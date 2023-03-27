using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// Bloom效果
    /// </summary>
    public class Bloom : PostEffectsBase
    {
        public Shader bloomShader;
        private Material bloomMaterial = null;

        public Material material
        {
            get
            {
                bloomMaterial = CheckShaderAndCreateMaterial(bloomShader, bloomMaterial);
                return bloomMaterial;
            }
        }

        /// <summary>
        /// 调整高斯模糊迭代次数，模糊范围和缩放系数
        /// </summary>
        [Range(0, 4)]
        public int iterations = 3;

        /// <summary>
        /// 在高斯核维数不变的情况下，blursize越大，模糊程度越高，但是采样数不会受影响
        /// </summary>
        [Range(0.2f, 3.0f)]
        public float blurSpread = 0.6f;

        /// <summary>
        /// 值越大，需要处理的像素越少，也能进一步提高模糊程度，这个数值太大的话可能会让图形像素化
        /// </summary>
        [Range(1, 8)]
        public int downSample = 2;

        /// <summary>
        /// 亮度阈值，控制较亮区域时使用的阈值大小
        /// 绝大多数情况下，图像的亮度值不会超过1.如果开启了HDR，硬件会允许把颜色值存储在一个更高精度范围的缓冲，此时像素的亮度值可能就会超过1.
        /// 所以这里把值限定在0-4
        /// </summary>
        [Range(0.0f, 4.0f)]
        public float luminanceThreshold = 0.6f;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            //利用两个临时缓存在迭代之间进行交替
            if (material != null)
            {
                material.SetFloat("_LuminanceThreshold", luminanceThreshold);

                int rtW = source.width / downSample;
                int rtH = source.height / downSample;

                //定义buffer0缓存
                RenderTexture buffer0 = RenderTexture.GetTemporary(rtW, rtH, 0);
                buffer0.filterMode = FilterMode.Bilinear;
                //使用Shader的第一个Pass提取图像中较亮的区域，将提取到的较亮的区域存储在buffer0中
                Graphics.Blit(source, buffer0, material, 0);

                for (int i = 0; i < iterations; i++)
                {
                    material.SetFloat("_BlurSize", 1.0f + i * blurSpread);

                    RenderTexture buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);

                    // Render the vertical pass
                    Graphics.Blit(buffer0, buffer1, material, 1);

                    RenderTexture.ReleaseTemporary(buffer0);
                    buffer0 = buffer1;
                    buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);

                    // Render the horizontal pass
                    Graphics.Blit(buffer0, buffer1, material, 2);

                    RenderTexture.ReleaseTemporary(buffer0);
                    buffer0 = buffer1;
                }
                //将模糊后较亮区域存储在了buffer0中，再传递给材质中的_Bloom纹理属性
                material.SetTexture("_Bloom", buffer0);
                //使用第4个Pass来进行最后的混合，并将结果存储在目标渲染纹理destination中
                Graphics.Blit(source, destination, material, 3);
                //释放临时内存
                RenderTexture.ReleaseTemporary(buffer0);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
