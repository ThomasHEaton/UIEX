---
layout: default
title: Query
parent: Attributes
---

<dl>
  <dt>Name</dt>
  <dd>Query</dd>
  <dt>Namespace</dt>
  <dd>RedOwl.Editor</dd>
  <dt>Status</dt>
  <dd><span class="label label-yellow">Beta</span></dd>
</dl>

Use this attribute on `RedOwlClasses` methods to provide uQuery functionality in a more buttoned up way by having a function be called when the element is found

<blockquote class="label bg-grey-dk-100">It can only be placed on: methods</blockquote>

### Parameters
---

<dl>
  <dt>Name</dt>
  <dd>string (default: null)</dd>
  <dt>Classes</dt>
  <dd>params string[] (default: null)</dd>
</dl>

### Examples
---

Q - Find a single element and call the function
Query - Find multiple elements and call the function for each

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
