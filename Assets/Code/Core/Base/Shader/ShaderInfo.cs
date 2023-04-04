using System;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader的属性信息
    /// </summary>
    public class ShaderInfo
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        //属性索引的数组
        public string[] PropertyNameArray { get; set; }

        //属性ID数组的排序
        private int[] _propertySortIDArray = null;
        //获取属性ID的数组
        private int[] _propertyIDArray = null;

        private ShaderPropertyType[] _propertyTypeArray = null;

        //属性值的数组
        public Vector4[] PropertyValueArray { get; set; }

        //实际的Shader
        private Shader _realShader = null;

        public Shader RealShader
        {
            get
            {
                if (_realShader == null)
                {
                    _realShader = ShaderEx.Find(Name);
                }
                return _realShader;
            }
            set
            {
                _realShader = value;
            }
        }

        public int[] PropertyIDArray
        {
            get
            {
                if (_propertyIDArray == null)
                {
                    RefreshPropertyArray();
                }
                return _propertyIDArray;
            }
        }

        //属性类型的数组
        public ShaderPropertyType[] PropertyTypeArray
        {
            get
            {
                if (_propertyTypeArray == null)
                {
                    _propertyTypeArray = Array.ConvertAll(PropertyIDArray, x => { return ShaderManager.Instance.GetShaderPropertyType(x); });
                }
                return _propertyTypeArray;
            }
        }

        //是否有属性
        public bool HasProperty(int id)
        {
            if (_propertySortIDArray == null)
            {
                RefreshPropertyArray();
            }
            return Array.BinarySearch(_propertySortIDArray, id) >= 0;
        }

        private void RefreshPropertyArray()
        {
            _propertyIDArray = Array.ConvertAll(PropertyNameArray, x => { return Shader.PropertyToID(x); });
            _propertySortIDArray = new int[_propertyIDArray.Length];
            Array.Copy(_propertyIDArray, _propertySortIDArray, _propertyIDArray.Length);
            Array.Sort(_propertySortIDArray);
        }
    }
}
