---
layout: default
title: Red Owl Wheel Manipulator
parent: Manipulators
---

<dl>
  <dt>Name</dt>
  <dd>RedOwlWheelManipulator</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

The wheel manipulator is slightly different then the previous 2 because there is really no configuration you need to pass in - all you care about is which direction the wheel is turned, right?

## Example
---

```cs
public class DemoElement : RedOwlVisualElement, IOnWheel
{
    public void OnWheel(WheelEvent evt, int wheelDelta)
    {
        Debug.Log($"The wheel moved: {wheelDelta}")
    }
}
```

The `wheelDelta` data will be constrained to values `0`, `1`, or `-1` to make building actions off this easier

There is also another variation of the wheel manipulator callback that is specifically designed for zooming actions because it provides you with `scale` data that can be fed directly into the UIElements transforms to scale (or zoom) them in and out

```cs
[UXML]
public class DemoElement : RedOwlVisualElement, IOnZoom
{
    [UXMLReference]
    VisualElement frame;

    public float zoomMinScale { get { return 0.2f; } }
    public float zoomMaxScale { get { return 15f; } }
    public float zoomScaleStep { get { return 0.15f; } }
    public EventModifiers zoomActivationModifiers { get { return EventModifiers.None; } }		
    public void OnZoom(WheelEvent evt, Vector3 scale)
    {
        frame.transform.scale = scale;
    }
}
```