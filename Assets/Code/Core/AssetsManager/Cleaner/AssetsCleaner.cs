using GameLib.Core.Utils;
using System.Collections;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源清理
    /// </summary>
    public class AssetsCleaner
    {
        //低内存标记
        public const int CN_LOW_MEMORY = 600;
        //是否正在清理
        private static bool _isCleanning = false;
        //是否还有下一个
        private static bool _hasNext = false;

        //清理所有的不用的资源
        public static void ClearUnUsedAsset()
        {
            _hasNext = true;
            if (!_isCleanning)
            {
                FLogger.DebugLog("Start Clear UnUsed Assets!!");
                _isCleanning = true;
                CoroutinePool.AddTask(DoClear());
            }
        }

        //清理某个对应资源
        public static void ClearAsset(UnityEngine.Object asset)
        {
            Resources.UnloadAsset(asset);
        }

        //清理的处理
        private static IEnumerator DoClear()
        {
            while (_hasNext)
            {
                yield return new WaitForEndOfFrame();
                _hasNext = false;
                yield return Resources.UnloadUnusedAssets();
                System.GC.Collect();
                yield return new WaitForSeconds(1f);
            }
            _isCleanning = false;
        }

        //判断是否更快的清理
        public static bool CheckedMoreFast()
        {
#if UNITY_IPHONE
            return SystemInfo.systemMemorySize < CN_LOW_MEMORY;
#else
            return false;
#endif
        }
    }
}
