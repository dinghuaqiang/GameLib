using System.Text;
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

        private static StringBuilder _sb = new StringBuilder();

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

        public static void LogFormat(string format, params object[] args)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogFormat(format, args);
        }

        public static void LogWarning(string msg)
        {
            if (!IS_SHOW_LOG) { return; }
            Debug.LogWarning(msg);
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

        public static void LogError(params object[] msg)
        {
            lock (_sb)
            {
                if (msg != null)
                {
                    _sb.Remove(0, _sb.Length);
                    for (int i = 0; i < msg.Length; i++)
                    {
                        _sb.Append(msg[i]);
                    }
                    Debug.LogError(_sb.ToString());
                }
            }
        }

        public static void LogErrorFormat(string format, params object[] args)
        {
            Debug.LogErrorFormat(format, args);
        }
    }
}
