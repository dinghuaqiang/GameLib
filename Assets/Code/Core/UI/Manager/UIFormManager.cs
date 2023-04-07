using System;
using System.Collections.Generic;
using Code.Core.Base;
using Code.Logic.Manager;
using GameLib.Cfg.Data;
using GameLib.Core.Asset;
using GameLib.Core.Base;
using GameLib.Core.Event;
using GameLib.Core.Utils;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = GameLib.Core.Event.EventManager.EventHandler;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体管理器
    /// </summary>
    public sealed class UIFormManager : MonoBehaviour, IUIFormManager, IUIChecker
    {
        #region 定义常量
        //暂定为一个UI 10个事件
        private static readonly int MAX_UI_EVENT = 10;
        //关闭窗体的ID
        private static readonly int CLOSE_EVENT_ID = 9;
        //UI的设计分辨率
        private readonly float UI_DESIGN_WIDTH = 1920;
        private readonly float UI_DESIGN_HEIGHT = 1080;
        #endregion

        #region 变量
        //UICanvas的根节点，也是UI的根节点
        private Transform _uiRootTrans = null;
        private Canvas _rootCanvas = null;
        private CanvasScaler _canvasScaler = null;
        private Camera _uiCamera = null;
        //当前的横竖屏状态
        private ScreenOrientation _currentOrientation = ScreenOrientation.Landscape;
        //存储未加载窗体的所属事件默认处理函数
        private Dictionary<string, List<KeyValuePair<int, EventHandler>>> _uiEventCallBacks = null;
        //缓存正在加载的窗体对象的消息
        private static Dictionary<string, List<EventMessage>> _uiEvents = null;
        //存储窗体引用的列表
        private List<IUIFormWidget> _noticeRegionForms;
        private List<IUIFormWidget> _topRegionForms;
        private List<IUIFormWidget> _middleRegionForms;
        private List<IUIFormWidget> _mainRegionForms;
        private List<IUIFormWidget> _bottomRegionForms;
        private List<IUIFormWidget> _allForms;
        //临时的窗体列表 -- 在方法中使用
        private List<IUIFormWidget> _tempFormList = new List<IUIFormWidget>();
        //当前激活的窗体
        private IUIFormWidget _activeForm = null;
        //窗体的请求队列
        UIFormRequestQueue _formReqQueue = new UIFormRequestQueue();
        //UI的两个摄像机
        private Camera _ui2DCamera = null;
        private Camera _uiTop2DCamera = null;
        //摄像机根节点
        private GameObject _uiCameraRootGo = null;
        //UI摄像机振动器
        //private VFXCameraShaker _cameraShaker = null;
        //判断是否在控制角色移动
        private bool _isControled = false;
        //挂起引用次数
        private int _suspendRefCount = 0;
        //是否挂起事件系统
        private bool _isSuspendEventSystem = false;
        private List<string> _isSuspendEventIgnoreForms = new List<string>();
        //所有窗体正在被关闭
        private bool _allFormsBeClose = false;
        //UI整体透明度
        private float _globalFormAlpha = 1f;
        //Lua端创建ui的事件
        private Action<string, GameObject> _creatLuaUIEvent = null;
        //ui界面关闭的是否直接detroy
        private bool _isDestroyPrefabOnClose = false;
        //预加载窗体名字列表
        private List<string> _preformsList = new List<string>();
        //曲面屏缩放值
        private float _curvedScreenScale = 1f;
        //缓存UI事件列表
        private Dictionary<int, bool> _cacheUIEvenetIds = null;
        //是否正在引导
        private bool _isGuiding = false;
        private float _frontScreenWidth = 0;
        private float _frontScreenHeight = 0;
        #endregion

        #region 属性
        /// <summary>
        /// UI相机，一些需要用到转换坐标，做射线操作的也可以用这个相机
        /// </summary>
        public Camera UICamera
        {
            get
            {
                if (_uiCamera == null)
                {
                    Transform cameraT = gameObject.transform.Find("Cameras/Camera_UI");
                    if (cameraT != null)
                    {
                        _uiCamera = cameraT.GetComponent<Camera>();
                    }
                }
                return _uiCamera;
            }
        }

        //UI的2D相机
        public Camera UITop2DCamera
        {
            get
            {
                if (_uiTop2DCamera == null)
                {
                    Transform cameraT = gameObject.transform.Find("Cameras/Camera_UI_Top");
                    if (cameraT != null)
                    {
                        _uiTop2DCamera = cameraT.GetComponent<Camera>();
                    }
                }
                return _uiTop2DCamera;
            }
        }
        //摄像机根节点
        public GameObject UICameraRootGo
        {
            get
            {
                if (_uiCameraRootGo == null)
                {
                    _uiCameraRootGo = gameObject.transform.Find("Cameras").gameObject;
                }
                return _uiCameraRootGo;
            }
        }
        /// <summary>
        /// 根画布
        /// </summary>
        public Canvas RootCanvas { get { return _rootCanvas; } }
        /// <summary>
        /// 当前的屏幕方向
        /// </summary>
        public ScreenOrientation CurrentOrientation { get { return _currentOrientation; } }
        /// <summary>
        /// UI宽度
        /// </summary>
        public float Width
        {
            get
            {
                if (_canvasScaler != null)
                {
                    return _canvasScaler.referenceResolution.x;
                }
                return UI_DESIGN_WIDTH;
            }
        }
        /// <summary>
        /// UI高度
        /// </summary>
        public float Height
        {
            get
            {
                if (_canvasScaler != null)
                {
                    return _canvasScaler.referenceResolution.y;
                }
                return UI_DESIGN_HEIGHT;
            }
        }

        //当前是否挂起
        public bool IsSuspend
        {
            get
            {
                return _suspendRefCount > 0;
            }
        }
        //ui界面关闭的是否直接detroy
        public bool IsDestroyPrefabOnClose
        {
            get { return _isDestroyPrefabOnClose; }
            set { _isDestroyPrefabOnClose = value; }
        }

        //是否为刘海屏
        public bool IsNotchInScreen { get; private set; }

        //曲面屏缩放值
        public float CurvedScreenScale
        {
            get
            {
                return _curvedScreenScale;
            }
            set
            {
                value = Mathf.Clamp01(value);
                if (_curvedScreenScale != value)
                {
                    _curvedScreenScale = value;
                    for (int i = 0; i < _allForms.Count; i++)
                    {
                        if (_allForms[i] != null)
                        {
                            _allForms[i].CurvedScreenScaleChanged(_curvedScreenScale);
                        }
                    }
                }
            }
        }

        //是否正在引导
        public bool IsGuiding
        {
            get
            {
                return _isGuiding;
            }
            set
            {
                _isGuiding = value;
            }
        }

        public bool IsControlling => throw new NotImplementedException();

        public bool IsControled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Camera UI2DCamera => throw new NotImplementedException();
        #endregion

        #region 创建画布实例
        public static UIFormManager CreateUICanvas()
        {
            UIFormManager ret = null;
            GameObject canvasRootGo = Resources.Load<GameObject>("Default/UIRoot/UICanvas");
            canvasRootGo.transform.position = Vector3.up * 2000;
            var uiroot = GameObject.Instantiate(canvasRootGo) as GameObject;
            uiroot.name = "UIRoot";
            ret = uiroot.AddComponent<UIFormManager>();
            //ret.IsNotchInScreen = GameCenter.GameSetting.GetSetting(GameSettingKeyCode.NotchShow) > 0;
            //ret.CurvedScreenScale = GameCenter.GameSetting.GetSetting(GameSettingKeyCode.CurvedScreenScreenScale) / 100f;
            return ret;
        }
        #endregion

        #region MonoBehaviour的重载函数
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _currentOrientation = Screen.orientation;
            _uiRootTrans = transform;
            _rootCanvas = _uiRootTrans.Find("Canvas").GetComponent<Canvas>();
            _canvasScaler = _rootCanvas.GetComponent<CanvasScaler>();
            _uiCamera = _uiRootTrans.Find("UICamera").GetComponent<Camera>();
            //处理UI点击的声音播放
            //UISoundFXPlayer.SoundPlayer = UIUtility.PlayUISoundFX;
            _currentOrientation = Screen.orientation;
            Initialize();
        }

        private void Start()
        {
            RegisterAllInitEvents();
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_CLOSE_ALL_FORM, OnCloseAllForm);
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_CLEAR_ALL_FORM_ASSET, OnClearAllFormAsset);

            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_SUSPEND_ALL_FORM, OnSuspendAllForm);
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_RESUME_ALL_FORM, OnResumeAllForm);

            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_SUSPEND_FORM_EVENT_SYSTEM, OnSuspendFormEventSystem);
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_RESUME_FORM_EVENT_SYSTEM, OnResumeFormEventSystem);

            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_SHOWALL_UICAMERA, ShowAllUICamera);
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_HIDEALL_UICAMERA, HideAllUICamera);

            //隐藏当前全屏UI
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_HIDE_CURFULLSCREEN_FORM, HideCurFullScreenForm);

            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_HIDE_CURRENT_FORM, HideCurrentForm);

            //预加载form处理
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_SETPRELOADFORM, SetPreLoadForm);
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_OPENPRELOADFORM, OpenPreLoadForm);

            PreLoadPreForm();

            //曲面屏缩放改变
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_CURVEDSCREENSCALE_CHANGE, CurvedScreenScaleChanged);

            //打印NGUI缓存信息
            //GameCenter.RegFixEventHandle(LogicEventDefine.EID_NGUI_PRINTCACHE_INFO, OnPrintNGUICacheInfo);

            //UIPanel填充频率改变
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_PANEL_FILLDRAWCALLRATE_CHANGED, OnPanelFillDrawCallRateChanged);

            //enable摄像机后处理脚本
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_ENABLE_CAMERA_POSTEFFECT, OnEnableCameraPostEffect);
            //disable摄像机后处理脚本
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_DISABLE_CAMERA_POSTEFFECT, OnDisableCameraPostEffect);

            //重新刷新刘海和曲面屏界面
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_REFRESH_NOTCHANDCURVESCREEN, OnRefreshNoticeAndCurveScreen);
            //刘海屏适配设置改变
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_NOTCHSHOW_CHANGED, OnNotchShowChanged);

            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_HIDEALLUI, OnHideAllUI);
            //柔体效果改变
            GameCenter.RegFixEventHandle(LogicEventDefine.EID_EVENT_SOFTBONE_ENABLE_CHANGED, OnSoftBoneEnableChanged);

            //先设置一次频率
            OnPanelFillDrawCallRateChanged(null, null);
            GameCenter.FormStateSystem.IsFormSystemReadyOK = true;
        }

        private void Update()
        {
            //判断窗体方向改变
            if (_currentOrientation != Screen.orientation && (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight))
            {
                _currentOrientation = Screen.orientation;
                for (int i = 0; i < _allForms.Count; i++)
                {
                    if (_allForms[i] != null)
                    {
                        _allForms[i].ScreenOrientationChanged(_currentOrientation);
                    }
                }
            }

            //TODO 暂时屏蔽掉
            //处理 ui scene
            //UISceneManager.Instance.Update();

#if !USE_PC_MODEL
            //int useUIWidth = Screen.width;
            //if (useUIWidth > UIROOT_MAX_WIDTH)
            //{
            //    useUIWidth = UIROOT_MAX_WIDTH;
            //}
            //int useUIHeight = Screen.height;
            //if(useUIHeight > UIROOT_MAX_HEIGHT)
            //{
            //    useUIHeight = UIROOT_MAX_HEIGHT;
            //}
            ////处理分辨率改变
            //if (useUIWidth > _oriUIRootWidth && useUIHeight > _oriUIRootHeight)
            //{
            //    if(_uiRoot.manualWidth != useUIWidth)
            //    {
            //        _uiRoot.manualWidth = useUIWidth;
            //    }
            //    if(_uiRoot.manualHeight != useUIHeight)
            //    {
            //        _uiRoot.manualHeight = useUIHeight;
            //    }
            //}
            //else
            //{
            //    if(_uiRoot.manualWidth != _oriUIRootWidth)
            //    {
            //        _uiRoot.manualWidth = _oriUIRootWidth;
            //    }
            //    if (_uiRoot.manualHeight != _oriUIRootHeight)
            //    {
            //        _uiRoot.manualHeight = _oriUIRootHeight;
            //    }
            //}
            //检测分辨率改变，用于重刷UI锚点
            if (_frontScreenWidth != Screen.width || _frontScreenHeight != Screen.height)
            {
                _frontScreenWidth = Screen.width;
                _frontScreenHeight = Screen.height;
                //重新计算UI锚点
                for (int i = 0; i < _allForms.Count; i++)
                {
                    var form = _allForms[i];
                    if (form != null)
                    {
                        form.ScreenSizeChanged();
                    }
                }
            }
#endif
        }

        private void OnDestroy()
        {
            UnRegisterAllInitEvents();
            _uiEventCallBacks.Clear();
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_CLOSE_ALL_FORM, OnCloseAllForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_CLEAR_ALL_FORM_ASSET, OnClearAllFormAsset);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_SUSPEND_ALL_FORM, OnSuspendAllForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_RESUME_ALL_FORM, OnResumeAllForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_SUSPEND_FORM_EVENT_SYSTEM, OnSuspendFormEventSystem);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_RESUME_FORM_EVENT_SYSTEM, OnResumeFormEventSystem);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_SHOWALL_UICAMERA, ShowAllUICamera);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_HIDEALL_UICAMERA, HideAllUICamera);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_HIDE_CURFULLSCREEN_FORM, HideCurFullScreenForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_SETPRELOADFORM, SetPreLoadForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_OPENPRELOADFORM, OpenPreLoadForm);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_CURVEDSCREENSCALE_CHANGE, CurvedScreenScaleChanged);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_PANEL_FILLDRAWCALLRATE_CHANGED, OnPanelFillDrawCallRateChanged);
            //GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_NGUI_PRINTCACHE_INFO, OnPrintNGUICacheInfo);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_ENABLE_CAMERA_POSTEFFECT, OnEnableCameraPostEffect);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_DISABLE_CAMERA_POSTEFFECT, OnDisableCameraPostEffect);
            GameCenter.UnRegFixEventHandle(LogicEventDefine.EID_EVENT_SOFTBONE_ENABLE_CHANGED, OnSoftBoneEnableChanged);
        }
        #endregion

        #region 事件的回调函数
        /// <summary>
        /// 关闭所有窗体 -用于事件回调
        /// </summary>
        private void OnCloseAllForm(object o, object sender = null)
        {
            _allFormsBeClose = true;

            string[] names = null;
            //var luaTable = o as LuaTable;
            //if (luaTable != null)
            //{
            //    //增加对于luatable的支持
            //    if (luaTable.Length > 0)
            //    {
            //        names = new string[luaTable.Length];
            //        for (int i = 1; i <= luaTable.Length; ++i)
            //        {
            //            var result = string.Empty;
            //            luaTable.TryGet<int, string>(i, out result);
            //            names[i - 1] = result;
            //        }
            //    }
            //}
            //else
            //{
            //    names = o as string[];
            //}
            names = o as string[];
            var list = new List<IUIFormWidget>(_allForms);
            if (names == null || names.Length == 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Hide();
                }
                _allForms.Clear();
                _formReqQueue.Clear();
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    bool isFind = false;
                    for (int m = 0; m < names.Length; m++)
                    {
                        if (names[m].Equals(list[i].Name, StringComparison.Ordinal))
                        {
                            isFind = true;
                            break;
                        }
                    }
                    //后台更新UI只能自己关闭
                    if (!isFind && !"UIUpdateNoticeForm".Equals(list[i].Name))
                    {
                        list[i].Hide();
                        _allForms.Remove(list[i]);
                    }
                }

                _formReqQueue.Remove(names);
            }
            _allFormsBeClose = false;

        }

        /// <summary>
        /// 清理所有窗体的资源
        /// </summary>
        public void OnClearAllFormAsset(object o, object sender = null)
        {
            //清理所有的Altas图集
            //GameUICenter.UIIconAltasManager.CleanupAltas();
            //FLogger.DebugLogError(Information());
            //UIPoolAssetsLoader.ClearDeactivedForms(_formReqQueue.GetContents());
        }

        //暂停所有的窗体 -- 暂时隐藏所有窗体
        private void OnSuspendAllForm(object o, object sender = null)
        {
            if (o != null)
            {
                SuspendAllForm((bool)o);
            }
            else
            {
                SuspendAllForm();
            }
        }

        //暂停所有的窗体 -- 暂时隐藏所有窗体
        public void SuspendAllForm(bool isHideTopCamera)
        {
            //把top上的所有窗体给隐藏了.
            _tempFormList.Clear();
            _tempFormList.AddRange(_noticeRegionForms);
            _tempFormList.AddRange(_topRegionForms);
            for (int i = 0; i < _tempFormList.Count; i++)
            {
                _tempFormList[i].Hide();
            }
            _tempFormList.Clear();

            UI2DCamera.enabled = false;
            if (isHideTopCamera)
            {
                UITop2DCamera.enabled = false;
            }

            _suspendRefCount++;
            GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_ON_SUSPEND_ALL_FORM_AFTER);
        }

        public void SuspendAllForm()
        {
            SuspendAllForm(false);
        }

        //恢复所有窗体
        private void OnResumeAllForm(object o, object sender = null)
        {
            if (o != null)
            {
                bool isCinematic = (bool)o;
                if (isCinematic)
                {
                    //直接清除引用
                    _suspendRefCount = 0;
                }
            }

            ResumeAllForm();
        }

        //恢复所有窗体
        public void ResumeAllForm()
        {
            _suspendRefCount--;
            if (_suspendRefCount <= 0)
            {
                UI2DCamera.enabled = true;
                UITop2DCamera.enabled = true;
                _suspendRefCount = 0;
            }
            GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_ON_RESUME_ALL_FORM_AFTER);
        }

        private void OnSuspendFormEventSystem(object o, object sender = null)
        {
            _isSuspendEventIgnoreForms.Clear();
            string[] forms = o as string[];
            if (forms != null && forms.Length > 0)
            {
                _isSuspendEventIgnoreForms.AddRange(forms);
            }
            _isSuspendEventSystem = true;
        }

        private void OnResumeFormEventSystem(object o, object sender = null)
        {
            _isSuspendEventIgnoreForms.Clear();
            _isSuspendEventSystem = false;
        }

        //显示所有UI摄像机
        private void ShowAllUICamera(object o, object sender = null)
        {
            UICameraRootGo.SetActive(true);
        }
        //隐藏所有UI摄像机
        private void HideAllUICamera(object o, object sender = null)
        {
            UICameraRootGo.SetActive(false);
        }

        //关闭当前全屏界面
        private void HideCurFullScreenForm(object o, object sender = null)
        {
            for (int i = _allForms.Count - 1; i >= 0; --i)
            {
                if (_allForms[i].IsFullScreen)
                {
                    _allForms[i].Hide();
                }
            }
        }

        private void HideCurrentForm(object o, object sender = null)
        {
            if (IsGuiding)
            {
                //正在引导，调用引导的tryhide函数
                var form = GetVisabledUIForm("UIGuideForm");
                if (form != null)
                {
                    form.TryHide();
                    return;
                }
            }
            OnTryHide(_activeForm);
            //重新设置激活UI
            SetActiveForm(GetEnableActiveForm());
        }

        //获取显示的窗体
        public T GetVisabledUIForm<T>()
            where T : IUIFormWidget
        {
            for (int i = 0; i < _allForms.Count; ++i)
            {
                var form = _allForms[i];
                if (form is T)
                    return (T)form;
            }
            return default(T);
        }

        private IUIFormWidget GetVisabledUIForm(string formName)
        {
            for (int i = 0; i < _allForms.Count; i++)
            {
                if (_allForms[i].Name == formName)
                {
                    return _allForms[i];
                }
            }
            return null;
        }

        private void OnTryHide(IUIFormWidget willCloseForm)
        {
            if (willCloseForm != null)
            {
                //Debug.LogError("关闭窗体:"+ willCloseForm.Name);
                //采集所有的父节点
                List<string> parentNames = new List<string>();
                List<IUIFormWidget> parents = new List<IUIFormWidget>();
                _formReqQueue.GetParentForms(willCloseForm.Name, parentNames);
                for (int i = 0; i < parentNames.Count; i++)
                {
                    //Debug.LogError("找到父窗体:" + parentNames[i]);
                    var f = GetVisabledUIForm(parentNames[i]);
                    if (f != null)
                    {
                        parents.Add(f);
                    }
                }

                //执行关闭
                if (willCloseForm.TryHide())
                {
                    for (int i = 0; i < parents.Count; i++)
                    {
                        parents[i].TryHide();
                    }
                }
            }
            else
            {
                //当前没有活跃的窗体,直接退出游戏.
                //GameCenter.SDKSystem.ExitGame();
                Debug.LogError("退出游戏!!" + Time.frameCount);
            }
        }

        //设置激活窗体
        private void SetActiveForm(IUIFormWidget form)
        {
            if (form == null)
                return;
            if (form.SetActive(true))
            {
                if (_activeForm != null && _activeForm != form)
                {
                    _activeForm.SetActive(false);
                }
                _activeForm = form;
            }
        }

        //获取能够被激活的窗体
        private IUIFormWidget GetEnableActiveForm()
        {
            //1.从顶层窗体中选择
            var newActiveForm = SelectedActiveForm(_noticeRegionForms);
            if (newActiveForm == null)
            {
                newActiveForm = SelectedActiveForm(_topRegionForms);
                if (newActiveForm == null)
                {
                    //2.从中间窗体中选择
                    newActiveForm = SelectedActiveForm(_middleRegionForms);
                    if (newActiveForm == null)
                    {
                        //3.从主界面的窗体中选择
                        newActiveForm = SelectedActiveForm(_mainRegionForms);
                        if (newActiveForm == null)
                        {
                            //4.从下层的窗体中选择
                            newActiveForm = SelectedActiveForm(_bottomRegionForms);
                        }

                    }
                }
            }
            return newActiveForm;
        }

        //设置某个窗体非激活
        private void SetDeactiveForm(IUIFormWidget form)
        {
            if (form == _activeForm)
            {
                _activeForm.SetActive(false);
                _activeForm = GetEnableActiveForm();
            }
        }

        //选择一个被激活窗体
        private IUIFormWidget SelectedActiveForm(List<IUIFormWidget> list)
        {
            //从列表中,找一个可被激活的窗体
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (!list[i].IsHiding && list[i].SetActive(true))
                {
                    return list[i];
                }
            }
            return null;
        }

        //设置预加载form
        public void SetPreLoadForm(object o, object sender = null)
        {
            if (o == null)
                return;
            string formName = (string)o;
            for (int i = 0; i < _allForms.Count; i++)
            {
                if (_allForms[i].Name == formName)
                {
                    GameCenter.PreLoadFormRoot.SetForm(formName, _allForms[i].TransformInst.gameObject);
                }
            }
        }

        //打开预加载Form
        public void OpenPreLoadForm(object o, object sender = null)
        {
            if (o == null)
                return;
            if (_preformsList.Count == 0)
            {
                _preformsList.AddRange((List<string>)o);
            }
            for (int i = 0; i < _preformsList.Count; i++)
            {
                string formName = _preformsList[i];
                if (UIFormConfigInfo.Instance.IsExist(formName))
                {
                    int UIEventId = UIFormConfigInfo.Instance.Get(formName).EventID;
                    GameCenter.PushFixEvent(UIEventId);
                }
            }
        }

        //加载预加载窗体
        public void PreLoadPreForm()
        {
            _preformsList = GameCenter.PreLoadFormRoot.GetPreLoadFormNames();
            for (int i = 0; i < _preformsList.Count; i++)
            {
                string formName = _preformsList[i];
                if (UIFormConfigInfo.Instance.IsExist(formName))
                {
                    int UIEventId = UIFormConfigInfo.Instance.Get(formName).EventID;
                    GameCenter.PushFixEvent(UIEventId);
                }
            }
        }

        //曲面屏设置改变
        private void CurvedScreenScaleChanged(object obj, object sender)
        {
            float scale = (float)obj / 100;
            CurvedScreenScale = scale;
        }

        //enable摄像机后处理脚本
        private void OnEnableCameraPostEffect(object obj, object sender)
        {
            var go = obj as GameObject;
            if (go != null)
            {
                var postEffects = go.GetComponents<PostEffect.PostEffectsBase>();
                if (postEffects != null && postEffects.Length > 0)
                {
                    for (int i = 0; i < postEffects.Length; ++i)
                    {
                        postEffects[i].enabled = true;
                    }
                }
            }
        }
        //disable摄像机后处理脚本
        private void OnDisableCameraPostEffect(object obj, object sender)
        {
            var go = obj as GameObject;
            if (go != null)
            {
                var postEffects = go.GetComponents<PostEffect.PostEffectsBase>();
                if (postEffects != null && postEffects.Length > 0)
                {
                    for (int i = 0; i < postEffects.Length; ++i)
                    {
                        postEffects[i].enabled = false;
                    }
                }
            }
        }

        //刘海屏设置改变
        private void OnNotchShowChanged(object obj, object sender)
        {
            //IsNotchInScreen = GameCenter.GameSetting.GetSetting(GameSettingKeyCode.NotchShow) > 0;
            for (int i = 0; i < _allForms.Count; i++)
            {
                if (_allForms[i] != null)
                {
                    _allForms[i].ScreenOrientationChanged(_currentOrientation);
                }
            }
        }

        //刷新刘海和曲面屏
        private void OnRefreshNoticeAndCurveScreen(object obj, object sender)
        {
            var name = obj as string;
            if (string.IsNullOrEmpty(name))
                return;
            for (int i = 0; i < _allForms.Count; i++)
            {
                if (_allForms[i].Name == name)
                {
                    _allForms[i].ScreenOrientationChanged(Screen.orientation);
                }
            }
        }

        //UI是否隐藏的切换
        private void OnHideAllUI(object obj, object sender)
        {
            _rootCanvas.gameObject.SetActive(!_rootCanvas.gameObject);
        }

        private void OnSoftBoneEnableChanged(object obj, object sender)
        {
            var value = (int)obj;
            SoftBoneScript.QualityLevel = value;
        }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initialize()
        {
            _uiEventCallBacks  = new Dictionary<string, List<KeyValuePair<int, EventHandler>>>(DeclareUIConfig.CacheDataCount);
            _uiEvents          = new Dictionary<string, List<EventMessage>>(DeclareUIConfig.CacheDataCount);
            _noticeRegionForms = new List<IUIFormWidget>();
            _middleRegionForms = new List<IUIFormWidget>();
            _topRegionForms    = new List<IUIFormWidget>();
            _bottomRegionForms = new List<IUIFormWidget>();
            _mainRegionForms   = new List<IUIFormWidget>();
            _allForms          = new List<IUIFormWidget>();
            //记录屏幕的宽高
            _frontScreenWidth = Screen.width;
            _frontScreenHeight = Screen.height;
        }

        public bool IsHitUI(int touchID)
        {
            throw new NotImplementedException();
        }

        public bool IsHitUI(int touchID, string uiname)
        {
            throw new NotImplementedException();
        }

        public bool IsSelectInputField()
        {
            throw new NotImplementedException();
        }

        // 窗体卸载处理
        public bool OnUIFormUnload(IUIFormWidget form)
        {
            if (form != null)
            {
                //重新使事件绑定默认处理函数
                RegisterUIEvents(form.Name, true);
                _allForms.Remove(form);

                RemoveFromRequestQueue(form.Name);
                GameCenter.FormStateSystem.SetFormState(form.Name, FormStateCode.FSC_UNLOADED, form.GameObjectInst);
                return true;
            }
            return false;
        }

        //当窗体被Show后的操作
        public void OnHasFormShowed(IUIFormWidget showedForm)
        {
            //AddRegionForm(showedForm);
            //往窗体队列中删除
            var list = AddRegionForm(showedForm);
            //重新设置深度
            ResetRegionFormsDepth(list, (int)showedForm.UIRegion);
            if (showedForm.FormType == UIFormType.Normal)
            {
                //把这个窗体设置为激活
                SetActiveForm(GetEnableActiveForm());
            }
            //某个窗体打开之前
            GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_FORM_SHOW_AFTER, showedForm.Name);
            if (UIFormConfigInfo.Instance.IsExist(showedForm.Name))
            {
                int formId = UIFormConfigInfo.Instance.Get(showedForm.Name).FormID;
                GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_FORM_ID_SHOW_AFTER, formId);
                DeclareUIConfig uiConfig = DeclareUIConfig.Get(showedForm.Name);
                if (uiConfig != null && uiConfig.IsPauseTask == 1)
                {
                    showedForm.IsPauseTask = true;
                    //GameCenter.TaskController.AddHoldUI(formId);
                }
            }

            FLogger.DebugLog("OnHasFormShowed:" + showedForm.Name);
        }

        //当窗体被Hide后的操作
        public void OnHasFormHided(IUIFormWidget form)
        {
            //从区域窗体队列中删除
            RemoveRegionForm(form, form.UIRegion);
            //把当前form设置为非激活
            SetDeactiveForm(form);
            //从Form管理器中取消
            form.ResetFormManager();
            //资源卸载
            UIPoolAssetsLoader.UnloadPrefab(form.Name, form.Name, form.TransformInst, IsDestroyPrefabOnClose);

            //某个窗体关闭之后 TODO 这里没实际意义了
            GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_FORM_CLOSE_AFTER, form.Name);
            if (UIFormConfigInfo.Instance.IsExist(form.Name))
            {
                int formId = UIFormConfigInfo.Instance.Get(form.Name).FormID;
                GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_FORM_ID_CLOSE_AFTER, formId);
                if (form.IsPauseTask)
                {
                    //GameCenter.TaskController.RemoveHoldUI(formId);
                }
            }

            FLogger.DebugLog("OnHasFormHided:" + form.Name);
        }

        //区域队列改变
        public void OnRegionChanged(IUIFormWidget form, UIFormRegion oldRegion)
        {
            //从原来的窗体队列中删除
            RemoveRegionForm(form, oldRegion);
            //往窗体队列中删除
            var list = AddRegionForm(form);
            //重新设置深度
            ResetRegionFormsDepth(list, (int)form.UIRegion);
        }

        public void PauseAllForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 处理显示UI
        /// </summary>
        /// <param name="form"></param>
        public void HandleShowForm(IUIFormWidget form)
        {
            form.GameObjectInst.SetActive(true);
        }

        /// <summary>
        /// 处理隐藏UI
        /// </summary>
        /// <param name="form"></param>
        public void HandleHideForm(IUIFormWidget form)
        {
            form.GameObjectInst.SetActive(false);
        }

        //根据窗体名字获取脚本名字
        public Type GetClass(string formName)
        {
            try
            {
                Type result = null;
                DeclareUIConfig temp = DeclareUIConfig.Get(formName);
                var str = temp.ComponentScript;
                if (temp != null && !string.IsNullOrEmpty(str))
                {
                    string path = String.Format("Thousandto.GameUI.Form.{0}", str);
                    result = Type.GetType(path);
                    if (result == null)
                    {
                        Debug.LogError("dont found form :" + path);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                FLogger.LogError("exception:", formName, ex.Message);
            }
            return typeof(UINormalForm);
        }

        #region 私有函数
        //通过UIConfig配置,为所有窗体的事件注册默认处理函数
        private void RegisterAllInitEvents()
        {
            UIFormConfigInfo.Instance.ForeachAll((x, y) =>
            {
                RegisterUIEvents(x);
            });
            _cacheUIEvenetIds = null;
        }

        //卸载所有窗体的事件默认处理函数
        private void UnRegisterAllInitEvents()
        {
            var iter = _uiEventCallBacks.GetEnumerator();
            while (iter.MoveNext())
            {
                //将事件全都反注册
                UnRegisterUIEvents(iter.Current.Key);
            }
        }

        //为窗体的事件注册默认处理函数
        private void RegisterUIEvents(string formName, bool bClearCache = false)
        {
            //判断是否清理缓冲事件
            if (bClearCache)
            {
                //把缓冲事件清理了
                if (_uiEvents.ContainsKey(formName))
                {
                    _uiEvents.Remove(formName);
                }
            }
            //添加把事件绑定默认处理
            if (!_uiEventCallBacks.TryGetValue(formName, out List<KeyValuePair<int, EventManager.EventHandler>> eventList))
            {
                //1.如果ui事件缓存中没有的话,就直接从UIConfig中读取,并初始化写入
                if (UIFormConfigInfo.Instance.IsExist(formName))
                {
                    int _eventType = UIFormConfigInfo.Instance.Get(formName).EventID;
                    if (_eventType > EventDefines.EVENT_UI_BASE_ID && _eventType < EventDefines.EVENT_UI_BASE_ID + 100000)
                    {
                        if (_cacheUIEvenetIds == null)
                        {
                            var array = (int[])Enum.GetValues(typeof(UIEventDefine));
                            _cacheUIEvenetIds = new Dictionary<int, bool>(array.Length);
                            for (int i = 0; i < array.Length; ++i)
                            {
                                _cacheUIEvenetIds[array[i]] = true;
                            }
                        }
                        eventList = new List<KeyValuePair<int, EventHandler>>(4);
                        _uiEventCallBacks[formName] = eventList;

                        //TODO 去掉Lua相关的
                        //bool isLuaEvent = _eventType > EventDefines.EVENT_UI_BASE_ID + 50000;
                        //for (int i = (int)_eventType; i < (int)_eventType + MAX_UI_EVENT; ++i)
                        //{
                        //    if ((!isLuaEvent && (_cacheUIEvenetIds.ContainsKey(i) || GameCenter.LuaSystem.Adaptor.CheckUIEventExt(i)))
                        //        || (isLuaEvent && GameCenter.LuaSystem.Adaptor.CheckUILuaEvent(i)))
                        //    {
                        //        //创建一个事件处理器
                        //        EventHandler handler = CreateUIEventHandler(i, formName);
                        //        //注册事件
                        //        EventManager.SharedInstance.RegEventHandle(i, handler);
                        //        eventList.Add(new KeyValuePair<int, EventHandler>(i, handler));
                        //    }
                        //}
                    }
                }
            }
            else
            {
                //2.如果在ui事件缓存中存在,那么就把事件进行再次注册
                if (eventList != null)
                {
                    for (int i = 0; i < eventList.Count; i++)
                    {
                        if (eventList[i].Value != null)
                        {
                            //将事件进行注册
                            EventManager.SharedInstance.RegEventHandle((int)eventList[i].Key, eventList[i].Value);
                        }
                    }
                }
            }
        }

        //创建一个UI事件处理器
        private EventHandler CreateUIEventHandler(int fixType, string formName)
        {
            return (object o, object sender) =>
            {
                //判断当前事件系统是否挂起,如果挂起就直接返回
                if (_isSuspendEventSystem)
                {
                    DevLog.LogError("当前是挂起状态!丢弃事件ID:" + fixType);
                    return;
                }
                if (_allFormsBeClose)
                {
                    DevLog.LogError("当前是关闭状态!丢弃事件ID:" + fixType);
                    return;
                }

                //无论是什么事件响应 第一次响应的时候 进行UI加载
                if (_uiEvents.ContainsKey(formName))
                {
                    _uiEvents[formName].Add(new EventMessage(sender, null, fixType, o));
                }
                else
                {
                    if ((fixType) % MAX_UI_EVENT != CLOSE_EVENT_ID)
                    {
                        _uiEvents.Add(formName, new List<EventMessage>());
                        _uiEvents[formName].Add(new EventMessage(sender, null, fixType, o));
                        LoadUIForm(formName);
                    }
                }
                //这里不再需要每次处理完一个消息就把当前消息回调给卸载,因为这样会导致同一个消息在窗体加载之前,只能cache住第一个,以后的相同消息就会被丢弃掉.
                //这里不做清除,还是因为,在每次加载窗体后,会把当前窗体的在Manager上所有注册的回调给清理掉.
                //本消息再次进行注册时,也会重新清理掉_uiEvents的消息.防止消息都被缓存,而不调用LoadUIForm事件.
            };
        }

        //加载UI的Prefab
        private bool LoadUIForm(string name)
        {
            GameCenter.FormStateSystem.SetFormState(name, FormStateCode.FSC_LOADING, null);
            FLogger.DebugLog("Request Load Form ", name);
            InsertRequestQueue(name);
            return true;
            //TODO 这里暂时不处理资源加载的情况
//            var ret = UIPoolAssetsLoader.LoadFormAsyn(name, trans =>
//            {
//                FLogger.DebugLog("Request Loaded Form Finished ", name);
//                //查找请求列表中是否存在
//                if (!_formReqQueue.IsExist(name))
//                {
//                    FLogger.Log("已关闭当前加载的窗体: ", name);
//                    UIPoolAssetsLoader.UnloadPrefab(name, name, trans);
//                    RegisterUIEvents(name, true);
//                    return;
//                }

//                //如果当前是挂起状态
//                if (_isSuspendEventSystem)
//                {
//                    if (_isSuspendEventIgnoreForms.IndexOf(name) <= 0)
//                    {
//                        FLogger.DebugLog("当前是挂起状态!丢弃窗体: ", name);
//                        UIPoolAssetsLoader.UnloadPrefab(name, name, trans);
//                        RemoveFromRequestQueue(name);
//                        RegisterUIEvents(name, true);
//                        return;
//                    }
//                }
//                if (trans != null)
//                {
//#if UNITY_EDITOR
//                    RemoveChildUITexture(trans);
//#endif
//                    trans.name = name;
//                    trans.parent = _uiRootTransform;
//                    UnityUtils.Reset(trans);
//                    IUIFormWidget uiform = null;

//                    var formType = GetClass(name);
//                    uiform = trans.GetComponent(formType) as IUIFormWidget;
//                    if (uiform == null)
//                    {
//                        uiform = trans.gameObject.AddComponent(formType) as IUIFormWidget;
//                    }
//                    //判断是否需要绑定lua脚本
//                    if (uiform.HasLuaScript && (!uiform.IsBindLuaScript || GameCenter.LuaSystem.Adaptor.IsRenewForm(name)))
//                    {
//                        uiform.SetLuaBehaviour(name);
//                    }

//                    if (uiform != null)
//                    {
//                        _allForms.Add(uiform);
//                        var panel = uiform.GameObjectInst.GetComponent<UIPanel>();
//                        if (panel != null)
//                        {
//                            panel.alpha = _globalFormAlpha;
//                        }
//                        uiform.SetFormManager(this);
//                    }
//                    else
//                    {
//                        UnityEngine.Debug.LogError(string.Format("UIPoolAssetsLoader.LoadFormAsyn({0}) dont found class!!", name));
//                        RemoveFromRequestQueue(name);
//                        UIPoolAssetsLoader.UnloadPrefab(name, name, trans);
//                    }
//                }
//            });
//            return ret;
        }

        //添加到请求队列中
        private void InsertRequestQueue(string formName)
        {
            _formReqQueue.Insert(formName);
        }

        public void RemoveChildUITexture(Transform parent)
        {
#if UNITY_EDITOR
            var childCount = parent.childCount;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    var childTrans = parent.GetChild(i);
                    RemoveChildUITexture(childTrans);
                    var uiTexture = childTrans.GetComponent<UITexture>();
                    if (uiTexture)
                    {
                        uiTexture.mainTexture = null;
                    }
                }
            }
#endif
        }

        // 当窗体预制加载完毕后,执行的操作
        public void OnUIFormLoaded(IUIFormWidget widget)
        {
            var name = widget.Name;
            GameCenter.FormStateSystem.SetFormState(name, FormStateCode.FSC_LOADED, widget.GameObjectInst);
            if (_uiEvents.ContainsKey(name))
            {
                //1.窗体已经加载并且窗体也注册了自己的处理函数,所以需要从Manager中删除此窗体事件的注册处理函数
                UnRegisterUIEvents(name);

                //2.然后在把之前保存的事件重新发送给窗体
                _uiEvents.TryGetValue(name, out List<EventMessage> _temp);
                if (_temp != null)
                {
                    for (int i = 0; i < _temp.Count; i++)
                    {
                        //将事件push给UI
                        _temp[i].Execute();
                    }
                }
                //从Manager的中删除事件缓存
                _uiEvents.Remove(name);
            }

            //这里打印一些警告日志,用于警告那些加载,但是没有显示的窗体
            if (!widget.IsVisible && !widget.IsDestroy)
            {
                Debug.LogWarning("加载了窗体但是没有调用窗体的Show操作!" + widget.Name);
            }
        }

        //卸载某窗体的事件默认处理函数
        private void UnRegisterUIEvents(string name)
        {
            if (_uiEventCallBacks.ContainsKey(name))
            {
                List<KeyValuePair<int, EventHandler>> _event = _uiEventCallBacks[name];
                if (_event != null)
                {
                    for (int i = 0; i < _event.Count; i++)
                    {
                        if (_event[i].Value != null)
                        {
                            //将事件全都反注册
                            EventManager.SharedInstance.UnRegEventHandle(_event[i].Key, _event[i].Value);
                        }
                    }
                }

            }
        }

        //Panel填充DrawCall的频率
        private void OnPanelFillDrawCallRateChanged(object obj, object sender)
        {
            //UGUI 这里屏蔽掉NGUI相关的处理
            //var setValue = GameCenter.GameSetting.GetSetting(GameSettingKeyCode.PanelUpdateRate);
            //if (setValue < 0) setValue = 0;
            //if (setValue > 5) setValue = 5;
            //UIPanel.lateUpdateRate = setValue;
            //UIRect.updateRate = setValue;
        }

        //设置窗体的层
        private void SetFormLayer(IUIFormWidget form)
        {
            if (form.UIRegion == UIFormRegion.TopRegion || form.UIRegion == UIFormRegion.NoticeRegion)
            {
                if (form.GameObjectInst.layer != LayerUtils.UITop)
                {
                    ReplaceUILayer(form.TransformInst, LayerUtils.AresUI, LayerUtils.UITop);
                }
            }
            else if (form.GameObjectInst.layer != LayerUtils.AresUI)
            {
                ReplaceUILayer(form.TransformInst, LayerUtils.UITop, LayerUtils.AresUI);
            }
        }

        //替换UILayer
        private void ReplaceUILayer(Transform tran, int oldLayer, int newLayer)
        {
            if (tran.gameObject.layer == oldLayer)
            {
                tran.gameObject.layer = newLayer;
            }

            for (int i = 0; i < tran.childCount; i++)
            {
                ReplaceUILayer(tran.GetChild(i), oldLayer, newLayer);
            }
        }
        #endregion

        //从请求列表中移除窗体
        private void RemoveFromRequestQueue(string formName)
        {
            _formReqQueue.Remove(formName);
        }

        //获取区域窗体队列
        public List<IUIFormWidget> GetRegionForms(UIFormRegion region)
        {
            switch (region)
            {
                case UIFormRegion.BottomRegion:
                    {
                        return _bottomRegionForms;
                    }
                case UIFormRegion.MainRegion:
                    {
                        return _mainRegionForms;
                    }
                case UIFormRegion.MiddleRegion:
                    {
                        return _middleRegionForms;
                    }
                case UIFormRegion.TopRegion:
                    {
                        return _topRegionForms;
                    }
                case UIFormRegion.NoticeRegion:
                    {
                        return _noticeRegionForms;
                    }
                default:
                    {
                        return _middleRegionForms;
                    }
            }
        }

        //窗体的排序函数
        private int OnFormSortFunc(IUIFormWidget x, IUIFormWidget y)
        {
            if (x != null && y != null)
            {
                try
                {
                    return _formReqQueue.OnSortFunc(x.Name, y.Name);
                }
                catch
                {
                    return 0;
                }
            }
            else if (x != null)
            {
                return -1;
            }
            else if (y != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //对所有窗体的深度进行重新设置
        private void ResetRegionFormsDepth(List<IUIFormWidget> regionForms, int orginDepth)
        {
            int nextDepth = orginDepth;
            for (int i = 0; i < regionForms.Count; i++)
            {
                regionForms[i].ZStartDepth = nextDepth;
                nextDepth = regionForms[i].ZEndDepth + 1;
            }
        }

        //添加到窗体队列中
        private List<IUIFormWidget> AddRegionForm(IUIFormWidget form)
        {

            var list = GetRegionForms(form.UIRegion);
            if (list.IndexOf(form) < 0)
            {
                list.Add(form);
                //根据请求进行排序
                list.Sort(OnFormSortFunc);
                SetFormLayer(form);
            }
            return list;
        }

        //移除窗体从队列中
        private List<IUIFormWidget> RemoveRegionForm(IUIFormWidget form, UIFormRegion region)
        {
            var list = GetRegionForms(region);
            if (list.IndexOf(form) >= 0)
            {
                list.Remove(form);
            }
            return list;
        }

        /// <summary>
        /// 使窗体移动到最上面 -- 这是一个工具类,是某个窗体移动到最顶层
        /// 需要在ShowAfter之后调用
        /// </summary>
        /// <param name="form"></param>
        public void OnFormMoveTop(IUIFormWidget form)
        {
            if (!_formReqQueue.IsTop(form.Name))
            {
                RemoveFromRequestQueue(form.Name);
                InsertRequestQueue(form.Name);
                var list = GetRegionForms(form.UIRegion);
                if (list.IndexOf(form) >= 0)
                {
                    //根据请求进行排序
                    list.Sort(OnFormSortFunc);
                    //重新设置深度
                    ResetRegionFormsDepth(list, (int)form.UIRegion);
                    //FLogger.DebugLogError("OnFormMoveTo:" , form.Name , "::" , form.ZDepth);
                    if (form.FormType == UIFormType.Normal)
                    {
                        //把这个窗体设置为激活
                        SetActiveForm(GetEnableActiveForm());
                    }
                }
            }
        }
    }
}
