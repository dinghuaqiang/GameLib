using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 机器的唯一标示ID
    /// </summary>
    public static class MachineUUID
    {
        //文件路径
        private const string CN_FILE_PATH = "gonbest/muuid";

        //唯一标识符的值
        public static string Value = "";

        //静态构造
        static MachineUUID()
        {
            Value = GetSavedUUID();
        }

        /// <summary>
        /// 外部更新UUID的接口
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateUUID(string id)
        {
            if (!string.IsNullOrEmpty(id) && !string.Equals(id, Value))
            {
                Value = id;
                SaveUUID(id,GetUUIDFilePath());
            }
        }

        //获取保存的uuid，用于登陆参数
        private static string GetSavedUUID()
        {
            string uuid = "";
            try
            {
                string packagePath = GetUUIDFilePath();
                if (System.IO.File.Exists(packagePath))
                {
                    uuid = System.IO.File.ReadAllText(packagePath).Trim();
                }

                if (string.IsNullOrEmpty(uuid))
                {
                    uuid = System.Guid.NewGuid().ToString("B");
                    SaveUUID(uuid, packagePath);
                }
            }
            catch (System.Exception ex)
            {
                UnityEngine.Debug.LogWarning(ex);
            }
            UnityEngine.Debug.Log("Read uuid: " + uuid);
            return uuid;
        }

        //保存UUID
        private static void SaveUUID(string id, string filePath)
        {
            try
            {
                string rootDir = filePath.Substring(0, filePath.LastIndexOf('/'));

                if (!System.IO.Directory.Exists(rootDir))
                {
                    System.IO.Directory.CreateDirectory(rootDir);
                }
                System.IO.File.WriteAllText(filePath, id);
            }
            catch (System.Exception ex)
            {
                UnityEngine.Debug.LogException(ex);
            }

        }

        private static string GetUUIDFilePath()
        {
            string packagePath = string.Empty;
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                packagePath = PathUtils.GetWritePath(CN_FILE_PATH);
            }
            else
            {
                packagePath = PathUtils.GetDeviceRootPath(CN_FILE_PATH);
            }
            packagePath = System.IO.Path.GetFullPath(packagePath);
            packagePath = packagePath.Replace("\\", "/");
            return packagePath;
        }
    }
}
