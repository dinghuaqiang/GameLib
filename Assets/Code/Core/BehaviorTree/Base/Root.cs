namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 根节点，只有一个子节点可以启动或者停止整个行为树
    /// </summary>
    public class Root : Decorator
    {
        #region 变量
        /// <summary>
        /// 主节点，行为树的入口节点
        /// </summary>
        private Node _mainNode;
        private Blackboard _blackboard;
        private Clock _clock;
        /// <summary>
        /// 节点名称
        /// </summary>
        private const string NAME = "Root";

        public override Blackboard Blackboard
        {
            get
            {
                return _blackboard;
            }
        }

        public override Clock Clock
        {
            get
            {
                return _clock;
            }
        }
        #endregion

        #region 构造函数
        public Root(Node mainNode) : base(NAME, mainNode)
        {
            _mainNode = mainNode;
            //自动创建计时器和黑板提供给子节点使用
            _clock = BehaviorContext.GetClock();
            _blackboard = new Blackboard(_clock);
            SetRoot(this);
        }

        public Root(Blackboard blackboard, Node mainNode) : base(NAME, mainNode)
        {
            _mainNode = mainNode;
            _blackboard = blackboard;
            _clock = BehaviorContext.GetClock();
            SetRoot(this);
        }

        public Root(Blackboard blackboard, Node mainNode, Clock clock) : base(NAME, mainNode)
        {
            _mainNode = mainNode;
            _blackboard = blackboard;
            _clock = clock;
            SetRoot(this);
        }
        #endregion

        #region 实现重载函数
        public override void SetRoot(Root rootNode)
        {
            base.SetRoot(rootNode);
            _mainNode.SetRoot(rootNode);
        }

        /// <summary>
        /// 启动主节点
        /// </summary>
        protected override void DoStart()
        {
            //开启黑板，给所有子节点挂载黑板
            _blackboard.Enable();
            //执行子节点
            _mainNode.Start();
        }

        /// <summary>
        /// 关闭主节点
        /// </summary>
        protected override void DoStop()
        {
            //需要停止的时候检查是否正在运行
            if (_mainNode.IsActive)
            {
                //停止节点
                _mainNode.Stop();
            }
            else
            {
                //移除正在计时的节点，不再执行
                _clock.RemoveTimer(_mainNode.Start);
            }
        }

        /// <summary>
        /// 主节点执行完毕并返回结果，如果根节点正在停止，那么返回主节点执行结果并停止，否则重启主节点。
        /// </summary>
        /// <param name="child"></param>
        /// <param name="succeeded"></param>
        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (!IsStopRequested)
            {
                //等待Tick, 防止递归
                _clock.AddTimer(0, 0, _mainNode.Start);
            }
            else
            {
                //移除子节点的黑板，移除计时行为
                _blackboard.Disable();
                //停止所有子节点
                Stopped(succeeded);
            }
        }
        #endregion
    }
}
