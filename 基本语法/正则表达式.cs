using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// 正则表达式的练习
    /// </summary>
    public class RegexPractice
    {
        /// <summary>
        /// 验证邮箱
        /// </summary>
        public void EmailRegex()
        {
            Console.WriteLine("请输入一个邮箱地址：");
            string email = Console.ReadLine();

            Regex regex = new Regex(@"^(\w)+(\.\w+)*@(\w)+(\.\w+)+$");

            if (regex.IsMatch(email))
            {
                Console.WriteLine("邮件地址输入成功！");
            }
            else
            {
                Console.WriteLine("邮件地址输入失败！");
            }
            Console.ReadKey();
        }
    }
}
