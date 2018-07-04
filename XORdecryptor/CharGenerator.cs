using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XORdecryptor
{
    public static class CharGenerator
    {
        public static HashSet<char> FromRegex(string regex)
        {
            var r = new List<char>();

            for (var i = byte.MinValue; i < byte.MaxValue / 2; i++)
            {
                var c = (char) i;
                if (Regex.IsMatch(c.ToString(), regex))
                {
                    r.Add(c);
                }
            }

            return new HashSet<char>(r);
        }
    }
}
