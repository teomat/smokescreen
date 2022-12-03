# smokescreen

A prank lockscreen for windows 10.

When you start this program it will "lock" your computer and intercept all inputs.
When any key or mouse button is pressed, a fake bluescreen is shown and after a few seconds your computer is locked.

Do not actually use this as your proper lockscreen, there are definitly ways to circumvent it!

You can press the 'Home' key to go straight bypass the bluescreen and lock your computer.

# fun things

You can put a file named 'command.bat' next to the smokescreen binary and when the bluescreen is triggered this batch file will be run.
In all examples from here on, we will assume that command.bat is used to call a powershell script and then do fun things with that.

command.bat:
```
powershell -ExecutionPolicy Bypass -File .\command.ps1
```

We can then use VLC to record from our webcam. The following command will use the default audio and video input device to record a 15 second video.

command.ps1:
```
$filename = [dateTime]::Now.ToFileTime()
$filename = "..\\${filename}.mp4"

& 'C:\Program Files (x86)\VideoLAN\VLC\vlc.exe' dshow:// :dshow-vdev=  :dshow-adev=  :live-caching=300 :stop-time=15.000 :sout="#transcode{vcodec=h264,scale=1.0,acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}:file{dst=${filename}},no-overwrite}" :no-sout-all :sout-keep vlc://quit
```
