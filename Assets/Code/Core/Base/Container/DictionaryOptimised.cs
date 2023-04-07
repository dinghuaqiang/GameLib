using GameLib.Core.Base;
using System;
using System.Collections.Generic;

namespace Code.Core.Base.Container
{
    /// <summary>
    /// 优化后的字典迭代器
    /// Key不能是int类型，避免使用foreach
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryOptimised<TKey, TValue> where TValue : UnityEngine.Object
    {
        private Dictionary<TKey, TValue> _keyValue = null;
        private List<TKey> _keys = null;

        public DictionaryOptimised()
        {
            _keyValue = new Dictionary<TKey, TValue>();
            _keys = new List<TKey>();
        }

        /// <summary>
        /// add func is different, ret true only add, date unique
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(TKey key, TValue value)
        {
            ContainerUtils.ListAddUnique(_keys, key);
            return ContainerUtils.DictionaryAdd(_keyValue, key, value);
        }

        public void Remove(TKey key)
        {
            _keyValue.Remove(key);
            _keys.Remove(key);
        }

        public void Remove(GFunc<TKey, TValue, bool> compare)
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                TKey key = _keys[i];
                TValue val = _keyValue[key];
                if (compare(key, val))
                {
                    RemoveAt(i);
                    i--;
                }
            }
        }

        public void RemoveAt(int index)
        {
            _keyValue.Remove(_keys[index]);
            _keys.RemoveAt(index);
        }

        public void Clear()
        {
            if (_keyValue != null)
            {
                _keyValue.Clear();
            }
            if (_keys != null)
            {
                _keys.Clear();
            }
        }

        /// <summary>
        /// get value with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                return _keyValue[key];
            }
            set
            {
                Add(key, value);
            }
        }

        public int Count
        {
            get
            {
                if (_keys != null)
                {
                    return _keys.Count;
                }
                return -1;
            }
        }

        /// <summary>
        /// foreach key - value
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(GAction<TKey, TValue> action)
        {
            if (_keys != null)
            {
                for (int i = 0, imax = _keys.Count; i < imax; i++)
                {
                    TKey key = _keys[i];
                    TValue val;
                    if (TryGetValue(key, out val))
                    {
                        action(key, val);
                    }
                }
            }
        }

        // get key with index
        public bool TryGetKey(int index, ref TKey key)
        {
            bool succ = false;
            if (_keys.Count > index)
            {
                key = _keys[index];
                succ = true;
            }
            return succ;
        }

        // get value with key
        public bool TryGetValue(TKey key, out TValue value)
        {
            bool succ = false;
            if (_keyValue.TryGetValue(key, out value))
            {
                succ = true;
            }
            return succ;
        }

        // data check
        public bool ContainsKey(TKey key)
        {
            bool succ = false;
            if (_keys.Contains(key))
            {
                succ = true;
            }
            return succ;
        }
        public bool ContainsValue(TValue value)
        {
            bool succ = false;
            if (_keyValue.ContainsValue(value))
            {
                succ = true;
            }
            return succ;
        }

        // deleta no referenced obj
        public void Trim()
        {
            if (_keys != null)
            {
                for (int i = _keys.Count - 1; i >= 0; i--)
                {
                    TValue value = null;
                    if (!_keyValue.TryGetValue(_keys[i], out value) || value == null)
                    {
                        RemoveAt(i);
                    }
                }
            }
        }
    }
}
