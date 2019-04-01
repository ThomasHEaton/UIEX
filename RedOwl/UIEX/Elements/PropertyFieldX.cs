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
    [USSClass("horizontal")]
    public abstract class PropertyFieldX : RedOwlVisualElement
    {
        public LabelX label = new LabelX();
        public bool IsReadonly { get; protected set; }
        public bool AsSlider { get; set; }

        public abstract void UpdateField();
    }

    public class PropertyFieldX<T> : PropertyFieldX
    {
        private Func<T> getter;
        private Action<T> setter;

        private INotifyValueChanged<T> field;

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

        public override void UpdateField()
        {
            if (field != null)
                field.value = Value;
        }
        
        [UICallback(1, true)]
        private void CreateUI()
        {
            Type type = typeof(T);
            var element = CreateField(type);
            if (element != null)
            {
                element.AddToClassList("unity-property-field-input");
                element.AddToClassList("nowrap");
                field = element as INotifyValueChanged<T>;
                if (field != null)
                {
                    field.OnValueChanged(evt => { SetValue(evt.newValue); });
                    UpdateField();
                }
                this.Add(element);
            }
        }

        private VisualElement CreateField(Type type)
        {
            if (!string.IsNullOrEmpty(label.text))
            {
                this.Add(label);
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                    var field = new TextField();
                    field.maxLength = 1;
                    return field;
                case TypeCode.String:
                    return new TextField();
                case TypeCode.Boolean:
                    return new Toggle();
                case TypeCode.Single:
                    if (AsSlider)
                    {
                        return new FloatSlider();
                    } else {
                        return new FloatField();
                    }
                case TypeCode.Double:
                    return new DoubleField();
                case TypeCode.Int16:
                case TypeCode.Int32:
                    if (AsSlider)
                    {
                        return new IntegerSlider();
                    } else {
                        return new IntegerField();
                    }
                case TypeCode.Int64:
                    if (AsSlider)
                    {
                        return new LongSlider();
                    } else {
                        return new LongField();
                    }
            }
            return CreateUnityField(type);
        }

        private VisualElement CreateUnityField(Type type)
        {
            if (typeof(Texture).IsAssignableFrom(type))
            {
                VisualElement element;
                if (typeof(Texture2D).IsAssignableFrom(type))
                    element = new Texture2DPreviewField();
                else if (typeof(RenderTexture).IsAssignableFrom(type))
                    element = new RenderTexturePreviewField();
                else
                    element = new TexturePreviewField();
                IPreviewField field = element as IPreviewField;
                field.CanvasSize = 64;
                return element;
            }
            if (typeof(Vector2).IsAssignableFrom(type))
            {
                return new Vector2Field();
            }
            if (typeof(Vector3).IsAssignableFrom(type))
            {
                return new Vector3Field();
            }
            if (typeof(Vector4).IsAssignableFrom(type))
            {
                return new Vector4Field();
            }
            if (typeof(Vector2Int).IsAssignableFrom(type))
            {
                return new Vector2IntField();
            }
            if (typeof(Vector3Int).IsAssignableFrom(type))
            {
                return new Vector3IntField();
            }
            if (typeof(Color).IsAssignableFrom(type) || typeof(Color32).IsAssignableFrom(type))
            {
                return new ColorField();
            }
            if (typeof(Gradient).IsAssignableFrom(type))
            {
                return new GradientField();
            }
            if (typeof(LayerMask).IsAssignableFrom(type))
            {
                return new LayerMaskField();
            }
            if (typeof(AnimationCurve).IsAssignableFrom(type))
            {
                return new CurveField();
            }
            if (typeof(Rect).IsAssignableFrom(type))
            {
                return new RectField();
            }
            if (typeof(RectInt).IsAssignableFrom(type))
            {
                return new RectIntField();
            }
            if (typeof(Bounds).IsAssignableFrom(type))
            {
                return new BoundsField();
            }
            if (typeof(BoundsInt).IsAssignableFrom(type))
            {
                return new BoundsIntField();
            }
            if (typeof(Enum).IsAssignableFrom(type))
            {
                return new PopupField<string>(Enum.GetNames(type).ToList(), 0);
            }
            Debug.LogWarningFormat("Unable to create PropertyFieldX for: {0}", type);
            return null;
        }
    }
}
