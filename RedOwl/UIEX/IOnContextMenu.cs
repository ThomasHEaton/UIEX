using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
    public interface IOnContextMenu
    {
        void OnContextMenu(ContextualMenuPopulateEvent  evt);
    }
}
