using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 图片资源请求
    /// </summary>
    public class ImageAssetRequest : IAssetRequest
    {
        private Texture2D _tex = null;

        public UnityEngine.Object Asset
        {
            get
            {
                return _tex;
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

        public ImageAssetRequest(string name,byte[] bytes, object param)
        {
            int w, h;
            w = h = 256;
            var val = param as object[];
            if (val != null && val.Length >= 2)
            {
                w = (int)val[0];
                h = (int)val[1];
            }
            _tex = new Texture2D(w, h);
            _tex.name = name;
            _tex.LoadImage(bytes);
        }
    }
}
