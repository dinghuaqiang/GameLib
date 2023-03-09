namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 以给定的概率，0到1运行decoratee。有一定概率不启动子节点
    /// </summary>
    public class Random : Decorator
    {
        private const string NAME = "Random";
        private float _probability;

        public Random(float probability, Node decoratee) : base(NAME, decoratee)
        {
            _probability = probability;
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            Stopped(succeeded);
        }

        protected override void DoStart()
        {
            //UnityEngine.Random.value返回 0-1之间的数值
            if (UnityEngine.Random.value <= _probability)
            {
                Decoratee.Start();
            }
            else
            {
                Stopped(false);
            }
        }

        protected override void DoStop()
        {
            Decoratee.Stop();
        }
    }
}
