namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader的属性类型 
    /// 对应UnityEditor.ShaderUtil.ShaderPropertyType枚举类
    /// </summary>
    public enum ShaderPropertyType
    {
        //没有类型
        None = -1,
        //颜色
        Color = 0,
        //四元值
        Vector = 1,
        //float值
        Float = 2,
        //区间--float
        Range = 3,
        //纹理
        TexEnv = 4
    }
}
