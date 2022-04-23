using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gifer {
  public partial class NotificationWindow : Form {

    private class NotificationMessage {


      public NotificationMessage() {
      }
    }

    Timer timer;
    PriorityQueue<Label, DateTime> priorityQueue = new PriorityQueue<Label, DateTime>();
    public NotificationWindow() {
      InitializeComponent();
      this.Visible = false;
      timer = new Timer();
      timer.Interval = 100;
      timer.Tick += NotificationsCleaner;
      timer.Start();
      PlaceBottomRight();
    }

    private void NotificationsCleaner(object sender, EventArgs e) {
      while (priorityQueue.TryPeek(out Label label, out DateTime time) && DateTime.Now > time) {
        priorityQueue.Dequeue();
        if (!label.Visible) {
          continue;
        }
        label.Hide();
        notifications.Controls.Remove(label);
        if (notifications.Controls.Count == 0) {
          this.Hide();
        }
      }
    }

    public void AddMessage(string text, int delayMillis, Color? color = null) {
      Label label = new Label();
      label.Text = text;
      label.AutoSize = true;
      label.Anchor = AnchorStyles.Left;
      label.Font = new Font("Arial", 30);
      if (color != null) {
        label.ForeColor = color.Value;
      }
      priorityQueue.Enqueue(label, DateTime.Now.AddMilliseconds(delayMillis));
      label.Show();
      notifications.Controls.Add(label);
      if (notifications.Width < label.Width) {
        notifications.Width = label.Width; 
      }
      PlaceBottomRight();
      if (!this.Visible) {
        this.Show();
      }
    }

    private void NotificationWindow_Resize(object sender, EventArgs e) {
      PlaceBottomRight();
    }

    void PlaceBottomRight() {
      var primaryScreen = Screen.PrimaryScreen;
      this.Left = primaryScreen.WorkingArea.Right - this.Width;
      this.Top = primaryScreen.WorkingArea.Bottom - this.Height;
    }
  }
}
