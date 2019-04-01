using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class QueryAttribute : Attribute
	{
        public string name;
        public string[] classes;
		
		public QueryAttribute(string name = null, params string[] classes)
		{
            this.name = name;
            this.classes = classes;
		}

		public QueryAttribute(string name = null, string className = null)
		{
            this.name = name;
            this.classes = new string[] { className };
		}
	}
}