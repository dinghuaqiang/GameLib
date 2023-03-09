namespace GameLib.Core.UI
{
    /// <summary>
    /// UI的事件接口
    /// </summary>
    public interface IUIEvent
    {
        /// <summary>
        /// 注册事件
        /// </summary>
        void RegisterEvents();
        /// <summary>
        /// 卸载事件
        /// </summary>
        void UnRegisterEvents();
    }
}