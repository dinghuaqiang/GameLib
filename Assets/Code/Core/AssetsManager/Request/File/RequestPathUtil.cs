using GameLib.Core.Utils;
using System.IO;
using UnityEngine;

namespace GameLib.Core.Asset
{  
    /// <summary>
    /// 资源请求路径工具类，用于修复路径
    /// </summary>
    public class RequestPathUtil
    {
        public const bool USE_LZ4 = false;

        //判断文件是否存在，
        public static bool IsFileExists(string path, out string fixPath,out bool inAndroidPkg)
        {
            inAndroidPkg = false;
            bool ret = false;
            fixPath = path;
            if (File.Exists(path))
            {
                ret = true;
            }
            else
            {
                string rootPath = PathUtils.GetReleaseResRootPath();
                if (path.StartsWith(rootPath))
                {
                    var _isBuildType = PathUtils.GetBuildType();
                    switch (_isBuildType)
                    {
                        case 1: //在Iphone下
                                ///var/containers/Application/E5543D66-83F3-476D-8A8F-49D5332B3763/myProj.app/Data/Raw
                            fixPath = path.Replace(rootPath, Application.streamingAssetsPath);
                            ret = File.Exists(fixPath);
                            break;
                        case 2: //在android下 -- 在Unity5.5之后,直接使用streamingAssetsPath就可以了.
                                ///data/app/com.myCompany.myProj-1/base.apk                                
                            //fixPath = path.Replace(rootPath, Application.dataPath + "!/assets");
                            //string dir = fixPath.Substring(0, fixPath.LastIndexOf("/"));
                            //string lowerName = fixPath.Substring(fixPath.LastIndexOf("/")).ToLower();
                            //fixPath = dir + lowerName;

                            fixPath = path.Replace(rootPath, Application.streamingAssetsPath);
                            //如果在包体内,默认存在
                            inAndroidPkg = true;
                            ret = true;
                            break;
                        case 3: //PC目录
                            ret = false;
                            break;
                    }
                }
            }
            FLogger.DebugLog("修复路径:" + fixPath);
            return ret;
        }

        //使用LZ4和5.x新的打bundle后，assetName可以直接是文件名本身
        //这里读取文件名，同时需要判断Prefab和VFX文件路径，因为是打包成scriptableObject的
        public static string FixeRequestPath(string requestPath)
        {
            //if (!USE_LZ4)
            //    return requestPath;

            var retStr =  System.IO.Path.GetFileNameWithoutExtension(requestPath); 
            //prefab和vfx使用了lz4压缩，读取bundle中asset只需要文件名即可
            if (requestPath.IndexOf("Prefab/") >= 0 || requestPath.IndexOf("VFX/") >= 0 || requestPath.IndexOf("TimeLine/") >= 0)
            {
                retStr += "_ScriptableObject";
            }

            return retStr;
        }
      
    }
}
