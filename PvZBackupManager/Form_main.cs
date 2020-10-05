using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static PvZBackupManager.MyString;

namespace PvZBackupManager
{
    public partial class Form_main : Form
    {
        
        private readonly IniFile     conf;
        private readonly StrListFile list;

        private LinkLabel button_debug;
        private DPI dpi;

        private bool   justStartUp = true;
        private int    gamever;
        private string path_userdata;

        public Form_main()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;

            #region 旧系统(xp)下针对旧版本(v1.0.7及以下)的操作

            if (Environment.OSVersion.Version.Major < 6)
            {
                string path_old = @"C:\ProgramData\PvZBackupManager";
                if (Directory.Exists(path_old) && !Directory.Exists(Path_BKdata))
                {
                    Dir.Move(path_old, Path_BKdata);
                }
            }

            #endregion

            #region 检测管理器文档路径是否存在，不存在则创建路径

            if (!Directory.Exists(Path_BKdata))
            {
                Directory.CreateDirectory(Path_BKdata);
            }
            if (!Directory.Exists(Path_backups))
            {
                Directory.CreateDirectory(Path_backups);
            }

            #endregion

            conf = new IniFile(Path_conf);
            list = new StrListFile(Path_list);
            SelectVersion();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {

            #region 加入item

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (Directory.Exists(Path_backups + @"\" + list[i]))
                {
                    listBox_backups.Items.Insert(0, list[i]);
                }
                else
                {
                    list.RemoveAt(i);
                }
            }
            foreach(var tmp in Directory.GetDirectories(Path_backups))
            {
                string name = tmp.Substring(tmp.LastIndexOf('\\') + 1);
                if(!list.Contains(name))
                {
                    if(Directory.Exists(tmp + @"\userdata"))
                    {
                        list.Add(name);
                        listBox_backups.Items.Add(name);
                    }
                    else
                    {
                        Dir.Delete(tmp);
                    }
                }
            }

            #endregion

            #region Dpi调整组件大小

            dpi = Dpi.GetDpi(this);

            float dx = dpi.DpiX / 100;
            float dy = dpi.DpiY / 100;

            button_create.Width = (int)(button_create.Width * dx);
            button_create.Height = (int)(button_create.Height * dy);

            button_restore.Width = (int)(button_restore.Width * dx);
            button_restore.Height = (int)(button_restore.Height * dy);

            button_restore.Left = button_create.Right + 6;
            listBox_backups.Top = button_create.Bottom + 6;

            #endregion

            ListBox_backups_SelectedIndexChanged(null, null);
            Form_main_SizeChanged(null, null);
            Activate();

            #region 恢复上一次关闭时的窗口位置

            int[] ws = new int[4]
            {
                conf.GetInteger("WindowState", "x"),
                conf.GetInteger("WindowState", "y"),
                conf.GetInteger("WindowState", "w"),
                conf.GetInteger("WindowState", "h"),
            };
            bool available = true;
            foreach(int tmp in ws)
            {
                if (tmp == -1)
                {
                    available = false;
                    break;
                }
            }
            if (available)
            {
                if (ws[0] < 0)
                    ws[0] = 0;
                else if (ws[0] + ws[2] > Screen.PrimaryScreen.Bounds.Width)
                    ws[0] = Screen.PrimaryScreen.Bounds.Width - ws[2];

                if (ws[1] < 0)
                    ws[1] = 0;
                else if (ws[1] + ws[3] > Screen.PrimaryScreen.Bounds.Height)
                    ws[1] = Screen.PrimaryScreen.Bounds.Height - ws[3];

                Left   = ws[0];
                Top    = ws[1];
                Width  = ws[2];
                Height = ws[3];
            }

            #endregion

            TopMost = conf.GetBoolean("var", "TopMost");

            justStartUp = false;

            #region 添加DEBUG按钮（此部分代码只在debug下执行）
#if DEBUG
            button_debug = new LinkLabel
            {
                Text = "DEBUG",
                AutoSize = true,
                Left = button_restore.Right + 6,
                Top = button_restore.Top
            };
            button_debug.Click += (object sender_, EventArgs e_) =>
            {
                string output = string.Empty;

                output +=
                    string.Format("【文件夹路径】\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n\n",
                    Path_AppData,
                    Path_BKdata,
                    Path_backups,
                    PATH_PVZUSERDATA_ORIGINAL,
                    PATH_PVZUSERDATA_STEAM,
                    PATH_PVZUSERDATA_ZOO_JP
                    );

                output +=
                    string.Format("【URL】\n{0}\n{1}\n\n",
                    URL_VIEWSOURCE, URL_UPDATE);

                output +=
                    string.Format("【DPI】\nDpiX: {0}\nDpiY: {1}\n\n",
                    dpi.DpiX, dpi.DpiY);

                output +=
                    string.Format("【当前】\nOS version (major): {0}\ngamever: {1}\npath_userdata: {2}",
                    Environment.OSVersion.Version.Major, gamever, path_userdata);

                MessageBox.Show(output, "DEBUG");
            };
            Controls.Add(button_debug);
#endif
            #endregion

        }

        private void Form_main_SizeChanged(object sender, EventArgs e)
        {
            listBox_backups.Height = ClientSize.Height - listBox_backups.Top - label_info.Height - 6;
            listBox_backups.Width  = ClientSize.Width - listBox_backups.Left * 2;
            label_info.Top         = listBox_backups.Top + listBox_backups.Height + 2;
            linkLabel_options.Top  = label_info.Top;
            linkLabel_options.Left = listBox_backups.Left + listBox_backups.Width - linkLabel_options.Width;
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                conf.WriteValue("WindowState", "x", Left);
                conf.WriteValue("WindowState", "y", Top);
                conf.WriteValue("WindowState", "w", Width);
                conf.WriteValue("WindowState", "h", Height);
            }
            conf.WriteValue("var", "TopMost", TopMost);
            Environment.Exit(0);
        }



        private void Button_create_Click(object sender, EventArgs e)
        {
            string name = new Form_create(gamever, dpi).ShowDialog();

            if (string.IsNullOrEmpty(name))
            {
            }
            else if (list.Contains(name))
            {
                ShowErrorMessage("无法创建,因为命名出现重复");
            }
            else
            {
                list.Add(name);
                Directory.CreateDirectory(Path_backups + @"\" + name);
                Dir.Copy(path_userdata, Path_backups + @"\" + name + @"\userdata");

                listBox_backups.Items.Add(name);
                listBox_backups.SetSelected(listBox_backups.Items.Count - 1, true);
            }
        }

        private void Button_restore_Click(object sender, EventArgs e)
        {
            string SelectedItem = listBox_backups.SelectedItem.ToString();

            string text;
            text = "确定要恢复备份\"{0}\"吗?\n此操作会覆盖当前存档";
            text = string.Format(text, SelectedItem);

            if (MessageBox.Show(text, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Dir.Delete(path_userdata, true);
                    Dir.Copy(Path_backups + @"\" + SelectedItem + @"\userdata", path_userdata);
                    MessageBox.Show(string.Format("已恢复到备份\"{0}\"", SelectedItem), "提示");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(string.Format("无法恢复备份，若多次出现此错误，请尝试关闭游戏后重试。\n\n{0}", ex));
                }
            }
        }

        private void ListBox_backups_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_restore.Enabled = listBox_backups.SelectedIndex >= 0;
            BottomText = string.Format("已备份存档{0}个", listBox_backups.Items.Count);
        }

        private void ListBox_backups_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBox_backups.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right && index >= 0)
            {
                listBox_backups.SetSelected(index, true);
                if (listBox_backups.Items.Count == 1)
                {
                    up.Enabled = false;
                    down.Enabled = false;
                    totop.Enabled = false;
                    tobottom.Enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        up.Enabled = false;
                        down.Enabled = true;
                        totop.Enabled = false;
                        tobottom.Enabled = true;
                    }
                    else if (index == listBox_backups.Items.Count - 1)
                    {
                        up.Enabled = true;
                        down.Enabled = false;
                        totop.Enabled = true;
                        tobottom.Enabled = false;
                    }
                    else
                    {
                        up.Enabled = true;
                        down.Enabled = true;
                        totop.Enabled = true;
                        tobottom.Enabled = true;
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
                    tmp = string.Format(tmp, "原版");
                    break;

                case PVZVersion.STEAM:
                    tmp = string.Format(tmp, "Steam版");
                    break;

                case PVZVersion.ZOO_JP:
                    tmp = string.Format(tmp, "Zoo日文版");
                    break;

                case PVZVersion.XPMODE:
                    tmp = string.Format("正在使用\"{0}\"", path_userdata);
                    currentgamever.Enabled = false;
                    break;
            }
            currentgamever.Text = tmp;
            topmost.Checked = TopMost;
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
            string item = listBox_backups.Items[listBox_backups.SelectedIndex].ToString();
            list.ToTop(item);
            listBox_backups.Items.Remove(item);
            listBox_backups.Items.Insert(0, item);
            listBox_backups.SetSelected(0, true);
        }

        private void ToBottom_Click(object sender, EventArgs e)
        {
            string item = listBox_backups.Items[listBox_backups.SelectedIndex].ToString();
            list.ToBottom(item);
            listBox_backups.Items.Remove(item);
            listBox_backups.Items.Add(item);
            listBox_backups.SetSelected(listBox_backups.Items.Count - 1, true);
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            Button_restore_Click(null, null);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string SelectedItem = listBox_backups.SelectedItem.ToString();

            string text;
            text = "确定要删除备份\"{0}\"吗?\n此操作不可恢复";
            text = string.Format(text, SelectedItem);

            if (MessageBox.Show(text, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dir.Delete(Path_backups + @"\" + SelectedItem);
                list.Remove(SelectedItem);
                listBox_backups.Items.RemoveAt(listBox_backups.SelectedIndex);
            }
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            string SelectedItem = listBox_backups.SelectedItem.ToString();
            string name = new Form_rename(SelectedItem, dpi).ShowDialog();
            
            if (string.IsNullOrEmpty(name))
            {
            }
            else if (list.Contains(name))
            {
                ShowErrorMessage("无法重命名,因为存在同名备份");
            }
            else
            {
                list.Rename(SelectedItem, name);
                Dir.Move(Path_backups + @"\" + SelectedItem, Path_backups + @"\" + name);

                int index = listBox_backups.SelectedIndex;
                listBox_backups.Items.RemoveAt(index);
                listBox_backups.Items.Insert(index, name);
                listBox_backups.SetSelected(index, true);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string SelectedItem = listBox_backups.SelectedItem.ToString();
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = string.Format("导出备份\"{0}\"\n\n请选择导出目录", SelectedItem)
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string source = Path_backups + @"\" + SelectedItem;
                string destination = fbd.SelectedPath + @"\" + SelectedItem;
                Dir.Copy(source, destination);
                MessageBox.Show(string.Format("已导出\"{0}\"到\n\"{1}\"", SelectedItem, fbd.SelectedPath), "提示");
            }
        }

        private void Changegamever_Click(object sender, EventArgs e)
        {
            SelectVersion();
        }

        private void Opendir_Click(object sender, EventArgs e)
        {
            Process.Start(path_userdata);
        }

        private void Topmost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void About_Click(object sender, EventArgs e)
        {
            new Form_about(dpi).ShowDialog();
        }

        /// <summary>
        /// 窗口底部标签的标题
        /// </summary>
        private string BottomText
        {
            set
            {
                label_info.Text = value;
            }
        }

        /// <summary>
        /// 交换listbox中的item
        /// </summary>
        private void ListBoxSwap(int i, int j)
        {
            if (i != j)
            {
                string name1 = listBox_backups.Items[i].ToString();
                string name2 = listBox_backups.Items[j].ToString();

                listBox_backups.Items.RemoveAt(i);
                listBox_backups.Items.Insert(i, name2);
                listBox_backups.Items.RemoveAt(j);
                listBox_backups.Items.Insert(j, name1);
            }
        }

        /// <summary>
        /// 选择游戏版本
        /// </summary>
        private void SelectVersion()
        {
            int ver_tmp;

            ver_tmp = conf.GetInteger("var", "gamever");
            ver_tmp = (PVZVersion.Exists(ver_tmp) && justStartUp) ? ver_tmp : PVZVersion.Check();

            if (ver_tmp == PVZVersion.NONE)
            {
                SetPath();
                return;
            }

            ver_tmp = (ver_tmp == PVZVersion.VAR) ? new Form_selectVersion(dpi).ShowDialog() : ver_tmp;

            switch (ver_tmp)
            {
                case PVZVersion.ORIGINAL:
                    path_userdata = PATH_PVZUSERDATA_ORIGINAL;
                    break;

                case PVZVersion.STEAM:
                    path_userdata = PATH_PVZUSERDATA_STEAM;
                    break;

                case PVZVersion.ZOO_JP:
                    path_userdata = PATH_PVZUSERDATA_ZOO_JP;
                    break;

                case PVZVersion.NONE:
                    if (justStartUp)
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
            gamever = (ver_tmp == PVZVersion.NONE) ? gamever : ver_tmp;
            RemoveReadOnly();
        }

        /// <summary>
        /// 找不到默认存档路径时手动选择存档路径
        /// </summary>
        private void SetPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,

                SelectedPath = conf["Path", "xp"],

                Description = Environment.OSVersion.Version.Major < 6 ?
                "当前系统版本过低，您需要手动选择存档路径\n\n请选择\"userdata\"所在目录" :
                "找不到游戏存档路径，您需要手动选择存档路径\n\n请选择\"userdata\"所在目录"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path_userdata = fbd.SelectedPath + @"\userdata";

                if (Directory.Exists(path_userdata))
                {
                    conf["Path", "xp"] = fbd.SelectedPath;
                    gamever = PVZVersion.XPMODE;
                    RemoveReadOnly();
                }
                else
                {
                    ShowErrorMessage(string.Format("找不到路径\"{0}\"", path_userdata));
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
            string bat = Path_BKdata + @"\attrib.bat";
            string cmd = string.Format(Properties.Resources.attrib, Path_backups, path_userdata);
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
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
