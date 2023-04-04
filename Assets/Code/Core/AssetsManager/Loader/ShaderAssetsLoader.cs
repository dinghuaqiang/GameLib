using GameLib.Core.Utils;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// Shader资源加载器
    /// </summary>
    public class ShaderAssetsLoader
    {
        //Shader的变体集合的Bundle路径
        private const string CN_SHADER_BUNDLE_PATH = "Shader/shaderfactory";
        private static GameObject _shaderFactoryAssets = null;
        private static GameObject _shaderFactoryGo = null;
        //材质没有找到
        private static bool _shaderAssetNotFound = false;

        private static System.Action<GameObject> _loadFinishedCallBack = null;

        internal static bool CheckShaderAssetNotFound()
        {
            return _shaderAssetNotFound;
        }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        internal static void Initialize(System.Action<GameObject> callBack)
        {

            Debug.Log("ShaderAssetsLoader.Initialize");
            _loadFinishedCallBack = callBack;
            _shaderAssetNotFound = false;
            LoadAssetBundle(CN_SHADER_BUNDLE_PATH);
        }

        internal static void Uninitialize()
        {

            _shaderAssetNotFound = false;
            if (_shaderFactoryAssets != null)
            {
                GameObject.DestroyImmediate(_shaderFactoryAssets);
                _shaderFactoryAssets = null;
            }

            if (_shaderFactoryGo != null)
            {
                GameObject.Destroy(_shaderFactoryGo);
                _shaderFactoryGo = null;
            }

        }

        /// <summary>
        /// 加载AssetBundle
        /// </summary>
        /// <param name="assetPath"></param>
        /// <param name="onLoadedCallback"></param>
        private static void LoadAssetBundle(string assetPath)
        {
            if (_shaderFactoryAssets == null)
            {
                AssetLoadManager.Instance.LoadAssetAsync(assetPath, (Object obj) => 
                {
                    GameObject gameObject = obj as GameObject;
                    Parse(gameObject);
                    if (_loadFinishedCallBack != null)
                    {
                        _loadFinishedCallBack(_shaderFactoryGo);
                    }
                });
            }
            else
            {
                if (_loadFinishedCallBack != null) _loadFinishedCallBack(null);
            }
        }

        /// <summary>
        /// 解析Bundle处理
        /// </summary>
        /// <param name="ab"></param>
        private static void Parse(Object obj)
        {
            if (obj != null)
            {
                _shaderFactoryAssets = obj as GameObject;
                if (_shaderFactoryAssets != null)
                {
                    Debug.Log("CreateShaderFactory Start!!");
                    var go = GameObject.Instantiate(_shaderFactoryAssets);
                    go.transform.parent = Base.AppRoot.Transform;
                    go.name = "[ShaderFactory]";
                    go.SetActive(true);
                    UnityUtils.ResetTransform(go);

                    _shaderFactoryGo = go;
                    Debug.Log("CreateShaderFactory OK!!");
                }
                else
                {
                    Debug.LogError("ShaderFactory不是Prefab?");
                }
            }
            else
            {
                _shaderAssetNotFound = true;
                Debug.LogError("ShaderFactory没有被加载!");
            }
        }
    }
}
