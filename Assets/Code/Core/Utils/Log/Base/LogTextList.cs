
using System;
using System.Collections.Generic;

using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志的文本列表
    /// </summary>
    public class LogTextList : List<String>
    {
        private static string strInfo1 = "< ";
        private static string strInfo2 = ">";
        private static string strInfo3 = "---Time:";

        private StringBuilder _sb = new StringBuilder();

        private int _totalCount = 0;

        /// <summary>
        /// 把一条信息写入列表中
        /// <0>----Time:2015-01-01 12-12-12 (1234) 
        /// message
        /// </summary>
        /// <param name="item"></param>
        public new void Add(string item)
        {
            lock (_sb)
            {
                if (_sb == null) return;
                _sb.Remove(0, _sb.Length);
                _sb.Append(strInfo1);
                _sb.Append(_totalCount);
                _sb.Append(strInfo2);
                _sb.Append(strInfo3);
                _sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss (ffff)"));
                _sb.AppendLine(item);
                base.Add(_sb.ToString());
                ++_totalCount;
            }
        }
    }
}
