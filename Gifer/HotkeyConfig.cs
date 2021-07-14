using Gifer.HotkeyComponent;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gifer {
  public partial class HotkeyConfig : Form {
    public HotkeyConfig(List<ValueTuple<int, String, Keys>> config) {
      InitializeComponent();
      config_ = config;
      editorPanel.Controls.Clear();
      editors_.Clear();
      labels_.Clear();
      editorPanel.RowCount = 0;
      editorPanel.RowStyles.Clear();
      foreach (var row in config) {
        editorPanel.RowCount++;
        Label label = new Label() { Text = row.Item2 };
        labels_.Add(label);
        editorPanel.Controls.Add(label, 0, editorPanel.RowCount - 1);
        HotkeyEditor hotkeyEditor = new HotkeyEditor() { HotKey = row.Item3, Width = 200, Height = 20 };
        editors_.Add(hotkeyEditor);
        editorPanel.Controls.Add(hotkeyEditor, 1, editorPanel.RowCount - 1);
        editorPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
      }
    }

    List<ValueTuple<int, String, Keys>> config_;
    List<HotkeyEditor> editors_ = new List<HotkeyEditor>();
    List<Label> labels_ = new List<Label>();
  }
}
