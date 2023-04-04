using UnityEngine;
using UnityEngine.Rendering;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader的属性信息
    /// </summary>
    public class ShaderPropertyInfo
    {
        //名字
        public string Name { get; private set; }
        //ID
        public int ID { get; private set; }
        //类型
        public int ValueType { get; private set; }

        public ShaderPropertyInfo(string name, int type)
        {
            Name = name;
            ValueType = type;
            ID = Shader.PropertyToID(name);
        }

        //获取Shader的属性类型
        public ShaderPropertyType GetShaderPropertyType()
        {
            int tmp = ValueType;
            if (tmp > 100)
            {
                tmp /= 100;
            }
            return (ShaderPropertyType)tmp;
        }

        //获取Shader的纹理维度
        public TextureDimension GetShaderTexDim()
        {
            return (TextureDimension)(ValueType % 100);
        }
    }
}
