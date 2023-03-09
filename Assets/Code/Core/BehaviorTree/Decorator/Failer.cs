namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 总是返回失败的节点
    /// </summary>
    public class Failer : Decorator
    {
        private const string NAME = "Failer";
        public Failer(Node decoratee) : base(NAME, decoratee)
        {
        }

        protected override void DoStart()
        {
            Decoratee.Start();
        }

        protected override void DoStop()
        {
            Decoratee.Stop();
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            Stopped(false);
        }
    }
}
