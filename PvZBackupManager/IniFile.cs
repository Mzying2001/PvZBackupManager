using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static PvZBackupManager.DllImports;

namespace PvZBackupManager
{
    class IniFile
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// ini文件的路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 目标文件是否存在
        /// </summary>
        public bool IsFileExist => File.Exists(Path);

        /// <summary>
        /// IniFile构造器
        /// </summary>
        /// <param name="path">ini文件的路径</param>
        public IniFile(string path)
        {
            Path = path;
        }

        public string this[string section, string key]
        {
            get
            {
                StringBuilder sb = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", sb, 255, Path);
                return sb.ToString().Trim();
            }
            set => WritePrivateProfileString(section, key, value, Path);
        }

        public void WriteValue(string section, string key, object value)
        {
            this[section, key] = value.ToString();
        }

        public T GetObject<T>(string section, string key)
        {
            return (T)Convert.ChangeType(this[section, key], typeof(T));
        }

    }
}
