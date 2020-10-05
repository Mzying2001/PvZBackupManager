using System;
using System.Windows.Forms;

namespace PvZBackupManager
{
    public partial class Form_rename : Form
    {

        public new string DialogResult = null;

        private readonly string OldName;

        public Form_rename(string name, DPI dpi)
        {
            InitializeComponent();

            #region Dpi调整组建大小

            float dx = dpi.DpiX / 100;
            float dy = dpi.DpiY / 100;

            Width = (int)(Width * dx);
            Height = (int)(Height * dy);

            textBox_name.Width = (int)(textBox_name.Width * dx);
            button_ok.Width = (int)(button_ok.Width * dx);

            textBox_name.Top = (ClientSize.Height - textBox_name.Height) / 2;
            textBox_name.Left = (ClientSize.Width - textBox_name.Width - button_ok.Width - 6) / 2;
            button_ok.Left = textBox_name.Right + 6;

            #endregion

            OldName = name;
            textBox_name.Text = name;

            Text += " \"" + name + "\"";
        }

        private void Form_rename_Load(object sender, EventArgs e)
        {
            button_ok.Top     = textBox_name.Top;
            button_ok.Height  = textBox_name.Height;
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
                    MessageBox.Show("备份名不能包含下列任何字符:\n\\ / : * ? \" < > | ", "提示");
                    break;

                case MyString.IsLegalBackupName_RESULT.LEGAL:
                    if (name.Equals(OldName))
                    {
                        Close();
                    }
                    else
                    {
                        DialogResult = name;
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

        public new string ShowDialog()
        {
            base.ShowDialog();
            return DialogResult;
        }
    }
}
