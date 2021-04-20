using System;
using System.Windows.Forms;

namespace SmartInstaller.Util {
    public static class UtilMessage {
        public static void ShowMessage(string strMessage) {
            MessageBox.Show(strMessage, "系统消息提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWarning(string strMessage) {
            MessageBox.Show(strMessage, "系统消息提示...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string strMessage) {
            MessageBox.Show(strMessage, "系统消息提示...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowError(Exception e) {
            MessageBox.Show(e.Message, "系统消息提示...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowConfirm(string strMessage) {
            return MessageBox.Show(strMessage, "系统消息提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}