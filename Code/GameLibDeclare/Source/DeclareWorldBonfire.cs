//文件是自动生成,请勿手动修改.来自数据文件:world_bonfire
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareWorldBonfire
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _level_exp_Index = -1;
        private static int _exp_addition_Index = -1;
        private static int _wood_cost_Index = -1;
        private static int _wood_exp_Index = -1;
        private static int _add_gather_Index = -1;
        private static int _add_gather_num_Index = -1;
        private static int _gather_location_Index = -1;
        #endregion
        #region //私有变量定义
        //等级
        private int _id;
        //升级所需经验
        private int _level_exp;
        //本级额外经验加成（每跳x%)
        private int _exp_addition;
        //本级添柴消耗（物品ID_数量）
        private int _wood_cost;
        //本级添柴增加的经验
        private int _wood_exp;
        //添柴召唤的采集物
        private int _add_gather;
        //添柴召唤的采集物数量
        private int _add_gather_num;
        //采集物坐标
        private int _gather_location;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int LevelExp { get{ return _level_exp; }}
        public int ExpAddition { get{ return _exp_addition; }}
        public string WoodCost { get{ return HanderDefine.SetStingCallBack(_wood_cost); }}
        public int WoodExp { get{ return _wood_exp; }}
        public int AddGather { get{ return _add_gather; }}
        public int AddGatherNum { get{ return _add_gather_num; }}
        public string GatherLocation { get{ return HanderDefine.SetStingCallBack(_gather_location); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareWorldBonfire cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareWorldBonfire> _dataCaches = null;
        public static Dictionary<int, DeclareWorldBonfire> CacheData
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
                        if (HanderDefine.DataCallBack("WorldBonfire", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareWorldBonfire cfg = null;
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
        private unsafe static DeclareWorldBonfire LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareWorldBonfire();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._level_exp = (int)GetValue(keyIndex, _level_exp_Index, ptr);
            tmp._exp_addition = (int)GetValue(keyIndex, _exp_addition_Index, ptr);
            tmp._wood_cost = (int)GetValue(keyIndex, _wood_cost_Index, ptr);
            tmp._wood_exp = (int)GetValue(keyIndex, _wood_exp_Index, ptr);
            tmp._add_gather = (int)GetValue(keyIndex, _add_gather_Index, ptr);
            tmp._add_gather_num = (int)GetValue(keyIndex, _add_gather_num_Index, ptr);
            tmp._gather_location = (int)GetValue(keyIndex, _gather_location_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("WorldBonfire", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelExp", out _level_exp_Index)) _level_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("ExpAddition", out _exp_addition_Index)) _exp_addition_Index = -1;
                    if (!nameIndexs.TryGetValue("WoodCost", out _wood_cost_Index)) _wood_cost_Index = -1;
                    if (!nameIndexs.TryGetValue("WoodExp", out _wood_exp_Index)) _wood_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("AddGather", out _add_gather_Index)) _add_gather_Index = -1;
                    if (!nameIndexs.TryGetValue("AddGatherNum", out _add_gather_num_Index)) _add_gather_num_Index = -1;
                    if (!nameIndexs.TryGetValue("GatherLocation", out _gather_location_Index)) _gather_location_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareWorldBonfire>(keyCount);
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
            if(HanderDefine.DataCallBack("WorldBonfire", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareWorldBonfire cfg = null;
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
        public static DeclareWorldBonfire Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareWorldBonfire result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("WorldBonfire", out _compressData))
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
