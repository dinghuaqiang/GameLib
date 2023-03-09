using System.Security.Cryptography;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// AES加密解密
    /// </summary>
    public class AESEncrypt
    {
        /// <summary>
        /// 默认密钥-密钥的长度必须是32位[网上找个随机生成的秘钥生成器就行]
        /// </summary>
        private const string PUBLIC_KEY = "JJNqjwQvbfsJa7U7FvHPJSjSTSJWqEzR";

        /// <summary>
        /// 默认向量
        /// IV的作用主要是用于产生密文的第一个block，以使最终生成的密文产生差异（明文相同的情况下），使密码攻击变得更为困难，除此之外IV并无其它用途。
        /// </summary>
        private const string IV = "7JHhhNZezhaNNrGb";

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="key">32位密钥</param>
        /// <returns>加密后的字符串</returns>
        public static byte[] Encrypt(byte[] toEncryptArray)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(PUBLIC_KEY);
            var rijndael = new RijndaelManaged();
            rijndael.Key = keyArray;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.IV = Encoding.UTF8.GetBytes(IV);
            ICryptoTransform cTransform = rijndael.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return resultArray;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <param name="key">32位密钥</param>
        /// <returns>解密后的字符串</returns>
        public static byte[] Decrypt(byte[] toDecryptArray)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(PUBLIC_KEY);

            var rijndael = new RijndaelManaged();
            rijndael.Key = keyArray;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.IV = Encoding.UTF8.GetBytes(IV);
            ICryptoTransform cTransform = rijndael.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            return resultArray;
        }
    }
}
