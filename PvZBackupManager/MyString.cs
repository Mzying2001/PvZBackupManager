using System;
using System.Linq;

namespace PvZBackupManager
{
    static class MyString
    {
        public static string Path_AppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string Path_BKdata  = Path_AppData + @"\PvZBackupManager";
        public static string Path_backups = Path_BKdata  + @"\backups";
        public const string PATH_PVZUSERDATA_ORIGINAL = @"C:\ProgramData\PopCap Games\PlantsVsZombies\userdata";
        public const string PATH_PVZUSERDATA_STEAM    = @"C:\ProgramData\Steam\PlantsVsZombies\userdata";
        public const string PATH_PVZUSERDATA_ZOO_JP   = @"C:\ProgramData\Zoo\Plants vs Zombies\userdata";

        public enum IsLegalBackupName_RESULT
        {
            LEGAL,
            ILLEGAL_CHAR,
            ILLEGAL_EMPTY,
            ILLEGAL_LENGHT,
        }
        public static IsLegalBackupName_RESULT IsLegalBackupName(string str)
        {
            string tmp = str.Trim();

            if (tmp.Length == 0)
            {
                return IsLegalBackupName_RESULT.ILLEGAL_EMPTY;
            }
            else if (tmp.Length > 100)
            {
                return IsLegalBackupName_RESULT.ILLEGAL_LENGHT;
            }
            else
            {
                char[] illegalchars = { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };
                foreach (char c in illegalchars)
                {
                    if (str.Contains(c))
                    {
                        return IsLegalBackupName_RESULT.ILLEGAL_CHAR;
                    }
                }
                return IsLegalBackupName_RESULT.LEGAL;
            }
        }

    }
}
