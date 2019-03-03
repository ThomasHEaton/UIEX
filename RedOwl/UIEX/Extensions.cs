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
		
		public static IEnumerable<T> Children<T>(this VisualElement self)
		{
			return self.Children().Cast<T>();
		}
		
		public static bool HasAttribute<T>(this Type self) where T : Attribute
		{
			var attribute = self.GetCustomAttributes(typeof(T), false).FirstOrDefault();
			return attribute != null;
		}
		
		public static bool TryGetAttribute<T>(this Type self, out T customAttribute) where T : Attribute
		{
			var attribute = self.GetCustomAttributes(typeof(T), false).FirstOrDefault();
			if (attribute == null) {
				customAttribute = null;
				return false;
			}
			customAttribute = (T)attribute;
			return true;
		}
		
		public static bool TryGetAttribute<T>(this MemberInfo self, out T customAttribute) where T : Attribute
        {
	        var attribute = self.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            if (attribute == null) {
                customAttribute = null;
                return false;
            }
            customAttribute = (T)attribute;
            return true;
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
		
		public static Vector2 GetPosition(this ITransform self)
		{
			return new Vector2(self.position.x, self.position.y);
		}
		
		public static Vector2Int ToFloor(this Vector2 self)
		{
			return new Vector2Int(Mathf.FloorToInt(self.x), Mathf.FloorToInt(self.y));
		}
	}
}