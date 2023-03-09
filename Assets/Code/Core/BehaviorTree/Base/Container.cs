namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 抽象出子节点执行完毕返回父节点后的父节点收尾工作
    /// </summary>
    public abstract class Container : Node
    {
        /// <summary>
        /// 是否处于崩溃状态
        /// </summary>
        public bool IsCollapse = false;

        public Container(string name) : base(name)
        {

        }

        /// <summary>
        /// 某个子节点要停用，做一些收尾工作
        /// </summary>
        /// <param name="child">节点</param>
        /// <param name="succeeded">是否停止成功</param>
        public void ChildStopped(Node child, bool succeeded)
        {
            this.DoChildStopped(child, succeeded);
        }

        /// <summary>
        /// 某个子节点停用并返回执行结果时应该做什么收尾？
        /// 子类具体实现停止的操作，子类会通过Node节点的Stopped继续调用其他子节点的DoChildStopped
        /// </summary>
        /// <param name="child"></param>
        /// <param name="succeeded">子节点的执行结果为true or false</param>
        protected abstract void DoChildStopped(Node child, bool succeeded);
    }
}
