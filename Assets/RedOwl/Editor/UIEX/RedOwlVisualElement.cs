using System;
using System.Linq;
using System.Reflection;
using System.Collections;
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