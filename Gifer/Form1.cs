using mrousavy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using Xabe.FFmpeg;

namespace Gifer {
  public partial class Form1 : Form {

    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, System.Windows.Input.ModifierKeys fsModifiers, int vlc);

    public Form1() {
      InitializeComponent();
      RegisterHotKey(Handle, 1, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.A));
      RegisterHotKey(Handle, 2, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.S));
      RegisterHotKey(Handle, 3, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.Z));
    }

    private void CutGif(int from, int to, String filePath) {
      var mediaInfo = MediaInfo.Get(filePath).Result;
      var videoStream = mediaInfo.VideoStreams.First().SetSeek(TimeSpan.FromMilliseconds(from));
      var fileName = Path.GetFileNameWithoutExtension(filePath);
      var resultName = fileName + "_" + from + "_" + to + ".mp4";
      var videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
      var resultPath = Path.Combine(videoPath, resultName);
      var conv = new Conversion().AddStream(videoStream)
  .SetOutputPixelFormat(Xabe.FFmpeg.Enums.PixelFormat.Yuv420P)
  .SetInputTime(TimeSpan.FromMilliseconds(to - from))
  .AddParameter("-vf \"scale=iw*sar:ih, scale='min(800,iw)':-2\" -crf 28 ")
  .SetOutput(resultPath).SetOverwriteOutput(true);
      var result = conv.Start().Result;
      if (!result.Success) {
        MessageBox.Show("Failed!", "Conversion");
      }
    }

    int start = -1;
    int end = -1;
    String fileName = "";
    VideoPlayerAPI api = new MPCAPI();

    protected override void WndProc(ref Message m) {
      if (m.Msg == 0x0312) {
        switch (m.WParam.ToInt32()) {
          case 1: {
              PlayerState state = api.GetPlayerState();
              if (fileName != state.filePath) {
                fileName = state.filePath;
                end = -1;
              }
              start = state.position;
            }
            break;
          case 2: {
              PlayerState state = api.GetPlayerState();
              if (fileName != state.filePath) {
                fileName = state.filePath;
                start = -1;
              }
              end = state.position;
            }
            break;
          case 3: {
              if (start != -1 && end != -1) {
                CutGif(start, end, fileName);
              }
            }
            break;
        }
      }
      base.WndProc(ref m);
    }
  }
}
