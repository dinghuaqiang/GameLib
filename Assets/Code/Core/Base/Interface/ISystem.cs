namespace GameLib.Core.Base
{
    public interface ISystem
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
        /// <summary>
        /// 反初始化，卸载数据
        /// </summary>
        void UnInitialize();
        /// <summary>
        /// Tick更新
        /// </summary>
        void Update(float deltaTime);
    }
}
