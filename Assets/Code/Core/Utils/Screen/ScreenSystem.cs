using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 屏幕系统
    /// </summary>
    public class ScreenSystem
    {
        //定义的标准的宽高16:9
        public const int STAND_WIDTH = 1136;
        public const int STAND_HEIGHT = 640;

        //宽高比例
        private static int scaleWidth = 0;
        private static int scaleHeight = 0;

        //是否初始化
        private static bool _isInitialized = false;
        //是否是安卓
        private static bool _isAndroid = false;

        //初始化
        public static void Initialize( bool isAndroid)
        {
            //设置屏幕不可以休眠
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            //记录判断是不是android
            _isAndroid = isAndroid;

            //初始化修改屏幕的大小
            if (!_isInitialized)
            {
                SetMaxDesignContent();
            }
            _isInitialized = true;
        }

        //设置屏幕的设计内容的比率
        //android下面的修改
        public static void SetDesignContentScale()
        {
            if (!_isAndroid) return;
            if (scaleWidth == 0 && scaleHeight == 0)
            {
                int width = Screen.currentResolution.width;
                int height = Screen.currentResolution.height;
                int designWidth = STAND_WIDTH;
                int designHeight = STAND_HEIGHT;
                float designScale = (float)designWidth / (float)designHeight;
                float screenScale = (float)width / (float)height;
                if (designScale < screenScale)
                {
                    designWidth = (int)Mathf.FloorToInt(designHeight * screenScale);
                }
                else if (designScale > screenScale)
                {
                    designHeight = (int)Mathf.FloorToInt(designWidth / screenScale);
                }
                float contentScale = (float)designWidth / (float)width;
                if (contentScale < 1.0f)
                {
                    scaleWidth = designWidth;
                    scaleHeight = designHeight;
                }
            }
            if (scaleWidth > 0 && scaleHeight > 0)
            {
                if (scaleWidth % 2 == 0)
                {
                    scaleWidth += 1;
                }
                else
                {
                    scaleWidth -= 1;
                }
                //切换分辨率
                Screen.SetResolution(scaleWidth, scaleHeight, true);
            }
        }

        //设置屏幕的设计内容的比率
        //android下面的修改
        public static void SetMaxDesignContent()
        {   
            if (!_isAndroid) return;
            var resolutions = Screen.resolutions;
            if (resolutions != null && resolutions.Length > 0)
            {
                //设置为显示器支持的最大分辨率
                var size = resolutions[resolutions.Length - 1];
                Screen.SetResolution(size.width, size.height, true);
            }
        }

        //对不同分辨率的Transform进行适配
        public void ResetTransScaleX(Transform targetTrans)
        {
            if (targetTrans != null)
            {
                //获取设计尺寸的屏幕宽高比/设计比例得到一个缩放倍数，对控件进行缩放
                float designScale = 1.0f * STAND_WIDTH / STAND_HEIGHT;
                //获取当前屏幕实际比例
                float screenScale = 1.0f * Screen.width / Screen.height;
                //需要缩放的尺寸
                float needScale = screenScale / designScale;
                //只对x轴进行缩放
                float scaleX = targetTrans.localScale.x;
                scaleX = scaleX * needScale;
                targetTrans.localScale = new Vector3(scaleX, targetTrans.localScale.y, targetTrans.localScale.z);
            }
        }

        public void ResetTransScale(Transform targetTrans)
        {
            if (targetTrans != null)
            {
                //获取设计尺寸的屏幕宽高比/设计比例得到一个缩放倍数，对控件进行缩放
                float designScale = 1.0f * STAND_WIDTH / STAND_HEIGHT;
                //获取当前屏幕实际比例
                float screenScale = 1.0f * Screen.width / Screen.height;
                //需要缩放的尺寸
                float needScale = screenScale / designScale;
                //对localscale轴进行缩放
                targetTrans.localScale *= needScale;
                //float scaleX = targetTrans.localScale.x;
                //scaleX = scaleX * needScale;
                //float scaleY = targetTrans.localScale.y;
                //scaleY = scaleY * needScale;
                //float scaleZ = targetTrans.localScale.z;
                //scaleZ = scaleZ * needScale;
                //targetTrans.localScale = new Vector3(scaleX, scaleY, scaleZ);
            }
        }

    }
}
