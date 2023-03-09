namespace GameLib.Core.UI
{
    /// <summary>
    /// 窗体的显示层级
    /// </summary>
    public enum UIFormRegion : int
    {
        NoticeRegion = 400,     //提示消息层界面，类似删除物品，跑马灯，通知等
        TopRegion    = 200,     //普通的顶层界面
        MiddleRegion = 0,       //主要功能的界面层级
        MainRegion   = -200,    //主界面层
        BottomRegion = -400,    //类似于HUD的一些低等级层级
    }
}
