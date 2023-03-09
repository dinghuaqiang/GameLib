using System.Collections.Generic;

namespace GameLib.Core.Base
{
    public interface IPoolObject
    {
        void OnSpawn();

        void OnDeSpawn();

        void OnDestroy();
    }

    public class ObjectFactory<T>
    {
        private GFunc<T> _createMethod = null;
        public ObjectFactory(GFunc<T> createMethod)
        {
            _createMethod = createMethod;
        }

        public T CreateObject()
        {
            return _createMethod();
        }
    }

    /// <summary>
    /// 一个通用对象池
    /// </summary>
    public class UniversalObjectPool<T> where T : IPoolObject
    {
        private int _defaultCount = 10;
        private GFunc<T> _createFunc = null;
        private ObjectFactory<T> _factory;
        private Stack<T> _cacheStack = new Stack<T>();
        /// <summary>
        /// 最大缓存的对象数
        /// </summary>
        private int _maxCacheCount = 10;
        /// <summary>
        /// 当前缓存了多少个对象
        /// </summary>
        public int CacheCount { get { return _cacheStack.Count; } }

        public UniversalObjectPool(GFunc<T> createFunc)
        {
            _createFunc = createFunc;
            _factory = new ObjectFactory<T>(createFunc);
            for (int i = 0; i < _maxCacheCount; i++)
            {
                T obj = _factory.CreateObject();
                _cacheStack.Push(obj);
                obj.OnSpawn();
            }
        }

        public T Spawn()
        {
            T cacheObj = _cacheStack.Count == 0 ? _factory.CreateObject() : _cacheStack.Pop();
            cacheObj.OnSpawn();
            return cacheObj;
        }

        public bool DeSpawn(T obj)
        {
            int oldCount = _cacheStack.Count;
            _cacheStack.Push(obj);
            obj.OnDeSpawn();
            return _cacheStack.Count > oldCount;
        }

        public void Clear()
        {
            if (_cacheStack.Count > 0)
            {
                while (_cacheStack.Count > 0)
                {
                    _cacheStack.Pop().OnDestroy();
                }
            }
        }
    }
}
