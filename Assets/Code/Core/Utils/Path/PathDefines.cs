namespace GameLib.Core.Utils.Path
{
    /// <summary>
    /// 常用路径定义
    /// </summary>
    public class PathDefines
    {
        #region //资源路径,以及配置文件所在路径,这些路径都有可能会被编辑器使用 ---都是读取AssetRoot的路径
        //资源所在目录
        public static string AssetsPath
        {
            get
            {
                return PathUtils.GetResourcePath(string.Empty);
            }
        }

        //本地版本路径
        public static string LocalVersionPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("LocalVersion.xml");
            }
        }

        //类型资源索引文件路径
        public static string PoolSettingsPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("PoolSettings.xml");
            }
        }

        //技能配置文件路径
        public static string SkillConfigPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("SkillCfg.xml");
            }
        }
        //技能配置文件路径
        public static string SkillConfigBinaryPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("SkillCfgBinary.bytes");
            }
        }

        //地图飞行传送数据
        public static string FlyTeleportConfigBinaryPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("FlyTeleportCfg.bytes");
            }
        }
        //类型资源索引文件路径
        public static string AllCharConfigPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("AllChar_{0}.bytes");
            }
        }

        //配置文件路径
        public static string Config_GlobalConfigPath
        {
            get
            {
                return PathUtils.GetConfigFilePath("Config");
            }
        }

        //地图目录路径
        public static string MapInfoDirPath
        {
            get
            {
                return PathUtils.GetResourcePath("/MapInfo");
            }
        }

        #endregion
    }
}
