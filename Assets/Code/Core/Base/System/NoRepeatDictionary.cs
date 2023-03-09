using System.Collections.Generic;

namespace GameLib.Core.Base
{
    /// <summary>
    /// 没有重复Key的字典
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class NoRepeatDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// 添加Key的时候判断有没有
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                base.Add(key, value);
            }
        }

        /// <summary>
        /// 替换原有Key对应的Value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>是否替换成功</returns>
        public bool Replace(TKey key, TValue value)
        {
            bool isRepSucc = false;
            if (ContainsKey(key))
            {
                base[key] = value;
                isRepSucc = true;
            }
            return isRepSucc;
        }

        /// <summary>
        /// 获取Key的List数据
        /// </summary>
        public List<TKey> KeyList
        {
            get
            {
                List<TKey> keyList = new List<TKey>(Keys.Count);
                var iter = Keys.GetEnumerator();
                try
                {
                    while (iter.MoveNext()) { keyList.Add(iter.Current); }
                }
                finally
                {
                    iter.Dispose();
                }
                return keyList;
            }
        }

        /// <summary>
        /// 获取值的List数据
        /// </summary>
        public List<TValue> ValueList
        {
            get
            {
                List<TValue> valueList = new List<TValue>(Values.Count);
                var iter = Values.GetEnumerator();
                try
                {
                    while (iter.MoveNext()) { valueList.Add(iter.Current); }
                }
                finally
                {
                    iter.Dispose();
                }
                return valueList;
            }
        }
    }
}
