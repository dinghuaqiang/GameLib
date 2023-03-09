namespace GameLib.Core.Utils
{
    /// <summary>
    /// 路径提供者的接口
    /// </summary>
    public interface IPathProvider
    {
        //app的文件所在路径
        string AppFilePath { get; }
        //app的数据路径
        string AppDataPath { get; }
        //app的stream路径
        string AppStreamPath { get; }
        //app中的Resouce路径
        string AppResourceRootPath { get; }
        //app中的config路径
        string AppConfigRootPath { get; }
        //app的持续化路径
        string AppPersistentPath { get; }

        //是否进行流文件读取
        bool IsStream { get; set; }

        //资源流所在目录
        string StreamingRootPath { get; }
        //需要写入的目录:比如日志,截图
        string WriteRootPath { get; }
        //资源所在目录
        string ResourceRootPath { get; }
        //配置文件所在目录
        string ConfigRootPath { get; }
        //设备根目录
        string DeviceRootPath { get; }
        //包释放资源所在目录,//获取资源释放路径中以包名命名的文件夹路径(SD卡跟路径）
        string ReleaseResRootPath { get; }

        string Print();

        string CombinePath(string rootPath, string relativePath);
    }
}
