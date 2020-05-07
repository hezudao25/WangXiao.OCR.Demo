using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangXiao.OCR.Common
{
    public class CustomCache
    {
        private static Dictionary<string, object> CustomCacheDictionary = new Dictionary<string, object>();

        public static void add(string key, object value)
        {
            CustomCacheDictionary.Add(key, value);

        }

        public static T Get<T>(string key)
        {
            return (T)CustomCacheDictionary[key];
        }

        public static bool Exists(string key)
        {
            return CustomCacheDictionary.ContainsKey(key);
        }
    }
}
