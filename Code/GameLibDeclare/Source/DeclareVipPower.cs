//文件是自动生成,请勿手动修改.来自数据文件:vipPower
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVipPower
    {
        #region //静态变量定义
        private static int _vipPower_Index = -1;
        private static int _powerDescribe_Index = -1;
        private static int _vipLevelUpDescribe_Index = -1;
        private static int _designDesc_Index = -1;
        private static int _isSpecialPower_Index = -1;
        private static int _vipPowerPrice_Index = -1;
        #endregion
        #region //私有变量定义
        //vip特权项，用于vip表直接调用ID（ID一定不能够修改，删除，因为大部分是程序写死处理的）
        private int _vipPower;
        //客户端实际调用（hide）
        private int _powerDescribe;
        //VIP提升时显示在界面上文字（解决界面文字颜色不通用的问题）
        //（hide）
        private int _vipLevelUpDescribe;
        //策划用（hide）
        private int _designDesc;
        //非特殊展示特权配置0或空
        //需要展示的特殊配置Icon编号
        //（hide）
        private int _isSpecialPower;
        //可购买次数特权对应的价格
        private int _vipPowerPrice;
        #endregion

        #region //公共属性
        public int VipPower { get{ return _vipPower; }}
        public string PowerDescribe { get{ return HanderDefine.SetStingCallBack(_powerDescribe); }}
        public string VipLevelUpDescribe { get{ return HanderDefine.SetStingCallBack(_vipLevelUpDescribe); }}
        public string DesignDesc { get{ return HanderDefine.SetStingCallBack(_designDesc); }}
        public int IsSpecialPower { get{ return _isSpecialPower; }}
        public string VipPowerPrice { get{ return HanderDefine.SetStingCallBack(_vipPowerPrice); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVipPower cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVipPower> _dataCaches = null;
        public static Dictionary<int, DeclareVipPower> CacheData
        {
            get 
            {
                lock (_lockObj)
                {
                    if (_dataIndexCaches == null)
                        SetBaseData();
                    if(!_dataCacheFull)
                    {
                        _dataCacheFull = true;
                        //读取所有数据
                        if (HanderDefine.DataCallBack("VipPower", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVipPower cfg = null;
                                if (!_dataCaches.TryGetValue(iter.Current.Key, out cfg))
                                {
                                    cfg = LoadSingleData(iter.Current.Value);
                                    _dataCaches[iter.Current.Key] = cfg;
                                }
                            }
                        }
                    }
                    return _dataCaches;
                }
            }
        }
        private static Dictionary<int, int> _dataIndexCaches = null;
        public static int CacheDataCount
        {
            get 
            {
                lock (_lockObj)
                {
                    if (_dataIndexCaches == null)
                        SetBaseData();
                    return _dataIndexCaches.Count;
                }
            }
        }
        private static int _indexFactor = 0;
        private static IntPtr _compressData = IntPtr.Zero;
        private static int[] _columnArr = null;
        private static int[] _ShiftArr = null;
        private static long[] _AndArr = null;
        private static int _compressMaxColumn = 0;

        private unsafe static long GetValue(int row, int column, int * ptr)
        {
            if(column < 0)
                return 0;
            int curColumn = _columnArr[column];
            int shift = _ShiftArr[column];
            long andData = _AndArr[column];
            long compressDataItem = 0;
            int index = (row * _compressMaxColumn + curColumn) * _indexFactor;
            int* valuePtr = ptr + index;
            compressDataItem = *(long*)valuePtr;
            long tempData = compressDataItem >> shift;
            long data = tempData & andData;
            long andSign = andData + 1;
            bool isMinus = (tempData & andSign) == andSign;
            return isMinus ? -data : data;
        }
        private unsafe static DeclareVipPower LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVipPower();
            tmp._vipPower = (int)GetValue(keyIndex, _vipPower_Index, ptr);
            tmp._powerDescribe = (int)GetValue(keyIndex, _powerDescribe_Index, ptr);
            tmp._vipLevelUpDescribe = (int)GetValue(keyIndex, _vipLevelUpDescribe_Index, ptr);
            tmp._designDesc = (int)GetValue(keyIndex, _designDesc_Index, ptr);
            tmp._isSpecialPower = (int)GetValue(keyIndex, _isSpecialPower_Index, ptr);
            tmp._vipPowerPrice = (int)GetValue(keyIndex, _vipPowerPrice_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("VipPower", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("VipPower", out _vipPower_Index)) _vipPower_Index = -1;
                    if (!nameIndexs.TryGetValue("PowerDescribe", out _powerDescribe_Index)) _powerDescribe_Index = -1;
                    if (!nameIndexs.TryGetValue("VipLevelUpDescribe", out _vipLevelUpDescribe_Index)) _vipLevelUpDescribe_Index = -1;
                    if (!nameIndexs.TryGetValue("DesignDesc", out _designDesc_Index)) _designDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSpecialPower", out _isSpecialPower_Index)) _isSpecialPower_Index = -1;
                    if (!nameIndexs.TryGetValue("VipPowerPrice", out _vipPowerPrice_Index)) _vipPowerPrice_Index = -1;
                    _columnArr = new int[nameIndexs.Count];
                    _ShiftArr = new int[nameIndexs.Count];
                    _AndArr = new long[nameIndexs.Count];
                    unsafe
                    {
                        int* ptr = (int*)columnShiftAndList.ToPointer();
                        for (int i = 0; i < nameIndexs.Count; i++)
                        {
                            int startIndex = i * 3;
                            _columnArr[i] = ptr[startIndex * _indexFactor] - 1;
                            _ShiftArr[i] = ptr[(startIndex + 1) * _indexFactor];
                            int index = (startIndex + 2) * _indexFactor;
                            int* valuePtr = ptr + index;
                            _AndArr[i] = *(long*)valuePtr;
                        }
                        _dataCaches = new Dictionary<int, DeclareVipPower>(keyCount);
                        _dataIndexCaches = new Dictionary<int, int>(keyCount);
                        ptr = (int*)_compressData.ToPointer();
                        for (int i = 0; i < keyCount; i++)
                        {
                            var key = (int)GetValue(i, 0, ptr);
                            _dataIndexCaches.Add(key, i);
                        }
                    }
                    _compressData = IntPtr.Zero;
                }
            }
        }
        //遍历函数，只能通过此函数遍历
        public static void Foreach(ForeachHandler func)
        {
            if(func == null)
                return;
            if (_dataCaches == null)
                SetBaseData();
            //读取所有数据
            if(HanderDefine.DataCallBack("VipPower", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVipPower cfg = null;
                    if (!_dataCaches.TryGetValue(iter.Current.Key, out cfg))
                    {
                        cfg = LoadSingleData(iter.Current.Value);
                        _dataCaches[iter.Current.Key] = cfg;
                    }
                    if (!func(cfg))
                    {
                        break;
                    }
                }
            }
            _compressData = IntPtr.Zero;
        }
        //根据ID获取数据
        public static DeclareVipPower Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVipPower result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("VipPower", out _compressData))
                    {
                        result = LoadSingleData(keyIndex);
                        _dataCaches[id] = result;
                    }
                    _compressData = IntPtr.Zero;
                }
                return result;
            }
        }
        #endregion
    }
}
