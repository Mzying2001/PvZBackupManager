using System.Runtime.InteropServices;
using System.Text;

namespace PvZBackupManager
{
    class IniFile
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string Path { get; set; }

        public bool Exists => System.IO.File.Exists(Path);

        public IniFile(string path)
        {
            Path = path;
        }

        public string this[string section,string key]
        {
            get
            {
                StringBuilder sb = new StringBuilder(255);

                GetPrivateProfileString(section, key, string.Empty, sb, 255, Path);

                return sb.ToString().Trim();
            }

            set => WritePrivateProfileString(section, key, value, Path);
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
