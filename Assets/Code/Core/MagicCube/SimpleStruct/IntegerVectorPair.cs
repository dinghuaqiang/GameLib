using System;
using UnityEngine;

namespace GameLib.Core.MagicCube.SimpleStruct
{
    /// <summary>
    /// 简单数据接口，整数与Vector的键值对
    /// </summary>
    [Serializable]
    public class IntegerVectorPair
    {
        [SerializeField]
        public int Key;
        public Vector4 Value;
    }
}
