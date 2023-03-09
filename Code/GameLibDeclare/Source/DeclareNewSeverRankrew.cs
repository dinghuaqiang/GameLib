//文件是自动生成,请勿手动修改.来自数据文件:new_sever_rankrew
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverRankrew
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _subType_Index = -1;
        private static int _sort_Index = -1;
        private static int _minRank_Index = -1;
        private static int _maxRank_Index = -1;
        private static int _limit_Index = -1;
        private static int _showName_Index = -1;
        private static int _showstring_Index = -1;
        private static int _rew_Index = -1;
        private static int _rankType_Index = -1;
        #endregion
        #region //私有变量定义
        //id,id=type*100+sort
        private int _id;
        //读取比拼的表里面的ID
        private int _type;
        //全服奖励（1）和个人奖励类型（0）
        private int _subType;
        //用于客户端排序
        private int _sort;
        //排名的最低等级
        //只要到达限制条件
        private int _minRank;
        //排名的最高等级
        private int _maxRank;
        //限制的条件，必须满足排行和限制条件才可领取
        private int _limit;
        //角标显示（hide）
        private int _showName;
        //描述的内容(hide)
        private int _showstring;
        //奖励配置
        private int _rew;
        //对应打开排行榜页签
        private int _rankType;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int SubType { get{ return _subType; }}
        public int Sort { get{ return _sort; }}
        public int MinRank { get{ return _minRank; }}
        public int MaxRank { get{ return _maxRank; }}
        public int Limit { get{ return _limit; }}
        public string ShowName { get{ return HanderDefine.SetStingCallBack(_showName); }}
        public string Showstring { get{ return HanderDefine.SetStingCallBack(_showstring); }}
        public string Rew { get{ return HanderDefine.SetStingCallBack(_rew); }}
        public int RankType { get{ return _rankType; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverRankrew cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverRankrew> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverRankrew> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverRankrew", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverRankrew cfg = null;
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
        private unsafe static DeclareNewSeverRankrew LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverRankrew();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._subType = (int)GetValue(keyIndex, _subType_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._minRank = (int)GetValue(keyIndex, _minRank_Index, ptr);
            tmp._maxRank = (int)GetValue(keyIndex, _maxRank_Index, ptr);
            tmp._limit = (int)GetValue(keyIndex, _limit_Index, ptr);
            tmp._showName = (int)GetValue(keyIndex, _showName_Index, ptr);
            tmp._showstring = (int)GetValue(keyIndex, _showstring_Index, ptr);
            tmp._rew = (int)GetValue(keyIndex, _rew_Index, ptr);
            tmp._rankType = (int)GetValue(keyIndex, _rankType_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverRankrew", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("SubType", out _subType_Index)) _subType_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("MinRank", out _minRank_Index)) _minRank_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxRank", out _maxRank_Index)) _maxRank_Index = -1;
                    if (!nameIndexs.TryGetValue("Limit", out _limit_Index)) _limit_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowName", out _showName_Index)) _showName_Index = -1;
                    if (!nameIndexs.TryGetValue("Showstring", out _showstring_Index)) _showstring_Index = -1;
                    if (!nameIndexs.TryGetValue("Rew", out _rew_Index)) _rew_Index = -1;
                    if (!nameIndexs.TryGetValue("RankType", out _rankType_Index)) _rankType_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverRankrew>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverRankrew", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverRankrew cfg = null;
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
        public static DeclareNewSeverRankrew Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverRankrew result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverRankrew", out _compressData))
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
