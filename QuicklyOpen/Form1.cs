using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;//打开外部程序用
using System.Runtime.InteropServices;//全局热键用

namespace QuicklyOpen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 路径变量
        /// </summary>
        string path, path1, path2, path3, path4, path5, path6, path7, path8, path9, path10, path11, path12,
               filename, filename1, filename2, filename3, filename4, filename5, filename6,
               filename7, filename8, filename9, filename10, filename11, filename12;

        int locationX, locationY;
        
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //读取保存的路径信息
            path1 = Settings.Default.path1;
            path2 = Settings.Default.path2;
            path3 = Settings.Default.path3;
            path4 = Settings.Default.path4;
            path5 = Settings.Default.path5;
            path6 = Settings.Default.path6;
            path7 = Settings.Default.path7;
            path8 = Settings.Default.path8;
            path9 = Settings.Default.path9;
            path10 = Settings.Default.path10;
            path11 = Settings.Default.path11;
            path12 = Settings.Default.path12;
            filename1 = Settings.Default.filename1;
            filename2 = Settings.Default.filename2;
            filename3 = Settings.Default.filename3;
            filename4 = Settings.Default.filename4;
            filename5 = Settings.Default.filename5;
            filename6 = Settings.Default.filename6;
            filename7 = Settings.Default.filename7;
            filename8 = Settings.Default.filename8;
            filename9 = Settings.Default.filename9;
            filename10 = Settings.Default.filename10;
            filename11 = Settings.Default.filename11;
            filename12 = Settings.Default.filename12;

            //从上次关闭位置启动窗体
            locationX = Settings.Default.locationX;
            locationY = Settings.Default.locationY;
            //this.Location = new Point(locationX, locationY);//可以转换成 Left 、Top.
            this.Top = locationY;
            this.Left = locationX;
        }

        /// <summary>
        /// 窗体即将关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存路径信息
            Settings.Default.path1 = path1;
            Settings.Default.path2 = path2;
            Settings.Default.path3 = path3;
            Settings.Default.path4 = path4;
            Settings.Default.path5 = path5;
            Settings.Default.path6 = path6;
            Settings.Default.path7 = path7;
            Settings.Default.path8 = path8;
            Settings.Default.path9 = path9;
            Settings.Default.path10 = path10;
            Settings.Default.path11 = path11;
            Settings.Default.path12 = path12;
            Settings.Default.filename1 = filename1;
            Settings.Default.filename2 = filename2;
            Settings.Default.filename3 = filename3;
            Settings.Default.filename4 = filename4;
            Settings.Default.filename5 = filename5;
            Settings.Default.filename6 = filename6;
            Settings.Default.filename7 = filename7;
            Settings.Default.filename8 = filename8;
            Settings.Default.filename9 = filename9;
            Settings.Default.filename10 = filename10;
            Settings.Default.filename11 = filename11;
            Settings.Default.filename12 = filename12;

            //保存窗体位置信息
            Settings.Default.locationX = this.Location.X;
            Settings.Default.locationY = this.Location.Y;

            Settings.Default.Save();
        }

        #region button事件设置（左键）
        private void ErrorCheck(string path0)
        {
            if ((path0 != null) && (path0 != ""))
            {
                Process.Start(path0);
            }
            else
            {
                MessageBox.Show("您还未设置路径");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ErrorCheck(path1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ErrorCheck(path2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ErrorCheck(path3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ErrorCheck(path4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ErrorCheck(path5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ErrorCheck(path6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ErrorCheck(path7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ErrorCheck(path8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ErrorCheck(path9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ErrorCheck(path10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ErrorCheck(path11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ErrorCheck(path12);
        }
        #endregion

        #region button绑定的contextMenuStrip事件设置（鼠标右键）
        private string PathSetting(string path, string filename, Button button, string hotkey)
        {
            path = Selselection() ?? path;//加判断防止打开选择路径对话框，未选择路径，而导致之前选择的路径被空值覆盖
            //path1 = @path1.Replace(@"\", "/"); //加@防止字符串中的转义字符被处理；替换字符串中的字符。
            path = (path != null) ? @path.Replace(@"\", "/") : null;//加判断防止path1为空时报错
            if (path!=null)
            {
                string[] filename0 = @path.Split('/'); //将字符串按‘/’分割成数组
                filename = filename0[filename0.Length - 1]; //取数组的最后一位
                button.Text = hotkey + filename;
            }
            return filename;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            filename1 = PathSetting(path1, filename1, button1, "①");
            path1 = path;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            filename2 = PathSetting(path2, filename2, button2, "②");
            path2 = path;
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {
            filename3 = PathSetting(path3, filename3, button3, "③");
            path3 = path;
        }

        private void contextMenuStrip4_Opening(object sender, CancelEventArgs e)
        {
            filename4 = PathSetting(path4, filename4, button4, "④");
            path4 = path;
        }

        private void contextMenuStrip5_Opening(object sender, CancelEventArgs e)
        {
            filename5 = PathSetting(path5, filename5, button5, "⑤");
            path5 = path;
        }

        private void contextMenuStrip6_Opening(object sender, CancelEventArgs e)
        {
            filename6 = PathSetting(path6, filename6, button6, "⑥");
            path6 = path;
        }

        private void contextMenuStrip7_Opening(object sender, CancelEventArgs e)
        {
            filename7 = PathSetting(path7, filename7, button7, "⑦");
            path7 = path;
        }

        private void contextMenuStrip8_Opening(object sender, CancelEventArgs e)
        {
            filename8 = PathSetting(path8, filename8, button8, "⑧");
            path8 = path;
        }

        private void contextMenuStrip9_Opening(object sender, CancelEventArgs e)
        {
            filename9 = PathSetting(path9, filename9, button9, "⑨");
            path9 = path;
        }

        private void contextMenuStrip10_Opening(object sender, CancelEventArgs e)
        {
            filename10 = PathSetting(path10, filename10, button10, "Ⓐ");
            path10 = path;
        }

        private void contextMenuStrip11_Opening(object sender, CancelEventArgs e)
        {
            filename11 = PathSetting(path11, filename11, button11, "Ⓑ");
            path11 = path;
        }

        private void contextMenuStrip12_Opening(object sender, CancelEventArgs e)
        {
            filename12 = PathSetting(path12, filename12, button12, "Ⓒ");
            path12 = path;
        }
        #endregion

        #region 鼠标移动到按钮上时，预览已经设置好的路径
        ToolTip toolTip;
        private void Preview(ToolTip toolTip, string pormpt, Button button)
        {
            // 创建the ToolTip 
            toolTip = new ToolTip();

            // 设置显示样式
            toolTip.AutoPopDelay = 10000;//提示信息的可见时间
            toolTip.InitialDelay = 500;//事件触发多久后出现提示
            toolTip.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip.SetToolTip(button, pormpt);//设置提示按钮和提示内容
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path1, button1);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path2, button2);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path3, button3);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path4, button4);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path5, button5);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path6, button6);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path7, button7);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path8, button8);
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path9, button9);
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path10, button10);
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path11, button11);
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            Preview(toolTip, path12, button12);
        }
        #endregion

        #region 设置文件或文件夹路径
        private string Selselection()
        {
            //弹出消息框，并判断选择的是“是”还是“否”
            DialogResult ret = MessageBox.Show("是：设定文件路径\n否：设定文件夹路径", "请选择设定文件路径还是文件夹路径", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (ret == DialogResult.Yes)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();//选择文件
                fileDialog.Multiselect = true; //该值确定是否可以选择多个文件
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*.*)|*.*";
                /*
                 * Filter 属性 赋值为一字符串 用于过滤文件类型;
                 *字符串说明如下：
                 *‘|’分割的两个，一个是注释，一个是真的Filter，显示出来的是那个注释。如果要一次显示多中类型的文件，用分号分开。
                 *如：
                 *Open1.Filter="图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";
                 *则过滤的文件类型为 “|”号  右边的 *.jpg;*.gif;*.bmp 三种类型文件，在OpenDialog/SaveDialog中显示给用户看的文件类型字符串则是 ：“|”号  左边的 图片文件(*.jpg,*.gif,*.bmp)。
                 *再如：
                 *Open1.Filter="图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
                 */
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;
                    path = file;
                    //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ret == DialogResult.No)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();//选择文件夹
                dialog.Description = "请选择文件夹路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string foldPath = dialog.SelectedPath;
                    path = foldPath;
                    //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //
            }
            return path;
        }
        #endregion

        #region 设置全局热键
        public class AppHotKey
        {
            [DllImport("kernel32.dll")]
            public static extern uint GetLastError();
            //如果函数执行成功，返回值不为0。
            //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
                IntPtr hWnd,                //要定义热键的窗口的句柄
                int id,                     //定义热键ID（不能与其它ID重复）          
                KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
                Keys vk                     //定义热键的内容
                );

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,                //要取消热键的窗口的句柄
                int id                      //要取消热键的ID
                );

            //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
            /// <summary>
            /// 注册热键
            /// </summary>
            /// <param name="hwnd">窗口句柄</param>
            /// <param name="hotKey_id">热键ID</param>
            /// <param name="keyModifiers">组合键</param>
            /// <param name="key">热键</param>
            public static void RegKey(IntPtr hwnd, int hotKey_id, KeyModifiers keyModifiers, Keys key)
            {
                try
                {
                    if (!RegisterHotKey(hwnd, hotKey_id, keyModifiers, key))
                    {
                        if (Marshal.GetLastWin32Error() == 1409) { MessageBox.Show("热键被占用 ！"); }
                        else
                        {
                            MessageBox.Show("注册热键失败！");
                        }
                    }
                }
                catch (Exception) { }
            }
            /// <summary>
            /// 注销热键
            /// </summary>
            /// <param name="hwnd">窗口句柄</param>
            /// <param name="hotKey_id">热键ID</param>
            public static void UnRegKey(IntPtr hwnd, int hotKey_id)
            {
                //注销Id号为hotKey_id的热键设定
                UnregisterHotKey(hwnd, hotKey_id);
            }
        }
        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        private const int WM_CREATE = 0x1; //窗口消息-创建
        private const int WM_DESTROY = 0x2; //窗口消息-销毁
        private const int Space = 0x3572; //热键ID
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID
                    switch (m.WParam.ToInt32())
                    {
                        case Space: //热键ID
                            this.Visible = true;
                            this.WindowState = FormWindowState.Normal;//正常大小
                            this.Activate(); //激活窗体
                            //MessageBox.Show("我按了Control +Shift +Alt +S");//设置按下热键后的动作
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.Ctrl, Keys.Space); //热键为Ctrl+空格
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    AppHotKey.UnRegKey(Handle, Space); //销毁热键
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 设置按钮快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*
            // 按快捷键Ctrl+S执行按钮的点击事件方法
            if (keyData == (Keys)Shortcut.CtrlS)
            {
                button1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData); // 其他键按默认处理　
            */
            switch (keyData)
            {
                case Keys.D1:
                    //焦点定位到控件button_num_0上，即0键上
                    button1.Focus();
                    //执行按钮点击操作
                    button1.PerformClick();
                    return true;
                case Keys.D2:
                    button2.Focus();
                    button2.PerformClick();
                    return true;
                case Keys.D3:
                    button3.Focus();
                    button3.PerformClick();
                    return true;
                case Keys.D4:
                    button4.Focus();
                    button4.PerformClick();
                    return true;
                case Keys.D5:
                    button5.Focus();
                    button5.PerformClick();
                    return true;
                case Keys.D6:
                    button6.Focus();
                    button6.PerformClick();
                    return true;
                case Keys.D7:
                    button7.Focus();
                    button7.PerformClick();
                    return true;
                case Keys.D8:
                    button8.Focus();
                    button8.PerformClick();
                    return true;
                case Keys.D9:
                    button9.Focus();
                    button9.PerformClick();
                    return true;
                case Keys.A:
                    button10.Focus();
                    button10.PerformClick();
                    return true;
                case Keys.B:
                    button11.Focus();
                    button11.PerformClick();
                    return true;
                case Keys.C:
                    button12.Focus();
                    button12.PerformClick();
                    return true;
                case Keys.Space://最小化窗体快捷键（空格）
                    //this.WindowState = FormWindowState.Minimized;//最小化到任务栏
                    //this.notifyIcon1.Visible = true;
                    this.Hide();//最小化到托盘
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
