#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
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
	public class IntSlider : RedOwlVisualElement
	{		
		public new class UxmlFactory : UxmlFactory<IntSlider, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlStringAttributeDescription _label = new UxmlStringAttributeDescription { name = "label" };
			UxmlIntAttributeDescription _lowValue = new UxmlIntAttributeDescription { name = "low-value" };
			UxmlIntAttributeDescription _highValue = new UxmlIntAttributeDescription { name = "high-value" };
			UxmlIntAttributeDescription _value = new UxmlIntAttributeDescription { name = "value" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (IntSlider)ve;
				base.Init(ve, bag, cc);
				target.label.text = _label.GetValueFromBag(bag, cc);
				target.slider.lowValue = _lowValue.GetValueFromBag(bag, cc);
				target.slider.highValue = _highValue.GetValueFromBag(bag, cc);
				target.Value = _value.GetValueFromBag(bag, cc);
			}
		}
		
		[UXMLReference]
		Label label;
	    
		[UXMLReference]
		SliderInt slider;
		
		[UXMLReference]
		IntegerField field;

		private int _value;
		public int Value {
			get {
				return _value;
			}
			set {
				_value = value;
				slider.value = value;
				field.value = value;
			}
		}
		
		public IntSlider() : base() {}
	    
		[UICallback(1, true)]
		private void CreateUI()
		{
			label.style.width = label.text.Length * 8;
			slider.OnValueChanged(evt => { Value = evt.newValue; });
			slider.style.minWidth = 50;
			field.OnValueChanged(evt => {Value = evt.newValue; });
			field.style.width = 80;
		}
	}
}
