using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RedOwl.Editor
{
	public abstract class RedOwlAssetEditor<T1, T2> : RedOwlEditorWindow<T2> where T1 : ScriptableObject where T2 : RedOwlAssetEditor<T1, T2>
	{
		public static void OpenWith(T1 target, WindowDockStyles style = WindowDockStyles.Inspector)
		{
			EnsureWindow(style);
			instance.Focus();
			instance.Load(target);
		}
		
		protected static bool HandleAutoOpen(WindowDockStyles style = WindowDockStyles.Inspector)
		{
			
			if (Selection.activeObject != null && typeof(T1).IsAssignableFrom(Selection.activeObject.GetType()))
			{
				EnsureWindow(style);
				instance.Load(Selection.activeObject as T1);
				return true;
			}
			return false;
		}
		
		protected override void OnEnable()
		{
			base.OnEnable();
			// Manual handlers have to be used over magic methods because
			// magic methods don't get triggered when the window is out of focus
			Selection.selectionChanged += OnSelectionChanged;
		}
        
		protected override void OnDisable()
		{
			base.OnDisable();
			Selection.selectionChanged -= OnSelectionChanged;
		}
        
		public void OnSelectionChanged()
		{
			if (Selection.activeObject != null && typeof(T1).IsAssignableFrom(Selection.activeObject.GetType()))
			{
				EnsureWindow(WindowDockStyles.DontChange);
				Focus();
				Load(Selection.activeObject as T1);
			}
		}
		
		// Contract
		public abstract void Load(T1 obj);
	}
}
