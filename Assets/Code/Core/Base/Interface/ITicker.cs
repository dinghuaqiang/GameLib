namespace GameLib.Core.Base
{
    /// <summary>
    /// 实现心跳的接口
    /// </summary>
    public interface ITicker
    {
        void Start();
        //更新
        void Update(float deltaTime);
        //卸载
        void Destory();
        //是否有效
        bool IsValid();
    }
}
