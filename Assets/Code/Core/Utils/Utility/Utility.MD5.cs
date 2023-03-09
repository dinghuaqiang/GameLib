using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// MD5工具类
        /// </summary>
        public static class MD5
        {
            /// <summary>
            /// 计算文件的 MD5 值
            /// </summary>
            /// <param name="this">源文件流</param>
            /// <returns>MD5 值16进制字符串</returns>
            public static string GetFileMD5(FileStream fs)
            {
                if (fs != null)
                {
                    return HashFile(fs, "md5");
                }
                return string.Empty;
            }

            /// <summary>
            /// 计算文件的 MD5 值
            /// </summary>
            /// <param name="filePath">文件路径</param>
            public static string GetFileMD5(string filePath)
            {
                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    return HashFile(fs, "md5");
                }
                DevLog.LogErrorFormat("MD5计算失败，文件:{0}不存在!", filePath);
                return string.Empty;
            }

            /// <summary>
            /// 获取字符串的MD5
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string GetStringMD5(string text)
            {
                HashAlgorithm crypto = new MD5CryptoServiceProvider();
                //将字符编码为一个字节序列
                byte[] data = Encoding.UTF8.GetBytes(text);
                byte[] retVal = crypto.ComputeHash(data);
                StringBuilder sb = new StringBuilder();
                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }

            /// <summary>
            /// 计算文件的 sha1 值
            /// </summary>
            /// <param name="this">源文件流</param>
            /// <returns>sha1 值16进制字符串</returns>
            public static string GetFileSha1(Stream stream)
            {
                if (stream != null)
                {
                    return HashFile(stream, "sha1");
                }
                return string.Empty;
            }
            /// <summary>
            /// 计算文件的哈希值
            /// </summary>
            /// <param name="fs">被操作的源数据流</param>
            /// <param name="algo">加密算法</param>
            /// <returns>哈希值16进制字符串</returns>
            static string HashFile(Stream fs, string algo)
            {
                try
                {
                    HashAlgorithm crypto = default;
                    switch (algo)
                    {
                        case "sha1":
                            crypto = new SHA1CryptoServiceProvider();
                            break;
                        default:
                            crypto = new MD5CryptoServiceProvider();
                            break;
                    }
                    byte[] retVal = crypto.ComputeHash(fs);
                    StringBuilder sb = new StringBuilder();
                    foreach (var t in retVal)
                    {
                        sb.Append(t.ToString("x2"));
                    }
                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    DevLog.LogError("Calc md5 fail : " + ex.Message);
                }
                finally
                {
                    fs.Flush();
                    fs.Close();
                }
                return string.Empty;
            }
        } 
    }
}
