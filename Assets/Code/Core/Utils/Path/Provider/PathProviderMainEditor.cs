namespace GameLib.Core.Utils
{
    /// <summary>
    /// 编辑器状态下的路径设定
    /// 编辑状态子啊的路径基本上在appdata路径组成
    /// </summary>
    public class PathProviderMainEditor : PathProviderBase
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
            return AppDataPath + "/StreamingAssets";
        }
        protected override string OnGetReleaseResRootPath()
        {
            return OnGetStreamingRootPath();
        }
        protected override string OnGetWriteRootPath()
        {
            return AppPersistentPath + "/TDFiles";
        }
        protected override string OnGetConfigRootPath()
        {
            if (IsStream)
            {
                return AppDataPath + "/StreamingAssets/GameAssets/Resources/Config";
            }
            else
            {
                return "Assets/GameAssets/Resources/Config";
            }
        }
        protected override string OnGetResourceRootPath()
        {
            if (IsStream)
            {
                return AppDataPath + "/StreamingAssets/GameAssets/Resources";
            }
            else
            {
                return "Assets/GameAssets/Resources";
            }
        }
        protected override string OnGetDeviceRootPath()
        {
            return "C:\\";
        }
    }
}
