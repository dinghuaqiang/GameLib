using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 更新黑板的条件后，影响分支的选择
    /// </summary>
    public class BlackboardCondition : ObservingDecorator
    {
        private const string NAME = "BlackboardCondition";
        private string _key;
        private object _value;
        private Operator _operator;

        /// <summary>
        /// 只有当黑板的键匹配oper / value条件时，才执行decoratee节点。
        /// 如果stopsOnChange不是NONE，则节点将根据stopsOnChange stop规则观察黑板上的变化并停止运行节点的执行。
        /// </summary>
        public BlackboardCondition(string key, Operator oper, object value, Stops stopsOnChange, Node decoratee) : base(NAME, stopsOnChange, decoratee)
        {
            _key = key;
            _value = value;
            _operator = oper;
        }

        /// <summary>
        /// 只有当黑板的键与oper条件匹配时才执行decoratee节点(例如，对于一个只检查IS_SET的操作数操作符)。
        /// 如果stopsOnChange不是NONE，则节点将根据stopsOnChange stop规则观察黑板上的变化并停止运行节点的执行。
        /// </summary>
        public BlackboardCondition(string key, Operator oper, Stops stopsOnChange, Node decoratee) : base(NAME, stopsOnChange, decoratee)
        {
            _key = key;
            _operator = oper;
        }

        protected override bool IsConditionMet()
        {
            if (_operator == Operator.ALWAYS_TRUE)
            {
                return true;
            }

            if (!RootNode.Blackboard.HasSetKey(_key))
            {
                return _operator == Operator.IS_NOT_SET;
            }

            object bdObject = RootNode.Blackboard.Get(_key);

            switch (_operator)
            {
                case Operator.IS_SET: return true;
                case Operator.IS_EQUAL: return object.Equals(bdObject, _value);
                case Operator.IS_NOT_EQUAL: return !object.Equals(bdObject, _value);

                case Operator.IS_GREATER_OR_EQUAL:
                    if (bdObject is float)
                    {
                        return (float)bdObject >= (float)_value;
                    }
                    else if (bdObject is int)
                    {
                        return (int)bdObject >= (int)_value;
                    }
                    else
                    {
                        Debug.LogError("类型无法比较: " + bdObject.GetType());
                        return false;
                    }

                case Operator.IS_GREATER:
                    if (bdObject is float)
                    {
                        return (float)bdObject > (float)_value;
                    }
                    else if (bdObject is int)
                    {
                        return (int)bdObject > (int)_value;
                    }
                    else
                    {
                        Debug.LogError("类型无法比较: " + bdObject.GetType());
                        return false;
                    }

                case Operator.IS_SMALLER_OR_EQUAL:
                    if (bdObject is float)
                    {
                        return (float)bdObject <= (float)_value;
                    }
                    else if (bdObject is int)
                    {
                        return (int)bdObject <= (int)_value;
                    }
                    else
                    {
                        Debug.LogError("类型无法比较: " + bdObject.GetType());
                        return false;
                    }

                case Operator.IS_SMALLER:
                    if (bdObject is float)
                    {
                        return (float)bdObject < (float)_value;
                    }
                    else if (bdObject is int)
                    {
                        return (int)bdObject < (int)_value;
                    }
                    else
                    {
                        Debug.LogError("类型无法比较: " + bdObject.GetType());
                        return false;
                    }

                default: return false;
            }
        }

        protected override void StartObserving()
        {
            RootNode.Blackboard.AddObserver(_key, OnValueChange);
        }

        protected override void StopObserving()
        {
            RootNode.Blackboard.RemoveObserver(_key, OnValueChange);
        }

        private void OnValueChange(Blackboard.OperationType operationType, object newValue)
        {
            Evaluate();
        }
    }
}
