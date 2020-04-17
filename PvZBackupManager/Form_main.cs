﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PvZBackupManager.Config;

namespace PvZBackupManager
{
    public partial class Form_main : Form
    {
        
        private readonly string PATH_BKDATA  = MyString.Path_BKdata;    //存档管理器文档路径
        private readonly string PATH_BACKUPS = MyString.Path_backups;   //备份文件路径
        private const string PATH_PVZUSERDATA_ORIGINAL = MyString.PATH_PVZUSERDATA_ORIGINAL;    //原版存档路径
        private const string PATH_PVZUSERDATA_STEAM    = MyString.PATH_PVZUSERDATA_STEAM;       //steam版存档路径
        private const string PATH_PVZUSERDATA_ZOO_JP   = MyString.PATH_PVZUSERDATA_ZOO_JP;      //日文版存档路径

        private readonly IniFile     conf;
        private readonly StrListFile list;
        private readonly LinkLabel   button_debug;

        private int    gamever;
        private string path_userdata;

        public Form_main()
        {
            InitializeComponent();

            Icon = Properties.Resources.icon;
            //旧系统(xp)下针对旧版本(v1.0.7及以下)的操作
            if (Environment.OSVersion.Version.Major < 6)
            {
                //注：此部分代码用于迁移旧版本文档
                string path_old = @"C:\ProgramData\PvZBackupManager";
                if (Directory.Exists(path_old) && !Directory.Exists(PATH_BKDATA))
                    Dir.Move(path_old, PATH_BKDATA);
            }
            //检测存档管理器路径是否存在,不存在则创建该路径
            if (!Directory.Exists(PATH_BKDATA)) Directory.CreateDirectory(PATH_BKDATA);
            //检测存档路径是否存在,不存在则创建该路径
            if (!Directory.Exists(PATH_BACKUPS)) Directory.CreateDirectory(PATH_BACKUPS);
            conf = new IniFile(PATH_BKDATA + @"\string.bin", "string", "value");
            list = new StrListFile(PATH_BKDATA + @"\list.bin");
            SelectVersion();

            #region 此部分代码只在debug下执行
#if DEBUG
            button_debug = new LinkLabel();
            button_debug.Text = "debug";
            button_debug.AutoSize = true;
            button_debug.Click += Debug_Click;
            Controls.Add(button_debug);
            void Debug_Click(object sender, EventArgs e)
            {
                string output = "";
                output += 
                    MyString.Format("【文件夹路径】\r\n{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n\r\n",
                    MyString.Path_AppData,
                    MyString.Path_BKdata,
                    MyString.Path_backups,
                    MyString.PATH_PVZUSERDATA_ORIGINAL,
                    MyString.PATH_PVZUSERDATA_STEAM,
                    MyString.PATH_PVZUSERDATA_ZOO_JP
                    );
                output +=
                    MyString.Format("【当前】\r\nOS version (major): {0}\r\ngamever: {1}\r\npath_userdata: {2}",
                    Environment.OSVersion.Version.Major, gamever, path_userdata);
                MessageBox.Show(output, "DEBUG");
            }
#endif
            #endregion

        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if (Directory.Exists(PATH_BACKUPS + @"\" + list[i]))
                {
                    listBox_backups.Items.Insert(0, list[i]);
                }
                else
                {
                    list.Remove(list[i]);
                }
            }
            ListBox_backups_SelectedIndexChanged(null, null);
            Form_main_SizeChanged(null, null);
            Activate();
        }
        
        private void Form_main_SizeChanged(object sender, EventArgs e)
        {
            listBox_backups.Height = ClientSize.Height - listBox_backups.Top - label_info.Height - 6;
            listBox_backups.Width  = ClientSize.Width - listBox_backups.Left * 2;
            label_info.Top         = listBox_backups.Top + listBox_backups.Height + 2;
            linkLabel_options.Top  = label_info.Top;
            linkLabel_options.Left = listBox_backups.Left + listBox_backups.Width - linkLabel_options.Width;

            #region 调整debug按钮
#if DEBUG
            button_debug.Left = linkLabel_options.Left - button_debug.Width - 6;
            button_debug.Top  = linkLabel_options.Top;
#endif
            #endregion

        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }



        private void Button_create_Click(object sender, EventArgs e)
        {
            bool created;
            DialogResult dr = new Form_create(gamever).ShowDialog();
            if (dr == Form_create.DIALOGRESULT_NOTHINGCREATED)
            {
                created = false;
            }
            else if (list.Contains(conf.Read()))
            {
                created = false;
                ShowErrorMessage("无法创建,因为命名出现重复");
            }
            else
            {
                created = true;
            }
            if (created)
            {
                list.Add(conf.Read());
                Directory.CreateDirectory(PATH_BACKUPS + @"\" + conf.Read());
                Dir.Copy(path_userdata, PATH_BACKUPS + @"\" + conf.Read() + @"\userdata");

                listBox_backups.Items.Add(conf.Read());
                listBox_backups.SetSelected(listBox_backups.Items.Count - 1, true);
            }
        }

        private void Button_restore_Click(object sender, EventArgs e)
        {
            string text;
            text = "确定要恢复备份\"{0}\"吗?\r\n此操作会覆盖当前存档";
            text = MyString.Format(text, listBox_backups.SelectedItem.ToString());
            DialogResult d = MessageBox.Show(text, "提示", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                try
                {
                    Dir.Delete(path_userdata, true);
                    Dir.Copy(PATH_BACKUPS + @"\" + listBox_backups.SelectedItem.ToString() + @"\userdata", path_userdata);
                    MessageBox.Show(MyString.Format("已恢复到备份\"{0}\"", listBox_backups.SelectedItem.ToString()), "提示");
                }
                catch (Exception ex)
                {
                    string errormsg;
                    errormsg = "无法恢复备份，若多次出现此错误，请尝试关闭游戏后重试。\r\n错误信息：{0}";
                    errormsg = MyString.Format(errormsg, ex.Message);
                    ShowErrorMessage(errormsg);
                }
            }
        }

        private void ListBox_backups_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBottomText(MyString.Format("已备份存档{0}个", listBox_backups.Items.Count));
            if (listBox_backups.SelectedIndex >= 0) 
                 button_restore.Enabled = true;
            else button_restore.Enabled = false;
        }

        private void ListBox_backups_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBox_backups.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right && index >= 0)
            {
                listBox_backups.SetSelected(index, true);
                if (listBox_backups.Items.Count == 1)
                {
                    contextMenuStrip_listbox.Items["Up"].Enabled = false;
                    contextMenuStrip_listbox.Items["Down"].Enabled = false;
                    contextMenuStrip_listbox.Items["ToTop"].Enabled = false;
                    contextMenuStrip_listbox.Items["ToBottom"].Enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        contextMenuStrip_listbox.Items["Up"].Enabled = false;
                        contextMenuStrip_listbox.Items["Down"].Enabled = true;
                        contextMenuStrip_listbox.Items["ToTop"].Enabled = false;
                        contextMenuStrip_listbox.Items["ToBottom"].Enabled = true;
                    }
                    else if (index == listBox_backups.Items.Count - 1)
                    {
                        contextMenuStrip_listbox.Items["Up"].Enabled = true;
                        contextMenuStrip_listbox.Items["Down"].Enabled = false;
                        contextMenuStrip_listbox.Items["ToTop"].Enabled = true;
                        contextMenuStrip_listbox.Items["ToBottom"].Enabled = false;
                    }
                    else
                    {
                        contextMenuStrip_listbox.Items["Up"].Enabled = true;
                        contextMenuStrip_listbox.Items["Down"].Enabled = true;
                        contextMenuStrip_listbox.Items["ToTop"].Enabled = true;
                        contextMenuStrip_listbox.Items["ToBottom"].Enabled = true;
                    }
                }
                listBox_backups.SetSelected(index, true);
                contextMenuStrip_listbox.Show(MousePosition);
            }
        }

        private void ListBox_backups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_backups.IndexFromPoint(e.Location) >= 0)
            {
                Button_restore_Click(null, null);
            }
        }

        private void LinkLabel_options_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tmp = "正在管理【{0}】存档";
            switch (gamever)
            {
                case PVZVersion.ORIGINAL:
                    tmp = MyString.Format(tmp, "原版");
                    break;

                case PVZVersion.STEAM:
                    tmp = MyString.Format(tmp, "Steam版");
                    break;

                case PVZVersion.ZOO_JP:
                    tmp = MyString.Format(tmp, "Zoo日文版");
                    break;

                case PVZVersion.XPMODE:
                    tmp = MyString.Format("正在使用\"{0}\"", path_userdata);
                    contextMenuStrip_options.Items["currentgamever"].Enabled = false;
                    break;
            }
            contextMenuStrip_options.Items["currentgamever"].Text = tmp;
            contextMenuStrip_options.Show(MousePosition);
        }

        private void Up_Click(object sender, EventArgs e)
        {
            int index = listBox_backups.SelectedIndex;
            list.Up(listBox_backups.Items[index].ToString());
            ListBoxSwap(index, index - 1);
            listBox_backups.SetSelected(index - 1, true);
        }

        private void Down_Click(object sender, EventArgs e)
        {
            int index = listBox_backups.SelectedIndex;
            list.Down(listBox_backups.Items[index].ToString());
            ListBoxSwap(index, index + 1);
            listBox_backups.SetSelected(index + 1, true);
        }

        private void ToTop_Click(object sender, EventArgs e)
        {
            string s = listBox_backups.Items[listBox_backups.SelectedIndex].ToString();
            list.ToTop(s);
            listBox_backups.Items.Remove(s);
            listBox_backups.Items.Insert(0, s);
            listBox_backups.SetSelected(0, true);
        }

        private void ToBottom_Click(object sender, EventArgs e)
        {
            string s = listBox_backups.Items[listBox_backups.SelectedIndex].ToString();
            list.ToBottom(s);
            listBox_backups.Items.Remove(s);
            listBox_backups.Items.Add(s);
            listBox_backups.SetSelected(listBox_backups.Items.Count - 1, true);
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            Button_restore_Click(null, null);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string text;
            text = "确定要删除备份\"{0}\"吗?\r\n此操作不可恢复";
            text = MyString.Format(text, listBox_backups.SelectedItem.ToString());
            DialogResult d = MessageBox.Show(text, "提示", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                Dir.Delete(PATH_BACKUPS + @"\" + listBox_backups.SelectedItem.ToString());
                list.Remove(listBox_backups.SelectedItem.ToString());
                listBox_backups.Items.RemoveAt(listBox_backups.SelectedIndex);
            }
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            bool changed;
            DialogResult dr = new Form_rename(listBox_backups.SelectedItem.ToString()).ShowDialog();
            if (dr == Form_rename.DIALOGRESULT_NOTHINGCHANGED)
            {
                changed = false;
            }
            else if (list.Contains(conf.Read()))
            {
                changed = false;
                ShowErrorMessage("无法重命名,因为存在同名备份");
            }
            else
            {
                changed = true;
            }
            if (changed)
            {
                list.Rename(listBox_backups.SelectedItem.ToString(), conf.Read());
                Dir.Move(PATH_BACKUPS + @"\" + listBox_backups.SelectedItem.ToString(), PATH_BACKUPS + @"\" + conf.Read());

                int index = listBox_backups.SelectedIndex;
                listBox_backups.Items.RemoveAt(index);
                listBox_backups.Items.Insert(index, conf.Read());
                listBox_backups.SetSelected(index, true);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = MyString.Format("导出备份\"{0}\"\r\n\r\n请选择导出目录", listBox_backups.SelectedItem.ToString());
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string source = PATH_BACKUPS + @"\" + listBox_backups.SelectedItem.ToString();
                string destination = fbd.SelectedPath + @"\" + listBox_backups.SelectedItem.ToString();
                Dir.Copy(source, destination);
                MessageBox.Show(MyString.Format("已导出\"{0}\"到\r\n\"{1}\"", listBox_backups.SelectedItem.ToString(), fbd.SelectedPath), "提示");
            }
        }

        private void Changegamever(object sender, EventArgs e)
        {
            SelectVersion();
        }

        private void Opendir_Click(object sender, EventArgs e)
        {
            Process.Start(path_userdata);
        }

        private void About_Click(object sender, EventArgs e)
        {
            new Form_about().ShowDialog();
        }

        /// <summary>
        /// 更改窗口底部标签的标题
        /// </summary>
        /// <param name="str">显示的文本</param>
        private void SetBottomText(string str)
        {
            label_info.Text = str;
        }
        /// <summary>
        /// 交换listbox中的item
        /// </summary>
        /// <param name="i">index1</param>
        /// <param name="j">index2</param>
        private void ListBoxSwap(int i, int j)
        {
            if (i != j)
            {
                string[] name = new string[2] { listBox_backups.Items[i].ToString(), listBox_backups.Items[j].ToString() };
                listBox_backups.Items.RemoveAt(i);
                listBox_backups.Items.Insert(i, name[1]);
                listBox_backups.Items.RemoveAt(j);
                listBox_backups.Items.Insert(j, name[0]);
            }
        }
        /// <summary>
        /// 选择游戏版本
        /// </summary>
        private void SelectVersion()
        {
            switch (PVZVersion.Check())
            {
                case PVZVersion.VAR:
                    DialogResult dr = new Form_selectVersion().ShowDialog();
                    switch (dr)
                    {
                        case Form_selectVersion.DIALOGRESULT_ORIGINAL: path_userdata = PATH_PVZUSERDATA_ORIGINAL; gamever=PVZVersion.ORIGINAL; break;
                        case Form_selectVersion.DIALOGRESULT_STEAM:    path_userdata = PATH_PVZUSERDATA_STEAM;    gamever=PVZVersion.STEAM;    break;
                        case Form_selectVersion.DIALOGRESULT_ZOO_JP:   path_userdata = PATH_PVZUSERDATA_ZOO_JP;   gamever=PVZVersion.ZOO_JP;   break;
                        case Form_selectVersion.DIALOGRESULT_NONE:     Close(); break;
                    }
                    break;
                case PVZVersion.ORIGINAL: path_userdata = PATH_PVZUSERDATA_ORIGINAL; gamever = PVZVersion.ORIGINAL; break;
                case PVZVersion.STEAM:    path_userdata = PATH_PVZUSERDATA_STEAM;    gamever = PVZVersion.STEAM;    break;
                case PVZVersion.ZOO_JP:   path_userdata = PATH_PVZUSERDATA_ZOO_JP;   gamever = PVZVersion.ZOO_JP;   break;
                case PVZVersion.NONE:     SetPath(); break;
            }
            RemoveReadOnly();
        }
        /// <summary>
        /// 找不到默认存档路径时手动选择存档路径
        /// </summary>
        private void SetPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = Environment.OSVersion.Version.Major < 6 ?
                "当前系统版本过低，您需要手动选择存档路径\r\n\r\n请选择\"userdata\"所在目录" :
                "找不到游戏存档路径，您需要手动选择存档路径\r\n\r\n请选择\"userdata\"所在目录";
            string path_xp = MyString.Path_BKdata + @"\xp.bin";
            if (File.Exists(path_xp))
            {
                string tmp = File.ReadAllText(path_xp);
                if (Directory.Exists(tmp)) fbd.SelectedPath = tmp;
            }
            else
            {
                File.WriteAllText(path_xp, "");
            }
            DialogResult fbd_dr = fbd.ShowDialog();
            if (fbd_dr == DialogResult.OK)
            {
                File.WriteAllText(path_xp, fbd.SelectedPath);
                path_userdata = fbd.SelectedPath + @"\userdata";
                if (Directory.Exists(path_userdata))
                {
                    gamever = PVZVersion.XPMODE;
                }
                else
                {
                    ShowErrorMessage(MyString.Format("找不到路径\"{0}\"", path_userdata));
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// 去除存档的只读属性
        /// </summary>
        private void RemoveReadOnly()
        {
            string bat = MyString.Path_BKdata + @"\attrib.bat";
            string cmd = MyString.Format(Properties.Resources.attrib, PATH_BACKUPS, path_userdata);
            File.WriteAllText(bat, cmd);

            Process proc = new Process();
            proc.StartInfo.FileName    = bat;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }
        /// <summary>
        /// 弹窗显示错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(
                message,
                "错误",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
            Activate();
        }

    }
}