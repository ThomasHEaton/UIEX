using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class UXMLReferenceAttribute : Attribute
	{
		public readonly string name;
		
		public UXMLReferenceAttribute(string name = "")
		{
			this.name = name;
		}
	}
}