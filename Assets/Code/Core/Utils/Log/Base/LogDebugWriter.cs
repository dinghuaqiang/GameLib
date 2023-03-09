using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 输出
    /// </summary>
    public class LogDebugWriter : ILogWriter
    {
        
        public void AddError(string message)
        {   
            UnityEngine.Debug.LogError(message);
        }

        public void AddInfo(string message, string gName = null)
        {
            UnityEngine.Debug.Log(message);
        }

        public void Start()
        {
          
        }


        public void Stop()
        {
            
        }

        public void Flush()
        {
           
        }

        public void Pause()
        {
            
        }

        public void Resume()
        {
            
        }
    }
}
