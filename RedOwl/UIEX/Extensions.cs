using System;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    public static class RedOwlUIElementsExtensions
    {
        internal static BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        public static IEnumerable<MethodInfo> GetMethods<T>(T instance)
        {
            foreach (MethodInfo info in instance.GetType().GetMethods(flags))
            {
                yield return info;
            }
        }

        public static IEnumerable<FieldInfo> GetFields<T>(T instance)
        {
            foreach (FieldInfo info in instance.GetType().GetFields(flags))
            {
                yield return info;
            }
        }
        
        private static Regex ResourceMatch = new Regex("[Rr]esources(.*)");
        
        public static string GetResourcesPath(this string self)
        {
            string output = "";
            Match match = ResourceMatch.Match(self);
            if (match.Success) output = match.Groups[1].Value.Substring(1);
            return output;
        }
        
        public static void Show(this VisualElement self, bool visiblity = true)
        {
            if (visiblity) self.RemoveFromClassList("hide");
            else self.AddToClassList("hide");
        }

        public static void ForFieldWithAttr<T, TAttr>(this T self, Action<FieldInfo, TAttr> callback, bool inhert = true) where TAttr : Attribute
        {
            foreach (var info in GetFields(self))
            {
                info.WithAttr<TAttr>((attr) => { callback(info, attr); }, inhert);
            }
        }

        public static void ForMethodWithAttr<T, TAttr>(this T self, Action<MethodInfo, TAttr> callback, bool inhert = true) where TAttr : Attribute
        {
            foreach (var info in GetMethods(self))
            {
                info.WithAttr<TAttr>((attr) => { callback(info, attr); }, inhert);
            }
        }

		public static void WithAttr<T>(this Type self, Action<T> callback, bool inherit = true) where T : Attribute
		{
			var attrs = self.GetCustomAttributes(inherit);
			foreach (var item in attrs)
			{
				T attr = item as T;
				if (attr != null) callback(attr);
			}
		}
		
		public static void WithAttr<T>(this MemberInfo self, Action<T> callback, bool inherit = true) where T : Attribute
		{
			var attrs = self.GetCustomAttributes(inherit);
			foreach (var item in attrs)
			{
				T attr = item as T;
				if (attr != null) callback(attr);
			}
		}
        
        public static void SetupOptions<T>(this DropdownMenu self, T initialValue, Action<T> callback, Func<T, bool> statusCallback) where T : Enum
        {
            foreach(T value in Enum.GetValues(typeof(T)))
            {
                self.AppendAction(value.ToString(),
                    a => { callback.Invoke(value); },
                    a => { return statusCallback.Invoke(value) ? DropdownMenu.MenuAction.StatusFlags.Checked : DropdownMenu.MenuAction.StatusFlags.Normal; });
            }
            callback.Invoke(initialValue);
        }
    }
}
