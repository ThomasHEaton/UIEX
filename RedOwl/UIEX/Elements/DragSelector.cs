#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
	public class DragSelector : RedOwlVisualElement
	{
		public new class UxmlFactory : UxmlFactory<DragSelector> {}

        public Color color;
        public Action<Rect> OnComplete;
				
		private IMGUIContainer container;
        private bool shouldDraw = false;
        private Vector2 startPoint;
        private Rect area;
		
		public DragSelector() : base()
		{
            color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
			container = new IMGUIContainer(UpdateUI);
			container.style.overflow = Overflow.Visible;
			Add(container);
		}

		public void OnDown(MouseDownEvent evt)
		{
            startPoint = container.WorldToLocal(evt.mousePosition);
		}
        
		public void OnMove(MouseMoveEvent evt, Vector3 delta)
		{
			CalculateRect(container.WorldToLocal(evt.mousePosition));
            shouldDraw = true;
		}

        public void OnUp(MouseUpEvent evt)
        {
            shouldDraw = false;
            CalculateRect(container.WorldToLocal(evt.mousePosition));
            OnComplete.Invoke(area);
        }

        private void CalculateRect(Vector2 endPoint)
        {
            area = new Rect(startPoint.x, startPoint.y, endPoint.x - startPoint.x, endPoint.y - startPoint.y);
        }
			    
		private void UpdateUI()
		{
			if (shouldDraw) DrawRect();
		}
		
		private void DrawRect()
		{
            GUI.color = color;
			GUI.Box(area, "");
            GUI.color = Color.white; 
		}
	}
}
