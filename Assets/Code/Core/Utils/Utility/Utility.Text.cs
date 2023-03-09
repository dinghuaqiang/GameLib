using System;
using System.Text;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 字符串工具类
        /// </summary>
        public static class Text 
        {
            private static StringBuilder _stringBuilderCache = new StringBuilder(1024);

            /// <summary>
            /// 是否包含字符串验证
            /// </summary>
            /// <param name="context">传入的内容</param>
            /// <param name="values">需要检测的字符数组</param>
            /// <returns>是否包含</returns>
            public static bool Contains(string context, string[] values)
            {
                var length = values.Length;
                for (int i = 0; i < length; i++)
                {
                    if (context.Contains(values[i]))
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// 分割字符串
            /// </summary>
            /// <param name="fullString">分割字符串</param>
            /// <param name="separator">new string[]{"."}</param>
            /// <returns>分割后的字段数组</returns>
            public static string[] StringSplit(string fullString, string[] separator)
            {
                string[] stringArray = null;
                stringArray = fullString.Split(separator, StringSplitOptions.None);
                return stringArray;
            }

            /// <summary>
            /// 分割字符串
            /// </summary>
            /// <param name="fullString">完整字段</param>
            /// <param name="separator">new string[]{"."}</param>
            /// <param name="count">要返回的子字符串的最大数量</param>
            /// <param name="removeEmptyEntries">是否移除空实体</param>
            /// <returns>分割后的字段</returns>
            public static string StringSplit(string fullString, string[] separator, int count, bool removeEmptyEntries)
            {
                string[] stringArray = null;
                if (removeEmptyEntries)
                    stringArray = fullString.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                else
                    stringArray = fullString.Split(separator, count, StringSplitOptions.None);
                return stringArray.ToString();
            }

            /// <summary>
            /// 是否是一串数字类型的string
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public static bool IsNumberStr(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsNumber(str[i])) return false;
                }
                return true;
            }

            /// <summary>
            /// 追加字符串
            /// </summary>
            /// <param name="args"></param>
            public static string Append(params object[] args)
            {
                if (args == null)
                {
                    throw new ArgumentNullException("Append is invalid.");
                }
                _stringBuilderCache.Length = 0;
                int length = args.Length;
                for (int i = 0; i < length; i++)
                {
                    _stringBuilderCache.Append(args[i]);
                }
                return _stringBuilderCache.ToString();
            }

            /// <summary>
            /// 字段合并；
            /// </summary>
            /// <param name="strings">字段数组</param>
            /// <returns></returns>
            public static string Combine(params string[] strings)
            {
                if (strings == null)
                {
                    throw new ArgumentNullException("Combine is invalid, strings is null.");
                }
                _stringBuilderCache.Length = 0;
                int length = strings.Length;
                for (int i = 0; i < length; i++)
                {
                    _stringBuilderCache.Append(strings[i]);
                }
                return _stringBuilderCache.ToString();
            }

            /// <summary>
            /// 字符串的字符数
            /// </summary>
            /// <param name="fullString"></param>
            /// <param name="separator"></param>
            public static int CharCount(string fullString, char separator)
            {
                if (string.IsNullOrEmpty(fullString) || string.IsNullOrEmpty(separator.ToString()))
                {
                    throw new ArgumentNullException("charCount \n string invaild!");
                }
                int count = 0;
                for (int i = 0; i < fullString.Length; i++)
                {
                    if (fullString[i] == separator)
                    {
                        count++;
                    }
                }
                return count;
            }

            /// <summary>
            /// 获取内容在UTF8编码下的字节长度；
            /// </summary>
            /// <param name="context">需要检测的内容</param>
            /// <returns>字节长度</returns>
            public static int GetUTF8Length(string context)
            {
                return Encoding.UTF8.GetBytes(context).Length;
            }

            /// <summary>
            /// 获取字符串的bytes数据
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            public static byte[] GetStringBytes(string context) 
            {
                if (string.IsNullOrEmpty(context))
                {
                    DevLog.LogError("字符串是空的，自己检查哈哦！");
                    return null;
                }
                return Encoding.UTF8.GetBytes(context);
            }

            /// <summary>
            /// 多字符替换
            /// </summary>
            /// <param name="context">需要修改的内容</param>
            /// <param name="oldContext">需要修改的内容</param>
            /// <param name="newContext">修改的新内容</param>
            /// <returns>修改后的内容</returns>
            public static string Replace(string context, string[] oldContext, string newContext)
            {
                if (string.IsNullOrEmpty(context))
                    throw new ArgumentNullException("context is invalid.");
                if (oldContext == null)
                    throw new ArgumentNullException("oldContext is invalid.");
                if (string.IsNullOrEmpty(newContext))
                    throw new ArgumentNullException("newContext is invalid.");
                var length = oldContext.Length;
                for (int i = 0; i < length; i++)
                {
                    context = context.Replace(oldContext[i], newContext);
                }
                return context;
            }
        }
    }
}
