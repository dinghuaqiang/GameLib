using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 反射的工具类
    /// </summary>
    public static class AssemblyUtils
    {
        //类型缓存
        private static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();

        //通过带有名字空间的类型名,查找类型
        public static Type FindType(string typeNameWithNamespace)
        {
            //1.如果字符串为空,就直接返回
            if (string.IsNullOrEmpty(typeNameWithNamespace)) return null;

            //2.查找类型缓存
            if (_typeCache.ContainsKey(typeNameWithNamespace))
            {
                return _typeCache[typeNameWithNamespace];
            }

            //3.扫描所有的Assembly
            var assmbles = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assmbles.Length; i++)
            {
                var t = assmbles[i].GetType(typeNameWithNamespace);
                if (t != null)
                {
                    _typeCache[typeNameWithNamespace] = t;
                    return t;
                }
            }
            return null;
        }

        //清理类型缓存
        public static void ClearTypeCache()
        {
            _typeCache.Clear();
        }

        //获取静态方法
        public static MethodInfo GetPublicStaticMethod(Type type, string methodName)
        {
            if (type != null)
            {
                return type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod);
            }
            return null;
        }

        //获取静态属性
        public static PropertyInfo GetPublicStaticProperty(Type type, string propertyName)
        {
            if (type != null)
            {
                return type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public);
            }
            return null;
        }

        //获取静态字段
        public static FieldInfo GetPublicStaticField(Type type, string fieldName)
        {
            if (type != null)
            {
                return type.GetField(fieldName, BindingFlags.Static | BindingFlags.Public);
            }
            return null;
        }



        //获取成员方法
        public static MethodInfo GetPublicMemberMethod(Type type, string methodName)
        {
            if (type != null)
            {
                return type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod);
            }
            return null;
        }

        //获取成员属性
        public static PropertyInfo GetPublicMemberProperty(Type type, string propertyName)
        {
            if (type != null)
            {
                return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            }
            return null;
        }

        //获取成员字段
        public static FieldInfo GetPublicMemberField(Type type, string fieldName)
        {
            if (type != null)
            {
                return type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public);
            }
            return null;
        }

        //执行成员方法
        public static object InvokePublicMemberMethod(object obj, string methodName, object[] paramArr)
        {
            if (obj != null)
            {
                var mi = GetPublicMemberMethod(obj.GetType(), methodName);
                if (mi != null)
                {
                    return mi.Invoke(obj, paramArr);
                }
            }
            return null;
        }

        //获取成员属性值
        public static object GetPublicMemberPropertyValue(object obj, string propertyName, object[] index)
        {
            if (obj != null)
            {
                var pi = GetPublicMemberProperty(obj.GetType(), propertyName);
                if (pi != null)
                {
                    return pi.GetValue(obj, index);
                }
            }
            return null;
        }

        //获取成员属性值
        public static bool SetPublicMemberPropertyValue(object obj, string propertyName, object value, object[] index)
        {
            if (obj != null)
            {
                var pi = GetPublicMemberProperty(obj.GetType(), propertyName);
                if (pi != null)
                {
                    pi.SetValue(obj, value, index);
                    return true;
                }
            }
            return false;
        }

        //获取成员字段值
        public static bool SetPublicMemberFieldValue(object obj, string fieldName, object value)
        {
            if (obj != null)
            {
                var fi = GetPublicMemberField(obj.GetType(), fieldName);
                if (fi != null)
                {
                    fi.SetValue(obj, value);
                    return true;
                }
            }
            return false;
        }
    }
}
