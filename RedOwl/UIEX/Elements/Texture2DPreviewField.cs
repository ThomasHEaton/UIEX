#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
    public class Texture2DPreviewField : TexturePreviewField<Texture2D>
    {
	    public new class UxmlFactory : UxmlFactory<Texture2DPreviewField, UxmlTraits> {}
	    
	    public new class UxmlTraits : TexturePreviewField<Texture2D>.UxmlTraits {}

		public Texture2DPreviewField() : base() {}
    }
}
