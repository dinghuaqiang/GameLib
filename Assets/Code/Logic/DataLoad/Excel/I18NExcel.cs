using GameLib.Core.Excel;
using System.Collections.Generic;

namespace GameLib.Code.Logic.DataLoad
{
    /// <summary>
    /// 读取翻译文件的Excel数据
    /// </summary>
    public class I18NExcel : XmlReadExcel
    {
        /// <summary>
        /// 翻译文件的路径
        /// </summary>
        public const string CN_I18N_EXCEL_PATH = "../../Gamedata/Locate/LanguageConverter.xlsx";
        /// <summary>
        /// 翻译存储的数据
        /// </summary>
        private Dictionary<string, string[]> _dataDict = new Dictionary<string, string[]>();

        private static I18NExcel _instance;
        private static I18NExcel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new I18NExcel();
                    _instance.Initialize();
                }
                return _instance;
            }
        }

        private void Initialize()
        {
            _instance.Parse();
        }

        public void SaveAsExcel()
        {
            _instance.Save();
        }

        public override void Parse()
        {
            base.Parse(CN_I18N_EXCEL_PATH);
            _dataDict.Clear();
            try
            {
                ConvertData();
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message + "\r\n" + ex.StackTrace;
                UnityEngine.Debug.LogError(msg);
            }
        }

        public override void Save()
        {
            base.Save(CN_I18N_EXCEL_PATH);
        }

        public static string GetLanguage(string chKey, int lanId)
        {
            if (Instance._dataDict.ContainsKey(chKey))
            {
                var valueArray = Instance._dataDict[chKey];
                if (lanId >= valueArray.Length)
                {
                    return null;
                }

                return valueArray[lanId];
            }

            return null;
        }

        public Dictionary<string, string[]> GetAllLanguage()
        {
            return _dataDict;
        }

        public Dictionary<string, string> GetAllLangauge(int lan)
        {
            Dictionary<string, string> retDict = new Dictionary<string, string>();

            var itor = _dataDict.Keys.GetEnumerator();
            while (itor.MoveNext())
            {
                retDict.Add(itor.Current, _dataDict[itor.Current][lan]);
            }

            return retDict;
        }

        public void AddValue(string chStr, string valueStr, int lan, int lanCount)
        {
            //添加到Dictionary
            string[] valueArray = null;
            if (!_dataDict.ContainsKey(chStr))
            {
                valueArray = new string[lanCount];
                _dataDict.Add(chStr, valueArray);
            }

            valueArray[lan] = valueStr;

            //添加到xml
            string[] dataArray = new string[lanCount];
            dataArray[lan] = valueStr;
            _sheetData.AddRow(dataArray);
        }

        /// <summary>
        /// 将行列数据转换为字典结构
        /// </summary>
        private void ConvertData()
        {
            var allRowData = _sheetData.GetAllData();
            for (int i = 0; i < allRowData.Count; ++i)
            {
                var collums = allRowData[i].GetCollumDatas();
                if (collums == null || collums.Count == 0 || collums[0] == null || collums[0].GetCollumNum() > 0)
                {
                    continue;
                }

                string key = collums[0].ShareValue;

                if (_dataDict.ContainsKey(key))
                {
                    //重复的key
                    UnityEngine.Debug.LogWarning("重复的Key: " + key);
                    continue;
                }

                string[] valueArray = allRowData[i].ToArray();

                _dataDict.Add(key, valueArray);
            }
        }
    }
}
