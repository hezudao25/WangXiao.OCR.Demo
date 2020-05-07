
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangXiao.OCR.Common
{
    public static class Until
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string string2Json(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                string c = CharAt(s, i);
                switch (c)
                {
                    case "\"":
                        sb.Append("\\\"");
                        break;
                    case "\\":
                        sb.Append("\\\\");
                        break;
                    case "/":
                        sb.Append("\\/");
                        break;
                    case "\b":
                        sb.Append("\\b");
                        break;
                    case "\f":
                        sb.Append("\\f");
                        break;
                    case "\n":
                        sb.Append("\\n");
                        break;
                    case "\r":
                        sb.Append("\\r");
                        break;
                    case "\t":
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
        public static string CharAt(this string s, int index)
        {
            if ((index >= s.Length) || (index < 0))
                return "";
            return s.Substring(index, 1);
        }
    }
}
