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
	[UXML]
    public class TextureCanvas : RedOwlVisualElement
    {		
	    public new class UxmlFactory : UxmlFactory<TextureCanvas, UxmlTraits> {}
	    
	    public new class UxmlTraits : VisualElement.UxmlTraits
	    {
		    UxmlBoolAttributeDescription _transparent = new UxmlBoolAttributeDescription { name = "transparent" };

		    public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		    {
			    get { yield break; }
		    }

		    public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
		    {
			    var target = (TextureCanvas)ve;
			    base.Init(ve, bag, cc);
			    target.transparent = _transparent.GetValueFromBag(bag, cc);
		    }
	    }
	    
	    private IMGUIContainer background;
	    
	    private bool show = true;
	    public void Show() { show = true; }
	    public void Hide() { show = false; }
	    
	    private bool transparent;

	    private int _CanvasSize = -1;
	    public int CanvasSize {
	    	get { return _CanvasSize; }
	    	set {
	    		this.style.width = value;
	    		this.style.height = value;
	    		_CanvasSize = value;
	    	}
	    }
	    
	    private int width {
	    	get { return (_texture != null && _CanvasSize == -1) ? _texture.width : _CanvasSize; }
	    }
	    
	    private int height {
	    	get { return (_texture != null && _CanvasSize == -1) ? _texture.height : _CanvasSize; }
	    }

	    private Texture _texture;
	    public Texture texture {
	    	get { return _texture; }
	    	set {
	    		var rt = _texture as RenderTexture;
	    		if (rt != null) rt.Release();
	    		_texture = value;
	    	}
	    }
		
	    public TextureCanvas() : base() {}
	    
	    [UICallback(1, true)]
	    private void CreateUI()
	    {
	    	background = new IMGUIContainer(UpdateUI);
	    	background.AddToClassList("fill");
	    	Add(background);
	    }
	    
	    private void UpdateUI()
	    {
	    	if (_texture != null && show)
	    	{
	    		if (transparent)
	    		{
	    			GUI.DrawTexture(new Rect(0, 0, width, height), _texture);
	    		} else {
			    	EditorGUI.DrawTextureTransparent(new Rect(0, 0, width, height), _texture);
	    		}
	    	}
	    }
    }
}
