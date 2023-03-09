using System.Collections.Generic;
using System.IO;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 通用的IO工具类
        /// </summary>
        public static class IO 
        {
            private const string CommonExceptionEx = ".svn|.DStore|.DS_Store|.meta";

            /// <summary>
            /// 删除文件夹下的所有文件以及文件夹
            /// </summary>
            /// <param name="folderPath">文件夹路径</param>
            public static void DeleteFolderAndFiles(string folderPath)
            {
                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo directory = Directory.CreateDirectory(folderPath);
                    FileInfo[] files = directory.GetFiles();
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                    DirectoryInfo[] folders = directory.GetDirectories();
                    foreach (var folder in folders)
                    {
                        DeleteFolderAndFiles(folder.FullName);
                    }
                    directory.Delete();
                }
            }

            /// <summary>
            /// 获取所有文件
            /// </summary>
            /// <param name="folder">路径</param>
            /// <param name="ext">通配符</param>
            /// <returns></returns>
            public static List<string> GetPathes(string folder, string ext)
            {
                return GetFiles(folder, ext, CommonExceptionEx);
            }

            /// <summary>
            /// 获取文件夹中的所有文件；
            /// </summary>
            /// <param name="path">地址</param>
            /// <returns>文件地址</returns>
            public static List<string> GetFiles(string path)
            {
                List<string> fileList = new List<string>();
                if (!Directory.Exists(path))
                {
                    return fileList;
                }
                //Directory.GetFiles("Device", ".dll");
                string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
                if (files != null)
                {
                    fileList.AddRange(files);
                }
                return fileList;
            }

            /// <summary>
            /// 获取文件列表，支持排除某些扩展名的文件
            /// </summary>
            /// <param name="dir"></param>
            /// <param name="ext"></param>
            /// <param name="exceptExt"></param>
            /// <returns></returns>
            public static List<string> GetFiles(string dir, string ext, string exceptExt = null)
            {
                List<string> fileList = new List<string>();
                if (!Directory.Exists(dir))
                {
                    return fileList;
                }
                //Directory.GetFiles("Device", ".dll");
                string[] files = Directory.GetFiles(dir, ext, SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; ++i)
                {
                    files[i] = files[i].Replace("\\", "/");
                }
                if (!string.IsNullOrEmpty(exceptExt))
                {
                    for (int i = 0; i < files.Length; ++i)
                    {
                        string extension = Path.GetExtension(files[i]);
                        if (!exceptExt.Contains(extension))
                        {
                            fileList.Add(files[i]);
                        }
                    }
                }
                else
                {
                    fileList.AddRange(files);
                }
                return fileList;
            }

            /// <summary>
            /// 创建文件夹
            /// </summary>
            /// <param name="path"></param>
            public static void CreateFolder(string path)
            {
                var dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                    DevLog.Log("The Folder: " + path + " has created!");
                }
            }

            /// <summary>
            /// 创建文件夹
            /// </summary>
            /// <param name="path">路径</param>
            /// <param name="folderName">文件夹名字</param>
            public static void CreateFolder(string path, string folderName)
            {
                var fullPath = Path.Combine(path, folderName);
                var dir = new DirectoryInfo(fullPath);
                if (!dir.Exists)
                {
                    dir.Create();
                    DevLog.Log("The Folder: " + path + " has created!");
                }
            }

            /// <summary>
            /// 拷贝文件到目标文件夹
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="toDir"></param>
            public static void CopyFileToDirectory(string filePath, string toDir)
            {
                if (!Directory.Exists(toDir))
                    Directory.CreateDirectory(toDir);

                string fileName = Path.GetFileName(filePath);
                string targetPath = toDir + "/" + fileName;
                //排除svn文件
                if (!filePath.Contains(".svn") && !targetPath.Contains(".svn"))
                {
                    File.Copy(filePath, targetPath, true);
                }
            }

            /// <summary>
            /// 拷贝文件夹的内容到另一个文件夹；
            /// </summary>
            /// <param name="source">原始地址</param>
            /// <param name="target">目标地址</param>
            public static void CopyFiles(DirectoryInfo source, DirectoryInfo target)
            {
                if (!Directory.Exists(target.FullName))
                {
                    Directory.CreateDirectory(target.FullName);
                }
                //复制所有文件到新地址
                foreach (FileInfo fileInfo in source.GetFiles())
                {
                    fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
                }
                //递归拷贝所有子目录
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyFiles(diSourceSubDir, nextTargetSubDir);
                }
            }

            /// <summary>
            /// 拷贝文件夹的内容到另一个文件夹；
            /// </summary>
            /// <param name="sourceDirectory">原始地址</param>
            /// <param name="targetDirectory">目标地址</param>
            public static void CopyDirFiles(string sourceDirectory, string targetDirectory)
            {
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
                CopyFiles(diSource, diTarget);
            }

            /// <summary>
            /// 文件夹拷贝
            /// </summary>
            /// <param name="srcDir"></param>
            /// <param name="destDir"></param>
            /// <param name="ext"></param>
            public static void CopyDirectory(string srcDir, string destDir, string ext = "*")
            {
                List<string> files = GetPathes(srcDir, "*");
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                for (int i = 0; i < files.Count; ++i)
                {
                    string targetFile = files[i].Replace(srcDir, destDir);
                    //不存在路径则创建
                    CreateParentDirectory(targetFile);
                    if (!files[i].Contains(".svn") && !targetFile.Contains(".svn"))
                    {
                        File.Copy(files[i], targetFile, true);
                    }
                }
            }

            /// <summary>
            /// 根据文件路径创建父目录（拷贝到目标目录的时候有可能没文件夹）
            /// </summary>
            /// <param name="filePath"></param>
            public static void CreateParentDirectory(string filePath) 
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    string parentDir = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(parentDir))
                    {
                        Directory.CreateDirectory(parentDir);
                    }
                }
            }

            /// <summary>
            /// 删除文件
            /// </summary>
            /// <param name="fileFullPath"></param>
            public static void DeleteFile(string fileFullPath)
            {
                if (File.Exists(fileFullPath))
                {
                    File.Delete(fileFullPath);
                }
            }

            /// <summary>
            /// 删除文件夹下的所有文件以及文件夹
            /// </summary>
            /// <param name="folderPath">文件夹路径</param>
            public static void DeleteDirAndFiles(string folderPath)
            {
                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo directory = Directory.CreateDirectory(folderPath);
                    FileInfo[] files = directory.GetFiles();
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                    DirectoryInfo[] folders = directory.GetDirectories();
                    foreach (var folder in folders)
                    {
                        DeleteDirAndFiles(folder.FullName);
                    }
                    directory.Delete();
                }
            }

            /// <summary>
            /// 重命名文件；
            /// 第一个参数需要：盘符+地址+文件名+后缀；
            /// 第二个参数仅需文件名+后缀名；
            /// </summary>
            /// <param name="oldFileFullPath">旧文件的完整路径，需要带后缀名</param>
            /// <param name="newFileNamewithExtension">新的文件名，仅需文件名+后缀名</param>
            public static void RenameFile(string oldFileFullPath, string newFileNamewithExtension)
            {
                if (!File.Exists(oldFileFullPath))
                {
                    //创建文件之后要释放流
                    File.Create(oldFileFullPath).Close();
                }
                var dirPath = Path.GetDirectoryName(oldFileFullPath);
                var newFileName = Path.Combine(dirPath, newFileNamewithExtension);
                if (File.Exists(newFileName)) 
                {
                    File.Delete(newFileName);
                }
                File.Move(oldFileFullPath, newFileName);
            }

            /// <summary>
            /// 获取共同的路径；
            /// </summary>
            /// <param name="paths">传入的路径合集</param>
            /// <returns>共同的路径</returns>
            public static string GetCommonPath(string[] paths)
            {
                var firstPath = paths[0];
                bool isSame = true;
                int index = 0;
                string commonPath = string.Empty;
                while (isSame && index < firstPath.Length)
                {
                    for (int i = 1; i < paths.Length && isSame; i++)
                    {
                        isSame = firstPath[index] == paths[i][index];
                    }
                    if (isSame)
                        commonPath += firstPath[index];
                    index++;
                }
                return commonPath;
            }

            /// <summary>
            /// 标准 Windows 文件路径地址合并；
            /// 返回结果示例：Resources\JsonData\
            /// </summary>
            /// <param name="paths">路径params</param>
            /// <returns>合并的路径</returns>
            public static string PathCombine(params string[] paths)
            {
                var resultPath = Path.Combine(paths);
                resultPath = resultPath.Replace("/", "\\");
                return resultPath;
            }

            /// <summary>
            /// 合并路径；
            /// web类型地址合并， 获得的路径将以 / 作为分割符；
            /// 返回结果示例：github.com/DonnYep/CosmosFramework
            /// </summary>
            /// <param name="paths">路径</param>
            /// <returns>合并的路径</returns>
            public static string WebPathCombine(params string[] paths)
            {
                var pathResult = Path.Combine(paths);
                pathResult = pathResult.Replace("\\", "/");
                return pathResult;
            }

            /// <summary>
            /// 读取字符串
            /// </summary>
            /// <param name="filePath"></param>
            /// <returns></returns>
            public static string ReadString(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    DevLog.LogErrorFormat("文件:{0}不存在！", filePath);
                }
                return File.ReadAllText(filePath);
            }

            /// <summary>
            /// 读取文件内容到byte数组，不作binary或者text转换；
            /// </summary>
            /// <param name="fileFullPath">文件的完整路径，包括后缀名等</param>
            /// <returns>读取到的文件byte数组</returns>
            public static byte[] ReadFileBytes(string fileFullPath)
            {
                if (!File.Exists(fileFullPath))
                {
                    DevLog.LogErrorFormat("文件读取失败，文件{0}不存在!", fileFullPath);
                    return null;
                }
                return File.ReadAllBytes(fileFullPath);
            }

            /// <summary>
            /// 读取二进制资源
            /// </summary>
            /// <param name="filePath">资源路径</param>
            /// <returns></returns>
            public static byte[] ReadBinaryFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    DevLog.LogErrorFormat("要读取的文件：{0}不存在，读取失败！", filePath);
                    return null;
                }
                using (FileStream stream = File.Open(filePath, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.UTF8))
                    {
                        return reader.ReadBytes((int)stream.Length);
                    }
                }
            }

            /// <summary>
            /// 不适用Text类型！；
            /// 写入二进制类型文件；
            /// </summary>
            /// <param name="context">文件内容</param>
            /// <param name="fileFullPath">文件完整路径，带后缀名</param>
            public static void WriteBinaryFile(byte[] context, string fileFullPath)
            {
                using (FileStream stream = File.Open(fileFullPath, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(context);
                        writer.Flush();
                    }
                }
            }

            /// <summary>
            /// 将byte数组写成文件；
            /// 若写入时文件夹路径不存在，则创建文件夹；
            /// </summary>
            /// <param name="context">需要写入的数据byte数组</param>
            /// <param name="fileFullPath">文件的完整路径，包括后缀名等</param>
            public static void WriteFile(byte[] context, string fileFullPath)
            {
                var folderPath = Path.GetDirectoryName(fileFullPath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileFullPath, FileMode.OpenOrCreate)))
                {
                    writer.Write(context);
                }
            }

            /// <summary>
            /// 追加写入；
            /// 将byte数组写成文件；
            /// 若写入时文件夹路径不存在，则创建文件夹；
            /// </summary>
            /// <param name="context">需要写入的数据byte数组</param>
            /// <param name="fileFullPath">文件的完整路径，包括后缀名等</param>
            /// <param name="startPosition">追加写入的起始位置</param>
            public static void WriteFile(byte[] context, string fileFullPath, int startPosition)
            {
                var folderPath = Path.GetDirectoryName(fileFullPath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileFullPath, FileMode.OpenOrCreate)))
                {
                    writer.Write(context, startPosition, context.Length);
                }
            }

            /// <summary>
            /// 追加并完全写入所有bytes;
            /// </summary>
            /// <param name="path">写入的地址</param>
            /// <param name="bytesArray">数组集合</param>
            /// <returns>写入的长度</returns>
            public static long AppendAndWriteAllBytes(string path, params byte[][] bytesArray)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    var bytesArrayLength = bytesArray.Length;
                    int size = 0;
                    for (int i = 0; i < bytesArrayLength; i++)
                    {
                        stream.Write(bytesArray[i], 0, bytesArray[i].Length);
                        size += bytesArray[i].Length;
                    }
                    var bytesLength = stream.Length;
                    File.WriteAllBytes(path, stream.ToArray());
                    stream.Close();
                    return bytesLength;
                }
            }

            /// <summary>
            /// 使用UTF8编码；
            /// 追加写入文件信息；
            /// 若文件为空，则自动创建；
            /// 此方法为text类型文件写入
            /// </summary>
            /// <param name="fileFullPath">文件完整路径</param>
            /// <param name="context">写入的信息</param>
            public static void AppendWriteTextFile(string fileFullPath, string context)
            {
                using (FileStream stream = new FileStream(fileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    stream.Position = stream.Length;
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(context);
                        writer.Flush();
                    }
                }
            }

            /// <summary>
            /// 写入字符串到指定文件
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="content"></param>
            public static void WriteTextFile(string filePath, string content)
            {
                //文件不存在就创建
                if (!File.Exists(filePath))
                {
                    CreateFile(filePath);
                }
                File.WriteAllText(filePath, content);
            }

            /// <summary>
            /// 根据路径生成一个文件，没有路径或者文件就直接创建
            /// </summary>
            /// <param name="filePath"></param>
            public static void CreateFile(string filePath)
            {
                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Directory.Exists)
                {
                    //没有文件夹就创建文件夹
                    fileInfo.Directory.Create();
                }
                if (!File.Exists(filePath))
                {
                    //没有文件就创建文件
                    File.Create(filePath).Dispose();
                }
            }

            /// <summary>
            /// 使用UTF8编码；
            /// 写入文件信息；
            /// 若文件为空，则自动创建；
            /// 此方法为text类型文件写入；
            /// </summary>
            /// <param name="filePath">文件路径</param>
            /// <param name="fileName">文件名</param>
            /// <param name="context">写入的信息</param>
            /// <param name="append">是否追加</param>
            public static void WriteTextFile(string filePath, string fileName, string context, bool append = false)
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                using (FileStream stream = File.Open(Path.Combine(filePath, fileName), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (append)
                        stream.Position = stream.Length;
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(context);
                        writer.Flush();
                    }
                }
            }

            /// <summary>
            ///  完全覆写，使用UTF8编码；
            /// </summary>
            /// <param name="filePath">w文件路径</param>
            /// <param name="fileName">文件名</param>
            /// <param name="context">写入的信息</param>
            public static void OverwriteTextFile(string filePath, string fileName, string context)
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                var fileFullPath = Path.Combine(filePath, fileName);
                using (FileStream stream = File.Open(fileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(context);
                        writer.Flush();
                    }
                }
            }

            /// <summary>
            /// 完全覆写；
            ///  使用UTF8编码；
            /// </summary>
            /// <param name="fileFullPath">文件完整路径</param>
            /// <param name="context">写入的信息</param>
            public static void OverwriteTextFile(string fileFullPath, string context)
            {
                using (FileStream stream = File.Open(fileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(context);
                        writer.Flush();
                    }
                }
            }

            /// <summary>
            /// 清空text类型的文本
            /// </summary>
            /// <param name="fileFullPath">完整文件路径</param>
            /// <returns>是否写入成功</returns>
            public static bool ClearTextContext(string fileFullPath)
            {
                if (!File.Exists(fileFullPath))
                    return false;
                File.WriteAllText(fileFullPath, string.Empty);
                return true;
            }

            /// <summary>
            /// 获取文件大小；
            /// 若文件存在，则返回正确的大小；若不存在，则返回-1；
            /// </summary>
            /// <param name="filePath">文件地址</param>
            /// <returns>文件long类型的长度</returns>
            public static long GetFileSize(string filePath)
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    return -1;
                }
                else if (File.Exists(filePath))
                {
                    return new FileInfo(filePath).Length;
                }
                return -1;
            }

            /// <summary>
            /// 获取文件夹所包含的文件大小；
            /// </summary>
            /// <param name="path">路径</param>
            /// <returns>文件夹大小</returns>
            public static long GetDirectorySize(string path)
            {
                if (!Directory.Exists(path))
                    return 0;
                DirectoryInfo directory = new DirectoryInfo(path);
                var allFiles = directory.GetFiles();
                long totalSize = 0;
                foreach (var file in allFiles)
                {
                    totalSize += file.Length;
                }
                return totalSize;
            }

            /// <summary>
            /// 获取文件夹中的文件数量；
            /// </summary>
            /// <param name="folderPath">文件夹路径</param>
            /// <returns>文件数量</returns>
            public static int FolderFileCount(string folderPath)
            {
                int count = 0;
                var files = Directory.GetFiles(folderPath); //String数组类型
                count += files.Length;
                var dirs = Directory.GetDirectories(folderPath);
                foreach (var dir in dirs)
                {
                    count += FolderFileCount(dir);
                }
                return count;
            }

        }
    }
}
