using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GameLib.Core.Utils
{
    //日志回调的委托
    public delegate void LoggerCallBackDelegate(bool isInfo, string msg);

    /// <summary>
    /// 日志记录者,自定义接口用于记录日志的接口
    /// </summary>
    public class FLogger
    {
        #region//静态变量
        //定义的常量字符串
        private static string _splitSymbol0 = "Assert(false)!";
        private static string _splitSymbol1 = "  ";
        private static string _splitSymbol2 = "NULL";
        private static string _splitSymbol3 = "Debug:";

        private static string _splitSymbol4 = "TickCount:[";
        private static string _splitSymbol5 = "]FrameCount:[";
        private static string _splitSymbol6 = "]";
        private static string _splitSymbol7 = "[";
        private static string _splitSymbol8 = ";";

        //用于合并字符串的StringBuilder
        private static StringBuilder _sb = new StringBuilder();
        #endregion

        #region//公共变量
        //Logger日志的回调操作 -- 只允许本dll内的引用
        internal static LoggerCallBackDelegate LoggerCallBack;
        #endregion

        #region//构造函数
        static FLogger()
        {
            FLogManager.Instance.Initialize();
        }
        #endregion

        #region//正常日志

        #region//断言
        public static void Assert(bool condition, params object[] args)
        {
            //当返回false的时候,才会写错误
            if (!condition)
            {  
                DoCallBack(false, Combine(_splitSymbol0, args));
            }
        }
        #endregion

        #region //日志

        #region//时间,帧信息 日志
        
        public static void LogTime(string arg)
        {
            DoCallBack(true,Combine(arg));
        }

        #endregion
        public static void Log(string arg)
        {
            DoCallBack(true, Combine(arg));
        }
        
        public static void Log(params object[] args)
        {
            DoCallBack(true, Combine(args));
        }
        
        public static void LogFormat(string formatStr, params object[] args)
        {
            DoCallBack(true, Combine(string.Format(formatStr, args)));
        }
        #endregion

        #region //警告日志
        
        public static void LogWarning(string arg)
        {
            DoCallBack(true, Combine(arg));
        }
        
        public static void LogWarning(params object[] args)
        {
            DoCallBack(true, Combine(args));
        }
        
        public static void LogWarningFormat(string formatStr, params object[] args)
        {
            DoCallBack(true, Combine(string.Format(formatStr, args)));
        }
        #endregion

        #region //错误日志

        
        public static void LogError(string arg)
        {
            DoCallBack(false, Combine(arg));
        }
        
        public static void LogError(params object[] args)
        {
            DoCallBack(false, Combine(args));
        }

        
        public static void LogErrorFormat(string formatStr, params object[] args)
        {
            DoCallBack(false, Combine(string.Format(formatStr, args)));
        }
        #endregion

        #region //异常日志
        
        public static void LogException(Exception e)
        {
            DoCallBack(false, Combine(e.Message,e.Source,e.StackTrace.Trim(),e.StackTrace));            
        }
        #endregion

        #endregion

        #region //调试用日志接口

        #region//断言
        //调试接口检测
        [Conditional("ASSERT")]
        public static void DebugAssert(bool condition, params object[] args)
        {
            //当返回false的时候,才会写错误
            if (!condition)
            {
                Debug.Assert(condition, CombineDebug(_splitSymbol0, args));
            }
        }
        #endregion

        #region//时间,帧信息 日志
        [Conditional("ASSERT")]
        public static void DebugLogTime(string arg)
        {
            UnityEngine.Debug.Log(CombineDebug(_splitSymbol4, Environment.TickCount, _splitSymbol5, UnityEngine.Time.frameCount, _splitSymbol6, arg));
        }

        #endregion

        #region //调试接口日志
        [Conditional("ASSERT")]
        public static void DebugLog(string arg)
        {
            UnityEngine.Debug.Log(CombineDebug(arg));
        }
        [Conditional("ASSERT")]
        public static void DebugLog(params object[] args)
        {
            UnityEngine.Debug.Log(CombineDebug(args));
        }

        [Conditional("ASSERT")]
        public static void DebugLogFormat(string formatStr, params object[] args)
        {
            UnityEngine.Debug.Log(CombineDebug(string.Format(formatStr, args)));
        }
        #endregion

        #region //调试接口警告日志
        [Conditional("ASSERT")]
        public static void DebugLogWarning(string arg)
        {
            UnityEngine.Debug.LogWarning(CombineDebug(arg));
        }
        [Conditional("ASSERT")]
        public static void DebugLogWarning(params object[] args)
        {
            UnityEngine.Debug.LogWarning(CombineDebug(args));
        }

        [Conditional("ASSERT")]
        public static void DebugLogWarningFormat(string formatStr, params object[] args)
        {
            UnityEngine.Debug.LogWarning(CombineDebug(string.Format(formatStr, args)));
        }
        #endregion

        #region //调试接口错误日志

        [Conditional("ASSERT")]
        public static void DebugLogError(string arg)
        {
            UnityEngine.Debug.LogError(CombineDebug(arg));
        }
        [Conditional("ASSERT")]
        public static void DebugLogError(params object[] args)
        {
            UnityEngine.Debug.LogError(CombineDebug(args));
        }

        [Conditional("ASSERT")]
        public static void DebugLogErrorFormat(string formatStr, params object[] args)
        {
            UnityEngine.Debug.LogError(CombineDebug(string.Format(formatStr, args)));
        }
        #endregion

        #region //调试接口异常日志
        [Conditional("ASSERT")]
        public static void DebugLogException(Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }
        #endregion

        #endregion

        #region//TRACE日志,具有多线程安全性
        [Conditional("TRACE")]
        public static void TraceWrite(string msg)
        {
#if !UNITY_WEBGL
            System.Diagnostics.Trace.Write(msg); 
#else
            FLogManager.Instance.Listener.Write(msg);
#endif
        }

        [Conditional("TRACE")]
        public static void TraceFail(string msg)
        {
#if !UNITY_WEBGL

            System.Diagnostics.Trace.Fail(msg);
#else
            FLogManager.Instance.Listener.Fail(msg);
#endif
        }
        [Conditional("TRACE")]
        public static void TraceFail(string msg, string detailMessage)
        {
#if !UNITY_WEBGL
            System.Diagnostics.Trace.Fail(msg, detailMessage);
#else
            FLogManager.Instance.Listener.Fail(msg,detailMessage);
#endif
        }
        #endregion

        #region//TRACE日志,具有多线程安全性        
        [Conditional("ASSERT")]
        public static void DebugTraceWrite(string msg)
        {
            System.Diagnostics.Trace.Write(msg);
        }

        [Conditional("ASSERT")]
        public static void DebugTraceFail(string msg)
        {
           System.Diagnostics.Trace.Fail(msg);
        }

        [Conditional("ASSERT")]
        public static void DebugTraceFail(string msg, string detailMessage)
        {
            System.Diagnostics.Trace.Fail(msg, detailMessage);
        }
        #endregion

        #region//私有方法,用于字符串合并操作
        //把对象组合起来
        private static string Combine(params object[] args)
        {
            lock (_sb)
            {
                _sb.Remove(0, _sb.Length);
                WriteTimeStamp(_sb);
                WriteToSB(_sb, args);
                return _sb.ToString();
            }
        }

        
        //把对象组合起来
        private static string Combine(string head,object[] args)
        {
            lock (_sb)
            {
                _sb.Remove(0, _sb.Length);
                WriteTimeStamp(_sb);
                _sb.Append(head);
                WriteToSB(_sb, args);
                return _sb.ToString();
            }
        }
        

        //把对象组合起来
        private static string CombineDebug(params object[] args)
        {
            return Combine(_splitSymbol3,args);
        }

        //把对象组合起来
        private static string CombineDebug(string head, object[] args)
        {
            lock (_sb)
            {
                _sb.Remove(0, _sb.Length);
                WriteTimeStamp(_sb);
                _sb.Append(_splitSymbol3);               
                _sb.Append(head);
                WriteToSB(_sb,args);
                return _sb.ToString();
            }
        }

        private static void WriteTimeStamp(StringBuilder theSB)
        {
            theSB.Append(_splitSymbol4);
            theSB.Append(TimeUtils.GetSystemTicksMS());
            //判断是否为子线程
            if (Thread.CurrentThread == null || !Thread.CurrentThread.IsBackground)
            {
                theSB.Append(_splitSymbol5);
                theSB.Append(UnityEngine.Time.frameCount);
            }
            theSB.Append(_splitSymbol6);
        }

        /// <summary>
        /// 把数组写入到Stringbuilder中
        /// </summary>
        /// <param name="args"></param>
        private static void WriteToSB(StringBuilder theSB,object[] args)
        { 
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)             
                {//如果为NULL,则输入NULL
                    theSB.Append(_splitSymbol2); 
                }
                else if (args[i] is Array)
                {//如果为数组则输出为[sd;sdf;]或者[null]
                    var objs = args[i] as object[];
                    theSB.Append(_splitSymbol7);
                    if (objs != null)
                    {
                        for (int j = 0; j < objs.Length; j++)
                        {
                            if (objs[i] == null)
                            {
                                theSB.Append(_splitSymbol2);
                            }
                            else
                            {
                                theSB.Append(objs[i]);
                            }
                            theSB.Append(_splitSymbol8);
                        }
                    }
                    else
                    {
                        theSB.Append(_splitSymbol2);  
                    }
                    theSB.Append(_splitSymbol6);
                }
                else
                {//直接输出
                    theSB.Append(args[i]); 
                }
                theSB.Append(_splitSymbol1);
            }
 
        }

        private static void DoCallBack(bool isInfo, string msg)
        {
            if (LoggerCallBack != null)
            {
                LoggerCallBack(isInfo, msg); 
            }
 
        }
        #endregion
    }
}
