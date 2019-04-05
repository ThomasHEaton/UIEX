---
layout: default
title: Font Awesome
parent: Custom Elements
---

<dl>
  <dt>Name</dt>
  <dd>FontAwesome</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

This custom element allows you to use FontAwesome icons (free only) in your unity editor ui's - https://fontawesome.com

### Constructors
---
TBD

### Fields & Properties
---
TBD

### Methods
---
TBD

### Examples
---

#### C#
```csharp
using RedOwl.Editor;

namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        FontAwesome obj;

        [UICallback(1, true)]
        void InitializeUI() {
            obj = new FontAwesome("solid", "fa-chevron-right")
            Add(obj);
        }

        [UICallback(500)]
        void UpdateUI() {
            if (obj.icon == "fa-chevron-right") obj.icon = "fa-chevron-down";
            else obj.icon = "fa-chevron-right";
        }
    }
}
```

#### UXML
```xml
<UXML xmlns="UnityEngine.UIElements" xmlns:ue="UnityEditor.UIElements" xmlns:ro="RedOwl.Editor">
    <VisualElement class="container row">
        <ue:ToolbarButton class="container row"><ro:FontAwesome type="solid" icon="fa-chevron-down" width="25" height="25" /></ue:ToolbarButton>
        <ro:FontAwesome type="solid" icon="fa-address-card" width="25" height="25" />
        <Label name="title" text="Title" />
    </VisualElement>
</UXML>
```