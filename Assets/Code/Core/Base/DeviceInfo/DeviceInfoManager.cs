using Code.Core.Utils;
using GameLib.Core.Utils;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// 设备信息管理类
    /// </summary>
    public class DeviceInfoManager : Singleton<DeviceInfoManager>
    {
        /// <summary>
        /// 需要到对应平台设备去取的数据信息
        /// </summary>
        private IDeviceInfo _deviceInfo = null;

        public override void OnInitialize()
        {
            base.OnInitialize();
#if UNITY_ANDROID
            _deviceInfo = new AndroidDeviceInfo();
#elif UNITY_IPHONE
            _deviceInfo = new IPhoneDeviceInfo();
#else
            _deviceInfo = new WinDevicesInfo();
#endif
        }

        public override void OnUnInitialize()
        {
            base.OnUnInitialize();
            _deviceInfo = null;
        }

        /// <summary>
        /// 获取剩余的可用内存,单位MB
        /// </summary>
        public long GetAvailableMemory()
        {
            return _deviceInfo.GetAvailableMemory();
        }

        /// <summary>
        /// 获取当前App使用的内存,单位MB
        /// </summary>
        public double GetAppUsedMemory()
        {
            return _deviceInfo.GetAppUsedMemory();
        }

        /// <summary>
        /// 获取磁盘剩余空间大小
        /// </summary>
        public double GetFreeDiskspace()
        {
            return _deviceInfo.GetFreeDiskspace();
        }

        /// <summary>
        /// 获取手机号码
        /// </summary>
        public string GetPhoneNumber()
        {
            return _deviceInfo.GetPhoneNumber();
        }

        /// <summary>
        /// SIM卡运营商
        /// </summary>
        public string GetSimOperator()
        {
            return _deviceInfo.GetSimOperator();
        }

        /// <summary>
        /// 获取屏幕的亮度
        /// </summary>
        public float GetScreenBrightness()
        {
            return _deviceInfo.GetScreenBrightness();
        }

        /// <summary>
        /// 设置屏幕的亮度
        /// </summary>
        public void SetScreenBrightness(float value)
        {
            _deviceInfo.SetScreenBrightness(value);
        }

        /// <summary>
        /// 设备的唯一标识符。这个不一定太准确，可以把其他值混合来算计算一个单独的ID
        /// </summary>
        public string GetUniqueIdentifier()
        {
            //TODO  这个也有坑，卸载包之后会变，不是那种不变的ID
            return MachineUUID.Value;
            //return SystemInfo.deviceUniqueIdentifier;
        }

        //获取总的内存,单位MB
        public int GetSumMemory()
        {
            //系统内存大小
            return SystemInfo.systemMemorySize;
        }

        /// <summary>
        /// 设备型号 。例：iPhone6,2、Xiaomi MI 5
        /// </summary>
        public string GetDeviceModel()
        {
            return SystemInfo.deviceModel;
        }

        /// <summary>
        /// Unknown = 0,
        /// Handheld = 1, //手持设备，如手机，平板
        /// Console = 2, //游戏机
        /// Desktop = 3 //台式电脑，笔记本电脑
        /// </summary>
        public DeviceType GetDeviceType()
        {
            return SystemInfo.deviceType;
        }

        /// <summary>
        /// 用户定义的设备名称,比如:XX的小米手机
        /// </summary>
        /// <returns></returns>
        public string GetDeviceName()
        {
            return SystemInfo.deviceName;
        }

        /// <summary>
        /// 判断是否在通电状态
        /// </summary>
        public bool BatteryIsCharging()
        {
            
            return SystemInfo.batteryStatus == BatteryStatus.Charging;
        }

        /// <summary>
        /// 获取电池电量 返回0-1，-1就是不支持，获取不到
        /// </summary>
        public float GetBatteryLevel()
        {
            return SystemInfo.batteryLevel;
        }

        /// <summary>
        /// 设备CPU型号
        /// </summary>
        public string GetCPUName()
        {
            return SystemInfo.processorType;
        }

        /// <summary>
        /// 设备CPU频率
        /// </summary>
        public int GetCPUFrequency()
        {
            return SystemInfo.processorFrequency;
        }

        /// <summary>
        /// 设备CPU个数
        /// </summary>
        public int GetPhoneCores()
        {
            return SystemInfo.processorCount;
        }

        /// <summary>
        /// 系统名称与版本
        /// </summary>
        public string GetSystemName()
        {
            return SystemInfo.operatingSystem;
        }

        /// <summary>
        /// 获取显卡名称
        /// </summary>
        public string GetGraphicsDeviceName()
        {
            return SystemInfo.graphicsDeviceName;
        }

        /// <summary>
        /// 显卡的类型和版本
        /// </summary>
        public string GetGraphicsDeviceVersion()
        {
            return SystemInfo.graphicsDeviceVersion;
        }

        /// <summary>
        /// 获取显存大小 MB
        /// </summary>
        public int GetGraphicsMemorySize()
        {
            return SystemInfo.graphicsMemorySize;
        }
    }
}
