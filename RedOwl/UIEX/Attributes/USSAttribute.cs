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
	public class USSAttribute : Attribute
	{
		public readonly string path;
		
		public USSAttribute(string path = "")
		{
			this.path = path;
		}
	}
}