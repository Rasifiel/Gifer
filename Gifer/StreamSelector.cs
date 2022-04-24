using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xabe.FFmpeg;

namespace Gifer {
  public partial class StreamSelector : Form {

    List<RadioButton> audioRadioButtons = new List<RadioButton>();
    List<RadioButton> subsRadioButtons = new List<RadioButton>();

    public StreamSelector(IMediaInfo mediaInfo) {
      InitializeComponent();
      foreach (var astream in mediaInfo.AudioStreams) {
        RadioButton rb = new RadioButton();
        rb.Text = $"{astream.Language} {astream.Channels}ch";
        rb.Checked = astream.Default != 0;
        rb.Tag = astream;
        rb.AutoSize = true;
        audioLayout.Controls.Add(rb);
        audioRadioButtons.Add(rb);
      }
      foreach (var sstream in mediaInfo.SubtitleStreams) {
        RadioButton rb = new RadioButton();
        rb.Text = $"{sstream.Language} {sstream.Title}";
        rb.Checked = sstream.Default != 0;
        rb.Tag = sstream;
        rb.AutoSize = true;
        subtitlesLayout.Controls.Add(rb);
        subsRadioButtons.Add(rb); 
      }
    }

    public IAudioStream GetSelectedAudio() {
      foreach (var rb in audioRadioButtons) {
        if (rb.Checked) {
          return (IAudioStream)rb.Tag;
        }
      }
      return null;
    }

    public ISubtitleStream GetSelectedSub() {
      foreach (var rb in subsRadioButtons) {
        if (rb.Checked) {
          return (ISubtitleStream)rb.Tag;
        }
      }
      return null;
    }

  }
}
