using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORdecryptor
{
    public static class StringConverter
    {
        public static string ToHex(char[] chars)
        {
            return chars.Select(c => ((int) c).ToString("x2")).Aggregate((r, v) => r += v);
        }

        public static string FromHex(string str)
        {
            var r = new StringBuilder(str.Length / 2);

            for (var i = 0; i < str.Length; i += 2)
            {
                var hex = str[i] + str[i + 1].ToString();
                r.Append((char) int.Parse(hex, NumberStyles.HexNumber));
            }

            return r.ToString();
        }
    }
}
