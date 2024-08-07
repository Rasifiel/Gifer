namespace Gifer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.VLCRadioButton = new System.Windows.Forms.RadioButton();
      this.MPCRadioButton = new System.Windows.Forms.RadioButton();
      this.CRFValue = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.crfToolTip = new System.Windows.Forms.ToolTip(this.components);
      this.label2 = new System.Windows.Forms.Label();
      this.SubtitesSize = new System.Windows.Forms.NumericUpDown();
      this.configHotkeysButton = new System.Windows.Forms.Button();
      this.customGifGroupBox = new System.Windows.Forms.GroupBox();
      this.selectStreamsButton = new System.Windows.Forms.Button();
      this.fullResolutionCheck = new System.Windows.Forms.CheckBox();
      this.keepSubsCheck = new System.Windows.Forms.CheckBox();
      this.keepAudioCheck = new System.Windows.Forms.CheckBox();
      this.BtnDnldFFmpeg = new System.Windows.Forms.Button();
      this.trayMenu.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CRFValue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SubtitesSize)).BeginInit();
      this.customGifGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // trayIcon
      // 
      this.trayIcon.ContextMenuStrip = this.trayMenu;
      this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
      this.trayIcon.Text = "Gifer";
      this.trayIcon.Visible = true;
      // 
      // trayMenu
      // 
      this.trayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size(135, 42);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(134, 38);
      this.quitToolStripMenuItem.Text = "Quit";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.VLCRadioButton);
      this.groupBox1.Controls.Add(this.MPCRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(20, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(228, 142);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Video player";
      // 
      // VLCRadioButton
      // 
      this.VLCRadioButton.AutoSize = true;
      this.VLCRadioButton.Location = new System.Drawing.Point(10, 93);
      this.VLCRadioButton.Name = "VLCRadioButton";
      this.VLCRadioButton.Size = new System.Drawing.Size(85, 36);
      this.VLCRadioButton.TabIndex = 1;
      this.VLCRadioButton.TabStop = true;
      this.VLCRadioButton.Text = "VLC";
      this.VLCRadioButton.UseVisualStyleBackColor = true;
      this.VLCRadioButton.CheckedChanged += new System.EventHandler(this.VLCRadioButton_CheckedChanged);
      // 
      // MPCRadioButton
      // 
      this.MPCRadioButton.AutoSize = true;
      this.MPCRadioButton.Location = new System.Drawing.Point(10, 35);
      this.MPCRadioButton.Name = "MPCRadioButton";
      this.MPCRadioButton.Size = new System.Drawing.Size(95, 36);
      this.MPCRadioButton.TabIndex = 0;
      this.MPCRadioButton.TabStop = true;
      this.MPCRadioButton.Text = "MPC";
      this.MPCRadioButton.UseVisualStyleBackColor = true;
      this.MPCRadioButton.CheckedChanged += new System.EventHandler(this.MPCRadioButton_CheckedChanged);
      // 
      // CRFValue
      // 
      this.CRFValue.Location = new System.Drawing.Point(28, 227);
      this.CRFValue.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
      this.CRFValue.Name = "CRFValue";
      this.CRFValue.Size = new System.Drawing.Size(218, 39);
      this.CRFValue.TabIndex = 2;
      this.crfToolTip.SetToolTip(this.CRFValue, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      this.CRFValue.ValueChanged += new System.EventHandler(this.CRFValue_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(29, 178);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(204, 32);
      this.label1.TabIndex = 3;
      this.label1.Text = "CRF (quality 0-51)";
      this.crfToolTip.SetToolTip(this.label1, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      // 
      // crfToolTip
      // 
      this.crfToolTip.ToolTipTitle = "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(29, 285);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(165, 32);
      this.label2.TabIndex = 4;
      this.label2.Text = "Subtitles scale";
      this.crfToolTip.SetToolTip(this.label2, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      // 
      // SubtitesSize
      // 
      this.SubtitesSize.DecimalPlaces = 1;
      this.SubtitesSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.SubtitesSize.Location = new System.Drawing.Point(28, 320);
      this.SubtitesSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.SubtitesSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.SubtitesSize.Name = "SubtitesSize";
      this.SubtitesSize.Size = new System.Drawing.Size(218, 39);
      this.SubtitesSize.TabIndex = 5;
      this.crfToolTip.SetToolTip(this.SubtitesSize, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      this.SubtitesSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.SubtitesSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // configHotkeysButton
      // 
      this.configHotkeysButton.Location = new System.Drawing.Point(28, 387);
      this.configHotkeysButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
      this.configHotkeysButton.Name = "configHotkeysButton";
      this.configHotkeysButton.Size = new System.Drawing.Size(218, 61);
      this.configHotkeysButton.TabIndex = 6;
      this.configHotkeysButton.Text = "Config hotkeys";
      this.configHotkeysButton.UseVisualStyleBackColor = true;
      this.configHotkeysButton.Click += new System.EventHandler(this.configHotkeysButton_Click);
      // 
      // customGifGroupBox
      // 
      this.customGifGroupBox.Controls.Add(this.selectStreamsButton);
      this.customGifGroupBox.Controls.Add(this.fullResolutionCheck);
      this.customGifGroupBox.Controls.Add(this.keepSubsCheck);
      this.customGifGroupBox.Controls.Add(this.keepAudioCheck);
      this.customGifGroupBox.Location = new System.Drawing.Point(24, 490);
      this.customGifGroupBox.Name = "customGifGroupBox";
      this.customGifGroupBox.Size = new System.Drawing.Size(328, 262);
      this.customGifGroupBox.TabIndex = 7;
      this.customGifGroupBox.TabStop = false;
      this.customGifGroupBox.Text = "Custom Gif settings";
      // 
      // selectStreamsButton
      // 
      this.selectStreamsButton.Location = new System.Drawing.Point(16, 205);
      this.selectStreamsButton.Name = "selectStreamsButton";
      this.selectStreamsButton.Size = new System.Drawing.Size(289, 51);
      this.selectStreamsButton.TabIndex = 3;
      this.selectStreamsButton.Text = "Select streams";
      this.selectStreamsButton.UseVisualStyleBackColor = true;
      this.selectStreamsButton.Click += new System.EventHandler(this.button1_Click);
      // 
      // fullResolutionCheck
      // 
      this.fullResolutionCheck.AutoSize = true;
      this.fullResolutionCheck.Location = new System.Drawing.Point(16, 138);
      this.fullResolutionCheck.Name = "fullResolutionCheck";
      this.fullResolutionCheck.Size = new System.Drawing.Size(198, 36);
      this.fullResolutionCheck.TabIndex = 2;
      this.fullResolutionCheck.Text = "Full resolution";
      this.fullResolutionCheck.UseVisualStyleBackColor = true;
      this.fullResolutionCheck.Click += new System.EventHandler(this.fullResolutionCheck_CheckedChanged);
      // 
      // keepSubsCheck
      // 
      this.keepSubsCheck.AutoSize = true;
      this.keepSubsCheck.Location = new System.Drawing.Point(16, 93);
      this.keepSubsCheck.Name = "keepSubsCheck";
      this.keepSubsCheck.Size = new System.Drawing.Size(155, 36);
      this.keepSubsCheck.TabIndex = 1;
      this.keepSubsCheck.Text = "Keep subs";
      this.keepSubsCheck.UseVisualStyleBackColor = true;
      this.keepSubsCheck.Click += new System.EventHandler(this.keepSubsCheck_CheckedChanged);
      // 
      // keepAudioCheck
      // 
      this.keepAudioCheck.AutoSize = true;
      this.keepAudioCheck.Location = new System.Drawing.Point(16, 46);
      this.keepAudioCheck.Name = "keepAudioCheck";
      this.keepAudioCheck.Size = new System.Drawing.Size(167, 36);
      this.keepAudioCheck.TabIndex = 0;
      this.keepAudioCheck.Text = "Keep audio";
      this.keepAudioCheck.UseVisualStyleBackColor = true;
      this.keepAudioCheck.Click += new System.EventHandler(this.keepAudioCheck_CheckedChanged);
      // 
      // BtnDnldFFmpeg
      // 
      this.BtnDnldFFmpeg.Location = new System.Drawing.Point(41, 774);
      this.BtnDnldFFmpeg.Name = "BtnDnldFFmpeg";
      this.BtnDnldFFmpeg.Size = new System.Drawing.Size(289, 51);
      this.BtnDnldFFmpeg.TabIndex = 4;
      this.BtnDnldFFmpeg.Text = "Download FFmpeg";
      this.BtnDnldFFmpeg.UseVisualStyleBackColor = true;
      this.BtnDnldFFmpeg.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(377, 843);
      this.Controls.Add(this.BtnDnldFFmpeg);
      this.Controls.Add(this.customGifGroupBox);
      this.Controls.Add(this.configHotkeysButton);
      this.Controls.Add(this.SubtitesSize);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CRFValue);
      this.Controls.Add(this.groupBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.ShowIcon = false;
      this.Text = "Gifer";
      this.trayMenu.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CRFValue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SubtitesSize)).EndInit();
      this.customGifGroupBox.ResumeLayout(false);
      this.customGifGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton VLCRadioButton;
    private System.Windows.Forms.RadioButton MPCRadioButton;
    private System.Windows.Forms.NumericUpDown CRFValue;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToolTip crfToolTip;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown SubtitesSize;
    private System.Windows.Forms.Button configHotkeysButton;
        private System.Windows.Forms.GroupBox customGifGroupBox;
        private System.Windows.Forms.CheckBox fullResolutionCheck;
        private System.Windows.Forms.CheckBox keepSubsCheck;
        private System.Windows.Forms.CheckBox keepAudioCheck;
    private System.Windows.Forms.Button selectStreamsButton;
        private System.Windows.Forms.Button BtnDnldFFmpeg;
    }
}

