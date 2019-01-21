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

	    public int CanvasSize = -1;
	    
	    private int width {
	    	get { return (texture != null && CanvasSize == -1) ? texture.width : CanvasSize; }
	    }
	    
	    private int height {
	    	get { return (texture != null && CanvasSize == -1) ? texture.height : CanvasSize; }
	    }

	    private RenderTexture _paint;
	    private Texture2D _texture;
	    public Texture2D texture {
	    	get { return _texture; }
	    	set {
	    		_paint = new RenderTexture(value.width, value.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
		    	_paint.filterMode = value.filterMode;
		    	Graphics.Blit(value, _paint);
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
	    	if (_paint != null && show)
	    	{
	    		if (transparent)
	    		{
	    			GUI.DrawTexture(new Rect(0, 0, width, height), _paint);
	    		} else {
			    	EditorGUI.DrawTextureTransparent(new Rect(0, 0, width, height), _paint);
	    		}
	    	}
	    }
    }
}
