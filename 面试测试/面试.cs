using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// 面试题测验
    /// </summary>
    public class InterviewTest
    {
        /// <summary>
        /// 反向输出字符串
        /// </summary>
        public void PrintString()
        {
            string s = "I love China";

            string[] ss = s.Split(' ');

            for (int i = ss.Length - 1; i >= 0; i--)
            {
                Console.Write(ss[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// 每3个一组输出数组
        /// </summary>
        public void PrintArray()
        {
            string[] array = { "a", "b", "c", "d", "e", "f" , "g"};
            string[] temp = new string[3];
            List<string[]> list = new List<string[]>();

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 && i % 3 == 0)
                {
                    list.Add(temp);
                    temp = new string[3];
                    temp[i % 3] = array[i];
                }
                else
                {
                    temp[i % 3] = array[i];
                }
            }

            if (temp.Length > 0)
            {
                list.Add(temp);
            }

            foreach (string[] a in list)
            {
                Console.WriteLine(string.Join(" ", a));
            }

            Console.ReadKey();
        }

        /// <summary>
        ///  找出数组中最接近10的数组元素
        /// </summary>
        public void FindNumber()
        {
            int[] array = new int[5] { 1, 5, 6, 9, 15 };
            int temp = Math.Abs(array[0] - 10);
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int value = Math.Abs(array[i] - 10);

                if (value < temp)
                {
                    temp = value;
                    result = i; 
                }
            }

            Console.WriteLine(array[result]);
            Console.ReadKey();
        }

        /// <summary>
        /// 找出数组中最接近10的数组元素（二分法）
        /// </summary>
        public void FindNumberAnother()
        {
            int[] arr = new int[5] { 1, 5, 6, 9, 15 };
            Array.Sort(arr);
            int length = arr.Length;
            if (arr[length - 1] <= 10)
            {
                Console.WriteLine(arr[length - 1]);
            }
            else if (arr[0] >= 10)
            {
                Console.WriteLine(arr[0]);
            }
            else
            {
                int min = 0;
                int max = arr.Length - 1;
                int index = (min + max) / 2;

                while (Math.Abs(max - min) > 1)
                {
                    if (arr[index] == 10)
                    {
                        Console.WriteLine(arr[index]);
                        break;
                    }
                    else if (arr[index] < 10)
                    {
                        min = index;
                    }
                    else
                    {
                        max = index;
                    }

                    index = (min + max) / 2;
                }

                if (Math.Abs(arr[min] - 10) < Math.Abs(arr[max] - 10))
                {
                    Console.WriteLine(arr[min]);
                }
                else
                {
                    Console.WriteLine(arr[max]);
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        ///  找出数组中最接近10的数组元素(Linq)
        /// </summary>
        public void FindNumberByLinq()
        {
            int[] arr = new int[] { 1, 5, 6, 9, 15, 10, 11, 13 };

            var result = from a in arr.AsEnumerable() select new { item = Math.Abs(a - 10), itemValue = a };
            int value = result.OrderBy(r => r.item).First().itemValue;
            Console.WriteLine(value);
            Console.ReadKey();
        }

        /// <summary>
        /// 不使用类库将string转成int（不考虑异常情况）
        /// </summary>
        public int StringToInt(string input)
        {
            int result = 0;
            char[] nums = input.ToCharArray();

            int count = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == 0 && nums[0] == '-')
                {
                    result *= -1;
                    break;
                }

                int value = nums[i] - '0';

                int temp = (int)Math.Pow(10, count);
                result += value * temp;
                count++;
            }
            return result;

        }

        /// <summary>
        /// 词频统计
        /// </summary>
        public void WordCount()
        {
            StringBuilder textStr = new StringBuilder();

            StreamReader stream = new StreamReader(@"D:\词频统计文件.txt");
            while (!stream.EndOfStream)
            {
                string str = stream.ReadLine();
                textStr.AppendLine(str);
            }

            Dictionary<string, int> result = new Dictionary<string, int>();

            string targetStr = textStr.ToString();
            string[] words = targetStr.Split(' ', '\r', '\n', ',', '.', ';', '!');
            //string[] words = Regex.Split(targetStr, @"\s+|\n+|!");

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result.Add(word, 1);
                }
            }

            result.AsEnumerable().OrderByDescending(r => r.Value).ToList().ForEach(r => Console.WriteLine(r.Key + ":" + r.Value));
            Console.WriteLine(textStr.ToString());
            Console.ReadKey();
        }

        #region 使用yield输出斐波那契数列
        public void Print()
        {
            foreach (int item in GetList(10))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public IEnumerable<int> GetList(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return GetValue(i);
            }
        }

        public int GetValue(int index)
        {
            if (index == 1 || index == 2)
            {
                return 1;
            }

            return GetValue(index - 2) + GetValue(index - 1);
        }
        #endregion
    }
}
