namespace GameLib.Core.Base
{
    /// <summary>
    /// 设备信息获取的接口
    /// 这里定义的函数只有和移动设备交互的
    /// </summary>
    public interface IDeviceInfo
    {
        //获取剩余的可用内存,单位MB
        long GetAvailableMemory();
        
        //获取当前App使用的内存,单位MB
        double GetAppUsedMemory();

        //获取磁盘剩余空间大小
        double GetFreeDiskspace();

        //获取手机号码
        string GetPhoneNumber();

        //SIM卡运营商
        string GetSimOperator();

        //获取屏幕的亮度
        float GetScreenBrightness();

        //设置屏幕的亮度
        void SetScreenBrightness(float value);
    }
}
