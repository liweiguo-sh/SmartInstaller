using System;

namespace SmartInstaller.Util {
    public static class UtilString {
        public static bool Equals(string str1, string str2) {
            if (str1 == null && str2 == null) {
                return true;
            }
            else if (str1 == null || str2 == null) {
                return false;
            }
            else {
                return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
            }
        }
        public static string KillNull(object objString) {
            if (objString == null || objString == DBNull.Value) {
                return "";
            }
            else {
                return ((string)objString).Trim();
            }
        }
    }
}