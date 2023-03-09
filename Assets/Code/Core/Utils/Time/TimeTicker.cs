using GameLib.Core.Base;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 计时器Ticker
    /// </summary>
    public class TimeTicker
    {
        //时间间隔是秒为单位
        private float _interval = 1f;

        //消失时间
        private float _elaspeTime = 0;

        //定时执行
        private GAction _callBack = null;

        //是否运行
        private bool _isRunning = false;

        //构造函数
        public TimeTicker(float interval, GAction callBack, bool createRun = true)
        {
            _interval = interval;
            _callBack = callBack;
            _isRunning = createRun;
        }

        //更新
        public void Update(float deltaTime)
        {
            if (_isRunning && _callBack != null)
            {
                _elaspeTime -= deltaTime;
                if (_elaspeTime <= 0)
                {
                    _elaspeTime = _interval;
                    _callBack();
                }
            }
        }

        //重置
        public void Reset(float interval = -1)
        {
            if (interval > 0)
            {
                _interval = interval;
            }
            _elaspeTime = _interval;
        }

        //设置Timer的运行状态
        public void SetEnable(bool isEnable)
        {
            _isRunning = isEnable;
            if (_isRunning)
            {
                _elaspeTime = _interval;
            }
        }
        //获取Timer的状态
        public bool GetEnable()
        {
            return _isRunning;
        }
    }
}
