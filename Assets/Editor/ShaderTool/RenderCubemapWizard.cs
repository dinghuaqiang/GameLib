using UnityEditor;
using UnityEngine;

/// <summary>
/// 把摄像机观察的到场景写入到Cubemap中去
/// Camera的RenderToCubemap可以把从任意位置观察到的场景图像存储到6张图中，从而创建出该位置上对应的立方体纹理。
/// </summary>
public class RenderCubemapWizard : ScriptableWizard
{
    public Transform renderFromPosition;
    public Cubemap cubemap;

    [MenuItem("ShaderTool/GameObject/创建立方体纹理(Cubemap)")]
    static void RenderCubemap()
    {
        ScriptableWizard.DisplayWizard<RenderCubemapWizard>("Render cubemap", "Render!");
    }

    void OnWizardUpdate()
    {
        helpString = "Select transform to render from and cubemap to render into";
        isValid = (renderFromPosition != null) && (cubemap != null);
    }

    void OnWizardCreate()
    {
        // create temporary camera for rendering
        GameObject go = new GameObject("CubemapCamera");
        go.AddComponent<Camera>();
        // 摄像机位置设置在指定的地方去
        go.transform.position = renderFromPosition.position;
        // 把当前位置观察到的图像渲染到立方体纹理中
        go.GetComponent<Camera>().RenderToCubemap(cubemap);
        // 完事了之后删掉节点
        DestroyImmediate(go);
    }
}
