using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPractice;

namespace Practice
{
    /// <summary>
    /// C#实例练习
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Test();

            #region 窗体启动
            //// 用于启动应用程序中可视的样式
            //Application.EnableVisualStyles();
            //// 设置默认属性
            //Application.SetCompatibleTextRenderingDefault(false);
            //// 设置启动窗体
            //Application.Run(new PracticeForm());
            #endregion
        }
    }
}
