
namespace Gifer {
  partial class HotkeyConfig {
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
      this.saveButton = new System.Windows.Forms.Button();
      this.editorPanel = new System.Windows.Forms.TableLayoutPanel();
      this.SuspendLayout();
      // 
      // saveButton
      // 
      this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.saveButton.Location = new System.Drawing.Point(424, 12);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(134, 32);
      this.saveButton.TabIndex = 0;
      this.saveButton.Text = "Save hotkeys";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // editorPanel
      // 
      this.editorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.editorPanel.AutoSize = true;
      this.editorPanel.ColumnCount = 2;
      this.editorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.editorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.editorPanel.Location = new System.Drawing.Point(6, 8);
      this.editorPanel.Name = "editorPanel";
      this.editorPanel.RowCount = 1;
      this.editorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.editorPanel.Size = new System.Drawing.Size(418, 46);
      this.editorPanel.TabIndex = 1;
      // 
      // HotkeyConfig
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(570, 56);
      this.Controls.Add(this.editorPanel);
      this.Controls.Add(this.saveButton);
      this.Name = "HotkeyConfig";
      this.Text = "Hotkey configuration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.TableLayoutPanel editorPanel;
  }
}