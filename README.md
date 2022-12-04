# smokescreen

A prank lockscreen for windows 10.

Running smokescreen.exe will show a static picture of your screen and intercept all inputs.
When any key or mouse button is pressed, it shows a fake bluescreen and then locks your computer after a few seconds.

Do not actually use this as your proper lockscreen, this is likely way unsafe and there are definitly ways to circumvent it!

You can press the 'Home' key to bypass the bluescreen and lock your computer right away.

# fun things

We can put a file named 'command.bat' next to the smokescreen binary and when the bluescreen is triggered this batch file will be run.
First we're gonna launch a powershell script and do our things from there.

command.bat:
```
powershell -ExecutionPolicy Bypass -File .\command.ps1
```

The following script captures an image from our webcam using [ffmpeg](https://ffmpeg.org/download.html#build-windows) and sets it as the lockscreen.
It then records a 15 second video using [VLC](https://www.videolan.org/) to capture the reaction of whoever triggered our trap.

I use the ffmpeg release essentials build from [here](https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.7z).

command.ps1:
```
New-Item -ItemType Directory -Force -Path output
$timestamp = [dateTime]::Now.ToFileTime()

# capture an image
.\ffmpeg.exe -f vfwcap -i 0 -vframes 1 ".\\output\\${timestamp}.jpg"

# set the lockscreen image
.\smokescreen.exe setlockscreen ".\\output\\${timestamp}.jpg"

$videofile = ".\\output\\${timestamp}.mp4"

# start a 15 second video capture with VLC, this uses the default audio and video inputs
& 'C:\Program Files\VideoLAN\VLC\vlc.exe' dshow:// :dshow-vdev=  :dshow-adev=  :live-caching=300 :stop-time=15.000 :sout="#transcode{vcodec=h264,scale=1.0,acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}:file{dst=${videofile}},no-overwrite}" :no-sout-all :sout-keep vlc://quit

# or we can use ffmpeg to record audio and video, but for this we need to specify device names
# we can use `.\ffmpeg.exe -list_devices true -f dshow -i dummy` to get a list of available devices
# .\ffmpeg.exe -y -t 15 -f dshow -i video="<VIDEO DEVICE NAME>":audio="<AUDIO DEVICE NAME>" "${videofile}"

```
