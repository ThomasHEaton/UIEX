---
layout: default
title: UXMLReference
parent: Attributes
nav_order: 1
---

<dl>
  <dt>Name</dt>
  <dd>UXMLReferenc</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

## Parameters
---

<dl>
  <dt>Name</dt>
  <dd>string (default: "")</dd>
<dl>

It can only be placed on: fields

## Examples
---

Use this attribute on `RedOwlClasses` to populate the field with the uxml object loaded from the UXML file using the query system

Optionally if the name given is blank it will use the fields name to query for the element within the loaded UXML

```cs
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

```xml
<?xml version="1.0" encoding="utf-8"?>
<UXML xmlns="UnityEngine.UIElements" xmlns:ro="RedOwl.Editor">
    <VisualElement name="Content">
        <VisualElement name="SideBar" />
    </VisualElement>
    <ro:TextureCanvas name="Canvas" />
</UXML>
```

NOTE: the type of the field is taken into consideration and an error will be thrown if it does not match the element found
