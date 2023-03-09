using System;
using System.IO;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 文件操作的方法处理
    /// </summary>
    public class FileUtils
    {
        //释放资源
        public static bool ReleaseFiles(string sourceDir,string[] dirOrFileList, string destDir)
        {
            for (int i = 0; i < dirOrFileList.Length; i++)
            {
                string s = sourceDir + "/" + dirOrFileList[i];
                string d = destDir + "/" + dirOrFileList[i];
                if (File.Exists(s))
                {
                    CopyFile(s, d, true);
                }
                else
                {
                    if (Directory.Exists(s))
                    {
                        CopyDirectory(s, d);
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// 批量删除文件
        /// </summary>
        /// <param name="destDir"></param>
        /// <param name="fileList"></param>
        /// <returns></returns>
        public static bool DeleteFiles(string destDir, string[] dirOrFileList)
        {
            for (int i = 0; i < dirOrFileList.Length; i++)
            {   
                string d = destDir + "/" + dirOrFileList[i];
                if (File.Exists(d))
                {
                    File.Delete(d);
                }
                else
                {
                    if (Directory.Exists(d))
                    {
                        DeleteDirectory(d);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="sDir"></param>
        /// <param name="dDir"></param>
        /// <returns></returns>
        public static bool CopyDirectory(string sDir,string dDir)
        {
            if (Directory.Exists(sDir))
            {
                try
                {
                    if (!Directory.Exists(dDir))
                    {
                        Directory.CreateDirectory(dDir);
                    }
                    var fs = Directory.GetFiles(sDir, "*.*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < fs.Length; i++)
                    {
                        File.Copy(fs[i], fs[i].Replace(sDir, dDir), true);
                    }

                    var ds = Directory.GetDirectories(sDir, "*.*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < ds.Length; i++)
                    {
                        CopyDirectory(ds[i], ds[i].Replace(sDir, dDir));
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    Debug.LogError("CopyDirectory复制目录失败!s:" + sDir + ";;d:" + dDir);
                    Debug.LogException(ex);
                }
            }
            else
            {
                Debug.LogError("CopyDirectory:原始目录不存在."+sDir);
            }
            return false;
        }



        /// <summary>
        /// /复制文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="isOverwrite"></param>
        /// <returns></returns>
        public static bool CopyFile(string source, string dest, bool isOverwrite = true)
        {
            try
            {
                if (File.Exists(source))
                {
                    var fi = new FileInfo(dest);
                    if (!fi.Directory.Exists)
                    {
                        fi.Directory.Create();
                    }
                    File.Copy(source, dest, isOverwrite);
                    return true;
                }
                else
                {
                    Debug.LogError("没有找到源文件:" + source);
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("复制文件失败!s:" + source + ";;;d:" + dest);
                Debug.LogException(ex);                
            }
            return false;
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool DeleteDirectory(string dir)
        {
            try
            {
                if (!Directory.Exists(dir)) return true;
                //1.删除文件
                var files = Directory.GetFiles(dir);
                for (int i = 0; i < files.Length; i++)
                {
                    if (File.Exists(files[i]))
                        File.Delete(files[i]);
                }

                //2.删除目录
                bool isDelSubDirSuccess = true;
                var dirs = Directory.GetDirectories(dir);
                for (int i = 0; i < dirs.Length; i++)
                {
                    isDelSubDirSuccess = isDelSubDirSuccess && DeleteDirectory(dirs[i]);
                }

                //3.检查所有子是否删除干净,删除目录
                if (isDelSubDirSuccess)
                {
                    var fse = Directory.GetFileSystemEntries(dir);
                    if (fse.Length == 0)
                    {
                       
                        Directory.Delete(dir);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.LogError("删除目录的内容时,出现异常:" + dir);
                Debug.LogException(ex);
                return false;
            }
        }
    }
}
