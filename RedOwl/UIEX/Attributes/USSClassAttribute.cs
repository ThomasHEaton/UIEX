using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class USSClassAttribute : Attribute
	{
		public readonly string[] names;
		
		public USSClassAttribute(params string[] names)
		{
			this.names = names;
		}
	}
}