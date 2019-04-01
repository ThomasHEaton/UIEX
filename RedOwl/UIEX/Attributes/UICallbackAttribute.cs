using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class UICallbackAttribute : Attribute
	{
		public readonly bool once;
		public readonly long interval;
		
		public UICallbackAttribute(long interval = 100, bool once = false)
		{
			this.once = once;
			this.interval = interval;
		}
	}
}