//文件是自动生成,请勿手动修改.来自数据文件:immortal_soul_exp
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareImmortalSoulExp
    {
        #region //静态变量定义
        private static int _level_Index = -1;
        private static int _blue_exp_Index = -1;
        private static int _violet_exp_Index = -1;
        private static int _golden_exp_Index = -1;
        private static int _gules_exp_Index = -1;
        #endregion
        #region //私有变量定义
        //等级
        private int _level;
        //蓝色升下级经验_分解总经验
        private int _blue_exp;
        //紫色升下级经验_分解总经验
        private int _violet_exp;
        //金色升下级经验_分解总经验
        private int _golden_exp;
        //红色升下级经验_分解总经验
        private int _gules_exp;
        #endregion

        #region //公共属性
        public int Level { get{ return _level; }}
        public string BlueExp { get{ return HanderDefine.SetStingCallBack(_blue_exp); }}
        public string VioletExp { get{ return HanderDefine.SetStingCallBack(_violet_exp); }}
        public string GoldenExp { get{ return HanderDefine.SetStingCallBack(_golden_exp); }}
        public string GulesExp { get{ return HanderDefine.SetStingCallBack(_gules_exp); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareImmortalSoulExp cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareImmortalSoulExp> _dataCaches = null;
        public static Dictionary<int, DeclareImmortalSoulExp> CacheData
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
                        if (HanderDefine.DataCallBack("ImmortalSoulExp", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareImmortalSoulExp cfg = null;
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
        private unsafe static DeclareImmortalSoulExp LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareImmortalSoulExp();
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._blue_exp = (int)GetValue(keyIndex, _blue_exp_Index, ptr);
            tmp._violet_exp = (int)GetValue(keyIndex, _violet_exp_Index, ptr);
            tmp._golden_exp = (int)GetValue(keyIndex, _golden_exp_Index, ptr);
            tmp._gules_exp = (int)GetValue(keyIndex, _gules_exp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ImmortalSoulExp", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("BlueExp", out _blue_exp_Index)) _blue_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("VioletExp", out _violet_exp_Index)) _violet_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("GoldenExp", out _golden_exp_Index)) _golden_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("GulesExp", out _gules_exp_Index)) _gules_exp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareImmortalSoulExp>(keyCount);
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
            if(HanderDefine.DataCallBack("ImmortalSoulExp", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareImmortalSoulExp cfg = null;
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
        public static DeclareImmortalSoulExp Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareImmortalSoulExp result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ImmortalSoulExp", out _compressData))
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
