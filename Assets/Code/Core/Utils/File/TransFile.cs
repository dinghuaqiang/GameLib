using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace GameLib.Core.Utils
{
    public class TransFile
    {
        /// <summary>
        /// 从StreamingAssets转移文件到datapath路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="onFinished"></param>
        public void TransFileFromApkStreamingPath(string fileName, Action<string> onFinished)
        {
            string apkFilePath = string.Format("{0}/{1}", Application.streamingAssetsPath, fileName);
            string dataFilePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
            if (Application.platform == RuntimePlatform.Android)
            {
                using (UnityWebRequest request = UnityWebRequest.Get(apkFilePath))
                {
                    //转移的开始时间
                    float startTime = Time.realtimeSinceStartup;
                    request.timeout = 5;
                    //直接将文件下载到外存
                    request.downloadHandler = new DownloadHandlerFile(dataFilePath);
                    request.SendWebRequest();
                    if (!string.IsNullOrEmpty(request.error))
                    {
                        Debug.LogError("转移资源出错了:" + request.error);
                    }
                    while (!request.isDone)
                    {
                        Debug.LogError("当前进度:" + request.downloadProgress);
                    }
                    //下载完成后执行的回调
                    if (request.isDone)
                    {
                        //记录结束时间
                        float endTime = Time.realtimeSinceStartup - startTime;
                        Debug.LogFormat("转移资源用时:{0}秒", endTime);
                        onFinished(dataFilePath);
                    }
                }
            }
            else
            {
                File.Copy(apkFilePath, dataFilePath, true);
            }
        }
    }
}
