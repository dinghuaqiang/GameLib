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
        //SDK消息的基础ID
        public const int EVENT_SDK_BASE_ID = 300000;

        //资源预加载的基础ID
        public const int EVENT_PRELOAD_BASE_ID = 400000;

        //PVP操作的基础ID
        public const int EVENT_PVP_BASE_ID = 500000;

        //虚拟机事件ID
        public const int EVENT_VM_BASE_ID = 600000;

        //lua的逻辑消息基础ID
        public const int EVENT_LUA_LOGIC_BASE_ID = 700000;

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
