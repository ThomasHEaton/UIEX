using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class UXMLReferenceAttribute : Attribute
	{
		public readonly string Name;
		
		public UXMLReferenceAttribute(string name = "")
		{
			Name = name;
		}
	}
}