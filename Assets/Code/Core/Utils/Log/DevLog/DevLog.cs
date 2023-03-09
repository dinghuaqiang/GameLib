using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日常开发可用的调试日志
    /// </summary>
    public static class DevLog
    {
        /// <summary>
        /// 日志开关
        /// </summary>
        public static bool IS_SHOW_LOG = true; 

        public static void LogWithColor(string msg, Color color)
        {
            if (!IS_SHOW_LOG) { return; }
            string logColor = ColorUtility.ToHtmlStringRGB(color);
            Debug.LogFormat("<color=#{0}>{1}</color>", logColor, msg);
        }

        /// <summary>
        /// 自己传颜色
        /// </summary>
        /// <param name="msg">打印的日志内容</param>
        /// <param name="defineColor">传入ColorDefines的具体颜色值</param>
        public static void LogWithColor(string msg, string defineColor)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogFormat("<color={0}>{1}</color>", defineColor, msg);
        }

        public static void Log(string msg)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.Log(msg);
        }

        public static void LogGreen(string msg)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogFormat("<color={0}>{1}</color>", ColorDefines.Green, msg);
        }

        public static void LogRed(string msg)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogFormat("<color={0}>{1}</color>", ColorDefines.Red, msg);
        }

        public static void LogBlue(string msg)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogFormat("<color={0}>{1}</color>", ColorDefines.Blue, msg);
        }

        public static void LogError(string msg) 
        {
            Debug.LogError(msg);
        }

        public static void LogErrorFormat(string format, params object[] args)
        {
            Debug.LogErrorFormat(format, args);
        }
    }
}
