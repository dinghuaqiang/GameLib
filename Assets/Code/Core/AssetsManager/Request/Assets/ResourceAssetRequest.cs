using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 通过Resource来获取Asset的请求
    /// </summary>
    public class ResourceAssetRequest : IAssetRequest
    {
        //Resource的异步请求
        private ResourceRequest _request;

        public UnityEngine.Object Asset
        {
            get
            {
                return _request.asset;
            }
        }

        public bool IsDone
        {
            get
            {
                return _request.isDone;
            }
        }

        public float Progress
        {
            get
            {
                return _request.progress;
            }
        }

        //构造函数
        public ResourceAssetRequest(ResourceRequest request)
        {
            _request = request;
        }
    }
}
