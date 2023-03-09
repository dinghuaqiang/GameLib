namespace GameLib.Core.Utils
{
    /// <summary>
    /// 编辑器状态下的路径设定
    /// 编辑状态子啊的路径基本上在appdata路径组成
    /// </summary>
    public class PathProviderEditor : PathProviderBase
    {
        private string _persistentPath = null;
        private string PersistentPath
        {
            get
            {
                if (string.IsNullOrEmpty(_persistentPath))
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDataPath);
                    _persistentPath = di.Parent.FullName + "/Persistent";
                }
                return _persistentPath;
            }
        }
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
            return PersistentPath + "/StreamingAssets";
        }
        protected override string OnGetReleaseResRootPath()
        {
            return OnGetStreamingRootPath();
        }
        protected override string OnGetWriteRootPath()
        {
            return PersistentPath + "/TDFiles";
        }
        protected override string OnGetConfigRootPath()
        {
            if (IsStream)
            {
                return PersistentPath + "/StreamingAssets/GameAssets/Resources/Config";
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
                return PersistentPath + "/StreamingAssets/GameAssets/Resources";
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
