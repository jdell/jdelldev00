using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Extensions
{
    public static class StringExtension
    {
        public static string ToCorrectCase(this string text)
        {
            string separator = " ";
            string[] result = text.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = string.Format("{0}{1}", result[i].Substring(0, 1).ToUpper(), result[i].Substring(1, result[i].Length-1).ToLower());
            }
            return string.Join(separator, result);
        }
    }
}
