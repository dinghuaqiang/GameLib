//文件是自动生成,请勿手动修改.来自数据文件:NewRedPacket
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewRedPacket
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _getReasons_Index = -1;
        private static int _value_Index = -1;
        private static int _time_Index = -1;
        private static int _maxNumber_Index = -1;
        private static int _minNumber_Index = -1;
        private static int _itemType_Index = -1;
        private static int _minGetValue_Index = -1;
        #endregion
        #region //私有变量定义
        //红包ID
        private int _id;
        //获得红包的原因1.首充奖励；2.每日充值；3.月卡；4.至尊月卡；5.成长基金6.巅峰基金；7.升级至VIP1；8.升级至VIP2；9.升级至VIP3；10.升级VIP4；11.升级VIP5；12.升级VIP6；13.升级VIP7；14.升级VIP8；15.升级VIP9；16.升级VIP10；17.升级VIP11；18.升级VIP12；19.升级VIP13；20.升级VIP14；21.升级VIP15；
        private int _getReasons;
        //红包内所含货币的数量
        private int _value;
        //红包持续时间（单位：分）
        private int _time;
        //最大红包个数
        private int _maxNumber;
        //最小红包个数
        private int _minNumber;
        //红包货币类型：
        //1.灵玉
        //2.绑定灵玉
        //12.元宝
        private int _itemType;
        //最小可获得红包内货币数量
        private int _minGetValue;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int GetReasons { get{ return _getReasons; }}
        public int Value { get{ return _value; }}
        public int Time { get{ return _time; }}
        public int MaxNumber { get{ return _maxNumber; }}
        public int MinNumber { get{ return _minNumber; }}
        public int ItemType { get{ return _itemType; }}
        public int MinGetValue { get{ return _minGetValue; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewRedPacket cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewRedPacket> _dataCaches = null;
        public static Dictionary<int, DeclareNewRedPacket> CacheData
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
                        if (HanderDefine.DataCallBack("NewRedPacket", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewRedPacket cfg = null;
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
        private unsafe static DeclareNewRedPacket LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewRedPacket();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._getReasons = (int)GetValue(keyIndex, _getReasons_Index, ptr);
            tmp._value = (int)GetValue(keyIndex, _value_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._maxNumber = (int)GetValue(keyIndex, _maxNumber_Index, ptr);
            tmp._minNumber = (int)GetValue(keyIndex, _minNumber_Index, ptr);
            tmp._itemType = (int)GetValue(keyIndex, _itemType_Index, ptr);
            tmp._minGetValue = (int)GetValue(keyIndex, _minGetValue_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewRedPacket", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("GetReasons", out _getReasons_Index)) _getReasons_Index = -1;
                    if (!nameIndexs.TryGetValue("Value", out _value_Index)) _value_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxNumber", out _maxNumber_Index)) _maxNumber_Index = -1;
                    if (!nameIndexs.TryGetValue("MinNumber", out _minNumber_Index)) _minNumber_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemType", out _itemType_Index)) _itemType_Index = -1;
                    if (!nameIndexs.TryGetValue("MinGetValue", out _minGetValue_Index)) _minGetValue_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewRedPacket>(keyCount);
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
            if(HanderDefine.DataCallBack("NewRedPacket", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewRedPacket cfg = null;
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
        public static DeclareNewRedPacket Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewRedPacket result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewRedPacket", out _compressData))
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
