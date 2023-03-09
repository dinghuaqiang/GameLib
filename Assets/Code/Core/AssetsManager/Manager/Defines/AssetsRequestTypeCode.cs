namespace GameLib.Core.Asset
{
    /// <summary>
    /// 文件请求码
    /// </summary>
    public enum AssetsRequestTypeCode
    {
        //异步加载
        Resource = 0,
        WWW,
        //同步加载
        BundleFile = 100,
        //读取一个普通文件:包括任何文件
        BytesFile,
        //读取一个可写的普通文件
        EnableWriteBytesFile,
    }
}
