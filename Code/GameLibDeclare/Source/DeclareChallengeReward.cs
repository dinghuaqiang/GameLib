//文件是自动生成,请勿手动修改.来自数据文件:challenge_reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareChallengeReward
    {
        #region //静态变量定义
        private static int _num_Index = -1;
        private static int _name_Index = -1;
        private static int _little_name_Index = -1;
        private static int _need_level_Index = -1;
        private static int _normal_reward_Index = -1;
        private static int _chapter_reward_Index = -1;
        private static int _need_fight_power_Index = -1;
        #endregion
        #region //私有变量定义
        //波次
        private int _num;
        //名字hide
        private int _name;
        //名字hide
        private int _little_name;
        //需求玩家等级
        private int _need_level;
        //普通通关奖励(@;@_@)
        private int _normal_reward;
        //章节通关奖励奖励(@;@_@)
        private int _chapter_reward;
        //需求战斗力
        private int _need_fight_power;
        #endregion

        #region //公共属性
        public int Num { get{ return _num; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string LittleName { get{ return HanderDefine.SetStingCallBack(_little_name); }}
        public int NeedLevel { get{ return _need_level; }}
        public string NormalReward { get{ return HanderDefine.SetStingCallBack(_normal_reward); }}
        public string ChapterReward { get{ return HanderDefine.SetStingCallBack(_chapter_reward); }}
        public int NeedFightPower { get{ return _need_fight_power; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareChallengeReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareChallengeReward> _dataCaches = null;
        public static Dictionary<int, DeclareChallengeReward> CacheData
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
                        if (HanderDefine.DataCallBack("ChallengeReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareChallengeReward cfg = null;
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
        private unsafe static DeclareChallengeReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareChallengeReward();
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._little_name = (int)GetValue(keyIndex, _little_name_Index, ptr);
            tmp._need_level = (int)GetValue(keyIndex, _need_level_Index, ptr);
            tmp._normal_reward = (int)GetValue(keyIndex, _normal_reward_Index, ptr);
            tmp._chapter_reward = (int)GetValue(keyIndex, _chapter_reward_Index, ptr);
            tmp._need_fight_power = (int)GetValue(keyIndex, _need_fight_power_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ChallengeReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("LittleName", out _little_name_Index)) _little_name_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedLevel", out _need_level_Index)) _need_level_Index = -1;
                    if (!nameIndexs.TryGetValue("NormalReward", out _normal_reward_Index)) _normal_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ChapterReward", out _chapter_reward_Index)) _chapter_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedFightPower", out _need_fight_power_Index)) _need_fight_power_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareChallengeReward>(keyCount);
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
            if(HanderDefine.DataCallBack("ChallengeReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareChallengeReward cfg = null;
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
        public static DeclareChallengeReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareChallengeReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ChallengeReward", out _compressData))
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
