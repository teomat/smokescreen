# smokescreen

A prank lockscreen for windows 10.

Running smokescreen.exe will show a static picture of your screen and intercept all inputs.
When any key or mouse button is pressed, it shows a fake bluescreen and then locks your computer after a few seconds.

Do not actually use this as your proper lockscreen, this is likely way unsafe and there are definitly ways to circumvent it!

You can press the 'Home' key to bypass the bluescreen and lock your computer right away.

# fun things

You can put a file named 'command.bat' next to the smokescreen binary and when the bluescreen is triggered this batch file will be run.
First we're gonna launch a powershell script and do our things from there.

command.bat:
```
powershell -ExecutionPolicy Bypass -File .\command.ps1
```

The following script captures an image from our webcam using ffmpeg and sets it as the lockscreen.
It then records a 15 second video to capture the reaction of whoever triggered our trap.

command.ps1:
```
# capture an image
.\ffmpeg.exe -f vfwcap -i 0 -vframes 1 lockscreen.jpg

# set the lockscreen
.\smokescreen.exe setlockscreen lockscreen.jpg

$filename = [dateTime]::Now.ToFileTime()
$filename = "..\\${filename}.mp4"

# start a 15 second video capture
& 'C:\Program Files (x86)\VideoLAN\VLC\vlc.exe' dshow:// :dshow-vdev=  :dshow-adev=  :live-caching=300 :stop-time=15.000 :sout="#transcode{vcodec=h264,scale=1.0,acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}:file{dst=${filename}},no-overwrite}" :no-sout-all :sout-keep vlc://quit
```

We use VLC to record from the default audio and video input devices.
We could also use ffmpeg to record the video, but then we'd need to specify the devices by name.

We can list the devices and record with ffmpeg as follows:
```
.\ffmpeg.exe -list_devices true -f dshow -i dummy
.\ffmpeg.exe -y -t 10 -f dshow -i video="<VIDEO DEVICE NAME>":audio="<AUDIO DEVICE NAME>" out.mp4
```
