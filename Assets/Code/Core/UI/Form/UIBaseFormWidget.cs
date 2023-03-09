using GameLib.Cfg.Data;
using GameLib.Core.Event;
using System;
using System.Collections.Generic;
using UnityEngine;
using EventHandler = GameLib.Core.Event.EventManager.EventHandler;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 所有UI界面的基类
    /// </summary>
    public abstract class UIBaseFormWidget : MonoCacheBase, IUIEvent, IUIFormWidget
    {
        #region 常量
        /// <summary>
        /// 重新排布Panel时,Z的步长，这个增加在世界坐标系增加。depth增加1，Z值增加的步长。
        /// 大致等于1000/360
        /// </summary>
        private const float CN_WORLD_Z_STEP_LEN = -3f;
        #endregion

        #region 私有变量
        /// <summary>
        /// 窗体管理器
        /// </summary>
        private IUIFormManager _formManager = null;

        /// <summary>
        /// 窗体显示层级设置
        /// </summary>
        private UIFormRegion _formRegion = UIFormRegion.MiddleRegion;

        /// <summary>
        /// 窗体类型
        /// </summary>
        private UIFormType _formType = UIFormType.Normal;

        /// <summary>
        /// 窗体是否显示
        /// </summary>
        private bool _isVisible = false;

        /// <summary>
        /// 窗体是否激活，表示该窗体在最上面
        /// </summary>
        private bool _isActived = false;

        /// <summary>
        /// 所有的事件记录器
        /// </summary>
        private Dictionary<int, List<EventHandler>> _allEvents = new Dictionary<int, List<EventHandler>>();

        private Canvas _mainCanvas = null;
        //private UIPanel _mainPanel;

        /// <summary>
        /// 窗体是否已经显示过了
        /// </summary>
        protected bool _hasEverShowed = false;

        /// <summary>
        /// 是否设置了3D摄像机的视窗大小
        /// </summary>
        private bool _isSet3DCameraViewSize = false;

        /// <summary>
        /// 界面配置表
        /// </summary>
        private DeclareUIConfig _uiCfg = null;

        /// <summary>
        /// 是否是全屏界面
        /// </summary>
        private bool _isFullScreen = false;

        /// <summary>
        /// 是否销毁
        /// </summary>
        private bool _isDestory = false;

        /// <summary>
        /// 是否挂起任务
        /// </summary>
        private bool _isPauseTask = false;

        private int _zStartDepth = int.MaxValue;
        private int _zEndDepth = 0;

        /// <summary>
        /// 是否绑定了Lua脚本
        /// </summary>
        protected bool _isBindLuaScript = false;

        /// <summary>
        /// 是否正在隐藏
        /// </summary>
        protected bool _isHiding = false;
        #endregion

        #region 公共变量
        public string Name
        {
            get
            {
                return name;
            }
        }

        public IUIFormManager Manager
        {
            get
            {
                return _formManager;
            }
        }

        public UIFormRegion UIRegion
        {
            get
            {
                return _formRegion;
            }
            set
            {
                if (_formRegion != value)
                {
                    var old = _formRegion;
                    _formRegion = value;
                    if (_formManager != null)
                    {
                        _formManager.OnRegionChanged(this, old);
                    }
                }
            }
        }

        public UIFormType FormType
        {
            get
            {
                return _formType;
            }
            set
            {
                _formType = value;
            }
        }

        /// <summary>
        /// 更改属性 Z值 变为深度值
        /// </summary>
        public int ZStartDepth
        {
            get
            {
                return _zStartDepth;
            }
            set
            {
                if (_zStartDepth != value)
                {
                    _zStartDepth = value;
                    _zEndDepth = _zStartDepth;
                    if (MainCanvas != null)
                    {
                        SetPanelDepth(_zStartDepth);
                    }
                }
            }
        }

        private void SetPanelDepth(int startDepthValue)
        {
            //获取所有子的Panel
            var canvass = TransformInst.GetComponentsInChildren<Canvas>(true);
            var canvanss2 = new Canvas[canvass.Length];
            Array.Copy(canvass, canvanss2, canvass.Length);

            //从小到大升序
            Array.Sort(canvass, (x, y) =>
            {
                return x.renderOrder - y.renderOrder;
            });

            //获取MainCanvas的索引
            int mainIndex = Array.IndexOf(canvass, MainCanvas);
        }

        public int ZEndDepth
        {
            get
            {
                return _zEndDepth;
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            protected set
            {
                _isVisible = value;
            }
        }

        public bool IsDestory
        {
            get
            {
                return _isDestory;
            }
        }

        public bool IsActived
        {
            get
            {
                return _isActived;
            }
        }

        /// <summary>
        /// 是否全屏，必须在OnFirstShow中进行设置
        /// </summary>
        public bool IsFullScreen
        {
            get
            {
                return _isFullScreen;
            }
            set
            {
                if (_isFullScreen != value)
                {
                    _isFullScreen = value;
                }
            }
        }

        /// <summary>
        /// 是否挂起任务
        /// </summary>
        public bool IsPauseTask
        {
            get
            {
                return _isPauseTask;
            }
            set
            {
                _isPauseTask = value;
            }
        }

        public Canvas MainCanvas
        {
            get
            {
                if (_mainCanvas == null)
                {
                    _mainCanvas = gameObject.GetComponent<Canvas>();
                }
                if (_mainCanvas == null)
                {
                    Debug.LogError(string.Format("警告!!! The GameObject {0} Can't get the Canvas widget!!", this.name));
                }
                return _mainCanvas;
            }
        }

        /// <summary>
        /// 是否包含lua逻辑
        /// </summary>
        public bool HasLuaScript
        {
            get
            {
                return IsHasLuaScript();
            }
        }

        /// <summary>
        /// 是否已经绑定了lua脚本
        /// </summary>
        public bool IsBindLuaScript
        {
            get
            {
                return _isBindLuaScript;
            }
        }

        /// <summary>
        /// 是否正在关闭
        /// </summary>
        public bool IsHiding
        {
            get
            {
                return _isHiding;
            }
        }
        #endregion

        #region 公共接口
        /// <summary>
        /// 设置窗体管理器
        /// </summary>
        /// <param name="manager"></param>
        public void SetFormManager(IUIFormManager manager)
        {
            _isDestory = false;
            //1. 设置当前的窗体管理器
            _formManager = manager;
            //2. 注册事件
            RegisterEvents();
            //3. Load其他子Prefab
            OnLoad();
            //4. 通过回调去处理一些缓存的事件
            if (_formManager != null)
            {
                _formManager.OnUIFormLoaded(this);
            }
        }

        /// <summary>
        /// 取消窗体管理器的设置
        /// </summary>
        public void ResetFormManager()
        {
            //1. 卸载所有事件
            UnRegisterEvents();
            //2. 执行回调，处理一些缓存起的事件
            if (_formManager != null)
            {
                _formManager.OnUIFormUnload(this);
                _formManager = null;
            }
            //3. 进行卸载操作
            OnUnload();
            _zStartDepth = int.MaxValue;
            _zEndDepth = 0;
            _isDestory = true;
        }

        public void Show(IUIFormWidget parentForm)
        {
            try
            {
                //1. 判断当前是否显示，如果是显示的就移到最上层显示
                if (_isVisible)
                {
                    _formManager.OnFormMoveTop(this);
                    return;
                }
                //2. 判断是否是第一次显示
                if (!_hasEverShowed)
                {
                    OnFirstShow();
                }
                //3. 显示界面之前调用设置的回调
                OnShowBefore();

                //4. 实现显示
                IsVisible = true;
                OnShowImpl(parentForm);

                //5. 显示之后调用设置的回调
                OnShowAfter();

                if (_formManager != null)
                {
                    _formManager.OnHasFormShowed(this);
                }
                _hasEverShowed = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        public void Show()
        {
            Show(null);
        }

        public bool TryHide()
        {
            if (OnTryHide())
            {
                Hide();
                return true;
            }
            return false;
        }

        public void Hide()
        {
            try
            {
                //1. 判断当前是否是显示的
                if (!_isVisible)
                {
                    return;
                }
                //2. 隐藏之前的回调
                if (OnHideBefore())
                {
                    //3. 实现隐藏
                    IsVisible = false;
                    OnHideImpl();
                    _zStartDepth = int.MaxValue;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        /// <summary>
        /// 注册UI事件
        /// </summary>
        public void RegisterEvents()
        {
            _allEvents.Clear();
            OnRegisterEvents();
            var iter = _allEvents.GetEnumerator();
            while (iter.MoveNext())
            {
                var list = iter.Current.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    EventManager.SharedInstance.RegEventHandle(iter.Current.Key, list[i]);
                }
            }
        }

        /// <summary>
        /// 卸载已注册的UI事件
        /// </summary>
        public void UnRegisterEvents()
        {
            OnUnRegisterEvents();
            var iter = _allEvents.GetEnumerator();
            while (iter.MoveNext())
            {
                var list = iter.Current.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    EventManager.SharedInstance.UnRegEventHandle(iter.Current.Key, list[i]);
                }
            }
        }

        /// <summary>
        /// 屏幕方向改变
        /// </summary>
        /// <param name="so"></param>
        public void ScreenOrientationChanged(ScreenOrientation so)
        {
            OnScreenOrientationChanged(so);
        }

        /// <summary>
        /// 屏幕分辨率的改变
        /// </summary>
        public void ScreenSizeChanged()
        {
            OnScreenSizeChanged();
        }

        public bool SetActive(bool isActive)
        {
            if (_formType == UIFormType.Normal)
            {
                if (_isActived != isActive)
                {
                    _isActived = isActive;
                    OnActiveChanged(isActive);
                }
                return true;
            }
            return false;
        }

        //曲面屏缩放值改变
        public void CurvedScreenScaleChanged(float value)
        {
            OnCurvedScreenScaleChanged(value);
        }
        
        public void SetLuaBehaviour(string name)
        {
            _isBindLuaScript = true;
            OnSetLuaBehaviour(name);
        }
        #endregion

        #region 纯虚函数，用于子类继承
        //1.事件注册  第一个被调用
        //事件注册的虚函数
        protected virtual void OnRegisterEvents()
        {

        }

        protected virtual void OnUnRegisterEvents()
        {

        }

        /// <summary>
        /// 窗体激活状态的改变
        /// </summary>
        /// <param name="isActive">是否激活</param>
        protected virtual void OnActiveChanged(bool isActive)
        {

        }

        protected virtual void OnSetLuaBehaviour(string name)
        {

        }

        /// <summary>
        /// 是否包含Lua脚本，子类自己继承实现
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsHasLuaScript()
        {
            return false;
        }

        //回调函数中第二个被调用，当对象被实例化或者从缓存池中读取之后,进行调用
        protected virtual void OnLoad()
        {
            if (_uiCfg == null)
            {
                _uiCfg = DeclareUIConfig.Get(this.Name);
            }
        }

        //回调函数中最后一个被调用,当对象放回缓存池后的进行调用
        protected virtual void OnUnload()
        {

        }

        //曲面屏缩放值改变
        protected virtual void OnCurvedScreenScaleChanged(float value)
        {

        }

        /// <summary>
        /// 调用Hide之后，每次隐藏之前第一个被调用
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnHideBefore()
        {
            if (_uiCfg != null && !string.IsNullOrEmpty(_uiCfg.CloseSFX))
            {
                //AudioPlayer.PlayUI(_uiCfg.CloseSFX);
            }
            return true;
        }

        //隐藏的实现,用于实现显示的方法,返回是否播放了隐藏动画
        protected virtual void OnHideImpl()
        {

        }

        //屏幕方向改变
        protected virtual void OnScreenOrientationChanged(ScreenOrientation so)
        {

        }

        //屏幕分辨率的改变
        protected virtual void OnScreenSizeChanged()
        {

        }

        //窗体销毁
        protected virtual void OnFormDestroy()
        {

        }

        /// <summary>
        /// 调用show后第一个被调用,仅在第一次显示时
        /// </summary>
        protected virtual void OnFirstShow()
        {

        }

        /// <summary>
        /// 调用Show后,第二个被调用, 每次显示之前
        /// </summary>
        protected virtual void OnShowBefore()
        {
            if (_uiCfg != null && !string.IsNullOrEmpty(_uiCfg.OpenSFX))
            {
                //AudioPlayer.PlayUI(_uiCfg.OpenSFX);
            }
        }

        /// <summary>
        /// 调用Show后最后个被调用,每次显示之后
        /// </summary>
        protected virtual void OnShowAfter()
        {

        }

        //显示的实现,用于实现显示的方法
        protected virtual void OnShowImpl(IUIFormWidget parentForm)
        {

        }

        /// <summary>
        /// 尝试隐藏窗体
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnTryHide()
        {
            return true;
        }
        #endregion
    }
}
