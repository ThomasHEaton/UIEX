#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    public interface IPreviewField
    {
        int CanvasSize { get; set; }
    }

    public abstract class PreviewField<T> : RedOwlBaseField<T>, IPreviewField
    {	    
	    protected IMGUIContainer container;

	    private int _CanvasSize = -1;
	    public int CanvasSize {
	    	get { return _CanvasSize; }
	    	set {
	    		this.style.minWidth = value;
	    		this.style.minHeight = value;
	    		_CanvasSize = value;
	    	}
	    }

        public PreviewField() : base() {}
	    
	    [UICallback(1, true)]
	    protected void CreateUI()
	    {
	    	container = new IMGUIContainer(() => {
                if (value != null)
                    UpdateUI();
            });
	    	Add(container);
	    }
	    
	    protected abstract void UpdateUI();
    }
}
