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
        Label label = new Label() { Text = row.Item2, AutoSize = true };
        labels_.Add(label);
        editorPanel.Controls.Add(label, 0, editorPanel.RowCount - 1);
        HotkeyEditor hotkeyEditor = new HotkeyEditor() { Width = 250, Height = 30, Visible = true };
        editors_.Add(hotkeyEditor);
        editorPanel.Controls.Add(hotkeyEditor, 1, editorPanel.RowCount - 1);
        hotkeyEditor.CreateControl();
        hotkeyEditor.HotKey = row.Item3;
        editorPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
      }
    }

    public Dictionary<GiferActionId, Keys> GetKeyMap() {
      Dictionary<GiferActionId, Keys> result = new Dictionary<GiferActionId, Keys>();
      for (int i = 0; i< config_.Count;i++) {
        result[(GiferActionId)config_[i].Item1] =  editors_[i].HotKey;
      }
      return result;
    }

    List<ValueTuple<int, String, Keys>> config_;
    List<HotkeyEditor> editors_ = new List<HotkeyEditor>();
    List<Label> labels_ = new List<Label>();
    public Dictionary<GiferActionId, Keys> result_;

    private void saveButton_Click(object sender, EventArgs e) {
      result_ = GetKeyMap();
    }
  }
}
