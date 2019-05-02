#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace RedOwl.Editor
{
	[UXML, USSClass("horizontal")]
	public class IntegerSlider : RedOwlBaseField<int>
	{
		public new class UxmlFactory : UxmlFactory<IntegerSlider, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlIntAttributeDescription _lowValue = new UxmlIntAttributeDescription { name = "low-value" };
			UxmlIntAttributeDescription _highValue = new UxmlIntAttributeDescription { name = "high-value" };
			UxmlIntAttributeDescription _value = new UxmlIntAttributeDescription { name = "value" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (IntegerSlider)ve;
				base.Init(ve, bag, cc);
				target.slider.lowValue = _lowValue.GetValueFromBag(bag, cc);
				target.slider.highValue = _highValue.GetValueFromBag(bag, cc);
				target.value = _value.GetValueFromBag(bag, cc);
			}
		}
	    
		[UXMLReference]
		SliderInt slider;
		
		[UXMLReference]
		IntegerField field;
		
		public IntegerSlider() : base()
        {    
			slider.RegisterValueChangedCallback(evt => { field.value = value = evt.newValue; });
			slider.style.minWidth = 50;
			field.RegisterValueChangedCallback(evt => { slider.value = value = evt.newValue; });
			field.style.minWidth = 80;
		}
	}
}