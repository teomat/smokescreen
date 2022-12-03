using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smokescreen
{
    public partial class BluescreenPanel : UserControl
    {
        private TimeSpan CounterTime => TimeSpan.FromSeconds(5);
        private TimeSpan TimeTillLock => TimeSpan.FromSeconds(10);

        private Stopwatch Stopwatch { get; } = new Stopwatch();

        public BluescreenPanel()
        {
            InitializeComponent();
        }

        public void InitInstance()
        {
            const string qrCodeText = "windows.com/stopcode";


            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(4, Color.FromArgb(255, 0, 120, 215), Color.White, true);
                pnlQrCode.BackgroundImage = qrCodeImage;
                pnlQrCode.Size = qrCodeImage.Size;
                pnlQrContainer.Size = qrCodeImage.Size;
                pnlBottom.Height = qrCodeImage.Height;
            }

            timer.Start();
            Stopwatch.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;

            var percentage = Math.Ceiling(Math.Clamp(elapsed / CounterTime, 0.0, 1.0) * 100);
            lblPercentage.Text = $"{percentage}% complete";

            if (elapsed >= TimeTillLock && !Program.DevMode)
            {
                ParentForm?.Close();
            }
        }
    }
}
