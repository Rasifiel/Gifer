namespace Gifer {
  partial class PaddingDialog {
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
      this.startDur = new System.Windows.Forms.TextBox();
      this.stopDur = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // startDur
      // 
      this.startDur.Location = new System.Drawing.Point(94, 12);
      this.startDur.Name = "startDur";
      this.startDur.Size = new System.Drawing.Size(53, 22);
      this.startDur.TabIndex = 0;
      this.startDur.Text = "0";
      // 
      // stopDur
      // 
      this.stopDur.Location = new System.Drawing.Point(94, 40);
      this.stopDur.Name = "stopDur";
      this.stopDur.Size = new System.Drawing.Size(53, 22);
      this.stopDur.TabIndex = 1;
      this.stopDur.Text = "0";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Start (ms)";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "End (ms)";
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Location = new System.Drawing.Point(11, 66);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(125, 28);
      this.button1.TabIndex = 4;
      this.button1.Text = "Go";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // PaddingDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(148, 100);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.stopDur);
      this.Controls.Add(this.startDur);
      this.Name = "PaddingDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "PaddingDialog";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    public System.Windows.Forms.TextBox startDur;
    public System.Windows.Forms.TextBox stopDur;
  }
}