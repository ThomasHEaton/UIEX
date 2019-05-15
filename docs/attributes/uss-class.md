---
layout: default
title: UXMLReference
parent: Attributes
---

# uss-class

NameUSSClassNamespaceRedOwl.EditorStatusBeta

Place any number of these attributes on `RedOwlClasses` and it will add a USS class to this element

> It can only be placed on: classes

## Parameters

Namesparams string\[\]

## Examples

The attributes are inherited so the resulting classes on `DemoElement2` would be `["vertical","red","fill"]`

```csharp
namespace RedOwl.Demo
{
    [USSClass("vertical", "red")]
    public class DemoElement : RedOwlVisualElement {}

    [USSClass("fill")]
    public class DemoElement2 : DemoElement {}
}
```

