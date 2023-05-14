
namespace ADB_Control
{
    partial class ADB_Ctrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADB_Ctrl));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Switch = new System.Windows.Forms.Button();
            this.button_Root = new System.Windows.Forms.Button();
            this.button_Reboot = new System.Windows.Forms.Button();
            this.button_DelVecentek = new System.Windows.Forms.Button();
            this.button_ReVecentek = new System.Windows.Forms.Button();
            this.button_MoveApp = new System.Windows.Forms.Button();
            this.textBox_FileSource = new System.Windows.Forms.TextBox();
            this.button_MovePrivApp = new System.Windows.Forms.Button();
            this.button_DataApp = new System.Windows.Forms.Button();
            this.button_system = new System.Windows.Forms.Button();
            this.textBox_CustomDest = new System.Windows.Forms.TextBox();
            this.button_CustomTransfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_ONwifiDebug = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label_DeviceName = new System.Windows.Forms.Label();
            this.button_sdcard = new System.Windows.Forms.Button();
            this.comboBox_FileType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Memory_usage_rate = new System.Windows.Forms.Label();
            this.textBox_ApkSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_InstallApk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_Switch
            // 
            this.button_Switch.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Switch.Location = new System.Drawing.Point(12, 110);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(162, 49);
            this.button_Switch.TabIndex = 1;
            this.button_Switch.Text = "解锁权限";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click);
            // 
            // button_Root
            // 
            this.button_Root.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Root.Location = new System.Drawing.Point(12, 55);
            this.button_Root.Name = "button_Root";
            this.button_Root.Size = new System.Drawing.Size(162, 49);
            this.button_Root.TabIndex = 1;
            this.button_Root.Text = "Root";
            this.button_Root.UseVisualStyleBackColor = true;
            this.button_Root.Click += new System.EventHandler(this.button_Root_Click);
            // 
            // button_Reboot
            // 
            this.button_Reboot.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Reboot.Location = new System.Drawing.Point(12, 377);
            this.button_Reboot.Name = "button_Reboot";
            this.button_Reboot.Size = new System.Drawing.Size(162, 49);
            this.button_Reboot.TabIndex = 1;
            this.button_Reboot.Text = "重启";
            this.button_Reboot.UseVisualStyleBackColor = true;
            this.button_Reboot.Click += new System.EventHandler(this.button_Reboot_Click);
            // 
            // button_DelVecentek
            // 
            this.button_DelVecentek.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DelVecentek.Location = new System.Drawing.Point(12, 165);
            this.button_DelVecentek.Name = "button_DelVecentek";
            this.button_DelVecentek.Size = new System.Drawing.Size(162, 49);
            this.button_DelVecentek.TabIndex = 1;
            this.button_DelVecentek.Text = "删除保护";
            this.button_DelVecentek.UseVisualStyleBackColor = true;
            this.button_DelVecentek.Click += new System.EventHandler(this.button_DelVecentek_Click);
            // 
            // button_ReVecentek
            // 
            this.button_ReVecentek.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ReVecentek.Location = new System.Drawing.Point(12, 220);
            this.button_ReVecentek.Name = "button_ReVecentek";
            this.button_ReVecentek.Size = new System.Drawing.Size(162, 49);
            this.button_ReVecentek.TabIndex = 1;
            this.button_ReVecentek.Text = "恢复保护";
            this.button_ReVecentek.UseVisualStyleBackColor = true;
            this.button_ReVecentek.Click += new System.EventHandler(this.button_ReVecentek_Click);
            // 
            // button_MoveApp
            // 
            this.button_MoveApp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_MoveApp.Location = new System.Drawing.Point(300, 113);
            this.button_MoveApp.Name = "button_MoveApp";
            this.button_MoveApp.Size = new System.Drawing.Size(216, 50);
            this.button_MoveApp.TabIndex = 3;
            this.button_MoveApp.Text = "到/system/app";
            this.button_MoveApp.UseVisualStyleBackColor = true;
            this.button_MoveApp.Click += new System.EventHandler(this.button_MoveApp_Click);
            // 
            // textBox_FileSource
            // 
            this.textBox_FileSource.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_FileSource.Location = new System.Drawing.Point(300, 62);
            this.textBox_FileSource.Name = "textBox_FileSource";
            this.textBox_FileSource.Size = new System.Drawing.Size(438, 34);
            this.textBox_FileSource.TabIndex = 2;
            this.textBox_FileSource.DoubleClick += new System.EventHandler(this.textBox_FileSource_DoubleClick);
            // 
            // button_MovePrivApp
            // 
            this.button_MovePrivApp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_MovePrivApp.Location = new System.Drawing.Point(522, 113);
            this.button_MovePrivApp.Name = "button_MovePrivApp";
            this.button_MovePrivApp.Size = new System.Drawing.Size(216, 50);
            this.button_MovePrivApp.TabIndex = 3;
            this.button_MovePrivApp.Text = "到/system/priv-app";
            this.button_MovePrivApp.UseVisualStyleBackColor = true;
            this.button_MovePrivApp.Click += new System.EventHandler(this.button_MovePrivApp_Click);
            // 
            // button_DataApp
            // 
            this.button_DataApp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DataApp.Location = new System.Drawing.Point(744, 113);
            this.button_DataApp.Name = "button_DataApp";
            this.button_DataApp.Size = new System.Drawing.Size(216, 50);
            this.button_DataApp.TabIndex = 3;
            this.button_DataApp.Text = "到/data/app";
            this.button_DataApp.UseVisualStyleBackColor = true;
            this.button_DataApp.Click += new System.EventHandler(this.button_DataApp_Click);
            // 
            // button_system
            // 
            this.button_system.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_system.Location = new System.Drawing.Point(300, 169);
            this.button_system.Name = "button_system";
            this.button_system.Size = new System.Drawing.Size(216, 50);
            this.button_system.TabIndex = 3;
            this.button_system.Text = "到/system/";
            this.button_system.UseVisualStyleBackColor = true;
            this.button_system.Click += new System.EventHandler(this.button_system_Click);
            // 
            // textBox_CustomDest
            // 
            this.textBox_CustomDest.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CustomDest.Location = new System.Drawing.Point(300, 235);
            this.textBox_CustomDest.Name = "textBox_CustomDest";
            this.textBox_CustomDest.Size = new System.Drawing.Size(438, 34);
            this.textBox_CustomDest.TabIndex = 2;
            // 
            // button_CustomTransfer
            // 
            this.button_CustomTransfer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_CustomTransfer.Location = new System.Drawing.Point(744, 235);
            this.button_CustomTransfer.Name = "button_CustomTransfer";
            this.button_CustomTransfer.Size = new System.Drawing.Size(216, 34);
            this.button_CustomTransfer.TabIndex = 3;
            this.button_CustomTransfer.Text = "自由传输";
            this.button_CustomTransfer.UseVisualStyleBackColor = true;
            this.button_CustomTransfer.Click += new System.EventHandler(this.button_CustomTransfer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(259, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "从";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(259, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "到";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ONwifiDebug
            // 
            this.button_ONwifiDebug.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ONwifiDebug.Location = new System.Drawing.Point(12, 275);
            this.button_ONwifiDebug.Name = "button_ONwifiDebug";
            this.button_ONwifiDebug.Size = new System.Drawing.Size(162, 49);
            this.button_ONwifiDebug.TabIndex = 1;
            this.button_ONwifiDebug.Text = "WiFi调试";
            this.button_ONwifiDebug.UseVisualStyleBackColor = true;
            this.button_ONwifiDebug.Click += new System.EventHandler(this.button_ONwifiDebug_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label_DeviceName
            // 
            this.label_DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DeviceName.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DeviceName.ForeColor = System.Drawing.Color.Red;
            this.label_DeviceName.Location = new System.Drawing.Point(12, 9);
            this.label_DeviceName.Name = "label_DeviceName";
            this.label_DeviceName.Size = new System.Drawing.Size(675, 37);
            this.label_DeviceName.TabIndex = 0;
            this.label_DeviceName.Text = "未连接";
            this.label_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_sdcard
            // 
            this.button_sdcard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_sdcard.Location = new System.Drawing.Point(522, 169);
            this.button_sdcard.Name = "button_sdcard";
            this.button_sdcard.Size = new System.Drawing.Size(216, 50);
            this.button_sdcard.TabIndex = 3;
            this.button_sdcard.Text = "到/sdcard/";
            this.button_sdcard.UseVisualStyleBackColor = true;
            this.button_sdcard.Click += new System.EventHandler(this.button_sdcard_Click);
            // 
            // comboBox_FileType
            // 
            this.comboBox_FileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FileType.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_FileType.FormattingEnabled = true;
            this.comboBox_FileType.Items.AddRange(new object[] {
            "文件",
            "文件夹"});
            this.comboBox_FileType.Location = new System.Drawing.Point(744, 62);
            this.comboBox_FileType.Name = "comboBox_FileType";
            this.comboBox_FileType.Size = new System.Drawing.Size(216, 31);
            this.comboBox_FileType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(688, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "系统剩余空间：";
            // 
            // Memory_usage_rate
            // 
            this.Memory_usage_rate.AutoSize = true;
            this.Memory_usage_rate.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Memory_usage_rate.ForeColor = System.Drawing.Color.Red;
            this.Memory_usage_rate.Location = new System.Drawing.Point(868, 21);
            this.Memory_usage_rate.Name = "Memory_usage_rate";
            this.Memory_usage_rate.Size = new System.Drawing.Size(68, 25);
            this.Memory_usage_rate.TabIndex = 6;
            this.Memory_usage_rate.Text = "    ";
            // 
            // textBox_ApkSource
            // 
            this.textBox_ApkSource.BackColor = System.Drawing.Color.Lime;
            this.textBox_ApkSource.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ApkSource.Location = new System.Drawing.Point(300, 336);
            this.textBox_ApkSource.Name = "textBox_ApkSource";
            this.textBox_ApkSource.Size = new System.Drawing.Size(438, 34);
            this.textBox_ApkSource.TabIndex = 2;
            this.textBox_ApkSource.DoubleClick += new System.EventHandler(this.textBox_ApkSource_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(195, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apk路径";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_InstallApk
            // 
            this.button_InstallApk.BackColor = System.Drawing.Color.Lime;
            this.button_InstallApk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_InstallApk.Location = new System.Drawing.Point(744, 336);
            this.button_InstallApk.Name = "button_InstallApk";
            this.button_InstallApk.Size = new System.Drawing.Size(216, 34);
            this.button_InstallApk.TabIndex = 3;
            this.button_InstallApk.Text = "安装";
            this.button_InstallApk.UseVisualStyleBackColor = false;
            this.button_InstallApk.Click += new System.EventHandler(this.button_InstallApk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(246, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(714, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "注意事项：本APK安装方法并非适用所有软件及所有车型，请谨慎使用！！！";
            // 
            // ADB_Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(980, 438);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Memory_usage_rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_FileType);
            this.Controls.Add(this.label_DeviceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_InstallApk);
            this.Controls.Add(this.button_CustomTransfer);
            this.Controls.Add(this.button_sdcard);
            this.Controls.Add(this.button_system);
            this.Controls.Add(this.button_DataApp);
            this.Controls.Add(this.button_MovePrivApp);
            this.Controls.Add(this.button_MoveApp);
            this.Controls.Add(this.textBox_CustomDest);
            this.Controls.Add(this.textBox_ApkSource);
            this.Controls.Add(this.textBox_FileSource);
            this.Controls.Add(this.button_Root);
            this.Controls.Add(this.button_ONwifiDebug);
            this.Controls.Add(this.button_ReVecentek);
            this.Controls.Add(this.button_Reboot);
            this.Controls.Add(this.button_DelVecentek);
            this.Controls.Add(this.button_Switch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADB_Ctrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "锐程PLUS车机工具箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ADB_Ctrl_FormClosing);
            this.Load += new System.EventHandler(this.ADB_Ctrl_Load);
            this.LocationChanged += new System.EventHandler(this.ADB_Ctrl_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.Button button_Root;
        private System.Windows.Forms.Button button_Reboot;
        private System.Windows.Forms.Button button_DelVecentek;
        private System.Windows.Forms.Button button_ReVecentek;
        private System.Windows.Forms.Button button_MoveApp;
        private System.Windows.Forms.TextBox textBox_FileSource;
        private System.Windows.Forms.Button button_MovePrivApp;
        private System.Windows.Forms.Button button_DataApp;
        private System.Windows.Forms.Button button_system;
        private System.Windows.Forms.TextBox textBox_CustomDest;
        private System.Windows.Forms.Button button_CustomTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_ONwifiDebug;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label_DeviceName;
        private System.Windows.Forms.Button button_sdcard;
        private System.Windows.Forms.ComboBox comboBox_FileType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Memory_usage_rate;
        private System.Windows.Forms.TextBox textBox_ApkSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_InstallApk;
        private System.Windows.Forms.Label label4;
    }
}

