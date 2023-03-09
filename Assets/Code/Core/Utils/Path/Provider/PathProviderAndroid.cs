using System.IO;

namespace GameLib.Core.Utils
{
    public class PathProviderAndroid : PathProviderBase
    {
        /// <summary>
        /// 处理Google aab分包的资源读取
        /// </summary>
        public PathProviderAndroid() : base()
        {
            string path = Path.GetDirectoryName(AppDataPath);
            path = path + "/split_base_assets.apk";
            if (File.Exists(path))
            {
                AppDataPath = path;
            }
        }

        protected override string OnGetAppFilePath()
        {
            return AppDataPath;
        }

        protected override string OnGetAppConfigRootPath()
        {
            return "/GameAssets/Resources/Config";
        }

        protected override string OnGetAppResourceRootPath()
        {
            return "/GameAssets/Resources";
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
