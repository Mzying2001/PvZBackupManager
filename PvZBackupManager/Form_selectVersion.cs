using System;
using System.IO;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_selectVersion : Form
    {

        public new int DialogResult = PVZVersion.NONE;

        private readonly IniFile conf = new IniFile(MyString.Path_conf);

        public Form_selectVersion(DPI dpi)
        {
            InitializeComponent();

            #region DPI调整组件大小

            float dx = dpi.DpiX / 100;
            float dy = dpi.DpiY / 100;

            int i = (int)((button_original.Left - label_info.Right) * dx);
            int j = (int)((button_steam.Top - button_original.Bottom) * dy);

            Width = (int)(Width * dx);
            Height = (int)(Height * dy);

            button_original.Width = (int)(button_original.Width * dx);
            button_original.Height = (int)(button_original.Height * dy);

            button_steam.Width = button_original.Width;
            button_steam.Height = button_original.Height;

            button_zoo_jp.Width = button_original.Width;
            button_zoo_jp.Height = button_original.Height;

            button_original.Left = ClientSize.Width - button_original.Width - (int)(12 * dx);
            button_steam.Left = button_original.Left;
            button_zoo_jp.Left = button_steam.Left;

            button_original.Top = (ClientSize.Height - button_original.Height * 3 - j * 2) / 2;
            button_steam.Top = button_original.Bottom + j;
            button_zoo_jp.Top = button_steam.Bottom + j;

            label_info.Left = (int)(12 * dx);
            label_info.Top = (int)(12 * dy);
            label_info.Width = button_original.Left - label_info.Left - i;

            checkBox_remember.Left = (int)(15 * dx);
            checkBox_remember.Top = ClientSize.Height - checkBox_remember.Height - (int)(12 * dy);
            label_info.Height = checkBox_remember.Top - label_info.Top - j;

            #endregion
        }

        private void Form_SelectVersion_Load(object sender, EventArgs e)
        {
            button_original.Enabled = Directory.Exists(MyString.PATH_PVZUSERDATA_ORIGINAL);
            button_steam.Enabled    = Directory.Exists(MyString.PATH_PVZUSERDATA_STEAM);
            button_zoo_jp.Enabled   = Directory.Exists(MyString.PATH_PVZUSERDATA_ZOO_JP);

            checkBox_remember.Checked = !string.IsNullOrEmpty(conf["var", "gamever"]);
        }

#if false
        //使关闭按钮变灰
        protected override CreateParams CreateParams
        {
            get
            {
                int CS_NOCLOSE = 0x200;
                CreateParams parameters = base.CreateParams;
                parameters.ClassStyle |= CS_NOCLOSE;
                return parameters;
            }
        }
#endif

        private void Button_original_Click(object sender, EventArgs e)
        {
            DialogResult = PVZVersion.ORIGINAL;
            Close();
        }

        private void Button_steam_Click(object sender, EventArgs e)
        {
            DialogResult = PVZVersion.STEAM;
            Close();
        }

        private void Button_zoo_jp_Click(object sender, EventArgs e)
        {
            DialogResult = PVZVersion.ZOO_JP;
            Close();
        }

        private void Form_selectVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != PVZVersion.NONE)
            {
                if (checkBox_remember.Checked)
                {
                    conf.WriteValue("var", "gamever", DialogResult);
                }
                else
                {
                    conf["var", "gamever"] = null;
                }
            }
        }

        public new int ShowDialog()
        {
            base.ShowDialog();
            return DialogResult;
        }
    }
}
