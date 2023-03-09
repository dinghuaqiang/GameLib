using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// Unity日志监听
    /// </summary>
    public class LogUnityListener
    {
        //是否进行拦截Unity的日志
        public static bool IsEnabled = true;

        //字符变量
        private static string _strSymbol = ">>";
        
        //写日志
        private ILogWriter _writer = null;
        //字符串组合
        private StringBuilder _sb = new StringBuilder();

        public LogUnityListener(ILogWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// 实际上接入了bugly的sdk就已经注册了新的log回调函数，这里
        /// 再注册可能会造成冲突，所以先屏蔽掉
        /// </summary>
        public void Start()
        {
            
            {
                Application.logMessageReceived += (LogCallback);
            }
        }

        public void Stop()
        {
            {
                Application.logMessageReceived -= LogCallback;
            }
        }

        public void LogCallback(string condition, string stackTrace, LogType type)
        {
            _sb.Remove(0, _sb.Length);
            _sb.Append(condition);
            _sb.AppendLine(_strSymbol);
            _sb.Append(stackTrace);

            if (type == LogType.Error)
            {
                _writer.AddError(_sb.ToString());
            }
            else if (type == LogType.Exception)
            {
                _writer.AddError(_sb.ToString()); 
            }
            else if (type == LogType.Assert)
            {
                _writer.AddError(_sb.ToString());  
            }
            else
            {
                _writer.AddInfo(_sb.ToString());
            }            
        }
    }
}
