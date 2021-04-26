using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gifer {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      var app = new System.Windows.Application();

      System.Windows.Application.Current.Resources.MergedDictionaries.Add(
      System.Windows.Application.LoadComponent(
        new Uri("ToastNotifications.Messages;component/Themes/Default.xaml",
        UriKind.Relative)) as System.Windows.ResourceDictionary);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
