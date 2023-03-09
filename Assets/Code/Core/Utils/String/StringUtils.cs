using System;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public static class StringUtils
    {

        static StringBuilder _strBuilder = new StringBuilder();
        static byte[] _bytes = new Byte[1024];

        public static StringBuilder StringBuilder
        {
            get
            {
                return _strBuilder;
            }
        }

        public static StringBuilder NewStringBuilder
        {
            get
            {
                _strBuilder.Length = 0;
                return _strBuilder;
            }
        }

        public static void SplitFilename(string qualifiedName, out string outBasename, out string outPath)
        {
            string path = qualifiedName.Replace('\\', '/');
            int i = path.LastIndexOf('/');
            if (i == -1)
            {
                outPath = string.Empty;
                outBasename = qualifiedName;
            }
            else
            {
                outBasename = path.Substring(i + 1, path.Length - i - 1);
                outPath = path.Substring(0, i + 1);
            }
        }

        public static string StandardisePath(string init)
        {
            string path = init.Replace('\\', '/');
            if (path.Length > 0 && path[path.Length - 1] != '/')
            {
                path += '/';
            }
            return path;
        }

        public static string StandardisePathWithoutSlash(string init)
        {
            string path = init.Replace('\\', '/');
            while (path.Length > 0 && path[path.Length - 1] == '/')
            {
                path = path.Remove(path.Length - 1);
            }
            return path;
        }

        /// <summary>
        /// 分割文件名
        /// </summary>
        /// <param name="fullName">文件名的全程</param>
        /// <param name="outBasename">基础文件名</param>
        /// <param name="outExtention">带"."的扩展名 </param>
        public static void SplitBaseFilename(string fullName, out string outBasename, out string outExtention)
        {
            int i = fullName.LastIndexOf('.');
            if (i == -1)
            {
                outExtention = string.Empty;
                outBasename = fullName;
            }
            else
            {
                outExtention = fullName.Substring(i);
                outBasename = fullName.Substring(0, i);
            }
        }

        public static int CountOf(string str, char what)
        {
            int count = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == what)
                {
                    ++count;
                }
            }
            return count;
        }

        public static string SafeFormat(string format, params object[] args)
        {
            if (format != null && args != null)
            {
                try
                {
                    return string.Format(format, args);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.Fail(e.Message, e.StackTrace);
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 分割全路径文件名
        /// </summary>
        /// <param name="qualifiedName">合格的名字</param>
        /// <param name="outBasename">文件名</param>
        /// <param name="outExtention">带有"."的扩展名</param>
        /// <param name="outPath">路径的目录</param>
        public static void SplitFullFilename(string qualifiedName, out string outBasename, out string outExtention, out string outPath)
        {
            string fullName = string.Empty;
            SplitFilename(qualifiedName, out fullName, out outPath);
            SplitBaseFilename(fullName, out outBasename, out outExtention);
        }

        public static string DecodeFromUtf8(string utf8String)
        {
            if (utf8String == null)
            {
                return string.Empty;
            }
            if (utf8String.Length > 0)
            {
                System.Diagnostics.Debug.Assert(_bytes.Length > utf8String.Length);
                for (int i = 0; i < utf8String.Length; ++i)
                {
                    _bytes[i] = (byte)utf8String[i];
                }
                return Encoding.UTF8.GetString(_bytes, 0, utf8String.Length);
            }
            return utf8String;
        }

        public static string EncodingEscape(string str, int startIndex = 0, int endIndex = -1)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            var s = new StringBuilder(str.Length + str.Length / 10 + 4);
            if (endIndex < 0)
            {
                endIndex = str.Length;
            }
            for (int i = startIndex; i < endIndex; ++i)
            {
                var c = str[i];
                switch (c)
                {
                    case '\'':
                        s.Append('\\');
                        s.Append('\'');
                        break;
                    case '\"':
                        s.Append('\\');
                        s.Append('\"');
                        break;
                    case '\a':
                        s.Append('\\');
                        s.Append('a');
                        break;
                    case '\b':
                        s.Append('\\');
                        s.Append('b');
                        break;
                    case '\f':
                        s.Append('\\');
                        s.Append('f');
                        break;
                    case '\n':
                        s.Append('\\');
                        s.Append('n');
                        break;
                    case '\r':
                        s.Append('\\');
                        s.Append('r');
                        break;
                    case '\t':
                        s.Append('\\');
                        s.Append('t');
                        break;
                    case '\v':
                        s.Append('\\');
                        s.Append('v');
                        break;
                    case '\\':
                        s.Append('\\');
                        s.Append('\\');
                        break;
                    default:
                        s.Append(c);
                        break;
                }
            }
            return s.ToString();
        }

        public static string CombineString(params string[] strs)
        {
            _strBuilder.Length = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                _strBuilder.Append(strs[i]);
            }
            return _strBuilder.ToString();
        }

        /// <summary>
        /// 把Word转换为等Unicode字符串(\u09f9)
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string WordToUnicode(string word)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(word))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    //将中文字符转为10进制整数，然后转为16进制unicode字符
                    outStr += "\\u" + ((int)word[i]).ToString("x");
                }
            }
            return outStr;
        }
        /// <summary>
        /// 把Unicode字符串(\u09f9)转换为word字符串
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string UnicodeToWord(string unicode)
        {
            string str = unicode;
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("\\", "").Split('u');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.Fail(e.Message, e.StackTrace);
                }
            }
            return outStr;
        }

        /// <summary>
        /// 对字符串进行翻转
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string Reverse(string original)
        {
            char[] arr = original.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// 字符串多语言转换，主要用于服务器下发后台配置语言转换
        /// </summary>
        /// <param name="fullStr">语言全文本 如：[CH]这是中文[/CH][EN]this is english[/EN]</param>
        /// <param name="lang">客户端语言标记，如：CH</param>
        /// <returns></returns>
        public static string LangConvert(string fullStr, string lang)
        {
            if (string.IsNullOrEmpty(fullStr) || string.IsNullOrEmpty(lang))
                return "";
            string str = fullStr;
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[')
                {
                    if (i + 4 > str.Length)
                        continue;
                    if (str[i + 3] == ']')
                    {
                        string sub = str.Substring(i + 1, 2);
                        if (sub == lang)
                        {
                            index = i + 4;
                            break;
                        }
                    }
                }
            }
            if (index > 0)
                str = str.Remove(0, index);
            index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[')
                {
                    if (i + 5 > str.Length)
                        continue;
                    if (str[i + 4] == ']')
                    {
                        string sub = str.Substring(i + 2, 2);
                        if (sub == lang)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }
            if (index > 0)
                str = str.Remove(index, str.Length - index);

            return str;
        }

        /// <summary>
        /// 计算字符串长度,主要用于判断玩家输入的文本长度. 
        /// 规则如下:
        /// 1.所有的Ascii字符长度设置为 1
        /// 2.非ASCII字符,包括中文,日文等其他文字长度统一为 2
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        public static int CalcStringLenByUCS(string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            int count = 0;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            for (int i = 0; i < buffer.Length; ++i)
            {
                //获取UTF8中一个char包含多少个byte.通过char的首字节获得.
                int byteCnt = OneCharHasByteCountByUCS(buffer[i]);
                i += (byteCnt - 1);
                count += Math.Min(2, byteCnt);
            }
            return count;
        }

        /// <summary>
        /// 获取字符串的子字符串
        /// 字符串长度规则如下:
        /// 1.所有的Ascii字符长度设置为 1
        /// 2.非ASCII字符,包括中文,日文等其他文字长度统一为 2
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="len">想要获取的长度</param>
        /// <param name="thinner">true: 获取的长度不能够大于len false:可以大于len </param>
        /// <returns></returns>
        public static string SubStringByUCS(string text, int startIndex, int len = 0, bool thinner = true)
        {
            if (string.IsNullOrEmpty(text)) return text;

            int count = 0;
            bool startRecord = false;
            var sb = NewStringBuilder;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            for (int i = 0; i < buffer.Length; ++i)
            {
                byte byte0 = buffer[i];
                int byteCnt = OneCharHasByteCountByUCS(byte0);              
                count += Math.Min(2,byteCnt);
                if (!startRecord)
                {//当没有开始记录的时候,

                    if (count >= startIndex)
                    {//startindex正好落在当前字符上.那么录制
                        startRecord = true;
                        startIndex = (count - Math.Min(2, byteCnt));
                    }
                }
                if (startRecord)
                {//开始记录字符
                    //一个字符的的字节数量
                    switch (byteCnt)
                    {
                        case 1:
                            {
                                sb.Append((char)byte0);
                            }
                            break;
                        case 2:
                            {
                                byte byte1 = buffer[i + 1];
                                int ch = (byte0 & 31) << 6;
                                ch |= (byte1 & 63);
                            }
                            break;
                        case 3:
                            {
                                byte byte1 = buffer[i + 1];
                                byte byte2 = buffer[i + 2];
                                if (!(byte0 == 0xEF && byte1 == 0xBB && byte2 == 0xBF)) //对win中utf8文件的标记,剔除
                                {
                                    int ch = (byte0 & 15) << 12;
                                    ch |= (byte1 & 63) << 6;
                                    ch |= (byte2 & 63);
                                    sb.Append((char)ch);
                                }
                            }
                            break;
                        case 4:
                            {   
                                byte byte1 = buffer[i + 1];
                                byte byte2 = buffer[i + 2];
                                byte byte3 = buffer[i + 3];
                                int ch = (byte0 & 7) << 18;
                                ch |= (byte1 & 63) << 12;
                                ch |= (byte2 & 63) << 6;
                                ch |= (byte3 & 63);
                                sb.Append((char)ch);
                            }
                            break;
                    }
                }
                //i增加
                i += (byteCnt - 1);
                if (len > 0)
                {//只有设置的长度大于0的情况才会根据长度截取
                    if (startIndex + len == count)
                    {
                        break;
                    }
                    else if (startIndex + len < count)
                    {
                        if (thinner) sb.Remove(sb.Length - 1, 1);
                        break;
                    }
                }
            }
            return sb.ToString();
        }

        //一个字符包含的字节数量
        public static int OneCharHasByteCountByUCS(byte firstByte)
        {
            if ((firstByte & 128) == 0)
            {
                // If an UCS fits 7 bits, its coded as 0xxxxxxx. This makes ASCII character represented by themselves
                //sb.Append((char)byte0);
                return 1;
            }
            else if ((firstByte & 224) == 192)
            {
                // If an UCS fits 11 bits, it is coded as 110xxxxx 10xxxxxx                  
                return 2;
            }
            else if ((firstByte & 240) == 224)
            {
                // If an UCS fits 16 bits, it is coded as 1110xxxx 10xxxxxx 10xxxxxx
                //if (byte0 == 0xEF && byte1 == 0xBB && byte2 == 0xBF){skip}// Byte Order Mark -- generally the first 3 bytes in a Windows-saved UTF-8 file. Skip it.
                return 3;

            }
            else if ((firstByte & 248) == 240)
            {
                // If an UCS fits 21 bits, it is coded as 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx                     
                return 4;
            }
            return 1;
        }

        /// <summary>
        /// 是否含有中文
        /// </summary>
        public static bool IsContainChinese(string srcText)
        {
            bool flag = false;
            char[] textChars = srcText.ToCharArray();
            for (int i = 0; i < textChars.Length; i++)
            {
                char charText = textChars[i];
                if (charText >= 0x4e00 && charText <= 0x9fbb)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// string Base64加密
        /// </summary>
        public static string StringToBase64(string srcText)
        {
            var b = Encoding.Default.GetBytes(srcText);
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// Base64转string
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string Base64ToString(string srcText)
        {
            var b = Convert.FromBase64String(srcText);
            return Encoding.Default.GetString(b);
        }

        /// <summary>
        /// 获取字符串之间的内容
        /// </summary>
        /// <param name="start">首部</param>
        /// <param name="end">尾部</param>
        /// <param name="inculdeStartAndEnd">是否包含首位</param>
        /// <returns>首尾之间的字段</returns>
        public static string Between(string srcText, string start, string end, bool inculdeStartAndEnd = false)
        {
            if (start.Equals(end))
                throw new ArgumentException("Start string can't equals a end string.");
            int startIndex = srcText.LastIndexOf(start) + 1;
            int endIndex = srcText.LastIndexOf(end) - 1 - srcText.LastIndexOf(start);
            if (!inculdeStartAndEnd)
                return srcText.Substring(startIndex + start.Length, endIndex - end.Length);
            else
                return srcText.Substring(startIndex, endIndex + end.Length);
        }

        /// <summary>
		/// 移除首个字符
		/// </summary>
		public static string RemoveFirstChar(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            return text.Substring(1);
        }
        /// <summary>
        /// 移除末尾字符
        /// </summary>
        public static string RemoveLastChar(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            return text.Substring(0, text.Length - 1);
        }

        /// <summary>
        /// 转换成字节数组
        /// </summary>
        public static byte[] ToByteArray(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// 移除后缀
        /// </summary>
        /// <param name="text">原始字符串，类似于New.text</param>
        /// <param name="suffix">最好一个分隔符,类似于".apk"</param>
        /// <returns></returns>
        public static string RemoveSuffix(string text, string suffix)
        {
            if (string.IsNullOrEmpty(text))
            {
                DevLog.LogErrorFormat("字符串{0}是空!", text);
                return text;
            }
            int index = text.LastIndexOf(suffix);
            //这里小于0说明是字符串里面没有这个
            if (index < 0)
            {
                return text;
            }
            return text.Substring(0, index);
        }
    }
}
