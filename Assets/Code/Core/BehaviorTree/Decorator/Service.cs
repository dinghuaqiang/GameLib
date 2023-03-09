using System;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 每帧或周期性调用委托
    /// 包含一个每帧或定时调用委托，开启后，系统会按照一定间隔时间调用委托
    /// </summary>
    public class Service : Decorator
    {
        private const string NAME = "Service";
        private Action _serviceCallBack;
        private float _interval = -1.0f;
        private float _randomVariation;

        /// <summary>
        /// 运行给定的服务函数，启动decoratee，然后在给定的时间间隔内以随机变量的方式运行服务。
        /// </summary>
        public Service(float interval, float randomVariation, Action serviceCallBack, Node decoratee) : base(NAME, decoratee)
        {
            _serviceCallBack = serviceCallBack;
            _interval = interval;
            _randomVariation = randomVariation;
            Label = string.Format("{0}...{1}s", (_interval - _randomVariation), (_interval + _randomVariation));
        }

        /// <summary>
        /// 运行给定的服务函数，启动decoratee，然后按给定的间隔运行服务。
        /// </summary>
        public Service(float interval, Action serviceCallBack, Node decoratee) : base(NAME, decoratee)
        {
            _serviceCallBack = serviceCallBack;
            _interval = interval;
            _randomVariation = interval * 0.05f;
            Label = string.Format("{0}...{1}s", (_interval - _randomVariation), (_interval + _randomVariation));
        }

        /// <summary>
        /// 运行给定的服务函数，启动decoratee，然后每次运行服务。
        /// </summary>
        public Service(Action serviceCallBack, Node decoratee) : base(NAME, decoratee)
        {
            _serviceCallBack = serviceCallBack;
            Label = "Every Tick";
        }

        /// <summary>
        /// 时钟注册服务委托，开启被装饰节点
        /// </summary>
        protected override void DoStart()
        {
            if (_serviceCallBack != null)
            {
                if (_interval <= 0)
                {
                    Clock.AddUpdateObserver(_serviceCallBack);
                    _serviceCallBack();
                }
                if (_randomVariation <= 0)
                {
                    Clock.AddTimer(_interval, -1, _serviceCallBack);
                    _serviceCallBack();
                }
                else
                {
                    ExcuteCallBackWithRandomVariation();
                }
            }
            Decoratee.Start();
        }

        /// <summary>
        /// 关闭被装饰节点
        /// </summary>
        protected override void DoStop()
        {
            Decoratee.Stop();
        }

        /// <summary>
        /// 时钟注销服务委托，停用并返回子节点的执行结果
        /// </summary>
        /// <param name="child"></param>
        /// <param name="succeeded"></param>
        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (_serviceCallBack != null)
            {
                if (_interval <= 0)
                {
                    Clock.RemoveUpdateObserver(_serviceCallBack);
                }
                if (_randomVariation <= 0)
                {
                    Clock.RemoveTimer(_serviceCallBack);
                }
                else
                {
                    Clock.RemoveTimer(ExcuteCallBackWithRandomVariation);
                }
            }
            Stopped(succeeded);
        }

        private void ExcuteCallBackWithRandomVariation()
        {
            _serviceCallBack();
            Clock.AddTimer(_interval, _randomVariation, 0, ExcuteCallBackWithRandomVariation);
        }
    }
}
