using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class LinqExtensions
    {
        public static string Join(this IEnumerable<string> _this, string separator)
        {
            return String.Join(separator, _this);
        }

        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> _this)
        {
            return from row in _this
                   from col in row.Select((x, i) => new KeyValuePair<int, T>(i, x))
                   group col.Value by col.Key into c
                   select c as IEnumerable<T>;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> collection, Func<T, T, bool> extractor)
        {
            return collection.Distinct(new LambdaEqualityComparer<T>(extractor));
        }

        public static bool AddUnique<T>(this List<T> collection, T item, Func<T, object> propertyExtractor)
        {
            object prop = propertyExtractor(item);
            if (collection.Any(i => propertyExtractor(i).Equals(prop)))
            {
                return false;
            }
            collection.Add(item);
            return true;
        }

        public static bool AddUnique<T>(this List<T> collection, T item)
        {
            return collection.AddUnique(item, arg => arg);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            return enumerable.OrderBy(i => rand.Next());
        }
    }

    internal class LambdaEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalsFunc;
        private readonly Func<T, int> _getHashCodeFunc;

        public LambdaEqualityComparer(Func<T, T, bool> equalsFunc, Func<T, int> getHashCodeFunc = null)
        {
            _equalsFunc = equalsFunc;
            if (getHashCodeFunc != null)
            {
                _getHashCodeFunc = getHashCodeFunc;
            }
            else
            {
                _getHashCodeFunc = arg => 0;
            }
        }
        public bool Equals(T x, T y)
        {
            return _equalsFunc(x, y);
        }

        public int GetHashCode(T obj)
        {
            if (_getHashCodeFunc == null)
            {
                return obj.GetHashCode();
            }
            return _getHashCodeFunc(obj);
        }
    }
}