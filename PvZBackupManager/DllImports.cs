using System.Runtime.InteropServices;
using System.Text;

namespace PvZBackupManager
{
    public static class DllImports
    {

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    }
}
