using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.Callbacks;

namespace RedOwl.Editor
{
    [InitializeOnLoad]
    public static class UIEX
    {
        public static Texture2D Background;

        [DidReloadScripts]
        static UIEX()
		{
			Background = ResourceManager.LoadTexture("EditorResources/Textures/background.png");
        }
    }
}
