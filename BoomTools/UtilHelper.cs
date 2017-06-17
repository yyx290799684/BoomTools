using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomTools
{
    public class UtilHelper
    {
        /// <summary>
        /// 获取Guid
        /// N 32 位数字︰00000000000000000000000000000000 
        /// D 连字符分隔的 32 位数字︰连字符分隔的 32 位数字︰ 
        /// B 由连字符，括在大括号分隔的 32 位数字︰{00000000-0000-0000-0000-000000000000} 
        /// P 由括在括号中的连字符分隔的 32 位数字︰(00000000-0000-0000-0000-000000000000) 
        /// X 四个十六进制值括在大括号，其中第四个值是也括在大括号的八个十六进制值的子集︰{0x00000000、 0x0000、 0x0000，{0x00、 0x00 的、 0x00、 0x00 的、 0x00、 0x00 的、 0x00 的、 0x00}}
        /// </summary>
        /// <param name="specifier">N、D、B、P、X</param>
        /// <returns></returns>
        public static string GetGuid(string specifier)
        {
            string guid = Guid.NewGuid().ToString(specifier);
            return guid;
        }

    }
}
