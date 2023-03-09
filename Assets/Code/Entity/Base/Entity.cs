using Assets.Code.FGameObject;
using Code.FGameObject.Interface;
using GameLib.Core.FSM;
using System;
using UnityEngine;

namespace Code.Entity.Base
{
    /// <summary>
    /// 游戏实体类
    /// </summary>
    public class Entity : IComparable<Entity>, IFSkinLogicObject
    {
        #region 变量
        //旋转的角度的误差距离
        public const float Epsilon_RotateLenSq = 0.001f;
        private ulong _id = 0;
        
        /// <summary>
        /// 实体的状态机
        /// </summary>
        private FiniteStateMachine _fsm = null;
        //模型比例:影响模型和动作
        private float _bodyScale = 1.0f;
        //实体的外观处理
        private FSkinBase _skin = null;
        //地形
        private IScene _baseScene;
        #endregion

        #region 属性
        /// <summary>
        /// 唯一ID
        /// </summary>
        public ulong ID { get { return _id; } }
        /// <summary>
        /// 状态机
        /// </summary>
        public FiniteStateMachine Fsm
        {
            get
            {
                return _fsm;
            }
            protected set
            {
                _fsm = value;
            }
        }
        //主体对象大小
        public virtual float BodyScale
        {
            get
            {
                return _bodyScale;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1.0f;
                }
                if (value != _bodyScale)
                {
                    _bodyScale = value;
                    //_skin.SetLocalScale(_bodyScale);
                }
            }
        }
        //摄像机
        public virtual float CameraOffY
        {
            get { return 0f; }
        }
        //实体的外表
        public FSkinBase Skin
        {
            get
            {
                return _skin;
            }
            protected set
            {
                _skin = value;
            }
        }
        public IScene Scene
        {
            get
            {
                return _baseScene;
            }
            set
            {
                _baseScene = value;
            }
        }
        #endregion

        #region 实现重载函数
        /// <summary>
        /// 两个实体比较的函数
        /// </summary>
        public int CompareTo(Entity other)
        {
            return _id.CompareTo(other.ID);
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.GetType().Name, _id);
        }
        #endregion

        #region 公共接口
        public bool Initialize(EntityInitInfo entityInitInfo, IScene scene)
        {
            try
            {
                _baseScene = scene;
                _id = entityInitInfo.ID;
                FSkinBase fSkin = OnSetupSkin();
                if (fSkin == null)
                {
                    return false;
                }
                _skin = fSkin;
                //_skin.Name = String.Format("[{0}_{1}]", GetType().Name, _ID);
                //_skin.SetPosition(GetTerrainPosition(baseInfo.X, baseInfo.Z));
                //_skin.SetLocalScale(_bodyScale);
                //_skin.LogicObject = this;
                if (!OnSetupFsmBefore())
                {
                    return false;
                }
                if (!OnSetupFsm())
                {
                    return false;
                }
                if (!OnInitializeAfter(entityInitInfo))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("{0}初始化失败!异常信息:{1}", ToString(), ex.Message));
            }
            return true;
        }

        public void UnInitialize()
        {
            OnUninitializeBefore();
            if (_fsm != null)
            {
                _fsm = null;
            }
            if (_skin != null)
            {
                //_skin.Destroy();
                _skin = null;
            }
            _id = 0;
        }

        public void Update(float dt)
        {
            OnUpdate(dt);
        }

        #endregion

        #region 需要子类重载的函数
        protected virtual FSkinBase OnSetupSkin()
        {
            return null;
        }

        protected virtual bool OnSetupFsmBefore()
        {
            return true;
        }

        protected virtual bool OnSetupFsm()
        {
            _fsm = new FiniteStateMachine(this);
            return true;
        }

        protected virtual bool OnInitializeAfter(EntityInitInfo entityInitInfo)
        {
            return true;
        }

        protected virtual void OnUninitializeBefore()
        {

        }

        protected virtual void OnSelect()
        {

        }

        protected virtual void OnDeselect()
        {

        }

        //更新实体的旋转角
        protected virtual void OnUpdateRotation(float dt)
        {

        }

        protected virtual void OnUpdate(float dt)
        {
            OnUpdateRotation(dt);
            if (_fsm != null)
            {
                _fsm.Update(dt);
            }
        }

        //播放动作
        //protected virtual bool OnPlayAnim(string anim, AnimationPartType partType, WrapMode wrapMode = WrapMode.Default, bool isCrossFade = true, float crossFadeTime = 0.2f, float speed = 1f, float normalizedTime = 0.0f)
        //{
        //    return _skin.PlayAnim(anim, partType, wrapMode, isCrossFade, crossFadeTime, speed, normalizedTime);
        //}
        #endregion
    }
}
