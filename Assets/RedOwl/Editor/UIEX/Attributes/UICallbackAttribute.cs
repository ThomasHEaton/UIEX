using System;

namespace RedOwl.Editor
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class UICallbackAttribute : Attribute
	{
		public readonly bool OnlyOnce;
		public readonly long Interval;
		
		public UICallbackAttribute(long interval = 100)
		{
			OnlyOnce = false;
			Interval = interval;
		}
		
		public UICallbackAttribute(bool once, long delay = 100)
		{
			OnlyOnce = once;
			Interval = delay;
		}
	}
}