using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoomTools
{
    public class RegexHelper
    {
        /// <summary>
        /// 是否为中文
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsChinese(string content)
        {
            Regex reg = new Regex(@"^[\u4e00-\u9fa5]{0,}$");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为邮箱有效格式
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsNum(string content)
        {
            Regex reg = new Regex(@"^[0-9]*$");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="content"></param>
        /// <param name="m">最低位数</param>
        /// <param name="n">最高位数</param>
        /// <returns></returns>
        public static bool IsNum(string content, int m, int n)
        {
            Regex reg = new Regex(string.Format(@"^\d{{0},{1}}$", m, n));
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为英文和数字
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsENorNumChar(string content)
        {
            Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为英文组成的字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsENString(string content)
        {
            Regex reg = new Regex(@"^[A-Za-z]+$");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为身份证号码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsidNum(string content)
        {
            Regex reg = new Regex(@"^\d{15}|\d{18}$");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为国内固定电话号码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsChinesePhone(string content)
        {
            Regex reg = new Regex(@"\d{3}-\d{8}|\d{4}-\d{7}");
            return reg.IsMatch(content);
        }

        /// <summary>
        /// 是否为QQ号码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsQQ(string content)
        {
            Regex reg = new Regex(@"[1-9][0-9]{4,}");
            return reg.IsMatch(content);
        }


    }
}
