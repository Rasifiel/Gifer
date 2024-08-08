# Gifer - tool to create "gifs" from your video player.
## Download
[Download Gifer 1.19](https://katou.moe/gifer/gifer-1.19.zip).  
[Changelog](https://katou.moe/gifer/changelog.html).

## Compatibility
Gifer can work with video players from MPC family (MPC, MPC-BE, MPC-HC) and VLC media player.
Gifer outputs mp4 video files using h264 codec. Output has width of 800 pixels or less if original video has lesser resolution.

## Initial setup
Extract Gifer to any folder.  
If you are using MPC player:  
* Enable web interface  
![Enable web interface](https://katou.moe/gifer/img/mpc.png)

If you are using VLC player:  
1. Enable web interface.  
![Enable web interface](https://katou.moe/gifer/img/vlc1.png)
2. Set password to '12345'  
![Set password to '12345'](https://katou.moe/gifer/img/vlc2.png)

Launch Gifer executable.  
Select your video player:  
![Main Gifer window](https://katou.moe/gifer/img/gifer_main.png)

Now you can close this window (Gifer minimizes to system tray) and start using Gifer.

## How to use Gifer
Gifer is running in the background. You can use global hotkeys to interact with it.
* **Ctrl+Alt+Shift+A**. Marks current position in video player as starting point. 
* **Ctrl+Alt+Shift+S**. Marks current position in video player as ending point.
* **Ctrl+Alt+Shift+Z**. Starts building "gif" for marked starting and ending points. 
* **Ctrl+Alt+Shift+X**. Shows padding dialog. Starts building "gif" for marked starting and ending points adding padding in the before start and after finish. 
* **Ctrl+Alt+Shift+C**. Shows cropping dialog. Starts building "gif" for marked starting and ending points cropping video frame. 
* **Ctrl+Alt+Shift+V**. Starts building "gif" for marked starting and ending points with subtitles.  

### Workflow
You select start and finish for moment that you want to cut using player seek bar (it can be helpful to use next/previous frame keybindings to select precise moments). After you start gif building process. When building process is finished Gifer will show notification in system tray. Built "gif" is placed in default Videos folder and also in clipboard, so you can use it immediately. 

### Padding dialog
![Padding dialog](https://katou.moe/gifer/img/gifer_pad.png)

**Start** is amount of padding added before first frame of the gif. **End** is amount of padding added after last frame of the gif. Padding is using first and last frame of the gif for start and end.

### Cropping dialog

### Dependencies
This project is built using [FFmpeg](https://ffmpeg.org), [Cyotek image box component](cyotek.com/blog/tag/imagebox), [Autoupdate.NET](https://github.com/ravibpatel/AutoUpdater.NET), [Newtonsoft JSON](https://www.newtonsoft.com/json), [Xabe FFmpeg wrapper](https://xabe.net/product/xabe_ffmpeg/).

