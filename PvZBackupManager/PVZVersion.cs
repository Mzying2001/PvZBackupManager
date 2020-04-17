using System.IO;

namespace PvZBackupManager
{
    static class PVZVersion
    {
        public const int NONE     = 1;
        public const int ORIGINAL = 2;
        public const int STEAM    = 3;
        public const int ZOO_JP   = 4;
        public const int XPMODE   = 5;
        public const int VAR      = 6;
        public static int Check()
        {
            bool original, steam, zoo_jp;
            original = Directory.Exists(MyString.PATH_PVZUSERDATA_ORIGINAL);
            steam    = Directory.Exists(MyString.PATH_PVZUSERDATA_STEAM);
            zoo_jp   = Directory.Exists(MyString.PATH_PVZUSERDATA_ZOO_JP);

            if ((original && steam) || (original && zoo_jp) || (steam && zoo_jp))
                return VAR;
            else if (original)
                return ORIGINAL;
            else if (steam)
                return STEAM;
            else if (zoo_jp)
                return ZOO_JP;
            else
                return NONE;
        }
    }
}
