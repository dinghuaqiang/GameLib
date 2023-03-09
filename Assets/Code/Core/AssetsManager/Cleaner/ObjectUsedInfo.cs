using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 对象被使用的信息,其中包括,使用时间,与使用次数
    /// </summary>
    public class ObjectUsedInfo
    {
        #region 变量
        private float _usedFirstTime;
        private float _usedLastTime;
        private float _usedTimes;
        private int _refCount = 0;
        #endregion

        #region 属性
        //引用计数
        public int RefCount
        {
            get
            {
                return _refCount;
            }
        }

        //第一次使用的时间
        public float UsedFirstTime
        {
            get
            {
                return _usedFirstTime;
            }
            set
            {
                _usedFirstTime = value;
            }
        }
        //使用次数        
        public float UsedTimes
        {
            get
            {
                return _usedTimes;
            }
            set
            {
                _usedTimes = value;
            }
        }
        //最后一次使用的时间
        public float UsedLastTime
        {
            get
            {
                return _usedLastTime;
            }
            set
            {
                _usedLastTime = value;
            }
        }
        #endregion

        #region //计算生存期的虚函数   
        public void BeginUsed()
        {
            if (_usedFirstTime == 0)
            {
                _usedFirstTime = Time.realtimeSinceStartup;
            }
            _usedTimes++;
            _refCount++;
        }
        public void EndUsed()
        {
            _usedLastTime = Time.realtimeSinceStartup;
            if (_refCount > 0)
                _refCount--;
        }

        //判断一个物件是否在生存期
        public bool CheckLifeTime(float currTime, float lifeTime)
        {
            //从最后一次被归还,开始计算 -- 一个文件不被使用了,然后开始计算他的缓存生存期
            return _usedLastTime < currTime - OnCalcLifeTime(lifeTime);
        }

        //计算生存时间
        protected virtual float OnCalcLifeTime(float lifeTime)
        {
            if (_usedTimes == 0) return lifeTime;
            float f = (_usedLastTime - _usedFirstTime) / _usedTimes + lifeTime;
            return f > 2 * lifeTime ? 2 * lifeTime : f;
        }
        #endregion
    }
}
