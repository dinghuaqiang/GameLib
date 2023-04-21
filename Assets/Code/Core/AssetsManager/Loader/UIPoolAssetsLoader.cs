using GameLib.Core.Asset.CachePool;
using GameLib.Core.Base;
using GameLib.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// UI界面关联加载 ----这里所有加载都是同步加载
    /// </summary>
    public class UIPoolAssetsLoader
    {
        #region//常量
        //默认基础字体的名字
        public const string CN_BASE_FONT_NAME = "UINewMainFont";
        #endregion

        #region//静态变量

        //定义Game对象的缓存池
        private static SpawnPoolExternal _formPool = null;

        private static Dictionary<string, Transform> _formDict = new Dictionary<string, Transform>();

        //没有找到字体的列表
        private static List<string> _notFoundFontList = new List<string>();

        #endregion

        #region//静态构造函数
        static UIPoolAssetsLoader()
        {
            _formPool = SpawnPoolManager.Instance.GetSpawnPool(SpawnPoolNameCode.UI);
        }
        #endregion

        #region //异步加载
        /// <summary>
        /// 加载UI窗体
        /// 默认加载的UI窗体都是非激活状态
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static bool LoadFormAsyn(string formName, GAction<Transform> asyncCallback)
        {
            return LoadPrefabAsyn(formName, formName, asyncCallback);
        }

        /// <summary>
        /// 加载UI预制,
        /// 默认所有加载的Prefab都是非激活状态
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="prefabName"></param>
        /// <returns></returns>
        public static bool LoadPrefabAsyn(string formName, string prefabName, GAction<Transform> asyncCallback)
        {
            if (string.IsNullOrEmpty(formName) || string.IsNullOrEmpty(prefabName))
            {
                return false;
            }
            string path = FormPrefabPath(formName, prefabName);
            //默认所有加载的UIPrefab都是非激活状态
            return LoadFormPrefab(path, _formPool, asyncCallback);
        }

        /// <summary>
        /// 加载图集的预制
        /// </summary>
        /// <param name="atlasName"></param>
        /// <returns></returns>
        public static bool LoadAtlasPrefabAsyn(string atlasName, GAction<Transform> asyncCallback)
        {
            if (string.IsNullOrEmpty(atlasName))
            {
                return false;
            }
            string path = AtlasPath(atlasName);
            return LoadAssetPrefab(path, asyncCallback);
        }
        /// <summary>
        /// 加载图集的预制
        /// </summary>
        /// <param name="atlasName"></param>
        /// <returns></returns>
        public static bool LoadAtlasPrefabAsyn(string atlasName, int index, GAction<Transform> asyncCallback)
        {
            if (string.IsNullOrEmpty(atlasName))
            {
                return false;
            }
            string path = AtlasPath(atlasName, index);
            return LoadAssetPrefab(path, asyncCallback);
        }

        /// <summary>
        /// 加载字体的预制
        /// </summary>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public static void LoadFontPrefabAsyn(string fontName, GAction<Transform> asyncCallback)
        {
            //如果内存较低,那么所有只加载一个字体
            if (string.IsNullOrEmpty(fontName))
            {//如果字体为空
                fontName = CN_BASE_FONT_NAME;
            }
            else if (_notFoundFontList.IndexOf(fontName) >= 0)
            {//如果这个字体之前加载失败
                fontName = CN_BASE_FONT_NAME;
            }
            //创建字体路径
            string path = FontPath(fontName);

            LoadAssetPrefab(path, x => {
                if (x != null)
                {
                    asyncCallback(x);
                }
                else if (fontName == CN_BASE_FONT_NAME)
                {
                    asyncCallback(null);
                }
                else
                {
                    _notFoundFontList.Add(fontName);
                    LoadAssetPrefab(FontPath(CN_BASE_FONT_NAME), x2 => {

                        if (x != null)
                        {
                            asyncCallback(x);
                        }
                        else
                        {
                            asyncCallback(null);
                        }
                    });
                }
            });
        }
        #endregion

        #region//卸载以及清理处理
        //卸载预制
        public static void UnloadPrefab(string formName, string prefabName, Transform trans, bool isDestroy = false)
        {
            if (trans == null)
            {
                UnityEngine.Debug.LogError("UnloadPrefab fail, trans is null: formName=" + formName);
                return;
            }
            string path = FormPrefabPath(formName, prefabName);
            if (trans.gameObject.activeSelf)
                trans.gameObject.SetActive(false);

            _formDict.Remove(path);
            if (isDestroy)
                Object.Destroy(trans.gameObject);
            else
                _formPool.FreeGameObject(ref trans);

        }
        //卸载Atlas
        public static void UnloadAtlas(string atlasName, Transform atlasTrans)
        {
            var arr = atlasName.Split(new string[] { "_", "(Clone)" }, System.StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 1)
            {
                int idx = -1;
                if (int.TryParse(arr[1], out idx))
                {
                    UnloadAtlas(arr[0], idx, atlasTrans);
                }
                else
                {
                    UnityEngine.Debug.LogError(string.Format("Unload Atlas Error!!{0}", atlasName));
                }
            }
            else
            {
                UnloadAtlas(atlasName, -1, atlasTrans);
            }

        }
        //卸载Atlas
        public static void UnloadAtlas(string atlasName, int index, Transform atlasTrans)
        {
            string path = AtlasPath(atlasName, index);
            //PrefabAssetManager.SharedInstance.UnLoadPrefab(path, null, false);
        }

        //卸载字体
        public static void UnloadFont(string fontName, Transform fontTrans)
        {
            /*
            if (fontName != CN_BASE_FONT_NAME)
            {
                string path = FontPath(fontName);
                PrefabAssetManager.SharedInstance.UnLoadPrefab(path, null, false);
            } */
            //对字体不做卸载处理
            /*
            string path = FontPath(fontName);
            _UIDict.Remove(path);
            _fontPool.FreeGameObject(ref fontTrans);
            */
        }

        //清理无用的预制
        public static List<string> ClearDeactivedForms(List<string> ignoreNames)
        {
            //1.把uiDict中的资源回收到Pool中
            var result = DespawnAllDeActivedForm(ignoreNames);
            //2.把窗体Pool中的所有无用资源全部清空
            _formPool.TrimUnusedPools(null, result);
            return result;
        }

        #endregion

        #region//路径组合

        //图集名字合成
        public static string AtlasName(string atlasName, int index = -1)
        {
            return "";
            if (index < 0)
            {
                return atlasName;
            }
            else
            {
                //return string.Format(AssetConstDefine.UIAtlasNameEx, atlasName, index);

            }
        }
        //图集的路径
        public static string AtlasPath(string atlasName, int index = -1)
        {
            return "";
            if (index < 0)
            {
                var idx = atlasName.LastIndexOf('_');
                if (idx > 0 && idx < atlasName.Length - 1)
                {
                    //if (!LanguageSystem.UseLang)
                    //{
                    //    return string.Format(AssetConstDefine.PathUIAtlasEx,
                    //        atlasName.Substring(0, idx),
                    //        atlasName.Substring(idx + 1, atlasName.Length - idx - 1));
                    //}
                    //else
                    //{
                    //    return string.Format(AssetConstDefine.PathUIAtlasEx_LANG,
                    //        atlasName.Substring(0, idx),
                    //        atlasName.Substring(idx + 1, atlasName.Length - idx - 1),
                    //        LanguageSystem.LangPostfix
                    //        );
                    //}
                }
                else
                {
                    //if (!LanguageSystem.UseLang)
                    //{
                    //    return string.Format(AssetConstDefine.PathUIAtlas, atlasName);
                    //}
                    //else
                    //{
                    //    return string.Format(AssetConstDefine.PathUIAtlas_LANG, atlasName, LanguageSystem.Lang);
                    //}


                }
            }
            else
            {
                //if (!LanguageSystem.UseLang)
                //{
                //    return string.Format(AssetConstDefine.PathUIAtlasEx, atlasName, index);
                //}
                //else
                //{
                //    return string.Format(AssetConstDefine.PathUIAtlasEx_LANG, atlasName, index, LanguageSystem.Lang);
                //}

            }
        }
        //字体的路径
        public static string FontPath(string fontName)
        {
            //if (!LanguageSystem.UseLang)
            //{
            //    return string.Format(AssetConstDefine.PathUIFont, fontName);
            //}
            //else
            //{
            //    return string.Format(AssetConstDefine.PathUIFont_LANG, fontName, LanguageSystem.Lang);
            //}
            return "";
        }
        #endregion

        #region//私有方法

        /// <summary>
        /// 加载字体或者atlas
        /// </summary>
        /// <param name="path"></param>
        /// <param name="asyncCallback"></param>
        /// <returns></returns>
        private static bool LoadAssetPrefab(string path, GAction<Transform> asyncCallback)
        {
            return true;
            //return PrefabAssetManager.SharedInstance.LoadPrefab(path, x =>
            //{

            //    //FLogger.DebugLogError("UIPoolAssetsLoader.LoadAssetPrefab:", path);
            //    if (x != null && x.AssetObject != null && !x.IsEmptyAsset)
            //    {
            //        asyncCallback(x.AssetObject.transform);
            //    }
            //    else
            //    {
            //        asyncCallback(null);
            //    }
            //}, true);
        }

        /// <summary>
        /// 加载一个预制缓存池(PrefabPool),从根缓存池(SpawnPool)中,如果根缓存池中没有的话,就异步加载资源.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="asyncCallback"></param>
        /// <param name="pool"></param>
        /// <param name="asyncLoadPrefabOnly"></param>
        /// <returns></returns>
        private static bool LoadFormPrefab(string filePath, SpawnPoolExternal pool, GAction<Transform> asyncCallback)
        {
            //从存储的字典中获取对象
            Transform uiTransform = null;
            if (_formDict.TryGetValue(filePath, out uiTransform))
            {
                if (uiTransform != null)
                {
                    if (asyncCallback != null) asyncCallback(uiTransform);
                    return true;
                }
                _formDict.Remove(filePath);
                DevLog.LogError("Get value from UI dict is null, remove key : ", filePath);
            }

            pool.NewGameObject(filePath, x =>
            {
                if (!_formDict.TryGetValue(filePath, out uiTransform))
                {
                    if (x != null)
                    {
                        //窗体UI加载后不要自动设置为可激活                                                          
                        x.name = filePath;
                        _formDict[filePath] = x;
                        uiTransform = x;
                    }
                    else
                    {
                        _formDict[filePath] = null;
                        DevLog.LogErrorFormat("Load prefab {0} failed!", filePath);
                    }
                }
                if (asyncCallback != null) asyncCallback(uiTransform);

            }, false, false, true);
            return true;

        }

        //窗体以及预制的路径
        public static string FormPrefabPath(string formName, string prefabName)
        {
            return "";
            //if (LanguageSystem.UseLang)
            //{
            //    return string.Format(AssetConstDefine.PathUIForm_LANG, formName, prefabName, LanguageSystem.Lang);
            //}
            //else
            //{
            //    return string.Format(AssetConstDefine.PathUIForm, formName, prefabName);
            //}
        }

        //把所有非活跃窗体回收到Pool中
        private static List<string> DespawnAllDeActivedForm(List<string> ignoreNames)
        {
            List<string> result = new List<string>();
            //把忽略的名字前面增加一个斜杠
            if (ignoreNames != null)
            {
                for (int i = 0; i < ignoreNames.Count; i++)
                {
                    ignoreNames[i] = "/" + ignoreNames[i];
                }
            }
            //找到所有非激活的资源并写入到一个列表中
            List<string> removeList = new List<string>();
            var em = _formDict.GetEnumerator();
            try
            {
                while (em.MoveNext())
                {
                    if (em.Current.Value == null)
                    {
                        Debug.LogError("Form:[" + em.Current.Key + "]已经被销毁了.");
                        removeList.Add(em.Current.Key);
                    }
                    else if (!em.Current.Value.gameObject.activeSelf)
                    {
                        //判断当前资源是否被忽略
                        bool isIgnore = false;
                        if (ignoreNames != null)
                        {
                            for (int i = 0; i < ignoreNames.Count; i++)
                            {
                                if (em.Current.Key.EndsWith(ignoreNames[i], System.StringComparison.OrdinalIgnoreCase))
                                {
                                    isIgnore = true;
                                    break;
                                }
                            }
                        }
                        if (!isIgnore)
                        {
                            removeList.Add(em.Current.Key);
                        }
                    }
                }
            }
            finally
            {
                em.Dispose();
            }

            //根据移除列表,把所有的预制全部都会受到Pool中
            for (int i = 0; i < removeList.Count; i++)
            {
                if (!string.IsNullOrEmpty(removeList[i]))
                {
                    var ui = _formDict[removeList[i]];
                    //这里只针对窗体进行回收处理
                    if (removeList[i].IndexOf("/Form/") >= 0)
                    {
                        if (ui != null)
                        {
                            _formPool.FreeGameObject(ref ui);
                        }
                        _formDict.Remove(removeList[i]);
                        int idx = removeList[i].LastIndexOf('/');
                        if (idx >= 0)
                        {
                            if (idx < removeList[i].Length)
                            {
                                result.Add(removeList[i].Substring(idx + 1));
                            }
                        }
                        else
                        {
                            result.Add(removeList[i]);
                        }
                    }

                }
            }
            removeList.Clear();
            return result;

        }
        #endregion
    }
}
