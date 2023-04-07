using Code.Core.Base.Container;
using GameLib.Core.Base;
using System;
using UnityEngine;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 对所有的树形子对象进行处理,这里使用的是非递归方式.
        /// 使用了一个缓存
        /// </summary>
        [ExecuteInEditMode]
        public static class Hierarchy
        {
            /// <summary>
            /// 用于防止递归的临时存储器
            /// </summary>
            private static QuickList<Transform> _searchStack = new QuickList<Transform>();

            /// <summary>
            /// 对的所有子Transform进行处理
            /// </summary>
            /// <param name="current"></param>
            /// <param name="walker"></param>
            public static void WalkHierarchy(Transform current, GFunc<Transform, bool> walker)
            {
                try
                {
                    _searchStack.Add(current);
                    while (_searchStack.Count > 0)
                    {
                        var cur = _searchStack.Pop();
                        if (walker(cur) == false)
                        {
                            continue;
                        }
                        for (int i = 0; i < cur.childCount; ++i)
                        {
                            _searchStack.Add(cur.GetChild(i));
                        }
                    }
                }
                finally
                {
                    _searchStack.Clear();
                }
            }

            /// <summary>
            /// 在所有子对象的层次中,检索名字
            /// </summary>
            /// <param name="current"></param>
            /// <param name="name"></param>
            /// <param name="ignoreCase"></param>
            /// <returns></returns>
            /// 
            public static Transform SearchHierarchy(Transform current, string name, bool ignoreCase = false)
            {
                try
                {
                    _searchStack.Add(current);
                    StringComparison cmp = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
                    while (_searchStack.Count > 0)
                    {
                        var cur = _searchStack.Pop();
                        if (cur == null)
                        {
                            continue;
                        }
                        if (cur.name.Equals(name, cmp))
                        {
                            return cur;
                        }
                        for (int i = 0; i < cur.childCount; ++i)
                        {
                            _searchStack.Add(cur.GetChild(i));
                        }
                    }
                }
                finally
                {
                    _searchStack.Clear();
                }
                return null;
            }

            //强制使用大小写
            public static Transform SearchHierarchyForceCase(Transform current, string name)
            {
                try
                {
                    if (current.name == name) return current;
                    _searchStack.Add(current);
                    while (_searchStack.Count > 0)
                    {
                        var cur = _searchStack.Pop();
                        if (cur == null)
                        {
                            continue;
                        }
                        var ret = cur.Find(name);
                        if (ret != null)
                        {
                            return ret;
                        }
                        for (int i = 0; i < cur.childCount; ++i)
                        {
                            cur = cur.GetChild(i);
                            if (cur.childCount > 0)
                            {
                                _searchStack.Add(cur);
                            }
                        }
                    }
                }
                finally
                {
                    _searchStack.Clear();
                }
                return null;
            }



            /// <summary>
            /// 在所有子对象的层次中,检索名字
            /// </summary>
            /// <param name="current"></param>
            /// <param name="name"></param>
            /// <param name="ignoreCase"></param>
            /// <returns></returns>
            public static Transform SearchHierarchyWithTag(Transform current, string name, bool ignoreCase = false, string tag = null)
            {
                try
                {
                    var findTag = !string.IsNullOrEmpty(tag);
                    _searchStack.Add(current);
                    StringComparison cmp = ignoreCase ? StringComparison.CurrentCultureIgnoreCase :
                            StringComparison.CurrentCulture;
                    while (_searchStack.Count > 0)
                    {
                        var cur = _searchStack.Pop();
                        if (cur == null)
                        {
                            continue;
                        }

                        if (!findTag || (findTag && cur.CompareTag(tag)))
                        {
                            if (cur.name.Equals(name, cmp))
                            {
                                return cur;
                            }
                        }
                        for (int i = 0; i < cur.childCount; ++i)
                        {
                            _searchStack.Add(cur.GetChild(i));
                        }
                    }
                }
                finally
                {
                    _searchStack.Clear();
                }
                return null;
            }
        }
    }
}
