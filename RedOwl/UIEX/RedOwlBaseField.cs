using System;
using UnityEngine.UIElements;

namespace RedOwl.Editor
{
    [USS("RedOwl/Editor/Styles")]
    public abstract class RedOwlBaseField<T> : BaseField<T>
    {
        public bool IsInitalized { get; protected set; }
        
        public RedOwlBaseField() : base("", null)
        {
            if (IsInitalized) return;
            RedOwlUtils.Setup(this, this);
            BuildUI();
            IsInitalized = true;
        }

        protected virtual void BuildUI() {}
    }
}