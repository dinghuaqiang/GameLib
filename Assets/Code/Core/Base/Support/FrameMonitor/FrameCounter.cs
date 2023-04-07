namespace GameLib.Core.Base.Support
{
    /// <summary>
    /// 帧计数器
    /// </summary>
    public class FrameCounter
    {
        //计时间隔
        private float _interval = 0.5f;
        //计算的帧率
        private float _fps = 0;
        //帧累积
        private float _frameCounter = 0;
        //时间累积
        private float _timeCounter = 0.5f;

        private bool _enableAvg = false;
        private int _avgCount = 0;
        private float _avgFps = 0;


        //帧率
        public float FPS
        {
            get
            {
                return _fps;
            }
        }

        //平均帧率
        public float AVGFPS
        {
            get
            {
                return _avgFps;
            }
        }

        //平均帧率计算的次数
        public int AVGValidFrameCount
        {
            get
            {
                return _avgCount;
            }
        }

        //构造函数
        public FrameCounter(float interval)
        {
            _interval = interval;
            if (_interval < 0.5f) _interval = 0.5f;
        }

        //更新
        public void Update(float deltaTime)
        {
            _timeCounter += deltaTime;
            if (_timeCounter > _interval)
            {
                _fps = _frameCounter / _timeCounter;
                _frameCounter = 0;
                _timeCounter = 0;
                if (_enableAvg)
                {
                    _avgFps = ((_avgFps * _avgCount) + _fps) / (_avgCount + 1);
                    _avgCount++;
                }
            }
            _frameCounter++;
        }

        /// <summary>
        /// 是否把存储值重新复位 
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="isReset"></param>
        public void SetEnable(bool isEnable, bool isReset)
        {
            _enableAvg = isEnable;
            if (isReset)
            {
                _avgFps = 0;
                _avgCount = 0;
            }
        }
    }
}
