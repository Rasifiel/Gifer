﻿using Newtonsoft.Json;
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

    public static Dictionary<GiferActionId, GiferAction> KeyConfig {
      get {
        var defaultConfig = DefaultGiferActions.BuildDefaultActions();
        if (Properties.Settings.Default.KeyConfig.Length == 0) {
          return defaultConfig;
        }
        Dictionary<GiferActionId, GiferAction> config = JsonConvert.DeserializeObject<Dictionary<GiferActionId, GiferAction>>(Properties.Settings.Default.KeyConfig);
        foreach (var row in defaultConfig) {
          if (!config.ContainsKey(row.Key)) {
            config.Add(row.Key, row.Value);
          }
        }
        return config;
      }
      set {
        Properties.Settings.Default.KeyConfig = JsonConvert.SerializeObject(value);
        Properties.Settings.Default.Save();
      }
    }
  }
}
