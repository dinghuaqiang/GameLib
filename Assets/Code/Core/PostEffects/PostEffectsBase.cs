using UnityEngine;

namespace GameLib.Core.PostEffect
{
    /// <summary>
    /// 后处理
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class PostEffectsBase : MonoBehaviour
    {
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
                return null;
            }

            if (shader.isSupported && material && material.shader == shader)
                return material;

            if (!shader.isSupported)
            {
                return null;
            }
            else
            {
                material = new Material(shader);
                material.hideFlags = HideFlags.DontSave;
                if (material)
                    return material;
                else
                    return null;
            }
        }
    }
}
