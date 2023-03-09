using GameLib.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// GameObject的Cache
    /// </summary>
    public class GameObjectPool
    {
        private GameObject _rootGo = null;
        private Transform _rootTrans = null;
        private Queue<GameObject> _cacheQueue = new Queue<GameObject>();

        private const string CN_POOL_NAME = "[SimpleGameObject]";
        private static GameObjectPool _instance = null;
        public static GameObjectPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObjectPool(CN_POOL_NAME);
                }
                return _instance;
            }
        }

        private GameObjectPool(string name)
        {
            _rootGo = new GameObject(name);
            _rootGo.name = name;
            _rootTrans = _rootGo.transform;
            _rootTrans.parent = AppRoot.Transform;
        }

        /// <summary>
        /// 申请一个GameObject
        /// </summary>
        /// <param name="goName">名字</param>
        public GameObject Allocate(string goName)
        {
            GameObject cacheGo = null;
            while (_cacheQueue.Count > 0)
            {
                cacheGo = _cacheQueue.Dequeue();
            }
            if (cacheGo == null)
            {
                cacheGo = new GameObject();
            }
            else
            {
                if (cacheGo.activeSelf)
                {
                    cacheGo.SetActive(true);
                }
                UnityUtils.ResetTransform(cacheGo);
            }
            cacheGo.name = goName;
            return cacheGo;
        }

        /// <summary>
        /// 回收一个GameObject
        /// </summary>
        /// <param name="go">要删除的GameObject</param>
        public void Recycle(GameObject go)
        {
            if (go != null && AppRoot.AppIsRunning)
            {
                _cacheQueue.Enqueue(go);
                go.transform.parent = _rootGo.transform;
            }
        }

        public void Clear()
        {
            while (_cacheQueue.Count > 0)
            {
                Object.Destroy(_cacheQueue.Dequeue());
            }
        }
    }
}
