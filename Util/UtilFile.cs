using System;
using System.Collections;
using System.IO;
using System.Text;

namespace SmartInstaller.Util {
    public static class UtilFile {
        // -- 目录、文件路径、名称、扩展名等 ----------------------------------------
        public static bool CheckDirectory(string directoryName, bool autoCreate) {
            if (!Directory.Exists(directoryName)) {
                if (autoCreate) {
                    Directory.CreateDirectory(directoryName);
                }
            }

            if (Directory.Exists(directoryName)) {
                return true;
            }
            else {
                return false;
            }
        }

        public static string GetPath(string filename) {
            int nIdx = filename.LastIndexOf("\\");
            return filename.Substring(0, nIdx);
        }
        public static string GetPreName(string fileName) {
            string extName = GetExtName(fileName);
            string[] arr = fileName.Split('\\');
            string preName = arr[arr.Length - 1];
            if (!UtilString.Equals(extName, "")) {
                preName = preName.Substring(0, preName.Length - extName.Length);
            }
            return preName;
        }
        public static string GetExtName(string fileName) {
            int nIdx = fileName.LastIndexOf(".");
            if (nIdx > 0) {
                return fileName.Substring(nIdx);
            }
            return "";
        }
        public static string Combine(string path, string filename) {
            if (path.EndsWith("\\")) {
                return path + filename;
            }
            else {
                return path + "\\" + filename;
            }
        }

        // -- read file -------------------------------------------------------
        public static string ReadFile(string filenFullname, string encodingName = "UTF-8") {
            string strLine;

            StreamReader reader = null;
            StringBuilder builder = new StringBuilder();
            // --------------------------------------------
            try {
                reader = new StreamReader(filenFullname, Encoding.GetEncoding(encodingName), true);
                while (reader.Peek() >= 0) {
                    strLine = reader.ReadLine().Trim();
                    builder.Append(strLine);
                }
                return builder.ToString();
            } catch (Exception e) {
                throw e;
            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }
        }
        public static ArrayList FileToArray(string txtFile) {
            string strLine;

            StreamReader reader = null;
            ArrayList list = new ArrayList();
            // --------------------------------------------
            try {
                reader = new StreamReader(txtFile, Encoding.GetEncoding("gb2312"), true);
                while (reader.Peek() >= 0) {
                    strLine = reader.ReadLine().Trim();
                    list.Add(strLine);
                }
                return list;
            } catch (Exception e) {
                throw e;
            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }
        }

        // -- create and write file -------------------------------------------
        public static bool WriteFile(string fileFullname, string fileContent, string encodingName = "UTF-8") {
            StreamWriter writer = null;
            // --------------------------------------------
            try {
                writer = new StreamWriter(fileFullname, false, Encoding.GetEncoding(encodingName));
                writer.WriteLine(fileContent);
            } catch (Exception e) {
                throw e;
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
            return true;
        }

        // -- delete file(files) ----------------------------------------------
        public static void DeleteFiles(string path, string suffix, bool includeSubs) {
            string[] arrFiles;
            string[] exts;

            if (UtilString.Equals(suffix, "")) {
                suffix = "*.*";
            }
            exts = suffix.Split(new char[] { ',', ';' });

            if (Directory.Exists(path)) {
                for (int i = 0; i < exts.Length; i++) {
                    arrFiles = Directory.GetFiles(path, exts[i], SearchOption.AllDirectories);
                    foreach (string filename in arrFiles) {
                        if (File.Exists(filename)) {
                            File.Delete(filename);
                        }
                    }
                }
            }
        }

        // -- Diretory --------------------------------------------------------
        public static void CopyDiretory(string source, string destination) {
            DirectoryInfo info = new DirectoryInfo(source);
            foreach (FileSystemInfo files in info.GetFileSystemInfos()) {
                string FileName = files.Name;
                string BFileName = Path.Combine(destination, FileName);
                if (files is FileInfo) {
                    File.Copy(files.FullName, BFileName, true);
                }
                else {
                    Directory.CreateDirectory(BFileName);
                    CopyDiretory(files.FullName, BFileName);
                }
            }
        }
    }
}