---
layout: default
title: UXMLReference
parent: Attributes
---

<dl>
  <dt>Name</dt>
  <dd>USSClass</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

Place any number of these attributes on `RedOwlClasses` and it will add a USS class to this element

<blockquote class="label bg-grey-dk-100">It can only be placed on: classes</blockquote>

### Parameters
---

<dl>
  <dt>Names</dt>
  <dd>params string[]</dd>
</dl>

### Examples
---

The attributes are inherited so the resulting classes on `DemoElement2` would be `["vertical","red","fill"]`

```cs
namespace RedOwl.Demo
{
    [USSClass("vertical", "red")]
    public class DemoElement : RedOwlVisualElement {}

    [USSClass("fill")]
    public class DemoElement2 : DemoElement {}
}
```
