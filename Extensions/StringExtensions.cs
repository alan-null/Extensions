using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using static System.String;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool NotNullOrWhiteSpace(this string str)
        {
            return !IsNullOrWhiteSpace(str);
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !IsNullOrEmpty(str);
        }

        public static bool HasValue(this string input)
        {
            if (input == null)
            {
                return false;
            }
            if (input.Trim() == Empty)
            {
                return false;
            }
            return true;
        }

        public static string RemoveDiacritics(this string s)
        {
            string asciiEquivalents = Encoding.ASCII.GetString(
                Encoding.GetEncoding("Cyrillic").GetBytes(s)
            );

            return asciiEquivalents;
        }

        public static NameValueCollection ParseQueryString(this string str)
        {
            return HttpUtility.ParseQueryString(str);
        }

        public static string ToUpperFirst(this string str)
        {
            if (IsNullOrEmpty(str))
            {
                return Empty;
            }
            char[] array = str.ToCharArray();
            array[0] = Char.ToUpper(array[0]);
            return new string(array);
        }
    }
}
