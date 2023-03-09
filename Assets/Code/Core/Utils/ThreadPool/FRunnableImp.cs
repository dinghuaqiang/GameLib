using System;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 线程池的一个简单实现
    /// </summary>
    public class FRunnableImp  : FRunnable
    {
        Action<object> _handler;
        object _param;

        public FRunnableImp(Action<object> handler ,object param)
        {
            _handler = handler;
            _param = param;
        }

        public override void Run()
        {
            try
            {
                if (_handler != null)
                {
                    _handler(_param);
                }
            }
            catch(Exception ex)
            {
                UnityEngine.Debug.LogException(ex);
            }
        }
    }
}
