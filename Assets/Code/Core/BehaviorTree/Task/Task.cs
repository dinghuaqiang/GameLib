namespace Code.Core.AI.BehaviorTree.Task
{
    /// <summary>
    /// 任务节点，这些都是实际工作的整个行为树的树叶。用来具体的做需要处理的逻辑。
    /// 在子类中扩展并覆盖DoStart()和DoStop()方法。
    /// 在DoStart()中，启动逻辑，一旦完成了，将使用适当的结果调用Stopped(bool result)。
    /// 确保实现DoStop()，因为节点可能被另一个节点取消，进行适当的清理并在它之后立即调用Stopped(bool result)。
    /// </summary>
    public abstract class Task : Node
    {
        public Task(string name) : base(name)
        {

        }
    }
}
