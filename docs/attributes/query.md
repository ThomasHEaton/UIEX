---
layout: default
title: Query
parent: Attributes
---

# query

NameQueryNamespaceRedOwl.EditorStatusBeta

Use this attribute on `RedOwlClasses` methods to provide uQuery functionality in a more buttoned up way by having a function be called when the element is found

> It can only be placed on: methods

## Parameters

Namestring \(default: null\)Classesparams string\[\] \(default: null\)

## Examples

Q - Find a single element and call the function Query - Find multiple elements and call the function for each

```csharp
namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        [Q("prop", "vertical")]
        void OnElementFound(VisualElement element) { /* will be called only once for the first element found with the name prop and class vertical */ }

        [Query(null, "vertical")]
        void OnElementFound(VisualElement element) { /* will be called for each element found with the class vertical */ }
    }
}
```

