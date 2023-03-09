using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 多语言处理
    /// </summary>
    public class FLanguage
    {
        #region//常量定义
        //定义语言的符号
        public const string CH = "CH";  //中文
        public const string TW = "TW";  //台湾--big5
        public const string EN = "EN";  //英文
        public const string KR = "KR";  //韩文
        public const string VIE = "VIE";  //越南
        public const string TH = "TH";  //泰文
        public const string JP = "JP";  //日文

        //定义的语言名字
        public const string CH_NAME = "中文简体";  //中文
        public const string TW_NAME = "中文繁体";  //台湾--big5
        public const string EN_NAME = "English";  //英文
        public const string KR_NAME = "한글";  //韩文
        public const string VIE_NAME = "Tiếng Việt";  //越南
        public const string TH_NAME = "ภาษาไทย";  //泰文
        public const string JP_NAME = "にほんご";  //日文
        #endregion

        #region//静态私有变量
        //语言字典
        private static Dictionary<string, string> _allLans = null;
        private static string[] _allKeys = null;
        private static string[] _allNames = null;
        #endregion

        #region//静态属性
        //语言数量
        public static int LanCount
        {
            get
            {
                return _allLans.Count;
            }
        }

        //当前默认语言
        public static string Default
        {
            get
            {
                return AppPersistData.UseLanguage;
            }
            set
            {
                AppPersistData.UseLanguage = value;
            }
        }
        #endregion

        #region//静态构造函数
        static FLanguage()
        {
            //1.初始化所有的语言
            _allKeys = new string[] {
               CH,TW,EN,KR,VIE,TH,JP
            };
            _allNames = new string[] {
               CH_NAME,TW_NAME,EN_NAME,KR_NAME,VIE_NAME,TH_NAME,JP_NAME
            };

            _allLans = new Dictionary<string, string>();
            for (int i = 0; i < _allKeys.Length; i++)
            {
                _allLans.Add(_allKeys[i], _allNames[i]);
            }

        }
        #endregion

        #region//功能性静态函数

        //可以被选择的语言列表
        public static Dictionary<string, string> EnabledSelectLans()
        {
            var result = new Dictionary<string, string>();
            if (AppManager.Instance.LocalVersionData.ContainsKey("developer"))
            {
                var lan = AppManager.Instance.LocalVersionData["developer"];
                if (!string.IsNullOrEmpty(lan))
                {
                    var lanArrays = lan.Split(new char[] { '_' }, System.StringSplitOptions.RemoveEmptyEntries);
                    if (lanArrays.Length > 0)
                    {
                        for (int i = 0; i < lanArrays.Length; i++)
                        {
                            var idx = Array.IndexOf(_allKeys, lanArrays[i]);
                            if (idx >= 0)
                            {
                                result[_allKeys[idx]] = _allNames[idx];
                            }
                        }
                    }
                }
            }
            if (result.Count == 0)
            {
                result[CH] = CH_NAME;
            }
            return result;
        }



        /// <summary>
        /// 把系统语言转换到定义语言标记
        /// </summary>
        public static string Cast(SystemLanguage slan)
        {
            //这里检测,根据机器的系统类型来定义语言            
            switch (slan)
            {
                case SystemLanguage.English:
                    return EN;
                case SystemLanguage.Japanese:
                    return JP;
                case SystemLanguage.Korean:
                    return KR;
                case SystemLanguage.Vietnamese:
                    return VIE;
                case SystemLanguage.Thai:
                    return TH;
                case SystemLanguage.ChineseTraditional:
                    return TW;
                default:
                    return CH;
            }
        }

        /// <summary>
        /// 查找当前字段是否是语言标记
        /// </summary>
        /// <param name="lan"></param>
        /// <returns></returns>
        public static bool IsLanguageFlag(string lan)
        {
            return Array.IndexOf(_allKeys, lan) >= 0;
        }

        /// <summary>
        /// 转换到索引
        /// </summary>
        /// <param name="lan"></param>
        /// <returns></returns>
        public static int CastToIndex(string lan)
        {
            var idx = Array.IndexOf(_allKeys, lan);
            if (idx < 0) idx = 0;
            return idx;
        }

        /// <summary>
        /// 转换到系统
        /// </summary>
        /// <param name="lan"></param>
        /// <returns></returns>
        public static SystemLanguage CastToSystem(string lan)
        {
            switch (lan)
            {
                case EN:
                    return SystemLanguage.English;
                case JP:
                    return SystemLanguage.Japanese;
                case KR:
                    return SystemLanguage.Korean;
                case VIE:
                    return SystemLanguage.Vietnamese;
                case TH:
                    return SystemLanguage.Thai;
                case TW:
                    return SystemLanguage.ChineseTraditional;
                default:
                    return SystemLanguage.Chinese;
            }
        }

        /// <summary>
        /// 获取本地时间格式化字符串
        /// </summary>
        public static String GetDayFormatString(string lan)
        {
            //根据语言类型获取时间格式化字符串         
            switch (lan)
            {
                case EN:
                    return "dd-MM-yyyy";
                case JP:
                    return "yyyy-MM-dd";
                case KR:
                    return "yyyy-MM-dd";
                case VIE:
                    return "yyyy-MM-dd";
                case TH:
                    return "dd-MM-yyyy";
            }
            //默认
            return "yyyy-MM-dd";
        }

        /// <summary>
        /// 获取长时间按的格式字符串
        /// </summary>
        /// <param name="lan"></param>
        /// <returns></returns>
        public static String GetLongTimeFormatString(string lan)
        {
            return GetDayFormatString(lan) + " HH:mm:ss";
        }

        #endregion
    }
}
