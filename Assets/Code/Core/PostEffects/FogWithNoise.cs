using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 根据噪音图控制雾
    /// </summary>
    public class FogWithNoise : PostEffectsBase
    {
        public Shader FogShader;
        private Material _fogMaterial;

        /// <summary>
        /// 雾的浓度
        /// </summary>
        [Range(0.0f, 3.0f)]
        public float FogDensity = 1.0f;

        /// <summary>
        /// 雾的颜色
        /// </summary>
        public Color FogColor = Color.white;

        /// <summary>
        /// 雾的起始高度
        /// </summary>
        public float FogStart = 0f;

        /// <summary>
        /// 雾的终止高度
        /// </summary>
        public float FogEnd = 2.0f;

        /// <summary>
        /// 模拟雾飘动的噪声图
        /// </summary>
        public Texture NoiseTex;

        /// <summary>
        /// 噪声图在水平和垂直方向上的移动速度，模拟雾的飘动效果。
        /// </summary>
        [Range(-0.5f, 0.5f)]
        public float FogXSpeed = 0.1f;

        [Range(-0.5f, 0.5f)]
        public float FogYSpeed = 0.1f;

        /// <summary>
        /// 控制噪声程度，为0时，表示不应用任何噪声，就是一个均匀的基于高度的全局雾效。
        /// </summary>
        [Range(0.0f, 3.0f)]
        public float NoiseAmount = 1.0f;

        public Material FogMaterial
        {
            get
            {
                _fogMaterial = CheckShaderAndCreateMaterial(FogShader, _fogMaterial);
                return _fogMaterial;
            }
        }
        private Camera _fogCamera = null;
        public Camera FogCamera
        {
            get
            {
                if (_fogCamera == null)
                {
                    _fogCamera = GetComponent<Camera>();
                }
                return _fogCamera;
            }
        }

        private Transform _fogCameraTrans = null;
        public Transform FogCameraTrans
        {
            get
            {
                if (_fogCameraTrans == null && FogCamera != null)
                {
                    _fogCameraTrans = FogCamera.transform;
                }
                return _fogCameraTrans;
            }
        }

        private void OnEnable()
        {
            FogCamera.depthTextureMode |= DepthTextureMode.Depth;
        }

        private void OnRenderImage(UnityEngine.RenderTexture source, UnityEngine.RenderTexture destination)
        {
            if (FogMaterial != null)
            {
                //近裁剪平面四个角对应的向量
                Matrix4x4 frustumCorners = Matrix4x4.identity;

                float fov = FogCamera.fieldOfView;
                float near = FogCamera.nearClipPlane;
                float aspect = FogCamera.aspect;

                float halfHeight = near * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
                Vector3 toRight = FogCameraTrans.right * halfHeight * aspect;
                Vector3 toTop = FogCameraTrans.up * halfHeight;

                Vector3 topLeft = FogCameraTrans.forward * near + toTop - toRight;
                float scale = topLeft.magnitude / near;

                topLeft.Normalize();
                topLeft *= scale;

                Vector3 topRight = FogCameraTrans.forward * near + toRight + toTop;
                topRight.Normalize();
                topRight *= scale;

                Vector3 bottomLeft = FogCameraTrans.forward * near - toTop - toRight;
                bottomLeft.Normalize();
                bottomLeft *= scale;

                Vector3 bottomRight = FogCameraTrans.forward * near + toRight - toTop;
                bottomRight.Normalize();
                bottomRight *= scale;

                frustumCorners.SetRow(0, bottomLeft);
                frustumCorners.SetRow(1, bottomRight);
                frustumCorners.SetRow(2, topRight);
                frustumCorners.SetRow(3, topLeft);

                FogMaterial.SetMatrix("_FrustumCornersRay", frustumCorners);

                FogMaterial.SetFloat("_FogDensity", FogDensity);
                FogMaterial.SetColor("_FogColor", FogColor);
                FogMaterial.SetFloat("_FogStart", FogStart);
                FogMaterial.SetFloat("_FogEnd", FogEnd);

                //噪声图相关的参数
                FogMaterial.SetTexture("_NoiseTex", NoiseTex);
                FogMaterial.SetFloat("_FogXSpeed", FogXSpeed);
                FogMaterial.SetFloat("_FogYSpeed", FogYSpeed);
                FogMaterial.SetFloat("_NoiseAmount", NoiseAmount);

                Graphics.Blit(source, destination, FogMaterial);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
