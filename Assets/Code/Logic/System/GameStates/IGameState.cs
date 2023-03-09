namespace Code.Logic.System
{
    /// <summary>
    /// 游戏状态操作接口
    /// </summary>
    public interface IGameState
    {

        /// <summary>
        /// 游戏状态参数
        /// </summary>
        object Arg { get; set; }
        /// <summary>
        /// 获取游戏状态ID
        /// </summary>
        /// <returns></returns>
        int GetStateId();
        /// <summary>
        /// 检查是否可以切换状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool Check(IGameState state);
        /// <summary>
        /// 加载--这里对状态进行内部初始化
        /// </summary>
        void Load();
        /// <summary>
        /// 释放
        /// </summary>
        void Release();
        /// <summary>
        /// 进入状态
        /// </summary>
        void Enter();
        void Leave();
        void Suspend();
        void Resume();
        /// <summary>
        /// 状态的心跳处理
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        bool Update(float deltaTime);
        /// <summary>
        /// 状态的渲染处理
        /// </summary>
        /// <returns></returns>
        bool Render();
        /// <summary>
        /// 处理消息
        /// </summary>
        void HandlerMessage(object msg);

        /// <summary>
        /// 当前是否被激活
        /// </summary>
        bool IsActived { get; }
    }
}
