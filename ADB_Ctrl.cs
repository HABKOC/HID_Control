using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace ADB_Control
{
    public partial class ADB_Ctrl : Form
    {
        private string AdbShell_Password = "";//锐程PLUS：adb36987|
        
        public ADB_Ctrl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 定义了窗体隐藏、出现的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.StopAanhor)
                {
                    case AnchorStyles.Top:
                        //窗体在最上方隐藏时，鼠标接触自动出现
                        this.Location = new Point(this.Location.X, 0);
                        break;
                    //窗体在最左方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;
                    //窗体在最右方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;
                }
            }
            else
            {
                //窗体隐藏时在靠近边界的一侧边会出现5像素原因：感应鼠标，同时5像素不会影响用户视线
                switch (this.StopAanhor)
                {
                    //窗体在顶部时时，隐藏在顶部，底部边界出现2像素
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - 5) * (-1));
                        break;
                    //窗体在最左边时时，隐藏在左边，右边边界出现2像素
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - 5), this.Location.Y);
                        break;
                    //窗体在最右边时时，隐藏在右边，左边边界出现2像素
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 5, this.Location.Y);
                        break;
                }
            }
        }
        internal AnchorStyles StopAanhor = AnchorStyles.None;
        /// <summary>
        /// 固定了窗体位置的类型
        /// </summary>
        private void mStopAnhor()
        {
            if (this.Top <= 0)
            {
                StopAanhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                StopAanhor = AnchorStyles.Right;
            }
            else
            {
                StopAanhor = AnchorStyles.None;
            }
        }
        private void ADB_Ctrl_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnhor();
        }

        private void ADB_Ctrl_Load(object sender, EventArgs e)
        {
            comboBox_FileType.SelectedIndex = 0;
            
            this.timer1.Start();//用于窗体侧边栏隐藏

            this.timer2.Start();//用于实时检测adb设备连接状态
        }

        private void ADB_Ctrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();

            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName=="adb")
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); 
                    }
                    catch
                    {
                    }
                }
            }
        }

        private string[] ADB_Order(string str)
        { 
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = Application.StartupPath + "//platform-tools";
            p.StartInfo.FileName = Application.StartupPath + "//platform-tools//adb.exe";
            p.StartInfo.Arguments = str;
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            //p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
            string[] output= { "",""};
            output[0] = p.StandardOutput.ReadToEnd();
            output[1] = p.StandardError.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            
            return output;
        }
        /// <summary>
        /// 获得系统超级管理员权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Root_Click(object sender, EventArgs e)
        {
            string[] ReturnValue= ADB_Order("root");
            if (ReturnValue[1] != "")
            {
                MessageBox.Show(ReturnValue[1]);
            }
            else
            {
                MessageBox.Show("Root成功");
            }
        }
        /// <summary>
        /// 释放分区读写权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Switch_Click(object sender, EventArgs e)
        {
            string[] ReturnValue = ADB_Order("remount");
            if (ReturnValue[1] != "")
            {
                MessageBox.Show(ReturnValue[1]);
            }
            else
            {
                MessageBox.Show("Remount成功");
            }
        }
        /// <summary>
        /// 重启设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Reboot_Click(object sender, EventArgs e)
        {
            string[] ReturnValue = ADB_Order("reboot");
            if (ReturnValue[1] != "")
            {
                MessageBox.Show(ReturnValue[1]);
            }
            else
            {
                MessageBox.Show("重启成功");
            }
        }
        /// <summary>
        /// 删除系统安全功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DelVecentek_Click(object sender, EventArgs e)
        {
            string backupApp = Application.StartupPath + "\\BackUpApp\\";
            string[] ReturnValue = ADB_Order("pull /system/app/VecentekApp "+ backupApp);//备份Vecentek安全软件

            if (!ReturnValue[0].Contains("No such file or directory"))
            {
                ReturnValue = ADB_Order(AdbShell_Password+"shell rm -rf /system/app/VecentekApp");
                if (ReturnValue[0] == ""&& ReturnValue[1] == "")
                {
                    
                    ADB_Order("exit");
                    MessageBox.Show("已成功删除设备保护");
                }
            }
            else
            {
                MessageBox.Show("该设备无需删除保护");
            }
        }
        /// <summary>
        /// 恢复系统安全功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ReVecentek_Click(object sender, EventArgs e)
        {
            string backupApp = Application.StartupPath + "\\BackUpApp\\";
            string[] ReturnValue = ADB_Order("push "+backupApp+"VecentekApp\\."+" /system/app/VecentekApp");//恢复Vecentek安全软件
            
            if (ReturnValue[0].Contains("adb:error"))
            {
                if (ReturnValue[0].Contains("Read-only file system"))
                    MessageBox.Show("请先解锁权限！！！");
                else if(ReturnValue[0].Contains("No such file or directory"))
                    MessageBox.Show("您的BackUpApp文件夹中缺少备份文件");
            }
            else
            {
                MessageBox.Show("已成功恢复设备安全保护");
            }
        }
        /// <summary>
        /// 打开系统WiFi调试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ONwifiDebug_Click(object sender, EventArgs e)
        {
            string[] ReturnValue = ADB_Order(AdbShell_Password + "shell setprop persist.adb.tcp.port 5555");//打开系统WiFi调试功能
            if (ReturnValue[0] == "" && ReturnValue[1] == "")
            {
                ADB_Order("exit");
                ADB_Order("reboot");
                MessageBox.Show("已打开设备WiFi调试功能，设备已自动重启");
            }
            else
            {
                MessageBox.Show("未能打开设备WiFi调试功能");
            }
        }
        /// <summary>
        /// 用于实时检测ADB设备连接状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            string[] devices = ADB_Order("devices");

            if (devices[0].Contains("\tdevice"))
            {
                string[] str = devices[0].Split('\n');
                str = str[1].Split('\t');
                label_DeviceName.Text = str[0];
                label_DeviceName.ForeColor = Color.Lime;

                if (str[0].Contains("emulator"))
                {
                    AdbShell_Password = "";//当前连接的设备为虚拟机
                }
                else
                {
                    AdbShell_Password = "adb36987|";//当前连接的设备为真实车机
                }

                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                        control.Enabled = true;
                }
            }
            else
            {
                label_DeviceName.Text = "未连接";
                label_DeviceName.ForeColor = Color.Red;

                foreach (Control control in this.Controls)
                {
                    if(control is Button)
                        control.Enabled = false;
                }
            }

            //查询系统剩余内存
            if (label_DeviceName.Text != "未连接")
            {
                string[] ReturnValue = ADB_Order(AdbShell_Password + "shell df -h /system");
                if (ReturnValue[0].Contains("Filesystem") || ReturnValue[0].Contains("\tSize"))
                {
                    ReturnValue = ReturnValue[0].Split('\n');//取出第二行
                    ReturnValue = ReturnValue[1].Split(new string[] { "/dev/root      " }, StringSplitOptions.None);//对第二行进行分解
                    ReturnValue = ReturnValue[1].Split(new string[] { "G  " }, StringSplitOptions.None);//对第二行取存储空间大小值
                    Memory_usage_rate.Text = (float.Parse(ReturnValue[0]) - float.Parse(ReturnValue[1])).ToString() + "G";
                }
            }
            else
            {
                Memory_usage_rate.Text = "";
            }
        }
        /// <summary>
        /// 文件源选框textbox的双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_FileSource_DoubleClick(object sender, EventArgs e)
        {
            if (comboBox_FileType.SelectedIndex == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_FileSource.Text = ofd.FileName;
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_FileSource.Text = fbd.SelectedPath+"\\.";
            }
        }
        /// <summary>
        /// 将文件或文件夹复制到设备的/system/priv-app目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MovePrivApp_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";
            
            if (textBox_FileSource.Text != "")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] {"\\","\\."}, StringSplitOptions.None);
                    Folder_Name=var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir /system/priv-app/" + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " /system/priv-app/" + Folder_Name);//复制文件或文件夹到/system/priv-app/

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的/system/priv-app路径下");
                    }
                }
                else
                {
                    MessageBox.Show(var2[0]);
                }
            }
            else
            {
                MessageBox.Show("请先输入起始文件路径");
            }
        }
        /// <summary>
        /// 将文件或文件夹复制到设备的/system/app目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MoveApp_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";

            if (textBox_FileSource.Text != "")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] { "\\", "\\." }, StringSplitOptions.None);
                    Folder_Name = var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir /system/app/" + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " /system/app/" + Folder_Name);//复制文件或文件夹到/system/app/

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的/system/app路径下");
                    }
                }
                else
                {
                    MessageBox.Show(var2[0]);
                }
            }
            else
            {
                MessageBox.Show("请先输入起始文件路径");
            }
        }
        /// <summary>
        /// 将文件或文件夹复制到设备的/data/app目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DataApp_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";

            if (textBox_FileSource.Text != "")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] { "\\", "\\." }, StringSplitOptions.None);
                    Folder_Name = var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir /data/app/" + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " /data/app/" + Folder_Name);//复制文件或文件夹到/data/app/

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的/data/app/路径下");
                    }
                }
                else
                {
                    MessageBox.Show(var2[0]);
                }
            }
            else
            {
                MessageBox.Show("请先输入起始文件路径");
            }
        }
        /// <summary>
        ///将文件或文件夹复制到设备的/system目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_system_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";

            if (textBox_FileSource.Text != "")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] { "\\", "\\." }, StringSplitOptions.None);
                    Folder_Name = var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir /system/" + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " /system/" + Folder_Name);//复制文件或文件夹到/system/

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的/system路径下");
                    }
                }
                else
                {
                    MessageBox.Show(var2[0]);
                }
            }
            else
            {
                MessageBox.Show("请先输入起始文件路径");
            }
        }
        /// <summary>
        /// 将文件或文件夹复制到设备的/sdcard目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sdcard_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";

            if (textBox_FileSource.Text != "")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] { "\\", "\\." }, StringSplitOptions.None);
                    Folder_Name = var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir /sdcard/" + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " /sdcard/" + Folder_Name);//复制文件或文件夹到/sdcard/

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的/sdcard路径下");
                    }
                }
                else
                {
                    MessageBox.Show(var2[0]);
                }
            }
            else
            {
                MessageBox.Show("请先输入起始文件路径");
            }
        }
        /// <summary>
        /// 将文件或文件夹复制到设备的自定义目录下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CustomTransfer_Click(object sender, EventArgs e)
        {
            string Folder_Name = "";

            if (textBox_FileSource.Text != ""&& textBox_CustomDest.Text!="")
            {
                if (textBox_FileSource.Text.Contains("\\."))
                {
                    string[] var1 = textBox_FileSource.Text.Split(new string[] { "\\", "\\." }, StringSplitOptions.None);
                    Folder_Name = var1[var1.Length - 2];
                }
                string[] var2 = ADB_Order(AdbShell_Password + "shell mkdir "+ textBox_CustomDest.Text + Folder_Name);//创建文件夹
                if (var2[0] == "")//创建文件夹成功
                {
                    string[] ReturnValue = ADB_Order("push " + textBox_FileSource.Text + " " + textBox_CustomDest.Text + Folder_Name);//复制文件或文件夹到自定义目录

                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        else if (ReturnValue[0].Contains("No such file or directory"))
                            MessageBox.Show("您的起始路径选择错误，请重新选择起始路径");
                    }
                    else
                    {
                        MessageBox.Show("已成功将文件复制到设备的%c路径下", textBox_CustomDest.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入正确的文件路径");
            }
        }

        private void textBox_ApkSource_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.apk";//限制文件格式
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox_ApkSource.Text = ofd.FileName;
        }

        private void button_InstallApk_Click(object sender, EventArgs e)
        {
            if (textBox_ApkSource.Text.Contains(".apk"))
            {
                string Apk_name = Path.GetFileNameWithoutExtension(textBox_ApkSource.Text);//获取文件名，不包含扩展名
                
                string Unzip_Folder = Application.StartupPath + "\\Unzip_Folder\\"+ Apk_name + "\\";
                if (!Directory.Exists(Unzip_Folder))
                {
                    Directory.CreateDirectory(Unzip_Folder);
                }
                if (!Unzip_Folder.EndsWith((Path.DirectorySeparatorChar).ToString()))
                    Unzip_Folder += Path.DirectorySeparatorChar;
                
                //复制APK文件到指定目录
                FileInfo file = new FileInfo(textBox_ApkSource.Text);
                file.CopyTo(Unzip_Folder + Apk_name+".apk", true);
                
                //复制解压后的.so文件到指定目录
                using (ZipArchive archive = ZipFile.OpenRead(textBox_ApkSource.Text))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".so", StringComparison.OrdinalIgnoreCase))
                        {
                            
                            if (entry.FullName.Contains("armeabi"))//有32位的.So文件
                            {
                                if (!Directory.Exists(Unzip_Folder+"lib\\arm"))
                                {
                                    Directory.CreateDirectory(Unzip_Folder + "lib\\arm");
                                }

                                string destinationPath = Path.GetFullPath(Unzip_Folder + "lib\\arm\\"+ entry.Name);
                                if (destinationPath.StartsWith(Unzip_Folder, StringComparison.Ordinal))
                                    entry.ExtractToFile(destinationPath);
                            }
                            if (entry.FullName.Contains("arm64-v8a"))//有64位的.So文件
                            {
                                if (!Directory.Exists(Unzip_Folder + "lib\\arm64"))
                                {
                                    Directory.CreateDirectory(Unzip_Folder + "lib\\arm64");
                                }

                                string destinationPath = Path.GetFullPath(Unzip_Folder + "lib\\arm64\\" + entry.Name);
                                if (destinationPath.StartsWith(Unzip_Folder, StringComparison.Ordinal))
                                    entry.ExtractToFile(destinationPath);
                            }
                        }
                    }
                }
                
                //将解压后的APK文件和.so安装到设备的/system/app目录下
                //步骤1：创建文件夹
                string[] var = ADB_Order(AdbShell_Password + "shell mkdir /system/app/" + Apk_name);//创建文件夹
                if (var[0] == "")//创建文件夹成功
                {
                    //步骤2：复制文件夹到设备/system/app/目录下
                    string[] ReturnValue = ADB_Order("push " + Unzip_Folder + "." + " /system/app/" + Apk_name);
                    if (ReturnValue[0].Contains("error"))
                    {
                        if (ReturnValue[0].Contains("Read-only file system"))
                            MessageBox.Show("请先解锁权限！！！");
                        //else if (ReturnValue[0].Contains("No such file or directory"))
                            //MessageBox.Show("您的BackUpApp文件夹中缺少备份文件");
                    }
                    else
                    {
                        MessageBox.Show("已成功安装"+ Apk_name+"，重启设备后生效");
                    }
                }
                else
                {
                    MessageBox.Show(var[0]);
                }
            }
            else
            {
                MessageBox.Show("您的APK文件选择有误，请重新双击左边文本框选择APK文件");
            }
            
            Directory.Delete(Application.StartupPath + "\\Unzip_Folder\\.", true);
        }
    }
}
