using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine;
using Code.Core.Utils;

namespace GameLib.Core.Asset
{
    public class AssetLoadManager : Singleton<AssetLoadManager>
    {
        #region 单例的初始化操作
        public override void OnInitialize()
        {
            base.OnInitialize();
            //进行初始化，方便进行同步加载
            Addressables.InitializeAsync();
        }

        public override void OnUnInitialize()
        {
            base.OnUnInitialize();
        }
        #endregion

        private Action<UnityEngine.Object> _onLoadComplated = null;
        private Action<UnityEngine.SceneManagement.Scene> _onSceneLoadComplated = null;
        private AsyncOperationHandle<SceneInstance> _sceneLoadHandle;

        public void UnloadScene()
        {
            if (_sceneLoadHandle.Result.Scene != null)
            {
                Addressables.UnloadSceneAsync(_sceneLoadHandle);
            }
        }

        public void UnloadAssets(GameObject go)
        {
            if (go != null)
            {
                Addressables.Release(go);
            }
        }

        private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> scendHandle)
        {
            if (scendHandle.Result.Scene != null)
            {
                if (_onSceneLoadComplated != null)
                {
                    _sceneLoadHandle = scendHandle;
                    _onSceneLoadComplated(scendHandle.Result.Scene);
                }
            }
        }

        /// <summary>
        /// 通过Addressables加载资源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="onLoadComplated"></param>
        public void LoadAssetAsync(string path, Action<UnityEngine.Object> onLoadComplated)
        {
            _onLoadComplated = onLoadComplated;
            AsyncOperationHandle<UnityEngine.Object> asyncLoad = Addressables.LoadAssetAsync<UnityEngine.Object>(path);
            asyncLoad.Completed += OnLoadComplated;
        }

        private void OnLoadComplated(AsyncOperationHandle<UnityEngine.Object> handle)
        {
            //加载之后需要实例化的资源
            UnityEngine.Object loadObj = handle.Result;
            if (loadObj != null)
            {
                if (_onLoadComplated != null)
                {
                    _onLoadComplated(loadObj);
                }
            }
        }

        /// <summary>
        /// 同步加载
        /// </summary>
        public GameObject LoadAsset(string assetPath) 
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(assetPath);
            GameObject go = asyncOperationHandle.WaitForCompletion();
            //UnloadAssets(go);
            return go;
        }
    }
}
