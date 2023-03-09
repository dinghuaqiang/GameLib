//文件是自动生成,请勿手动修改.来自数据文件:characters
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCharacters
    {
        #region //静态变量定义
        private static int _level_Index = -1;
        private static int _exp_Index = -1;
        private static int _occMental_Index = -1;
        private static int _error_reward_Index = -1;
        private static int _sZZQ_EXP_award_Index = -1;
        private static int _sZZQ_EXP_rank_award_Index = -1;
        private static int _leader_Preach_award_Index = -1;
        private static int _convoy_Exp_Index = -1;
        #endregion
        #region //私有变量定义
        //等级
        private int _level;
        //升级所需经验(当前级别升下级的经验)
        private Int64 _exp;
        //升级自动获得的心法
        private int _occMental;
        //错误答题奖励(@;@_@)correct_reward
        private int _error_reward;
        //神魔战场积分经验奖励(5个，按照分数从低到高顺序填写）[@;@_@]
        private int _sZZQ_EXP_award;
        //神魔战场排行经验奖励（5个，按照排名从前到后的排名填写）[@;@_@]
        private int _sZZQ_EXP_rank_award;
        //掌门传道每次经验奖励（4个难度依次填写）[@_@]
        private Int64 _leader_Preach_award;
        //神女ID_护送经验;
        private int _convoy_Exp;
        #endregion

        #region //公共属性
        public int Level { get{ return _level; }}
        public Int64 Exp { get{ return _exp; }}
        public int OccMental { get{ return _occMental; }}
        public string ErrorReward { get{ return HanderDefine.SetStingCallBack(_error_reward); }}
        public string SZZQEXPAward { get{ return HanderDefine.SetStingCallBack(_sZZQ_EXP_award); }}
        public string SZZQEXPRankAward { get{ return HanderDefine.SetStingCallBack(_sZZQ_EXP_rank_award); }}
        public Int64 LeaderPreachAward { get{ return _leader_Preach_award; }}
        public string ConvoyExp { get{ return HanderDefine.SetStingCallBack(_convoy_Exp); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCharacters cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCharacters> _dataCaches = null;
        public static Dictionary<int, DeclareCharacters> CacheData
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
                        if (HanderDefine.DataCallBack("Characters", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCharacters cfg = null;
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
        private unsafe static DeclareCharacters LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCharacters();
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._exp = GetValue(keyIndex, _exp_Index, ptr);
            tmp._occMental = (int)GetValue(keyIndex, _occMental_Index, ptr);
            tmp._error_reward = (int)GetValue(keyIndex, _error_reward_Index, ptr);
            tmp._sZZQ_EXP_award = (int)GetValue(keyIndex, _sZZQ_EXP_award_Index, ptr);
            tmp._sZZQ_EXP_rank_award = (int)GetValue(keyIndex, _sZZQ_EXP_rank_award_Index, ptr);
            tmp._leader_Preach_award = GetValue(keyIndex, _leader_Preach_award_Index, ptr);
            tmp._convoy_Exp = (int)GetValue(keyIndex, _convoy_Exp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Characters", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("OccMental", out _occMental_Index)) _occMental_Index = -1;
                    if (!nameIndexs.TryGetValue("ErrorReward", out _error_reward_Index)) _error_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("SZZQEXPAward", out _sZZQ_EXP_award_Index)) _sZZQ_EXP_award_Index = -1;
                    if (!nameIndexs.TryGetValue("SZZQEXPRankAward", out _sZZQ_EXP_rank_award_Index)) _sZZQ_EXP_rank_award_Index = -1;
                    if (!nameIndexs.TryGetValue("LeaderPreachAward", out _leader_Preach_award_Index)) _leader_Preach_award_Index = -1;
                    if (!nameIndexs.TryGetValue("ConvoyExp", out _convoy_Exp_Index)) _convoy_Exp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCharacters>(keyCount);
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
            if(HanderDefine.DataCallBack("Characters", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCharacters cfg = null;
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
        public static DeclareCharacters Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCharacters result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Characters", out _compressData))
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
