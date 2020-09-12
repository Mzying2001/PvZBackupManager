namespace PvZBackupManager
{
    partial class Form_selectVersion
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
            this.button_original = new System.Windows.Forms.Button();
            this.button_steam = new System.Windows.Forms.Button();
            this.button_zoo_jp = new System.Windows.Forms.Button();
            this.checkBox_remember = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_info
            // 
            this.label_info.Location = new System.Drawing.Point(12, 12);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(179, 56);
            this.label_info.TabIndex = 0;
            this.label_info.Text = "检测到您的电脑上有不同版本的游戏存档，请选择一个版本来管理存档";
            // 
            // button_original
            // 
            this.button_original.Location = new System.Drawing.Point(197, 12);
            this.button_original.Name = "button_original";
            this.button_original.Size = new System.Drawing.Size(75, 25);
            this.button_original.TabIndex = 1;
            this.button_original.Text = "原版";
            this.button_original.UseVisualStyleBackColor = true;
            this.button_original.Click += new System.EventHandler(this.Button_original_Click);
            // 
            // button_steam
            // 
            this.button_steam.Location = new System.Drawing.Point(197, 43);
            this.button_steam.Name = "button_steam";
            this.button_steam.Size = new System.Drawing.Size(75, 25);
            this.button_steam.TabIndex = 2;
            this.button_steam.Text = "Steam版";
            this.button_steam.UseVisualStyleBackColor = true;
            this.button_steam.Click += new System.EventHandler(this.Button_steam_Click);
            // 
            // button_zoo_jp
            // 
            this.button_zoo_jp.Location = new System.Drawing.Point(197, 74);
            this.button_zoo_jp.Name = "button_zoo_jp";
            this.button_zoo_jp.Size = new System.Drawing.Size(75, 25);
            this.button_zoo_jp.TabIndex = 3;
            this.button_zoo_jp.Text = "Zoo日文版";
            this.button_zoo_jp.UseVisualStyleBackColor = true;
            this.button_zoo_jp.Click += new System.EventHandler(this.Button_zoo_jp_Click);
            // 
            // checkBox_remember
            // 
            this.checkBox_remember.AutoSize = true;
            this.checkBox_remember.Location = new System.Drawing.Point(15, 77);
            this.checkBox_remember.Name = "checkBox_remember";
            this.checkBox_remember.Size = new System.Drawing.Size(75, 21);
            this.checkBox_remember.TabIndex = 4;
            this.checkBox_remember.Text = "记住选择";
            this.checkBox_remember.UseVisualStyleBackColor = true;
            // 
            // Form_selectVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.checkBox_remember);
            this.Controls.Add(this.button_zoo_jp);
            this.Controls.Add(this.button_steam);
            this.Controls.Add(this.button_original);
            this.Controls.Add(this.label_info);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_selectVersion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择版本";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_selectVersion_FormClosing);
            this.Load += new System.EventHandler(this.Form_SelectVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_original;
        private System.Windows.Forms.Button button_steam;
        private System.Windows.Forms.Button button_zoo_jp;
        private System.Windows.Forms.CheckBox checkBox_remember;
    }
}