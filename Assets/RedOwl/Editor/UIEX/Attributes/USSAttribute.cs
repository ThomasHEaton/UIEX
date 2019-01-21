using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class USSAttribute : Attribute
	{
		public readonly string path;
		
		public USSAttribute(string path = "")
		{
			this.path = path;
		}
	}
}