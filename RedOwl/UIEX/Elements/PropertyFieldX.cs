#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Linq;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEditor.UIElements;
#else
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    [USSClass("container", "row")]
    public class PropertyFieldX : RedOwlVisualElement
    {
        public LabelX label = new LabelX();
        public bool IsReadonly { get; protected set; }
        public bool AsSlider { get; set; }
    }

    public class PropertyFieldX<T> : PropertyFieldX
    {
        private Func<T> getter;
        private Action<T> setter;

        public T Value {
            get { return getter(); }
            set { setter(value); }
        }

        private void SetValue(object obj) { Value = (T)obj; }

        public PropertyFieldX(Func<T> getter) : base()
        {
            this.getter = getter;
            IsReadonly = true;
        }

        public PropertyFieldX(Func<T> getter, Action<T> setter, bool asSlider = false) : base()
        {
            this.getter = getter;
            this.setter = setter;
            IsReadonly = false;
            AsSlider = asSlider;
        }

        public PropertyFieldX(string label, Func<T> getter, Action<T> setter, bool asSlider = false) : base()
        {
            this.label.text = label;
            this.getter = getter;
            this.setter = setter;
            IsReadonly = false;
            AsSlider = asSlider;
        }
        
        [UICallback(1, true)]
        private VisualElement CreateUI()
        {
            if (!string.IsNullOrEmpty(label.text))
            {
                this.Add(label);
            }
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Char:
                    var field = new TextField();
                    field.maxLength = 1;
                    return CreateField<string, TextField>(field);
                case TypeCode.String:
                    return CreateField<string, TextField>(new TextField());
                case TypeCode.Boolean:
                    return CreateField<bool, Toggle>(new Toggle());
                case TypeCode.Single:
                    if (AsSlider)
                    {
                        return CreateField<float, FloatSlider>(new FloatSlider());
                    } else {
                        return CreateField<float, FloatField>(new FloatField());
                    }
                case TypeCode.Double:
                    return CreateField<double, DoubleField>(new DoubleField());
                case TypeCode.Int16:
                case TypeCode.Int32:
                    if (AsSlider)
                    {
                        return CreateField<int, IntegerSlider>(new IntegerSlider());
                    } else {
                        return CreateField<int, IntegerField>(new IntegerField());
                    }
                case TypeCode.Int64:
                    if (AsSlider)
                    {
                        return CreateField<long, LongSlider>(new LongSlider());
                    } else {
                        return CreateField<long, LongField>(new LongField());
                    }
            }
            return CreateUnityField();
        }

        private VisualElement CreateUnityField()
        {
            if (typeof(Vector2).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Vector2, Vector2Field>(new Vector2Field());
            }
            if (typeof(Vector3).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Vector3, Vector3Field>(new Vector3Field());
            }
            if (typeof(Vector4).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Vector4, Vector4Field>(new Vector4Field());
            }
            if (typeof(Vector2Int).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Vector2Int, Vector2IntField>(new Vector2IntField());
            }
            if (typeof(Vector3Int).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Vector3Int, Vector3IntField>(new Vector3IntField());
            }
            if (typeof(Color).IsAssignableFrom(typeof(T)) || typeof(Color32).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Color, ColorField>(new ColorField());
            }
            if (typeof(Gradient).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Gradient, GradientField>(new GradientField());
            }
            if (typeof(LayerMask).IsAssignableFrom(typeof(T)))
            {
                return CreateField<int, LayerMaskField>(new LayerMaskField());
            }
            if (typeof(AnimationCurve).IsAssignableFrom(typeof(T)))
            {
                return CreateField<AnimationCurve, CurveField>(new CurveField());
            }
            if (typeof(Rect).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Rect, RectField>(new RectField());
            }
            if (typeof(RectInt).IsAssignableFrom(typeof(T)))
            {
                return CreateField<RectInt, RectIntField>(new RectIntField());
            }
            if (typeof(Bounds).IsAssignableFrom(typeof(T)))
            {
                return CreateField<Bounds, BoundsField>(new BoundsField());
            }
            if (typeof(BoundsInt).IsAssignableFrom(typeof(T)))
            {
                return CreateField<BoundsInt, BoundsIntField>(new BoundsIntField());
            }
            if (typeof(Enum).IsAssignableFrom(typeof(T)))
            {
                return CreateField<string, PopupField<string>>(new PopupField<string>(Enum.GetNames(typeof(T)).ToList(), 0));
            }
            Debug.LogWarningFormat("Unable to create PropertyFieldX for: {0} | {1}", typeof(T), typeof(Vector2).IsAssignableFrom(typeof(T)));
            return null;
        }

        private TField CreateField<TFieldType, TField>(TField field) where TField : VisualElement, INotifyValueChanged<TFieldType>
        {
            field.AddToClassList("unity-property-field-input");
            field.AddToClassList("nowrap");
            field.OnValueChanged(evt => { SetValue(evt.newValue); });
            this.Add(field);
            return field;
        }
    }
}
