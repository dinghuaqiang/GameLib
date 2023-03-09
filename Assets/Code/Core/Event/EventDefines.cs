namespace GameLib.Core.Event
{
    /// <summary>
    /// 事件消息的定义
    /// </summary>
    public class EventDefines
    {
        //基础ID
        public const int EVENT_CORE_BASE_ID = 0;
        //逻辑ID
        public const int EVENT_LOGIC_BASE_ID = 100000;
        //UI ID
        public const int EVENT_UI_BASE_ID = 200000;
        //....还可以加一些其他的事件基础ID，比如处理SDK，资源加载，LUA调用

        //基础消息，类似场景切换...
        public const int EID_CORE_SCENE_CHANGE = EVENT_CORE_BASE_ID + 101;
        //UI消息，类似开关登陆界面...
        public const int EID_UI_UILoginForm_OPEN = EVENT_UI_BASE_ID + 101;
        public const int EID_UI_UILoginForm_CLOSE = EVENT_UI_BASE_ID + 109;
        //逻辑消息，类似登陆界面的数据刷新...
        public const int EID_LOGIC_LOGIN_SUCC = EVENT_LOGIC_BASE_ID + 101;
        public const int EID_LOGIC_LOGIN_FAIL = EVENT_LOGIC_BASE_ID + 102;
    }
}
