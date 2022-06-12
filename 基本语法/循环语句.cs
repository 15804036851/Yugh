using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// 循环语句的练习
    /// </summary>
    public class Circulate
    {
        #region 九九乘法表
        /// <summary>
        /// 打印九九乘法表
        /// </summary>
        public void PrintTable()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("{0} * {1} = {2}\t", i, j, i * j);
                }
                Console.WriteLine();
            }
            Console.WriteLine("请按任意键继续");
            Console.ReadKey();
        }

        /// <summary>
        /// 打印九九乘法表(从小到大)
        /// </summary>
        public void PrintNormalTable()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("{0} * {1} = {2}\t", j, i, i * j);
                }
                Console.WriteLine();
            }
            Console.WriteLine("请按任意键继续");
            Console.ReadKey();
        }
        #endregion

        #region 菱形
        /// <summary>
        /// 打印菱形(5*5)
        /// </summary>
        public void PrintGraph()
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 2; i > 0; i--)
            {
                for (int j = 1; j <= 3 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine("请按任意键继续");
            Console.ReadKey();
        }

        /// <summary>
        /// 打印菱形(99*99)
        /// </summary>
        public void PrintGraphNew()
        {
            for (int i = 1; i <= 50; i++)
            {
                for (int j = 1; j <= 50 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 49; i > 0; i--)
            {
                for (int j = 1; j <= 50 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine("请按任意键继续");
            Console.ReadKey();
        }
        #endregion

        #region 偶数乘积计算
        /// <summary>
        /// 计算1-10中所有偶数的乘积
        /// </summary>
        public void CalculateNum()
        {
            // 计算结果
            int num = 1;

            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    num *= i;
                }
            }
            Console.WriteLine("1-10中所有偶数的乘积：{0}", num.ToString());
            Console.WriteLine("请按任意键继续");
            Console.ReadKey();
        }
        #endregion

        #region 斐波那契数列
        /// <summary>
        /// 输出斐波那契数列（第一列是1，第二列是1，以后各项都是前两项的和）
        /// </summary>
        public void PrintArray()
        {
            Console.WriteLine("请指定斐波那契数列的项数："); 
            string input = Console.ReadLine();
            int num;
            if (int.TryParse(input, out num))
            {
                // 方法递归的方式
                for (int i = 1; i <= num; i++)
                {
                    Console.WriteLine("斐波那契数列第{0}列：{1}", i, Fibonacci(i).ToString());
                }

                if (num > 3)
                {
                    int[] array = new int[num];
                    
                    array[0] = 1;
                    array[1] = 1;

                    for (int i = 2; i < num; i++)
                    {
                        array[i] = array[i - 2] + array[i - 1];
                    }

                    Console.WriteLine("斐波那契数列前{0}列：{1}", num, string.Join("、", array));
                    Console.ReadKey();
                }
                else
                {
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("斐波那契数列前{0}列：1", num);
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("斐波那契数列前{0}列：1、1", num);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("输入值不正确，只能输入0以上整数");
                            PrintArray();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("输入值不正确，只能输入0以上整数");
                PrintArray();
            }
        }

        /// <summary>
        /// 斐波那契数列
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Fibonacci(int num)
        {
            if (num == 1 || num == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(num - 2) + Fibonacci(num - 1);
            }
        }
        #endregion
    }
}
