namespace Code.Core.AI.BehaviorTree.Task
{
    /// <summary>
    /// 只是等待，等待被其他节点停止。
    /// 它通常用于Selector的末尾，等待任何before头的同级BlackboardCondition、BlackboardQuery或Condition变为活动状态。
    /// </summary>
    public class WaitUntilStopped : Task
    {
        private bool _successWhenStopped = false;
        private const string NAME = "WaitUntilStoppedTask";
        public WaitUntilStopped(bool successWhenStopped = false) : base(NAME)
        {
            _successWhenStopped = successWhenStopped;
        }

        protected override void DoStop()
        {
            Stopped(_successWhenStopped);
        }
    }
}
