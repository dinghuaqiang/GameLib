using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 文件资源的请求文件
    /// </summary>
    public class BundleFileAsynRequest : IFileRequest
    {
        //最大的步数
        private const int CN_MAX_STEP_COUNT = 2;
        //资源Bundle
        private AssetBundleCreateRequest _bundle;
        //文件路径
        private string _filePath = string.Empty;        
        //错误
        private string _error = string.Empty;


        public BundleFileAsynRequest(string filePath, int code)
        {
            _filePath = filePath;
            bool inAndroidPkg = false;
            if (!RequestPathUtil.IsFileExists(_filePath, out _filePath,out inAndroidPkg))
            {
                _error = string.Format("FileAssetsRequest load failed! NOT EXIST File:{0}", _filePath);
                Debug.LogError(_error);
            }
            else
            {
                try
                {  
                    _bundle = AssetBundle.LoadFromFileAsync(_filePath);                    
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                    UnityEngine.Debug.LogException(ex);
                }
            }            
        }

        public float Progress
        {
            get {
                if (_bundle != null)
                {
                    return _bundle.progress;
                }
                return 0;
            }
        }

        public bool IsDone
        {
            get {
                if (_bundle != null)
                {
                    return _bundle.isDone;
                }
                return false;
            }
        }

        public string Error
        {
            get { return _error; }
        }

        public AssetBundle Bundle
        {
            get {
                if (_bundle != null)
                {
                    return _bundle.assetBundle;
                }
                return null;
            }
        }

        public void Dispose()
        {
            if (_bundle != null)
            {
                _bundle = null;
            }
        }

        public object Current
        {
            get {
                if (_bundle != null)
                {
                    return _bundle;
                }
                return null;
            }
        }

        public bool MoveNext()
        {
            if (_bundle != null)
            {
                return !_bundle.isDone;
            }
            return false;
        }

        public void Reset()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            while (!IsDone)
            {
                yield return null;
            }
        }

        public IAssetRequest GetAssetRequest(string requestPath, Type assetType)
        {
            if (Bundle != null)
            {
                requestPath = RequestPathUtil.FixeRequestPath(requestPath);
                return new BundleAssetRequest(Bundle.LoadAsset(requestPath));
            }
            return null;
        }
    }
}
