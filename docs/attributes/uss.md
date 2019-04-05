---
layout: default
title: USS
parent: Attributes
nav_order: 1
---

<dl>
  <dt>Name</dt>
  <dd>USS</dd>
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
<dl>

It can only be placed on: classes

## Examples
---

Place any number of these attributes on `RedOwlClasses` and it will load the USS file

Optionally if the path given is blank it will build a path from the classes namespace and class name with the suffix `Style`

```cs
namespace RedOwl.Demo
{
    [USS, USS("RedOwl/Styles")]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load and attach the USS files `Resources/RedOwl/Demo/DemoElementStyle.uss` and `Resources/RedOwl/Styles.uss`
