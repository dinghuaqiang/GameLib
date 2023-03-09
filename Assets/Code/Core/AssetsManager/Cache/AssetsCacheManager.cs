using GameLib.Core.Utils;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源Cache管理器
    /// 1.AppPersistData.LastCacheResBaseCode在启动的时候判断是否为新的app时进行增加1000
    /// 2.通过修复记录来进行增加1
    /// </summary>
    public class AssetsCacheManager
    {
        //资源文件的标记
        private const string CN_ASSET_FILE_FLAG = "GameAssets/Resources/";

        //文件修复记录
        private static RepairRecordFileData _repairRecord = new RepairRecordFileData();
        //cahce的基础版本号
        private static int _baseCacheVersion = 0;

        //初始化处理
        public static void Initialize()
        {
            _baseCacheVersion = AppPersistData.LastCacheResBaseCode;
            SetCacheMaxSize(800);
            _repairRecord.Read();
            DevLog.Log("BaseCacheVersion:" + _baseCacheVersion);
        }

        /// <summary>
        /// 获取文件版本
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int GetFileVersion(string filePath)
        {
            int idx = filePath.IndexOf(CN_ASSET_FILE_FLAG);
            if (idx >= 0)
            {
                return _repairRecord.GetRepairCount(filePath.Substring(idx)) + _baseCacheVersion;
            }
            return _baseCacheVersion;
        }

        #region //私有函数
        //设置Cache的大小
        private static void SetCacheMaxSize(int size)
        {
            var curCache = UnityEngine.Caching.defaultCache;
            curCache.maximumAvailableStorageSpace = size * 1024 * 1024;
            FLogger.Log("设置Cache大小为:", curCache.maximumAvailableStorageSpace, "可用空间:", curCache.spaceFree, "已用:", curCache.spaceOccupied);
        }
        #endregion
    }
}
