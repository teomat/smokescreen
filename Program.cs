using System.CommandLine;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Storage;
using Windows.System.UserProfile;

namespace smokescreen;

static class Program
{
    internal static bool DevMode = Debugger.IsAttached;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    static async Task Main(string[] args)
    {
        // root command
        var rootCommand = new RootCommand("A prank lockscreen");
        rootCommand.SetHandler(RunSmokescreen);

        // lockscreen image subcommand
        var lockscreenCommand = new Command("setlockscreen", "Set the lockscreen image");
        var fileArgument = new Argument<FileInfo>(
            name: "image path",
            description: "Path of the image to set as the lockscreen.");
        lockscreenCommand.AddArgument(fileArgument);
        lockscreenCommand.SetHandler(async (file) =>
        {
            await SetLockscreenImage(file.FullName);
        }, fileArgument);

        // run the thing
        rootCommand.AddCommand(lockscreenCommand);
        await rootCommand.InvokeAsync(args);
    }

    static async Task SetLockscreenImage(string path)
    {
        var folder = Path.GetDirectoryName(path);
        var file = Path.GetFileName(path);

        var sf = await StorageFolder.GetFolderFromPathAsync(folder);
        var imgFile = await sf.GetFileAsync(file);

        using (var stream = await imgFile.OpenAsync(FileAccessMode.Read))
        {
            await LockScreen.SetImageStreamAsync(stream);
        }
    }

    static void RunSmokescreen()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var appContext = new SmokescreenAppContext();
        Application.Run(appContext);
    }

    static class Win32
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);

        [DllImport("user32")]
        public static extern bool UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32")]
        public static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);

        [DllImport("kernel32")]
        public static extern IntPtr GetModuleHandle(string name);

        [DllImport("kernel32")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x0100;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
    }

    class SmokescreenAppContext : ApplicationContext
    {
        private IntPtr KeyboardHookId { get; }
        private Win32.LowLevelKeyboardProc KeyboardProc { get; }
        private List<Form> Forms { get; } = new List<Form>();

        public SmokescreenAppContext()
        {
            var consoleWindow = Win32.GetConsoleWindow();
            Win32.ShowWindow(consoleWindow, Win32.SW_HIDE);

            KeyboardProc = KeyboardProcCallback;
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule!)
            {
                KeyboardHookId = Win32.SetWindowsHookEx(Win32.WH_KEYBOARD_LL, KeyboardProc,
                    Win32.GetModuleHandle(curModule.ModuleName), 0);
            }

            Application.ApplicationExit += OnApplicationExit;

            var screens = new List<(Screen Screen, Bitmap Bitmap)>();

            foreach (var screen in Screen.AllScreens)
            {
                var bounds = screen.Bounds;
                var bitmap = new Bitmap(bounds.Width, bounds.Height);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bitmap.Size);
                }
                screens.Add((screen, bitmap));
            }

            foreach (var (screen, bitmap) in screens)
            {
                var bounds = screen.Bounds;

                var screenshotForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.Manual,
                    Bounds = bounds,
                    BackgroundImage = bitmap,
                    KeyPreview = true,
                    TopMost = true,
                };

                screenshotForm.FormClosing += OnFormClosing;
                screenshotForm.Click += OnScreenshotFormClick;
                screenshotForm.KeyDown += OnScreenshotFormDown;

                screenshotForm.Show();
                Forms.Add(screenshotForm);
            }

            // bring the forms to the foreground continiously to counteract any other programs popping up
            var makeFormTopmostTimer = new System.Windows.Forms.Timer()
            {
                Interval = 100,
            };
            makeFormTopmostTimer.Tick += (sender, ev) =>
            {
                foreach (var form in Forms)
                {
                    form.BringToFront();
                }
            };
            makeFormTopmostTimer.Start();
        }

        protected override void Dispose(bool disposing)
        {
            Win32.UnhookWindowsHookEx(KeyboardHookId);

            base.Dispose(disposing);
        }

        private IntPtr KeyboardProcCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // we ignore any windows key presses as those mess with our illusion
            if (nCode >= 0 && wParam == (IntPtr)Win32.WM_KEYDOWN)
            {
                var key = (Keys)Marshal.ReadInt32(lParam);
                if (key == Keys.LWin || key == Keys.RWin)
                {
                    return (IntPtr)1;
                }
            }
            return Win32.CallNextHookEx(KeyboardHookId, nCode, wParam, lParam);
        }

        private void LockScreens()
        {
            Cursor.Show();
            if (!DevMode)
            {
                Win32.LockWorkStation();
            }
            Environment.Exit(0);
        }

        private void SimulateBluescreen()
        {
            foreach (var form in Forms)
            {
                form.Hide();
            }

            if (!DevMode)
            {
                RunExternalCommand();
                Cursor.Hide();
            }

            // make all secondary screens black
            foreach (var screen in Screen.AllScreens)
            {
                if (screen.Primary) continue;

                var bounds = screen.Bounds;

                var bluescreenForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.Manual,
                    Bounds = bounds,
                    BackColor = Color.Black,
                    KeyPreview = true,
                    TopMost = !DevMode,
                };

                bluescreenForm.FormClosing += OnFormClosing;

                bluescreenForm.Show();
                Forms.Add(bluescreenForm);
            }

            // create bluescreen window on the main screen
            {
                var screen = Screen.PrimaryScreen!;
                var bounds = screen.Bounds;

                var bluescreenForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.Manual,
                    Bounds = bounds,
                    BackColor = Color.FromArgb(255, 0, 120, 215),
                    KeyPreview = true,
                    TopMost = !DevMode,
                };
                var mainPanel = new Panel()
                {
                    Bounds = bounds,
                    BackColor = Color.Transparent,
                };
                bluescreenForm.Controls.Add(mainPanel);

                var bluescreenPanel = new BluescreenPanel()
                {
                    BackColor = Color.Transparent,
                    Anchor = AnchorStyles.None,
                    Dock = DockStyle.Fill,
                };
                bluescreenPanel.InitInstance();
                mainPanel.Controls.Add(bluescreenPanel);

                bluescreenForm.FormClosing += OnFormClosing;

                bluescreenForm.Show();
                Forms.Add(bluescreenForm);
            }
        }

        private void RunExternalCommand()
        {
            var exeDir = Path.GetDirectoryName(Environment.ProcessPath) ?? "";
            var commandPath = Path.Combine(exeDir, "command.bat");
            if (File.Exists(commandPath))
            {
                var procInfo = new ProcessStartInfo(commandPath)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                };

                Process.Start(procInfo);
            }
        }

        private void OnScreenshotFormDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                LockScreens();
            }
            else
            {
                SimulateBluescreen();
            }
        }

        private void OnScreenshotFormClick(object? sender, EventArgs e)
        {
            SimulateBluescreen();
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            LockScreens();
        }

        private void OnApplicationExit(object? sender, EventArgs e)
        {
            LockScreens();
        }
    }
}