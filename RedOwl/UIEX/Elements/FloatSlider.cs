#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace RedOwl.Editor
{
	[UXML, USSClass("horizontal")]
	public class FloatSlider : RedOwlBaseField<float>
	{
		public new class UxmlFactory : UxmlFactory<FloatSlider, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlFloatAttributeDescription _lowValue = new UxmlFloatAttributeDescription { name = "low-value" };
			UxmlFloatAttributeDescription _highValue = new UxmlFloatAttributeDescription { name = "high-value" };
			UxmlFloatAttributeDescription _value = new UxmlFloatAttributeDescription { name = "value" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (FloatSlider)ve;
				base.Init(ve, bag, cc);
				target.slider.lowValue = _lowValue.GetValueFromBag(bag, cc);
				target.slider.highValue = _highValue.GetValueFromBag(bag, cc);
				target.value = _value.GetValueFromBag(bag, cc);
			}
		}
	    
		[UXMLReference]
		Slider slider;
		
		[UXMLReference]
		FloatField field;
		
		public FloatSlider() : base()
        {
            slider.RegisterValueChangedCallback(evt => { field.value = value = evt.newValue; });
			slider.style.minWidth = 50;
			field.RegisterValueChangedCallback(evt => { slider.value = value = evt.newValue; });
			field.style.minWidth = 80;
        }
	}
}