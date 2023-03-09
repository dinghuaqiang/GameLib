using System;
using UnityEngine;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体管理者接口
    /// </summary>
    public interface IUIFormManager
    {
        /// <summary>
        /// 当前是否被挂起
        /// </summary>
        bool IsSuspend { get; }

        /// <summary>
        /// 判断当前操作是否控制角色移动
        /// </summary>
        bool IsControled { get; set; }

        /// <summary>
        /// 是否是刘海屏
        /// </summary>
        bool IsNotchInScreen { get; }

        /// <summary>
        /// 当前屏幕方向
        /// </summary>
        ScreenOrientation CurrentOrientation { get; }

        /// <summary>
        /// 曲面屏缩放值
        /// </summary>
        float CurvedScreenScale { get; set; }

        /// <summary>
        /// UI的整体透明度，用于隐藏界面UI
        /// </summary>
        float GlobalFormAlpha { get; set; }

        /// <summary>
        /// UI的2D相机
        /// </summary>
        Camera UI2DCamera { get; }

        /// <summary>
        /// 摄像机的根节点
        /// </summary>
        GameObject UICameraRootGo { get; }

        /// <summary>
        /// 是否正在引导
        /// </summary>
        bool IsGuiding { get; set; }

        /// <summary>
        /// 窗体加载后的操作
        /// </summary>
        /// <param name="widget"></param>
        void OnUIFormLoaded(IUIFormWidget widget);

        /// <summary>
        /// 窗体被卸载后的操作
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        bool OnUIFormUnload(IUIFormWidget form);

        /// <summary>
        /// 当一个窗体显示后的操作
        /// </summary>
        /// <param name="widget"></param>
        void OnHasFormShowed(IUIFormWidget widget);

        /// <summary>
        /// 当一个窗体隐藏后的操作
        /// </summary>
        /// <param name="widget"></param>
        void OnHasFormHided(IUIFormWidget widget);

        /// <summary>
        /// 窗体的显示区域发生变化
        /// </summary>
        /// <param name="form"></param>
        /// <param name="oldRegion"></param>
        void OnRegionChanged(IUIFormWidget form, UIFormRegion oldRegion);

        /// <summary>
        /// 获取显示的窗体
        /// </summary>
        /// <typeparam name="Form"></typeparam>
        /// <returns></returns>
        Form GetVisabledUIForm<Form>() where Form : IUIFormWidget;

        /// <summary>
        /// 窗体移动到最上面
        /// </summary>
        /// <param name="form"></param>
        void OnFormMoveTop(IUIFormWidget form);

        /// <summary>
        /// 暂停所有的窗体（暂时隐藏所有的窗体）
        /// </summary>
        //void SuspendAllForm();
        void PauseAllForm();

        /// <summary>
        /// 恢复所有的窗体
        /// </summary>
        void ResumeAllForm();

        /// <summary>
        /// 处理显示界面
        /// </summary>
        void HandleShowForm(IUIFormWidget form);

        /// <summary>
        /// 处理隐藏的界面
        /// </summary>
        void HandleHideForm(IUIFormWidget form);

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Type GetClass(string name);
    }
}
