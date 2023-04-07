using GameLib.Core.Base;
using System.Collections.Generic;

namespace Code.Core.Base.Container
{
    /// <summary>
    /// 容器的工具类
    /// </summary>
    public class ContainerUtils
    {
        /// <summary>
        /// 封装字典的Foreach处理
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <param name="onCallback"></param>
        public static void DoForeachDictionary<K, V>(Dictionary<K, V> data, GAction<K, V> onCallback)
        {
            if (data == null || data.Count == 0) return;
            var e = data.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    onCallback(e.Current.Key, e.Current.Value);
                }
            }
            finally
            {
                e.Dispose();
            }
        }
        /// <summary>
        /// 封装Dict添加数据泛型方法 返回false为修改原有数据
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="tagDict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool DictionaryAdd<K, V>(Dictionary<K, V> tagDict, K key, V value)
        {
            if (tagDict != null)
            {
                V data;
                if (!tagDict.TryGetValue(key, out data))
                {
                    tagDict.Add(key, value);
                    return true;
                }
                else
                {
                    tagDict[key] = value;
                }
            }
            return false;
        }

        /// <summary>
        /// 封装List置换数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagList"></param>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <param name="doAdd"></param>
        public static void ListReplace<T>(List<T> tagList, T oldData, T newData, bool doAdd = false)
        {
            if (tagList != null)
            {
                int index = tagList.IndexOf(oldData);
                if (index != -1)
                {
                    tagList[index] = newData;
                }
                else
                {
                    if (doAdd)
                    {
                        tagList.Add(newData);
                    }
                }
            }
        }
        public static void ListReplace<T>(List<T> tagList, T newData, bool doAdd = false)
        {
            if (tagList != null)
            {
                int index = tagList.IndexOf(newData);
                if (index != -1)
                {
                    tagList[index] = newData;
                }
                else
                {
                    if (doAdd)
                    {
                        tagList.Add(newData);
                    }
                }
            }
        }

        /// <summary>
        /// 封装List置换数据唯一方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagList"></param>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <param name="doAdd"></param>
        public static void ListReplaceUnique<T>(List<T> tagList, T oldData, T newData, bool doAdd = false)
        {
            if (tagList != null)
            {
                int index = tagList.IndexOf(oldData);
                if (index != -1)
                {
                    tagList.RemoveAt(index);
                }
                ListAddUnique(tagList, newData);
            }
        }

        /// <summary>
        /// 封装List唯一数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagList"></param>
        /// <param name="newData"></param>
        public static void ListAddUnique<T>(List<T> tagList, T newData)
        {
            if (tagList != null)
            {
                if (!tagList.Contains(newData))
                {
                    tagList.Add(newData);
                }
            }
        }

        /// <summary>
        /// 封装添加目标容器固定位方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagList"></param>
        /// <param name="index"></param>
        /// <param name="newData"></param>
        /// <param name="defaultData"></param>
        public static void ListAddToTagIndex<T>(List<T> tagList, int index, T newData, T defaultData)
        {
            if (tagList != null)
            {
                if (index > tagList.Count - 1)
                {
                    for (int i = 0, imax = (index - (tagList.Count)); i < imax; i++)
                    {
                        tagList.Add(defaultData);
                    }
                    tagList.Add(newData);
                }
                else
                {
                    tagList[index] = newData;
                }
            }
        }

        /// <summary>
        /// 封装array foreach方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagArray"></param>
        /// <param name="foreachFunc"></param>
        public static void DoForeach<T>(T[] tagArray, GAction<T> foreachFunc = null)
        {
            if (tagArray != null)
            {
                for (int i = 0, imax = tagArray.Length; i < imax; i++)
                {
                    T curElement = tagArray[i];
                    if (foreachFunc != null && curElement != null)
                    {
                        foreachFunc(curElement);
                    }
                }
            }
        }

        /// <summary>
        /// 封装array foreach方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagArray"></param>
        /// <param name="foreachFunc"></param>
        public static void DoForeachIteratively<T>(T[] tagArray, GAction<T, int> foreachFunc = null)
        {
            if (tagArray != null)
            {
                for (int i = 0, imax = tagArray.Length; i < imax; i++)
                {
                    T curElement = tagArray[i];
                    if (foreachFunc != null && curElement != null)
                    {
                        foreachFunc(curElement, i);
                    }
                }
            }
        }

        /// <summary>
        /// 获取字典的值,通过索引
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static KeyValuePair<T1, T2> GetDictItem<T1, T2>(Dictionary<T1, T2> dict, int idx)
        {
            var e = dict.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    if (idx == 0)
                    {
                        return e.Current;
                    }
                    else if (idx < 0)
                    {
                        break;
                    }
                    else
                    {
                        idx--;
                    }
                }
            }
            finally
            {
                e.Dispose();
            }
            return default(KeyValuePair<T1, T2>);
        }

        /// <summary>
        /// 查找字典通过值
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<T1, T2> FindDictItemByValue<T1, T2>(Dictionary<T1, T2> dict, T2 value)
        {
            var e = dict.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    if (e.Current.Value.Equals(value))
                    {
                        return e.Current;
                    }
                }
            }
            finally
            {
                e.Dispose();
            }
            return default(KeyValuePair<T1, T2>);
        }

        public static T GetItemByIndex<T>(LinkedList<T> list, int idx)
        {
            var e = list.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    if (idx == 0)
                    {
                        return e.Current;
                    }
                    else if (idx < 0)
                    {
                        break;
                    }
                    else
                    {
                        idx--;
                    }
                }
            }
            finally
            {
                e.Dispose();
            }
            return default(T);
        }
    }
}
