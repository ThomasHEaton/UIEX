using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
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