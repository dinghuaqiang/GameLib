//文件是自动生成,请勿手动修改.来自数据文件:recharge_daily_cangzhenge
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRechargeDailyCangzhenge
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _times_Index = -1;
        private static int _reward_Index = -1;
        private static int _probability_Index = -1;
        private static int _superreward_Index = -1;
        private static int _end_Index = -1;
        private static int _record_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _iD;
        //第几轮
        private int _times;
        //item_num_bind_occ
        //bind 0未绑定1绑定
        //occ 0男1女9通用
        private int _reward;
        //几率（和为10W）
        private int _probability;
        //是否为展示用大奖（0，不是；1，是）hide
        private int _superreward;
        //是否为最后一轮（0，不是；1，是）
        private int _end;
        //是否进入大奖的记录
        private int _record;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int Times { get{ return _times; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int Probability { get{ return _probability; }}
        public int Superreward { get{ return _superreward; }}
        public int End { get{ return _end; }}
        public int Record { get{ return _record; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRechargeDailyCangzhenge cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRechargeDailyCangzhenge> _dataCaches = null;
        public static Dictionary<int, DeclareRechargeDailyCangzhenge> CacheData
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
                        if (HanderDefine.DataCallBack("RechargeDailyCangzhenge", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRechargeDailyCangzhenge cfg = null;
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
        private unsafe static DeclareRechargeDailyCangzhenge LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRechargeDailyCangzhenge();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._times = (int)GetValue(keyIndex, _times_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._probability = (int)GetValue(keyIndex, _probability_Index, ptr);
            tmp._superreward = (int)GetValue(keyIndex, _superreward_Index, ptr);
            tmp._end = (int)GetValue(keyIndex, _end_Index, ptr);
            tmp._record = (int)GetValue(keyIndex, _record_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RechargeDailyCangzhenge", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("Times", out _times_Index)) _times_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Probability", out _probability_Index)) _probability_Index = -1;
                    if (!nameIndexs.TryGetValue("Superreward", out _superreward_Index)) _superreward_Index = -1;
                    if (!nameIndexs.TryGetValue("End", out _end_Index)) _end_Index = -1;
                    if (!nameIndexs.TryGetValue("Record", out _record_Index)) _record_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRechargeDailyCangzhenge>(keyCount);
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
            if(HanderDefine.DataCallBack("RechargeDailyCangzhenge", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRechargeDailyCangzhenge cfg = null;
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
        public static DeclareRechargeDailyCangzhenge Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRechargeDailyCangzhenge result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RechargeDailyCangzhenge", out _compressData))
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
