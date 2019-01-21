using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class UICallbackAttribute : Attribute
	{
		public readonly bool OnlyOnce;
		public readonly long Interval;
		
		public UICallbackAttribute(long interval = 100, bool once = false)
		{
			OnlyOnce = once;
			Interval = interval;
		}
	}
}