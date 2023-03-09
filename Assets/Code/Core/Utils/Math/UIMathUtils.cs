using System.Numerics;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// UI处理用到的一些数学库
    /// </summary>
    public class UIMathUtils
    {
        /// <summary>
        /// 根据屏幕的宽高比,以图片高为基准对图片宽度进行比例切割
        /// </summary>
        /// <param name="ImageW"></param>
        /// <param name="ImageH"></param>
        /// <returns>图片宽度被剪切后的比例</returns>
        public static float GetWidthClipScale(float ImageW, float ImageH, float ScreenW, int ScreenH)
        {
            float wfactor = (ScreenW * ImageH) / (ScreenH * ImageW);
            return wfactor > 1 ? 1f : wfactor;
        }

        /// <summary>
        /// 根据原始图片的宽度,以及分割后中间重叠的长度,获取图片在屏幕上的重叠长度,关于如何切割请看示例在本类的最后.
        /// </summary>
        /// <param name="OrgImageW">原始图片的长度</param>
        /// <param name="ImageOverlapLen">图片分割后中间重叠的长度</param>
        /// <param name="ScreenW">屏幕的宽度</param>
        /// <param name="Wfactor">图片宽度被剪切后的比例</param>
        /// <returns></returns>
        public static float GetScreenOverlapLen(float OrgImageW, float ImageOverlapLen, float ScreenW, float Wfactor)
        {
            return ((ScreenW * ImageOverlapLen)) / ((OrgImageW * Wfactor));
        }

        /// <summary>
        /// 根据原始图片的宽度和子图片的宽度,以及原始图片被剪切的比例,来获得两个两个部分的偏移和缩放 ,关于如何切割请看示例在本类的最后.
        /// 注意:这里的计算图片的偏移和剪切都是以原始图片中心点为锚点的.
        /// </summary>
        /// <param name="OrgImageW"></param>
        /// <param name="PartImageW"></param>
        /// <param name="Wfactor"></param>
        /// <returns></returns>
        public static Vector4 GetPartWRect(float OrgImageW, float PartImageW, float Wfactor)
        {
            //首先计算左边图片的偏移比例
            float leftOffset = OrgImageW * (1 - Wfactor) * 0.5f / PartImageW;
            //左边展示的宽度比例
            float leftClipScale = 1 - leftOffset;
            //右边图片的偏移比例
            float rightOffset = 0f;
            //右边图片的宽度比例
            float rightClipScale = leftClipScale;
            return new Vector4(leftOffset, leftClipScale, rightOffset, rightClipScale);
        }



        /*
         * 这个示例中:
         * 原始图片宽度:   OrgImageW : 1984
         * 切割后的宽度:   ImageW:1024
         * 重叠部分的宽度: ImageOverlapLen:64
         * 
            |<--------1984-------->|
            |----------------------|
            |		   	  		   |
            |		      		   |
            |		   	  		   |
            |----------------------|

            |<---1024--->|
            |---------|--|---------|
            |		  |	 |	       |
            |		  |  |		   |
            |		  |	 |		   |
            |---------|--|---------|
		              |<---1024--->|
                      |64|  
         */
    }
}
