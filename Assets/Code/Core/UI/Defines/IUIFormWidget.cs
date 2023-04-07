using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体组件的接口
    /// </summary>
    public interface IUIFormWidget : IMonoCache
    {
        /// <summary>
        /// 窗体名字
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 窗体正在使用的层级
        /// </summary>
        UIFormRegion UIRegion { get; }

        /// <summary>
        /// 窗体类型
        /// </summary>
        UIFormType FormType { get; }

        /// <summary>
        /// 该窗体的深度，就是这个窗体GameObject的深度
        /// </summary>
        int ZStartDepth { get; set; }

        int ZEndDepth { get; }

        /// <summary>
        /// 当前窗体是否可见
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// 当前窗体是否被销毁
        /// </summary>
        bool IsDestroy { get; }

        /// <summary>
        /// 当前窗体是否激活
        /// </summary>
        bool IsActived { get; }

        /// <summary>
        /// 当前窗体是否是全屏
        /// </summary>
        bool IsFullScreen { get; set; }

        /// <summary>
        /// 是否挂起任务
        /// </summary>
        bool IsPauseTask { get; set; }

        //当前窗体主Panel
        //Panel MainPanel { get; }
        Canvas MainCanvas { get; }

        /// <summary>
        /// 是否包含Lua逻辑
        /// </summary>
        bool HasLuaScript { get; }

        /// <summary>
        /// 是否已经绑定了Lua脚本
        /// </summary>
        bool IsBindLuaScript { get; }

        /// <summary>
        /// 是否正在关闭
        /// </summary>
        bool IsHiding { get; }

        /// <summary>
        /// 带有父窗体的显示
        /// </summary>
        /// <param name="parentForm">父窗体</param>
        void Show(IUIFormWidget parentForm);

        /// <summary>
        /// 显示该窗体
        /// </summary>
        void Show();

        /// <summary>
        /// 隐藏该窗体
        /// </summary>
        void Hide();

        /// <summary>
        /// 尝试隐藏窗体
        /// </summary>
        bool TryHide();

        /// <summary>
        /// 使窗体激活
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        bool SetActive(bool isActive);

        /// <summary>
        /// 设置窗体管理者
        /// </summary>
        /// <param name="manager"></param>
        void SetFormManager(IUIFormManager manager);

        /// <summary>
        /// 恢复窗体管理器
        /// </summary>
        void ResetFormManager();

        /// <summary>
        /// 设置Lua行为
        /// </summary>
        /// <param name="name"></param>
        void SetLuaBehaviour(string name);

        /// <summary>
        /// 屏幕方向改变的监听
        /// </summary>
        /// <param name="so"></param>
        void ScreenOrientationChanged(ScreenOrientation so);

        /// <summary>
        /// 曲面屏缩放值改表的监听
        /// </summary>
        /// <param name="value"></param>
        void CurvedScreenScaleChanged(float value);

        /// <summary>
        /// 屏幕分辨率改表的监听
        /// </summary>
        void ScreenSizeChanged();
    }
}
