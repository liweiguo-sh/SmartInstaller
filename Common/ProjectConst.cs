using SmartInstaller.Util;

using System.IO;
using System.Windows.Forms;

namespace SmartInstaller.Common {
    public static class ProjectConst {
        #region -- module variable definition --
        private const string InstallSourceDebug = @"C:\Users\volant\Desktop\InstallSource";      // -- 安装源调试目录 --

        public static bool IsVsIdeEnv = false;          // -- 当前是否是在VS IDE开发环境 --        
        public static string SourcePath;                // -- 安装包根目录 --

        public static string APP_FOLDER;                // -- 默认安装文件夹名称 --
        public static string APP_EXE;                   // -- 目标程序名称 --
        public static string APP_SHORTCUT;              // -- 目标程序快捷方式名称(创建到桌面) --
        public static string APP_SHORTCUT_DESC;         // -- 目标程序快捷方式描述 --
        #endregion
        #region -- init --
        public static void ReadConfigIni() {
            if (IsVsIdeEnv && Directory.Exists(InstallSourceDebug)) {
                SourcePath = InstallSourceDebug;
            }
            else {
                SourcePath = Application.StartupPath;
            }

            IniFile iniFile = new IniFile(UtilFile.Combine(SourcePath, "config.ini"), 0);
            APP_FOLDER = iniFile.getValue("app_folder", "config.ini.app_folder error");
            APP_EXE = iniFile.getValue("app_exe", "config.ini.app_exe error");
            APP_SHORTCUT = iniFile.getValue("app_shortcut", "config.ini.app_shortcut error");
            APP_SHORTCUT_DESC = iniFile.getValue("app_shortcut_desc", "config.ini.app_shortcut_desc error");
        }
        #endregion
    }
}