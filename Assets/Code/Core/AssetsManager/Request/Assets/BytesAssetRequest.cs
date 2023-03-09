namespace GameLib.Core.Asset
{
    /// <summary>
    /// 二进制资源请求
    /// </summary>
    public class BytesAssetRequest : IAssetRequest
    {
        private BytesAsset _asset;

        public UnityEngine.Object Asset
        {
            get
            {
                return _asset;
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
                return 1f;
            }
        }

        public BytesAssetRequest(string name,byte[] bytes, object param)
        {
            _asset = new BytesAsset(name, bytes,param);
        }
    }

    public class BytesAsset : UnityEngine.Object
    {
        public byte[] Contents { get; }
        public object Param { get; }

        internal BytesAsset(string assetName, byte[] content, object param) : base()
        {
            name = assetName;
            Contents = content;
            Param = param;
        }
    }
}
