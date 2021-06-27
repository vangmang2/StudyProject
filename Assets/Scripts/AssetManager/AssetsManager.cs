using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace UnityEngine.Assets
{
    public interface IAssetLoader
    {
        void CollectAssets();
    }

    [Serializable]
    public class AssetManager<T> : SerializedScriptableObject, IAssetLoader
        where T : Object
    {
        [SerializeField] protected string assetDirectory;
        [ReadOnly] [SerializeField] List<T> assets;
        public List<T> Assets => assets;

        [Button("Collect")]
        public void CollectAssets()
        {
            assets = AssetUtility.LoadAllAssetsAtPath<T>(assetDirectory);
        }
    }
}
