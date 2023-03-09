using GameLib.Code.Logic.DataLoad;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 本地化翻译模块
        /// TODO 这里还需要一个Excel的读取模块
        /// </summary>
        public static class I18N
        {
            public enum LanDefine
            {
                CN,
                EN,
                TH,
                VIE,
                KOR,
            }

            /// <summary>
            /// 翻译某个字符串
            /// </summary>
            /// <param name="text"></param>
            /// <param name="lanId"></param>
            /// <returns></returns>
            public static string Translate(string text, int lanId)
            {
                return I18NExcel.GetLanguage(text, lanId);
            }
        }
    }
}
