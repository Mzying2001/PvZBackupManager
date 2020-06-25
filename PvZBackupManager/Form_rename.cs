using System;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_rename : Form
    {

        public const DialogResult DIALOGRESULT_NOTHINGCHANGED = (DialogResult)1;
        public const DialogResult DIALOGRESULT_CHANGED = (DialogResult)2;

        private bool changed = false;
        private readonly string OldName;

        public Form_rename(string name)
        {
            InitializeComponent();
            OldName = name;
            textBox_name.Text = name;
        }

        private void Form_rename_Load(object sender, EventArgs e)
        {
            button_ok.Top     = textBox_name.Top;
            button_ok.Height  = textBox_name.Height;
        }

        private void Form_rename_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
                DialogResult = DIALOGRESULT_CHANGED;
            else
                DialogResult = DIALOGRESULT_NOTHINGCHANGED;
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text.Trim();
            MyString.IsLegalBackupName_RESULT r = MyString.IsLegalBackupName(name);
            switch (r)
            {
                case MyString.IsLegalBackupName_RESULT.ILLEGAL_EMPTY:
                    MessageBox.Show("请输入备份名", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.ILLEGAL_LENGHT:
                    MessageBox.Show("备份名长度不能超过100个字符", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.ILLEGAL_CHAR:
                    MessageBox.Show("备份名不能包含下列任何字符:\r\n\\ / : * ? \" < > | ", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.LEGAL:
                    if (name.Equals(OldName))
                    {
                        Close();
                    }
                    else
                    {
                        changed = true;
                        new IniFile(MyString.Path_conf)["string", "tmp_name"] = textBox_name.Text.Trim();
                        Close();
                    }
                    break;
            }
        }

        private void TextBox_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Button_ok_Click(null, null);
        }

    }
}
