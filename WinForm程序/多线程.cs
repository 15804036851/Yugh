using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// 多线程编程的练习
    /// </summary>
    public class MultiThreadPractice
    {
        /// <summary>
        /// 开启线程
        /// </summary>
        public void RunThread()
        {
            TestLock tl = new TestLock();
            TestMonitor tm = new TestMonitor();
            TestMutex tmu = new TestMutex();

            for (int i = 0; i < 3; i++)
            {
                //Thread thLock = new Thread(tl.TestRun);
                //thLock.Start();
                //thLock.Join();

                //Thread thMonitor = new Thread(tm.TestRun);
                //thMonitor.Start();

                Thread thMutex = new Thread(tmu.TestRun);
                thMutex.Start();

            }
            Console.ReadKey();
        }
    }

    /// <summary>
    /// lock的使用
    /// </summary>
    class TestLock
    {
        private Object obj = new Object();
        private int i = 0;

        /// <summary>
        /// 线程同步
        /// </summary>
        public void TestRun()
        {
            lock (obj)
            {
                Console.WriteLine("i的初始值为：" + i.ToString());
                Thread.Sleep(1000);
                i++;
                Console.WriteLine("i的自增值为：" + i.ToString());
            }
        }
    }

    /// <summary>
    /// Monitor的使用
    /// </summary>
    class TestMonitor
    {
        // 定义同步对象
        private Object obj = new Object();
        private int i = 0;

        /// <summary>
        /// 线程同步
        /// </summary>
        public void TestRun()
        {
            // 在同步对象上获取排他锁
            Monitor.Enter(obj);
            Console.WriteLine("i的初始值为：" + i.ToString());
            Thread.Sleep(1000);
            i++;
            Console.WriteLine("i的值为：" + i.ToString());
            // 释放同步对象上的排他锁
            Monitor.Exit(obj);
        }
    }

    /// <summary>
    /// Mutex的使用
    /// </summary>
    class TestMutex
    {
        Mutex mutex = new Mutex(false);
        private int i = 0;

        /// <summary>
        /// 线程同步
        /// </summary>
        public void TestRun()
        {
            while (true)
            {
                // 阻止线程，等待WaitHandle收到信号
                if (mutex.WaitOne())
                {
                    break;
                }
            }

            Console.WriteLine("i的初始值为：" + i.ToString());
            Thread.Sleep(1000);
            i++;
            Console.WriteLine("i的值为：" + i.ToString());
            // 执行完释放资源
            mutex.ReleaseMutex();
        }
    }
}
