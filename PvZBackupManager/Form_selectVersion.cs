using System;
using System.IO;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_selectVersion : Form
    {

        public const DialogResult DIALOGRESULT_ORIGINAL = (DialogResult)PVZVersion.ORIGINAL;
        public const DialogResult DIALOGRESULT_STEAM    = (DialogResult)PVZVersion.STEAM;
        public const DialogResult DIALOGRESULT_ZOO_JP   = (DialogResult)PVZVersion.ZOO_JP;
        public const DialogResult DIALOGRESULT_NONE     = (DialogResult)PVZVersion.NONE;

        private DialogResult dr = DIALOGRESULT_NONE;

        public Form_selectVersion()
        {
            InitializeComponent();
        }

        private void Form_SelectVersion_Load(object sender, EventArgs e)
        {
            button_original.Enabled = Directory.Exists(MyString.PATH_PVZUSERDATA_ORIGINAL);
            button_steam.Enabled    = Directory.Exists(MyString.PATH_PVZUSERDATA_STEAM);
            button_zoo_jp.Enabled   = Directory.Exists(MyString.PATH_PVZUSERDATA_ZOO_JP);
        }

        private void Form_SelectVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = dr;
        }

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

        private void Button_original_Click(object sender, EventArgs e)
        {
            dr = DIALOGRESULT_ORIGINAL;
            Close();
        }

        private void Button_steam_Click(object sender, EventArgs e)
        {
            dr = DIALOGRESULT_STEAM;
            Close();
        }

        private void Button_zoo_jp_Click(object sender, EventArgs e)
        {
            dr = DIALOGRESULT_ZOO_JP;
            Close();
        }
    }
}
