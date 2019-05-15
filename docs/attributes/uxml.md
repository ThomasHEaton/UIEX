---
layout: default
title: UXML
parent: Attributes
---

# uxml

NameUXMLNamespaceRedOwl.EditorStatusStable

Place this attribute on `RedOwlClasses` and it will load the UXML file

> It can only be placed on: classes

## Parameters

Pathstring \(default: ""\)

## Examples

The first example would load the UXML file `Resources/RedOwl/Demo.uxml`

```csharp
namespace RedOwl.Demo
{
    [UXML("RedOwl/Demo")]
    public class DemoElement : RedOwlVisualElement {}
}
```

If the path given is blank it will build a path from the namespace and class name with a suffix of `Layout` like this `Resources/RedOwl/Demo/DemoElementLayout.uxml`

```csharp
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement {}
}
```

