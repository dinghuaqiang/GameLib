using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 计算MD5的一些函数
    /// </summary>
    public class MD5Utils
    {
        /// <summary>
        /// 获取文件的MD5
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileMD5(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return "";
            }

            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                Debug.LogError("calc md5 fail : " + ex.Message + "\n" + filePath);
            }
            return "";

        }

        //字符串md5
        public static string MD5String(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(text);//将字符编码为一个字节序列 
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(data);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                Debug.LogError("calc md5 fail : " + ex.Message);
            }

            return "";
        }
    }
}
