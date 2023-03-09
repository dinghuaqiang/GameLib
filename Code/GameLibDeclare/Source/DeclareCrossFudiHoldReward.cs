//文件是自动生成,请勿手动修改.来自数据文件:Cross_fudi_hold_reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossFudiHoldReward
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _position_Index = -1;
        private static int _day_Index = -1;
        private static int _level_Index = -1;
        private static int _rank_Index = -1;
        private static int _reward0_Index = -1;
        private static int _reward1_Index = -1;
        private static int _reward2_Index = -1;
        private static int _reward3_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //福地等级（1，一级福地；2，二级福地；3，三级福地）
        private int _position;
        //开服时间和世界等级控制
        private int _day;
        //开服时间和世界等级控制
        private int _level;
        //排名
        private int _rank;
        //职业男的奖励物品id
        private int _reward0;
        //职业女的奖励物品id
        private int _reward1;
        //职业3的奖励物品id
        private int _reward2;
        //职业4的奖励物品id
        private int _reward3;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Position { get{ return _position; }}
        public string Day { get{ return HanderDefine.SetStingCallBack(_day); }}
        public string Level { get{ return HanderDefine.SetStingCallBack(_level); }}
        public string Rank { get{ return HanderDefine.SetStingCallBack(_rank); }}
        public string Reward0 { get{ return HanderDefine.SetStingCallBack(_reward0); }}
        public string Reward1 { get{ return HanderDefine.SetStingCallBack(_reward1); }}
        public string Reward2 { get{ return HanderDefine.SetStingCallBack(_reward2); }}
        public string Reward3 { get{ return HanderDefine.SetStingCallBack(_reward3); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossFudiHoldReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossFudiHoldReward> _dataCaches = null;
        public static Dictionary<int, DeclareCrossFudiHoldReward> CacheData
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
                        if (HanderDefine.DataCallBack("CrossFudiHoldReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossFudiHoldReward cfg = null;
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
        private unsafe static DeclareCrossFudiHoldReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossFudiHoldReward();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._position = (int)GetValue(keyIndex, _position_Index, ptr);
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._rank = (int)GetValue(keyIndex, _rank_Index, ptr);
            tmp._reward0 = (int)GetValue(keyIndex, _reward0_Index, ptr);
            tmp._reward1 = (int)GetValue(keyIndex, _reward1_Index, ptr);
            tmp._reward2 = (int)GetValue(keyIndex, _reward2_Index, ptr);
            tmp._reward3 = (int)GetValue(keyIndex, _reward3_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossFudiHoldReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Position", out _position_Index)) _position_Index = -1;
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Rank", out _rank_Index)) _rank_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward0", out _reward0_Index)) _reward0_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward1", out _reward1_Index)) _reward1_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward2", out _reward2_Index)) _reward2_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward3", out _reward3_Index)) _reward3_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossFudiHoldReward>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossFudiHoldReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossFudiHoldReward cfg = null;
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
        public static DeclareCrossFudiHoldReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossFudiHoldReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossFudiHoldReward", out _compressData))
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
