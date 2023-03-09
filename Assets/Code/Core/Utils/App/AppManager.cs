using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// App文件的管理
    /// </summary>
    public class AppManager
    {
        #region//常量定义
        /// <summary>
        /// 文件列表读取
        /// </summary>
        private const string CN_FILE_LIST_KEY = "FileList.txt";
        /// <summary>
        /// LocalVersion的路径名
        /// </summary>
        private const string CN_LOCAL_VERSION_FILE_KEY = "GameAssets/Resources/Config/LocalVersion.xml";
        #endregion

        #region//静态变量和属性
        /// <summary>
        /// App的实例化
        /// </summary>
        private static AppManager _instance;
        public static AppManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppManager();
                }
                return _instance;
            }
        }
        #endregion

        #region//私有变量
        /// <summary>
        /// App文件的路径
        /// </summary>
        private string _appPath = null;

        /// <summary>
        /// 包体内是否存在FileList.txt文件
        /// </summary>
        private bool _isExistFileList = false;
        /// <summary>
        /// 资源数据信息
        /// </summary>
        private Dictionary<string, AppAssetFileInfo> _assetData = null;
        /// <summary>
        /// 本地版本数据
        /// </summary>
        private Dictionary<string, string> _localVersionData = null;

        /// <summary>
        /// 本地版本的字符串
        /// </summary>
        private string _localVersionText = null;

        /// <summary>
        /// 是否初始化
        /// </summary>
        private int _initCount = 0;

        /// <summary>
        /// 远程配置数据
        /// </summary>
        private SecurityElement _remoteVersionData = null;
        #endregion

        #region//属性信息
        /// <summary>
        /// App文件的路径
        /// </summary>
        public string AppPath
        {
            get
            {
                if (_appPath == null)
                {
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        _appPath = PathUtils.Provider.AppDataPath;
                    }
                    else
                    {
                        _appPath = PathUtils.Provider.AppStreamPath;
                    }
                }
                return _appPath;
            }

        }

        /// <summary>
        /// 资源数据信息
        /// </summary>
        public Dictionary<string, AppAssetFileInfo> AssetData
        {
            get
            {
                if (_assetData == null)
                {
                    _assetData = ReadInAppFileList();
                }
                return _assetData;
            }
        }

        /// <summary>
        /// 是否存在文件列表
        /// </summary>
        public bool IsExistFileList
        {
            get
            {
                if (_assetData == null)
                {
                    _assetData = ReadInAppFileList();
                }
                return _isExistFileList;
            }
        }

        /// <summary>
        /// 本地版本数据
        /// </summary>
        public Dictionary<string, string> LocalVersionData
        {
            get
            {
                if (_localVersionData == null)
                {
                    _localVersionData = ReadInAppLocalVersion();
                }
                return _localVersionData;
            }
        }

        /// <summary>
        /// 本地版本数据
        /// </summary>
        public SecurityElement RemoteVersionData
        {
            get
            {
                return _remoteVersionData;
            }
        }

        /// <summary>
        /// 包体内版本的文本内容
        /// </summary>
        public string LocalVersionText
        {
            get
            {
                if (_localVersionText == null)
                {
                    ReadInAppLocalVersion();
                }
                return _localVersionText;
            }
        }

        /// <summary>
        /// 当前AppManager是否初始化了
        /// </summary>
        public bool IsInited
        {
            get
            {
                return _initCount >= 2;
            }
        }
        #endregion

        #region//公共方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            _initCount = 0;
            ReadInAppLocalVersionAsync((x, y) =>
            {
                _localVersionData = x;
                _localVersionText = y;
                _initCount = _initCount + 1;
            });
            ReadInAppFileListAsync(x =>
            {
                _assetData = x;
                _initCount = _initCount + 1;
            });
        }

        /// <summary>
        /// 获取app中本地版本的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetLocalVersionValue(string key)
        {
            string val = null;
            LocalVersionData.TryGetValue(key, out val);
            return val;
        }

        /// <summary>
        /// 释放文件或者目录
        /// </summary>
        /// <param name="releaseDirOrFiles"></param>
        public void ReleaseDirOrFiles(string[] releaseDirOrFiles)
        {
            Debug.Log("开始释放配置资源!!");
            if (Application.platform == RuntimePlatform.Android)
            {
                int total = 0;
                int count = 0;
                ZipFileUtils.UnzipTargetList(AppPath, releaseDirOrFiles, PathUtils.GetReleaseResRootPath(), true, ref total, ref count);
            }
            else if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WebUtils.ReleaseFiles(AppPath, releaseDirOrFiles, PathUtils.GetReleaseResRootPath());
            }
            else
            {
                FileUtils.ReleaseFiles(AppPath, releaseDirOrFiles, PathUtils.GetReleaseResRootPath());
            }
        }


        /// <summary>
        /// 从当前app目录读取文件
        /// 默认:
        /// 1.如果是Android的话,就直接使用dataPath
        /// 2.如果是其他平台的话,使用streamingAssetsPath当前他的包体内容
        /// </summary>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public byte[] ReadBytes(string relativPath)
        {

            if (Application.platform == RuntimePlatform.Android)
            {
                return ZipFileUtils.ReadBytesFromApp(AppPath, relativPath);
            }
            else
            {
                string fullFilePath = Path.Combine(AppPath, relativPath);
                if (File.Exists(fullFilePath))
                    return File.ReadAllBytes(fullFilePath);
            }

            return null;
        }

        /// <summary>
        /// 从当前app目录读取文件
        /// 默认:
        /// 1.如果是Android的话,就直接使用dataPath
        /// 2.如果是其他平台的话,使用streamingAssetsPath当前他的包体内容
        /// </summary>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public void ReadBytesAsync(string relativPath, Action<byte[]> callBack)
        {
            if (callBack == null) return;

            if (Application.platform == RuntimePlatform.Android)
            {
                callBack(ZipFileUtils.ReadBytesFromApp(AppPath, relativPath));
            }
            else if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WebUtils.ReadBytes(Path.Combine(AppPath, relativPath), callBack);
            }
            else
            {
                string fullFilePath = Path.Combine(AppPath, relativPath);
                if (File.Exists(fullFilePath))
                    callBack(File.ReadAllBytes(fullFilePath));
                else
                    callBack(null);
            }
        }

        /// <summary>
        ///  从当前APP中读取文本
        /// 默认:
        /// 1.如果是Android的话,就直接使用dataPath
        /// 2.如果是其他平台的话,使用streamingAssetsPath当前他的包体内容
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public string[] ReadAllLine(string relativPath)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return ZipFileUtils.ReadAllLineFromApp(AppPath, relativPath);
            }
            else
            {
                string fullFilePath = Path.Combine(AppPath, relativPath);
                if (File.Exists(fullFilePath))
                    return File.ReadAllLines(fullFilePath);
            }

            return null;
        }

        /// <summary>
        ///  从当前APP中读取文本
        /// 默认:
        /// 1.如果是Android的话,就直接使用dataPath
        /// 2.如果是其他平台的话,使用streamingAssetsPath当前他的包体内容
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public void ReadAllLineAsync(string relativPath, Action<string[]> callBack)
        {
            if (callBack == null) return;

            if (Application.platform == RuntimePlatform.Android)
            {
                callBack(ZipFileUtils.ReadAllLineFromApp(AppPath, relativPath));
            }
            else if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WebUtils.ReadAllLine(Path.Combine(AppPath, relativPath), callBack);
            }
            else
            {
                string fullFilePath = Path.Combine(AppPath, relativPath);
                if (File.Exists(fullFilePath))
                {
                    callBack(File.ReadAllLines(fullFilePath));
                }
                else
                {
                    callBack(null);
                }
            }
        }

        /// <summary>
        /// 从包体内读取文本信息
        /// </summary>
        /// <param name="relativPath"></param>
        /// <param name="callBack"></param>
        public void ReadAllTextAsync(string relativPath, Action<string> callBack)
        {
            if (callBack == null) return;

            if (Application.platform == RuntimePlatform.Android)
            {
                callBack(ZipFileUtils.ReadAllTextFromApp(AppPath, relativPath));
            }
            else if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WebUtils.ReadAllText(Path.Combine(AppPath, relativPath), callBack);
            }
            else
            {
                string fullFilePath = Path.Combine(AppPath, relativPath);
                if (File.Exists(fullFilePath))
                {
                    callBack(File.ReadAllText(fullFilePath));
                }
                else
                {
                    callBack(null);
                }
            }
        }


        /// <summary>
        /// 游戏资源是否在app中
        /// </summary>
        /// <param name="assetPath">类似如此的路径:"Assets/GameAssets/Resources/Config/Sound.xml"</param>
        /// <returns></returns>
        public bool AssetInApp(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) return false;
            return AssetData.ContainsKey(assetPath.ToLower());
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <param name="assetPath"></param>
        /// <returns></returns>
        public AppAssetFileInfo GetAssetInfo(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) return null;
            AppAssetFileInfo result = null;
            AssetData.TryGetValue(assetPath.ToLower(), out result);
            return result;
        }

        /// <summary>
        /// 判断文件是否在包体内, 在Android下尽量不要通过这个接口进行查询.
        /// </summary>
        /// <param name="filePath">以assets目录为根目录的相对文件路径</param>
        /// <returns></returns>
        public bool Exists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;
            return ZipFileUtils.Exists(AppPath, filePath);
        }


        /// <summary>
        /// 把一个全路径调整为一个相对的资源路径
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public string NormalizeAssetPath(string fullPath)
        {
            fullPath = fullPath.Replace("\\", "/");
            string releaseRoot = PathUtils.GetReleaseResRootPath();
            if (fullPath.IndexOf(releaseRoot) >= 0)
            {
                return fullPath.Replace(releaseRoot + "/", "");
            }

            return fullPath;
        }

        #endregion

        #region//私有变量

        /// <summary>
        /// 读取包内文件配置信息
        /// </summary>
        private void ReadInAppFileListAsync(Action<Dictionary<string, AppAssetFileInfo>> callBack)
        {
            if (_assetData == null)
            {
                _isExistFileList = false;
                _assetData = new Dictionary<string, AppAssetFileInfo>();
                ReadAllLineAsync(CN_FILE_LIST_KEY, (fileData) =>
                {
                    if (fileData != null)
                    {
                        for (int i = 0; i < fileData.Length; ++i)
                        {
                            var splitArray = fileData[i].Split('\t');
                            AppAssetFileInfo inData = new AppAssetFileInfo();
                            inData.Path = splitArray[0];
                            inData.MD5 = splitArray[1];
                            inData.Size = int.Parse(splitArray[2]);
                            _assetData[inData.Path.ToLower()] = inData;
                        }
                        _isExistFileList = true;
                    }
                    callBack(_assetData);
                });
            }
            else
            {
                callBack(_assetData);
            }
        }
        /// <summary>
        /// 读取包体内的版本信息
        /// </summary>
        /// <returns></returns>
        private void ReadInAppLocalVersionAsync(Action<Dictionary<string, string>, string> callBack)
        {
            if (_localVersionData == null)
            {
                _localVersionData = new Dictionary<string, string>();
                ReadAllTextAsync(CN_LOCAL_VERSION_FILE_KEY, (fileData) =>
                {
                    if (fileData != null)
                    {
                        //解析xml
                        var dom = MonoXmlUtils.GetRootNodeFromString(fileData);
                        dom = dom.Tag != "local_info" ? dom.SearchForChildByTag("local_info") : dom;
                        if (dom != null)
                        {
                            var childs = dom.Children;
                            for (int i = 0; i < childs.Count; i++)
                            {
                                var ch = childs[i] as SecurityElement;
                                if (!string.IsNullOrEmpty(ch.Tag) && !string.IsNullOrEmpty(ch.Text))
                                {
                                    _localVersionData[ch.Tag] = ch.Text;
                                }
                            }
                        }
                    }
                    callBack(_localVersionData, fileData);
                });
            }
            else
            {
                callBack(_localVersionData, _localVersionText);
            }
        }

        /// <summary>
        /// 读取包内文件配置信息
        /// </summary>
        private Dictionary<string, AppAssetFileInfo> ReadInAppFileList()
        {
            if (_assetData == null)
            {
                _isExistFileList = false;
                _assetData = new Dictionary<string, AppAssetFileInfo>();
                var fileData = ReadAllLine(CN_FILE_LIST_KEY);
                if (fileData != null)
                {
                    for (int i = 0; i < fileData.Length; ++i)
                    {
                        var splitArray = fileData[i].Split('\t');
                        AppAssetFileInfo inData = new AppAssetFileInfo();
                        inData.Path = splitArray[0];
                        inData.MD5 = splitArray[1];
                        inData.Size = int.Parse(splitArray[2]);
                        _assetData[inData.Path.ToLower()] = inData;
                    }
                    _isExistFileList = true;
                }
            }
            return _assetData;
        }

        /// <summary>
        /// 读取包体内的版本信息
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> ReadInAppLocalVersion()
        {
            if (_localVersionData == null)
            {
                _localVersionData = new Dictionary<string, string>();
                var fileData = ReadAllLine(CN_LOCAL_VERSION_FILE_KEY);
                if (fileData != null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < fileData.Length; ++i)
                    {
                        sb.AppendLine(fileData[i]);
                    }
                    _localVersionText = sb.ToString();
                    //解析xml
                    var dom = MonoXmlUtils.GetRootNodeFromString(_localVersionText);
                    dom = dom.Tag != "local_info" ? dom.SearchForChildByTag("local_info") : dom;
                    if (dom != null)
                    {
                        var childs = dom.Children;
                        for (int i = 0; i < childs.Count; i++)
                        {
                            var ch = childs[i] as SecurityElement;
                            if (!string.IsNullOrEmpty(ch.Tag) && !string.IsNullOrEmpty(ch.Text))
                            {
                                _localVersionData[ch.Tag] = ch.Text;
                            }
                        }
                    }
                }
            }
            return _localVersionData;
        }

        /// <summary>
        /// 读取远程版本信息
        /// </summary>
        /// <returns></returns>
        public bool ReLoadRemoteVersionData(string xmlText)
        {
            if (string.IsNullOrEmpty(xmlText))
                return false;
            //解析xml
            var dom = MonoXmlUtils.GetRootNodeFromString(xmlText);
            if (dom != null)
            {
                _remoteVersionData = dom.Tag != "ResourceVersion" ? dom.SearchForChildByTag("ResourceVersion") : dom;
            }
            return _remoteVersionData != null;
        }
        #endregion

    }
}
