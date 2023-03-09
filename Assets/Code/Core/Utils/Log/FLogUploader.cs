using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志上传者
    /// </summary>
    public class FLogUploader
    {
        //是否停止
        private static bool isStop = false;

        //开始上传日志
        public static void StartUploadLog(string upLoadURL, Action<float> progressAction = null, Action<int> failaction = null)
        {
            isStop = false;
            List<string> toUploadLogList = FLogManager.Instance.GetLatestLogs();
            CoroutinePool.AddTask(CoroSendToServer(upLoadURL, toUploadLogList, progressAction, failaction));
        }

        //停止上传日志
        public static void StopUploadLog()
        {
            isStop = true;
        }

        //上传到服务器的协成
        private static IEnumerator CoroSendToServer(string upLoadURL, List<string> logFiles, Action<float> progressAction, Action<int> failaction)
        {
            //上传之前先暂停写文件,防止读写文件冲突
            FLogManager.Instance.PauseWrite();

            yield return new WaitForSeconds(1f);

            StringBuilder sb = new StringBuilder();
            int maxCount = logFiles.Count;
            UnityEngine.Debug.LogError("上传日志文件数量为:" + maxCount);
            int failCount = 0;
            if (progressAction != null) progressAction(0);
            for (int i = 0; i < maxCount; ++i)
            {
                if (isStop)
                {
                    break;
                }
                string fileName = logFiles[i];
                string trace = AppPersistData.AppVersion
                        + "\n"
                        + Application.platform.ToString();

                try
                {
                    trace += "\n" + File.ReadAllText(logFiles[i]);
                }
                catch (System.Exception ex)
                {
                    //读文件失败的话,就不算失败次数.这里的错误一般情况是当前运行日志正在被读写,所以不能读取.
                    UnityEngine.Debug.LogError("读取文件异常:" + logFiles[i]);
                    UnityEngine.Debug.LogException(ex);
                    continue;
                }

                byte[] bytes = Encoding.UTF8.GetBytes(trace);

                WWWForm form = new WWWForm();
                form.AddBinaryData("stack", bytes, fileName, "text/plain");
                form.AddField("logPath", GetLogPath(fileName));
                form.AddField("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") /*rp.m_time.ToString("yyyyMMddHHmmss")*/);
                form.AddField("mem_free", SystemInfo.systemMemorySize.ToString());
                form.AddField("mem_used", "" + SystemInfo.graphicsMemorySize);
                if (string.IsNullOrEmpty(AppPersistData.AppVersion))
                {
                    form.AddField("version", AppManager.Instance.GetLocalVersionValue("local_app_version"));
                }
                else
                {
                    form.AddField("version", AppPersistData.AppVersion);
                }
                form.AddField("playerid", AppPersistData.LastRoleID);
                form.AddField("playername", AppPersistData.LastRoleName);
                if(Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    form.AddField("game", "windows_qq_game");
                }
                else
                {
                    form.AddField("game", Application.identifier);
                }
                form.AddField("user", AppPersistData.GameUserID);
                form.AddField("uuid", MachineUUID.Value);
                form.AddField("miei", MachineUUID.Value);
                form.AddField("idfa", MachineUUID.Value);
                form.AddField("os", SystemInfo.operatingSystem);



                // send to http server.
                using (var w = UnityWebRequest.Post(upLoadURL, form))
                {
                    yield return w.SendWebRequest();

                    if (w.error != null)
                    {
                        failCount++;
                        UnityEngine.Debug.LogError("upload logFile error:" + fileName + "::" + w.error + ";;" + upLoadURL);
                    }
                    else
                    {
                        UnityEngine.Debug.Log("upload success " + fileName + ";;" + upLoadURL);
                    }
                }
                if (progressAction != null) progressAction((float)i / (float)maxCount);
            }
            yield return new WaitForSeconds(1f);
            //恢复日志的写操作
            FLogManager.Instance.ResumeWrite();

            if (progressAction != null) progressAction(1);
            if (failaction != null) failaction(failCount);
            
        }

        //获取日志路径--为了配合服务器的解析进行处理
        private static string GetLogPath(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var arr = filePath.Split(new char[] { '\\', '/' });
                var num = arr.Length;
                if (num >= 3)
                {
                    return string.Format("{0}/{1}/{2}", arr[num - 3], arr[num - 2], arr[num - 1]);
                }
                else if (num == 2)
                {
                    return string.Format("{0}/{1}/{2}", "Log", arr[num - 2], arr[num - 1]);
                }
                else if (num == 1)
                {
                    return string.Format("{0}/{1}/{2}", "Log", "UnknowDateTime", arr[num - 1]);
                }
                else
                {
                    return string.Format("{0}/{1}/{2}", "Log", "UnknowDateTime", "UnknowFileName");
                }
            }
            else
            {
                return string.Format("{0}/{1}/{2}", "Log", "UnknowDateTime", "UnknowFileName");
            }

        }
    }
}
