using System;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
    [USS("RedOwl/Editor/Styles")]
    public abstract class RedOwlVisualElement : VisualElement
    {				
        public bool IsInitalized { get; protected set; }
        
        public RedOwlVisualElement()
        {
            if (IsInitalized) return;
            RedOwlUtils.Setup(this, this);
            BuildUI();
            IsInitalized = true;
        }

        protected virtual void BuildUI() {}
    }
}
