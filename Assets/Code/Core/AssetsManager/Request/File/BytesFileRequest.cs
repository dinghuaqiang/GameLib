using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace GameLib.Core.Asset
{
    public class BytesFileRequest : IFileRequest
    {
        //最大的步数
        private const int CN_MAX_STEP_COUNT = 2;        
        //文件路径
        private string _filePath = string.Empty;
        //错误
        private string _error = string.Empty;

        //读取的文件内容
        private byte[] _contents = null;

        //文件请求参数
        private object _param = null;

        public BytesFileRequest(string filePath, object param)
        {
            bool inAndroidPkg = false;
            _filePath = filePath;
            _param = param;
            if (!RequestPathUtil.IsFileExists(_filePath, out _filePath,out inAndroidPkg))
            {
                _error = string.Format("FileAssetsRequest load failed! NOT EXIST File:{0}", _filePath);
                UnityEngine.Debug.LogError(_error);
            }
            else
            {
                try
                {
                    //if (inAndroidPkg)如果文件在android包的内部,是不能通过FileStream来进行读取的.   
                    //创建文件读取流
                    using (var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.Seek(0, SeekOrigin.Begin);
                        //创建文件长度缓冲区
                        _contents = new byte[fileStream.Length];
                        //读取文件
                        fileStream.Read(_contents, 0, (int)fileStream.Length);
                    }
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
            get
            {
                return 1f;
            }
        }

        public bool IsDone
        {
            get
            {
                return true;
            }
        }

        public string Error
        {
            get { return _error; }
        }

        public AssetBundle Bundle
        {
            get
            {
                return null;
            }
        }

        public void Dispose()
        {

        }

        public object Current
        {
            get
            {
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
            if (_contents != null)
            {
                IAssetRequest result = null;
                if (assetType == typeof(Texture))
                {
                    result = new ImageAssetRequest(System.IO.Path.GetFileNameWithoutExtension(requestPath), _contents, _param);
                }
                else
                {
                    result = new BytesAssetRequest(System.IO.Path.GetFileNameWithoutExtension(requestPath), _contents, _param);
                }
                _contents = null;
                return result;
            }
            return null;
        }
    }
}
