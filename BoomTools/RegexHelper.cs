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
    }
}
