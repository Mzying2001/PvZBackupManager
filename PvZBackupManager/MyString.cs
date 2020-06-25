using System;
using System.Linq;

namespace PvZBackupManager
{
    static class MyString
    {
        public static string Path_AppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string Path_BKdata  = Path_AppData + @"\PvZBackupManager"; //存档管理器文档路径
        public static string Path_backups = Path_BKdata  + @"\backups";          //备份文件路径

        public static string Path_conf = Path_BKdata + @"\conf.bin"; //配置文件路径
        public static string Path_list = Path_BKdata + @"\list.bin"; //列表文件路径

        public const string PATH_PVZUSERDATA_ORIGINAL = @"C:\ProgramData\PopCap Games\PlantsVsZombies\userdata"; //原版存档路径
        public const string PATH_PVZUSERDATA_STEAM    = @"C:\ProgramData\Steam\PlantsVsZombies\userdata";        //steam版存档路径
        public const string PATH_PVZUSERDATA_ZOO_JP   = @"C:\ProgramData\Zoo\Plants vs Zombies\userdata";        //日文版存档路径

        public const string URL_VIEWSOURCE = "https://github.com/Mzying2001/PvZBackupManager";
        public const string URL_UPDATE     = "https://Mzying2001.github.io/ApplicationUpdates/PvZBackupManager.txt";

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
