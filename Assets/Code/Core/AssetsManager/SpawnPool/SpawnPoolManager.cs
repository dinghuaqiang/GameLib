using Code.Core.Utils;
using GameLib.Core.Base;
using GameLib.Core.Support;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Asset.CachePool
{
    /// <summary>
    /// 缓存池管理器
    /// </summary>
    public class SpawnPoolManager : Singleton<SpawnPoolManager>
    {
        #region//常量
        private const string CN_NAME = "[GameObjectPool]";
        #endregion

        #region //私有变量
        //SpawnPool管理器
        private Dictionary<int, SpawnPoolExternal> _container = new Dictionary<int, SpawnPoolExternal>();
        //SpawnPool的根节点
        private GameObject _node = null;
        #endregion

        #region 初始化和卸载
        public override void OnInitialize()
        {
            base.OnInitialize();
            Initialize();
        }

        public override void OnUnInitialize()
        {
            base.OnUnInitialize();
            Uninitialize();
        }

        //初始化PoolRoot
        public void Initialize()
        {
            if (_node == null)
            {
                //初始化PoolSetting
                PoolSettingManager.ShareInstance.Initialize();

                _node = new GameObject(CN_NAME);
                _node.transform.parent = AppRoot.Transform;
                for (int i = (int)SpawnPoolNameCode.Begin + 1; i < (int)SpawnPoolNameCode.End; i++)
                {
                    var go = new GameObject(((SpawnPoolNameCode)i).ToString());
                    var pool = go.AddComponent<SpawnPool>();
                    go.transform.parent = _node.transform;

                    //设置是否进行自动清理
                    var settings = PoolSettingManager.ShareInstance.GetSpawnSettings(pool.name);
                    if (settings != null && settings.StartupAutoCleaner && settings.PrefabLiftTime > 0 && settings.CleanerTick > 0)
                    {
                        pool.InstallAutoCleaner(settings.PrefabLiftTime, settings.CleanerTick);
                    }
                }

            }
        }
        //卸载
        public void Uninitialize()
        {
            if (_node != null)
            {
                GameObject.Destroy(_node);
                _node = null;
            }
            if (_container != null)
            {
                //清理容器
                _container.Clear();
            }
            PoolSettingManager.ShareInstance.Uninitialize();
        }
        #endregion

        public SpawnPoolExternal GetSpawnPool(SpawnPoolNameCode poolNameCode)
        {
            return null;
        }
    }
}
