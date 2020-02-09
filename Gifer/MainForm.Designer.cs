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
      this.trayMenu.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CRFValue)).BeginInit();
      this.SuspendLayout();
      // 
      // trayIcon
      // 
      this.trayIcon.ContextMenuStrip = this.trayMenu;
      this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
      this.trayIcon.Text = "Gifer";
      this.trayIcon.Visible = true;
      this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
      // 
      // trayMenu
      // 
      this.trayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size(107, 28);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
      this.quitToolStripMenuItem.Text = "Quit";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.VLCRadioButton);
      this.groupBox1.Controls.Add(this.MPCRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(140, 72);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Video player";
      // 
      // VLCRadioButton
      // 
      this.VLCRadioButton.AutoSize = true;
      this.VLCRadioButton.Location = new System.Drawing.Point(6, 45);
      this.VLCRadioButton.Name = "VLCRadioButton";
      this.VLCRadioButton.Size = new System.Drawing.Size(55, 21);
      this.VLCRadioButton.TabIndex = 1;
      this.VLCRadioButton.TabStop = true;
      this.VLCRadioButton.Text = "VLC";
      this.VLCRadioButton.UseVisualStyleBackColor = true;
      this.VLCRadioButton.CheckedChanged += new System.EventHandler(this.VLCRadioButton_CheckedChanged);
      // 
      // MPCRadioButton
      // 
      this.MPCRadioButton.AutoSize = true;
      this.MPCRadioButton.Location = new System.Drawing.Point(6, 18);
      this.MPCRadioButton.Name = "MPCRadioButton";
      this.MPCRadioButton.Size = new System.Drawing.Size(58, 21);
      this.MPCRadioButton.TabIndex = 0;
      this.MPCRadioButton.TabStop = true;
      this.MPCRadioButton.Text = "MPC";
      this.MPCRadioButton.UseVisualStyleBackColor = true;
      this.MPCRadioButton.CheckedChanged += new System.EventHandler(this.MPCRadioButton_CheckedChanged);
      // 
      // CRFValue
      // 
      this.CRFValue.Location = new System.Drawing.Point(17, 114);
      this.CRFValue.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
      this.CRFValue.Name = "CRFValue";
      this.CRFValue.Size = new System.Drawing.Size(134, 22);
      this.CRFValue.TabIndex = 2;
      this.crfToolTip.SetToolTip(this.CRFValue, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      this.CRFValue.ValueChanged += new System.EventHandler(this.CRFValue_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 88);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(123, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "CRF (quality 0-51)";
      this.crfToolTip.SetToolTip(this.label1, "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default");
      // 
      // crfToolTip
      // 
      this.crfToolTip.ToolTipTitle = "Constant Rate Factor: 0 - lossless 51 - lowest quality 28 - default";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(159, 143);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CRFValue);
      this.Controls.Add(this.groupBox1);
      this.Name = "MainForm";
      this.Text = "Gifer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.trayMenu.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CRFValue)).EndInit();
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
  }
}

