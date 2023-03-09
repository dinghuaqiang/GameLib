using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 自定日志的监听器
    /// </summary>
    public class LoggerListener
    {
        //是否进行拦截Unity的日志
        public static bool IsEnabled = true;

        //写日志
        private ILogWriter _writer = null;

        public LoggerListener(ILogWriter writer)
        {
            _writer = writer;
        }      
        public void Start()
        {
            if (IsEnabled)
            {
                FLogger.LoggerCallBack = LoggerCallBack;
            }
        }

        public void Stop()
        {
            if (IsEnabled)
            {
                if (FLogger.LoggerCallBack == LoggerCallBack)
                {
                    FLogger.LoggerCallBack = null; 
                }                
            }
        }

        private void LoggerCallBack(bool isInfo,string msg)
        {
            if (isInfo)
            {
                _writer.AddInfo(msg);
            }
            else
            {
                _writer.AddError(msg); 
            }
        }
        
    }
}
