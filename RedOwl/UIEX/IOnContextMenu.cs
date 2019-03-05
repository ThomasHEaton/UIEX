using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    public interface IOnContextMenu
    {
        void OnContextMenu(ContextualMenuPopulateEvent  evt);
    }
}
