using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// TODO 这里要具体写和安卓交互的函数来获取数据
    /// </summary>
    public class AndroidDeviceInfo : IDeviceInfo
    {
        public double GetAppUsedMemory()
        {
            throw new System.NotImplementedException();
        }

        public long GetAvailableMemory()
        {
            throw new System.NotImplementedException();
        }

        public double GetFreeDiskspace()
        {
            throw new System.NotImplementedException();
        }

        public string GetPhoneNumber()
        {
            /// TelephonyManager tm = (TelephonyManager)this.getSystemService(Context.TELEPHONY_SERVICE);
            /// return tm.getLine1Number();//获取本机号码
            throw new System.NotImplementedException();
        }

        public float GetScreenBrightness()
        {
            throw new System.NotImplementedException();
        }

        public string GetSimOperator()
        {
            throw new System.NotImplementedException();
        }

        public void SetScreenBrightness(float value)
        {
            throw new System.NotImplementedException();
        }
    }
}
