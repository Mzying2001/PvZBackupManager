using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_about : Form
    {
#if DEBUG
        const string BUILDVER = "debug";
#else
        const string BUILDVER = "release";
#endif
        public Form_about()
        {
            InitializeComponent();
        }

        private void Form_about_Load(object sender, EventArgs e)
        {
            label_info.Text = string.Format("版本 {0}-{1} | by {2}", Application.ProductVersion, BUILDVER, Application.CompanyName);
            
            pictureBox_icon.Top  = (ClientSize.Height - pictureBox_icon.Height) / 2;
            pictureBox_icon.Left = (ClientSize.Width - pictureBox_icon.Width - label_title.Width) / 2;
            label_title.Top      = (ClientSize.Height - label_title.Height - label_info.Height) / 2;
            label_title.Left     = pictureBox_icon.Left + pictureBox_icon.Width;
            label_info.Top       = label_title.Top + label_title.Height;
            label_info.Left      = label_title.Left + (label_title.Width - label_info.Width) / 2;
        }

        private void LinkLabel_updatelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form_log(Properties.Resources.updatelog, "更新日志").ShowDialog();
        }

        private void LinkLabel_viewSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Mzying2001/PvZBackupManager");
        }

        private void LinkLabel_update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Mzying2001/PvZBackupManager/releases/latest");
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
            WordWrap    = false,
            BackColor   = Color.White,
            ScrollBars  = ScrollBars.Both,
            BorderStyle = BorderStyle.None,
            Font        = new Font(new FontFamily("黑体"), 10, FontStyle.Regular),
        };
        public Form_log(string message, string title)
        {
            Width    = 450;
            Height   = 500;
            ShowIcon = false;
            Text     = title;

            MaximizeBox   = false;
            MinimizeBox   = false;
            StartPosition = FormStartPosition.CenterParent;

            tb.Text   = message;
            tb.Width  = ClientSize.Width;
            tb.Height = ClientSize.Height;
            tb.Select(0, 0);
            tb.ScrollToCaret();

            Controls.Add(tb);
            SizeChanged += WindowSizeChange;
        }
        private void WindowSizeChange(object sender, EventArgs e)
        {
            tb.Width  = ClientSize.Width;
            tb.Height = ClientSize.Height;
        }
    }

    #endregion

}
