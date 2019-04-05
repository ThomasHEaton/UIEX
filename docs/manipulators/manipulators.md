---
layout: default
title: Manipulators
nav_order: 1
has_children: true
permalink: /docs/manipulators
---

## Manipulators

The manipulators system has been generalized to allow for more easily defining callbacks within your `RedOwlClasses` without having to write your own manipulator class - this gets you back closer to how IMGUI worked while still retaining the UI Event bubbling improvements of UIElements

The core of the Mouse and Keyboard manipulators is that they've been written to be generic by takeing "config" structs which help them decide where to send the events too

The interfaces you have to implement help the system know that when to hook up a manipulator and ask for your filter "config" structs

Some of the callback methods have extra data which is generally useful when working with that kind of input event - such as the `MouseFilters.OnMove` callback gives you a delta of the mouse movement between callbacks, but all of the callback methods also passthrough the original event if you want to get at other properites or methods defined on that type of event - IE `evt.StopPropagation()`

<blockquote >**NOTE:*** while the manipulators will automatically hook themseleves up inside `RedOwlClasses` this does not mean you cannot use these manipulators with other UIElements classes.  You could still apply this manipulators to non `RedOwlClasses` and feed them the "config" structs and they would still work properly outside of  `RedOwlClasses`</blockquote>