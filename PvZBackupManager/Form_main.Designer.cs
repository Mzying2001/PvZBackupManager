namespace PvZBackupManager
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox_backups = new System.Windows.Forms.ListBox();
            this.button_create = new System.Windows.Forms.Button();
            this.button_restore = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.linkLabel_options = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip_listbox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.up = new System.Windows.Forms.ToolStripMenuItem();
            this.down = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.totop = new System.Windows.Forms.ToolStripMenuItem();
            this.tobottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.restore = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.export = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.currentgamever = new System.Windows.Forms.ToolStripMenuItem();
            this.opendir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.topmost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_listbox.SuspendLayout();
            this.contextMenuStrip_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_backups
            // 
            this.listBox_backups.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_backups.FormattingEnabled = true;
            this.listBox_backups.IntegralHeight = false;
            this.listBox_backups.ItemHeight = 21;
            this.listBox_backups.Location = new System.Drawing.Point(12, 48);
            this.listBox_backups.Name = "listBox_backups";
            this.listBox_backups.Size = new System.Drawing.Size(340, 184);
            this.listBox_backups.TabIndex = 0;
            this.listBox_backups.SelectedIndexChanged += new System.EventHandler(this.ListBox_backups_SelectedIndexChanged);
            this.listBox_backups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_backups_MouseDoubleClick);
            this.listBox_backups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox_backups_MouseDown);
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(12, 12);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(65, 30);
            this.button_create.TabIndex = 1;
            this.button_create.Text = "新建";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.Button_create_Click);
            // 
            // button_restore
            // 
            this.button_restore.Enabled = false;
            this.button_restore.Location = new System.Drawing.Point(83, 12);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(65, 30);
            this.button_restore.TabIndex = 2;
            this.button_restore.Text = "恢复";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.Button_restore_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(12, 235);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(63, 17);
            this.label_info.TabIndex = 4;
            this.label_info.Text = "label_info";
            // 
            // linkLabel_options
            // 
            this.linkLabel_options.AutoSize = true;
            this.linkLabel_options.Location = new System.Drawing.Point(311, 235);
            this.linkLabel_options.Name = "linkLabel_options";
            this.linkLabel_options.Size = new System.Drawing.Size(41, 17);
            this.linkLabel_options.TabIndex = 6;
            this.linkLabel_options.TabStop = true;
            this.linkLabel_options.Text = "选项...";
            this.linkLabel_options.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_options_LinkClicked);
            // 
            // contextMenuStrip_listbox
            // 
            this.contextMenuStrip_listbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.up,
            this.down,
            this.toolStripMenuItem1,
            this.totop,
            this.tobottom,
            this.toolStripMenuItem2,
            this.restore,
            this.delete,
            this.rename,
            this.toolStripMenuItem3,
            this.export});
            this.contextMenuStrip_listbox.Name = "contextMenuStrip_listbox";
            this.contextMenuStrip_listbox.Size = new System.Drawing.Size(125, 198);
            // 
            // up
            // 
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(124, 22);
            this.up.Text = "上移";
            this.up.Click += new System.EventHandler(this.Up_Click);
            // 
            // down
            // 
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(124, 22);
            this.down.Text = "下移";
            this.down.Click += new System.EventHandler(this.Down_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // totop
            // 
            this.totop.Name = "totop";
            this.totop.Size = new System.Drawing.Size(124, 22);
            this.totop.Text = "移到顶层";
            this.totop.Click += new System.EventHandler(this.ToTop_Click);
            // 
            // tobottom
            // 
            this.tobottom.Name = "tobottom";
            this.tobottom.Size = new System.Drawing.Size(124, 22);
            this.tobottom.Text = "移到底层";
            this.tobottom.Click += new System.EventHandler(this.ToBottom_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // restore
            // 
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(124, 22);
            this.restore.Text = "恢复";
            this.restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(124, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // rename
            // 
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(124, 22);
            this.rename.Text = "重命名";
            this.rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(121, 6);
            // 
            // export
            // 
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(124, 22);
            this.export.Text = "导出";
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // contextMenuStrip_options
            // 
            this.contextMenuStrip_options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentgamever,
            this.opendir,
            this.toolStripSeparator1,
            this.topmost,
            this.toolStripSeparator2,
            this.about});
            this.contextMenuStrip_options.Name = "contextMenuStrip_options";
            this.contextMenuStrip_options.Size = new System.Drawing.Size(173, 104);
            // 
            // currentgamever
            // 
            this.currentgamever.Name = "currentgamever";
            this.currentgamever.Size = new System.Drawing.Size(172, 22);
            this.currentgamever.Text = "currentgamever";
            this.currentgamever.Click += new System.EventHandler(this.Changegamever_Click);
            // 
            // opendir
            // 
            this.opendir.Name = "opendir";
            this.opendir.Size = new System.Drawing.Size(172, 22);
            this.opendir.Text = "打开游戏存档目录";
            this.opendir.Click += new System.EventHandler(this.Opendir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // topmost
            // 
            this.topmost.Name = "topmost";
            this.topmost.Size = new System.Drawing.Size(172, 22);
            this.topmost.Text = "窗口顶置";
            this.topmost.Click += new System.EventHandler(this.Topmost_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(172, 22);
            this.about.Text = "关于";
            this.about.Click += new System.EventHandler(this.About_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 261);
            this.Controls.Add(this.linkLabel_options);
            this.Controls.Add(this.button_restore);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.listBox_backups);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(380, 300);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PvZ存档管理器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.SizeChanged += new System.EventHandler(this.Form_main_SizeChanged);
            this.contextMenuStrip_listbox.ResumeLayout(false);
            this.contextMenuStrip_options.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_backups;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_restore;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.LinkLabel linkLabel_options;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listbox;
        private System.Windows.Forms.ToolStripMenuItem up;
        private System.Windows.Forms.ToolStripMenuItem down;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem totop;
        private System.Windows.Forms.ToolStripMenuItem tobottom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem restore;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.ToolStripMenuItem rename;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem export;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_options;
        private System.Windows.Forms.ToolStripMenuItem currentgamever;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem opendir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem topmost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

