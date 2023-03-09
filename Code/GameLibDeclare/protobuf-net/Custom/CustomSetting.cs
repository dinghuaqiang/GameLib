using System;
using System.Collections.Generic;

/// <summary>
/// 说明：某类型与在该类型上自定义Serializer的映射表
/// 
/// 注意：
///     1）在使用ProtoBuf-net前需要初始化这张表
/// 
/// @by wsh 2017-06-29
/// </summary>

namespace ProtoBuf.Serializers
{
    public static class CustomSetting
    {
        //private static Dictionary<Type, ICustomProtoSerializer> customSerializerMap = null;

        //static public void NewSerializerMap(int size)
        //{
        //    customSerializerMap = new Dictionary<Type, ICustomProtoSerializer>(size);
        //}

        //static public void AddCustomSerializer(Type type, ICustomProtoSerializer customSerializer)
        //{
        //    if (customSerializerMap == null)
        //    {
        //        customSerializerMap = new Dictionary<Type, ICustomProtoSerializer>();
        //    }
        //    customSerializerMap.Add(type, customSerializer);
        //}

        //static public void RemoveCustomSerializer(Type type)
        //{
        //    if (customSerializerMap == null)
        //        return;
        //    customSerializerMap.Remove(type);
        //}

        //static public void CrearCustomSerializer()
        //{
        //    if (customSerializerMap == null)
        //        return;
        //    customSerializerMap.Clear();
        //}

        //static public ICustomProtoSerializer TryGetCustomSerializer(Type targetType)
        //{
        //    if (customSerializerMap == null)
        //        return null;
        //    ICustomProtoSerializer customSerializer;
        //    if (customSerializerMap.TryGetValue(targetType, out customSerializer))
        //    {
        //        return customSerializer;
        //    }
        //    return null;
        //}
        //==============[2020.6.19]==================
        private static Dictionary<uint, IExtensible> _deserializerMap = null;
        private static Dictionary<uint, Type> _deserializerTypeMap = null;

        static public void NewDeserializerMap(int size)
        {
            _deserializerMap = new Dictionary<uint, IExtensible>(size);
            _deserializerTypeMap = new Dictionary<uint, Type>(size);
        }

        static public void AddDeserializer(uint msgId, Type t)
        {
            if(_deserializerTypeMap == null)
            {
                _deserializerTypeMap = new Dictionary<uint, Type>();
            }
            _deserializerTypeMap.Add(msgId, t);
        }

        static public void RemoveDeserializer(uint msgId)
        {
            if (_deserializerTypeMap == null)
                return;
            _deserializerTypeMap.Remove(msgId);
        }

        static public void ClearDeserializer()
        {
            if (_deserializerMap != null)
            {
                _deserializerMap.Clear();
            }
            if(_deserializerTypeMap != null)
            {
                _deserializerTypeMap.Clear();
            }
        }

        static public IExtensible TryGetDeserializer(uint msgId)
        {
            if (_deserializerMap == null)
                return null;
            IExtensible deserializer = null;
            Type t = null;
            if (!_deserializerMap.TryGetValue(msgId, out deserializer) && _deserializerTypeMap.TryGetValue(msgId, out t))
            {
                deserializer = System.Activator.CreateInstance(t) as IExtensible;
                if(deserializer != null)
                {
                    _deserializerMap.Add(msgId, deserializer);
                }
            }
            return deserializer;
        }

    }
}