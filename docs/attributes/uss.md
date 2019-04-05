---
layout: default
title: USS
parent: Attributes
---

<dl>
  <dt>Name</dt>
  <dd>USS</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

Place any number of these attributes on `RedOwlClasses` and it will load the USS file

## Parameters
---

<dl>
  <dt>Path</dt>
  <dd>string (default: "")</dd>
</dl>

It can only be placed on: classes

## Examples
---

If the path given is blank it will build a path from the classes namespace and class name with the suffix `Style`

The following example would load and attach the USS files `Resources/RedOwl/Demo/DemoElementStyle.uss` and `Resources/RedOwl/Styles.uss`

```cs
namespace RedOwl.Demo
{
    [USS, USS("RedOwl/Styles")]
    public class DemoElement : RedOwlVisualElement {}
}
```
