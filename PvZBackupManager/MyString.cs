using System;
using System.Linq;

namespace PvZBackupManager
{
    enum CheckName_Result
    {
        LEGAL,
        ILLEGAL_CHAR,
        ILLEGAL_EMPTY,
        ILLEGAL_LENGHT,
    }

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

        public static CheckName_Result CheckBackupName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return CheckName_Result.ILLEGAL_EMPTY;
            }
            else
            {
                string tmp = name.Trim();

                if (tmp.Length > 100)
                {
                    return CheckName_Result.ILLEGAL_LENGHT;
                }
                else
                {
                    char[] illegalchars = { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };
                    foreach (char c in illegalchars)
                    {
                        if (name.Contains(c))
                        {
                            return CheckName_Result.ILLEGAL_CHAR;
                        }
                    }
                    return CheckName_Result.LEGAL;
                }
            }
        }

    }
}
