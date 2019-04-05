---
layout: default
title: Red Owl Keyboard Manipulator
parent: Manipulators
---

<dl>
  <dt>Name</dt>
  <dd>RedOwlKeyboardManipulator</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

The keyboard filter works much like the mouse filter just with a different interface and set of callbacks available

## Example
---

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