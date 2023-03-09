using System.Collections.Generic;
using System.IO;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// Json工具类
        /// </summary>
        public static class Json 
        {
            public static string ToJson(Dictionary<string, string> srcDict) 
            {
                JSONObject json = new JSONObject();
                if (srcDict != null)
                {
                    var iter = srcDict.GetEnumerator();
                    while (iter.MoveNext())
                    {
                        json.Add(iter.Current.Key, new JSONString(iter.Current.Value));
                    }
                }
                return json.ToString();
            }

            /// <summary>
            /// 获取Json的数据
            /// </summary>
            public static Dictionary<string, JSONNode> GetJSONNodeDict(JSONObject jsonObject)
            {
                if (jsonObject != null)
                {
                    return jsonObject.DataDict;
                }
                return new Dictionary<string, JSONNode>();
            }

            /// <summary>
            /// 获取Json的数据
            /// </summary>
            public static Dictionary<string, string> GetDictFromJSONObject(JSONObject jsonObject)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                if (jsonObject != null)
                {
                    var datas = jsonObject.DataDict;
                    if (datas != null)
                    {
                        var iter = datas.GetEnumerator();
                        try
                        {
                            while (iter.MoveNext())
                            {
                                result.Add(iter.Current.Key, iter.Current.Value);
                            }
                        }
                        finally
                        {
                            iter.Dispose();
                        }
                    }
                    
                }
                return result;
            }

            /// <summary>
            /// 把Json内容保存到文件
            /// </summary>
            public static void WriteJson(string filePath, string jsonContent)
            {
                IO.WriteTextFile(filePath, jsonContent);
            }

            /// <summary>
            /// 把Json内容保存到文件
            /// </summary>
            public static void WriteJson(string filePath, JSONNode json)
            {
                IO.WriteTextFile(filePath, json.ToString());
            }

            /// <summary>
            /// 读取Json
            /// </summary>
            public static JSONNode ReadJson(string content)
            {
                if (string.IsNullOrEmpty(content))
                {
                    DevLog.LogErrorFormat("读取的Json内容为空!");
                }
                return JSON.Parse(content);
            }

            /// <summary>
            /// 从文件读取Json
            /// </summary>
            /// <param name="filePath"></param>
            /// <returns></returns>
            public static JSONNode ReadJsonFromFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    DevLog.LogErrorFormat("Json文件：{0}不存在!", filePath);
                }
                string jsonText = File.ReadAllText(filePath);
                return JSON.Parse(jsonText);
            }
        }
    }
}
