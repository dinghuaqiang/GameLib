using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 通过他可以形成一系列的二进制写的类
    /// </summary>
    static class BinWriterInit
    {
        static BinWriterInit()
        {
            BinWriter<Boolean>._invoke = (s, v) => BinarySerializer.Write_Boolean(s, v);
            BinWriter<Char>._invoke = (s, v) => BinarySerializer.Write_Int16(s, (Int16)v);
            BinWriter<Byte>._invoke = (s, v) => BinarySerializer.Write_Byte(s, v);
            BinWriter<SByte>._invoke = (s, v) => BinarySerializer.Write_SByte(s, v);
            BinWriter<Int16>._invoke = (s, v) => BinarySerializer.Write_Int16(s, v);
            BinWriter<UInt16>._invoke = (s, v) => BinarySerializer.Write_UInt16(s, v);
            BinWriter<Int32>._invoke = (s, v) => BinarySerializer.Write_Int32(s, v);
            BinWriter<UInt32>._invoke = (s, v) => BinarySerializer.Write_UInt32(s, v);
            BinWriter<Int64>._invoke = (s, v) => BinarySerializer.Write_Int64(s, v);
            BinWriter<UInt64>._invoke = (s, v) => BinarySerializer.Write_UInt64(s, v);
            BinWriter<String>._invoke = (s, v) => BinarySerializer.Write_String(s, v);
            BinWriter<Single>._invoke = (s, v) => BinarySerializer.Write_Single(s, v);
            BinWriter<Double>._invoke = (s, v) => BinarySerializer.Write_Double(s, v);
            Externsion();
        }        
        public static void DoInit()
        {
        }
        static void Externsion()
        {
            BinWriter<Quaternion>._invoke = (s, v) => BinarySerializer.Write_Quaternion(s, v);
            BinWriter<Vector4>._invoke = (s, v) => BinarySerializer.Write_Vector4(s, v);
            BinWriter<Vector3>._invoke = (s, v) => BinarySerializer.Write_Vector3(s, v);
            BinWriter<Vector2>._invoke = (s, v) => BinarySerializer.Write_Vector2(s, v);
        }
    }
}
