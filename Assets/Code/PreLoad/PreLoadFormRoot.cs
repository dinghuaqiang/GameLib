using Code.Logic.Manager;
using GameLib.Core.Base;
using GameLib.Core.Event;
using GameLib.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic.PreLoad
{
    /// <summary>
    ///  预加载窗体节点
    /// </summary>
    public class PreLoadFormRoot
    {
        #region//私有变量
        private string _rootName = "[PreLoadForm]";
        private string _uirootName = "UIRoot";
        private GameObject _root = null;
        private GameObject _uiRoot = null;
        private List<string> _waiteList = new List<string>();
        private Dictionary<string, GameObject> _dicPreShowForm = new Dictionary<string, GameObject>();
        private List<string> _waitResetForms = new List<string>();
        #endregion

        #region//公共函数
        public void Add(string name)
        {
            if (_root == null)
            {
                var go = new GameObject(_rootName);
                _root = go;
                _root.transform.parent = AppRoot.Transform;
                _root.gameObject.SetActive(false);
            }
            if (!_dicPreShowForm.ContainsKey(name))
            {
                _dicPreShowForm.Add(name, null);
                _waiteList.Add(name);
            }
            OpenForm();
        }

        public bool SetRealParent()
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Find(_uirootName);
            }
            _waitResetForms.Clear();
            if (_waiteList.Count != 0)
            {
                for (int i = _waiteList.Count - 1; i >= 0; i--)
                {
                    if (_dicPreShowForm.ContainsKey(_waiteList[i]))
                    {
                        var form = _dicPreShowForm[_waiteList[i]];
                        if (form != null && form.transform.parent != _uiRoot.transform)
                        {
                            form.transform.parent = _uiRoot.transform;
                            UnityUtils.Reset(form.transform);
                            _dicPreShowForm.Remove(_waiteList[i]);
                            _waiteList.RemoveAt(i);
                            _waitResetForms.Add(form.name);
                            //刷新界面的层级
                            form.SendMessage("RefreshPanelDepth", SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
                //GameObject.Destroy(_root);
                return true;
            }
            else
            {
                if (_root == null)
                {
                    var trans = AppRoot.Transform.Find(_rootName);
                    if (trans)
                    {
                        _root = trans.gameObject;
                    }
                    else
                    {
                        return false;
                    }
                }
                for (int i = _root.transform.childCount - 1; i >= 0; i--)
                {
                    var child = _root.transform.GetChild(i);
                    if (child)
                    {
                        if (child.parent != _uiRoot.transform)
                        {
                            child.parent = _uiRoot.transform;
                            UnityUtils.Reset(child);
                            child.SendMessage("RefreshPanelDepth", SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
                return false;
            }
        }
        public void SetForm(string name, GameObject form)
        {
            _dicPreShowForm[name] = form;
            if (!string.Equals(name, "UIGuideForm"))
            {
                _dicPreShowForm[name].transform.parent = _root.transform;
            }
        }
        public void RefreshNoticeAndCurveScreen()
        {
            for (int i = 0; i < _waitResetForms.Count; ++i)
            {
                GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_REFRESH_NOTCHANDCURVESCREEN, _waitResetForms[i]);
            }
            _waitResetForms.Clear();
        }

        public void Update()
        {
            if (_waiteList.Count > 0)
            {
                for (int i = _waiteList.Count - 1; i >= 0; i--)
                {
                    if (_dicPreShowForm[_waiteList[i]] == null)
                    {
                        GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_SETPRELOADFORM, _waiteList[i]);
                    }
                }
            }
        }

        public List<string> GetPreLoadFormNames()
        {
            return _waiteList;
        }
        #endregion

        private void OpenForm()
        {
            GameCenter.PushFixEvent(LogicEventDefine.EID_EVENT_OPENPRELOADFORM, _waiteList);
        }

    }
}
