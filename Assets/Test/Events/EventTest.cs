using GameLib.Core.Event;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            //注册
            EventManager.SharedInstance.RegEventHandle(EventDefines.EID_UI_UILoginForm_OPEN, OnLoginFormOpen);
        }

        private void Start()
        {
            EventManager.SharedInstance.PushEvent(EventDefines.EID_UI_UILoginForm_OPEN, "开始登陆", null);
        }

        void OnLoginFormOpen(object param, object sender)
        {
            //TODO 发消息给服务器请求数据
            if (param != null)
            {
                //Debug.Log(param.ToString());
            }
        }

        private void OnDisable()
        {
            //注销
            EventManager.SharedInstance.UnRegEventHandle(EventDefines.EID_UI_UILoginForm_OPEN, OnLoginFormOpen);
        }
    }
}
