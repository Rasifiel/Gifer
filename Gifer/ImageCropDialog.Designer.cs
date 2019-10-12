namespace Gifer {
  partial class ImageCropDialog {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCropDialog));
      this.imageCropBox = new Cyotek.Windows.Forms.ImageBox();
      this.SuspendLayout();
      // 
      // imageCropBox
      // 
      this.imageCropBox.AllowZoom = false;
      this.imageCropBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.imageCropBox.DropShadowSize = 0;
      this.imageCropBox.Location = new System.Drawing.Point(0, 0);
      this.imageCropBox.Margin = new System.Windows.Forms.Padding(0);
      this.imageCropBox.Name = "imageCropBox";
      this.imageCropBox.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.Rectangle;
      this.imageCropBox.Size = new System.Drawing.Size(1262, 673);
      this.imageCropBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
      this.imageCropBox.TabIndex = 0;
      this.imageCropBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageCropDialog_KeyUp);
      // 
      // ImageCropDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1262, 673);
      this.ControlBox = false;
      this.Controls.Add(this.imageCropBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ImageCropDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ImageCropDialog";
      this.TopMost = true;
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageCropDialog_KeyUp);
      this.ResumeLayout(false);

    }

    #endregion

    public Cyotek.Windows.Forms.ImageBox imageCropBox;
  }
}