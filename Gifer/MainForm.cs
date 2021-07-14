using AutoUpdaterDotNET;
using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using Xabe.FFmpeg;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Gifer {
  public partial class MainForm : Form {

    private static void WriteToLog(String message) {
      using (EventLog eventLog = new EventLog("Application")) {
        eventLog.Source = "Application";
        eventLog.WriteEntry("Gifer error: " + message, EventLogEntryType.Information, 101, 1);
      }
    }
    Notifier notifier = new Notifier(cfg => {
      cfg.PositionProvider = new PrimaryScreenPositionProvider(
          corner: Corner.BottomRight,
          offsetX: 10,
          offsetY: 10
        );
      cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
          notificationLifetime: TimeSpan.FromSeconds(2),
          maximumNotificationCount: MaximumNotificationCount.FromCount(3)
        );
      cfg.DisplayOptions.TopMost = true;
      cfg.DisplayOptions.Width = 200;
      cfg.Dispatcher = System.Windows.Application.Current.Dispatcher;
    }
    );

    enum MessageType {
      Info, Warning, Error, Success
    }

    private void ShowMessage(MessageType type, String message) {
      var opts = new MessageOptions {
        ShowCloseButton = true,
        FreezeOnMouseEnter = true,
        NotificationClickAction = n => { n.Close(); },
      };
      if (type == MessageType.Info) {
        notifier.ShowInformation(message, opts);
      } else if (type == MessageType.Warning) {
        notifier.ShowWarning(message, opts);
      } else if (type == MessageType.Error) {
        notifier.ShowError(message, opts);
      } else if (type == MessageType.Success) {
        notifier.ShowSuccess(message, opts);
      }
    }

    private void RegisterHotkeys(Dictionary<GiferActionId, GiferAction> keys) {
      foreach (var row in keys) {
        if (row.Value.Key == 0) {
          HotkeyManager.Current.Remove(row.Key.ToString());
        } else {
          HotkeyManager.Current.AddOrReplace(row.Key.ToString(), row.Value.Key, HotkeyHandler);
        }
      }
    }

    public MainForm() {
      AutoUpdater.InstalledVersion = new Version("1.4");
      AutoUpdater.Start("https://katou.moe/gifer/manifest.xml");
      InitializeComponent();
      RegisterHotkeys(Configuration.KeyConfig);
      trayIcon.Visible = true;
      DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(2) };
      timer.Tick += delegate {
        AutoUpdater.Start("https://katou.moe/gifer/manifest.xml");
      };
      timer.Start();
    }
    const int kWarningTresholdMin = 5;
    private void CutGif(int from, int to, String filePath, String additionalFilter, bool subtitles = false) {
      if (from > to) {
        int t = from;
        from = to;
        to = t;
      }
      if (from == to) {
        ShowMessage(MessageType.Warning, "Start and end markers have same position");
        return;
      }
      if (TimeSpan.FromMilliseconds(to - from) > TimeSpan.FromMinutes(kWarningTresholdMin)) {
        if (MessageBox.Show("You selected timespan longer than 5 minutes. Do you want proceed?", "Gifer", MessageBoxButtons.YesNo) != DialogResult.Yes) {
          return;
        }
      }
      var escapedPath = filePath.Replace("\\", "\\\\").Replace(":", "\\:");
      var mediaInfo = MediaInfo.Get(filePath).Result;
      var videoStream = mediaInfo.VideoStreams.First();
      var fileName = Path.GetFileNameWithoutExtension(filePath);
      var resultName = fileName + "_" + from + "_" + to + ".mp4";
      var videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
      var resultPath = Path.Combine(videoPath, resultName);
      var basicVf = "scale=iw*sar:ih, scale='min(800,iw)':-2";
      var subtitlesVf = subtitles ? $",subtitles='{escapedPath}':force_style='FontName=Open Sans Semibold,FontSize={Configuration.SubtitlesSize},PrimaryColour=&H00FFFFFF,Bold=1'" : "";
      var vf = ((additionalFilter.Length != 0) ? (additionalFilter + ",") : "") + basicVf + subtitlesVf;
      var crf = Configuration.CRF;
      var conv = new Conversion().AddStream(videoStream).AddParameter($"-ss {from}ms -to {to}ms -copyts", Xabe.FFmpeg.Enums.ParameterPosition.PreInput)
        .SetOutputPixelFormat(Xabe.FFmpeg.Enums.PixelFormat.Yuv420P)
        .AddParameter($"-vf \"{vf}\" -c:v libx264 -crf {crf} -profile:v baseline -ss {from}ms")
        .SetOutput(resultPath).SetOverwriteOutput(true);
      var convProcess = conv.Start();
      convProcess.Wait();
      if (convProcess.Status != System.Threading.Tasks.TaskStatus.RanToCompletion || !convProcess.Result.Success) {
        if (convProcess.Exception != null) {
          WriteToLog(convProcess.Exception.ToString());
        } else {
          WriteToLog(convProcess.Result.ToString());
        }
        ShowMessage(MessageType.Error, "Building gif failed");
        return;
      }
      ShowMessage(MessageType.Success, "Finished building gif");
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

    private void HotkeyHandler(object sender, HotkeyEventArgs e) {
      GiferActionId actionId;
      if (!Enum.TryParse(e.Name, out actionId)) {
        return;
      }
      switch (actionId) {
        case GiferActionId.MarkStart: {
            PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
            if (state.position == -1) {
              ShowMessage(MessageType.Error, "Can't connect to video player");
            } else {
              if (fileName != state.filePath) {
                fileName = state.filePath;
                end = -1;
              }
              start = state.position;
              ShowMessage(MessageType.Info, "Marked start position " + TimeSpan.FromMilliseconds(start).ToString());
            }
          }
          break;
        case GiferActionId.MarkEnd: {
            PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
            if (state.position == -1) {
              ShowMessage(MessageType.Error, "Can't connect to video player");
            } else {
              if (fileName != state.filePath) {
                fileName = state.filePath;
                start = -1;
              }
              end = state.position;
              ShowMessage(MessageType.Info, "Marked end position " + TimeSpan.FromMilliseconds(end).ToString());
            }
          }
          break;
        case GiferActionId.CreateDefault: {
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
        case GiferActionId.CreatePadded: {
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
        case GiferActionId.CreateCropped: {
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
        case GiferActionId.CreateWithSubs: {
            if (start != -1 && end != -1) {
              if (start > end) {
                int t = start;
                start = end;
                end = t;
              }
              CutGif(start, end, fileName, "", true);
            }
          }
          break;
      }
      e.Handled = true;
    }

    private void ShowCropDialog() {
      PlayerState state = VideoPlayerAPIFactory.CreateVideoPlayerAPI().GetPlayerState();
      if (state.position == -1) {
        ShowMessage(MessageType.Error, "Can't connect to video player");
        return;
      }
      String screenPath = Path.ChangeExtension(Path.GetTempFileName(), "png");
      var result = Conversion.Snapshot(state.filePath, screenPath, TimeSpan.FromMilliseconds(state.position)).Start().Result;
      if (!result.Success) {
        ShowMessage(MessageType.Error, "Getting screenshot failed");
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
      SubtitesSize.Value = Configuration.SubtitlesSize;
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

    private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
      Configuration.SubtitlesSize = (int)SubtitesSize.Value;
    }

    private void configHotkeysButton_Click(object sender, EventArgs e) {
      List<(int, String, Keys)> hotkeyList = new List<(int, string, Keys)>();
      foreach (var row in Configuration.KeyConfig) {
        hotkeyList.Add(( (int)row.Key, row.Value.Description, row.Value.Key));
      }
      hotkeyList = hotkeyList.OrderBy(t => t.Item1).ToList();
      HotkeyConfig hotkeyConfig = new HotkeyConfig(hotkeyList);
      HotkeyManager.Current.IsEnabled = false;
      if (hotkeyConfig.ShowDialog() == DialogResult.OK) {
        Configuration.KeyConfig = hotkeyConfig.result_;
        RegisterHotkeys(Configuration.KeyConfig);
      }
      HotkeyManager.Current.IsEnabled = true;
    }
  }
}