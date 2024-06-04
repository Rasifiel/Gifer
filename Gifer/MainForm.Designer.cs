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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            trayIcon = new System.Windows.Forms.NotifyIcon(components);
            trayMenu = new System.Windows.Forms.ContextMenuStrip(components);
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox1 = new System.Windows.Forms.GroupBox();
            VLCRadioButton = new System.Windows.Forms.RadioButton();
            MPCRadioButton = new System.Windows.Forms.RadioButton();
            CRFValue = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            crfToolTip = new System.Windows.Forms.ToolTip(components);
            label2 = new System.Windows.Forms.Label();
            SubtitesSize = new System.Windows.Forms.NumericUpDown();
            configHotkeysButton = new System.Windows.Forms.Button();
            customGifGroupBox = new System.Windows.Forms.GroupBox();
            selectStreamsButton = new System.Windows.Forms.Button();
            fullResolutionCheck = new System.Windows.Forms.CheckBox();
            keepSubsCheck = new System.Windows.Forms.CheckBox();
            keepAudioCheck = new System.Windows.Forms.CheckBox();
            BtnDnldFFmpeg = new System.Windows.Forms.Button();
            trayMenu.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CRFValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubtitesSize).BeginInit();
            customGifGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Icon = (System.Drawing.Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "Gifer";
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
            // 
            // trayMenu
            // 
            trayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { quitToolStripMenuItem });
            trayMenu.Name = "trayMenu";
            trayMenu.Size = new System.Drawing.Size(107, 28);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(VLCRadioButton);
            groupBox1.Controls.Add(MPCRadioButton);
            groupBox1.Location = new System.Drawing.Point(12, 15);
            groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            groupBox1.Size = new System.Drawing.Size(140, 89);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Video player";
            // 
            // VLCRadioButton
            // 
            VLCRadioButton.AutoSize = true;
            VLCRadioButton.Location = new System.Drawing.Point(6, 58);
            VLCRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            VLCRadioButton.Name = "VLCRadioButton";
            VLCRadioButton.Size = new System.Drawing.Size(54, 24);
            VLCRadioButton.TabIndex = 1;
            VLCRadioButton.TabStop = true;
            VLCRadioButton.Text = "VLC";
            VLCRadioButton.UseVisualStyleBackColor = true;
            VLCRadioButton.CheckedChanged += VLCRadioButton_CheckedChanged;
            // 
            // MPCRadioButton
            // 
            MPCRadioButton.AutoSize = true;
            MPCRadioButton.Location = new System.Drawing.Point(6, 22);
            MPCRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            MPCRadioButton.Name = "MPCRadioButton";
            MPCRadioButton.Size = new System.Drawing.Size(60, 24);
            MPCRadioButton.TabIndex = 0;
            MPCRadioButton.TabStop = true;
            MPCRadioButton.Text = "MPC";
            MPCRadioButton.UseVisualStyleBackColor = true;
            MPCRadioButton.CheckedChanged += MPCRadioButton_CheckedChanged;
            // 
            // CRFValue
            // 
            CRFValue.Location = new System.Drawing.Point(17, 142);
            CRFValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            CRFValue.Maximum = new decimal(new int[] { 51, 0, 0, 0 });
            CRFValue.Name = "CRFValue";
            CRFValue.Size = new System.Drawing.Size(134, 27);
            CRFValue.TabIndex = 2;
            crfToolTip.SetToolTip(CRFValue, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
            CRFValue.ValueChanged += CRFValue_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 111);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(127, 20);
            label1.TabIndex = 3;
            label1.Text = "CRF (quality 0-51)";
            crfToolTip.SetToolTip(label1, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
            // 
            // crfToolTip
            // 
            crfToolTip.ToolTipTitle = "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 178);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 20);
            label2.TabIndex = 4;
            label2.Text = "Subtitles scale";
            crfToolTip.SetToolTip(label2, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
            // 
            // SubtitesSize
            // 
            SubtitesSize.DecimalPlaces = 1;
            SubtitesSize.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            SubtitesSize.Location = new System.Drawing.Point(17, 200);
            SubtitesSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            SubtitesSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            SubtitesSize.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            SubtitesSize.Name = "SubtitesSize";
            SubtitesSize.Size = new System.Drawing.Size(134, 27);
            SubtitesSize.TabIndex = 5;
            crfToolTip.SetToolTip(SubtitesSize, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
            SubtitesSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            SubtitesSize.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // configHotkeysButton
            // 
            configHotkeysButton.Location = new System.Drawing.Point(17, 242);
            configHotkeysButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            configHotkeysButton.Name = "configHotkeysButton";
            configHotkeysButton.Size = new System.Drawing.Size(134, 38);
            configHotkeysButton.TabIndex = 6;
            configHotkeysButton.Text = "Config hotkeys";
            configHotkeysButton.UseVisualStyleBackColor = true;
            configHotkeysButton.Click += configHotkeysButton_Click;
            // 
            // customGifGroupBox
            // 
            customGifGroupBox.Controls.Add(selectStreamsButton);
            customGifGroupBox.Controls.Add(fullResolutionCheck);
            customGifGroupBox.Controls.Add(keepSubsCheck);
            customGifGroupBox.Controls.Add(keepAudioCheck);
            customGifGroupBox.Location = new System.Drawing.Point(15, 306);
            customGifGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            customGifGroupBox.Name = "customGifGroupBox";
            customGifGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            customGifGroupBox.Size = new System.Drawing.Size(202, 164);
            customGifGroupBox.TabIndex = 7;
            customGifGroupBox.TabStop = false;
            customGifGroupBox.Text = "Custom Gif settings";
            // 
            // selectStreamsButton
            // 
            selectStreamsButton.Location = new System.Drawing.Point(10, 128);
            selectStreamsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            selectStreamsButton.Name = "selectStreamsButton";
            selectStreamsButton.Size = new System.Drawing.Size(178, 32);
            selectStreamsButton.TabIndex = 3;
            selectStreamsButton.Text = "Select streams";
            selectStreamsButton.UseVisualStyleBackColor = true;
            selectStreamsButton.Click += button1_Click;
            // 
            // fullResolutionCheck
            // 
            fullResolutionCheck.AutoSize = true;
            fullResolutionCheck.Location = new System.Drawing.Point(10, 86);
            fullResolutionCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            fullResolutionCheck.Name = "fullResolutionCheck";
            fullResolutionCheck.Size = new System.Drawing.Size(124, 24);
            fullResolutionCheck.TabIndex = 2;
            fullResolutionCheck.Text = "Full resolution";
            fullResolutionCheck.UseVisualStyleBackColor = true;
            fullResolutionCheck.CheckedChanged += fullResolutionCheck_CheckedChanged;
            // 
            // keepSubsCheck
            // 
            keepSubsCheck.AutoSize = true;
            keepSubsCheck.Location = new System.Drawing.Point(10, 58);
            keepSubsCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            keepSubsCheck.Name = "keepSubsCheck";
            keepSubsCheck.Size = new System.Drawing.Size(98, 24);
            keepSubsCheck.TabIndex = 1;
            keepSubsCheck.Text = "Keep subs";
            keepSubsCheck.UseVisualStyleBackColor = true;
            keepSubsCheck.CheckedChanged += keepSubsCheck_CheckedChanged;
            // 
            // keepAudioCheck
            // 
            keepAudioCheck.AutoSize = true;
            keepAudioCheck.Location = new System.Drawing.Point(10, 29);
            keepAudioCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            keepAudioCheck.Name = "keepAudioCheck";
            keepAudioCheck.Size = new System.Drawing.Size(107, 24);
            keepAudioCheck.TabIndex = 0;
            keepAudioCheck.Text = "Keep audio";
            keepAudioCheck.UseVisualStyleBackColor = true;
            keepAudioCheck.CheckedChanged += keepAudioCheck_CheckedChanged;
            // 
            // BtnDnldFFmpeg
            // 
            BtnDnldFFmpeg.Location = new System.Drawing.Point(25, 484);
            BtnDnldFFmpeg.Margin = new System.Windows.Forms.Padding(2);
            BtnDnldFFmpeg.Name = "BtnDnldFFmpeg";
            BtnDnldFFmpeg.Size = new System.Drawing.Size(178, 32);
            BtnDnldFFmpeg.TabIndex = 4;
            BtnDnldFFmpeg.Text = "Dowload FFmpeg";
            BtnDnldFFmpeg.UseVisualStyleBackColor = true;
            BtnDnldFFmpeg.Click += button1_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(232, 527);
            Controls.Add(BtnDnldFFmpeg);
            Controls.Add(customGifGroupBox);
            Controls.Add(configHotkeysButton);
            Controls.Add(SubtitesSize);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CRFValue);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "Gifer";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            trayMenu.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CRFValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubtitesSize).EndInit();
            customGifGroupBox.ResumeLayout(false);
            customGifGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

