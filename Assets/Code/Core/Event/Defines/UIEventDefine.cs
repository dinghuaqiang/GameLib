namespace GameLib.Core.Event
{
    /// <summary>
    /// 固定事件名称定义
    /// 定义窗体事件潜规则:
    /// 1.关闭事件ID的定义 :事件ID % 10 == 9 ,也就是ID:19,29,....229等
    /// 2.每个窗体操作事件不能多于10个.
    /// 注意:{这个数不可以超过100000} + EventConstDefine.EVENT_UI_BASE_ID
    /// </summary>
    public enum UIEventDefine
    {
        //主界面窗体的打开关闭
        UIMainForm_OPEN  = EventDefines.EVENT_UI_BASE_ID + 10,
        UIMainForm_CLOSE = EventDefines.EVENT_UI_BASE_ID + 19,

        //登录窗体
        UILOGINFORM_OPEN               = EventDefines.EVENT_UI_BASE_ID + 50,
        //切换账号
        UILOGINFORM_SWITCHACCOUNT_OPEN = EventDefines.EVENT_UI_BASE_ID + 51,
        //返回到服务器界面
        UILOGINFORM_ENTERGAME_OPEN     = EventDefines.EVENT_UI_BASE_ID + 52,
        //显示登录失败信息：未到开服时间
        UILOGINFORM_SHOWLOGINFAILPANEL = EventDefines.EVENT_UI_BASE_ID + 53,
        UILOGINFORM_CLOSE              = EventDefines.EVENT_UI_BASE_ID + 59,
    }
}
