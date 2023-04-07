namespace GameLib.Core.Event
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class EventMessage
    {
        //消息发送者
        public object Sender;
        //消息的目标
        public object Target;
        //时间类型
        public int EventType;
        //参数
        public object Param;
        //延迟
        private float _delayTime;
        //延迟时间消逝时间
        private float _delayElapsedTime;

        public EventMessage(object sender, object target, int eventType, object param, float delayTime = 0f)
        {
            Sender = sender;
            Target = target;
            EventType = eventType;
            Param = param;
            _delayTime = delayTime;
            _delayElapsedTime = 0f;
        }

        //检查是否进行延迟
        public bool IsDelayExec()
        {
            bool result = false;
            if (_delayTime > 0)
            {
                _delayElapsedTime += UnityEngine.Time.deltaTime;
                if (_delayElapsedTime < _delayTime)
                {
                    result = true;
                }
            }
            return result;
        }

        public void Execute()
        {
            EventManager.SharedInstance.PushFixEvent(EventType, Param, Sender, Target, true, 0);
        }
    }
}
