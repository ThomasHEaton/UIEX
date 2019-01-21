using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;

namespace RedOwl.Editor
{
	[USS("RedOwl/Editor/Styles")]
	public abstract class RedOwlVisualElement : VisualElement
	{				
		public bool IsInitalized { get; protected set; }
		
		public RedOwlVisualElement()
		{
			if (IsInitalized) return;
			RedOwlUtils.Setup(this, this);
			IsInitalized = true;
		}
	}
}