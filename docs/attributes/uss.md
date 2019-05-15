---
layout: default
title: USS
parent: Attributes
---

# uss

NameUSSNamespaceRedOwl.EditorStatusStable

Place any number of these attributes on `RedOwlClasses` and it will load the USS file

> It can only be placed on: classes

## Parameters

Pathstring \(default: ""\)

## Examples

If the path given is blank it will build a path from the classes namespace and class name with the suffix `Style`

The following example would load and attach the USS files `Resources/RedOwl/Demo/DemoElementStyle.uss` and `Resources/RedOwl/Styles.uss`

```csharp
namespace RedOwl.Demo
{
    [USS, USS("RedOwl/Styles")]
    public class DemoElement : RedOwlVisualElement {}
}
```

