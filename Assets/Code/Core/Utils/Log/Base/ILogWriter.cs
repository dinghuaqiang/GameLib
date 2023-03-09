namespace GameLib.Core.Utils
{
    //新日志的接口
    public interface ILogWriter
    {
        void AddError(string message);
        void AddInfo(string message, string gName = null);
        void Start();
        void Stop();
        void Flush();
        void Pause();
        void Resume();
    }
}
