---
layout: default
title: UXMLReference
parent: Attributes
nav_order: 1
---

<dl>
  <dt>Name</dt>
  <dd>USSClass</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

## Parameters
---

<dl>
  <dt>Names</dt>
  <dd>params string[]</dd>
</dl>

It can only be placed on: classes

## Examples
---

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
