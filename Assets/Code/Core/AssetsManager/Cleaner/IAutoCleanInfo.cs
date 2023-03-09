namespace GameLib.Core.Asset
{
    /// <summary>
    /// 自动清理的数据需要继承的接口
    /// </summary>
    public interface IAutoCleanInfo
    {
        //将要被清楚了的标记
        bool WillBeCleared { get; }
        //第一次使用的时间
        ObjectUsedInfo UsedTimeInfo { get; }
    }
}
