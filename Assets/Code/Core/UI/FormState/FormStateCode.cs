namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体状态码
    /// </summary>
    public enum FormStateCode
    {
        //当前窗体没有状态
        FSC_NONE = 0,
        //加载中
        FSC_LOADING,
        //加载完成
        FSC_LOADED,

        //正在打开
        FSC_OPENING,
        //已经打开
        FSC_OPENED,
        //正在关闭中
        FSC_CLOSEING,
        //已经关闭
        FSC_CLOSED,
        //卸载完成
        FSC_UNLOADED,
        //窗体卸载
        FSC_DESTROY
    }
}
