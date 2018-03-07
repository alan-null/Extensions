using System.Collections.Generic;

namespace Extensions
{
    public static class DictionaryExtensions
    {
        public static TVal GetValueSafe<TKey, TVal>(this Dictionary<TKey, TVal> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(TVal);
        }
    }
}
