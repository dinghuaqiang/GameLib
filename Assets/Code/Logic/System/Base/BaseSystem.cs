using UnityEngine;

namespace Code.Logic.System
{
    public class BaseSystem
    {
        #region//私有变量
        //更新频率，用于控制OnUpdate的调用频率
        protected int _updateFrameRate = 1;
        //dttime，用于记录上次到本次调用OnUpdate的时间
        private float _updateDeltaTime = 0f;
        //dttime，用于记录上次到本次调用OnLateUpdate的时间
        private float _lateUpdateDeltaTime = 0f;
        #endregion

        #region//公有函数
        //更新
        public bool Update(float deltaTime)
        {
            _updateDeltaTime += deltaTime;
            bool ret = true;
            if (_updateFrameRate <= 1 || Time.frameCount % _updateFrameRate == 0)
            {
                ret = OnUpdate(_updateDeltaTime);
                _updateDeltaTime = 0f;
            }
            return ret;
        }

        //LateUpdate
        public bool LateUpdate(float deltaTime)
        {
            _lateUpdateDeltaTime += deltaTime;
            bool ret = true;
            if (_updateFrameRate <= 1 || Time.frameCount % _updateFrameRate == 0)
            {
                ret = OnLateUpdate(_lateUpdateDeltaTime);
                _lateUpdateDeltaTime = 0f;
            }
            return ret;
        }
        #endregion

        #region//子类继承
        //子类继承更新操作
        protected virtual bool OnUpdate(float deltaTime)
        {
            return true;
        }

        protected virtual bool OnLateUpdate(float deltaTime)
        {
            return true;
        }
        #endregion
    }
}
