using System;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 启动，停用时回调函数
    /// </summary>
    public class Observer : Decorator
    {
        private const string NAME = "Observer";
        private Action _onStart;
        private Action<bool> _onStop;
        public Observer(Action onStart, Action<bool> onStop, Node decoratee) : base(NAME, decoratee)
        {
            _onStart = onStart;
            _onStop = onStop;
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (_onStop != null)
            {
                _onStop(succeeded);
            }
            Stopped(succeeded);
        }

        protected override void DoStart()
        {
            if (_onStart != null)
            {
                _onStart();
            }
            Decoratee.Start();
        }

        protected override void DoStop()
        {
            Decoratee.Stop();
        }
    }
}
