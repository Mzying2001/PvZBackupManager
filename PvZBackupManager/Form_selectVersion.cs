using System;
using System.IO;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_selectVersion : Form
    {

        private int dialog_result = PVZVersion.NONE;

        private readonly IniFile conf = new IniFile(MyString.Path_conf);

        public Form_selectVersion()
        {
            InitializeComponent();
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
            dialog_result = PVZVersion.ORIGINAL;
            Close();
        }

        private void Button_steam_Click(object sender, EventArgs e)
        {
            dialog_result = PVZVersion.STEAM;
            Close();
        }

        private void Button_zoo_jp_Click(object sender, EventArgs e)
        {
            dialog_result = PVZVersion.ZOO_JP;
            Close();
        }

        private void Form_selectVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dialog_result != PVZVersion.NONE)
            {
                if (checkBox_remember.Checked)
                {
                    conf.WriteValue("var", "gamever", dialog_result);
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
            return dialog_result;
        }
    }
}
