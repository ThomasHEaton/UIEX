using System;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif
using Object = UnityEngine.Object;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class UXMLAttribute : Attribute
	{
		public readonly string path;
		
		public UXMLAttribute(string path = "")
		{
			this.path = path;
		}
	}
}