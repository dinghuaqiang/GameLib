namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源请求的结构
    /// </summary>
    public interface IAssetRequest
    {
        //进度
        float Progress { get; }
        //是否完成
        bool IsDone { get; }
        //请求的资源
        UnityEngine.Object Asset { get; }
    }
}
