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
  public partial class ImageCropDialog : Form {
    public ImageCropDialog() {
      InitializeComponent();
    }

    private void ImageCropDialog_KeyUp(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Space:
        case Keys.Enter: {
            DialogResult = DialogResult.OK;
            Close();
          }
          break;
        case Keys.Escape: {
            DialogResult = DialogResult.Cancel;
            Close();
          }
          break;
      }
    }
  }
}
