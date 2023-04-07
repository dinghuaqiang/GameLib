using UnityEngine;

namespace GameLib.Core.Base.Support
{
    /// <summary>
    /// FPS计数器
    /// </summary>
    public class FPSCounter
    {
        private float _updateInterval = 0.5f;
        private float _lastInterval = 0;
        private int _frames = 0;
        private float _fps;

        public float FPS
        {
            get { return _fps; }
        }

        public FPSCounter()
        {
        }

        public void Start()
        {
            _lastInterval = Time.time;
            _frames = 0;
        }

        public void Update()
        {
            ++_frames;
            if (Time.time > _lastInterval + _updateInterval)
            {
                _fps = _frames / (Time.time - _lastInterval);
                _frames = 0;
                _lastInterval = Time.time;
            }
        }
    }
}