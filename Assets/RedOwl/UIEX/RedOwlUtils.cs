using System.Linq;
using System.Reflection;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
	public static class RedOwlUtils
	{
		public static void Setup<T>(T instance, VisualElement element)
		{
			RedOwlUtils.HandleUXMLAttribute(instance, element);
			RedOwlUtils.HandleUSSAttributes(instance, element);
			RedOwlUtils.HandleUSSClassAttributes(instance, element);
			RedOwlUtils.HandleUXMLReferenceAttributes(instance, element);
			RedOwlUtils.AddManipulators(instance, element);
			RedOwlUtils.RegisterUICallbacks(instance, element);
		}
		
		public static string GetAssetNamespace<T>(T instance)
		{
			return instance.GetType().Namespace.Replace(".", "/");
		}
		
		public static string GetAssetName<T>(T instance)
		{ 
			return instance.GetType().Name;
		}
		
		public static string GetUXMLPath<T>(T instance, string path)
		{
			return string.IsNullOrEmpty(path) ? string.Format("{0}/{1}Layout", GetAssetNamespace(instance), GetAssetName(instance)) : path;
		}
		
		public static string GetUSSPath<T>(T instance, string path)
		{ 
			return string.IsNullOrEmpty(path) ? string.Format("{0}/{1}Style", GetAssetNamespace(instance), GetAssetName(instance)) : path;
		}
		
		public static void HandleUXMLAttribute<T>(T instance, VisualElement element)
		{
			var attr = instance.GetType().GetCustomAttributes(typeof(UXMLAttribute), false).FirstOrDefault();
			if (attr != null) {
				string path = GetUXMLPath(instance, ((UXMLAttribute)attr).path);
				var layout = Resources.Load<VisualTreeAsset>(path);
				if (layout != null)
				{
					//Debug.LogFormat("Loading '{0}.uxml' for '{1}'", path, instance.GetType().Name);
					layout.CloneTree(element, null);
				}
			}
		}
		
		public static void HandleUSSAttributes<T>(T instance, VisualElement element)
		{
			foreach (var attr in instance.GetType().GetCustomAttributes(typeof(USSAttribute), true))
			{
				string path = GetUSSPath(element, ((USSAttribute)attr).path);
				//Debug.LogFormat("Adding '{0}.uss' to '{1}'", path, instance.GetType().Name);
				element.AddStyleSheetPath(path);
			}
		}
		
		public static void HandleUSSClassAttributes<T>(T instance, VisualElement element)
		{
			foreach (var attr in instance.GetType().GetCustomAttributes(typeof(USSClassAttribute), true))
			{
				foreach (var name in ((USSClassAttribute)attr).names)
				{
					//Debug.LogFormat("Adding USSClass '{0}' to '{1}'", name, instance.GetType().Name);
					element.AddToClassList(name);
				}
			}
		}
		
		public static void HandleUXMLReferenceAttributes<T>(T instance, VisualElement element)
		{
			foreach (FieldInfo info in instance.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
			{
				var attr = info.GetCustomAttributes(typeof(UXMLReferenceAttribute), true).FirstOrDefault();
				if (attr != null)
				{
					string uxmlName = ((UXMLReferenceAttribute)attr).Name;
					if (string.IsNullOrEmpty(uxmlName)) uxmlName = info.Name;
					//Debug.LogFormat("Populating 'UXMLReferenceAttribute' on '{0}.{1}' by looking for UXML name '{2}'", instance.GetType().Name, info.Name, uxmlName);
					info.SetValue(instance, element.Q(uxmlName));
				}
			}
		}
		
		public static void AddManipulators<T>(T instance, VisualElement element)
		{
			IOnMouse mouseHandler = instance as IOnMouse;
			if (mouseHandler != null)
			{
				//Debug.LogFormat("Adding 'MouseManipulator' to '{0}'", instance.GetType().Name);
				element.AddManipulator(new RedOwlMouseManipulator(mouseHandler.IsContentDragger, mouseHandler.MouseFilters.ToArray()));
			}
			
			IOnContextMenu contextMenuHandler = instance as IOnContextMenu;
			if (contextMenuHandler != null)
			{
				//Debug.LogFormat("Adding 'ContextualMenuManipulator' to '{0}'", instance.GetType().Name);
				element.AddManipulator(new ContextualMenuManipulator(contextMenuHandler.OnContextMenu));
			}
			
			IOnKeyboard keyboardHandler = instance as IOnKeyboard;
			if (keyboardHandler != null)
			{
				//Debug.LogFormat("Adding 'KeyboardManipulator' to '{0}'", instance.GetType().Name);
				element.AddManipulator(new RedOwlKeyboardManipulator(keyboardHandler.KeyboardFilters.ToArray()));
			}
			
			IOnWheel wheelHandler = instance as IOnWheel;
			IOnZoom zoomHandler = instance as IOnZoom;
			if (wheelHandler != null || zoomHandler != null)
			{
				//Debug.LogFormat("Adding 'WheelManipulator' to '{0}'", instance.GetType().Name);
				element.AddManipulator(new RedOwlWheelManipulator());
			}
		}
		
		public static void RegisterUICallbacks<T>(T instance, VisualElement element)
		{
			UICallbackAttribute attr;
			foreach (MethodInfo info in instance.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
			{
				var item = info.GetCustomAttributes(typeof(UICallbackAttribute), false).FirstOrDefault();
				if (item != null)
				{
					//Debug.LogFormat("Registering 'UICallbackAttribute' on '{0}.{1}'", instance.GetType().Name, info.Name);
					attr = (UICallbackAttribute)item;
					if (attr.OnlyOnce)
					{
						element.schedule.Execute(() => {info.Invoke(instance, null);}).StartingIn(attr.Interval);
					} else {
						element.schedule.Execute(() => {info.Invoke(instance, null);}).Every(attr.Interval);
					}
				}
			}
		}
	}
}
