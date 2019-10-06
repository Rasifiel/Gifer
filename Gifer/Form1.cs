using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
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
      osd.Show();
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
        osd.ShowOSD("Building gif failed", 1000);
        return;
      }
      osd.ShowOSD("Finished building gif", 1000);
      StringCollection resultList = new StringCollection();
      resultList.Add(resultPath);
      Clipboard.SetFileDropList(resultList);
    }

    int start = -1;
    int end = -1;
    String fileName = "";
    VideoPlayerAPI api = new MPCAPI();
    OSDWindow osd = new OSDWindow();

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
              osd.ShowOSD("Marked start position " + TimeSpan.FromMilliseconds(start).ToString(), 1000);
            }
            break;
          case 2: {
              PlayerState state = api.GetPlayerState();
              if (fileName != state.filePath) {
                fileName = state.filePath;
                start = -1;
              }
              end = state.position;
              osd.ShowOSD("Marked end position " + TimeSpan.FromMilliseconds(end).ToString(), 1000);
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

    private void button1_Click(object sender, EventArgs e) {
      osd.ShowOSD("Test!"+new Random().Next(0,10000), 2000);
    }
  }

  internal class OSDWindow : Form {
    public OSDWindow() {
      this.Bounds = Screen.PrimaryScreen.Bounds;
      this.TopMost = true; // make the form always on top
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
      this.WindowState = FormWindowState.Maximized; // maximized
      this.MinimizeBox = this.MaximizeBox = false; // not allowed to be minimized
      this.MinimumSize = this.MaximumSize = this.Size; // not allowed to be resized
      this.TransparencyKey = this.BackColor = Color.Black; // the color key to transparent, choose a color that you don't use
      timer.Tick += delegate { if (needToClean && DateTime.Now >= timeToClean) { message = ""; needToClean = false; Refresh(); } };
      timer.Interval = 10;
      timer.Start();
    }
    protected override CreateParams CreateParams {
      get {
        CreateParams cp = base.CreateParams;
        // Set the form click-through
        cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
        return cp;
      }
    }

    private String message = "";
    private Font osdFont = new Font("Verdana", 26, FontStyle.Bold);
    private Timer timer = new Timer();
    private bool needToClean = false;
    private DateTime timeToClean;

    public void ShowOSD(String message, int time) {
      timeToClean = DateTime.Now.AddMilliseconds(time);
      needToClean = true;
      this.message = message;
      Refresh();
    }

    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      Graphics g = e.Graphics;
      g.TextRenderingHint =
   System.Drawing.Text.TextRenderingHint.AntiAlias;
      GraphicsPath gp = new GraphicsPath();
      gp.AddString(message, osdFont.FontFamily, (int)osdFont.Style, g.DpiY * osdFont.SizeInPoints / 72, new Point(0, 0), StringFormat.GenericDefault);
      g.SmoothingMode = SmoothingMode.HighQuality;
      g.Clear(Color.Black);
      g.FillPath(Brushes.Green, gp);
    }
  }
}
