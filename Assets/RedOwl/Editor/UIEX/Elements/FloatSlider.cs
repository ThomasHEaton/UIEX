#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;

namespace RedOwl.Editor
{
	[UXML]
	public class FloatSlider : RedOwlVisualElement
	{		
		public new class UxmlFactory : UxmlFactory<FloatSlider, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlStringAttributeDescription _label = new UxmlStringAttributeDescription { name = "label" };
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
				target.label.text = _label.GetValueFromBag(bag, cc);
				target.slider.lowValue = _lowValue.GetValueFromBag(bag, cc);
				target.slider.highValue = _highValue.GetValueFromBag(bag, cc);
				target.Value = _value.GetValueFromBag(bag, cc);
			}
		}
		
		[UXMLReference("Label")]
		Label label;
	    
		[UXMLReference("Slider")]
		Slider slider;
		
		[UXMLReference("Field")]
		FloatField field;

		private float _value;
		public float Value {
			get {
				return _value;
			}
			set {
				_value = value;
				slider.value = value;
				field.value = value;
			}
		}
		
		public FloatSlider() : base() {}
	    
		[UICallback(true, 1)]
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
