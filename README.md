<h1 align="center">UIEX</h1>
<h4 align="center">UIElementsX (UIEX) is the missing high level API for unity's new UI system.</h4>


<p align="center">
    <a href="#what-it-looks-like">What it looks like?</a> •
    <a href="#installation">How to get it?</a> •
    <a href="#documentation">Documentation</a> •
    <a href="#classes">Classes</a> •
    <a href="#attributes">Attributes</a> •
    <a href="#manipulators">Manipulators</a> •
    <a href="#custom-elements">Custom Elements</a>
</p>

# Key Features

* Reduce boilerplate code in every class when working with UXML and USS by leveraging c# attributes
* Provide a better framework for input handleing without the hassel of writing custom manipulators
* Provide a set of base classes which remove alot of general editor scripting boilerplate
* Act as a library of missing controls from the built in set of controls - TexturePreview, PathPicker, etc

#### NOTE: This is a library for coders to help them make unity UI's easier when using UIElements, if you are looking for something a little more friendly i suggest you check out [Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)

# What it looks like?

First lets start out with an example VisualElement that you'd write if you didn't use this library and then we'll show that same example VisualElement if you did write it with this library so you can see how much boilerplate code goes way.

Given these UXML and USS files the below the code turns them into an element that can pan around its child element with right mouse click.
```xml
<?xml version="1.0" encoding="utf-8"?>
<UXML xmlns="UnityEngine.Experimental.UIElements">
    <VisualElement name="content" class="fill">
        <VisualElement name="frame">
            <VisualElement name="texture" class="logo" />
        </VisualElement>
    </VisualElement>
</UXML>
```

```cs
.fill {
    position: absolute;
    top: 0px;
    bottom: 0px;
    right: 0px;
    left: 0px;
}
.logo {
    background-image: Resource("RedOwl/Demo/Logo")
}
```

<details>
  <summary>The Unity Only Way (click to open)</summary><p>

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;

namespace RedOwl.Demo
{
    public class PanManipulator : MouseManipulator
    {
        private Action<Vector2> callback
		private Vector2 _mouseStart;
		private bool _active;

		public PanManipulator(Action<Vector2> callback, params ManipulatorActivationFilter[] filters) : base()
		{
            base()
            foreach (var filter in filters)
            {
                activators.Add(filter)
            }
			this.callback = callback;
			_active = false;
		}
		
		protected override void RegisterCallbacksOnTarget()
		{
			target.RegisterCallback<MouseDownEvent>(OnMouseDown);
			target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
			target.RegisterCallback<MouseUpEvent>(OnMouseUp);
		}

		protected override void UnregisterCallbacksFromTarget()
		{
			target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
			target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
			target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
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
				_mouseStart = evt.localMousePosition;
				_active = true;
				target.CaptureMouse();
				evt.StopPropagation();
			}
		}

		protected void OnMouseMove(MouseMoveEvent evt)
		{
			if (!_active || !target.HasMouseCapture()) return;
			callback(evt.localMousePosition - _mouseStart);
			_mouseStart = evt.localMousePosition;
			evt.StopPropagation();
		}

		protected void OnMouseUp(MouseUpEvent evt)
		{
			if (!_active || !target.HasMouseCapture() || !CanStopManipulation(evt)) return;
			_active = false;
			target.ReleaseMouse();
			evt.StopPropagation();
		}
    }

    public class Demo : EditorWindow
    {
        const string uxmlPath = "RedOwl/Demo/DemoLayout";
        const string ussPath = "RedOwl/Demo/DemoStyle";

        VisualElement frame;

        [MenuItem("Tools/Unity")]
        public static void Open()
        {
            var wnd = GetWindow<Demo>();
        }

        public void OnEnable()
        {
            var root = this.GetRootVisualContainer();
            var visualTree = Resources.Load<VisualTreeAsset>(uxmlPAth);
            visualTree.CloneTree(root, null);
            root.AddStyleSheetPath(ussPath);

            frame = root.Q("frame");

            root.AddManipulator(OnPath, new ManipulatorActivationFilter { button = MouseButton.RightMouse})
        }
        
        public void OnPan(Vector2 delta)
        {
            Vector3 current = frame.transform.position;
            frame.transform.position = new Vector3(current.x + delta.x, current.y + delta.y, -100f);
        }
    }
}
```
</p></details>

<details>
  <summary>The Red Owl Way (click to open)</summary><p>

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using RedOwl.Editor;

namespace RedOwl.Demo
{
    [UXML, USS]
    public class Demo : RedOwlEditorWindow<Demo>, IOnMouse
    {
        [UXMLReference]
        VisualElement frame;

        [MenuItem("Tools/RedOwl")]
        public static void Open()
        {
            EnsureWindow();
        }
        
        public IEnumerable<MouseFilter> MouseFilters {
            get {
                yield return new MouseFilter { 
                    button = MouseButton.RightMouse,
                    OnMove = OnPan
                };
            }
        }
        
        public void OnPan(MouseMoveEvent evt, Vector2 delta)
        {
            Vector3 current = frame.transform.position;
            frame.transform.position = new Vector3(current.x + delta.x, current.y + delta.y, -100f);
        }
    }
}
```
</p></details>

There are 104 lines of code in the Unity way and there are only 34 in the RedOwl way.  Both achive the same end result, one just has you writing alot more code over and over and over for each editor window.  The point of this library is to abstract away that boilerplate code so that every VisualElement or EditorWindow has access to it and you don't have to write it over and over and over.  On top of reducing the redundent code it also keeps a very clear seperation of concerns, your C# is truely closer to being just business logic instead of being both business logic and ui hookup code.

BUT!!!  I don't wanna use your base classes.  Well then you are in luck, you don't have to - if you looked at the `RedOwlVisualElement` base class you'd notice that its very sparse.  Thats because all that sweet sweet functionality is offloaded into a utility function so you can do this if you need to.

```cs
public class DemoElement : VisualElement, IOnMouse
{
    VisualElement frame;
 
    public DemoElement()
    {
        RedOwlUtils.Setup(this, this);  //Here is where the magic happens
    }
 
    [UICallback(1, true)]
    private void InitUI()
    {
        frame = new VisualElement();
    }
 
    public IEnumerable<MouseFilter> MouseFilters {
        get {
            yield return new MouseFilter {
                button = MouseButton.RightMouse,
                OnMove = OnPan
            };
        }
    }
 
    private void OnPan(MouseMoveEvent evt, Vector2 delta)
    {
        Vector3 current = frame.transform.position;
        frame.transform.position = new Vector3(current.x + delta.x, current.y + delta.y, -100f);
    }
}
```

So from here on out when we refer to `RedOwlClasses` we mean any class that has been run through the `RedOwlUtils.Setup` function.  The RedOwl variants of Unity's classes all have this called on them at the appropreiate time and place so you don't have to worry about it.

# Installation

The best method if you are using Unity > 2018.3 is via the new package manager.

- In your unity project root open `Packages/manifest.json`
- Add the following line to the dependencies section `"com.redowl.editor.uiex": "https://github.com/rocktavious/UIEX.git",`
- Open Unity and the package should download automatically

If you are using Unity < 2018.3 - i'm sorry you are out of luck, UIElements is only useable in this version of unity or higher

# Documentation

The following documentation assumes you have a little bit of familiarity with c# and Unity's new UI Elements system - if not go read about it [here](https://docs.unity3d.com/Manual/UIElements.html)

## Classes

Collectively the following class will be refered to as the `RedOwlClasses` for purposes of understanding what features only work within these classes

<details>
  <summary>Classes Documentation</summary><p>

### RedOwlVisualElement (Gold)

This is an abstract base class that derives from `VisualElement` and takes care of all the boiler plate for UIElements - The class is so stupidly simple that i'm going to link it here for you to go read, trust me its really short [so go read it](https://github.com/rocktavious/UIEX/blob/master/Assets/RedOwl/Editor/UIEX/RedOwlVisualElement.cs)

Back? HAHA! Ok so maybe I cheated you a little bit when I said it was simple - all of the functionality is bound up in the [utilities class](https://github.com/rocktavious/UIEX/blob/master/Assets/RedOwl/Editor/UIEX/RedOwlUtils.cs)

But even still its pretty crazy how simple it is.  This code has eliminated a TON of boilerplate from all of my UIElements classes that I no longer want to write UIElements code without this library (and I hope you eventually do too!)

### RedOwlEditor (Alpha)

NOT FOR USE YET - this class in intended to be the editor class for inline field and property inspectors

### RedOwlAssetEditor (Alpha)

This class is inteded to provide some Quality of Life improvements when writing an editor window which is to provide as the editor for for scriptable objects - this editor window maybe eventually be merged with RedOwlEditorWindow - i'm not sure yet - as it will sort of overlap in functionality with RedOwlEditorWindow and RedOwlInspector - not ready for use yet

### RedOwlEditorWindow (Beta)

This class bring together the RedOwlUtils functions into a Unity EditorWindow class that builds its UI using UIElements.  This class is still under heavy development so i won't document it here yet, but it has a few Quailty of Life improvments that make working with editor windows much much easier - go read the code if you want to know more!

Almost all of the example code in this readme is deriving from `RedOwlVisualElement` but anything you can do with that class you can do with this class just the same.

### RedOwlInspector (Alpha)

NOT FOR USE YET - this class is intended to be the inspector class to build custom inspectors for custom types but in Unity 2018.3 the Inspector Window does not yet support UIElements inspectors

</p></details>

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

Would load the UXML file `Resources/RedOwl/Demo.uss`

If the path given is blank it will build a path from the classes namespace and class name with a suffix of `Layout`

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
<UXML xmlns="UnityEngine.Experimental.UIElements" xmlns:ro="RedOwl.Editor">
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

TBD

### TextureCanvas (Alpha)

### PathPicker (Alpha)

### FloatSlider / IntSlider (Beta)
