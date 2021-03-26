using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_about : Form
    {
        DPI dpi;
#if DEBUG
        const string BUILDVER = "debug";
#else
        const string BUILDVER = "release";
#endif
        public Form_about(DPI dpi)
        {
            InitializeComponent();

            this.dpi = dpi;
            Width  = (int)(Width * dpi.DpiX / 100);
            Height = (int)(Height * dpi.DpiY / 100);
        }

        private void Form_about_Load(object sender, EventArgs e)
        {
            label_info.Text = string.Format("版本 {0}-{1} | by {2}", Application.ProductVersion, BUILDVER, Application.CompanyName);

            pictureBox_icon.Top  = (ClientSize.Height - pictureBox_icon.Height) / 2 - 10;
            pictureBox_icon.Left = (ClientSize.Width - pictureBox_icon.Width - label_title.Width) / 2;
            label_title.Top      = (ClientSize.Height - label_title.Height - label_info.Height) / 2 - 10;
            label_title.Left     = pictureBox_icon.Left + pictureBox_icon.Width;
            label_info.Top       = label_title.Top + label_title.Height;
            label_info.Left      = label_title.Left + (label_title.Width - label_info.Width) / 2;

            linkLabel_updatelog.Top = linkLabel_viewSource.Top = ClientSize.Height - linkLabel_updatelog.Height - 10;

            linkLabel_viewSource.Left = ClientSize.Width - linkLabel_viewSource.Width - 10;
            linkLabel_updatelog.Left = linkLabel_viewSource.Left - linkLabel_updatelog.Width - 6;
        }

        private void LinkLabel_updatelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form_log(Properties.Resources.updatelog, "更新日志", dpi).ShowDialog();
        }

        private void LinkLabel_viewSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(MyString.URL_VIEWSOURCE);
        }
    }

    #region 更新日志窗口

    class Form_log : Form
    {
        private TextBox tb = new TextBox()
        {
            Visible     = true,
            Multiline   = true,
            ReadOnly    = true,
            WordWrap    = true,
            BackColor   = Color.White,
            ScrollBars  = ScrollBars.Vertical,
            BorderStyle = BorderStyle.None,
            Font        = new Font(new FontFamily("黑体"), 10, FontStyle.Regular),
        };
        public Form_log(string message, string title, DPI dpi)
        {
            Width    = 450;
            Height   = 500;
            ShowIcon = false;
            TopMost  = true;
            Text     = title;

            Width  = (int)(Width * dpi.DpiX / 100);
            Height = (int)(Height * dpi.DpiY / 100);

            MaximizeBox   = false;
            MinimizeBox   = false;
            StartPosition = FormStartPosition.CenterParent;

            foreach (var tmp in message.Split('\n'))
            {
                tb.Text += string.Format(" {0}\n", tmp);
            }

            tb.Width  = ClientSize.Width;
            tb.Height = ClientSize.Height;
            tb.Select(0, 0);
            tb.ScrollToCaret();

            Controls.Add(tb);
            SizeChanged += (object sender, EventArgs e) =>
            {
                tb.Width  = ClientSize.Width;
                tb.Height = ClientSize.Height;
            };
        }
    }

    #endregion

}
