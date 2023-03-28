using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 利用深度纹理和深度法线图做边缘检测
    /// </summary>
    public class EdgeDetectNormalsAndDepth : PostEffectsBase
    {
        public Shader EdgeDetectShader;

        private Material _edgeDetectMaterial = null;


        public Material EdgeDetectMaterial
        {
            get
            {
                if (_edgeDetectMaterial == null)
                {
                    _edgeDetectMaterial = CheckShaderAndCreateMaterial(EdgeDetectShader, _edgeDetectMaterial);
                }
                return _edgeDetectMaterial;
            }
        }

        /// <summary>
        /// 边缘强度
        /// </summary>
        [Range(0f, 1.0f)]
        public float EdgesOnly = 0f;
        /// <summary>
        /// 描边颜色
        /// </summary>
        public Color EdgeColor = Color.black;
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BackgroundColor = Color.white;
        /// <summary>
        /// 采样距离，用于控制对深度+法线纹理采样时使用的采样距离。
        /// </summary>
        public float SampleDistance = 1.0f;
        /// <summary>
        /// 灵敏度参数，SensitivityDepth和SensitivityNormals会影响当邻域的深度值或法线值相差多少时，会被认为存在一条边界。
        /// 如果把灵敏度调得很大，那么可能即使是深度或法线上很小的变化也会形成一条边。
        /// </summary>
        public float SensitivityDepth = 1.0f;
        public float SensitivityNormals = 1.0f;


        private void OnEnable()
        {
            Camera camera = GetComponent<Camera>();
            if (camera != null)
            {
                camera.depthTextureMode |= DepthTextureMode.DepthNormals;
            }
        }

        /// <summary>
        /// ImageEffectOpaque属性，默认情况下，OnRenderImage会在所有的不透明和透明的Pass执行完毕后被调用，以便对场景中所有游戏对象都产生影响。
        /// 这里希望在不透明的Pass执行完毕后立即调用OnRenderImage，而不对透明物体产生影响。
        /// 只希望对不透明物体进行描边，不希望透明物体也被描边，这里加上了ImageEffectOpaque属性
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        [ImageEffectOpaque]
        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (EdgeDetectMaterial != null)
            {
                EdgeDetectMaterial.SetFloat("_EdgeOnly", EdgesOnly);
                EdgeDetectMaterial.SetColor("_EdgeColor", EdgeColor);
                EdgeDetectMaterial.SetColor("_BackgroundColor", BackgroundColor);
                EdgeDetectMaterial.SetFloat("_SampleDistance", SampleDistance);
                Vector4 sensitivity = new Vector4(SensitivityNormals, SensitivityDepth, 0f, 0f);
                EdgeDetectMaterial.SetVector("_Sensitivity", sensitivity);

                Graphics.Blit(source, destination, EdgeDetectMaterial);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
