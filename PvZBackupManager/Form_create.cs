using System;
using System.IO;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_create : Form
    {

        public new string DialogResult = null;

        public Form_create(int gamever)
        {
            InitializeComponent();

            string name;
            switch (gamever)
            {
                case PVZVersion.STEAM:  name = "Steam"; break;
                case PVZVersion.ZOO_JP: name = "日文版"; break;
                default:                name = "存档"; break;
            }
            for (int i = 1; true; i++)
            {
                string tmp = i.ToString();
                while (tmp.Length < 3) tmp = "0" + tmp;
                tmp = string.Format("{0} - {1}", name, tmp);
                if (!Directory.Exists(MyString.Path_backups + @"\" + tmp))
                {
                    name = tmp;
                    break;
                }
            }
            textBox_name.Text = name;
        }

        private void Form_create_Load(object sender, EventArgs e)
        {
            button_ok.Top    = textBox_name.Top;
            button_ok.Height = textBox_name.Height;
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text.Trim();
            switch (MyString.IsLegalBackupName(name))
            {
                case MyString.IsLegalBackupName_RESULT.ILLEGAL_EMPTY:
                    MessageBox.Show("请输入备份名", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.ILLEGAL_LENGHT:
                    MessageBox.Show("备份名长度不能超过100个字符", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.ILLEGAL_CHAR:
                    MessageBox.Show("备份名不能包含下列任何字符:\n\\ / : * ? \" < > | ", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.LEGAL:
                    DialogResult = name;
                    Close();
                    break;
            }
        }

        private void TextBox_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Button_ok_Click(null, null);
        }


        public new string ShowDialog()
        {
            base.ShowDialog();
            return DialogResult;
        }
    }
}
