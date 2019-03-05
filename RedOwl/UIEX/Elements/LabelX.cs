#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEditor.UIElements;
#else
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    [UXML]
	public class LabelX : RedOwlVisualElement
	{		
		public new class UxmlFactory : UxmlFactory<LabelX, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlStringAttributeDescription _label = new UxmlStringAttributeDescription { name = "text" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (LabelX)ve;
				base.Init(ve, bag, cc);
				target.label.text = _label.GetValueFromBag(bag, cc);
			}
		}
		
		[UXMLReference]
		Label label;

		public string text {
			get { return label.text; }
			set { label.text = value; }
		}
		
		public LabelX() : base() {}

        public LabelX(string text) : base()
        {
            label.text = text;
        }
	    
		[UICallback(1, true)]
		private void CreateUI()
		{
			label.text = ObjectNames.NicifyVariableName(label.text);
			this.style.marginLeft = 13;
		}
	}
}
