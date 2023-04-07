namespace GameLib.Core.Asset.CachePool
{
    /// <summary>
    /// SpawnPool的设置
    /// </summary>
    public class SpawnPoolSettings
    {
        //是否启动自动清理器
        public bool StartupAutoCleaner { get; set; }
        //Prefab的生存期
        public int PrefabLiftTime { get; set; }
        //清理的Tick
        public int CleanerTick { get; set; }

        public SpawnPoolSettings()
        {
            StartupAutoCleaner = false;
            PrefabLiftTime = 120;
            CleanerTick = 30;
        }
    }
}
