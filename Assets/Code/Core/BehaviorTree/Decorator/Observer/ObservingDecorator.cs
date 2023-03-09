namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 观察装饰器,这是个简单的条件装饰器，根据特定的条件使用stopsOnChange终止
    /// 监听条件是否满足，更新父组合节点启用当前分支
    /// 主要处理：当满足的条件 与 当前节点状态矛盾时，令组合节点 更新它的分支 开启/关闭 对条件变量的监听
    /// </summary>
    public abstract class ObservingDecorator : Decorator
    {
        protected Stops _stopsOnChange;
        private bool _isObserving;

        public ObservingDecorator(string name, Stops stopsOnChange, Node decoratee) : base(name, decoratee)
        {
            _stopsOnChange = stopsOnChange;
            _isObserving = false;
        }

        /// <summary>
        /// 开始监听时做什么？（时钟注册Evaluate）
        /// </summary>
        protected abstract void StartObserving();
        /// <summary>
        /// 停止监听时做什么？（时钟注销Evaluate）
        /// </summary>
        protected abstract void StopObserving();
        /// <summary>
        /// 主要写满足什么样的条件逻辑
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsConditionMet();

        protected override void DoStart()
        {
            if (_stopsOnChange != Stops.NONE)
            {
                if (!_isObserving)
                {
                    _isObserving = true;
                    StartObserving();
                }
            }

            if (!IsConditionMet())
            {
                Stopped(false);
            }
            else
            {
                Decoratee.Start();
            }
        }

        protected override void DoStop()
        {
            Decoratee.Stop();
        }

        protected override void DoParentCompositeStopped(Composite composite)
        {
            if (_isObserving)
            {
                _isObserving = false;
                StopObserving();
            }
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (CurState != State.INACTIVE)
            {
                if (_stopsOnChange == Stops.NONE || _stopsOnChange == Stops.SELF)
                {
                    if (_isObserving)
                    {
                        _isObserving = false;
                        StopObserving();
                    }
                }
                Stopped(succeeded);
            }
        }

        /// <summary>
        /// 根据当前条件是否被满足，重置当前节点状态与父组合节点的分支状态
        /// </summary>
        protected void Evaluate()
        {
            if (IsActive && !IsConditionMet())
            {
                if (_stopsOnChange == Stops.SELF || _stopsOnChange == Stops.BOTH || _stopsOnChange == Stops.IMMEDIATE_RESTART)
                {
                    Stop();
                }
            }
            else if (!IsActive && IsConditionMet())
            {
                if (_stopsOnChange == Stops.LOWER_PRIORITY || _stopsOnChange == Stops.BOTH || _stopsOnChange == Stops.IMMEDIATE_RESTART || _stopsOnChange == Stops.LOWER_PRIORITY_IMMEDIATE_RESTART)
                {
                    Container parentNode = ParentNode;
                    Node childNode = this;
                    while (parentNode != null && !(parentNode is Composite))
                    {
                        childNode = parentNode;
                        parentNode = ParentNode;
                    }
                    if (parentNode != null)
                    {
                        if ((parentNode is Parallel) && _stopsOnChange == Stops.IMMEDIATE_RESTART)
                        {
                            UnityEngine.Debug.LogError("在并行节点上，所有的子节点都有相同的优先级，因此在这种情况下，Stops.LOWER_PRIORITY或Stops.BOTH是不被支持的。");
                        }
                        if (_stopsOnChange == Stops.IMMEDIATE_RESTART || _stopsOnChange == Stops.LOWER_PRIORITY_IMMEDIATE_RESTART)
                        {
                            if (_isObserving)
                            {
                                _isObserving = false;
                                StopObserving();
                            }
                        }
                    }
                    if (childNode != null)
                    {
                        ((Composite)parentNode).StopLowerPriorityChildrenForChild(childNode, _stopsOnChange == Stops.IMMEDIATE_RESTART || _stopsOnChange == Stops.LOWER_PRIORITY_IMMEDIATE_RESTART);
                    }
                }
            }
        }
    }
}
