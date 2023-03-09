using System;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 更新黑板后，执行函数，影响分支的选择
    /// </summary>
    public class BlackboardQuery : ObservingDecorator
    {
        private const string NAME = "BlackboardQuery";
        private string[] _keys;
        private Func<bool> _queryFunc;

        /// <summary>
        /// BlackboardCondition只允许检查一个键，而这个将观察多个黑板键，并在其中一个值发生变化时立即计算给定的查询函数，从而允许在黑板上执行任意查询。
        /// 它将根据stopsOnChange stop规则停止运行节点。
        /// </summary>
        public BlackboardQuery(string[] keys, Stops stopsOnChange, Func<bool> query, Node decoratee) : base(NAME, stopsOnChange, decoratee)
        {
            _keys = keys;
            _queryFunc = query;
        }

        protected override bool IsConditionMet()
        {
            return _queryFunc();
        }

        protected override void StartObserving()
        {
            if (_keys != null)
            {
                for (int i = 0; i < _keys.Length; i++)
                {
                    RootNode.Blackboard.AddObserver(_keys[i], OnValueChanged);
                }
            }
        }

        protected override void StopObserving()
        {
            if (_keys != null)
            {
                for (int i = 0; i < _keys.Length; i++)
                {
                    RootNode.Blackboard.RemoveObserver(_keys[i], OnValueChanged);
                }
            }
        }

        private void OnValueChanged(Blackboard.OperationType operationType, object value)
        {
            Evaluate();
        }
    }
}
