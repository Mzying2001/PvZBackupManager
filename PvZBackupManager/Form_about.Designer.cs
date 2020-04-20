namespace PvZBackupManager
{
    partial class Form_about
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_info = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.pictureBox_icon = new System.Windows.Forms.PictureBox();
            this.linkLabel_updatelog = new System.Windows.Forms.LinkLabel();
            this.linkLabel_viewSource = new System.Windows.Forms.LinkLabel();
            this.linkLabel_update = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(95, 53);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(30, 17);
            this.label_info.TabIndex = 5;
            this.label_info.Text = "info";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(92, 17);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(290, 36);
            this.label_title.TabIndex = 4;
            this.label_title.Text = "PvZBackupManager";
            // 
            // pictureBox_icon
            // 
            this.pictureBox_icon.Image = global::PvZBackupManager.Properties.Resources.icon_72px;
            this.pictureBox_icon.Location = new System.Drawing.Point(14, 17);
            this.pictureBox_icon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox_icon.Name = "pictureBox_icon";
            this.pictureBox_icon.Size = new System.Drawing.Size(72, 72);
            this.pictureBox_icon.TabIndex = 3;
            this.pictureBox_icon.TabStop = false;
            // 
            // linkLabel_updatelog
            // 
            this.linkLabel_updatelog.AutoSize = true;
            this.linkLabel_updatelog.Location = new System.Drawing.Point(212, 115);
            this.linkLabel_updatelog.Name = "linkLabel_updatelog";
            this.linkLabel_updatelog.Size = new System.Drawing.Size(56, 17);
            this.linkLabel_updatelog.TabIndex = 6;
            this.linkLabel_updatelog.TabStop = true;
            this.linkLabel_updatelog.Text = "更新日志";
            this.linkLabel_updatelog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_updatelog_LinkClicked);
            // 
            // linkLabel_viewSource
            // 
            this.linkLabel_viewSource.AutoSize = true;
            this.linkLabel_viewSource.Location = new System.Drawing.Point(274, 115);
            this.linkLabel_viewSource.Name = "linkLabel_viewSource";
            this.linkLabel_viewSource.Size = new System.Drawing.Size(56, 17);
            this.linkLabel_viewSource.TabIndex = 8;
            this.linkLabel_viewSource.TabStop = true;
            this.linkLabel_viewSource.Text = "查看源码";
            this.linkLabel_viewSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_viewSource_LinkClicked);
            // 
            // linkLabel_update
            // 
            this.linkLabel_update.AutoSize = true;
            this.linkLabel_update.Location = new System.Drawing.Point(336, 115);
            this.linkLabel_update.Name = "linkLabel_update";
            this.linkLabel_update.Size = new System.Drawing.Size(56, 17);
            this.linkLabel_update.TabIndex = 9;
            this.linkLabel_update.TabStop = true;
            this.linkLabel_update.Text = "下载新版";
            this.linkLabel_update.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_update_LinkClicked);
            // 
            // Form_about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 141);
            this.Controls.Add(this.linkLabel_update);
            this.Controls.Add(this.linkLabel_viewSource);
            this.Controls.Add(this.linkLabel_updatelog);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.pictureBox_icon);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_about";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.Load += new System.EventHandler(this.Form_about_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.PictureBox pictureBox_icon;
        private System.Windows.Forms.LinkLabel linkLabel_updatelog;
        private System.Windows.Forms.LinkLabel linkLabel_viewSource;
        private System.Windows.Forms.LinkLabel linkLabel_update;
    }
}