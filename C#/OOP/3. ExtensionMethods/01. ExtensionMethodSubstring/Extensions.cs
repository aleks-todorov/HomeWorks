using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExtensionMethodSubstring
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index)
        {
            string result = sb.ToString();
            result = result.Substring(index);
            sb.Clear();
            sb.Append(result);
            return sb;
        }
    }
}
