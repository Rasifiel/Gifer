using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;

namespace Gifer {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      var app = new System.Windows.Application();
      XmlConfigurator.Configure();
      Application.EnableVisualStyles();
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
