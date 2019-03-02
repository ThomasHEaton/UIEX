#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleEnums;
#else
using UnityEngine.Experimental.UIElements;
using UnityEngine.Experimental.UIElements.StyleEnums;
#endif

namespace RedOwl.Editor
{
	public interface IHandlesBezier
	{
		float LineWidth { get; }
		Color LineColor { get; }
		IEnumerable<Tuple<Vector2, Vector2>> GetBezierPoints();
	}
	
	public class HandlesRenderer : RedOwlVisualElement
	{
		public new class UxmlFactory : UxmlFactory<HandlesRenderer> {}
		
		private IHandlesBezier bezier;
		
		private IMGUIContainer container;
		
		public HandlesRenderer() : base() {}
		
		public void Load(IHandlesBezier bezier) { this.bezier = bezier; }
	    
		[UICallback(1, true)]
		private void CreateUI()
		{
			container = new IMGUIContainer(UpdateUI);
			container.style.overflow = Overflow.Visible;
			Add(container);
		}
	    
		private void UpdateUI()
		{
			if (bezier != null) DrawHandlesBezier();
		}
		
		private void DrawHandlesBezier()
		{
			Vector2 start;
			Vector2 startTangent;
			Vector2 end;
			Vector2 endTangent;
			float lineWidth = bezier.LineWidth;
			Color lineColor = bezier.LineColor;
			foreach (var conn in bezier.GetBezierPoints())
			{
				start = container.WorldToLocal(conn.Item1);
				end = container.WorldToLocal(conn.Item2);
				if (start.x < end.x)
				{
					startTangent = Vector2.right;
					endTangent = Vector2.left;
				} else {
					startTangent = Vector2.left;
					endTangent = Vector2.right;
				}
				//TODO: Turn this into a 2 curve drawing where you draw from
				// start to midpoint and then end to midpoint where midpoint is end - start
				Handles.DrawBezier(
					start,
					end,
					start + startTangent * 100,
					end + endTangent * 100,
					lineColor,
					null,
					lineWidth
				);
			}
		}
	}
}
