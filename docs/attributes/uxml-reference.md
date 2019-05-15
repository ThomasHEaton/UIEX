---
layout: default
title: UXMLReference
parent: Attributes
---

# uxml-reference

NameUXMLReferenceNamespaceRedOwl.EditorStatusBeta

Use this attribute on `RedOwlClasses` to populate the field with the uxml object loaded from the UXML file using the query system

> It can only be placed on: fields

## Parameters

Namestring \(default: ""\)

## Examples

If the name given is blank it will use the fields name to query for the element within the loaded UXML

```csharp
namespace RedOwl.Demo
{
    [UXML]
    public class DemoElement : RedOwlVisualElement
    {
        [UXMLReference]
        VisualElement Content;

        [UXMLReference("SideBar")]
        VisualElement Navigation;

        [UXMLReference]
        TextureCanvas Canvas;
    }
}
```

With the below UXML these `DemoElement` fields would be populated with references to the elements written in the UXML file

```markup
<?xml version="1.0" encoding="utf-8"?>
<UXML xmlns="UnityEngine.UIElements" xmlns:ro="RedOwl.Editor">
    <VisualElement name="Content">
        <VisualElement name="SideBar" />
    </VisualElement>
    <ro:TextureCanvas name="Canvas" />
</UXML>
```

NOTE: the type of the field is taken into consideration and an error will be thrown if it does not match the element found

