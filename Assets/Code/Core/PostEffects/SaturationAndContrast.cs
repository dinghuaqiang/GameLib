using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 后处理提亮度和对比度
    /// 需要搭配Shader   SaturationAndContrast使用
    /// </summary>
    public class SaturationAndContrast : PostEffectsBase
    {
        public Shader briSatConShader;
        private Material briSatConMaterial;
        public Material material
        {
            get
            {
                briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
                return briSatConMaterial;
            }
        }

        /// <summary>
        /// 亮度
        /// </summary>
        [Range(0.0f, 3.0f)]
        public float brightness = 1.0f;

        /// <summary>
        /// 饱和度
        /// </summary>
        [Range(0.0f, 3.0f)]
        public float saturation = 1.0f;

        /// <summary>
        /// 对比度
        /// </summary>
        [Range(0.0f, 3.0f)]
        public float contrast = 1.0f;

        /// <summary>
        /// 在整个屏幕渲染完以后(也就是在不透明和透明物体之后都渲染完以后)调用
        /// </summary>
        /// <param name="src">表示当前屏幕纹理或者上一步处理后得到的渲染纹理</param>
        /// <param name="dest">表示目标渲染纹理，如果他的值为null，那么就会直接将处理后的纹理渲染到屏幕上面</param>
        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            if (material != null)
            {
                material.SetFloat("_Brightness", brightness);
                material.SetFloat("_Saturation", saturation);
                material.SetFloat("_Contrast", contrast);
                UnityEngine.Graphics.Blit(src, dest, material);
            }
            else
            {
                UnityEngine.Graphics.Blit(src, dest);
            }
        }
    }
}
