using GameLib.Core.Base;
using GameLib.Core.Utils;
using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 文件的信息类
    /// </summary>
    public class FileEntity
    {
        //静态的最大ID
        private static int MaxID = 0;

        //文件扩展名
        private AssetTypeCode _assetType = AssetTypeCode.None;
        //资源类型
        private Type _objectType = null;

        private AssetsRequestTypeCode _fileRequestCode = AssetsRequestTypeCode.Resource;

        //ID,唯一表示一个FileClass
        public int ID { get; private set; }
        //相对路径
        //Texture/UI/abc
        //Texture/UI/abc.jpg
        public string RequestPath { get; private set; }

        //资源全路径fullPath, 扩展名为.unity3d
        //file://..../assets/GameAssets/Resources/Texture/UI/abc.unity3d
        public string AssetsPath { get; set; }

        //获取资源路径,相对路径,从GameAssets起
        //比如:GameAssets/Resources/Texture/UI/abc.unity3d
        public string GameAssetsPath { get; set; }

        //经过后台更新后的状态码，参见CodeDefine.RET_BACKDOWNLOADxxx
        /*
         *        
            /// <summary>
            /// 已经存在
            /// </summary>
            public const int RET_BACKDOWNLOAD_ALREADYEXIST = 1;

            /// <summary>
            /// 后台更新，当个文件下载成功
            /// </summary>
            public const int RET_BACKDOWNLOAD_SUCCESS = 0;
     
            /// <summary>
            /// http下载失败，包括MD5校验失败
            /// </summary>
            public const int RET_BACKDOWNLOAD_HTTPFAIL = -1;
            /// <summary>
            /// 因暂停跳过
            /// </summary>
            public const int RET_BACKDOWNLOAD_SKIPBYPAUSE = -2;
            /// <summary>
            /// 无效请求，map中不存在这个文件
            /// </summary>
            public const int RET_BACKDOWNLOAD_INVALIDFILE = -3;
        */
        public int ErrorCode { get; set; }

        //完成后的的回调
        public GAction<Object, AssetBundle, AsstesRetCode> FinishedCallBack { get; private set; }

        //最终需要的结果类型:Object,Bundle,Scene,UI
        public AsyncActionType ResultType { get; private set; }

        //忽略正在加载 -- True:如果正在加载中,那么就直接返回,Flase:如果正在加载把回调加到正在加载的资源上
        public bool IgnoreLoading { get; private set; }

        //是否卸载Bundle
        public bool WillUnloadBundle { get; private set; }

        //参数
        public object Param { get; private set; }

        //当前请求的版本信息Code值
        public int VersionCode { get; set; }

        //资源的类型
        public Type ObjectType
        {
            get
            {
                if (_objectType == null)
                {
                    _objectType = GetObjectType(_assetType);
                }
                return _objectType;
            }
        }
        //是否从流中读取资源
        public AssetsRequestTypeCode FileRequestCode
        {
            get
            {
                return _fileRequestCode;
            }
        }



        //是否同步加载
        public bool IsSyncLoad
        {
            get
            {
                return FileRequestCode >= AssetsRequestTypeCode.BundleFile;
            }
        }

        //构造函数
        public FileEntity(string requestPath, AssetTypeCode assetType, GAction<Object, AssetBundle, AsstesRetCode> callBack, AsyncActionType resultType, bool ignoreLoading = true, object param = null, AssetsRequestTypeCode fileTypeCode = AssetsRequestTypeCode.Resource)
        {
            ID = MaxID++;
            RequestPath = requestPath;
            FinishedCallBack = callBack;
            ResultType = resultType;
            IgnoreLoading = ignoreLoading;
            Param = param;
            WillUnloadBundle = ResultType == AsyncActionType.LoadObject;
            VersionCode = 0;
            ErrorCode = 0;
            _assetType = assetType;
            _fileRequestCode = CorrectionFileTypeCode(fileTypeCode);
            RebuildAssetsPath(_fileRequestCode);

        }


        //判断FileClasses是否存在
        public bool Exists()
        {
            if (!File.Exists(AssetsPath))
            {
                FLogger.LogError(string.Format("FileClasses:Exist(FileClasses):{0} not exist!", AssetsPath));
                return false;
            }
            return true;
        }

        //获取资源的类型
        public static Type GetObjectType(AssetTypeCode assetType)
        {
            switch (assetType)
            {
                case AssetTypeCode.Prefab:
                    return typeof(GameObject);
                case AssetTypeCode.Texture:
                    return typeof(Texture);
                case AssetTypeCode.AudioClip:
                    return typeof(AudioClip);
                case AssetTypeCode.AnimationClip:
                    return typeof(AnimationClip);
                default:
                    return typeof(UnityEngine.Object);
            }
        }



        /// <summary>
        /// 重建AssetPath
        /// </summary>
        /// <param name="requestCode"></param>
        private void RebuildAssetsPath(AssetsRequestTypeCode requestCode)
        {
            //AssetsPath = AssetUtils.GetAssetsPath(RequestPath, requestCode);
            //GameAssetsPath = AssetUtils.GetGameAssetsPath(RequestPath, requestCode);
        }

        /// <summary>
        /// 修正文件请求类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private AssetsRequestTypeCode CorrectionFileTypeCode(AssetsRequestTypeCode value)
        {
            if (PathUtils.IsStreaming())
            {
                if (value == AssetsRequestTypeCode.Resource)
                {
                    return AssetsRequestTypeCode.WWW;
                }
                else
                {
                    return value;
                }
            }
            else
            {//如果不是Stream的文件路径,那么就除了个别类型,统统修改为Resource的请求
                if (value == AssetsRequestTypeCode.BytesFile || value == AssetsRequestTypeCode.EnableWriteBytesFile)
                {
                    return value;
                }
                else
                {
                    return AssetsRequestTypeCode.Resource;
                }
            }

        }
    }
}
