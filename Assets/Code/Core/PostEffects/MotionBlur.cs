using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 运动模糊
    /// </summary>
    public class MotionBlur : PostEffectsBase
    {
        public Shader _motionBlurShader;
        private Material _motionBlurMat;
        private Material material
        {
            get
            {
                _motionBlurMat = CheckShaderAndCreateMaterial(_motionBlurShader, _motionBlurMat);
                return _motionBlurMat;
            }
        }

        /// <summary>
        /// 运动模糊在混合图像时的模糊参数
        /// 为了防止拖尾效果完全替代当前帧的渲染结果，把值限定在0-0.9
        /// </summary>
        [Range(0.0f, 0.9f)]
        public float BlurAmount = 0.5f;

        /// <summary>
        /// 保存之前图像叠加的结果
        /// </summary>
        private RenderTexture _accumulationTex;

        private void OnDisable()
        {
            //在每次应用运动模糊的时候重新叠加图像，所以在每次关闭的时候销毁掉之前的叠加结果
            DestroyImmediate(_accumulationTex);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (material != null)
            {
                if (_accumulationTex == null || _accumulationTex.width != source.width || _accumulationTex.height != source.height)
                {
                    DestroyImmediate(_accumulationTex);
                    _accumulationTex = new RenderTexture(source.width, source.height, 0);
                    //不会保存到Hierarchy中，也不会保存到场景中
                    _accumulationTex.hideFlags = HideFlags.HideAndDontSave;
                    //将一张纹理绘制到另一张纹理中。而在此方法中可以指定一种材质来实现特殊的效果
                    Graphics.Blit(source, _accumulationTex);
                }
                //标记需要进行渲染纹理的恢复操作
                _accumulationTex.MarkRestoreExpected();

                material.SetFloat("_BlurAmount", 1.0f - BlurAmount);

                //把当前的屏幕图像source叠加到_accumulationTex
                Graphics.Blit(source, _accumulationTex, material);
                //把结果显示到屏幕上
                Graphics.Blit(_accumulationTex, destination);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
