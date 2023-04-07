using GameLib.Core.Base;
using GameLib.Core.Support;
using GameLib.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Asset.CachePool
{
    /// <summary>
    /// SpawnPool扩展
    /// </summary>
    public class SpawnPoolExternal
    {
        /// <summary>
        /// SpawnPool缓存池
        /// </summary>
        private SpawnPool _spawnPool = null;

        public SpawnPoolNameCode PoolNameCode { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="spawnPool"></param>
        public SpawnPoolExternal(SpawnPool spawnPool, SpawnPoolNameCode name)
        {
            _spawnPool = spawnPool;
            PoolNameCode = name;
        }

        /// <summary>
        /// 预加载预制体
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="callBack">回调方法</param>
        public void LoadPrefab(string filePath, GAction<Transform> callBack, bool isUI = false)
        {
            var prefab = GetPrefab(filePath);
            if (prefab == null)
            {
                ////加载处理
                //PrefabAssetManager.SharedInstance.LoadPrefab(filePath, x =>
                //{
                //    if (x != null && x.IsAssetLoaded)
                //    {//返回的资源信息不为空,并且预制体资源是已经加载完毕,再次请求的话不会被加载了.

                //        if (!x.IsEmptyAsset)
                //        {//如果是非空资源,那么就需要建立一个PrefabPool.
                //            prefab = GetPrefab(x.AssetPath);
                //            if (prefab == null)
                //            {
                //                prefab = x.AssetObject.transform;
                //                //创建一个Prefab缓存池
                //                CreatePrefabPool(x);
                //            }
                //        }
                //    }
                //    //加载预制体资源失败,下次请求还会加载                    
                //    if (callBack != null) callBack(prefab);
                //}, Name == SpawnPoolNameCode.UI);
            }
            else
            {
                //当前有一个对应文件路径的预制体
                if (callBack != null) callBack(prefab);
            }
        }

        /// <summary>
        /// 创建一个替代资源
        /// </summary>
        public Transform NewPlaceHolder(string filePath)
        {
            //var x = AssetPlaceHolder.GetPrefabPlaceHolder(filePath);
            //return CreatePrefabInstance(x.transform, true);
            return null;
        }

        /// <summary>
        /// 获取一个新的GameObject对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="callBack"></param>
        public void NewGameObject(string filePath, GAction<Transform> callBack, bool spawnActive, bool usePlaceHolder, bool isUI = false)
        {
            LoadPrefab(filePath, prefabTrans => {
                Transform result = null;
                if (prefabTrans != null)
                {
                    //实例化一个预制体.也即是创建一个GameObject
                    result = CreatePrefabInstance(prefabTrans, spawnActive);
                }
                else
                {
                    //这里表示,回调函数是同步执行过来的.result还没有赋值
                    if (result == null && usePlaceHolder)
                    {
                        //返回一个替代资源
                        result = NewPlaceHolder(filePath);
                    }
                    Utils.DevLog.LogError("CreateGameObject:", filePath, "is Fail!! return null");
                }
                if (callBack != null) callBack(result);
            }, isUI);
        }

        /// <summary>
        /// 销毁一个GameObject
        /// </summary>
        /// <param name="trans"></param>
        public void FreeGameObject(ref Transform trans)
        {
            if (trans != null && _spawnPool != null && AppRoot.AppIsRunning)
            {
                _spawnPool.Despawn(trans);
                if (trans.parent != _spawnPool.Group)
                {
                    trans.parent = _spawnPool.Group;
                }
                trans = null;
            }
        }

        /// <summary>
        /// 清空缓存池数据
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="all"></param>
        public void Sweep(bool all)
        {
            if (_spawnPool != null)
            {
                try
                {
                    var prefabPools = _spawnPool.LockPrefabPoolsRef();
                    for (int i = 0; i < prefabPools.Count; ++i)
                    {
                        var prefabPool = prefabPools[i];
                        if (all && prefabPool.cullDespawned == false)
                        {
                            prefabPool.cullDespawned = true;
                            DevLog.LogFormat("force active prefabl pool culling: {0}", prefabPool._prefabName);
                        }
                        prefabPool.Sweep();
                    }
                }
                finally
                {
                    _spawnPool.UnlockPrefabPoolsRef();
                }
            }
        }

        /// <summary>
        /// 判断某个资源是否在缓存池中
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public bool IsInPool(string filePath)
        {
            return PrefabAssetManager.SharedInstance.IsLoaded(filePath);
        }

        /// <summary>
        /// 移除不需要的对象
        /// </summary>
        /// <param name="preCallDeletePool"></param>
        /// <param name="IgnorePools"></param>
        public int TrimUnusedPools(GAction<Transform> preCallDeletePool, List<string> IgnorePools)
        {
            return _spawnPool.TrimUnusedPools(preCallDeletePool, IgnorePools);

        }

        /// <summary>
        /// 当前是否正在清理无用资源
        /// </summary>
        /// <returns></returns>
        public bool IsTrimingUnusedPools()
        {
            return _spawnPool.IsTrimingUnusedPools();
        }

        #region 私有函数
        /// <summary>
        /// 创建一个PrefabPool
        /// </summary>        
        /// <param name="prefab"></param>
        private void CreatePrefabPool(PrefabAssetInfo info)
        {
            var prefab = _spawnPool.GetPrefab(info.AssetObject);
            if (prefab == null)
            {
                PrefabPool pool = new Support.PrefabPool(info.AssetObject.transform);
                pool.PrefabAssetPath = info.AssetPath;
                _spawnPool.CreatePrefabPool(pool);
                PoolSettingManager.ShareInstance.InitPoolSettings(pool);
                pool.OnPostDestroy = OnPostPoolDestory;
            }
        }

        /// <summary>
        /// 从缓存池获取Prefab
        /// </summary>
        private Transform GetPrefab(string prefabPath)
        {
            if (_spawnPool.Prefabs.TryGetValue(prefabPath, out Transform prefab))
            {
                return prefab;
            }
            return null;
        }

        /// <summary>
        /// 实例化一个预制体.也即是创建一个GameObject
        /// </summary>
        private Transform CreatePrefabInstance(Transform prefabTrans, bool spawnActive)
        {
            PrefabPool pool = null;
            Transform result = _spawnPool.Spawn(prefabTrans, ref pool, spawnActive);
            if (pool != null && string.IsNullOrEmpty(pool.PrefabAssetPath))
            {
                pool.PrefabAssetPath = "PlaceHolder";
                PoolSettingManager.ShareInstance.InitPoolSettings(pool);
            }
            return result;
        }

        /// <summary>
        /// 当PrefabPool删除时的操作
        /// </summary>
        /// <param name="pool"></param>
        private void OnPostPoolDestory(PrefabPool pool)
        {
            //清理Prefab的资源
            PrefabAssetManager.SharedInstance.UnLoadPrefab(pool.PrefabAssetPath, null, true);
        }
        #endregion
    }
}
