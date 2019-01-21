using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental;
using UnityEditor.Experimental.UIElements;

namespace RedOwl.Editor
{
	public abstract class RedOwlEditor : UIElementsEditor
	{
		protected VisualElement Root { get; set; }
		
		private string GetAssetNamespace() { return this.GetType().Namespace.Replace(".", "/"); }
		private string GetAssetName() { return this.GetType().Name; }
		public virtual string GetWindowTitle() { return GetAssetName(); }
		protected virtual string GetUXMLPath() { return string.Format("{0}/{1}Layout", GetAssetNamespace(), GetAssetName()); }
		protected virtual string GetUSSPath() { return string.Format("{0}/{1}Style", GetAssetNamespace(), GetAssetName()); }
		
		public override VisualElement CreateInspectorGUI()
		{
			var layout = Resources.Load<VisualTreeAsset>(GetUXMLPath());
			if (layout == null) return new VisualElement();
			Root = layout.CloneTree(null);
			Root.AddStyleSheetPath("RedOwl/Editor/Styles");
			if (this.GetType().HasAttribute<USSAttribute>()) Root.AddStyleSheetPath(GetUSSPath());
			ParseUXMLReferences();
			RegisterUpdateCallbacks();
			return Root;
		}
		
		private void ParseUXMLReferences()
		{
			UXMLReferenceAttribute attr;
			foreach (FieldInfo info in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
			{
				if (info.TryGetAttribute(out attr))
				{
					info.SetValue(this, Root.Q(attr.Name));
				}
			}
		}
		
		private void RegisterUpdateCallbacks()
		{
			UICallbackAttribute attr;
			foreach (MethodInfo info in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
			{
				if (info.TryGetAttribute(out attr))
				{
					if (attr.OnlyOnce)
					{
						Root.schedule.Execute(() => {info.Invoke(this, null);}).StartingIn(attr.Interval);
					} else {
						Root.schedule.Execute(() => {info.Invoke(this, null);}).Every(attr.Interval);
					}
				}
			}
		}
	}
}