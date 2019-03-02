using System.Collections.Generic;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEditor.UIElements;
#else
using UnityEditor.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
	public abstract class RedOwlInspector : RedOwlVisualElement
	{
		protected RedOwlInspector(SerializedObject obj)
		{
			_target = obj;
		}
		
		private SerializedObject _target;
		public SerializedObject target {
			get { return _target; }
			set {
				_target = value;
				Draw();
			}
		}
	
		[UICallback(2, true)]
		private void Draw()
		{
			if (target == null) return;
			var propertiesToExclude = GetExcludedFields();
			target.Update();
			SerializedProperty property = target.GetIterator();
			OnBeforeDrawInspector();
            property.NextVisible(true);
            do
            {
				if (propertiesToExclude.Contains(property.name)) continue;
				OnBeforeDrawProperty(property);
				Add( new PropertyField(property));
				OnAfterDrawProperty(property);
			}
			while (property.NextVisible(false));
			OnAfterDrawInspector();
			target.ApplyModifiedProperties();
		}
		
		protected virtual void OnBeforeDrawInspector() {}
		
		protected virtual void OnBeforeDrawProperty(SerializedProperty property) {}
		
		protected virtual void OnAfterDrawProperty(SerializedProperty property) {}
		
		protected virtual void OnAfterDrawInspector() {}
		
		protected virtual List<string> GetExcludedFields()
		{
			return new List<string>{"m_Script"};
		}
	}
}