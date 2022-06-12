using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformPractice
{
    public partial class PracticeForm : Form
    {
        public PracticeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载显示线程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PracticeForm_Load(object sender, EventArgs e)
        {
            string strInfo = string.Empty;
            Thread t = new Thread(new ThreadStart(ThreadFunction));
            t.Start();

            // 获取线程信息
            strInfo = "新建子线程唯一标识符：" + t.ManagedThreadId;
            strInfo += "\n新建子线程名称：" + t.Name;
            strInfo += "\n新建子线程状态：" + t.ThreadState.ToString();
            strInfo += "\n新建子线程优先级：" + t.Priority.ToString();
            strInfo += "\n新建子线程是否为后台线程：" + t.IsBackground;

            Thread.Sleep(500);

            t.Abort("新建子线程退出");
            t.Join();
            MessageBox.Show("新建子线程执行结束", "新建子线程");

            // 显示线程信息
            rtbInfo.Text = strInfo;
        }

        /// <summary>
        /// 程序开始
        /// </summary>
        public void ThreadFunction()
        {
            MessageBox.Show("新建子线程开始执行", "新建子线程");
        }
    }
}
