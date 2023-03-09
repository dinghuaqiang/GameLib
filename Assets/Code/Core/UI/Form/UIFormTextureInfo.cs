using GameLib.Core.Asset;
using GameLib.Core.Base;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 用来缓存的图片实例
    /// </summary>
    public class UIFormTextureInfo
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string TexPath = string.Empty;

        /// <summary>
        /// 加载完成的回调
        /// </summary>
        public GAction<TextureInfo> CallBack = null;

        /// <summary>
        /// 保存当前加载出来的图片
        /// </summary>
        public TextureInfo TextureInfo = null;
    }
}
