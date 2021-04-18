using AutoUpdaterDotNET;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
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

    private static void WriteToLog(String message) {
      using (EventLog eventLog = new EventLog("Application")) {
        eventLog.Source = "Application";
        eventLog.WriteEntry("Gifer error: "+message, EventLogEntryType.Information, 101, 1);
      }
    }

    public MainForm() {
      AutoUpdater.InstalledVersion = new Version("1.1");
      AutoUpdater.Start("https://katou.moe/gifer/manifest.xml");
      InitializeComponent();
      RegisterHotKey(Handle, 1, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.A));
      RegisterHotKey(Handle, 2, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.S));
      RegisterHotKey(Handle, 3, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.Z));
      RegisterHotKey(Handle, 4, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.C));
      RegisterHotKey(Handle, 5, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Shift, KeyInterop.VirtualKeyFromKey(Key.X));
      trayIcon.Visible = true;
    }
    const int kWarningTresholdMin = 5;
    private void CutGif(int from, int to, String filePath, String additionalFilter) {
      if (from > to) {
        int t = from;
        from = to;
        to = t;
      }
      if (from == to) {
        trayIcon.ShowBalloonTip(2000, "", "Start and end markers have same position", ToolTipIcon.Warning);
        return;
      }
      if (TimeSpan.FromMilliseconds(to - from) > TimeSpan.FromMinutes(kWarningTresholdMin)) {
        if (MessageBox.Show("You selected timespan longer than 5 minutes. Do you want proceed?", "Gifer", MessageBoxButtons.YesNo) != DialogResult.Yes) {
          return;
        }
      }
      var mediaInfo = MediaInfo.Get(filePath).Result;
      var videoStream = mediaInfo.VideoStreams.First().SetSeek(TimeSpan.FromMilliseconds(from));
      var fileName = Path.GetFileNameWithoutExtension(filePath);
      var resultName = fileName + "_" + from + "_" + to + ".mp4";
      var videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
      var resultPath = Path.Combine(videoPath, resultName);
      var basicVf = "scale=iw*sar:ih, scale='min(800,iw)':-2";
      var vf = ((additionalFilter.Length != 0) ? (additionalFilter + ",") : "") + basicVf;
      var crf = Configuration.CRF;
      var conv = new Conversion().AddStream(videoStream)
        .SetOutputPixelFormat(Xabe.FFmpeg.Enums.PixelFormat.Yuv420P)
        .SetInputTime(TimeSpan.FromMilliseconds(to - from))
        .AddParameter($"-vf \"{vf}\" -crf {crf} -profile:v baseline")
        .SetOutput(resultPath).SetOverwriteOutput(true);
      var convProcess = conv.Start();
      convProcess.Wait();
      if (convProcess.Status != System.Threading.Tasks.TaskStatus.RanToCompletion || !convProcess.Result.Success) {
        if (convProcess.Exception != null) {
          WriteToLog(convProcess.Exception.ToString());
        } else {
          WriteToLog(convProcess.Result.ToString());
        }
        trayIcon.ShowBalloonTip(2000, "", "Building gif failed", ToolTipIcon.Error);
        return;
      }
      trayIcon.ShowBalloonTip(500, "", "Finished building gif", ToolTipIcon.None);
      StringCollection resultList = new StringCollection {
        resultPath
      };
      Clipboard.SetFileDropList(resultList);
    }

    int start = -1;
    int end = -1;
    String fileName = "";
    ImageCropDialog imageCropDialog = new ImageCropDialog();
    PaddingDialog paddingDialog = new PaddingDialog();

    protected override void WndProc(ref Message m) {
      if (m.Msg == 0x0312) {
        switch (m.WParam.ToInt32()) {
          case 1: {
              PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
              if (state.position == -1) {
                trayIcon.ShowBalloonTip(4000, "", "Can't connect to video player", ToolTipIcon.Error);
              } else {
                if (fileName != state.filePath) {
                  fileName = state.filePath;
                  end = -1;
                }
                start = state.position;
                trayIcon.ShowBalloonTip(500, "", "Marked start position " + TimeSpan.FromMilliseconds(start).ToString(), ToolTipIcon.None);
              }
            }
            break;
          case 2: {
              PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
              if (state.position == -1) {
                trayIcon.ShowBalloonTip(4000, "", "Can't connect to video player", ToolTipIcon.Error);
              } else {
                if (fileName != state.filePath) {
                  fileName = state.filePath;
                  start = -1;
                }
                end = state.position;
                trayIcon.ShowBalloonTip(500, "", "Marked end position " + TimeSpan.FromMilliseconds(end).ToString(), ToolTipIcon.None);
              }
            }
            break;
          case 3: {
              if (start != -1 && end != -1) {
                if (start > end) {
                  int t = start;
                  start = end;
                  end = t;
                }
                CutGif(start, end, fileName, "");
              }
            }
            break;
          case 4: {
              if (start != -1 && end != -1) {
                if (start > end) {
                  int t = start;
                  start = end;
                  end = t;
                }
                ShowCropDialog();
              }
            }
            break;
          case 5: {
              if (start != -1 && end != -1) {
                if (start > end) {
                  int t = start;
                  start = end;
                  end = t;
                }
                ShowPadDialog();
              }
            }
            break;
        }
      }
      base.WndProc(ref m);
    }

    private void ShowCropDialog() {
      PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
      if (state.position == -1) {
        trayIcon.ShowBalloonTip(4000, "", "Can't connect to video player", ToolTipIcon.Error);
        return;
      }
      String screenPath = Path.ChangeExtension(Path.GetTempFileName(), "png");
      var result = Conversion.Snapshot(state.filePath, screenPath, TimeSpan.FromMilliseconds(state.position)).Start().Result;
      if (!result.Success) {
        trayIcon.ShowBalloonTip(4000, "", "Getting screenshot failed", ToolTipIcon.Error);
        return;
      }
      var image = Image.FromFile(screenPath);
      imageCropDialog.imageCropBox.Image = image;
      imageCropDialog.imageCropBox.SelectNone();
      var display = Screen.PrimaryScreen.WorkingArea;
      double wScale = image.Width * 1.0 / display.Width;
      double hScale = image.Height * 1.0 / display.Height;
      double maxScale = Math.Max(wScale, hScale);
      if (maxScale <= 1.0) {
        imageCropDialog.Size = image.Size;
      } else {
        imageCropDialog.Width = (int)(image.Width / maxScale);
        imageCropDialog.Height = (int)(image.Height / maxScale);
      }
      if (imageCropDialog.ShowDialog() == DialogResult.Cancel) { return; }
      var region = imageCropDialog.imageCropBox.SelectionRegion;
      String crop = String.Format("crop={0}:{1}:{2}:{3}", (int)region.Width, (int)region.Height, (int)region.X, (int)region.Y);
      CutGif(start, end, fileName, crop);
    }

    private void ShowPadDialog() {
      if (paddingDialog.ShowDialog() == DialogResult.Cancel) { return; }
      String padding_vf = String.Format("tpad=start_mode=clone:start_duration={0}ms:stop_mode=clone:stop_duration={1}ms", paddingDialog.startDur.Text, paddingDialog.stopDur.Text);
      CutGif(start, end, fileName, padding_vf);
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void MPCRadioButton_CheckedChanged(object sender, EventArgs e) {
      if (MPCRadioButton.Checked) {
        Configuration.CurrentPlayer = VideoPlayer.MPC;
      }
    }

    private void VLCRadioButton_CheckedChanged(object sender, EventArgs e) {
      if (VLCRadioButton.Checked) {
        Configuration.CurrentPlayer = VideoPlayer.VLC;
      }
    }

    private void MainForm_Load(object sender, EventArgs e) {
      if (Configuration.CurrentPlayer == VideoPlayer.MPC) {
        MPCRadioButton.Checked = true;
      } else {
        VLCRadioButton.Checked = true;
      }
      CRFValue.Value = Configuration.CRF;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        Hide();
        e.Cancel = true;
      }
    }

    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
      Show();
    }

    private void CRFValue_ValueChanged(object sender, EventArgs e) {
      Configuration.CRF = (int)CRFValue.Value;
    }
  }
}