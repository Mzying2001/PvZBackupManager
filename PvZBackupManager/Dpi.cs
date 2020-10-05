using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZBackupManager
{
    public struct DPI
    {
        public float DpiX;
        public float DpiY;
    }

    static class Dpi
    {
        public static DPI GetDpi(System.Windows.Forms.Form form)
        {
            float dx, dy;

            System.Drawing.Graphics g = form.CreateGraphics();
            try
            {
                dx = g.DpiX;
                dy = g.DpiY;

                while ((int)dx % 5 != 0) dx++;
                while ((int)dy % 5 != 0) dy++;
            }
            catch (Exception)
            {
                dx = 100;
                dy = 100;
            }
            finally
            {
                g.Dispose();
            }
            return new DPI() { DpiX = dx, DpiY = dy };
        }
    }
}
