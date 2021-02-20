using System;
using System.IO;
using System.Text;
using static PvZBackupManager.DllImports;

namespace PvZBackupManager
{
    class IniFile
    {
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

        /// <summary>
        /// 向配置文件写入值
        /// </summary>
        public static void ProfileWriteValue(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// 读取配置文件的值
        /// </summary>
        public static string ProfileReadValue(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, 255, path);
            return sb.ToString().Trim();
        }

        public string this[string section, string key]
        {
            get => ProfileReadValue(section, key, Path);
            set => ProfileWriteValue(section, key, value, Path);
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
