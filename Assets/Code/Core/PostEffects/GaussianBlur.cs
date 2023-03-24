using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 后处理的高斯模糊
    /// </summary>
    public class GaussianBlur : PostEffectsBase
    {
        public Shader gaussianBlurShader;
        private Material gaussianBlurMaterial = null;

        public Material material
        {
            get
            {
                gaussianBlurMaterial = CheckShaderAndCreateMaterial(gaussianBlurShader, gaussianBlurMaterial);
                return gaussianBlurMaterial;
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

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            //利用两个临时缓存在迭代之间进行交替
            if (material != null)
            {
                int rtW = source.width / downSample;
                int rtH = source.height / downSample;

                //定义buffer0缓存
                RenderTexture buffer0 = RenderTexture.GetTemporary(rtW, rtH, 0);
                buffer0.filterMode = FilterMode.Bilinear;
                //把src的图形缩放后放在buffer0中
                Graphics.Blit(source, buffer0);
                //在执行第一个Pass的时候，输入是buffer0，输出是buffer1，完毕之后先把buffer0释放，
                //再把结果值buffer1存储到buffer0中，重新分配buffer1，然后再调用第二个Pass
                for (int i = 0; i < iterations; i++)
                {
                    material.SetFloat("_BlurSize", 1.0f + i * blurSpread);

                    RenderTexture buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);

                    // Render the vertical pass
                    Graphics.Blit(buffer0, buffer1, material, 0);

                    RenderTexture.ReleaseTemporary(buffer0);
                    buffer0 = buffer1;
                    buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);

                    // Render the horizontal pass
                    Graphics.Blit(buffer0, buffer1, material, 1);

                    RenderTexture.ReleaseTemporary(buffer0);
                    buffer0 = buffer1;
                }
                //上面的迭代完成之后buffer0存储的是最终的图像，再通过Graphics.Blit把结果显示到屏幕上并释放缓存
                Graphics.Blit(buffer0, destination);
                RenderTexture.ReleaseTemporary(buffer0);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
