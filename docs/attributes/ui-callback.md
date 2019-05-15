---
layout: default
title: UICallback
parent: Attributes
---

# ui-callback

NameUICallbackNamespaceRedOwl.EditorStatusStable

Use this attribute on `RedOwlClasses` methods to automatically schedule for callback at certain intervals

> It can only be placed on: methods

## Parameters

IntervalintegerOnlyOncebool \(default: false\)

## Examples

The first function's attribute is given a "true" argument which tells the system to only schedule the callback once after the delay given

```csharp
namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        [UICallback(100)]
        void UpdateUI() { Debug.Log("Will be called every 100ms!"); }
    }
}
```

