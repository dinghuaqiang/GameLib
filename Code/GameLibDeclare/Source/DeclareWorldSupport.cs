//文件是自动生成,请勿手动修改.来自数据文件:World_Support
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareWorldSupport
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _level_rank_Index = -1;
        private static int _pic_res_Index = -1;
        private static int _s_title_rank_Index = -1;
        private static int _s_title_item_Index = -1;
        private static int _s_title_fight_Index = -1;
        private static int _max_times_Index = -1;
        private static int _cold_times_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //等级区间
        private int _level_rank;
        //支援奖励：物品ID_数量_最大数量
        private int _pic_res;
        //感谢物品ID_每日可获得的最大数量
        private int _s_title_rank;
        //感谢的奖励
        private int _s_title_item;
        //被感谢的奖励_数量_每日最大获取数量
        private int _s_title_fight;
        //支援的最大人数
        private int _max_times;
        //冷却时间（秒）
        private int _cold_times;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string LevelRank { get{ return HanderDefine.SetStingCallBack(_level_rank); }}
        public string PicRes { get{ return HanderDefine.SetStingCallBack(_pic_res); }}
        public string STitleRank { get{ return HanderDefine.SetStingCallBack(_s_title_rank); }}
        public string STitleItem { get{ return HanderDefine.SetStingCallBack(_s_title_item); }}
        public string STitleFight { get{ return HanderDefine.SetStingCallBack(_s_title_fight); }}
        public int MaxTimes { get{ return _max_times; }}
        public int ColdTimes { get{ return _cold_times; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareWorldSupport cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareWorldSupport> _dataCaches = null;
        public static Dictionary<int, DeclareWorldSupport> CacheData
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
                        if (HanderDefine.DataCallBack("WorldSupport", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareWorldSupport cfg = null;
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
        private unsafe static DeclareWorldSupport LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareWorldSupport();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._level_rank = (int)GetValue(keyIndex, _level_rank_Index, ptr);
            tmp._pic_res = (int)GetValue(keyIndex, _pic_res_Index, ptr);
            tmp._s_title_rank = (int)GetValue(keyIndex, _s_title_rank_Index, ptr);
            tmp._s_title_item = (int)GetValue(keyIndex, _s_title_item_Index, ptr);
            tmp._s_title_fight = (int)GetValue(keyIndex, _s_title_fight_Index, ptr);
            tmp._max_times = (int)GetValue(keyIndex, _max_times_Index, ptr);
            tmp._cold_times = (int)GetValue(keyIndex, _cold_times_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("WorldSupport", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelRank", out _level_rank_Index)) _level_rank_Index = -1;
                    if (!nameIndexs.TryGetValue("PicRes", out _pic_res_Index)) _pic_res_Index = -1;
                    if (!nameIndexs.TryGetValue("STitleRank", out _s_title_rank_Index)) _s_title_rank_Index = -1;
                    if (!nameIndexs.TryGetValue("STitleItem", out _s_title_item_Index)) _s_title_item_Index = -1;
                    if (!nameIndexs.TryGetValue("STitleFight", out _s_title_fight_Index)) _s_title_fight_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxTimes", out _max_times_Index)) _max_times_Index = -1;
                    if (!nameIndexs.TryGetValue("ColdTimes", out _cold_times_Index)) _cold_times_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareWorldSupport>(keyCount);
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
            if(HanderDefine.DataCallBack("WorldSupport", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareWorldSupport cfg = null;
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
        public static DeclareWorldSupport Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareWorldSupport result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("WorldSupport", out _compressData))
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
