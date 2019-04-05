---
layout: default
title: UICallback
parent: Attributes
---

<dl>
  <dt>Name</dt>
  <dd>UICallback</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-green">Stable</span></dd>
</dl>

Use this attribute on `RedOwlClasses` methods to automatically schedule for callback at certain intervals

## Parameters
---

<dl>
  <dt>Interval</dt>
  <dd>integer</dd>
  <dt>OnlyOnce</dt>
  <dd>bool (default: false)</dd>
</dl>

It can only be placed on: methods

## Examples
---

The first function's attribute is given a "true" argument which tells the system to only schedule the callback once after the delay given

```cs
namespace RedOwl.Demo
{
    public class DemoElement : RedOwlVisualElement
    {
        [UICallback(1, true)]
        void InitializeUI() { Debug.Log("Will only be called once after a 1ms delay!"); }

        [UICallback(100)]
        void UpdateUI() { Debug.Log("Will be called every 100ms!"); }
    }
}
```
