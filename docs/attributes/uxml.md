---
layout: default
title: UXML
parent: Attributes
nav_order: 1
---

<dl>
  <dt class="bg-grey-dk-000">Name</dt>
  <dd>UXML</dd>
  <dt class="bg-grey-dk-000">Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt class="bg-grey-dk-000">Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

## Examples
---

Place this attribute on any `RedOwlClasses` and it will load the UXML file

```cs
namespace RedOwl.Demo
{
    [UXML("RedOwl/Demo")]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load the UXML file `Resources/RedOwl/Demo.uxml`

If the path given is blank it will build a path from the classes namespace and class name with a suffix of `Layout` as show below

```cs
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement {}
}
```

Would load the UXML file `Resources/RedOwl/Demo/DemoElementLayout.uxml`
