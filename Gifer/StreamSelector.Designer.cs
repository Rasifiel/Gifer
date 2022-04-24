namespace Gifer {
  partial class StreamSelector {
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.subtitleStreams = new System.Windows.Forms.GroupBox();
      this.subtitlesLayout = new System.Windows.Forms.FlowLayoutPanel();
      this.audioStreams = new System.Windows.Forms.GroupBox();
      this.audioLayout = new System.Windows.Forms.FlowLayoutPanel();
      this.OK = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.subtitleStreams.SuspendLayout();
      this.audioStreams.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.subtitleStreams, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.audioStreams, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 79);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // subtitleStreams
      // 
      this.subtitleStreams.AutoSize = true;
      this.subtitleStreams.Controls.Add(this.subtitlesLayout);
      this.subtitleStreams.Location = new System.Drawing.Point(3, 3);
      this.subtitleStreams.Name = "subtitleStreams";
      this.subtitleStreams.Size = new System.Drawing.Size(466, 73);
      this.subtitleStreams.TabIndex = 1;
      this.subtitleStreams.TabStop = false;
      this.subtitleStreams.Text = "Subtitle streams";
      // 
      // subtitlesLayout
      // 
      this.subtitlesLayout.AutoSize = true;
      this.subtitlesLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.subtitlesLayout.Location = new System.Drawing.Point(3, 35);
      this.subtitlesLayout.Name = "subtitlesLayout";
      this.subtitlesLayout.Size = new System.Drawing.Size(460, 0);
      this.subtitlesLayout.TabIndex = 0;
      this.subtitlesLayout.WrapContents = false;
      // 
      // audioStreams
      // 
      this.audioStreams.AutoSize = true;
      this.audioStreams.Controls.Add(this.audioLayout);
      this.audioStreams.Dock = System.Windows.Forms.DockStyle.Top;
      this.audioStreams.Location = new System.Drawing.Point(475, 3);
      this.audioStreams.Name = "audioStreams";
      this.audioStreams.Size = new System.Drawing.Size(466, 38);
      this.audioStreams.TabIndex = 0;
      this.audioStreams.TabStop = false;
      this.audioStreams.Text = "Audio streams";
      // 
      // audioLayout
      // 
      this.audioLayout.AutoSize = true;
      this.audioLayout.Dock = System.Windows.Forms.DockStyle.Top;
      this.audioLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.audioLayout.Location = new System.Drawing.Point(3, 35);
      this.audioLayout.Name = "audioLayout";
      this.audioLayout.Size = new System.Drawing.Size(460, 0);
      this.audioLayout.TabIndex = 0;
      this.audioLayout.WrapContents = false;
      // 
      // OK
      // 
      this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OK.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.OK.Location = new System.Drawing.Point(0, 76);
      this.OK.Name = "OK";
      this.OK.Size = new System.Drawing.Size(944, 60);
      this.OK.TabIndex = 1;
      this.OK.Text = "OK";
      this.OK.UseVisualStyleBackColor = true;
      // 
      // StreamSelector
      // 
      this.AcceptButton = this.OK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(944, 136);
      this.Controls.Add(this.OK);
      this.Controls.Add(this.tableLayoutPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "StreamSelector";
      this.ShowIcon = false;
      this.Text = "Stream selector";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.subtitleStreams.ResumeLayout(false);
      this.subtitleStreams.PerformLayout();
      this.audioStreams.ResumeLayout(false);
      this.audioStreams.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox subtitleStreams;
    private System.Windows.Forms.GroupBox audioStreams;
    private System.Windows.Forms.Button OK;
    private System.Windows.Forms.FlowLayoutPanel subtitlesLayout;
    private System.Windows.Forms.FlowLayoutPanel audioLayout;
  }
}