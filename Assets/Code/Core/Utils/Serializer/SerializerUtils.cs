using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    //常用的一些类的序列化操作
    public static class SerializerUtils
    {

        #region//序列化

        //序列化所有字段
        public static bool SerializeAllFields(System.IO.BinaryWriter sw,object o,Type type, System.Reflection.BindingFlags flags)
        {
            if (o == null || type == null) return false;
            var fields = type.GetFields(flags);
            sw.Write(fields.Length);
            for (int i = 0; i < fields.Length; i++)
            {
                var fd = fields[i];
                var obj = fd.GetValue(o);
                if (obj != null)
                {
                    sw.Write(true);
                    if (!Serialize(sw, obj))
                    {
                        Debug.LogError("Field Serialzie Fail!!" + fd.Name);
                        return false;
                    }
                }
                else
                {
                    sw.Write(false);
                }
            }
            return true;  
        }

        public static bool Serialize(System.IO.BinaryWriter sw, object o)
        {
            if (o == null) return false;
            var type = o.GetType();
            if (type == typeof(Int64)) return Serialize(sw, (Int64)o);
            else if (type == typeof(UInt64)) return Serialize(sw, (UInt64)o);
            else if (type == typeof(Int32)) return Serialize(sw, (Int32)o);
            else if (type == typeof(UInt32)) return Serialize(sw, (UInt32)o);
            else if (type == typeof(Int16)) return Serialize(sw, (Int16)o);
            else if (type == typeof(UInt16)) return Serialize(sw, (UInt16)o);
            else if (type == typeof(sbyte)) return Serialize(sw, (sbyte)o);
            else if (type == typeof(byte)) return Serialize(sw, (byte)o);
            else if (type == typeof(Single)) return Serialize(sw, (Single)o);
            else if (type == typeof(Double)) return Serialize(sw, (Double)o);
            else if (type == typeof(string)) return Serialize(sw, (string)o);
            else if (type == typeof(bool)) return Serialize(sw, (bool)o);
            else if (type == typeof(Vector2)) return Serialize(sw, (Vector2)o);
            else if (type == typeof(Vector3)) return Serialize(sw, (Vector3)o);
            else if (type == typeof(Vector4)) return Serialize(sw, (Vector4)o);
            else if (type == typeof(Color)) return Serialize(sw, (Color)o);
            else if (type == typeof(AnimationCurve)) return Serialize(sw, (AnimationCurve)o);
            else
            {
               throw new Exception("Can not find the serialize function about type:" + type.Name); 
            }

        }

        public static bool Serialize(System.IO.BinaryWriter sw, Int64 value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, UInt64 value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, Int32 value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, UInt32 value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, Int16 value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, UInt16 value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, sbyte value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, byte value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, Single value)
        {
            sw.Write(value);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, Double value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, string value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, bool value)
        {
            sw.Write(value);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, Vector2 value)
        {
            sw.Write(value.x);
            sw.Write(value.y);
            return true;
        }
        public static bool Serialize(System.IO.BinaryWriter sw, Vector3 value)
        {
            sw.Write(value.x);
            sw.Write(value.y);
            sw.Write(value.z);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, Vector4 value)
        {
            sw.Write(value.x);
            sw.Write(value.y);
            sw.Write(value.z);
            sw.Write(value.w);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, Color value)
        {
            sw.Write(value.r);
            sw.Write(value.g);
            sw.Write(value.b);
            sw.Write(value.a);
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, Keyframe[] value)
        {
            if (value == null) return false;
            sw.Write(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                sw.Write(value[i].inTangent);
                sw.Write(value[i].outTangent);
                sw.Write(value[i].tangentMode);
                sw.Write(value[i].time);
                sw.Write(value[i].value);
            }
            return true;
        }

        public static bool Serialize(System.IO.BinaryWriter sw, AnimationCurve value)
        {
            if (value == null) return false;
            sw.Write((int)value.preWrapMode);
            sw.Write((int)value.postWrapMode);
            Serialize(sw, value.keys);
            return true;
        }
        #endregion

        #region//反序列化

        //反序列化对象所有字段
        public static bool DeSerializeAllFields(System.IO.BinaryReader sr, object o, Type type, System.Reflection.BindingFlags flags)
        {
            if (o == null || type == null) return false;
            var fields = type.GetFields(flags);
            var fc = sr.ReadInt32();
            for (int i = 0; i < fields.Length && i < fc; i++)
            {
                var fd = fields[i];
                var isnull = !sr.ReadBoolean();
                if (!isnull)
                {
                    var fv = DeSerialize(sr, fd.FieldType);
                    if (fv != null)
                    {
                        fd.SetValue(o, fv);
                    }
                    else
                    {
                        Debug.LogError("Field DeSerialzie Fail!!" + fd.Name);
                        return false;
                    }
                }
                else
                {
                    fd.SetValue(o, null);
                }
            }
            return true;
        }

        public static object DeSerialize(System.IO.BinaryReader sr, Type type)
        {
            if (type == typeof(Int64)) { Int64 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(UInt64)) { UInt64 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Int32)) { Int32 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(UInt32)) { UInt32 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Int16)) { Int16 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(UInt16)) { UInt16 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(sbyte)) { sbyte result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(byte)) { byte result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Single)) { Single result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Double)) { Double result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(string)) { string result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(bool)) { bool result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Vector2)) { Vector2 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Vector3)) { Vector3 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Vector4)) { Vector4 result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(Color)) { Color result; DeSerialize(sr, out result); return result; }
            else if (type == typeof(AnimationCurve)) { AnimationCurve result; DeSerialize(sr, out result); return result; }
            else
            {
                throw new Exception("Can not find the deserialize function about type:" + type.Name);
            }

        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out Int64 value)
        {
            value = sr.ReadInt64();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out UInt64 value)
        {
            value = sr.ReadUInt64();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out Int32 value)
        {
            value = sr.ReadInt32();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out UInt32 value)
        {
            value = sr.ReadUInt32();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out Int16 value)
        {
            value = sr.ReadInt16();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out UInt16 value)
        {
            value = sr.ReadUInt16();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out sbyte value)
        {
            value = sr.ReadSByte();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out byte value)
        {
            value = sr.ReadByte();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out Single value)
        {
            value = sr.ReadSingle();
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out Double value)
        {
            value = sr.ReadDouble();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out string value)
        {
            value = sr.ReadString();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out bool value)
        {
            value = sr.ReadBoolean();
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out Vector2 value)
        {
            value = new Vector2(sr.ReadSingle(), sr.ReadSingle());
            return true;
        }
        public static bool DeSerialize(System.IO.BinaryReader sr, out Vector3 value)
        {
            value = new Vector3(sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle());
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out Vector4 value)
        {
            value = new Vector4(sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle());
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out Color value)
        {
            value = new Color(sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle());
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out Keyframe[] value)
        {
            value = new Keyframe[sr.ReadInt32()];
            for (int i = 0; i < value.Length; i++)
            {
                value[i].inTangent = sr.ReadSingle();
                value[i].outTangent = sr.ReadSingle();
                value[i].tangentMode = sr.ReadInt32();
                value[i].time = sr.ReadSingle();
                value[i].value = sr.ReadSingle();
            }
            return true;
        }

        public static bool DeSerialize(System.IO.BinaryReader sr, out AnimationCurve value)
        {
            value = new AnimationCurve();
            value.preWrapMode = (WrapMode)sr.ReadInt32();
            value.postWrapMode = (WrapMode)sr.ReadInt32();
            Keyframe[] keys = null;
            DeSerialize(sr, out keys);
            value.keys = keys;
            return true;
        }
        #endregion
    }
}
