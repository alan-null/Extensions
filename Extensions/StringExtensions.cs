using static System.String;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool NotNullOrWhiteSpace(this string str)
        {
            return !IsNullOrWhiteSpace(str);
        }
    }
}
