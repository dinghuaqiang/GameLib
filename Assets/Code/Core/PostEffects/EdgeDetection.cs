using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 后处理的边缘检测
    /// 挂载到相机下
    /// 需要搭配Shader  EdgeDetection使用
    /// </summary>
    public class EdgeDetection : PostEffectsBase
    {
        /// <summary>
        /// 边缘检测的Shader
        /// </summary>
        public Shader _edgeDetectionShader = null;
        /// <summary>
        /// 对应的材质
        /// </summary>
        private Material edgeDetectionMat;
        public Material material
        {
            get
            {
                edgeDetectionMat = CheckShaderAndCreateMaterial(_edgeDetectionShader, edgeDetectionMat);
                return edgeDetectionMat;
            }
        }

        /// <summary>
        /// 边缘线强度
        /// </summary>
        [Range(0.0f, 1.0f)]
        public float _edgesOnly = 0.0f;

        /// <summary>
        /// 边缘颜色
        /// </summary>
        public Color _edgeColor = Color.red;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color _backgroundColor = Color.white;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (material != null)
            {
                material.SetFloat("_EdgeOnly", _edgesOnly);
                material.SetColor("_EdgeColor", _edgeColor);
                material.SetColor("_BackgroundColor", _backgroundColor);
                UnityEngine.Graphics.Blit(source, destination, material);
            }
            else
            {
                UnityEngine.Graphics.Blit(source, destination);
            }
        }
    }
}
