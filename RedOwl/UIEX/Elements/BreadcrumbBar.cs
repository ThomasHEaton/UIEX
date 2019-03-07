#if UNITY_EDITOR
#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using RedOwl.Editor;

namespace RedOwl.Editor
{
    [USSClass("contianer", "row")]
	public abstract class BreadcrumbBar<T> : RedOwlVisualElement
	{
        private List<T> data;
		    	
		public BreadcrumbBar() : base()
        {
            data = new List<T>();
        }

        public void AddBreadcrumb(T item)
        {
            data.Add(item);
            var index = data.Count - 1;
            Breadcrumb crumb = new Breadcrumb(index, item.ToString(), HandleBreadcrumbClicked);
            if (data.Count > 1)
            {
                crumb.ShowSeparator();
            }
            Add(crumb);
        }

        public void ClearBreadcrumbs()
        {
            data = new List<T>();
            Clear();
        }

        private void HandleBreadcrumbClicked(int index)
        {
            for (int i = childCount - 1; i > index; i--)
            {
                this.RemoveAt(i);
            }
            data = data.Take(index + 1).ToList();
            OnBreadcrumbClicked(data[index]);
        }

        // Contract
        protected abstract void OnBreadcrumbClicked(T item);
    }
}
#endif
