using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using Xabe.FFmpeg;

namespace Gifer {
  public partial class MainForm : Form {

    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, System.Windows.Input.ModifierKeys fsModifiers, int vlc);

    public MainForm() {
      InitializeComponent();
      RegisterHotKey(Handle, 1, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.A));
      RegisterHotKey(Handle, 2, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.S));
      RegisterHotKey(Handle, 3, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.Z));
      trayIcon.Visible = true;
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
        trayIcon.ShowBalloonTip(2000, "", "Building gif failed", ToolTipIcon.Error);
        return;
      }
      trayIcon.ShowBalloonTip(2000, "", "Finished building gif", ToolTipIcon.None);
      StringCollection resultList = new StringCollection {
        resultPath
      };
      Clipboard.SetFileDropList(resultList);
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
              if (state.position == -1) {
                trayIcon.ShowBalloonTip(4000, "", "Can't connect to video player", ToolTipIcon.Error);
              } else {
                if (fileName != state.filePath) {
                  fileName = state.filePath;
                  end = -1;
                }
                start = state.position;
                trayIcon.ShowBalloonTip(2000, "", "Marked start position " + TimeSpan.FromMilliseconds(start).ToString(), ToolTipIcon.None);
              }
            }
            break;
          case 2: {
              PlayerState state = api.GetPlayerState();
              if (state.position == -1) {
                trayIcon.ShowBalloonTip(4000, "", "Can't connect to video player", ToolTipIcon.Error);
              } else {
                if (fileName != state.filePath) {
                  fileName = state.filePath;
                  start = -1;
                }
                end = state.position;
                trayIcon.ShowBalloonTip(2000, "", "Marked end position " + TimeSpan.FromMilliseconds(end).ToString(), ToolTipIcon.None);
              }
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

    private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void MainForm_VisibleChanged(object sender, EventArgs e) {
      Visible = false;
    }
  }
}