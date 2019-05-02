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
	public class LongSlider : RedOwlBaseField<long>
	{
		public new class UxmlFactory : UxmlFactory<LongSlider, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlFloatAttributeDescription _lowValue = new UxmlFloatAttributeDescription { name = "low-value" };
			UxmlFloatAttributeDescription _highValue = new UxmlFloatAttributeDescription { name = "high-value" };
			UxmlLongAttributeDescription _value = new UxmlLongAttributeDescription { name = "value" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (LongSlider)ve;
				base.Init(ve, bag, cc);
				target.slider.lowValue = _lowValue.GetValueFromBag(bag, cc);
				target.slider.highValue = _highValue.GetValueFromBag(bag, cc);
				target.value = _value.GetValueFromBag(bag, cc);
			}
		}
	    
		[UXMLReference]
		Slider slider;
		
		[UXMLReference]
		LongField field;
		
		public LongSlider() : base()
        {
			slider.RegisterValueChangedCallback(evt => { field.value = value = (long)evt.newValue; });
			slider.style.minWidth = 50;
			field.RegisterValueChangedCallback(evt => { slider.value = value = evt.newValue; });
			field.style.minWidth = 80;
		}
	}
}