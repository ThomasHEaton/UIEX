---
layout: default
title: UXML
parent: Attributes
nav_order: 1
---

<dl>
  <dt>Name</dt>
  <dd>UXML</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

## Parameters
---

<dl>
  <dt>Path</dt>
  <dd>string (default: "")</dd>
</dl>

It can only be placed on: classes

## Examples
---

Place this attribute on `RedOwlClasses` and it will load the UXML file `Resources/RedOwl/Demo.uxml`

```cs
namespace RedOwl.Demo
{
    [UXML("RedOwl/Demo")]
    public class DemoElement : RedOwlVisualElement {}
}
```

If the path given is blank it will build a path from the namespace and class name with a suffix of `Layout` like this `Resources/RedOwl/Demo/DemoElementLayout.uxml`

```cs
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement {}
}
```
