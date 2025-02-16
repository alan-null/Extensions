using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool Empty<T>(this IEnumerable<T> dt)
        {
            return !dt.Any();
        }
    }
}
