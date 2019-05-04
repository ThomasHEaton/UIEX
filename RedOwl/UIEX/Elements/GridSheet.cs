#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using RedOwl.Editor;

namespace RedOwl.Editor
{	
	public class GridSheet : RedOwlVisualElement
	{
		public new class UxmlFactory : UxmlFactory<GridSheet> {}

		public Vector2 pan;
		public Vector2 scale;
		public Color lineColor;
				
		private IMGUIContainer container;
		
		public GridSheet() : base()
		{
			pan = Vector2.zero;
			scale = Vector2.one;
			lineColor = new Color(0.8f, 0.8f, 0.8f, 0.18f);
			container = new IMGUIContainer(UpdateUI);
			container.style.overflow = Overflow.Visible;
			Add(container);
		}
			    
		private void UpdateUI()
		{
			DrawGrid();
		}
		
		private void DrawGrid()
		{
			Rect displayRect = new Rect(0, 0, parent.layout.width, parent.layout.height);
			float UVWidth = 6f / scale.x;
			float UVHeight = 3.5f / scale.y;
			float U = pan.x / (parent.layout.width * (1 / UVWidth));
			float V = pan.y / (parent.layout.height * (1 / UVHeight)) - UVHeight;
			if (U == Mathf.Infinity) U = 0f;
			if (V == Mathf.Infinity) V = 0f;
			Rect uvRect = new Rect(-U, V, UVWidth, UVHeight);
			GUI.DrawTextureWithTexCoords(displayRect, UIEX.Background, uvRect);
		}
	}
}
