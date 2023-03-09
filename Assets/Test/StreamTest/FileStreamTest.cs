using System;
using System.IO;
using System.Text;

namespace FileCopyTest
{
    public class FileStreamTest
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
                                Console.WriteLine("当前拷贝进度:{0}%", progress);
                            }
                            readCount = readStream.Read(bufferBytes, 0, bufferBytes.Length);
                        }
                        Console.WriteLine("拷贝完成！");
                        Console.ReadLine();
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
                Console.WriteLine("{0文件不存在!");
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
