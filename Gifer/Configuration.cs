using System;

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
  }
}
