namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 总是返回成功的节点，永远要成功，不管装饰器是否成功
    /// </summary>
    public class Succeeder : Decorator
    {
        private const string NAME = "Succeeder";
        public Succeeder(string name, Node decoratee) : base(NAME, decoratee)
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
            Stopped(true);
        }
    }
}
