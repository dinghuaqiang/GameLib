using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// Zip文件工具类，释放资源，从apk中读取资源
    /// </summary>
    public class ZipFileUtils
    {
        protected static int _bufferSize = 1024 * 10;
        protected static byte[] _buffer = new byte[1024 * 10];
        protected static StringBuilder _sb = new StringBuilder();


        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fullAppPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public static bool Exists(string fullAppPath, string relativPath)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return ExistsFromApk(fullAppPath, relativPath);
            }
            else
            {
                string fullFilePath = Path.Combine(fullAppPath, relativPath);
                return File.Exists(fullFilePath);
            }
        }


        /// <summary>
        /// 从app目录读取文件
        /// </summary>
        /// <param name="fullAppPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public static byte[] ReadBytesFromApp(string fullAppPath, string relativPath)
        {

            if (Application.platform == RuntimePlatform.Android)
            {
                return ReadBytesFromApk(fullAppPath, relativPath);
            }
            else
            {
                string fullFilePath = Path.Combine(fullAppPath, relativPath);
                if (File.Exists(fullFilePath))
                    return File.ReadAllBytes(fullFilePath);
            }

            return null;
        }



        /// <summary>
        ///  从APP中读取文本
        /// </summary>
        /// <param name="fullAppPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public static string[] ReadAllLineFromApp(string fullAppPath, string relativPath)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return ReadAllLineFromApk(fullAppPath, relativPath);
            }
            else 
            {
                string fullFilePath = Path.Combine(fullAppPath, relativPath);
                if (File.Exists(fullFilePath))
                    return File.ReadAllLines(fullFilePath);
            }

            return null;
        }

        /// <summary>
        ///  从APP中读取文本
        /// </summary>
        /// <param name="fullAppPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public static string ReadAllTextFromApp(string fullAppPath, string relativPath)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                string[] lines = ReadAllLineFromApk(fullAppPath, relativPath);
                _sb.Length = 0;
                for (int i = 0; lines != null && i < lines.Length; ++i)
                {
                    _sb.AppendLine(lines[i]);
                }
                return _sb.ToString();
            }
            else
            {
                string fullFilePath = Path.Combine(fullAppPath, relativPath);
                if (File.Exists(fullFilePath))
                    return File.ReadAllText(fullFilePath);
            }

            return null;
        }

        /// <summary>
        /// 判断文件是否在APK内
        /// </summary>
        /// <param name="apkPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        private static bool ExistsFromApk(string apkPath, string relativPath)
        {
            relativPath = "assets/" + relativPath;

            int idx = -1;
            ZipFile f = null;
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(apkPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                f = new ZipFile(fileStream);
                idx = f.FindEntry(relativPath, true);
                fileStream.Close();
                f.Close();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
            return idx >= 0;
        }
        /// <summary>
        /// 通过apk中读取一个字节流
        /// </summary>
        /// <param name="apkPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        internal static byte[] ReadBytesFromApk(string apkPath, string relativPath)
        {
            relativPath = "assets/" + relativPath;
            ZipFile f = null;
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(apkPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                f = new ZipFile(fileStream);
                var fileCount = f.Count;
                for (int i = 0; i < fileCount; ++i)
                {
                    if (f[i].Name == relativPath)
                    {
                        var stream = f.GetInputStream(i);
                        MemoryStream ms = new MemoryStream();
                        byte[] buffer = new byte[1024 * 10];
                        int len = 0;
                        while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, len);
                        }

                        stream.Close();
                        fileStream.Close();
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            return null;
        }

        /// <summary>
        /// 从apk中读取一个字符串数组
        /// </summary>
        /// <param name="apkPath"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        internal static string[] ReadAllLineFromApk(string apkPath, string relativPath)
        {
            relativPath = "assets/" + relativPath;
            List<string> retList = new List<string>();
            ZipFile f = null;
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(apkPath, FileMode.Open, FileAccess.Read, FileShare.Read);// new FileStream(apkPath, FileMode.Open);

                f = new ZipFile(fileStream);
                var fileCount = f.Count;
                for (int i = 0; i < fileCount; ++i)
                {
                    if (f[i].Name == relativPath)
                    {
                        var stream = f.GetInputStream(i);
                        StreamReader sr = new StreamReader(stream);
                        string readLine = null;
                        while ((readLine = sr.ReadLine()) != null)
                        {
                            retList.Add(readLine);
                        }
                        sr.Close();
                        stream.Close();
                        break;
                    }
                }

                fileStream.Close();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
            return retList.ToArray();
        }

        /// <summary>
        /// //释放指定文件列表
        /// </summary>
        /// <param name="apkPath">apk绝对路径</param>
        /// <param name="fileList">包含列表</param>
        /// <param name="unzipRootPath">释放根目录</param>
        /// <param name="useContain">是否使用包含关系，true：包含fileList列表， false：排除fileList列表</param>
        /// <param name="total"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public static bool UnzipTargetList(string apkPath, string[] fileList, string unzipRootPath, bool useContain, ref int total, ref int counter, bool isUnZipObb = false)
        {
            ZipFile f = null;
            FileStream fileStream = null;
            try
            {
                string zipRootDir = "assets/";
                string skipDir = "assets/bin";
                fileStream = File.Open(apkPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                f = new ZipFile(fileStream);
                var fileCount = f.Count;
                total = (int)fileCount;
                bool needUnzip = false;
                for (int i = 0; i < fileCount; ++i)
                {
                    counter++;

                    if (!isUnZipObb && (!f[i].Name.StartsWith(zipRootDir) || f[i].Name.StartsWith(skipDir)))
                    {
                        continue;
                    }
                    needUnzip = IsNeedUnzip(f[i].Name, fileList, useContain);

                    if (needUnzip)
                    {
                        //消除assets/文件夹
                        string relativePath = f[i].Name;
                        if (!isUnZipObb)
                            relativePath = f[i].Name.Substring(zipRootDir.Length);

                        string unzipFullPath = Path.Combine(unzipRootPath, relativePath);
                        //存在则跳过
                        if (File.Exists(unzipFullPath))
                            continue;
                        var stream = f.GetInputStream(i);
                        if (!WriteFile(stream, unzipFullPath))
                        {
                            counter--;
                            stream.Close();
                            return false;
                        }

                        stream.Close();
                    }
                }

                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            return false;
        }

        //根据列表目录，获取zip文件中对应文件个数
        public static int GetUnzipFileCount(string apkPath, string[] dirList)
        {
            int count = 0;
            ZipFile f = null;
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(apkPath, FileMode.Open, FileAccess.Read, FileShare.Read);// new FileStream(apkPath, FileMode.Open);
                f = new ZipFile(fileStream);
                var fileCount = f.Count;
                for (int i = 0; i < fileCount; ++i)
                {
                    for (int j = 0; j < dirList.Length; ++j)
                    {
                        if (f[i].Name.IndexOf(dirList[j]) >= 0)
                        {
                            count++;
                            break;
                        }
                    }
                }

                fileStream.Close();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            return count;
        }

        /// <summary>
        /// 是否需要释放
        /// </summary>
        /// <param name="entryName"></param>
        /// <param name="targetList"></param>
        /// <param name="useContain">是否包含关系</param>
        /// <returns></returns>
        public static bool IsNeedUnzip(string entryName, string[] targetList, bool useContain = true)
        {
            bool needUnzip = false;
            if (targetList == null || targetList.Length == 0)
                needUnzip = true;
            else
            {
                for (int j = 0; j < targetList.Length; ++j)
                {
                    int index = entryName.IndexOf(targetList[j]);
                    //如果是包含关系，包含list才为true
                    if (index >= 0 && useContain)
                    {
                        needUnzip = true;
                        break;
                    }

                    //如果不是包含关系，排除list才为true
                    if (index == -1 && !useContain)
                    {
                        needUnzip = true;
                        break;
                    }
                }
            }

            return needUnzip;
        }

        public static bool WriteFile(Stream sourceStream, string filePath)
        {
            try
            {
                CreateDir(filePath);

                string tempFile = filePath + ".temp";
                DeleteFile(filePath);
                DeleteFile(tempFile);

                using (FileStream streamWriter = File.Create(tempFile))
                {
                    if (streamWriter == null)
                    {
                        Debug.LogError("创建文件失败，存储空间不足");
                        return false;
                    }
                    WriteFile(sourceStream, streamWriter);

                    streamWriter.Flush();
                    streamWriter.Close();

                    //到这里，如果目标文件还存在，有可能是资源修复下载的，则不覆盖
                    if (File.Exists(filePath) || File.Exists(filePath + ".bak"))
                    {
                        File.Delete(tempFile);
                    }
                    else
                        File.Move(tempFile, filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                Debug.LogError("文件损坏： " + filePath);
                //打点转移资源
            }

            return false;
        }

        public static void WriteFile(Stream zi, FileStream outFile)
        {
            int size = 0;
            while ((size = zi.Read(_buffer, 0, _bufferSize)) > 0)
            {
                outFile.Write(_buffer, 0, size);
            }
        }

        private static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        private static void CreateDir(string fullFilePath)
        {
            var root = Path.GetDirectoryName(fullFilePath);
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
        }
    }
}