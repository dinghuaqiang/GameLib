using System;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 通过他可以形成一系列的二进制读取的类
    /// </summary>
    static class BinReaderInit
    {
        static BinReaderInit()
        {
            BinReader<Boolean>._invoke = s => BinarySerializer.Read_Boolean(s);
            BinReader<Char>._invoke = s => (Char)BinarySerializer.Read_Int16(s);
            BinReader<Byte>._invoke = s => BinarySerializer.Read_Byte(s);
            BinReader<SByte>._invoke = s => BinarySerializer.Read_SByte(s);
            BinReader<Int16>._invoke = s => BinarySerializer.Read_Int16(s);
            BinReader<UInt16>._invoke = s => BinarySerializer.Read_UInt16(s);
            BinReader<Int32>._invoke = s => BinarySerializer.Read_Int32(s);
            BinReader<UInt32>._invoke = s => BinarySerializer.Read_UInt32(s);
            BinReader<Int64>._invoke = s => BinarySerializer.Read_Int64(s);
            BinReader<UInt64>._invoke = s => BinarySerializer.Read_UInt64(s);
            BinReader<String>._invoke = s => BinarySerializer.Read_String(s);
            BinReader<Single>._invoke = s => BinarySerializer.Read_Single(s);
            BinReader<Double>._invoke = s => BinarySerializer.Read_Double(s);
            Externsion();
        }        
        public static void DoInit()
        {
        }
        static void Externsion()
        {
            BinReader<Quaternion>._invoke = s => BinarySerializer.Read_Quaternion(s);
            BinReader<Vector4>._invoke = s => BinarySerializer.Read_Vector4(s);
            BinReader<Vector3>._invoke = s => BinarySerializer.Read_Vector3(s);
            BinReader<Vector2>._invoke = s => BinarySerializer.Read_Vector2(s);
        }
    }
}
