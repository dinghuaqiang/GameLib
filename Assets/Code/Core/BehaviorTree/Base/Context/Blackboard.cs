using System;
using System.Collections.Generic;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 黑板类，存储每个节点的数据
    /// </summary>
    public class Blackboard
    {
        #region 操作类型枚举
        public enum OperationType
        {
            //添加
            ADD,
            //删除
            REMOVE,
            //改变
            CHANGE,
        }
        #endregion

        #region 通知类
        /// <summary>
        /// 消息通知
        /// </summary>
        private class Notification
        {
            public OperationType OperationType;
            public string Key;
            public object Value;

            public Notification(OperationType type, string key, object value)
            {
                OperationType = type;
                Key = key;
                Value = value;
            }
        }
        #endregion

        #region 变量
        /// <summary>
        /// 定时器
        /// </summary>
        private Clock _clock;
        /// <summary>
        /// 父节点的黑板
        /// </summary>
        private Blackboard _parentBlackboard;
        /// <summary>
        /// 是否正在通知
        /// </summary>
        private bool _isNotifiyng = false;
        /// <summary>
        /// 子节点的黑板
        /// </summary>
        private HashSet<Blackboard> _children = new HashSet<Blackboard>();
        /// <summary>
        /// 所有的键值对数据存放点
        /// </summary>
        private Dictionary<string, object> _data = new Dictionary<string, object>();
        private Dictionary<string, List<Action<OperationType, object>>> _observers = new Dictionary<string, List<Action<OperationType, object>>>();
        private Dictionary<string, List<Action<OperationType, object>>> _addObservers = new Dictionary<string, List<Action<OperationType, object>>>();
        private Dictionary<string, List<Action<OperationType, object>>> _removeObservers = new Dictionary<string, List<Action<OperationType, object>>>();
        private List<Notification> _notifs = new List<Notification>();
        private List<Notification> _dispatchNotifs = new List<Notification>();
        #endregion

        #region 构造函数
        public Blackboard(Clock clock)
        {
            this._clock = clock;
        }

        public Blackboard(Blackboard parentBD, Clock clock)
        {
            _parentBlackboard = parentBD;
            this._clock = clock;
        }
        #endregion

        #region 启用和停止黑板
        public void Enable()
        {
            if (_parentBlackboard != null)
            {
                _parentBlackboard._children.Add(this);
            }
        }

        public void Disable()
        {
            if (_parentBlackboard != null)
            {
                _parentBlackboard._children.Remove(this);
            }
            if (_clock != null)
            {
                _clock.RemoveTimer(NotifiyObservers);
            }
        }
        #endregion

        #region 设置值的操作
        public object this[string key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }

        public void Add(string key)
        {
            if (!HasSetKey(key))
            {
                Add(key, null);
            }
        }

        public void Add(string key, object value)
        {
            if (_parentBlackboard != null && _parentBlackboard.HasSetKey(key))
            {
                _parentBlackboard.Add(key, value);
            }
            else
            {
                if (!_data.ContainsKey(key))
                {
                    //没有包含key，直接新增一个
                    _data.Add(key, value);
                    _notifs.Add(new Notification(OperationType.CHANGE, key, value));
                    _clock.AddTimer(0f, 0, NotifiyObservers);
                }
                else
                {
                    //判断下是否未设置过值，或者，新设置的值和之前的值不一样再进行添加或者变更
                    if ((_data[key] == null && value != null) || (_data[key] != null && !_data[key].Equals(value)))
                    {
                        _data[key] = value;
                        _notifs.Add(new Notification(OperationType.CHANGE, key, value));
                        _clock.AddTimer(0f, 0, NotifiyObservers);
                    }
                }
            }
        }

        /// <summary>
        /// 移除某个值
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (_data.ContainsKey(key))
            {
                _data.Remove(key);
                _notifs.Add(new Notification(OperationType.REMOVE, key, null));
                _clock.AddTimer(0f, 0, NotifiyObservers);
            }
        }
        #endregion

        #region 回调的处理
        public void AddObserver(string key, Action<OperationType, object> observer)
        {
            List<Action<OperationType, object>> observerList = GetObserverList(_observers, key);
            if (!_isNotifiyng)
            {
                if (!observerList.Contains(observer))
                {
                    observerList.Add(observer);
                }
            }
            else
            {
                if (!observerList.Contains(observer))
                {
                    List<Action<OperationType, object>> addObserverList = GetObserverList(_addObservers, key);
                    if (!addObserverList.Contains(observer))
                    {
                        addObserverList.Add(observer);
                    }
                }

                List<Action<OperationType, object>> removeObserverList = GetObserverList(_removeObservers, key);
                if (!removeObserverList.Contains(observer))
                {
                    removeObserverList.Remove(observer);
                }
            }
        }

        public void RemoveObserver(string key, Action<OperationType, object> observer)
        {
            //在处理列表里面就移除
            List<Action<OperationType, object>> observerList = GetObserverList(_observers, key);
            if (!_isNotifiyng)
            {
                if (!observerList.Contains(observer))
                {
                    observerList.Remove(observer);
                }
            }
            else
            {
                //如果没在移除列表里面就新增进去等待移除
                List<Action<OperationType, object>> removeObserverList = GetObserverList(_removeObservers, key);
                if (!removeObserverList.Contains(observer))
                {
                    if (observerList.Contains(observer))
                    {
                        removeObserverList.Add(observer);
                    }
                }
                //如果在新增列表里面，移除
                List<Action<OperationType, object>> addObserverList = GetObserverList(_addObservers, key);
                if (addObserverList.Contains(observer))
                {
                    addObserverList.Remove(observer);
                }
            }
        }

        private void NotifiyObservers()
        {
            if (_notifs.Count == 0)
            {
                return;
            }
            //添加通知回调
            _dispatchNotifs.Clear();
            _dispatchNotifs.AddRange(_notifs);
            var childrenIter = _children.GetEnumerator();
            try
            {
                while (childrenIter.MoveNext())
                {
                    childrenIter.Current._notifs.AddRange(_notifs);
                    childrenIter.Current._clock.AddTimer(0f, 0, childrenIter.Current.NotifiyObservers);
                }
            }
            finally
            {
                childrenIter.Dispose();
            }
            _notifs.Clear();

            _isNotifiyng = true;
            //处理具体的通知回调
            for (int i = 0; i < _dispatchNotifs.Count; i++)
            {
                Notification notification = _dispatchNotifs[i];
                if (!_observers.ContainsKey(notification.Key))
                {
                    continue;
                }
                List<Action<OperationType, object>> observerList = GetObserverList(_observers, notification.Key);
                for (int j = 0; j < observerList.Count; j++)
                {
                    Action<OperationType, object> observerCallback = observerList[j];
                    if (_removeObservers.ContainsKey(notification.Key) && _removeObservers[notification.Key].Contains(observerCallback))
                    {
                        continue;
                    }
                    //执行回调
                    observerCallback(notification.OperationType, notification.Value);
                }
            }
            //添加操作
            var addIter = _addObservers.GetEnumerator();
            try
            {
                while (addIter.MoveNext())
                {
                    GetObserverList(_observers, addIter.Current.Key).AddRange(addIter.Current.Value);
                }
            }
            finally
            {
                addIter.Dispose();
            }
            //移除操作
            var removeIter = _removeObservers.GetEnumerator();
            try
            {
                while (removeIter.MoveNext())
                {
                    for (int i = 0; i < removeIter.Current.Value.Count; i++)
                    {
                        Action<OperationType, object> action = removeIter.Current.Value[i];
                        GetObserverList(_observers, removeIter.Current.Key).Remove(action);
                    }
                }
            }
            finally
            {
                removeIter.Dispose();
            }
            _addObservers.Clear();
            _removeObservers.Clear();
            _isNotifiyng = false;
        }

        private List<Action<OperationType, object>> GetObserverList(Dictionary<string, List<Action<OperationType, object>>> target, string key)
        {
            List<Action<OperationType, object>> observers;
            if (target.ContainsKey(key))
            {
                observers = target[key];
            }
            else
            {
                observers = new List<Action<OperationType, object>>();
                target.Add(key, observers);
            }
            return observers;
        }
        #endregion

        #region 取值的操作
        public BDVAL Get<BDVAL>(string key)
        {
            object result = Get(key);
            if (result != null)
            {
                return (BDVAL)result;
            }
            return default;
        }

        public object Get(string key)
        {
            if (_data.ContainsKey(key))
            {
                return _data[key];
            }
            if (_parentBlackboard != null)
            {
                return _parentBlackboard.Get(key);
            }
            return null;
        }

        public bool HasSetKey(string key)
        {
            return _data.ContainsKey(key) || (_parentBlackboard != null && _parentBlackboard.HasSetKey(key));
        }
        #endregion
    }
}
