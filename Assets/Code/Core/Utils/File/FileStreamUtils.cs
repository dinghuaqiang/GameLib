using System.IO;
using System.Text;
using UnityEngine;

namespace GameLib.Core.Utils
{
    public class FileStreamUtils
    {
        public void CopyFile(string srcPath, string targetPath)
        {
            if (!string.IsNullOrEmpty(srcPath) && File.Exists(srcPath))
            {
                //创建读取流
                using (FileStream readStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
                {
                    //创建写入流
                    using (FileStream writeStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        //创建一个中转缓冲区，一次读取多少字节的数据进行后面的写入操作，类似于从一个水缸舀水到另一个水缸的容器大小
                        byte[] bufferBytes = new byte[1024 * 1024 * 3];
                        //一次读取多少的字节数【读取数据到缓冲区，从什么位置开始读，读取的最大数量】
                        int readCount = readStream.Read(bufferBytes, 0, bufferBytes.Length);
                        int lastProgress = 0;
                        while (readCount > 0)
                        {
                            //将读取到缓冲区的二进制写入到新文件中去
                            writeStream.Write(bufferBytes, 0, readCount);
                            int progress = (int)((writeStream.Position / (float)readStream.Length) * 100);
                            if (progress > lastProgress)
                            {
                                lastProgress = progress;
                                //Debug.Log(string.Format("当前拷贝进度:{0}%", progress));
                            }
                            readCount = readStream.Read(bufferBytes, 0, bufferBytes.Length);
                        }
                        //Debug.Log("拷贝完成！");
                    }
                }

                //using (FileStream fsRead = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
                //{
                //    using (FileStream fsWrite = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                //    {
                //        byte[] bufferBytes = new byte[1024 * 1024 * 5];
                //        int readCount = 0;
                //        int lastProgress = 0;
                //        while ((readCount = fsRead.Read(bufferBytes, 0, bufferBytes.Length)) > 0)
                //        {
                //            ////进行简单加解密,byte是255,这里简单对读写的数据进行255-byte进行加密，解密就再进行一次同样操作
                //            //for (int i = 0; i < readCount; i++)
                //            //{
                //            //    bufferBytes[i] = (byte)(byte.MaxValue - bufferBytes[i]);
                //            //}
                //            //将读取到缓冲区的二进制写入到新文件中去
                //            fsWrite.Write(bufferBytes, 0, readCount);
                //            int progress = (int)((fsWrite.Position / (float)fsRead.Length) * 100);
                //            if (progress > lastProgress)
                //            {
                //                lastProgress = progress;
                //                Console.WriteLine("当前拷贝进度:{0}%", progress);
                //            }
                //        }
                //        Console.WriteLine("拷贝完成！");
                //        Console.ReadLine();
                //    }
                //}
            }
            else
            {
                Debug.LogFormat("{0}文件不存在!", srcPath);
            }
        }

        /// <summary>
        /// 以文件流的形式复制大文件(同步)
        /// </summary>
        /// <param name="this">源</param>
        /// <param name="dest">目标地址</param>
        /// <param name="bufferSize">缓冲区大小，默认8MB</param>
        public void CopyFileSync(string src, string dest)
        {
            using (FileStream fsRead = new FileStream(src, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsWrite = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    int bufferSize = 1024 * 1024 * 4;
                    byte[] buf = new byte[bufferSize];
                    int len;
                    while ((len = fsRead.Read(buf, 0, buf.Length)) != 0)
                    {
                        fsWrite.Write(buf, 0, len);
                    }
                }
            }
        }

        /// <summary>
        /// 使用async异步拷贝文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="targetPath"></param>
        public async void CopyFileAsync(string srcPath, string targetPath)
        {
            if (!string.IsNullOrEmpty(srcPath) && File.Exists(srcPath))
            {
                if (!string.IsNullOrEmpty(targetPath))
                {
                    FileInfo fileInfo = new FileInfo(targetPath);
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }
                }
                using (FileStream srcStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream targetStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        await srcStream.CopyToAsync(targetStream);
                    }
                }
            }
        }

        /// <summary>
        /// 内存流保存为文件
        /// </summary>
        public void SaveFile(MemoryStream memoryStream, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                using (FileStream writeStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] needSaveDatas = memoryStream.ToArray();
                    writeStream.Write(needSaveDatas, 0, needSaveDatas.Length);
                    writeStream.Flush();
                }
            }
        }

        //文字读取
        public void CopyText(string srcPath, string targetPath)
        {
            if (!string.IsNullOrEmpty(srcPath) && File.Exists(srcPath))
            {
                //读取文字的流
                using (StreamReader srReader = new StreamReader(srcPath, Encoding.Default))
                {
                    //写入文字的流
                    using (StreamWriter srWriter = new StreamWriter(targetPath))
                    {
                        while (!srReader.EndOfStream)
                        {
                            string lineText = srReader.ReadLine();
                            srWriter.WriteLine(lineText);
                        }
                    }
                }
            }
        }
    }
}
