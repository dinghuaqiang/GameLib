using System;
using System.Collections;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源文件请求
    /// </summary>
    public class ResourceFileRequest : IFileRequest
    {
        //返回Bundle,因为是Resource所以返回为null
        public AssetBundle Bundle
        {
            get
            {
                return null;
            }
        }

        public object Current
        {
            get
            {
                return null;
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public bool IsDone
        {
            get
            {
                return true;
            }
        }

        public float Progress
        {
            get
            {
                return 1;
            }
        }

        public void Dispose()
        {
            
        }

        public IAssetRequest GetAssetRequest(string requestPath, Type assetType)
        {
            var idx = requestPath.LastIndexOf('.');
            if (idx >= 0)
            {
                requestPath = requestPath.Substring(0, idx);
            }
            var request = Resources.LoadAsync(requestPath);//, assetType);
            if (request != null)
            {
                return new ResourceAssetRequest(request);
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            yield return null;
        }

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
            
        }
    }
}
