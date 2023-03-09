using GameLib.Core.Utils;
using UnityEngine;

namespace GameLib.Core.Base
{
    //内存等级
    public enum MemoryLevel
    {
        Low,
        Middle,
        High,
    }

    public class MemoryMonitor
    {
        #region //常量
        //当空闲内存低于300M
        private const float _lowRAMStandard = 300f;
        //空闲内存为500M
        private const float _midRAMStandard = 500f;


        #endregion

        #region//私有变量
        //内存等级
        private static MemoryLevel _level;
        //总的内存数量
        private static int _sumRAM = -1;
        #endregion

        #region //公共接口

        //构造函数
        static MemoryMonitor()
        {
            _sumRAM = SystemInfo.systemMemorySize;
            _level = GetCurrentMemoryLevel();
            Debug.Log("app启动后的内存等级:" + _level);
        }

        //内存等级
        public static MemoryLevel Level
        {
            get
            {
                return _level;
            }
        }

        //当前内存等级
        public static MemoryLevel GetCurrentMemoryLevel()
        {
            var _lastRAMValue = (float)DeviceInfoManager.Instance.GetAvailableMemory();
            Debug.Log("当前总体内存:" + _sumRAM + ";;当前可用内存:" + _lastRAMValue);
            //如果获取当前可用内存小于0,那么就表示读取空闲内存失败,那么就判断总体内存
            if (_lastRAMValue < 0)
            {
                if (_sumRAM > 3000)     //大于3G
                {
                    return MemoryLevel.High;
                }
                else if (_sumRAM > 2000) //大于2G
                {
                    return MemoryLevel.Middle;
                }
                else
                {
                    return MemoryLevel.Low;
                }
            }

            if (_lastRAMValue <= _lowRAMStandard)
            {
                return MemoryLevel.Low;
            }
            else if (_lastRAMValue <= _midRAMStandard)
            {
                return MemoryLevel.Middle;
            }
            else
            {
                return MemoryLevel.High;
            }
        }

        //当前内存信息
        public static string Infomation()
        {
            var sb = StringUtils.NewStringBuilder;
            sb.AppendLine("MemoryMonitor:");
            sb.AppendLine();
            sb.AppendFormat("Free:" + DeviceInfoManager.Instance.GetAvailableMemory());
            sb.AppendLine();
            sb.AppendFormat("Sum:" + DeviceInfoManager.Instance.GetSumMemory());
            sb.AppendLine();
            sb.AppendFormat("AppUsed:" + DeviceInfoManager.Instance.GetAppUsedMemory());
            return sb.ToString();
        }

        #endregion
    }
}
