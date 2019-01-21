#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;

namespace RedOwl.Editor
{
	[UXML]
    public class TextureCanvas : RedOwlVisualElement
    {		
	    public new class UxmlFactory : UxmlFactory<TextureCanvas> {}
	    
	    private IMGUIContainer background;

	    public int CanvasSize = -1;
	    
	    private int width {
	    	get { return (texture != null && CanvasSize == -1) ? texture.width : CanvasSize; }
	    }
	    
	    private int height {
	    	get { return (texture != null && CanvasSize == -1) ? texture.height : CanvasSize; }
	    }

	    public Texture2D texture;
		
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
	    	if (texture != null) EditorGUI.DrawTextureTransparent(new Rect(0, 0, width, height), texture);
	    }
    }
}
