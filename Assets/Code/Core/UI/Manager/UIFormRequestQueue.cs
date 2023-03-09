using System;
using System.Collections.Generic;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体请求的缓存处理
    /// </summary>
    public class UIFormRequestQueue
    {
        //请求的窗体名字
        private List<string> _requestFormNames = new List<string>();

        public string this[int index]
        {
            get
            {
                return _requestFormNames[index];
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int OnSortFunc(string l, string r)
        {
            return _requestFormNames.IndexOf(l) - _requestFormNames.IndexOf(r);
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count
        {
            get
            {
                return _requestFormNames.Count;
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void Remove(string formName)
        {
            _requestFormNames.Remove(formName);
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void Remove(string[] formNames)
        {
            if (formNames != null)
            {
                for (int i = _requestFormNames.Count -1; i >= 0 ; i--)
                {
                    bool isFind = false;
                    for (int n = 0; n < formNames.Length; n++)
                    {
                        if (_requestFormNames[i].Equals(formNames[n], StringComparison.Ordinal))
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
                    {
                        _requestFormNames.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _requestFormNames.Clear();
        }

        /// <summary>
        /// 获取所有内容
        /// </summary>
        public List<string> GetContents()
        {
            return new List<string>(_requestFormNames);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        public bool IsExist(string formName)
        {
            return _requestFormNames.IndexOf(formName) >= 0;
        }

        /// <summary>
        /// 判断窗体是否是最后一个窗体
        /// </summary>
        public bool IsTop(string formName)
        {
            if (_requestFormNames.Count > 0)
            {
                return _requestFormNames[_requestFormNames.Count - 1].Equals(formName);
            }
            return false;
        }

        /// <summary>
        /// 查找窗体的索引
        /// </summary>
        public int IndexOf(string formName)
        {
            return _requestFormNames.IndexOf(formName);
        }

        /// <summary>
        /// 查找最后一个父窗体的位置
        /// </summary>
        public int LastIndexOf(List<string> formNames)
        {
            int idx = -1;
            for (int i = 0; i < formNames.Count; i++)
            {
                //从后面查比较快
                int tmpIndex = _requestFormNames.LastIndexOf(formNames[i]);
                if (tmpIndex >= 0 && tmpIndex > idx)
                {
                    idx = tmpIndex;
                }
            }
            return idx;
        }

        /// <summary>
        /// 查找当前窗体的所有父窗体
        /// </summary>
        public void GetParentForms(string formName, ref List<string> forms)
        {
            UIFormConfigInfo cfg = UIFormConfigInfo.Instance.Get(formName);
            if (cfg != null && cfg.Parents.Count > 0)
            {
                int idx = IndexOf(formName);
                //往上查找父窗体，中间查到不是父窗体，是同级窗体也要被关掉
                int parentIdx = idx - 1;
                while (parentIdx >= 0)
                {
                    string tmpName = _requestFormNames[parentIdx];
                    if (cfg.Parents.IndexOf(tmpName) >= 0)
                    {
                        break;
                    }
                    parentIdx -= 1;
                }
                if (parentIdx >= 0)
                {
                    //找到父窗体
                    for (int i = idx - 1; i >= parentIdx; i--)
                    {
                        forms.Add(_requestFormNames[i]);
                    }
                    GetParentForms(_requestFormNames[parentIdx], ref forms);
                }
            }
        }

        /// <summary>
        /// 插入窗体
        /// </summary>
        public bool Insert(string formName)
        {
            UIFormConfigInfo cfg = UIFormConfigInfo.Instance.Get(formName);
            if (cfg != null)
            {
                //查找父窗体
                int idx = LastIndexOf(cfg.Parents);
                if (idx >= 0)
                {
                    //插到父窗体之后
                    idx += 1;
                    _requestFormNames.Insert(idx, formName);
                }
                else
                {
                    //没找到父窗体，直接加载最后面
                    _requestFormNames.Add(formName);
                    idx = _requestFormNames.Count - 1;
                }
                //查找，并把所有子窗体都移动到当前窗体的后面
                for (int i = 0; i < cfg.Childs.Count; i++)
                {
                    idx = MoveFormToIndexAfter(cfg.Childs[i], idx);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移动某个窗体到某个索引的后面
        /// </summary>
        private int MoveFormToIndexAfter(string formName, int pIdx)
        {
            int tmpIdx = _requestFormNames.IndexOf(formName);
            if (tmpIdx >= 0)
            {
                //当父窗体索引比当前索引大，先插入再删除，最后返回的父索引减一
                if (pIdx > tmpIdx)
                {
                    _requestFormNames.Insert(pIdx + 1, formName);
                    _requestFormNames.RemoveAt(tmpIdx);
                    return pIdx - 1;
                }
                //当父索引的值小于当前索引,先删除,后插入,最后返回的父索引不变化
                else if (pIdx < tmpIdx)
                {
                    _requestFormNames.RemoveAt(tmpIdx);
                    _requestFormNames.Insert(pIdx + 1, formName);
                    return pIdx;
                }
            }
            return pIdx;
        }
    }
}
