using Code.Core.Utils;
using GameLib.Cfg.Data;
using GameLib.Core.Utils;
using System;
using System.Collections.Generic;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体配置信息
    /// 主要是解析配置表，设置数据
    /// </summary>
    public class UIFormConfigInfo : Singleton<UIFormConfigInfo>
    {
        private int _eventID = -1;
        /// <summary>
        /// 窗体ID
        /// </summary>
        public int FormID { get; set; }
        /// <summary>
        /// 窗体名字
        /// </summary>
        public string FormName { get; set; }
        /// <summary>
        /// 当前窗体的父窗体
        /// </summary>
        public List<string> Parents { get; set; }
        /// <summary>
        /// 当前窗体的子窗体
        /// </summary>
        public List<string> Childs { get; set; }
        /// <summary>
        /// 所有的UI配置信息
        /// </summary>
        private Dictionary<string, UIFormConfigInfo> _data = null;

        /// <summary>
        /// 事件ID
        /// </summary>
        public int EventID
        {
            get
            {
                if (_eventID < 0)
                {
                    _eventID = Event.EventDefines.EVENT_UI_BASE_ID + FormID;
                }
                return _eventID;
            }
        }

        /// <summary>
        /// 是否存在当前界面
        /// </summary>
        public bool IsExist(string formName)
        {
            return AllData.ContainsKey(formName);
        }

        /// <summary>
        /// 获取当前UI的配置信息
        /// </summary>
        public UIFormConfigInfo Get(string formName)
        {
            bool hasConfig = AllData.TryGetValue(formName, out UIFormConfigInfo configInfo);
            if (!hasConfig)
            {
                FLogger.DebugLogErrorFormat("窗体 {0} 没有找到配置信息!!", formName);
            }
            return configInfo;
        }

        /// <summary>
        /// 遍历所有配置信息
        /// </summary>
        public void ForeachAll(Action<string, UIFormConfigInfo> handler)
        {
            if (handler != null)
            {
                var iter = AllData.GetEnumerator();
                try
                {
                    while (iter.MoveNext())
                    {
                        handler(iter.Current.Key, iter.Current.Value);
                    }
                }
                finally
                {
                    iter.Dispose();
                }
            }
        }

        /// <summary>
        /// 所有UI界面的配置信息
        /// </summary>
        private Dictionary<string, UIFormConfigInfo> AllData
        {
            get
            {
                _data = new Dictionary<string, UIFormConfigInfo>(DeclareUIConfig.CacheDataCount);
                var iter = DeclareUIConfig.CacheData.GetEnumerator();
                try
                {
                    DeclareUIConfig uiConfig = iter.Current.Value;
                    //初次加载所有UI事件 同时保存配置文件
                    var info = new UIFormConfigInfo
                    {
                        FormID = uiConfig.Id * 10,
                        FormName = uiConfig.Name,
                        Parents = new List<string>(),
                        Childs = new List<string>()
                    };
                    //记录父界面的信息
                    if (!string.IsNullOrEmpty(uiConfig.Parents))
                    {
                        info.Parents.AddRange(uiConfig.Parents.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                    }
                    _data[info.FormName] = info;
                }
                finally
                {
                    iter.Dispose();
                }

                //填充子对象，记录子界面的信息
                var pIter = _data.GetEnumerator();
                try
                {
                    List<string> parents = pIter.Current.Value.Parents;
                    for (int i = 0; i < parents.Count; i++)
                    {
                        if (_data.ContainsKey(parents[i]))
                        {
                            _data[parents[i]].Childs.Add(pIter.Current.Key);
                        }
                    }
                }
                finally
                {
                    pIter.Dispose();
                }
                return _data;
            }
        }
    }
}
