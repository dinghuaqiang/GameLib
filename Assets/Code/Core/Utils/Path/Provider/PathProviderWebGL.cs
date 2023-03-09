namespace GameLib.Core.Utils
{
    /// <summary>
    /// Android下的路径设定 
    /// android的路径大部分是有app的持续化路径组成.
    /// </summary>
    public class PathProviderWebGL : PathProviderBase
    {
        protected override string OnGetAppFilePath()
        {
            return AppDataPath;
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
            return AppPersistentPath + "/StreamingAssets";
        }
        protected override string OnGetReleaseResRootPath()
        {
            return OnGetStreamingRootPath();
        }
        protected override string OnGetWriteRootPath()
        {
            return AppPersistentPath + "/TDFiles";
        }
        protected override string OnGetDeviceRootPath()
        {
            return AppPersistentPath;
            /* android 11之后 禁止调用外部存储了.
            if (AppPersistentPath.Contains("Android"))
            {
                return AppPersistentPath.Substring(0, AppPersistentPath.IndexOf("Android"));
            }
            else
            {
                return AppPersistentPath + "/..";
            } */
        }
        protected override string OnGetConfigRootPath()
        {
            return AppPersistentPath + "/StreamingAssets/GameAssets/Resources/Config";
        }
        protected override string OnGetResourceRootPath()
        {
            if (IsStream)
            {
                return AppPersistentPath + "/StreamingAssets/GameAssets/Resources";
            }
            else
            {
                return "";
            }
        }
    }
}
