using GameLib.Core.Base;
using GameLib.Core.Support;
using GameLib.Core.Utils;
using System.Collections.Generic;

namespace GameLib.Core.Asset.CachePool
{
    /// <summary>
    /// PrefabPoolSetting的管理者
    /// </summary>
    public class PoolSettingManager
    {
        #region//静态变量
        private static PoolSettingManager _shareInstance = null;

        public static PoolSettingManager ShareInstance
        {
            get
            {
                if (_shareInstance == null)
                {
                    _shareInstance = new PoolSettingManager();
                }
                return _shareInstance;
            }

        }
        #endregion   

        #region//私有变量
        //prefabPoolSettings的容器
        private Dictionary<string, PrefabPoolSettings> _prefabPoolSettingsDict = new Dictionary<string, PrefabPoolSettings>();
        //spawnPoolSettings的容器
        private Dictionary<string, SpawnPoolSettings> _spawnPoolSettingsDict = new Dictionary<string, SpawnPoolSettings>();
        //预制名字
        private Dictionary<string, string> _prefabNameToGroup = new Dictionary<string, string>();
        //默认的PrefabSettings
        private PrefabPoolSettings _defaultPrefab = new PrefabPoolSettings(null);

        //默认的SpawnSettings
        private SpawnPoolSettings _defaultSpawn = new SpawnPoolSettings();

        //已经应用Setting的历史
        private List<string> _applySettingsHistory = new List<string>();
        #endregion

        #region//公共接口

        //初始化操作
        public void Initialize()
        {
            _prefabPoolSettingsDict.Clear();

            _applySettingsHistory.Clear();

            _spawnPoolSettingsDict.Clear();

            _prefabNameToGroup.Clear();

            PoolSettingsXmlReader.ReadXml(OnAddSpawnSettings, OnAddPrefabSettings);

            //使用内存等级来处理Prefab的处理方式
            UseMemoryLevel();

        }

        //反初始化
        public void Uninitialize()
        {
            _applySettingsHistory.Clear();
            _prefabNameToGroup.Clear();
            _prefabPoolSettingsDict.Clear();
            _spawnPoolSettingsDict.Clear();
        }

        //获取某个配置
        public PrefabPoolSettings GetPrefabSettings(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return _defaultPrefab;

            if (_prefabPoolSettingsDict.ContainsKey(groupName.ToLower()))
            {
                return _prefabPoolSettingsDict[groupName.ToLower()];
            }
            return _defaultPrefab;
        }
        //获取某个配置
        public SpawnPoolSettings GetSpawnSettings(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return _defaultSpawn;

            if (_prefabPoolSettingsDict.ContainsKey(groupName.ToLower()))
            {
                return _spawnPoolSettingsDict[groupName.ToLower()];
            }
            return _defaultSpawn;
        }

        //初始化Settings
        public void InitPoolSettings(PrefabPool prefabPool)
        {
            if (_applySettingsHistory.IndexOf(prefabPool._prefabName) < 0)
            {
                _applySettingsHistory.Add(prefabPool._prefabName);
                string groupName = GetGroupName(prefabPool._prefabName);
                if (string.IsNullOrEmpty(groupName))
                {
                    groupName = prefabPool.SpawnPool.name.ToLower();
                }
                var settings = GetPrefabSettings(groupName);
                if (settings != null)
                {
                    prefabPool.ApplySettings(settings);
                }
            }

        }

        #endregion

        #region//私有函数
        //初始化一个默认的缓存池配置信息
        private void CreateDefault()
        {
            //PrefabSettings Default
            //默认清除
            _defaultPrefab.CullDespawned = false;
            //最多缓存10个
            _defaultPrefab.CullAbove = 10;
            //清除间隔是30
            _defaultPrefab.CullDelay = 10;
            //容器被删除
            _defaultPrefab.OnPreDestroy = OnPrefabPoolDestory;
            //SpawnSettings Default
            //默认不启动自动清除
            _defaultSpawn.StartupAutoCleaner = false;
            //Prefab的生存期为1分钟
            _defaultSpawn.PrefabLiftTime = 60;
            //清除器的Tick为10秒
            _defaultSpawn.CleanerTick = 10;

        }

        //添加SpawnSettings信息,用于读取xml的回调
        private void OnAddSpawnSettings(string name, SpawnPoolSettings settings)
        {
            if (string.IsNullOrEmpty(name)) return;
            _spawnPoolSettingsDict[name.ToLower()] = settings;
        }

        //用于读取xml的回调
        private void OnAddPrefabSettings(string[] prefabNames, string groupName, PrefabPoolSettings settings)
        {
            //设置容器被删除的回调
            settings.OnPreDestroy = OnPrefabPoolDestory;
            _prefabPoolSettingsDict[groupName.ToLower()] = settings;
            for (int i = 0; i < prefabNames.Length; i++)
            {
                string val = prefabNames[i].Trim().ToLower();
                if (!string.IsNullOrEmpty(val))
                {
                    _prefabNameToGroup[val] = groupName.ToLower();
                }
            }
        }

        //如果内存等级发生了改变,那么久重新对Setting进行刷新
        private void UseMemoryLevel()
        {
            float scale = 1f;
            switch (MemoryMonitor.Level)
            {
                case MemoryLevel.High:
                    scale = 1.5f;
                    break;
                case MemoryLevel.Middle:
                    scale = 1;
                    break;
                case MemoryLevel.Low:
                    scale = 0.5f;
                    break;
            }
            var enumerator = _prefabPoolSettingsDict.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Value.CullDelay = (int)((float)enumerator.Current.Value.CullDelay * scale);
                }
            }
            finally
            {
                enumerator.Dispose();
            }
            //刷新所有
            RefreshSpawnPoolSettingsAll();
        }

        //刷新所有的SpawnPool数据
        private void RefreshSpawnPoolSettingsAll()
        {
            var e = PoolManager.Pools.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    RefreshSpawnPoolSettings(e.Current.Value);
                }
            }
            finally
            {
                e.Dispose();
            }

        }

        //刷新SpawnPool的内容信息
        private void RefreshSpawnPoolSettings(SpawnPool pool)
        {
            if (pool != null)
            {
                try
                {
                    var prefabPools = pool.LockPrefabPoolsRef();
                    for (int i = 0; i < prefabPools.Count; ++i)
                    {
                        var prefabPool = prefabPools[i];
                        string groupName = GetGroupName(prefabPool._prefabName);
                        var settings = GetPrefabSettings(groupName);
                        if (settings != null)
                        {
                            prefabPool.cullDespawned = settings.CullDespawned;
                            prefabPool.CullAbove = settings.CullAbove;
                            prefabPool.CullDelay = settings.CullDelay;
                        }
                    }
                }
                finally
                {
                    pool.UnlockPrefabPoolsRef();
                }
            }
        }

        //获取组的名字
        private string GetGroupName(string filePath)
        {
            string baseName, ext;
            StringUtils.SplitFilename(filePath, out baseName, out ext);
            if (_prefabNameToGroup.ContainsKey(baseName))
            {
                return _prefabNameToGroup[baseName];
            }
            return null;
        }

        //容器被删除的回调
        private void OnPrefabPoolDestory(PrefabPool pool)
        {
            _applySettingsHistory.Remove(pool._prefabName);
        }
        #endregion

    }
}
