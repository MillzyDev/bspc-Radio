using System.Collections.Generic;
using System.Linq;

namespace Radio
{
    public static class DictionaryUtils
    {
        public static Dictionary<K, V> Merge<K, V>(params Dictionary<K, V>[] dictionaries)
        {
            return dictionaries.SelectMany(x => x)
                            .ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
