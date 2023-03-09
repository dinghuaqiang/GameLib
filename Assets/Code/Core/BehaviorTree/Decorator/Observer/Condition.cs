using System;

namespace Code.Core.AI.BehaviorTree
{
    public class Condition : ObservingDecorator
    {
        private const string NAME = "Condition";
        private Func<bool> _condition;
        private float _checkInterval;
        private float _checkVariance;

        /// <summary>
        /// 如果给定条件返回true，则执行decoratee节点
        /// </summary>
        public Condition(Func<bool> condition, Node decoratee) : base(NAME, Stops.NONE, decoratee)
        {
            _condition = condition;
            _checkInterval = 0;
            _checkVariance = 0;
        }

        /// <summary>
        /// 如果给定条件返回true，则执行decoratee节点。根据stopsOnChange stop规则重新评估每个帧的条件并停止运行节点。
        /// </summary>
        public Condition(Func<bool> condition, Stops stopsOnChange, Node decoratee) : base(NAME, stopsOnChange, decoratee)
        {
            _condition = condition;
            _checkInterval = 0;
            _checkVariance = 0;
        }

        /// <summary>
        /// 如果给定条件返回true，则执行decoratee节点。在给定的校验间隔和随机方差处重新评估条件，并根据stopsOnChange stop规则停止运行节点。
        /// 每帧执行函数，影响分支的选择
        /// </summary>
        public Condition(Func<bool> condition, Stops stopsOnChange, float checkInterval, float randomVariance, Node decoratee) : base(NAME, stopsOnChange, decoratee)
        {
            _condition = condition;
            _checkInterval = checkInterval;
            _checkVariance = randomVariance;
        }

        protected override bool IsConditionMet()
        {
            return _condition();
        }

        protected override void StartObserving()
        {
            RootNode.Clock.AddTimer(_checkInterval, _checkVariance, -1, Evaluate);
        }

        protected override void StopObserving()
        {
            RootNode.Clock.RemoveTimer(Evaluate);
        }
    }
}
