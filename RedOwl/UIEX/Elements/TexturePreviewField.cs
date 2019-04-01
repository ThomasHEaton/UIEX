#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
	[USSClass("TexturePreview")]
    public abstract class TexturePreviewField<T> : PreviewField<T> where T : Texture
    {
	    public new class UxmlTraits : VisualElement.UxmlTraits
	    {
		    UxmlBoolAttributeDescription _transparent = new UxmlBoolAttributeDescription { name = "transparent" };

		    public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		    {
			    get { yield break; }
		    }

		    public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
		    {
			    var target = (TexturePreviewField<T>)ve;
			    base.Init(ve, bag, cc);
			    target.transparent = _transparent.GetValueFromBag(bag, cc);
		    }
	    }

	    public bool transparent;
	    
	    private int width {
	    	get { return (value != null && CanvasSize == -1) ? value.width : CanvasSize; }
	    }
	    
	    private int height {
	    	get { return (value != null && CanvasSize == -1) ? value.height : CanvasSize; }
	    }

	    public T texture {
	    	get { return value; }
	    	set {
	    		var rt = value as RenderTexture;
	    		if (rt != null && rt != RenderTexture.active) rt.Release();
	    		this.value = value;
	    	}
	    }
		
	    public TexturePreviewField() : base() {}
		
        public TexturePreviewField(bool transparent) : base()
        {
            this.transparent = transparent;
        }
	    
	    protected override void UpdateUI()
	    {
			container.style.minWidth = width;
			container.style.minHeight = height;
			if (transparent)
			{
				GUI.DrawTexture(new Rect(0, 0, width, height), value);
			} else {
				EditorGUI.DrawTextureTransparent(new Rect(0, 0, width, height), value);
			}
	    }
    }

	public class TexturePreviewField : TexturePreviewField<Texture>
	{
	    public new class UxmlFactory : UxmlFactory<TexturePreviewField, UxmlTraits> {}
	    
	    public new class UxmlTraits : TexturePreviewField<Texture>.UxmlTraits {}

		public TexturePreviewField() : base() {}
	}
}
