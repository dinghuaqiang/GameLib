using GameLib.Core.FSM;

namespace Code.Logic.System
{
    /// <summary>
    /// 状态系统接口
    /// </summary>
    public interface IStateSystem
    {
        /// <summary>
        /// 获取状态machine
        /// </summary>
        /// <returns></returns>
        FiniteStateMachine Fsm { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
        /// <summary>
        /// 反初始化
        /// </summary>
        void UnInitialize();
        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        IGameState GetCurState();
        /// <summary>
        /// 获取前一游戏状态
        /// </summary>
        /// <returns></returns>
        IGameState GetPrevState();
        /// <summary>
        /// 获取后一游戏状态
        /// </summary>
        /// <returns></returns>
        IGameState GetNextState();
        /// <summary>
        /// 通过状态id获取游戏状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IGameState GetStateById(int id);
        /// <summary>
        /// 切换游戏状态
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="arg"></param>
        void ChangeState(int stateId, object arg = null);

        /// <summary>
        /// 是否是当前状态
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        bool IsCurState(int stateID);
        /// <summary>
        /// 处理状态消息
        /// </summary>
        /// <param name="msg"></param>
        void HandlerMessage(object msg);

        void Update(float dt);
    }
}
