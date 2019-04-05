---
layout: default
title: Visual Element
parent: Classes
---

<dl>
  <dt>Name</dt>
  <dd>RedOwlVisualElement</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

This is an abstract base class that derives from `VisualElement`

### Constructors
---



### Fields & Properties
---

<dl>
  <dt>IsInitialized</dt>
  <dd>bool</dd>
</dl>

### Methods
---

<dl>
  <dt>BuildUI</dt>
  <dd>A virtual method you can override to implement ui building logic at the right lifecycle time</dd>
</dl>

### Examples
---

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
