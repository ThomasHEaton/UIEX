using System;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    [USS("RedOwl/Editor/Styles")]
    public abstract class RedOwlBaseField<T> : BaseField<T>
    {
        public bool IsInitalized { get; protected set; }
        
        public RedOwlBaseField() : base()
        {
            if (IsInitalized) return;
            RedOwlUtils.Setup(this, this);
            BuildUI();
            IsInitalized = true;
        }

        protected virtual void BuildUI() {}
    }
}
