using System;
using System.Collections.Generic;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 计时器类,每个黑板都带有一个计时器
    /// 主要处理定时调用委托，每帧调用委托
    /// </summary>
    public class Clock
    {
        #region Timer内部类
        /// <summary>
        /// 内部类，主要记录计时的各种行为和参数，负责管理每帧调用的委托和定时调用的委托。
        /// </summary>
        private class Timer
        {
            public double ScheduledTime = 0f;
            public int Repeat = 0;
            public bool Used = false;
            public double Delay = 0f;
            public float RandomVariance = 0.0f;

            public void ScheduleAbsoluteTime(double elapsedTime)
            {
                ScheduledTime = elapsedTime + Delay - RandomVariance * 0.5f + RandomVariance * UnityEngine.Random.value;
            }
        }
        #endregion

        #region 变量
        /// <summary>
        /// 是否正在进行Update
        /// </summary>
        private bool IsInUpdate;
        /// <summary>
        /// 流逝的时间
        /// </summary>
        private double _elapsedTime;
        /// <summary>
        /// 当前选中的计时器池索引
        /// </summary>
        private int _curTimerPoolIndex;
        //计时器池，缓存Timer，避免重复创建
        private List<Timer> _timerPool;
        //正在计时的计时器列表
        private Dictionary<Action, Timer> _timers;
        //新增的计时器列表
        private Dictionary<Action, Timer> _addTimers;
        //需要移除的计时器列表
        private HashSet<Action> _removeTimers;
        //每帧调用的回调容器
        private List<Action> _updateObservers;
        //待删除的回调容器
        private HashSet<Action> _removeObservers;
        //待添加的回调容器
        private HashSet<Action> _addObservers;

        /// <summary>
        /// 每帧调用的回调数量
        /// </summary>
        public int NumUpdateObservers
        {
            get
            {
                return _updateObservers.Count;
            }
        }

        /// <summary>
        /// 定时调用的回调数量
        /// </summary>
        public int NumTimers
        {
            get
            {
                return _timers.Count;
            }
        }

        /// <summary>
        /// 已流逝的时间
        /// </summary>
        public double ElapsedTime
        {
            get
            {
                return _elapsedTime;
            }
        }
        #endregion

        #region 数据初始化
        public Clock()
        {
            Initialize();
        }

        /// <summary>
        /// 初始化各种存储数据结构
        /// </summary>
        private void Initialize()
        {
            IsInUpdate = false;
            _elapsedTime = 0f;
            _curTimerPoolIndex = 0;
            _timerPool = new List<Timer>();
            _timers = new Dictionary<Action, Timer>();
            _updateObservers = new List<Action>();
            _removeObservers = new HashSet<Action>();
            _addObservers = new HashSet<Action>();
            _removeTimers = new HashSet<Action>();
            _addTimers = new Dictionary<Action, Timer>();
        }
        #endregion

        #region 计时器模块
        /// <summary>
        /// 注册计时器
        /// </summary>
        /// <param name="time">毫秒</param>
        /// <param name="repeat">重复执行的次数，-1为无限次数(直到移除计时器为止)</param>
        /// <param name="action">执行的回调函数</param>
        public void AddTimer(float time, int repeat, Action action)
        {
            AddTimer(time, 0f, repeat, action);
        }

        /// <summary>
        /// 注册一个随机时间的计时器
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="randomVariance"></param>
        /// <param name="repeat"></param>
        /// <param name="action"></param>
        public void AddTimer(float delay, float randomVariance, int repeat, Action action)
        {
            Timer timer = null;
            if (!IsInUpdate)
            {
                if (!_timers.ContainsKey(action))
                {
                    _timers[action] = GetTimerFromPool();
                }
                timer = _timers[action];
            }
            else
            {
                //添加回调到新增列表
                if (!_addTimers.ContainsKey(action))
                {
                    _addTimers[action] = GetTimerFromPool();
                }
                timer = _addTimers[action];
                //如果有这个回调就添加到移除列表
                if (_removeTimers.Contains(action))
                {
                    _removeTimers.Remove(action);
                }
            }
            //设置Timer新的参数
            if (!timer.Used)
            {
                timer.Delay = delay;
                timer.RandomVariance = randomVariance;
                timer.Repeat = repeat;
                timer.ScheduleAbsoluteTime(_elapsedTime);
            }
        }

        /// <summary>
        /// 根据回调函数移除计时器
        /// </summary>
        /// <param name="action"></param>
        public void RemoveTimer(Action action)
        {
            if (!IsInUpdate)
            {
                if (_timers.ContainsKey(action))
                {
                    _timers[action].Used = false;
                    _timers.Remove(action);
                }
            }
            else
            {
                if (_timers.ContainsKey(action))
                {
                    _removeTimers.Add(action);
                }
                if (_addTimers.ContainsKey(action))
                {
                    if (_addTimers[action].Used)
                    {
                        _addTimers[action].Used = false;
                        _addTimers.Remove(action);
                    }
                }
            }
        }

        public bool HasTimer(Action action)
        {
            if (!IsInUpdate)
            {
                return _timers.ContainsKey(action);
            }
            else
            {
                if (_removeTimers.Contains(action))
                {
                    return false;
                }
                else if (_addTimers.ContainsKey(action))
                {
                    return true;
                }
                else
                {
                    return _timers.ContainsKey(action);
                }
            }
        }

        /// <summary>
        /// 从缓存中取一个Timer
        /// </summary>
        /// <returns></returns>
        private Timer GetTimerFromPool()
        {
            Timer timer = null;
            //从缓存池找一个可用的
            int index = 0;
            int cacheCount = _timerPool.Count;
            while (index < cacheCount)
            {
                int timerIndex = (index + _curTimerPoolIndex) % cacheCount;
                if (!_timerPool[timerIndex].Used)
                {
                    _curTimerPoolIndex = timerIndex;
                    timer = _timerPool[timerIndex];
                    break;
                }
                index++;
            }
            //缓存池找不到可用的就创建一个
            if (timer == null)
            {
                timer = new Timer();
                _curTimerPoolIndex = 0;
                _timerPool.Add(timer);
            }
            timer.Used = true;
            return timer;
        }
        #endregion

        #region 帧更新回调函数的处理
        /// <summary>
        /// 注册一个每帧调用的回调函数
        /// </summary>
        /// <param name="action">回调函数</param>
        public void AddUpdateObserver(Action action)
        {
            if (!IsInUpdate)
            {
                _updateObservers.Add(action);
            }
            else
            {
                if (!_updateObservers.Contains(action))
                {
                    _addObservers.Add(action);
                }
                if (_removeObservers.Contains(action))
                {
                    _removeObservers.Remove(action);
                }
            }
        }

        public void RemoveUpdateObserver(Action action)
        {
            if (!IsInUpdate)
            {
                _updateObservers.Remove(action);
            }
            else
            {
                if (_updateObservers.Contains(action))
                {
                    _removeObservers.Remove(action);
                }
                if (_addObservers.Contains(action))
                {
                    _addObservers.Remove(action);
                }
            }
        }

        public bool HasUpdateObserver(System.Action action)
        {
            if (!IsInUpdate)
            {
                return _updateObservers.Contains(action);
            }
            else
            {
                if (_removeObservers.Contains(action))
                {
                    return false;
                }
                else if (_addObservers.Contains(action))
                {
                    return true;
                }
                else
                {
                    return _updateObservers.Contains(action);
                }
            }
        }
        #endregion

        #region 帧更新
        /// <summary>
        /// 通过BehaviorContext脚本挂载，从Unity的Update过来执行帧更新操作
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            _elapsedTime += deltaTime;
            IsInUpdate = true;
            foreach (var action in _updateObservers)
            {
                if (!_removeObservers.Contains(action))
                {
                    if (action != null) action();
                }
            }
            Dictionary<Action, Timer>.KeyCollection keys = _timers.Keys;
            foreach (Action callback in keys)
            {
                if (_removeTimers.Contains(callback))
                {
                    continue;
                }

                Timer timer = _timers[callback];
                if (timer.ScheduledTime <= _elapsedTime)
                {
                    if (timer.Repeat == 0)
                    {
                        RemoveTimer(callback);
                    }
                    else if (timer.Repeat >= 0)
                    {
                        timer.Repeat--;
                    }
                    if (callback != null) callback();
                    timer.ScheduleAbsoluteTime(_elapsedTime);
                }
            }

            foreach (Action action in _addObservers)
            {
                _updateObservers.Add(action);
            }
            foreach (Action action in _removeObservers)
            {
                _updateObservers.Remove(action);
            }
            foreach (Action action in _addTimers.Keys)
            {
                if (_timers.ContainsKey(action))
                {
                    if (!ReferenceEquals(_timers[action], _addTimers[action]) || !_timers[action].Equals(_addTimers[action]))
                    {
                        _timers[action].Used = false;
                    }
                }
                if (_addTimers[action].Used)
                {
                    _timers[action] = _addTimers[action];
                }
            }
            foreach (Action action in _removeTimers)
            {
                if (_timers[action].Used)
                {
                    _timers[action].Used = false;
                    _timers.Remove(action);
                }
            }
            _addObservers.Clear();
            _removeObservers.Clear();
            _addTimers.Clear();
            _removeTimers.Clear();
            IsInUpdate = false;
        }
        #endregion
    }
}
