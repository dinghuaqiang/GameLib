using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 后处理
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class PostEffectsBase : MonoBehaviour
    {
        #region 变量
        protected bool IsSupportHDRTextures = true;
        protected bool IsSupportDX11 = false;
        protected bool IsSupported = true;
        private List<Material> _createdMaterials = null;
        #endregion

        #region 生命周期处理
        private void Awake()
        {
            _createdMaterials = new List<Material>();
        }

        private void OnEnable()
        {
            IsSupported = true;
        }

        private void Start()
        {
            IsSupportHDRTextures = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
            CheckResources();
        }

        private void OnDestroy()
        {
            RemoveCreatedMaterials();
            OnDestroyAfter();
        }

        private void RemoveCreatedMaterials()
        {
            while (_createdMaterials.Count > 0)
            {
                Material mat = _createdMaterials[0];
                _createdMaterials.RemoveAt(0);
#if UNITY_EDITOR
                DestroyImmediate(mat);
#else
                Destroy(mat);
#endif
            }
        }
        #endregion

        #region 保护函数
        /// <summary>
        /// 检查材质，没有材质的话就根据Shader创建一个出来
        /// 每个屏幕后处理效果通常都需要指定一个Shader来创建一个用于处理渲染纹理的材质
        /// </summary>
        /// <param name="shader">该特效需要使用的Shader</param>
        /// <param name="material">用于后处理的材质</param>
        /// <returns></returns>
        protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
        {
            if (shader == null)
            {
                Debug.Log("Missing shader in " + ToString());
                enabled = false;
                return null;
            }

            if (shader.isSupported && material && material.shader == shader)
                return material;

            if (!shader.isSupported)
            {
                NotSupported();
                Debug.Log("The shader " + shader.ToString() + " on effect " + ToString() + " is not supported on this platform!");
                return null;
            }
            else
            {
                material = new Material(shader);
                material.hideFlags = HideFlags.DontSave;
                _createdMaterials.Add(material);
                if (material)
                    return material;
                else
                    return null;
            }
        }

        protected Material CreateMaterial(Shader shader, Material createMat)
        {
            if (!shader)
            {
                Debug.Log("Missing shader in " + ToString());
                return null;
            }

            if (createMat && (createMat.shader == shader) && (shader.isSupported))
                return createMat;

            if (!shader.isSupported)
            {
                return null;
            }

            createMat = new Material(shader);
            _createdMaterials.Add(createMat);
            createMat.hideFlags = HideFlags.DontSave;

            return createMat;
        }

        protected void DrawBorder(RenderTexture dest, Material material)
        {
            float x1;
            float x2;
            float y1;
            float y2;

            RenderTexture.active = dest;
            bool invertY = true; // source.texelSize.y < 0.0ff;
            // Set up the simple Matrix
            GL.PushMatrix();
            GL.LoadOrtho();

            for (int i = 0; i < material.passCount; i++)
            {
                material.SetPass(i);

                float y1_; float y2_;
                if (invertY)
                {
                    y1_ = 1.0f; y2_ = 0.0f;
                }
                else
                {
                    y1_ = 0.0f; y2_ = 1.0f;
                }

                // left
                x1 = 0.0f;
                x2 = 0.0f + 1.0f / (dest.width * 1.0f);
                y1 = 0.0f;
                y2 = 1.0f;
                GL.Begin(GL.QUADS);

                GL.TexCoord2(0.0f, y1_); GL.Vertex3(x1, y1, 0.1f);
                GL.TexCoord2(1.0f, y1_); GL.Vertex3(x2, y1, 0.1f);
                GL.TexCoord2(1.0f, y2_); GL.Vertex3(x2, y2, 0.1f);
                GL.TexCoord2(0.0f, y2_); GL.Vertex3(x1, y2, 0.1f);

                // right
                x1 = 1.0f - 1.0f / (dest.width * 1.0f);
                x2 = 1.0f;
                y1 = 0.0f;
                y2 = 1.0f;

                GL.TexCoord2(0.0f, y1_); GL.Vertex3(x1, y1, 0.1f);
                GL.TexCoord2(1.0f, y1_); GL.Vertex3(x2, y1, 0.1f);
                GL.TexCoord2(1.0f, y2_); GL.Vertex3(x2, y2, 0.1f);
                GL.TexCoord2(0.0f, y2_); GL.Vertex3(x1, y2, 0.1f);

                // top
                x1 = 0.0f;
                x2 = 1.0f;
                y1 = 0.0f;
                y2 = 0.0f + 1.0f / (dest.height * 1.0f);

                GL.TexCoord2(0.0f, y1_); GL.Vertex3(x1, y1, 0.1f);
                GL.TexCoord2(1.0f, y1_); GL.Vertex3(x2, y1, 0.1f);
                GL.TexCoord2(1.0f, y2_); GL.Vertex3(x2, y2, 0.1f);
                GL.TexCoord2(0.0f, y2_); GL.Vertex3(x1, y2, 0.1f);

                // bottom
                x1 = 0.0f;
                x2 = 1.0f;
                y1 = 1.0f - 1.0f / (dest.height * 1.0f);
                y2 = 1.0f;

                GL.TexCoord2(0.0f, y1_); GL.Vertex3(x1, y1, 0.1f);
                GL.TexCoord2(1.0f, y1_); GL.Vertex3(x2, y1, 0.1f);
                GL.TexCoord2(1.0f, y2_); GL.Vertex3(x2, y2, 0.1f);
                GL.TexCoord2(0.0f, y2_); GL.Vertex3(x1, y2, 0.1f);

                GL.End();
            }

            GL.PopMatrix();
        }

        protected void ReportAutoDisable()
        {
            Debug.LogWarning("The image effect " + ToString() + " has been disabled as it's not supported on the current platform.");
        }
        #endregion

        #region 子类可重写的函数
        public virtual bool CheckResources()
        {
            Debug.LogWarning("CheckResources () for " + ToString() + " should be overwritten.");
            return IsSupported;
        }

        protected virtual void OnDestroyAfter()
        {

        }
        #endregion

        #region 支持平台的判断函数
        public bool Dx11Support()
        {
            return IsSupportDX11;
        }

        protected bool CheckSupport()
        {
            return CheckSupport(false);
        }

        protected bool CheckSupport(bool needDepth)
        {
            IsSupported = true;
            IsSupportDX11 = SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders;

            if (!SystemInfo.supportsImageEffects)
            {
                NotSupported();
                return false;
            }

            if (needDepth && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
            {
                NotSupported();
                return false;
            }

            if (needDepth)
                GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;

            return true;
        }

        protected bool CheckSupport(bool needDepth, bool needHdr)
        {
            if (!CheckSupport(needDepth))
                return false;

            if (needHdr && !IsSupportHDRTextures)
            {
                NotSupported();
                return false;
            }

            return true;
        }

        private void NotSupported()
        {
            enabled = false;
            IsSupported = false;
        }
        #endregion
    }
}
