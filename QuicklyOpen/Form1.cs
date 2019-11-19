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
            string[] filename0 = @path.Split('/'); //将字符串按‘/’分割成数组
            filename = filename0[filename0.Length - 1]; //取数组的最后一位
            button.Text = hotkey + filename;
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
    }
}
