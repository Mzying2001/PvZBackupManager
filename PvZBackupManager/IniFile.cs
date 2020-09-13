using System.IO;
using System.Text;
using static PvZBackupManager.DllImports;

namespace PvZBackupManager
{
    class IniFile
    {

        public string Path;

        public bool Exists => File.Exists(Path);

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

        public string this[string section,string key]
        {
            get => ProfileReadValue(section, key, Path);
            set => ProfileWriteValue(section, key, value, Path);
        }

        public void WriteValue(string section, string key, object value)
        {
            this[section, key] = value.ToString();
        }

        public string GetString(string section, string key)
        {
            return this[section, key];
        }

        public int GetInteger(string section, string key)
        {
            try
            {
                return int.Parse(this[section, key]);
            }
            catch
            {
                return -1;
            }
        }

        public bool GetBoolean(string section, string key)
        {
            try
            {
                return bool.Parse(this[section, key]);
            }
            catch
            {
                return false;
            }
        }

    }
}
