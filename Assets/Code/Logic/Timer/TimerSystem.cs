using System.Collections.Generic;

namespace Code.Logic.Timer
{
    /// <summary>
    /// 定时器系统
    /// </summary>
    public class TimerSystem
    {
        //设置成单例
        private static TimerSystem _instance = null;
        public static TimerSystem GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TimerSystem();
                _instance.Initialize();
            }
            return _instance;
        }

        //TimerID 自增
        private int _autoIncreTimerID = 1;
        //回调
        public delegate void TimerCallBack(object param);
        //所有的计时器
        private Dictionary<int, TimerNode> _timerDict = null;
        //缓存中的计时器队列
        private List<TimerNode> _cachedList = null;
        //需要移除的计时器队列
        private List<TimerNode> _removeList = null;

        /// <summary>
        /// 初始化数据存储的结构
        /// </summary>
        public void Initialize()
        {
            _timerDict = new Dictionary<int, TimerNode>();
            _autoIncreTimerID = 1;
            _cachedList = new List<TimerNode>();
            _removeList = new List<TimerNode>();
        }

        public void UnInitialize()
        {
            _timerDict.Clear();
            _autoIncreTimerID = 1;
            _cachedList.Clear();
            _removeList.Clear();
        }

        public void Update(float deltaTime)
        {
            //把缓存中的计时器添加到总字典
            for (int i = 0; i < _cachedList.Count; i++)
            {
                TimerNode timer = _cachedList[i];
                _timerDict.Add(timer.timerID, timer);
            }
            _cachedList.Clear();

            var iter = _timerDict.GetEnumerator();
            while (iter.MoveNext())
            {
                var timer = iter.Current.Value;
                //判断计时器是否需要进行移除，添加到队列去移除
                if (timer.isRemoved)
                {
                    _removeList.Add(timer);
                    continue;
                }
                //更新计时的时间
                timer.elapseTime += deltaTime;
                //计时器到点了，执行回调，放到移除队列去
                if (timer.elapseTime >= (timer.delay + timer.duration))
                {
                    //执行回调
                    timer.callback(timer.param);
                    //执行次数减1次
                    timer.repeat--;
                    //更新运行的时间
                    timer.elapseTime -= (timer.delay + timer.duration);
                    timer.delay = 0;
                    //如果执行次数完成了就添加到移除队列去
                    if (timer.repeat <= 0)
                    {
                        timer.isRemoved = true;
                        _removeList.Add(timer);
                    }
                }
            }
            //清空需要移除的计时器
            for (int i = 0; i < _removeList.Count; i++)
            {
                TimerNode timer = _removeList[i];
                _timerDict.Remove(timer.timerID);
            }
            _removeList.Clear();
        }

        public int ScheduleOnce(TimerCallBack callback, float delay)
        {
            return Schedule(callback, 1, 0, delay);
        }

        public int ScheduleOnce(TimerCallBack callback, object param, float delay)
        {
            return Schedule(callback, param, 1, delay);
        }

        public int Schedule(TimerCallBack callback, int repeat, float duration, float delay = 0)
        {
            return Schedule(callback, null, repeat, duration, delay);
        }

        /// <summary>
        /// 执行定时器
        /// </summary>
        /// <param name="callback">设置回调函数</param>
        /// <param name="param">设置回调的参数，在到点的时候回传到回调函数</param>
        /// <param name="repeat">执行的次数</param>
        /// <param name="duration">需要定时的时间（秒）</param>
        /// <param name="delay">延迟的时间（秒）</param>
        /// <returns></returns>
        public int Schedule(TimerCallBack callback, object param, int repeat, float duration, float delay = 0f)
        {
            TimerNode timerNode = new TimerNode();
            timerNode.callback = callback;
            timerNode.param = param;
            timerNode.repeat = repeat;
            timerNode.duration = duration;
            timerNode.delay = delay;
            timerNode.elapseTime = duration;
            timerNode.isRemoved = false;
            timerNode.timerID = _autoIncreTimerID;
            _autoIncreTimerID++;
            _cachedList.Add(timerNode);
            return timerNode.timerID;
        }

        /// <summary>
        /// 移除计时器
        /// </summary>
        /// <param name="timerID"></param>
        public void UnSchedue(int timerID)
        {
            if (!_timerDict.ContainsKey(timerID))
            {
                return;
            }
            TimerNode timer = null;
            _timerDict.TryGetValue(timerID, out timer);
            if (timer != null)
            {
                timer.isRemoved = true;
            }
        }

        /// <summary>
        /// 计时器节点
        /// </summary>
        private class TimerNode
        {
            //回调
            public TimerCallBack callback;
            //触发的时间间隔
            public float duration;
            //第一次触发要间隔多少时间
            public float delay;
            //触发的次数
            public int repeat;
            //流逝的时间
            public float elapseTime;
            //用户传递的参数
            public object param;
            //是否已经移除掉了
            public bool isRemoved;
            //Timer的ID
            public int timerID;
        }
    }
}