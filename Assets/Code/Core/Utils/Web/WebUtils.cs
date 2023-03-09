using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class WebUtils
    {
        private static char[] CN_LINE_TAIL = new char[] { '\r', '\n' };

        public static void ReadAllLine(string fullPath, Action<string[]> callBack)
        {
            CoroutinePool.AddTask(StartDownloadLines(fullPath, callBack));
        }

        public static void ReadBytes(string fullPath, Action<byte[]> callBack)
        {
            CoroutinePool.AddTask(StartDownloadBytes(fullPath, callBack));
        }

        public static void ReadAllText(string fullPath, Action<string> callBack)
        {
            CoroutinePool.AddTask(StartDownloadText(fullPath, callBack));
        }

        public static void ReleaseFiles(string sourceDir, string[] dirOrFileList, string destDir)
        {
            CoroutinePool.AddTask(StartReleaseFiles(sourceDir, dirOrFileList,destDir));
        }

        public static IEnumerator StartReleaseFiles(string baseurl, string[] dirOrFileList, string destDir)
        {

            for (int i = 0; i < dirOrFileList.Length; i++)
            {
                UnityWebRequest req = UnityWebRequest.Get(Path.Combine(baseurl, dirOrFileList[i]));                
                yield return req.SendWebRequest();
                if (string.IsNullOrEmpty(req.error))
                {                    
                    File.WriteAllBytes(Path.Combine(destDir, dirOrFileList[i]), req.downloadHandler.data);
                }
                else
                {
                    Debug.LogError("下载异常:" + req.error + "::" + req.responseCode+"::"+ req.url);
                }
            }
        }

        public static IEnumerator StartDownloadBytes(string url, Action<byte[]> callBack)
        {
            UnityWebRequest req = UnityWebRequest.Get(url);
            yield return req.SendWebRequest();
            if (string.IsNullOrEmpty(req.error))
            {
                callBack(req.downloadHandler.data);
            }
            else
            {
                Debug.LogError("下载异常:" + req.error + "::"+req.responseCode + "::" + req.url);
                callBack(null);
            }
        }

        public static IEnumerator StartDownloadText(string url, Action<string> callBack)
        {
            UnityWebRequest req = UnityWebRequest.Get(url);
            yield return req.SendWebRequest();
            if (string.IsNullOrEmpty(req.error))
            {
                callBack(req.downloadHandler.text);
            }
            else
            {
                Debug.LogError("下载异常:" + req.error + "::" + req.responseCode + "::" + req.url);
                callBack(null);
            }
        }

        public static IEnumerator StartDownloadLines(string url, Action<string[]> callBack)
        {
            UnityWebRequest req = UnityWebRequest.Get(url);
            yield return req.SendWebRequest();
            if (string.IsNullOrEmpty(req.error) && !string.IsNullOrEmpty(req.downloadHandler.text))
            {
                callBack(req.downloadHandler.text.Split(CN_LINE_TAIL, StringSplitOptions.RemoveEmptyEntries));
            }
            else
            {
                Debug.LogError("下载异常:"+ req.error + "::" + req.responseCode + "::" + req.url);
                callBack(null);
            }
        }

    }
}
