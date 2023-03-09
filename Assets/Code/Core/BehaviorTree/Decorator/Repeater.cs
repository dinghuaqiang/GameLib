namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 子节点会重复执行n次
    /// </summary>
    public class Repeater : Decorator
    {
        private const string NAME = "Repeater";
        private int _loopCount = -1;
        private int _curLoop = 0;
        /// <summary>
        /// 设置为-1就可以永远重复，要注意无尽循环的问题
        /// </summary>
        /// <param name="loopCount">循环次数</param>
        public Repeater(int loopCount, Node decoratee) : base(NAME, decoratee)
        {
            _loopCount = loopCount;
        }

        /// <summary>
        /// repeated forever
        /// </summary>
        public Repeater(Node decoratee) : base(NAME, decoratee)
        {
            
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (succeeded)
            {
                if (IsStopRequested && (_loopCount > 0 && ++_curLoop >= _loopCount))
                {
                    Stopped(true);
                }
                else
                {
                    Clock.AddTimer(0, 0, RestartDecoratee);
                }
            }
            else
            {
                Stopped(false);
            }
        }

        protected override void DoStart()
        {
            if (_loopCount != 0)
            {
                _curLoop = 0;
                Decoratee.Start();
            }
            else
            {
                Stopped(true);
            }
        }

        protected override void DoStop()
        {
            Clock.RemoveTimer(RestartDecoratee);
            if (Decoratee.IsActive)
            {
                Decoratee.Stop();
            }
            else
            {
                Stopped(false);
            }
        }

        protected void RestartDecoratee()
        {
            Decoratee.Start();
        }
    }
}
