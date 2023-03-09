namespace GameLib.Core.Asset
{
    /// <summary>
    /// 从Bundle中请求资源Asset
    /// </summary>
    public class BundleAssetRequest : IAssetRequest
    {
        //通过Bundle中获取资源的异步请求
        private UnityEngine.AssetBundleRequest _request;
        private UnityEngine.Object _asset;
        private bool _isDone;

        public UnityEngine.Object Asset
        {
            get
            {
                if (_request == null)
                    return _asset;
                return _request.asset;
            }
        }

        public bool IsDone
        {
            get
            {
                if (_request == null)
                    return _isDone;
                return _request.isDone;
            }
        }

        public float Progress
        {
            get
            {
                if (_asset == null)
                    return 1f;
                return _request.progress;
            }
        }

        //构造函数
        public BundleAssetRequest(UnityEngine.AssetBundleRequest request)
        {
            _request = request;
        }

        public BundleAssetRequest(UnityEngine.Object obj)
        {
            _asset = obj;
            _isDone = true;
        }
    }
}
