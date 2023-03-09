namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// Cooldown 类似于技能CD
    /// </summary>
    public class Cooldown : Decorator
    {
        private const string NAME = "Cooldown";
        //true:施放技能结束后，才进入cd  false:施放技能开始时，立即进入cd（默认）
        private bool _startAfterDecoratee = false;
        //true:取消技能施放时(被装饰节点停用返回false),重置cd false:取消技能施放时，不重置cd（默认）
        private bool _resetOnFailiure = false;
        //true:技能没有准备好却被用户请求施放时停用当前节点返回false false:什么都不做
        private bool _failOnCoolDown = false;
        //技能冷却时间
        private float _cooldownTime = 0.0f;
        //技能冷却时间随机扰乱因子
        private float _randomVariation = 0.05f;
        //技能是否已经准备好
        private bool _isReady = true;

        /// <summary>
        /// Cooldown装饰器确保在给定的cooldown时间内，分支不能被启动两次。
        /// 装饰器可以立即启动冷却时间，也可以等到孩子停止时再启动，可以用`startAfterDecoratee`参数控制这一行为。
        /// 如果冷却计时器处于激活状态，并且该节点再次被启动，那么默认的行为是，装饰器会等待，直到达到冷却时间，然后执行底层节点。
        /// 可以通过`failOnCooldown`参数改变这一行为，使装饰器立即失效。
        /// </summary>
        /// <param name="cooldownTime">距离下一次执行的时间</param>
        /// <param name="randomVariation">在冷却时间上增加的随机变化时间</param>
        /// <param name="startAfterDecoratee">如果设置为true，则冷却时间从被装饰者启动后开始计算，否则将立即启动。</param>
        /// <param name="resetOnFailiure">如果设置为true，在底层节点发生故障时，定时器将被重置。</param>
        /// <param name="failOnCooldown">如果当前处于冷却状态，并且该参数被设置为true，那么装饰器将立即失败，而不是等待冷却时间。</param>
        /// <param name="decoratee">装饰节点</param>
        public Cooldown(float cooldownTime, float randomVariation, bool startAfterDecoratee, bool resetOnFailiure, bool failOnCooldown, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _cooldownTime = cooldownTime;
            _randomVariation = randomVariation;
            _startAfterDecoratee = startAfterDecoratee;
            _resetOnFailiure = resetOnFailiure;
            _failOnCoolDown = failOnCooldown;
        }

        public Cooldown(float cooldownTime, bool startAfterDecoratee, bool resetOnFailiure, bool failOnCooldown, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _startAfterDecoratee = startAfterDecoratee;
            _cooldownTime = cooldownTime;
            _randomVariation = cooldownTime * 0.1f;
            _resetOnFailiure = resetOnFailiure;
            _failOnCoolDown = failOnCooldown;
        }

        public Cooldown(float cooldownTime, float randomVariation, bool startAfterDecoratee, bool resetOnFailiure, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _startAfterDecoratee = startAfterDecoratee;
            _cooldownTime = cooldownTime;
            _resetOnFailiure = resetOnFailiure;
            _randomVariation = randomVariation;
        }

        public Cooldown(float cooldownTime, bool startAfterDecoratee, bool resetOnFailiure, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _startAfterDecoratee = startAfterDecoratee;
            _cooldownTime = cooldownTime;
            _randomVariation = cooldownTime * 0.1f;
            _resetOnFailiure = resetOnFailiure;
        }

        
        public Cooldown(float cooldownTime, float randomVariation, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _startAfterDecoratee = false;
            _cooldownTime = cooldownTime;
            _resetOnFailiure = false;
            _randomVariation = randomVariation;
        }

        /// <summary>
        /// 立即运行decoratee，但前提是最后一次执行至少没有超过cooldownTime
        /// </summary>
        public Cooldown(float cooldownTime, Node decoratee) : base(NAME, decoratee)
        {
            if (cooldownTime <= 0f)
            {
                UnityEngine.Debug.LogError("CooldownTime变量非法，需要大于0");
                return;
            }
            _startAfterDecoratee = false;
            _cooldownTime = cooldownTime;
            _resetOnFailiure = false;
            _randomVariation = cooldownTime * 0.1f;
        }

        /// <summary>
        /// 用户请求施放技能（当前节点启动）
        /// 如果技能已经准备好，立即施放技能（启动被装饰节点）
        /// 否则，什么也不做（根据failOnCooldown决定是否停用当前节点）
        /// </summary>
        protected override void DoStart()
        {
            if (_isReady)
            {
                _isReady = false;
                if (!_startAfterDecoratee)
                {
                    Clock.AddTimer(_cooldownTime, _randomVariation, 0, OnTimeoutReached);
                }
                Decoratee.Start();
            }
            else
            {
                if (_failOnCoolDown)
                {
                    Stopped(false);
                }
            }
        }

        /// <summary>
        /// 对于状态切换类技能
        /// 用户请求关闭技能状态（关闭当前节点）
        /// 如果这个技能处于施放状态，关闭这个技能（关闭被装饰节点）
        /// 否则，什么也不做（停用当前节点）
        /// </summary>
        protected override void DoStop()
        {
            _isReady = true;
            Clock.RemoveTimer(OnTimeoutReached);
            if (Decoratee.IsActive)
            {
                Decoratee.Stop();
            }
            else
            {
                Stopped(false);
            }
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (_resetOnFailiure && !succeeded)
            {
                _isReady = true;
                Clock.RemoveTimer(OnTimeoutReached);
            }
            else if (_startAfterDecoratee)
            {
                Clock.AddTimer(_cooldownTime, _randomVariation, 0, OnTimeoutReached);
            }
            Stopped(succeeded);
        }

        private void OnTimeoutReached()
        {
            if (IsActive && !Decoratee.IsActive)
            {
                Clock.AddTimer(_cooldownTime, _randomVariation, 0, OnTimeoutReached);
                Decoratee.Start();
            }
            else
            {
                _isReady = true;
            }
        }
    }
}
