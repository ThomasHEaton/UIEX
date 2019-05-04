using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

namespace RedOwl.Editor
{
    [Serializable]
    public class ResourceManager : ScriptableObject
    {
        private const string ASSETS_PATH = "Assets/";
        private const string PACKAGES_PATH = "Packages/com.redowl.uiex/";
        private const string REDOWL = "RedOwl";

        private static string s_basePath;
        public static string BasePath
        {
            get
            {
                if (!string.IsNullOrEmpty(s_basePath)) return s_basePath;
                var obj = CreateInstance<ResourceManager>();
                UnityEditor.MonoScript s = UnityEditor.MonoScript.FromScriptableObject(obj);
                string assetPath = UnityEditor.AssetDatabase.GetAssetPath(s);
                DestroyImmediate(obj);

                if (assetPath.StartsWith(PACKAGES_PATH))
                {
                    s_basePath = assetPath.Replace("UIEX/ResourceManager.cs", "");
                } else {
                    var fileInfo = new FileInfo(assetPath);
                    UnityEngine.Debug.Assert(fileInfo.Directory != null, "fileInfo.Directory != null");
                    UnityEngine.Debug.Assert(fileInfo.Directory.Parent != null, "fileInfo.Directory.Parent != null");
                    DirectoryInfo baseDir = fileInfo.Directory.Parent;
                    UnityEngine.Debug.Assert(baseDir != null, "baseDir != null");
                    Assert.AreEqual(REDOWL, baseDir.Name);
                    string baseDirPath = baseDir.ToString().Replace('\\', '/');
                    int index = baseDirPath.LastIndexOf(ASSETS_PATH, StringComparison.Ordinal);
                    Assert.IsTrue(index >= 0);
                    baseDirPath = baseDirPath.Substring(index);
                    s_basePath = baseDirPath;
                }
                return s_basePath;
            }
        }

		#region Common Resource Loading

		public static string PreparePath(string path) 
		{
            path = path.Replace(Application.dataPath, "Assets");
            if (!path.StartsWith("Assets/"))
			    path = BasePath + path;
            return path;
        }

		public static T[] LoadResources<T>(string path) where T : UnityEngine.Object
		{
			path = PreparePath(path);
			return UnityEditor.AssetDatabase.LoadAllAssetsAtPath(path).OfType<T>().ToArray();
		}

		public static T LoadResource<T>(string path) where T : UnityEngine.Object
		{
			path = PreparePath(path);
			return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
		}

		#endregion

		#region Texture Management

		private static List<MemoryTexture> loadedTextures = new List<MemoryTexture>();

		public static Texture2D LoadTexture(string texPath)
		{
			if (String.IsNullOrEmpty(texPath))
				return null;
			int existingInd = loadedTextures.FindIndex((MemoryTexture memTex) => memTex.path == texPath);
			if (existingInd != -1) 
			{ 
				if (loadedTextures[existingInd].texture == null)
					loadedTextures.RemoveAt(existingInd);
				else
					return loadedTextures[existingInd].texture;
			}
		
			Texture2D tex = LoadResource<Texture2D>(texPath);
			AddTextureToMemory(texPath, tex);
			return tex;
		}
		
		public static void AddTextureToMemory(string texturePath, Texture2D texture)
		{
			if (texture == null) return;
			loadedTextures.Add(new MemoryTexture (texturePath, texture));
		}
		
		public static MemoryTexture FindInMemory (Texture2D tex)
		{
			int existingInd = loadedTextures.FindIndex((MemoryTexture memTex) => memTex.texture == tex);
			return existingInd != -1? loadedTextures[existingInd] : null;
		}
		
		public static bool HasInMemory(string texturePath)
		{
			int existingInd = loadedTextures.FindIndex((MemoryTexture memTex) => memTex.path == texturePath);
			return existingInd != -1;
		}
		
		public static MemoryTexture GetMemoryTexture(string texturePath)
		{
			List<MemoryTexture> textures = loadedTextures.FindAll((MemoryTexture memTex) => memTex.path == texturePath);
			if (textures == null || textures.Count == 0)
				return null;
			foreach (MemoryTexture tex in textures)
				return tex;
			return null;
		}
		
		public static Texture2D GetTexture(string texturePath)
		{
			MemoryTexture memTex = GetMemoryTexture(texturePath);
			return memTex == null? null : memTex.texture;
		}
		
		public class MemoryTexture 
		{
			public string path;
			public Texture2D texture;
			
			public MemoryTexture(string texPath, Texture2D tex) 
			{
				path = texPath;
				texture = tex;
			}
		}
		
		#endregion
	}

}