﻿using System.Collections;
using UnityEngine;
using UnityEditor;

namespace RedOwl.Editor
{
    public abstract class RedOwlEditor : UnityEditor.Editor
    {	
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            OnBeforeDefaultInspector();
            DrawPropertiesExcluding(serializedObject, GetInvisibleInDefaultInspector());
            serializedObject.ApplyModifiedProperties();
            OnAfterDefaultInspector();
        }
        
        protected virtual void OnBeforeDefaultInspector() {}
        
        protected virtual void OnAfterDefaultInspector() {}
        
        protected virtual string[] GetInvisibleInDefaultInspector()
        {
            return new string[0];
        }
    }
}

/*
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEditor.UIElements;
#else
using UnityEditor.Experimental;
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;
#endif

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
*/