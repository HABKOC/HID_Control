using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HID_Control
{
    public partial class HID_Ctrl : Form
    {
        string HID_Search = "pnputil /enum-devices /instanceid \"HID\\VID_1FF7&PID_0013&COL04\\7&13C5B80E&0&0003\"";
        string HID_Enable = "pnputil /enable-device \"HID\\VID_1FF7&PID_0013&COL04\\7&13C5B80E&0&0003\"";
        string HID_Disable = "pnputil /disable-device \"HID\\VID_1FF7&PID_0013&COL04\\7&13C5B80E&0&0003\"";

        public HID_Ctrl()
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
        private void HID_Ctrl_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnhor();
        }

        private void HID_Ctrl_Load(object sender, EventArgs e)
        {
            this.timer1.Start();

            string Search_Log = CMD_Order(HID_Search);
            if (Search_Log.Contains("已启动"))
            {
                label_Status.Text = "已启动";
                label_Status.ForeColor = Color.Green;
            }
            else if (Search_Log.Contains("已禁用"))
            {
                label_Status.Text = "已禁用";
                label_Status.ForeColor = Color.Yellow;
            }
            else
            {
                MessageBox.Show("该软件不适用于该系统，请检查驱动配置！！！");
                Application.Exit();
            }
        }

        private string CMD_Order(string str)
        { 
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            return output;
        }

        private void button_Switch_Click(object sender, EventArgs e)
        {
            if (label_Status.Text == "已启动")
            {
                string Disable_Log = CMD_Order(HID_Disable);
                if (Disable_Log.Contains("已成功禁用设备"))
                {
                    label_Status.Text = "已禁用";
                    label_Status.ForeColor = Color.Yellow;
                }
                else if(Disable_Log.Contains("拒绝访问"))
                {
                    MessageBox.Show("请以管理员权限运行该程序！！！");
                    Application.Exit();
                }
            }
            else
            {
                string Enable_Log = CMD_Order(HID_Enable);
                if (Enable_Log.Contains("已成功启用设备"))
                {
                    label_Status.Text = "已启动";
                    label_Status.ForeColor = Color.Green;
                }
                else if (Enable_Log.Contains("拒绝访问"))
                {
                    MessageBox.Show("请以管理员权限运行该程序！！！");
                    Application.Exit();
                }
            }
        }
    }
}
