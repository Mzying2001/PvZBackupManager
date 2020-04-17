using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PvZBackupManager.Config
{
    class IniFile:Ini
    {

        private string path;
        private string section;
        private string key;
        
        public IniFile(string path, string section, string key)
        {
            SetPath(path);
            SetSectionAndKey(section, key);
            if (!File.Exists(path)) File.WriteAllText(path, "");
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
