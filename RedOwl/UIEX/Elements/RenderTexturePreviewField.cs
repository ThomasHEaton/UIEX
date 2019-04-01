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
    public class RenderTexturePreviewField : TexturePreviewField<RenderTexture>
    {
	    public new class UxmlFactory : UxmlFactory<RenderTexturePreviewField, UxmlTraits> {}
	    
	    public new class UxmlTraits : TexturePreviewField<RenderTexture>.UxmlTraits {}

        public RenderTexturePreviewField() : base() {}
    }
}
