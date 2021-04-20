using SmartInstaller.Common;

using System;
using System.Windows.Forms;

namespace SmartInstaller {
    static class Program {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 1 && args[0].Equals("vsIdeEnv")) {
                ProjectConst.IsVsIdeEnv = true;
            }
            ProjectConst.ReadConfigIni();

            Application.Run(new FormInstallConfig());
        }
    }
}