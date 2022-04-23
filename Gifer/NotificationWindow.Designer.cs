namespace Gifer {
  partial class NotificationWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.notifications = new System.Windows.Forms.FlowLayoutPanel();
      this.SuspendLayout();
      // 
      // notifications
      // 
      this.notifications.AutoSize = true;
      this.notifications.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.notifications.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
      this.notifications.Location = new System.Drawing.Point(0, 0);
      this.notifications.Name = "notifications";
      this.notifications.Size = new System.Drawing.Size(0, 0);
      this.notifications.TabIndex = 0;
      // 
      // NotificationWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(669, 136);
      this.Controls.Add(this.notifications);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NotificationWindow";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "NotificationWindow";
      this.TopMost = true;
      this.Resize += new System.EventHandler(this.NotificationWindow_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel notifications;
  }
}