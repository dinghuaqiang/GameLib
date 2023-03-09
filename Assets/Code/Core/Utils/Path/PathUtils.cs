using System.IO;
using UnityEngine;

namespace GameLib.Core.Utils
{
    public class PathUtils
    {
        /// <summary>
        /// 版本类型0:编辑器,1:iphone,2:android
        /// </summary>
        private static int _buildType = 0;
        /// <summary>
        /// 是否通过Bundle来进行加载资源
        /// </summary>
        private static bool _isStream = false;

        private static bool _useDevEnvPath = false;

        private static IPathProvider _provider = null;

        public static IPathProvider Provider
        {
            get
            {
                return _provider;
            }
        }

        public PathUtils()
        {
            Initialize(false);
        }

        /// <summary>
        /// 此属性只对编辑器有效
        /// </summary>
        public static bool IsDevEnv
        {
            get
            {
                return _useDevEnvPath && Application.isEditor;
            }

            set
            {
                if (_useDevEnvPath != value)
                {
                    _useDevEnvPath = value;
                    ResetProvider();
                }
            }
        }

        /// <summary>
        /// 0 pc， 2 android， 1 iphone
        /// </summary>
        /// <returns></returns>
        public static int GetBuildType()
        {
            return _buildType;
        }

        //当前是不是通过Stream来读取资源
        public static bool IsStreaming()
        {
            return _isStream;
        }

        private void Initialize(bool isStream, int buildType = 0)
        {
            _isStream = isStream;
            _buildType = (buildType >= 0) ? buildType : DefaultBuildType();
            ResetProvider();
        }

        private static void ResetProvider()
        {
            _provider = PathProviderFactory.CreateProvider(_buildType, _useDevEnvPath);
            _provider.IsStream = _isStream;
            Debug.Log(string.Format("IsStream:{0}, BuildType:{1}, IsMainProject:{2}", _isStream, _buildType, _useDevEnvPath));
            Debug.Log(Infomation());
        }

        private static int DefaultBuildType()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    return 2;
                case RuntimePlatform.IPhonePlayer:
                    return 1;
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.LinuxEditor:
                    return 0;
                case RuntimePlatform.WindowsPlayer:
                    return 3;
                case RuntimePlatform.WebGLPlayer:
                    return 4;
                default:
                    return 0;
            }
        }

        //获取App的Streamming路径
        public static string GetAppStreamingPath(string relativePath)
        {
            return _provider.CombinePath(_provider.AppStreamPath, relativePath);
        }

        //获取App的Resource路径
        public static string GetAppResourcePath(string relativePath)
        {
            return _provider.CombinePath(_provider.AppResourceRootPath, relativePath);
        }

        //获取App的Config路径
        public static string GetAppConfigFilePath(string relativePath)
        {
            return _provider.CombinePath(_provider.AppConfigRootPath, relativePath);
        }

        //streaming 路径
        public static string GetStreamingRootPath(string relativePath)
        {
            return _provider.CombinePath(_provider.StreamingRootPath, relativePath);
        }

        //获取资源路径
        public static string GetResourcePath(string relativePath)
        {
            return _provider.CombinePath(_provider.ResourceRootPath, relativePath);
        }

        //获取资源路径
        public static string GetConfigFilePath(string relativePath)
        {
            return _provider.CombinePath(_provider.ConfigRootPath, relativePath);
        }

        //获取配置文件在Resource下面的路径
        public static string GetConfigFilePathRelativeResouce(string fullPath)
        {
            return fullPath.Replace(_provider.ConfigRootPath + "/", "");
        }

        //获取可写路径
        public static string GetWritePath(string relativePath)
        {
            return _provider.CombinePath(_provider.WriteRootPath, relativePath);
        }

        //获取存储区名称
        public static string GetDeviceRootPath(string relativePath)
        {
            return _provider.CombinePath(_provider.DeviceRootPath, relativePath);
        }

        //获取路径中以包名命名的文件夹路径
        public static string GetReleaseResPath(string relativePath)
        {
            return _provider.CombinePath(_provider.ReleaseResRootPath, relativePath);
        }

        //获取资源释放路径的根路径
        public static string GetReleaseResRootPath()
        {
            return _provider.ReleaseResRootPath;
        }

        /// <summary>
        /// 配置文件路径，需要查找一下存储路径是否存在，存在就替换路径
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public static string FixedPath(string configFilePath)
        {
            if (configFilePath.IndexOf(_provider.AppStreamPath) >= 0)
            {
                string fixPath = configFilePath.Replace(_provider.AppStreamPath, _provider.ReleaseResRootPath);
                if (File.Exists(fixPath))
                {
                    return fixPath;
                }
            }
            return configFilePath;
        }

        public static string Infomation()
        {
            return _provider.Print();
        }
    }
}
