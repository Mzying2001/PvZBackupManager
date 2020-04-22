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
        Thread update;
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

        private void Form_about_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (update != null)
            {
                update.Abort();
            }
        }

        private void LinkLabel_updatelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form_log(Properties.Resources.updatelog, "更新日志").ShowDialog();
        }

        private void LinkLabel_viewSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(MyString.URL_VIEWSOURCE);
        }

        private void LinkLabel_update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_update.Visible = false;
            linkLabel_updatelog.Visible = false;
            linkLabel_viewSource.Enabled = false;
            linkLabel_viewSource.Text = "正在检查更新...";

            update = new Thread(new ThreadStart(GetUpDateMessage));
            update.Start();
        }

        #region 检查更新

        private delegate void GetUpdateDelegate(string message);
        private void GetUpdate(string message)
        {
            try
            {
                string url = message.Substring(message.IndexOf('#') + 1);

                Version ver_new = new Version(message.Substring(0, message.IndexOf('#')));
                Version ver_now = new Version(Application.ProductVersion);

                if (ver_now < ver_new)
                {
                    string text = string.Format("检测到新版本（v{0}），是否前往下载？", ver_new);
                    if (MessageBox.Show(text, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(url);
                    }
                }
                else
                {
                    MessageBox.Show("当前已经是最新版本。", "信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                linkLabel_update.Visible = true;
                linkLabel_updatelog.Visible = true;
                linkLabel_viewSource.Enabled = true;
                linkLabel_viewSource.Text = "查看源码";
            }
        }

        private void GetUpDateMessage()
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string message = new WebClient().DownloadString(MyString.URL_UPDATE);

                GetUpdateDelegate threadEnd = new GetUpdateDelegate(GetUpdate);
                Invoke(threadEnd, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        #endregion

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
