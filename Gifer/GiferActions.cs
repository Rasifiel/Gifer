using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gifer {
  public enum GiferActionId : int {
    MarkStart = 1,
    MarkEnd = 2,
    CreateDefault = 3,
    CreatePadded = 4,
    CreateCropped = 5,
    CreateWithSubs = 6,
  }

  public class GiferAction {

    String description;
    Keys key;

    public GiferAction(string description, Keys defaultKey) {
      this.Description = description;
      this.Key = defaultKey;
    }

    public string Description { get => description; set => description = value; }
    public Keys Key { get => key; set => key = value; }
  }

  public static class DefaultGiferActions {
    public static Dictionary<GiferActionId, GiferAction> BuildDefaultActions() {
      Dictionary<GiferActionId, GiferAction> result = new Dictionary<GiferActionId, GiferAction>() {
        { GiferActionId.MarkStart, new GiferAction( "Mark start", Keys.Control | Keys.Alt | Keys.Shift | Keys.A ) },
        { GiferActionId.MarkEnd, new GiferAction( "Mark end", Keys.Control | Keys.Alt | Keys.Shift | Keys.S ) },
        { GiferActionId.CreateDefault, new GiferAction("Create default gif", Keys.Control | Keys.Alt | Keys.Shift | Keys.Z ) },
        { GiferActionId.CreatePadded, new GiferAction( "Create gif with padding", Keys.Control | Keys.Alt | Keys.Shift | Keys.X ) },
        { GiferActionId.CreateCropped, new GiferAction( "Create cropped gif", Keys.Control | Keys.Alt | Keys.Shift | Keys.C ) },
        { GiferActionId.CreateWithSubs, new GiferAction( "Create gif with subs", Keys.Control | Keys.Alt | Keys.Shift | Keys.V ) },
      };
      return result;
    }
  }
}
