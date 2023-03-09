using System;

namespace Code.Core.AI.BehaviorTree.Task
{
    public class Wait : Task
    {
        #region 变量
        private const string NAME = "WaitTask";
        private Func<float> _callback = null;
        private string _blackboardKey = string.Empty;
        private float _seconds = -1f;
        private float _randomVariance = 0f;
        public float RandomVariance { get { return _randomVariance; } set { _randomVariance = value; } }
        #endregion

        #region 构造函数
        /// <summary>
        /// 等待给定的秒，随机误差为0.05 *秒
        /// </summary>
        public Wait(float seconds) : base(NAME)
        {
            _seconds = seconds;
            _randomVariance = seconds * 0.05f;
        }

        /// <summary>
        /// 用给定的随机变量等待给定的秒数
        /// </summary>
        public Wait(float seconds, float randomVariance) : base(NAME)
        {
            if (seconds >= 0)
            {
                _seconds = seconds;
                _randomVariance = randomVariance;
            }
        }

        /// <summary>
        /// 等待在给定的黑板键中设置为浮点数的秒数
        /// </summary>
        public Wait(string blackboardKey, float randomVariance = 0f) : base(NAME)
        {
            _blackboardKey = blackboardKey;
            _randomVariance = randomVariance;
        }

        /// <summary>
        /// 等待在给定的blackboardKey中设置为float的秒数
        /// </summary>
        public Wait(Func<float> callback, float randomVariance = 0f) : base("Wait")
        {
            _callback = callback;
            _randomVariance = randomVariance;
        }
        #endregion

        #region 开始和结束的处理
        protected override void DoStart()
        {
            if (_seconds < 0)
            {
                if (!string.IsNullOrEmpty(_blackboardKey))
                {
                    _seconds = Blackboard.Get<float>(_blackboardKey);
                }
                else if (_callback != null)
                {
                    _seconds = _callback();
                }
                _seconds = 0;
            }
            if (_randomVariance >= 0f)
            {
                Clock.AddTimer(_seconds, _randomVariance, 0, OnRemoveTimer);
            }
            else
            {
                Clock.AddTimer(_seconds, 0, OnRemoveTimer);
            }
        }

        protected override void DoStop()
        {
            Clock.RemoveTimer(OnRemoveTimer);
            Stopped(false);
        }

        private void OnRemoveTimer()
        {
            Clock.RemoveTimer(OnRemoveTimer);
            Stopped(true);
        }
        #endregion
    }
}
