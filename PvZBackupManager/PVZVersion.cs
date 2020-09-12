using System.IO;
using static PvZBackupManager.MyString;

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
            bool original = Exists(ORIGINAL);
            bool steam    = Exists(STEAM);
            bool zoo_jp   = Exists(ZOO_JP);

            if ((original && steam) || (original && zoo_jp) || (steam && zoo_jp))
            {
                return VAR;
            }
            else if (original)
            {
                return ORIGINAL;
            }
            else if (steam)
            {
                return STEAM;
            }
            else if (zoo_jp)
            {
                return ZOO_JP;
            }
            else
            {
                return NONE;
            }
        }

        public static bool Exists(int ver)
        {
            switch (ver)
            {
                case ORIGINAL: return Directory.Exists(PATH_PVZUSERDATA_ORIGINAL);

                case STEAM: return Directory.Exists(PATH_PVZUSERDATA_STEAM);

                case ZOO_JP: return Directory.Exists(PATH_PVZUSERDATA_ZOO_JP);

                default: return false;
            }
        }
    }
}
