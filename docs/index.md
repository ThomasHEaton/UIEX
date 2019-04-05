---
layout: home
title: Home
heading: Documentation Topics
navigation:
  - /classes
---

The following documentation assumes you have a little bit of familiarity with c# and Unity's new UI Elements system - if not go read about it [here](https://docs.unity3d.com/Manual/UIElements.html)


## Need to move into sub files


## Attributes

### UXML

Place this attribute on any `RedOwlClasses` and it will load the UXML file

```cs
namespace RedOwl.Demo
{
    [UXML("RedOwl/Demo")]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load the UXML file `Resources/RedOwl/Demo.uxml`

If the path given is blank it will build a path from the classes namespace and class name with a suffix of `Layout` as show below

```cs
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load the UXML file `Resources/RedOwl/Demo/DemoElementLayout.uxml`

### UXMLReference

Use this attribute on `RedOwlClasses` fields and it will populate the field with the object loaded from the UXML file using the query system

Optionally if the name given is blank it will use the fields name to query for the element within the loaded UXML

```cs
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement
    {
        [UXMLReference]
        VisualElement Content;

        [UXMLReference("SideBar")]
        VisualElement Navigation;

        [UXMLReference]
        TextureCanvas Canvas;
    }
}
```

With the below UXML these `DemoElement` fields would be populated with references to the elements written in the UXML file

```xml
<?xml version="1.0" encoding="utf-8"?>
<UXML xmlns="UnityEngine.UIElements" xmlns:ro="RedOwl.Editor">
    <VisualElement name="Content">
        <VisualElement name="SideBar" />
    </VisualElement>
    <ro:TextureCanvas name="Canvas" />
</UXML>
```

NOTE: the type of the field is taken into consideration and an error will be thrown if it does not match the element found

### USS

Place any number of these attributes on `RedOwlClasses` and it will load the USS file

Optionally if the path given is blank it will build a path from the classes namespace and class name with the suffix `Style`

```cs
namespace RedOwl.Demo
{
    [USS, USS("RedOwl/Styles")]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load and attach the USS files `Resources/RedOwl/Demo/DemoElementStyle.uss` and `Resources/RedOwl/Styles.uss`

### USSClass

Place any number of these attributes on `RedOwlClasses` and it will add a USS class to this element

```cs
namespace RedOwl.Demo
{
    [USSClass("vertical", "red")]
    public class DemoElement : RedOwlVisualElement {}

    [USSClass("fill")]
    public class DemoElement2 : DemoElement {}
}
```

The attributes are inherited so the resulting classes on `DemoElement2` would be `["vertical","red","fill"]`

### Q & Query

This attribute is to provide uQuery functionality in a more buttoned up way by having a function be called when the element is found

Q - Find a single element and call the function
Query - Find multiple elements and call the function for each

```cs
namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        [Q("prop", "vertical")]
        void OnElementFound(VisualElement element) { /* will be called only once for the first element found with the name prop and class vertical */ }

        [Query(null, "vertical")]
        void OnElementFound(VisualElement element) { /* will be called for each element found with the class vertical */ }
    }
}
```

### UICallback

Use this attribute on `RedOwlClasses` methods to automatically schedule for callback at certain intervals

```cs
namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        [UICallback(1, true)]
        void InitializeUI() { Debug.Log("Will only be called once after a 1ms delay!"); }

        [UICallback(100)]
        void UpdateUI() { Debug.Log("Will be called every 100ms!"); }
    }
}
```

The first function's attribute is given a "true" argument which tells the system to only schedule the callback once after the delay given

## Manipulators

The manipulators system has been generalized to allow for more easily defining callbacks within your `RedOwlClasses` without having to write your own manipulator class - this gets you back closer to how IMGUI worked while still retaining the UI Event bubbling improvements of UIElements

The core of the Mouse and Keyboard manipulators is that they've been written to be generic by takeing "config" structs which help them decide where to send the events too

The interfaces you have to implement help the RedOwl editor class know that it should hook up a manipulator into the system and then ask for your filter "config" structs

Some of the callback methods have extra data which is generally useful when working with that kind of input event - such as the MouseFilters.OnMove callback gives you a delta of the mouse movement between callbacks, but all of the callback methods also passthrough the original event if you want to get at other properites or methods defined on that type of event - IE `evt.StopPropagation()`

#### NOTE: while the manipulators will automatically hook themseleves up inside `RedOwlClasses` this does not mean you cannot use these manipulators with other UIElements classes.  You could still apply this manipulators to non `RedOwlClasses` and feed them the "config" structs and they would still work properly, you just don't need to implement the interfaces

### RedOwlMouseManipulator

To enable this manipulator on your `RedOwlClasses` you have to implement an interface

```cs
[UXML]
public class DemoElement : RedOwlVisualElement, IOnMouse
{
    [UXMLReference]
    VisualElement frame;
	
    public IEnumerable<MouseFilter> MouseFilters {
        get {
            yield return new MouseFilter { 
                button = MouseButton.LeftMouse,
                OnDown = OnMouseDown,
                OnMove = OnPan,
                OnUp = OnMouseUp
            };
            yield return new MouseFilter { 
                button = MouseButton.MiddleMouse,
                modifiers = EventModifiers.Control,
                OnMove = OnPan
            };
        }
    }

    public void OnMouseDown(MouseDownEvent evt)
    {
        Debug.Log("Left Mouse Pressed")
	}
	
    public void OnPan(MouseMoveEvent evt, Vector2 delta)
    {
        // Will happen for left mouse or right mouse + ctrl/cmd
        Vector3 current = frame.transform.position;
        frame.transform.position = new Vector3(current.x + delta.x, current.y + delta.y, -100f);
    }

    public void OnMouseUp(MouseDownEvent evt)
    {
        Debug.Log("Left Mouse Released");
    }
}
```

The above shows an example of implementing the IOnMouse interface and giving it 2 "config" structures which map to the same function on the class - this means you can hookup multiple ways to callback into your code from the input system.  The manipulator system is written to properly detect and filter the input based on the "configs" provided so that your classes function is guaranteed to only be called when those filters are true.

### RedOwlKeyboardManipulator

The keyboard filter works much like the mouse filter just with a different interface and set of callbacks available

```cs
public class DemoElement : RedOwlVisualElement, IOnKeyboard
{
    public IEnumerable<KeyboardFilter> KeyboardFilters {
        get {
            yield return new KeyboardFilter {
                key = KeyCode.F,
                OnDown = OnKeyDown
            };
            yield return new KeyboardFilter {
                key = KeyCode.G,
                OnUp = OnKeyUp
            };
        }
    }

    void OnKeyDown(KeyDownEvent evt)
    {
        Debug.Log("This will get called when the F key is pressed down or held down");
        evt.StopPropagation();
    }

    void OnKeyUp(KeyUpEvent evt)
    {
        Debug.Log("This will get called when the G key is released");
    }
}
```

### RedOwlWheelManipulator

The wheel manipulator is slightly different then the previous 2 because there is really no configuration you need to pass in - all you care about is which direction the wheel is turned, right?

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

There is also another variation of the wheel manipulator callback that is specifically designed for zooming actions because it provides you with `scale` data that can be feed directly into the UIElements transforms to scale (or zoom) them in and out

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

## Custom Elements

The following documenation is about custom elements you can use in your unity editor ui's which are not included in the base set of unity's elements.

### FontAwesome (Gold)

This custom element allows you to use FontAwesome icons (free only) in your unity editor ui's - https://fontawesome.com

Here is an example of how to use the element in c#:

```cs
using RedOwl.Editor;

namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        FontAwesome obj;

        [UICallback(1, true)]
        void InitializeUI() {
            obj = new FontAwesome("solid", "fa-chevron-right")
            Add(obj);
        }

        [UICallback(500)]
        void UpdateUI() {
            if (obj.icon == "fa-chevron-right") obj.icon = "fa-chevron-down";
            else obj.icon = "fa-chevron-right";
        }
    }
}
```

or you can use it in UXML like this:

```xml
<UXML xmlns="UnityEngine.UIElements" xmlns:ue="UnityEditor.UIElements" xmlns:ro="RedOwl.Editor">
    <VisualElement class="container row">
        <ue:ToolbarButton class="container row"><ro:FontAwesome type="solid" icon="fa-chevron-down" width="25" height="25" /></ue:ToolbarButton>
        <ro:FontAwesome type="solid" icon="fa-address-card" width="25" height="25" />
        <Label name="title" text="Title" />
    </VisualElement>
</UXML>
```

There are other custom elements but i'm not documenting them yet as i'd like to prove out their usefulness

