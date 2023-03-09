using System;
using System.Collections;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 文件资源的请求文件
    /// </summary>
    public class BundleFileRequest : IFileRequest
    {
        //最大的步数
        private const int CN_MAX_STEP_COUNT = 2;
        //资源Bundle
        private AssetBundle _bundle;
        //文件路径
        private string _filePath = string.Empty;        
        //错误
        private string _error = string.Empty;


        public BundleFileRequest(string filePath)
        {
            _filePath = filePath;
            bool inAndroidPkg = false;
            if (!RequestPathUtil.IsFileExists(_filePath, out _filePath,out inAndroidPkg))
            {
                _error = string.Format("BundleFileRequest load failed! NOT EXIST File:{0}", _filePath);
                Debug.LogError(_error);
            }
            else
            {
                try
                {   
                    
                    var version = AssetsCacheManager.GetFileVersion(filePath);                    
                    _bundle = AssetBundle.LoadFromFile(_filePath);                
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
                return 1f;
            }
        }

        public bool IsDone
        {
            get {
                return true;
            }
        }

        public string Error
        {
            get { return _error; }
        }

        public AssetBundle Bundle
        {
            get {
                return _bundle; 
            }
        }

        public void Dispose()
        {
            
        }

        public object Current
        {
            get {
                return null;
            }
        }

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            yield return null;
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
