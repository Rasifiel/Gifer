using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gifer {

  public enum VideoPlayer {
    MPC, VLC
  }

  public static class Configuration {
    public static VideoPlayer CurrentPlayer {
      get {
        return (VideoPlayer)Properties.Settings.Default.ActivePlayer;
      }
      set { Properties.Settings.Default.ActivePlayer = (int)value; Properties.Settings.Default.Save(); }
    }

    public static String VLCPassword {
      get { return Properties.Settings.Default.VLCPassword; }
      set { Properties.Settings.Default.VLCPassword = value; Properties.Settings.Default.Save(); }
    }

    public static int CRF {
      get {
        return Properties.Settings.Default.CRF;
      }
      set { Properties.Settings.Default.CRF = value; Properties.Settings.Default.Save(); }
    }

    public static int SubtitlesSize {
      get {
        return Properties.Settings.Default.SubtitlesSize;
      }
      set { Properties.Settings.Default.SubtitlesSize = value; Properties.Settings.Default.Save(); }
    }

    public static decimal SubtitlesScale {
      get {
        return Properties.Settings.Default.SubtitlesScale;
      }
      set { Properties.Settings.Default.SubtitlesScale = value; Properties.Settings.Default.Save(); }
    }

    public static Dictionary<GiferActionId, Keys> KeyConfig {
      get {
        var defaultConfig = DefaultGiferActions.BuildDefaultActions();
        Dictionary<GiferActionId, Keys> config;
        if (Properties.Settings.Default.KeyConfig.Length == 0) {
          config = new Dictionary<GiferActionId, Keys>();
        } else {
          config = JsonConvert.DeserializeObject<Dictionary<GiferActionId, Keys>>(Properties.Settings.Default.KeyConfig);
        }
        foreach (var row in defaultConfig) {
          if (!config.ContainsKey(row.Key)) {
            config.Add(row.Key, row.Value.Key);
          }
        }
        return config;
      }
      set {
        Properties.Settings.Default.KeyConfig = JsonConvert.SerializeObject(value);
        Properties.Settings.Default.Save();
      }
    }

    public static bool CustomKeepAudio {
      get {
        return Properties.Settings.Default.CustomKeepAudio;
      }
      set { Properties.Settings.Default.CustomKeepAudio = value; Properties.Settings.Default.Save(); }
    }

    public static bool CustomKeepSubs {
      get {
        return Properties.Settings.Default.CustomKeepSubs;
      }
      set { Properties.Settings.Default.CustomKeepSubs = value; Properties.Settings.Default.Save(); }
    }

    public static bool CustomFullResolution {
      get {
        return Properties.Settings.Default.CustomFullResolution;
      }
      set { Properties.Settings.Default.CustomFullResolution = value; Properties.Settings.Default.Save(); }
    }
  }
}
