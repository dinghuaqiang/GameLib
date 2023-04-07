namespace GameLib.Core.Event
{
    /// <summary>
    /// 逻辑事件的ID定义 
    /// 这些消息与UI消息的区别是:不会导致UI预制的加载
    /// 注意:EID_BASE + {这个数不可以超过100000}
    /// </summary>
    public enum LogicEventDefine
    {
        //消息ID基础
        EID_BASE = EventDefines.EVENT_LOGIC_BASE_ID,

        //系统消息=========================================
        //GameCenter,内核初始化完毕
        EID_GAMECENTER_LOGIC_NEW,
        //开始初始化
        EID_GAMECENTER_LOGIC_START_INITIALIZE,
        //GameCenter,卸载完毕
        EID_GAMECENTER_LOGIC_UNINITIALIZED,
        //GameCenter，profiler事件注册
        EID_GAMECENTER_LOGIC_PROFILER,
        //网络,登录以及SDK相关消息,===============================
        //登录SDK成功
        EID_EVENT_SDK_LOGIN_SUCCESS,
        //登录游戏成功        
        EID_EVENT_GAME_LOGIN_SUCCESS,
        //登录场景准备完毕
        EID_EVENT_LOGINSCENE_READYOK,
        //进入登录状态
        EID_EVENT_ENTER_LOGINSTATE,
        //离开登录状态
        EID_EVENT_LEAVE_LOGINSTATE,
        //断线重连
        EID_EVENT_RECONNECT,
        //关闭所有的窗体
        EID_EVENT_CLOSE_ALL_FORM,
        //卸载所有的窗体资源
        EID_EVENT_CLEAR_ALL_FORM_ASSET,
        //暂时挂起和恢复所有的窗体
        EID_EVENT_SUSPEND_ALL_FORM,
        EID_EVENT_RESUME_ALL_FORM,
        //挂起和恢复UIFormManager的消息系统 --- 这两个事件要慎用
        //这两个事件只用于返回登录以及返回更新的处理里,其他地方不要用
        EID_EVENT_SUSPEND_FORM_EVENT_SYSTEM,
        EID_EVENT_RESUME_FORM_EVENT_SYSTEM,
        //显示和隐藏所有UI摄像机
        EID_EVENT_SHOWALL_UICAMERA,
        EID_EVENT_HIDEALL_UICAMERA,
        //关闭当前的全屏界面
        EID_EVENT_HIDE_CURFULLSCREEN_FORM,
        //关闭当前界面
        EID_EVENT_HIDE_CURRENT_FORM,
        //设置预加载form
        EID_EVENT_SETPRELOADFORM,
        //打开预加载form
        EID_EVENT_OPENPRELOADFORM,
        //曲面屏缩放设置改变
        EID_CURVEDSCREENSCALE_CHANGE,
        //打印NGUI缓存信息
        //EID_NGUI_PRINTCACHE_INFO,
        //UIPanel填充频率改变
        EID_PANEL_FILLDRAWCALLRATE_CHANGED,
        //enable摄像机后处理脚本
        EID_EVENT_ENABLE_CAMERA_POSTEFFECT,
        //disable摄像机后处理脚本
        EID_EVENT_DISABLE_CAMERA_POSTEFFECT,
        //重新刷新刘海和曲面屏界面
        EID_EVENT_REFRESH_NOTCHANDCURVESCREEN,
        //刘海屏设置改变
        EID_NOTCHSHOW_CHANGED,
        //关闭所有UI
        EID_EVENT_HIDEALLUI,
        //柔体效果改变
        EID_EVENT_SOFTBONE_ENABLE_CHANGED,
        //所有窗体挂起或者恢复之后的处理
        EID_EVENT_ON_SUSPEND_ALL_FORM_AFTER,
        EID_EVENT_ON_RESUME_ALL_FORM_AFTER,
        //当某个窗体关闭或者显示时,发送的消息
        EID_EVENT_FORM_SHOW_AFTER,
        EID_EVENT_FORM_CLOSE_AFTER,
        //某个窗体关闭或者显示时,发送他的窗体ID,也就是UIConfig中的ID
        EID_EVENT_FORM_ID_SHOW_AFTER,
        EID_EVENT_FORM_ID_CLOSE_AFTER,
    }
}
