using System;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

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