<h1 align="center">UIEX</h1>
<h4 align="center">UIElementsX (UIEX) is the missing high level API for unity's new UI system.</h4>


<p align="center">
    <a href="#how-it-works">How it works?</a> •
    <a href="#installation">How to get it?</a> •
    <a href="#current-features">Features</a>
</p>

# Key Features

* Turn common UIElements functions for loading UXML and USS into attributes to make it trivial to use them
* Provide a better framework for hooking up input tracking without the hassel of writing manipulators
* Provide a set of base classes which remove alot of general editor scripting boilerplate
* A library of UIElement elements that are missing from the built in set of elements

# How it works?

Here is a example EditorWindow that has mouse and input handling and shows off a number of features

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;
using RedOwl.Editor;

[UXML, USS, USSClass("vertical", "fill")]
public class Demo : RedOwlEditorWindow<Demo>, IOnKeyboard, IOnMouse
{
	[UXMLReference]
	VisualElement Content;
	
	[UXMLReference("SideBar")]
	VisualElement Navigation;
	
	[MenuItem("Tools/Demo")]
	public static void Open()
	{
		EnsureWindow();
	}
	
	public IEnumerable<MouseFilter> MouseFilters {
		get {
			yield return new MouseFilter { 
				button = MouseButton.LeftMouse,
				modifiers = EventModifiers.Control,
				OnMove = OnMouseMove
			};
			yield return new MouseFilter { 
				button = MouseButton.RightMouse,
				modifiers = EventModifiers.None,
				OnMove = OnMouseMove
			};
		}
	}
	
	public IEnumerable<KeyboardFilter> KeyboardFilters {
		get {
			yield return new KeyboardFilter {
				key = KeyCode.F,
				OnDown = OnKeyDown
			};
		}
	}
	
	void OnMouseMove(MouseMoveEvent evt, Vector2 delta)
	{
		Debug.Log(delta);
	}
	
	void OnKeyDown(KeyDownEvent evt)
	{
		Debug.Log(evt.keyCode);
	}
}
```

Here a sample custom element that can pan and zoom

```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using RedOwl.Editor;

[UXML]
public class PanAndZoom : RedOwlVisualElement, IOnMouse, IOnZoom
{
	public new class UxmlFactory : UxmlFactory<PanAndZoom> {}
	
	[UXMLReference]
	VisualElement frame;
	
	public IEnumerable<MouseFilter> MouseFilters {
		get {
			yield return new MouseFilter { 
				button = MouseButton.LeftMouse,
				modifiers = EventModifiers.Control,
				OnMove = OnPan
			};
			yield return new MouseFilter { 
				button = MouseButton.MiddleMouse,
				modifiers = EventModifiers.None,
				OnMove = OnPan
			};
		}
	}
	
	public void OnPan(MouseMoveEvent evt, Vector2 delta)
	{
		Vector3 current = frame.transform.position;
		frame.transform.position = new Vector3(current.x + delta.x, current.y + delta.y, -100f);
	}
	
	public float zoomMinScale { get { return 0.2f; } }
	public float zoomMaxScale { get { return 15f; } }
	public float zoomScaleStep { get { return 0.15f; } }
	public EventModifiers zoomActivationModifiers { get { return EventModifiers.Control; } }		
	public void OnZoom(WheelEvent evt, Vector3 scale)
	{
		frame.transform.scale = scale;
	}
}
```

# Installation

The best method if you are using Unity > 2018.3 is via the new package manager.

- In your unity project root open `Packages/manifest.json`
- Add the following line to the dependencies section `"com.redowl.editor.uiex": "https://github.com/rocktavious/UIEX.git",`
- Open Unity and the package should download automatically

If you are not using using Unity > 2018.3 - i'm sorry you are out of luck, UIElements is only useable in this version of unity or higher

# Current Features

#### This section of the docs is still under heavy WIP

## Classes

### RedOwlVisualElement

### RedOwlEditorWindow

### RedOwlInspector

## Attributes

### UXML

### UXMLReference

### USS

### USSClass

### UICallback

## Manipulators

### RedOwlMouseManipulator

### RedOwlKeyboardManipulator

### RedOwlWheelManipulator

## Custom Elements

### TextureCanvas

### PathPicker

### FloatSlider / IntSlider
