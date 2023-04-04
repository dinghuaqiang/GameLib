using System;

namespace GameLib.Core.MagicCube.SimpleStruct
{
    /// <summary>
    /// 简单数据接口，字符串和整数的键值对
    /// </summary>
    [Serializable]
    public class StringIntegerPair
    {
        public string Key;
        public int Value;
    }
}
