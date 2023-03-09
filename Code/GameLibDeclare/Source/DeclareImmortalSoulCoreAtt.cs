//文件是自动生成,请勿手动修改.来自数据文件:immortal_soul_core_att
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareImmortalSoulCoreAtt
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _core_id_Index = -1;
        private static int _level_Index = -1;
        private static int _add_att_Index = -1;
        private static int _all_level_Index = -1;
        private static int _next_level_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（核心ID*10000+核心等级）
        private int _iD;
        //核心ID
        private int _core_id;
        //核心等级
        private int _level;
        //增加的属性
        private int _add_att;
        //需要的当前灵魄的总等级
        private int _all_level;
        //下一个等级所需得总等级
        private int _next_level;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int CoreId { get{ return _core_id; }}
        public int Level { get{ return _level; }}
        public string AddAtt { get{ return HanderDefine.SetStingCallBack(_add_att); }}
        public int AllLevel { get{ return _all_level; }}
        public int NextLevel { get{ return _next_level; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareImmortalSoulCoreAtt cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareImmortalSoulCoreAtt> _dataCaches = null;
        public static Dictionary<int, DeclareImmortalSoulCoreAtt> CacheData
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
                        if (HanderDefine.DataCallBack("ImmortalSoulCoreAtt", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareImmortalSoulCoreAtt cfg = null;
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
        private unsafe static DeclareImmortalSoulCoreAtt LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareImmortalSoulCoreAtt();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._core_id = (int)GetValue(keyIndex, _core_id_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._add_att = (int)GetValue(keyIndex, _add_att_Index, ptr);
            tmp._all_level = (int)GetValue(keyIndex, _all_level_Index, ptr);
            tmp._next_level = (int)GetValue(keyIndex, _next_level_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ImmortalSoulCoreAtt", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("CoreId", out _core_id_Index)) _core_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("AddAtt", out _add_att_Index)) _add_att_Index = -1;
                    if (!nameIndexs.TryGetValue("AllLevel", out _all_level_Index)) _all_level_Index = -1;
                    if (!nameIndexs.TryGetValue("NextLevel", out _next_level_Index)) _next_level_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareImmortalSoulCoreAtt>(keyCount);
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
            if(HanderDefine.DataCallBack("ImmortalSoulCoreAtt", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareImmortalSoulCoreAtt cfg = null;
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
        public static DeclareImmortalSoulCoreAtt Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareImmortalSoulCoreAtt result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ImmortalSoulCoreAtt", out _compressData))
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
