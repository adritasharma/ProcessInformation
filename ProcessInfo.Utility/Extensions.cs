using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static string ToEnumDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}
