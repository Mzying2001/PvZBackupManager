using System.IO;
using System.Text;

namespace PvZBackupManager
{
    class IniFile : DllImports
    {

        private string path;
        private string section;
        private string key;

        /// <summary>
        /// 向配置文件写入值：
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="path"></param>
        public static void ProfileWriteValue(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        /// <summary>
        /// 读取配置文件的值：
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ProfileReadValue(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, 255, path);
            return sb.ToString().Trim();
        }

        public IniFile(string path, string section, string key)
        {
            SetPath(path);
            SetSectionAndKey(section, key);
            if (!File.Exists(path))
            {
                File.WriteAllText(path, null);
            }
        }
        public void SetPath(string path)
        {
            this.path = path;
        }
        public void SetSectionAndKey(string section,string key)
        {
            this.section = section;
            this.key = key;
        }
        public string Read()
        {
            return ProfileReadValue(section, key, path);
        }
        public int ReadInt()
        {
            return int.Parse(ProfileReadValue(section, key, path));
        }
        public void Write(string value)
        {
            ProfileWriteValue(section, key, value, path);
        }
        public void WriteInt(int value)
        {
            ProfileWriteValue(section, key, value.ToString(), path);
        }

    }
}
