using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 根据深度图做运动模糊
    /// </summary>
    public class MotionBlurWithDepthTexture : PostEffectsBase
    {
        private Material _motionBlurMat = null;
        private Camera _camera;
        /// <summary>
        /// 保存上一帧摄像机的视角*投影矩阵
        /// </summary>
        private Matrix4x4 _previousViewProjectionMatrix;

        public Shader MotionBlurShader;
        /// <summary>
        /// 运动模糊时模糊图像使用的大小
        /// </summary>
        [Range(0.0f, 1.0f)]
        public float BlurSize = 0.5f;

        public Material MotionBlurMaterial
        {
            get
            {
                _motionBlurMat = CheckShaderAndCreateMaterial(MotionBlurShader, _motionBlurMat);
                return _motionBlurMat;
            }
        }

        public Camera Camera
        {
            get
            {
                if (_camera == null)
                {
                    _camera = GetComponent<Camera>();
                }
                return _camera;
            }
        }

        private void OnEnable()
        {
            //设置摄像机的状态，方便获取摄像机的深度纹理
            Camera.depthTextureMode |= DepthTextureMode.Depth;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (MotionBlurMaterial != null)
            {
                MotionBlurMaterial.SetFloat("_BlurSize", BlurSize);
                MotionBlurMaterial.SetMatrix("_PreviousViewProjectionMatrix", _previousViewProjectionMatrix);

                //前一帧的视角 * 投影矩阵，当前的视角矩阵和投影矩阵
                Matrix4x4 curViewProjectionMatrix = Camera.projectionMatrix * Camera.worldToCameraMatrix;
                //对当前的视角矩阵和投影矩阵相称后取逆得到当前帧的视角 * 投影矩阵的逆矩阵
                Matrix4x4 curViewProjectionInverseMatrix = curViewProjectionMatrix.inverse;
                //把矩阵传递给材质
                MotionBlurMaterial.SetMatrix("_CurViewProjectionInverseMatrix", curViewProjectionInverseMatrix);
                //下一帧的时候传递给材质
                _previousViewProjectionMatrix = curViewProjectionInverseMatrix;

                Graphics.Blit(source, destination, MotionBlurMaterial);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
