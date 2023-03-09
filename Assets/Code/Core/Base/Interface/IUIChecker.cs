namespace GameLib.Core.Base
{
    /// <summary>
    /// UI的检测接口
    /// </summary>
    public interface IUIChecker
    {
        /// <summary>
        /// 是否正在控制摇杆
        /// </summary>
        bool IsControlling { get; }
        /// <summary>
        /// 是否点击UI
        /// </summary>
        bool IsHitUI(int touchID);
        /// <summary>
        /// 是否点击UI
        /// </summary>
        bool IsHitUI(int touchID, string uiname);
        /// <summary>
        /// 焦点是否在输入框上
        /// </summary>
        bool IsSelectInputField();
    }
}
