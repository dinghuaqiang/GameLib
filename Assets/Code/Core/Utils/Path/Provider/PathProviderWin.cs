namespace GameLib.Core.Utils
{
    /// <summary>
    /// Windows PC的路径设定
    /// 这个也是由appdata组成
    /// </summary>
    public class PathProviderWin : PathProviderBase
    {
        protected override string OnGetAppFilePath()
        {
            return AppStreamPath + "/GameAssets/Resources/Config/LocalVersion.xml";
        }
        protected override string OnGetAppConfigRootPath()
        {
            return AppStreamPath + "/GameAssets/Resources/Config";
        }
        protected override string OnGetAppResourceRootPath()
        {
            return AppStreamPath + "/GameAssets/Resources";
        }
        protected override string OnGetStreamingRootPath()
        {
            return AppStreamPath;
        }
        protected override string OnGetWriteRootPath()
        {
            return AppPersistentPath + "/TDFiles";
        }
        protected override string OnGetDeviceRootPath()
        {
            return AppDataPath;
        }
        protected override string OnGetReleaseResRootPath()
        {
            return OnGetStreamingRootPath();
        }
        protected override string OnGetConfigRootPath()
        {
            return AppDataPath + "/StreamingAssets/GameAssets/Resources/Config";
        }
        protected override string OnGetResourceRootPath()
        {
            return AppDataPath + "/StreamingAssets/GameAssets/Resources";
        }
    }
}
