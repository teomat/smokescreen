# smokescreen

A prank lockscreen for windows 10.

Running smokescreen.exe will "lock" your computer and intercept all inputs.
When any key or mouse button is pressed, it shows a fake bluescreen and then locks your computer after a few seconds.

Do not actually use this as your proper lockscreen, this is likely way unsafe and there are definitly ways to circumvent it!

You can press the 'Home' key to bypass the bluescreen and lock your computer right away.

# fun things

You can put a file named 'command.bat' next to the smokescreen binary and when the bluescreen is triggered this batch file will be run.
In all examples from here on, we will assume that command.bat simply calls a powershell script and then do fun things from there.

command.bat:
```
powershell -ExecutionPolicy Bypass -File .\command.ps1
```

## recording our webcam
We can use VLC to record from our webcam to an mp4 file.
The following command will use the default audio and video input device to record a 15 second video.

command.ps1:
```
$filename = [dateTime]::Now.ToFileTime()
$filename = "..\\${filename}.mp4"

& 'C:\Program Files (x86)\VideoLAN\VLC\vlc.exe' dshow:// :dshow-vdev=  :dshow-adev=  :live-caching=300 :stop-time=15.000 :sout="#transcode{vcodec=h264,scale=1.0,acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}:file{dst=${filename}},no-overwrite}" :no-sout-all :sout-keep vlc://quit
```
