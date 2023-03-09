using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源修复记录的文件数据
    /// </summary>
    public class RepairRecordFileData
    {
        //文件名
        private const string CN_FILE_NAME = "RepairRecord.txt";
        //用于分割的字符
        private const char CN_SPLIT_CHAR = '\t';
        //用于分割的字符串
        private static char[] CN_SPLIT_CHAR_ARRAY = new char[] { CN_SPLIT_CHAR };
        /// <summary>
        /// 记录修复次数 <名称,修复次数>
        /// </summary>
        private Dictionary<string, int> _repairDict = new Dictionary<string, int>();

        //文件路径
        private string _filePath = "";

        /// <summary>
        /// 获取某个文件修复的次数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetRepairCount(string name)
        {
            if (_repairDict.ContainsKey(name))
            {
                return _repairDict[name];
            }
            else
            {
                name = ToLowerFileName(name);
                if (_repairDict.ContainsKey(name))
                    return _repairDict[name];
            }
            return 0;
        }

        private string ToLowerFileName(string name)
        {
            int index = name.LastIndexOf("/");
            if (index != -1)
            {
                var fileName = name.Substring(index).ToLower();
                var dir = name.Substring(0, index);
                name = dir + fileName;
            }

            return name;
        }

        //读数据
        public void Read()
        {
            _filePath = PathUtils.GetWritePath(CN_FILE_NAME);
            _repairDict.Clear();
            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    var arr = lines[i].Split(CN_SPLIT_CHAR_ARRAY, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2 && !string.IsNullOrEmpty(arr[0]))
                    {
                        int cnt;
                        if (int.TryParse(arr[1], out cnt))
                        {
                            _repairDict[arr[0]] = cnt;
                        }
                    }
                }
            }
        }
    }
}
