using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 使用UnityWebRequest来进行请求AssetBundle
    /// </summary>
    public class UnityWebFileRequest : IFileRequest
    {
        //Web请求的对象 
        private UnityWebRequest _request;
        private UnityWebRequestAsyncOperation _reqOp = null;
        private AssetBundle _bundle;
        //错误信息
        private string _error = string.Empty;
        //路径
        private string _requestPath = string.Empty;

        public float Progress
        {
            get {
                if (_request != null)
                {
                    return _request.downloadProgress;
                }
                return 0;
            }
        }

        public bool IsDone {
            get
            {
                if (_request != null)
                {
                    return _request.isDone;
                }
                return false;
            }
        }

        public string Error
        {
            get
            {
                if (_request != null)
                {
                    return _request.error;
                }
                else
                {
                    return _error;
                }
            }
        }

        public AssetBundle Bundle
        {
            get
            {
                if (_request != null && _bundle == null)
                {
                    _bundle = (_request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
                }
                return _bundle;
            }
        }

        public void Dispose()
        {
            if (_request != null)
            {
                _request.Dispose();
                _request = null;
            }
        }

        public object Current
        {
            get
            {
                if (_request != null)
                {
                    return _reqOp;
                }
                return _error;
            }
        }

        public UnityWebFileRequest(string requestPath)
        {
            //这里只判断是否在Android包体内
            bool inAndroidPkg = false;
            bool isExist = RequestPathUtil.IsFileExists(requestPath, out requestPath, out inAndroidPkg);
            _requestPath = requestPath;
            if (isExist)
            {
                //如果不在包体内,增加一个[file://]前缀
                string url = inAndroidPkg ? requestPath : "file://" + requestPath;

                //只有在Android,Iphone,Web,windows下才会读取Cache.
                if (Application.platform == RuntimePlatform.Android
                    || Application.platform == RuntimePlatform.IPhonePlayer
                    || Application.platform == RuntimePlatform.WebGLPlayer
                    || Application.platform == RuntimePlatform.WindowsPlayer
                    )
                {
                    uint version = (uint)AssetsCacheManager.GetFileVersion(_requestPath);
                    _request = UnityWebRequestAssetBundle.GetAssetBundle(url, version, 0);
                }
                else
                {
                    _request = UnityWebRequestAssetBundle.GetAssetBundle(url);
                }
                _reqOp = _request.SendWebRequest();
            }
            else
            {
                _error = string.Format("UnityWebFileRequest load failed! NOT EXIST File:{0}", _requestPath);
            }
        } 

        public IAssetRequest GetAssetRequest(string requestName, Type assetType)
        {
            if (Bundle != null)
            {
                requestName = RequestPathUtil.FixeRequestPath(requestName);
                var bRequest = Bundle.LoadAssetAsync(requestName);
                if (bRequest != null)
                {
                    return new BundleAssetRequest(bRequest);
                }
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            yield return _reqOp;
        }

        public bool MoveNext()
        {
            if (_request != null)
            {
                return !_request.isDone;
            }
            return false;
        }

        public void Reset()
        {
           
        }
    }
}
