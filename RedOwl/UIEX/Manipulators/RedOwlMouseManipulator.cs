using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
	public interface IOnMouseMove {
		void OnMouseMove(MouseMoveEvent evt);
	}
	
	public interface IOnMouse {
		bool IsContentDragger { get; }
		IEnumerable<MouseFilter> MouseFilters { get; }
	}
	
	public interface IOnMouseHover {
		void OnMouseEnter(MouseEnterEvent evt);
		void OnMouseHover(MouseMoveEvent evt);
		void OnMouseLeave(MouseLeaveEvent evt);
	}
	
	// I had to fork this code from unity because i wanted to have the filters control which callbacks are run in my custom manipulater setup
	// Forked - https://github.com/Unity-Technologies/UnityCsReference/blob/2018.3/Modules/UIElements/ManipulatorActivationFilter.cs
	// Forked - https://github.com/Unity-Technologies/UnityCsReference/blob/2018.3/Modules/UIElements/MouseManipulator.cs
	public struct MouseFilter  //
	{
		public MouseButton button;
		public EventModifiers modifiers;
		public int clickCount;
		
		public Action<MouseDownEvent> OnDown;
		public Action<MouseMoveEvent, Vector3> OnMove;
		public Action<MouseUpEvent> OnUp;
		
		public bool Matches(IMouseEvent e)
		{
			// Default clickCount field value is 0 since we're in a struct -- this case is covered if the user
			// did not explicitly set clickCount
			var minClickCount = (clickCount == 0 || (e.clickCount >= clickCount));
			return button == (MouseButton)e.button && HasModifiers(e) && minClickCount;
		}

		private bool HasModifiers(IMouseEvent e)
		{
			if (((modifiers & EventModifiers.Alt) != 0 && !e.altKey) ||
			((modifiers & EventModifiers.Alt) == 0 && e.altKey))
			{
				return false;
			}

			if (((modifiers & EventModifiers.Control) != 0 && !e.ctrlKey) ||
			((modifiers & EventModifiers.Control) == 0 && e.ctrlKey))
			{
				return false;
			}

			if (((modifiers & EventModifiers.Shift) != 0 && !e.shiftKey) ||
			((modifiers & EventModifiers.Shift) == 0 && e.shiftKey))
			{
				return false;
			}

			return ((modifiers & EventModifiers.Command) == 0 || e.commandKey) &&
			((modifiers & EventModifiers.Command) != 0 || !e.commandKey);
		}
	}
	
	public class RedOwlMouseManipulator : Manipulator
	{
		private bool isContentDragger;
		private MouseFilter[] filters;
		public MouseFilter currentFilter { get; private set; }
		
		private Vector2 _start;
		private bool _active;

		public RedOwlMouseManipulator(bool isContentDragger, params MouseFilter[] filters)
		{
			this.isContentDragger = isContentDragger;
			this.filters = filters;
			_active = false;
		}
		
		protected override void RegisterCallbacksOnTarget()
		{
			target.RegisterCallback<MouseDownEvent>(OnMouseDown);
			target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
			target.RegisterCallback<MouseUpEvent>(OnMouseUp);
			
			var moveTarget = target as IOnMouseMove;
			if (moveTarget != null)
			{
				target.RegisterCallback<MouseMoveEvent>(moveTarget.OnMouseMove);
			}
			
			var hoverTarget = target as IOnMouseHover;
			if (hoverTarget != null)
			{
				target.RegisterCallback<MouseEnterEvent>(hoverTarget.OnMouseEnter);
				target.RegisterCallback<MouseMoveEvent>(hoverTarget.OnMouseHover);
				target.RegisterCallback<MouseLeaveEvent>(hoverTarget.OnMouseLeave);
			}
		}

		protected override void UnregisterCallbacksFromTarget()
		{
			target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
			target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
			target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
			
			var moveTarget = target as IOnMouseMove;
			if (moveTarget != null)
			{
				target.UnregisterCallback<MouseMoveEvent>(moveTarget.OnMouseMove);
			}
			
			var hoverTarget = target as IOnMouseHover;
			if (hoverTarget != null)
			{
				target.UnregisterCallback<MouseEnterEvent>(hoverTarget.OnMouseEnter);
				target.UnregisterCallback<MouseMoveEvent>(hoverTarget.OnMouseHover);
				target.UnregisterCallback<MouseLeaveEvent>(hoverTarget.OnMouseLeave);
			}
		}
		
		protected void OnMouseDown(MouseDownEvent evt)
		{
			if (_active)
			{
				evt.StopImmediatePropagation();
				return;
			}

			if (CanStartManipulation(evt))
			{
				_active = true;
				target.CaptureMouse();
				_start = evt.localMousePosition;
				if (currentFilter.OnDown != null) currentFilter.OnDown(evt);
				evt.StopImmediatePropagation();
			}
		}

		protected void OnMouseMove(MouseMoveEvent evt)
		{
			if (!_active || !target.HasMouseCapture()) return;
			if (currentFilter.OnMove != null)
			{
				VisualElement element = evt.target as VisualElement;
				if (element != null)
				{
					Vector2 diff = evt.localMousePosition - _start;
					if (isContentDragger == false)
					{
						diff.x *= element.transform.scale.x;
						diff.y *= element.transform.scale.y;
					}
					currentFilter.OnMove(evt, (Vector3)diff);
				}
			}
			if (isContentDragger)
				_start = evt.localMousePosition;
			evt.StopPropagation();
		}

		protected void OnMouseUp(MouseUpEvent evt)
		{
			if (!_active || !target.HasMouseCapture() || !CanStopManipulation(evt)) return;
			target.ReleaseMouse();
			_active = false;
			if (currentFilter.OnUp != null) currentFilter.OnUp(evt);
			evt.StopPropagation();
		}

		protected bool CanStartManipulation(IMouseEvent evt)
		{
			foreach (var filter in filters)
			{
				if (filter.Matches(evt))
				{
					currentFilter = filter;
					return true;
				}
			}
			return false;
		}

		protected bool CanStopManipulation(IMouseEvent e)
		{
			return ((MouseButton)e.button == currentFilter.button);
		}
	}
}