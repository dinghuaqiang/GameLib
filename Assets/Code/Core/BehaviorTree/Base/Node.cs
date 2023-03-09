namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 所有行为节点的根节点
    /// 节点的生命周期由 start() stop() stopped(bool)三个函数来控制
    /// </summary>
    public abstract class Node
    {
        #region 枚举
        public enum State
        {
            //节点已停止。
            INACTIVE,
            //节点已启动，但尚未停止。
            ACTIVE,
            //节点当前正在停止，但尚未调用Stopped()来通知父节点。
            STOP_REQUESTED,
        }
        #endregion

        #region 变量
        private string _label;
        private string _name;
        private Container _parentNode;
        protected State _curState = State.INACTIVE;
        public Root RootNode;
        public State CurState
        {
            get
            {
                return _curState;
            }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        /// <summary>
        /// 节点是否被停止
        /// </summary>
        public bool IsStopRequested
        {
            get
            {
                return _curState == State.STOP_REQUESTED;
            }
        }

        public bool IsActive
        {
            get
            {
                return _curState == State.ACTIVE;
            }
        }

        public Container ParentNode
        {
            get
            {
                return _parentNode;
            }
        }

        public virtual Blackboard Blackboard
        {
            get
            {
                return RootNode.Blackboard;
            }
        }

        public virtual Clock Clock
        {
            get
            {
                return RootNode.Clock;
            }
        }
        #endregion

        #region 构造函数
        public Node(string name)
        {
            _name = name;
        }
        #endregion

        #region 给子类继承实现的虚函数
        /// <summary>
        /// 启动，INACTIVE => ACTIVE
        /// </summary>
        public void Start()
        {
            if (_curState == State.INACTIVE)
            {
                _curState = State.ACTIVE;
                DoStart();
            }
            else
            {
                UnityEngine.Debug.LogError("只能启动未激活的节点。");
            }
        }

        /// <summary>
        /// 停止 ACTIVE => STOP_REQUESTED
        /// </summary>
        public void Stop()
        {
            if (_curState == State.ACTIVE)
            {
                _curState = State.STOP_REQUESTED;
                DoStop();
            }
            else
            {
                UnityEngine.Debug.LogError("只能停止已激活的节点。");
            }
        }

        /// <summary>
        /// 启用节点时的回调
        /// </summary>
        protected virtual void DoStart() { }
        /// <summary>
        /// 关闭节点时的回调
        /// 每次调用DoStop()都必须导致调用Stopped(result)，需要确保在DoStop()中调用了Stopped()
        /// 行为树需要能够在运行时立即取消正在运行的分支。这也意味着所有的子节点也将调用Stopped()
        /// 这反过来又使得它很容易编写可靠的decorator甚至composite节点:在DoStop()里只需要调用active状态下的孩子Stop()函数,他们将轮流执行ChildStopped()。
        /// `最终会回溯到上层节点的Stopped()函数！`
        /// </summary>
        protected virtual void DoStop() { }

        /// <summary>
        /// 设置Root节点
        /// </summary>
        /// <param name="rootNode"></param>
        public virtual void SetRoot(Root rootNode)
        {
            RootNode = rootNode;
        }

        /// <summary>
        /// 设置父节点
        /// </summary>
        public virtual void SetParent(Container parent)
        {
            _parentNode = parent;
        }

        /// <summary>
        /// 停止节点，保证这个函数在最后才调用，在调用之后不要再去做任何状态的修改，这是因为Stopped将立即继续遍历其他节点上的树，如果不考虑这一点，将完全破坏行为树的状态。
        /// </summary>
        /// <param name="success">执行结果true或者false，返回给父节点做收尾工作</param>
        protected virtual void Stopped(bool success)
        {
            if (_curState != State.INACTIVE)
            {
                _curState = State.INACTIVE;
                if (ParentNode != null)
                {
                    ParentNode.ChildStopped(this, success);
                }
            }
            else
            {
                UnityEngine.Debug.LogError("不能在非激活状态下停止节点!");
            }
        }

        /// <summary>
        /// 某个先祖Composite节点停用时，做一些收尾工作
        /// </summary>
        /// <param name="composite"></param>
        public virtual void ParentCompositeStopped(Composite composite)
        {
            DoParentCompositeStopped(composite);
        }

        /// <summary>
        /// 关闭父组合节点时的回调,这个是提供给节点在 [INACTIVE] 状态的时候调用的，目的是让装饰者删除任何待定的观察者。
        /// </summary>
        /// <param name="composite"></param>
        protected virtual void DoParentCompositeStopped(Composite composite)
        {

        }
        #endregion

        #region 重载函数
        public override string ToString()
        {
            return !string.IsNullOrEmpty(Label) ? string.Format("{0}{{1}}", Name, Label) : Name;
        }

        protected string GetPath()
        {
            if (ParentNode != null)
            {
                return string.Format("{0}/{1}", ParentNode.GetPath(), Name);
            }
            else
            {
                return Name;
            }
        }
        #endregion
    }
}
