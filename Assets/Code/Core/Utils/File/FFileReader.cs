using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 二进制文件读取数据
    /// </summary>
    public class FFileReader
    {
        //读取文件的Bytes
        public static byte[] ReadBytes(string fullPath)
        {

            //1.先读取持续化目录的文件
            fullPath = PathUtils.FixedPath(fullPath);
            if (File.Exists(fullPath))
            {
                return File.ReadAllBytes(fullPath);
            }
            else
            {
                //2.在去包体内读资源
                var relativePath = AppManager.Instance.NormalizeAssetPath(fullPath);
                if (AppManager.Instance.AssetInApp(relativePath))
                {
                    return AppManager.Instance.ReadBytes(relativePath);
                }
                else
                {//3.去Resource目录中读取
                    string name, ext;
                    StringUtils.SplitBaseFilename(PathUtils.GetConfigFilePathRelativeResouce(fullPath), out name, out ext);

                    var textAsset = Resources.Load<TextAsset>(name);
                    if (textAsset != null)
                    {
                        return textAsset.bytes;
                    }
                }
                UnityEngine.Debug.LogError(string.Format("FileUtils:ReadFileBytes,Resources.Load<TextAsset>(({0}) Fail!", fullPath));
            }
            return null;
        }


        //读取文件文本信息
        public static string ReadText(string fullPath)
        {
            //1.先读取持续化目录的文件
            fullPath = PathUtils.FixedPath(fullPath);
            if (File.Exists(fullPath))
            {
                return File.ReadAllText(fullPath);
            }
            else
            {
                //2.在去包体内读资源
                var relativePath = AppManager.Instance.NormalizeAssetPath(fullPath);
                if (AppManager.Instance.AssetInApp(relativePath))
                {
                    var lines = AppManager.Instance.ReadAllLine(relativePath);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; lines != null && i < lines.Length; ++i)
                    {
                        sb.AppendLine(lines[i]);
                    }

                    return sb.ToString();
                }
                else
                {
                    //3.去Resource目录中读取
                    string name, ext;
                    StringUtils.SplitBaseFilename(PathUtils.GetConfigFilePathRelativeResouce(fullPath), out name, out ext);
                    var textAsset = Resources.Load<TextAsset>(name);
                    if (textAsset != null)
                    {
                        return textAsset.text;
                    }
                }

                UnityEngine.Debug.LogError(string.Format("FileUtils:ReadFileText,Resources.Load<TextAsset>(({0}) Fail!", fullPath));
            }

            return null;
        }


        //读取文件的Bytes
        public static void ReadBytesAsync(string fullPath, Action<byte[]> callBack)
        {
            if (callBack == null) return;

            //1.先读取持续化目录的文件
            fullPath = PathUtils.FixedPath(fullPath);
            if (File.Exists(fullPath))
            {
                callBack(File.ReadAllBytes(fullPath));
            }
            else
            {
                //2.在去包体内读资源
                var relativePath = AppManager.Instance.NormalizeAssetPath(fullPath);
                if (AppManager.Instance.AssetInApp(relativePath))
                {
                    AppManager.Instance.ReadBytesAsync(relativePath, callBack);
                }
                else
                {//3.去Resource目录中读取
                    string name, ext;
                    StringUtils.SplitBaseFilename(PathUtils.GetConfigFilePathRelativeResouce(fullPath), out name, out ext);

                    var textAsset = Resources.Load<TextAsset>(name);
                    if (textAsset != null)
                    {
                        callBack(textAsset.bytes);
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(string.Format("FileUtils:ReadFileBytes,Resources.Load<TextAsset>(({0}) Fail!", fullPath));
                        callBack(null);
                    }
                }
            }

        }


        //读取文件文本信息
        public static void ReadTextAsync(string fullPath, Action<string> callBack)
        {
            if (callBack == null) return;

            //1.先读取持续化目录的文件
            fullPath = PathUtils.FixedPath(fullPath);
            if (File.Exists(fullPath))
            {
                callBack(File.ReadAllText(fullPath));
            }
            else
            {
                //2.在去包体内读资源
                var relativePath = AppManager.Instance.NormalizeAssetPath(fullPath);
                if (AppManager.Instance.AssetInApp(relativePath))
                {
                    AppManager.Instance.ReadAllTextAsync(relativePath, callBack);
                }
                else
                {
                    //3.去Resource目录中读取
                    string name, ext;
                    StringUtils.SplitBaseFilename(PathUtils.GetConfigFilePathRelativeResouce(fullPath), out name, out ext);
                    var textAsset = Resources.Load<TextAsset>(name);
                    if (textAsset != null)
                    {
                        callBack(textAsset.text);
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(string.Format("FileUtils:ReadFileText,Resources.Load<TextAsset>(({0}) Fail!", fullPath));
                        callBack(null);
                    }
                }
            }
        }

    }
}
