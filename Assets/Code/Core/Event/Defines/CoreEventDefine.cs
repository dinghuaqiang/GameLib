namespace GameLib.Core.Event
{
    /// <summary>
    /// 内核消息定义
    /// </summary>
    public class CoreEventDefine
    {
        //基础
        private const int EID_BASE = EventDefines.EVENT_CORE_BASE_ID;

        /// <summary>
        ///当时间区间发生改变,有DayTimeSpanManager触发
        /// </summary>
        public const int EID_CORE_DAY_TIMESPAN_CHANGED = EID_BASE + 1;

        //帧率等级变化
        public const int EID_CORE_FPS_LEVEL_CHANGED = EID_BASE + 3;

        //摄像机属性改变消息
        public const int EID_EVENT_CAMERAFOLLOWDIS_CHANGED = EID_BASE + 4;
        public const int EID_EVENT_CAMERAYAW_CHANGED = EID_BASE + 5;
        public const int EID_EVENT_CAMERAPITCH_CHANGED = EID_BASE + 6;
        public const int EID_EVENT_CAMERALOCKSTATE_CHANGED = EID_BASE + 7;

        //检查文件路径的请求
        public const int EID_CORE_CHECK_FILE_PATH_REQ = EID_BASE + 8;
        //检查文件路径的结果的回答
        public const int EID_CORE_CHECK_FILE_PATH_RESP = EID_BASE + 9;

        //有一个FGameObject对象下载完毕
        public const int EID_CORE_FGAMEOBJECT_LOAD_FINISHED = EID_BASE + 10;

        //特效的显示等级发生改变
        public const int EID_CORE_VFX_LEVEL_CHANGED = EID_BASE + 11;

        //实体对象移除
        public const int EID_CORE_ENTITY_CONTAINER_REMOVE = EID_BASE + 12;
        //实体对象增加
        public const int EID_CORE_ENTITY_CONTAINER_ADD = EID_BASE + 13;
        //实体对象清除
        public const int EID_CORE_ENTITY_CONTAINER_CLEAR = EID_BASE + 14;

        //检查文件是否有效的同步请求,它的参数是一个回调函数
        public const int EID_CORE_CHECK_FILE_IS_VALID_SYN_REQ = EID_BASE + 15;

        //游戏设置被改变的消息
        public const int EID_CORE_GAME_SETTING_CHANGED = EID_BASE + 16;
        //角色设置被改变
        public const int EID_CORE_GAME_ROLE_SETTING_CHANGED = EID_BASE + 17;

        //全局显示提示的消息
        public const int EID_CORE_GLOBAL_SHOW_MESSAGE_BOX = EID_BASE + 18;

        //重启游戏的消息
        public const int EID_CORE_RESTART_GAME = EID_BASE + 19;

        public const int EID_CORE_FIX_MSG_LIST = EID_BASE + 100;
        public const int EID_CORE_FIX_MSG_LIST_RETURN = EID_BASE + 101;
        //打开UniWebView网页
        public const int EID_EVENT_SHOW_UNIWEBVIEW = EID_BASE + 102;

        //客户端打点系统
        public const int EID_CORE_RECORD_BEHAVIOR = EID_BASE + 105;

        //资源转移开始的统计
        public const int EID_CORE_DATA_RES_TRANS_START = EID_BASE + 106;
        //资源转移完成的统计
        public const int EID_CORE_DATA_RES_TRANS_FINISHED = EID_BASE + 107;
        //资源下载开始的统计
        public const int EID_CORE_DATA_RES_DOWNLOAD_START = EID_BASE + 108;
        //资源下载完成的统计
        public const int EID_CORE_DATA_RES_DOWNLOAD_FINISHED = EID_BASE + 109;
    }
}
