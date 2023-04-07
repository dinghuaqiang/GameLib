using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.UI
{
    /// <summary>
    /// UI窗体检测系统
    /// </summary>
    public class FormStateSystem
    {
        #region//私有变量
        //使用窗体ID来关联窗体名字
        private Dictionary<int, string> _idAndNameDict = new Dictionary<int, string>();
        //使用窗体名字来关联窗体状态
        private Dictionary<string, FormStateCode> _nameStateDict = new Dictionary<string, FormStateCode>();
        //根据窗体名字关联,窗体的对象
        private Dictionary<string, GameObject> _nameGameObjectDict = new Dictionary<string, GameObject>();
        //窗体系统是否准备完毕
        private bool _isFormSystemReadyOK = false;
        #endregion

        #region//属性信息
        //获取窗体系统是否准备完毕
        public bool IsFormSystemReadyOK
        {
            get
            {
                return _isFormSystemReadyOK;
            }
            set
            {
                _isFormSystemReadyOK = value;
            }
        }
        #endregion

        #region//窗体查询,获取等功能函数

        #region//获取窗体状态的接口
        //通过名字,获取窗体状态
        public FormStateCode GetFormState(string name)
        {
            if (_nameStateDict.ContainsKey(name))
            {
                return _nameStateDict[name];
            }
            return FormStateCode.FSC_NONE;
        }

        //通过ID,获取窗体状态
        public FormStateCode GetFormState(int formID)
        {
            if (_idAndNameDict.ContainsKey(formID))
            {
                return GetFormState(_idAndNameDict[formID]);
            }
            return FormStateCode.FSC_NONE;
        }

        //通过ID,获取窗体状态
        public FormStateCode GetFormStateByEventID(int eventID)
        {
            return GetFormState(EventIDToFormID(eventID));
        }
        #endregion

        #region//当前窗体是否打开的接口
        //UI是否开启
        public bool FormIsOpen(string name)
        {
            var state = GetFormState(name);
            return FormStateIsOpen(state);
        }

        //UI是否开启
        public bool FormIsOpen(int formID)
        {
            var state = GetFormState(formID);
            return FormStateIsOpen(state);
        }

        //UI是否开启
        public bool FormIsOpenByEventID(int eventID)
        {
            var state = GetFormStateByEventID(eventID);
            return FormStateIsOpen(state);
        }

        #endregion

        #region//获取已经打开的窗口GameObject
        /// <summary>
        /// 获取打开的窗体
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public GameObject GetOpenedForm(int formID)
        {
            if (_idAndNameDict.ContainsKey(formID))
            {
                return GetOpenedForm(_idAndNameDict[formID]);
            }
            return null;
        }
        /// <summary>
        /// 获取打开的窗体
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public GameObject GetOpenedForm(string name)
        {
            GameObject go = null;
            _nameGameObjectDict.TryGetValue(name, out go);
            return go;
        }

        /// <summary>
        /// 获取打开的窗体
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public GameObject GetOpenedFormByEventID(int eventID)
        {
            return GetOpenedForm(EventIDToFormID(eventID));
        }
        #endregion

        #region//窗体ID,UI消息,窗体名称,相互转换的函数
        //通过事件ID获取窗体ID
        public int EventIDToFormID(int uiEventID)
        {
            return (uiEventID - Event.EventDefines.EVENT_UI_BASE_ID) / 10;
        }

        //通过ID,获取窗体状态
        public string GetFormName(int formID)
        {
            string strName = string.Empty;
            _idAndNameDict.TryGetValue(formID, out strName);
            return strName;
        }
        #endregion

        #endregion

        #region//窗体状态处理,由UI系统来进行调用
        //设置状态
        public void SetFormState(string name, FormStateCode value, GameObject go)
        {
            _nameStateDict[name] = value;
            if (value == FormStateCode.FSC_OPENED)
            {
                _nameGameObjectDict[name] = go;
            }
            else
            {
                _nameGameObjectDict[name] = null;
            }
        }
        #endregion

        #region//初始化或者卸载
        public void Initialize()
        {
            _idAndNameDict.Clear();
            var e = Cfg.Data.DeclareUIConfig.CacheData.GetEnumerator();
            while (e.MoveNext())
            {
                _idAndNameDict[e.Current.Value.Id] = e.Current.Key;
            }
        }

        public void UnInitialize()
        {
            _idAndNameDict.Clear();
        }
        #endregion

        #region//私有函数
        //窗体是否打开判断
        private bool FormStateIsOpen(FormStateCode state)
        {
            if (state == FormStateCode.FSC_CLOSED || state == FormStateCode.FSC_UNLOADED || state == FormStateCode.FSC_DESTROY || state == FormStateCode.FSC_NONE)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
