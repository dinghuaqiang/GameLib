namespace GameLib.Core.Utils
{
    /// <summary>
    /// IOS的路径设定
    /// 基本上也是由appdata组成
    /// </summary>
    public class PathProviderIOS : PathProviderBase
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
            return AppPersistentPath + "/StreamingAssets";
        }

        protected override string OnGetWriteRootPath()
        {
            return AppPersistentPath + "/TDFiles";
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
                return "Assets/GameAssets/Resources/";
            }
        }

        protected override string OnGetDeviceRootPath()
        {
            return AppPersistentPath;
        }

        protected override string OnGetReleaseResRootPath()
        {
            return OnGetStreamingRootPath();
        }
    }
}
