namespace GameLib.Core.Base.Support
{
    /// <summary>
    /// 帧时间进行平滑改变的类
    /// </summary>
    public class FrameTimeSmoother
    {
        const int MaxSampleNum = 15; // np2 - 1
        float[] _samples = new float[MaxSampleNum + 1];
        int _size = 0;
        int _cur = 0;
        public FrameTimeSmoother Add(float dt)
        {
            if (_size < MaxSampleNum)
            {
                ++_size;
            }
            _samples[_cur++] = dt;
            _cur = _cur & MaxSampleNum;
            return this;
        }
        public void Clear()
        {
            _cur = 0;
            _size = 0;
        }
        public float Get()
        {
            var sum = 0.0f;
            int j = _cur;
            for (int i = 0; i < _size; ++i, ++j)
            {
                sum += _samples[j & MaxSampleNum];
            }
            return sum / _size;
        }
    }
}
