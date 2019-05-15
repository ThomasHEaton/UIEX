---
layout: default
title: Visual Element
parent: Classes
---

# visual-element

NameRedOwlVisualElementNamespaceRedOwl.EditorStatusStable

This is an abstract base class that derives from `VisualElement`

## Constructors

## Fields & Properties

IsInitializedbool

## Methods

BuildUIA virtual method you can override to implement ui building logic at the right lifecycle time

## Examples

```csharp
using UnityEngine.UIElements;
using RedOwl.Editor;

namespace RedOwl.Demo
{
    [UXML, USS]
    public class DemoElement : RedOwlVisualElement
    {
        [UXMLReference]
        VisualElement frame;

        protected override void BuildUI()
        {
            //Create UI programmatically here
        }
    }
}
```

