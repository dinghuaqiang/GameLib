using System;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 满足条件后才能启动子节点
    /// </summary>
    public class WaitForCondition : Decorator
    {
        private const string NAME = "WaitForCondition";
        private Func<bool> _conditionCallback;
        private float _checkInterval;
        private float _checkVariance;

        /// <summary>
        /// 延迟decoratee节点的执行，直到条件为真，检查每一帧
        /// </summary>
        public WaitForCondition(Func<bool> condition, Node decoratee) : base(NAME, decoratee)
        {
            _conditionCallback = condition;
            _checkInterval = 0f;
            _checkVariance = 0f;
            Label = "Every tick";
        }

        /// <summary>
        /// 延迟decoratee节点的执行，直到条件为真，使用给定的checkInterval和randomVariance进行检查
        /// </summary>
        public WaitForCondition(Func<bool> condition, float interval, float randomVariance, Node decoratee) : base(NAME, decoratee)
        {
            _conditionCallback = condition;
            _checkInterval = interval;
            _checkVariance = randomVariance;
            Label = string.Format("{0}...{1}s", (_checkInterval - _checkVariance), (_checkInterval + _checkVariance));
        }

        protected override void DoStart()
        {
            if (!_conditionCallback())
            {
                Clock.AddTimer(_checkInterval, _checkVariance, -1, CheckCondition);
            }
            else
            {
                Decoratee.Start();
            }
        }

        protected override void DoStop()
        {
            Clock.RemoveTimer(CheckCondition);
            if (Decoratee.IsActive)
            {
                Decoratee.Stop();
            }
            else
            {
                Stopped(false);
            }
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (CurState != State.INACTIVE)
            {
                Stopped(succeeded);
            }
        }

        private void CheckCondition()
        {
            if (_conditionCallback())
            {
                Clock.RemoveTimer(CheckCondition);
                Decoratee.Start();
            }
        }
    }
}
