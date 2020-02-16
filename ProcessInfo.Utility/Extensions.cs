using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.Utility
{
    public static class Extensions
    {
        public static object GetProperty<T>(this T obj, string name) where T : class
        {
            Type t = typeof(T);
            return t.GetProperty(name).GetValue(obj, null);
        }

        public static string TrimSpace(this string value)
        {
            if (value != null)
            {
                
                    return value.Trim();
            }
            return null;
        }
    }
}
