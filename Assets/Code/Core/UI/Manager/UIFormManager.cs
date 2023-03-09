using System;
using GameLib.Core.Base;
using UnityEngine;
using UnityEngine.UI;

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
        private ScreenOrientation _currentOrientation = ScreenOrientation.Landscape;
        #endregion

        #region 属性
        /// <summary>
        /// UI相机
        /// </summary>
        public Camera UICamera { get { return _uiCamera; } }
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
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        public bool IsControlling => throw new NotImplementedException();

        public bool IsSuspend => throw new NotImplementedException();

        public bool IsControled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsNotchInScreen => throw new NotImplementedException();

        public bool IsGuiding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float CurvedScreenScale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float GlobalFormAlpha { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Camera UI2DCamera => throw new NotImplementedException();

        public GameObject UICameraRootGo => throw new NotImplementedException();

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

        public void OnUIFormLoaded(IUIFormWidget widget)
        {
            throw new NotImplementedException();
        }

        public bool OnUIFormUnload(IUIFormWidget form)
        {
            throw new NotImplementedException();
        }

        public void OnHasFormShowed(IUIFormWidget widget)
        {
            throw new NotImplementedException();
        }

        public void OnHasFormHided(IUIFormWidget widget)
        {
            throw new NotImplementedException();
        }

        public void OnRegionChanged(IUIFormWidget form, UIFormRegion oldRegion)
        {
            throw new NotImplementedException();
        }

        public Form GetVisabledUIForm<Form>() where Form : IUIFormWidget
        {
            throw new NotImplementedException();
        }

        public void OnFormMoveTop(IUIFormWidget form)
        {
            throw new NotImplementedException();
        }

        public void PauseAllForm()
        {
            throw new NotImplementedException();
        }

        public void ResumeAllForm()
        {
            throw new NotImplementedException();
        }

        public void HandleShowForm(IUIFormWidget form)
        {
            throw new NotImplementedException();
        }

        public void HandleHideForm(IUIFormWidget form)
        {
            throw new NotImplementedException();
        }

        public Type GetClass(string name)
        {
            throw new NotImplementedException();
        }
    }
}
