namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 逆变节点【成功和失败都是相反的返回】
    /// 如果decoratee成功，则逆变器失败;如果decoratee失败，则逆变器成功。
    /// </summary>
    public class Inverter : Decorator
    {
        private const string NAME = "Inverter";
        public Inverter(Node decoratee) : base(NAME, decoratee)
        {
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            Stopped(!succeeded);
        }

        protected override void DoStart()
        {
            Decoratee.Start();
        }

        protected override void DoStop()
        {
            Decoratee.Stop();
        }
    }
}
