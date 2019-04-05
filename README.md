<h1 align="center">UIEX</h1>
<h4 align="center">UIElementsX (UIEX) is the missing high level API for unity's new UI system.</h4>

<p align="center">
    <a href="#introduction">Introduction</a> •
    <a href="#installation">Installation</a> •
    <a href="https://redowlgames.com/UIEX">Documentation</a>
</p>

# Key Features

* Reduce boilerplate code when working with UIElementts
* Provide a clean framework for input handleing without writing custom manipulators
* Provide a set of base classes which remove alot of general editor scripting boilerplate
* Act as a library of missing controls from the built in set of controls

#### NOTE: This is a library for coders to help them make unity UI's easier and faster when using UIElements, if you are looking for something a little more friendly i suggest you check out [Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)

<h2 align="center">
	If this library helps you out consider 
<link href="https://fonts.googleapis.com/css?family=Lato&subset=latin,latin-ext" rel="stylesheet"><a class="bmc-button" target="_blank" href="https://www.buymeacoffee.com/hu2HD8AkM"><span style="margin-left:5px">buying me a coffee!</span><img src="https://www.buymeacoffee.com/assets/img/BMC-btn-logo.svg" alt="Buy me a coffee"></a>	
</h2>

# Introduction

First lets start out with an example VisualElement that you'd write if you didn't use this library and then we'll show that same example VisualElement if you did write it with this library so you can see how much boilerplate code goes way.

Given these UXML and USS files the below the code turns them into an element that can pan around its child element with right mouse click.

<details>
  <summary>Source for UXML and USS (click to open)</summary><p>
```xml
<?xml version="1.0" encoding="utf-8"?>
<UXML xmlns="UnityEngine.UIElements">
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

</p></details>

<details>
  <summary>The Unity Only Way (click to open)</summary><p>

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

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
using UnityEngine.UIElements;
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
</p></details><br />

There are 104 lines of code in the Unity way and there are only 34 in the RedOwl way but both achive the same end result.

On top of reducing the redundent code it also help you keep a very clear seperation of concerns, your C# is truely closer to being just business logic instead of being both business logic and ui hookup / input handling hookup code.

### But I don't wanna use your base classes!!!

Well then you are in luck, you don't have to - if you looked at the `RedOwlVisualElement` base class you'd notice that its very sparse.  Thats because all that sweet sweet functionality is offloaded into a utility function so you can do this if you need to.

<details>
  <summary>Unity + RedOwl (click to open)</summary><p>

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using RedOwl.Editor;

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
</p></details><br />

So from here on out when we refer to `RedOwlClasses` we mean any class that has been run through the `RedOwlUtils.Setup` function.  The RedOwl variants of Unity's classes all have this called on them at the appropreiate time and place so you don't have to worry about it.

# Installation

The best method if you are using Unity > 2018.3 is via the new package manager.

- In your unity project root open `Packages/manifest.json`
- Add the following line to the dependencies section `"com.redowl.editor.uiex": "https://github.com/rocktavious/UIEX.git",`
- Open Unity and the package should download automatically

If you are using Unity < 2018.3 - i'm sorry you are out of luck, UIElements is only useable in this version of unity or higher
