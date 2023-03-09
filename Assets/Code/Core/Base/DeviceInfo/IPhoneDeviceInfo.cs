namespace GameLib.Core.Base
{
    public class IPhoneDeviceInfo : IDeviceInfo
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
            ///  UIDevice *device = [[UIDevice alloc]init];
            ///  NSString* idForVend = [NSString stringWithFormat: @"%@", [device identifierForVendor]];
            ///  NSLog(@"%@", idForVend);
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
