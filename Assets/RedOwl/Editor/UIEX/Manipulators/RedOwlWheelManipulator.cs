using System;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEditor.UIElements;
#else
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{	
	public interface IOnWheel {
		void OnWheel(WheelEvent evt, int wheelDelta);
	}
	
	public interface IOnZoom {
		float zoomMinScale { get; }
		float zoomMaxScale { get; }
		float zoomScaleStep { get; }
		EventModifiers zoomActivationModifiers { get; }
		void OnZoom(WheelEvent evt, Vector3 scale);
		
		/*
		// Example IOnZoom Implementation
		public float zoomMinScale { get { return 0.2f; } }
		public float zoomMaxScale { get { return 5f; } }
		public float zoomScaleStep { get { return 0.15f; } }
		public EventModifiers zoomActivationModifiers { get { return EventModifiers.None; } }
		public void OnZoom(WheelEvent evt, Vector3 scale)
		{
		canvas.transform.scale = scale;
		}
		*/
	}

	public class RedOwlWheelManipulator : Manipulator
	{
		private IOnWheel wheelTarget;
		private IOnZoom zoomTarget;
		
		private float zoomMinScale;
		private float zoomMaxScale;
		private float zoomScaleStep;
		private float zoomCurrentScale;
		private EventModifiers zoomModifiers;

		protected override void RegisterCallbacksOnTarget()
		{
			wheelTarget = target as IOnWheel;
			zoomTarget = target as IOnZoom;

			if (wheelTarget != null || zoomTarget != null) 
			{
				if (zoomTarget != null)
				{
					zoomMinScale = zoomTarget.zoomMinScale;
					zoomMaxScale = zoomTarget.zoomMaxScale;
					zoomScaleStep = zoomTarget.zoomScaleStep;
					zoomCurrentScale = 1f;
					zoomModifiers = zoomTarget.zoomActivationModifiers;
				}
				target.RegisterCallback<WheelEvent>(OnWheel);
			}
		}

		protected override void UnregisterCallbacksFromTarget()
		{
			if (wheelTarget != null || zoomTarget != null) target.UnregisterCallback<WheelEvent>(OnWheel);
		}
		

		
		void OnWheel(WheelEvent evt)
		{
			if (MouseCaptureController.IsMouseCaptured()) return;
			
			if (wheelTarget != null) wheelTarget.OnWheel(evt, GetWheelDelta(evt.delta.y));
			
			if (zoomTarget != null && evt.modifiers == zoomModifiers)
			{
				zoomCurrentScale = CalculateNewZoom(zoomCurrentScale, -evt.delta.y, zoomScaleStep, zoomMinScale, zoomMaxScale);
				zoomTarget.OnZoom(evt, new Vector3(zoomCurrentScale, zoomCurrentScale, 1f));
			}
		}
		
		int GetWheelDelta(float delta)
		{
			if (Mathf.Approximately(delta, 0)) return 0;
			return (int)Mathf.Sign(delta);
		}
		
		// Compute the parameters of our exponential model:
		// z(w) = (1 + s) ^ (w + a) + b
		// Where
		// z: calculated zoom level
		// w: accumulated wheel deltas (1 unit = 1 mouse notch)
		// s: zoom step
		//
		// The factors a and b are calculated in order to satisfy the conditions:
		// z(0) = referenceZoom
		// z(1) = referenceZoom * (1 + zoomStep)
		private static float CalculateNewZoom(float currentZoom, float wheelDelta, float zoomStep, float minZoom, float maxZoom)
		{
			float DefaultReferenceScale = 1f;
			if (minZoom <= 0)
			{
				return currentZoom;
			}
			if (DefaultReferenceScale < minZoom)
			{
				return currentZoom;
			}
			if (DefaultReferenceScale > maxZoom)
			{
				return currentZoom;
			}
			if (zoomStep < 0)
			{
				return currentZoom;
			}

			currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

			if (Mathf.Approximately(wheelDelta, 0))
			{
				return currentZoom;
			}

			// Calculate the factors of our model:
			double a = Math.Log(DefaultReferenceScale, 1 + zoomStep);
			double b = DefaultReferenceScale - Math.Pow(1 + zoomStep, a);

			// Convert zoom levels to scroll wheel values.
			double minWheel = Math.Log(minZoom - b, 1 + zoomStep) - a;
			double maxWheel = Math.Log(maxZoom - b, 1 + zoomStep) - a;
			double currentWheel = Math.Log(currentZoom - b, 1 + zoomStep) - a;

			// Except when the delta is zero, for each event, consider that the delta corresponds to a rotation by a
			// full notch. The scroll wheel abstraction system is buggy and incomplete: with a regular mouse, the
			// minimum wheel movement is 0.1 on OS X and 3 on Windows. We can't simply accumulate deltas like these, so
			// we accumulate integers only. This may be problematic with high resolution scroll wheels: many small
			// events will be fired. However, at this point, we have no way to differentiate a high resolution scroll
			// wheel delta from a non-accelerated scroll wheel delta of one notch on OS X.
			wheelDelta = Math.Sign(wheelDelta);
			currentWheel += wheelDelta;

			// Assimilate to the boundary when it is nearby.
			if (currentWheel > maxWheel - 0.5)
			{
				return maxZoom;
			}
			if (currentWheel < minWheel + 0.5)
			{
				return minZoom;
			}

			// Snap the wheel to the unit grid.
			currentWheel = Math.Round(currentWheel);

			// Do not assimilate again. Otherwise, points as far as 1.5 units away could be stuck to the boundary
			// because the wheel delta is either +1 or -1.

			// Calculate the corresponding zoom level.
			return (float)(Math.Pow(1 + zoomStep, currentWheel + a) + b);
		}
	}
}
