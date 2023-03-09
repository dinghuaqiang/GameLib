namespace Code.Logic.System
{
    /// <summary>
    /// 整体游戏状态的ID
    /// </summary>
    public enum GameStateId
    {
        None = -1,
        AppUpdateCheck = 0,         //更新检测
        Login,                      //登陆,创建角色,选择角色
        SceneLoading,               //场景加载
        World,                      //世界状态
        Reservered,                 //保留
        PreLoad,                    //资源预加载
        RetToLogin,                 //返回到Login    
        RetToUpdate,                //返回到Update
        Count
    }
}
