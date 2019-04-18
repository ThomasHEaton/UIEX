using System;
using UnityEngine;
using UnityEngine.UIElements;

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