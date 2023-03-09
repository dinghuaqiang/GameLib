using GameLib.Core.Asset;
using PathologicalGames;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Test
{
    public class SpawnPoolTest : MonoBehaviour
    {
        private SpawnPool _objectPool = null;
        private Transform _objectRoot = null;
        private List<Transform> _cacheList = null;
        private bool _despawned = false;
        private bool _loaded = false;

        private string _modelPath = "Assets/GameAssets/Resources/Prefabs/UnityChanModel/Prefabs/for Locomotion/unitychan_dynamic_locomotion.prefab";
        //private string _modelPath = "Assets/GameAssets/Resources/Prefabs/UnityChanModel/Prefabs/unitychan_dynamic_locomotion.prefab";
        private string _lightPath = "Assets/GameAssets/Resources/Prefabs/UnityChanModel/Prefabs/Directional light for UnityChan.prefab";

        private void Awake()
        {
            _cacheList = new List<Transform>();
            _objectPool = PoolManager.Pools.Create("[SpawnObjectPool]");
            _objectRoot = transform.Find("[Objects]");
            for (int i = 0; i < 10; i++)
            {
                AssetLoadManager.SharedInstance.LoadAssetAsync(_modelPath, OnLoadComplated);
            }
            //AssetLoadManager.SharedInstance.LoadAssetAsync(_modelPath, OnLoadComplated);
            AssetLoadManager.SharedInstance.LoadAssetAsync(_lightPath, OnLoadComplated);
        }

        private void OnLoadComplated(Object obj)
        {
            GameObject go = obj as GameObject;
            Transform trans = _objectPool.Spawn(go.transform);
            bool isContains = _objectPool.prefabs.ContainsKey("unitychan_dynamic_locomotion");
            _cacheList.Add(trans);
        }

        private void Update()
        {
            if (Time.realtimeSinceStartup >= 30 && !_despawned)
            {
                _despawned = true;
                for (int i = 0; i < _cacheList.Count; i++)
                {
                    _objectPool.Despawn(_cacheList[i]);
                }
            }
            if (Time.realtimeSinceStartup >= 40 && !_loaded)
            {
                _loaded = true;
                AssetLoadManager.SharedInstance.LoadAssetAsync(_modelPath, OnLoadComplated);
            }
        }

        private void OnDestroy()
        {

        }
    }
}
