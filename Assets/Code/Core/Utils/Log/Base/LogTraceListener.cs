using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志跟踪的监听器
    /// </summary>
    public class LogTraceListener
#if !UNITY_WEBPLAYER
        : TraceListener
#endif
    {        
        private static string _strSymbol_0 = "TRACE";
        private static string _strSymbol = ">>";
        private static string _splitSymbol4 = "TickCount:[";
        private static string _splitSymbol5 = "]";

        private ILogWriter _writer = null;
        private StringBuilder _sb = new StringBuilder();

        public LogTraceListener(ILogWriter writer)
        {
            _writer = writer;
        }

        #region//Error
        public
#if !UNITY_WEBPLAYER
            override 
#endif
 void Fail(string message)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(message);
            _writer.AddError(_sb.ToString());            
        }

        public 
#if !UNITY_WEBPLAYER
            override 
#endif 
            void Fail(string message, string detailMessage)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(message);
            _sb.Append(_strSymbol);
            _sb.Append(detailMessage);
            _writer.AddError(_sb.ToString());  
        }
        #endregion

        #region//Write
        public
#if !UNITY_WEBPLAYER
        override
#endif
        void Write(string message, string category)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(message);
            _writer.AddInfo(_sb.ToString(), category);
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void Write(object o, string category)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(o as string);
            _writer.AddInfo(_sb.ToString(), category);
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void Write(string message)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(message);
            _writer.AddInfo(_sb.ToString());
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void Write(object o)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(o as string);
            _writer.AddInfo(_sb.ToString());
        }
        #endregion

        #region//WriteLine        

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void WriteLine(string message, string category)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(message);
            _writer.AddInfo(_sb.ToString(), category);
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void WriteLine(object o, string category)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(o as string);
            _writer.AddInfo(_sb.ToString(), category);
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void WriteLine(object o)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(o as string);
            _writer.AddInfo(_sb.ToString());
        }

        public
#if !UNITY_WEBPLAYER
        override
#endif
        void WriteLine(string message)
        {
            _sb.Remove(0, _sb.Length);
            WriteTimeStamp(_sb);
            _sb.Append(_strSymbol_0);
            _sb.Append(_strSymbol);
            _sb.Append(message);
            _writer.AddInfo(_sb.ToString());
        }      
        #endregion

        private static void WriteTimeStamp(StringBuilder theSB)
        {
            theSB.Append(_splitSymbol4);
            theSB.Append(Environment.TickCount);
            theSB.Append(_splitSymbol5);
        }
    }
}
