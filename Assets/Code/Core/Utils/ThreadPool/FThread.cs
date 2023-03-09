using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameLib.Core.Utils
{
    public class FThread
    {
        private Thread _thread;
        private Switcher _switcher = new Switcher();

        private Action<Switcher> _func;

        private bool _isRunning = false;

        public bool IsStopped()
        {
            return _thread == null || !_isRunning;
        }

        public void Start(Action<Switcher> func)
        {
            Stop();
            _func = func;
            _switcher.On = true;
            _thread = new Thread(new ThreadStart(OnExecute));
            _thread.Start();
        }

        public void Stop()
        {   
            _switcher.On = false;
            Thread.Sleep(300);
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }
            _isRunning = false;
        }

        private void OnExecute()
        {
            try
            {
                _isRunning = true;
                if (_func != null)
                {
                    _func(_switcher);
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogException(ex);
            }
            finally {
                _isRunning = false;
                _thread = null;
            }
        }

        //创建一个线程开关的类
        public class Switcher
        {
            public bool On { get; set; }
        }
    }
}
