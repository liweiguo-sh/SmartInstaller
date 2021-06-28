using SmartInstaller.Common;
using SmartInstaller.Util;

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
[assembly: ImportedFromTypeLib("IWshRuntimeLibrary")]

namespace SmartInstaller {
    public partial class FormInstallConfig : Form {

        #region -- module variable definition --
        private const string InstallTargetDebug = @"C:\Users\volant\Desktop\InstallTarget";      // -- 安装目标调试目录 --
        #endregion
        #region -- FormLoad --
        public FormInstallConfig() {
            InitializeComponent();
        }
        private void FormInstallConfig_Load(object sender, EventArgs e) {
            InitInstallConfig();

            lblWelcome.Text = ProjectConst.INSTALL_WELCOME;
            txtSource.Text = ProjectConst.SourcePath;
        }
        #endregion
        #region -- Form controls event --
        private void BtnSelectTargetPath_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog {
                SelectedPath = TargetPath
            };
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                TargetPath = fbd.SelectedPath;
            }
        }

        private void BtnInstall_Click(object sender, EventArgs e) {
            try {
                Install();
            } catch (Exception ex) {
                UtilMessage.ShowError(ex);
            }
        }
        #endregion

        #region -- init -- 
        private void InitInstallConfig() {
            string targetPath;
            if (ProjectConst.IsVsIdeEnv && Directory.Exists(InstallTargetDebug)) {
                targetPath = InstallTargetDebug;
            }
            else {
                targetPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).ToString();
            }

            TargetPath = UtilFile.Combine(targetPath, ProjectConst.APP_FOLDER) + "\\";
        }

        private string TargetPath {
            get {
                return txtTarget.Text.Trim();
            }
            set {
                txtTarget.Text = value;
            }
        }
        #endregion
        #region -- install --
        private bool CheckBeforeInstall() {
            if (Directory.Exists(TargetPath)) {
                DirectoryInfo info = new DirectoryInfo(TargetPath);
                if (info.GetFiles().Length > 0) {
                    if (UtilMessage.ShowConfirm("安装目标目录不为空，确定要覆盖安装吗？") != DialogResult.Yes) {
                        return false;
                    }
                }
            }
            else {
                if (!UtilFile.CheckDirectory(TargetPath, true)) {
                    UtilMessage.ShowWarning("创建安装目标目录失败，可能是当前用户权限不足，请检查。");
                    return false;
                }
            }

            return true;
        }
        private void Install() {
            if (!CheckBeforeInstall()) return;

            string package, extTarget, desktopPath, startupPath;

            // -- 1. 拷贝目录 --
            package = UtilFile.Combine(ProjectConst.SourcePath, "package");
            UtilFile.CopyDiretory(package, TargetPath);

            // -- 2. 创建快捷方式到桌面和启动组 --
            extTarget = UtilFile.Combine(TargetPath, ProjectConst.APP_EXE);

            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            CreateShortcut(TargetPath, extTarget, ProjectConst.APP_SHORTCUT, ProjectConst.APP_SHORTCUT_DESC, desktopPath);

            if (ProjectConst.FLAG_SHORTCUT_ON_STARTUP) {
                startupPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                CreateShortcut(TargetPath, extTarget, ProjectConst.APP_SHORTCUT, ProjectConst.APP_SHORTCUT_DESC, startupPath);
            }

            // -- 4. 立即运行 --
            if (UtilMessage.ShowConfirm(ProjectConst.APP_SHORTCUT_DESC + " 安装成功，是否立即运行？") == DialogResult.Yes) {
                Environment.CurrentDirectory = TargetPath;      // -- 确保exeTarget运行时，当前目录是exeTarget所在目录，否则是SmartInstaller.exe所在目录 --
                Process.Start(extTarget);
            }
            else {
                UtilMessage.ShowMessage(ProjectConst.APP_SHORTCUT_DESC + " 安装成功，已创建桌面快捷方式。");
            }

            // -- 9. end --
            this.Close();
        }

        public static void CreateShortcut(string pathTarget, string extTarget, string shortcutName, string shortcutDesc, string shortcutPath) {
            shortcutPath = Path.Combine(shortcutPath, string.Format("{0}.lnk", shortcutName));
            // --------------------------------------------
            if (File.Exists(shortcutPath)) {
                File.Delete(shortcutPath);
            }

            // -------------------------------------------- 
            var shell = new IWshRuntimeLibrary.WshShell();
            var shortcut = (IWshRuntimeLibrary.WshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = extTarget;
            shortcut.Arguments = string.Empty;
            shortcut.Description = shortcutDesc;
            shortcut.WorkingDirectory = pathTarget;
            shortcut.IconLocation = extTarget;
            shortcut.WindowStyle = 1;
            shortcut.Save();
        }
        #endregion
    }
}