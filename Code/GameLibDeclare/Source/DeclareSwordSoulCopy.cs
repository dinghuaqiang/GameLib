//文件是自动生成,请勿手动修改.来自数据文件:sword_soul_copy
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSwordSoulCopy
    {
        #region //静态变量定义
        private static int _num_Index = -1;
        private static int _reward_Index = -1;
        private static int _reward_show_Index = -1;
        private static int _unlock_part_Index = -1;
        private static int _unlock_type_Index = -1;
        private static int _need_fight_power_Index = -1;
        private static int _pass_power_Index = -1;
        private static int _mandate_single_reward_Index = -1;
        private static int _moster_ids_Index = -1;
        #endregion
        #region //私有变量定义
        //波次
        private int _num;
        //通关奖励(@;@_@)
        private int _reward;
        //客户端用通关奖励得显示(@;@_@)
        private int _reward_show;
        //解锁灵魄位置
        private int _unlock_part;
        //客户端显示解锁灵魄类型hide
        private int _unlock_type;
        //需求战斗力
        private int _need_fight_power;
        //跳过需要的战斗力
        private int _pass_power;
        //挂机每次奖励的道具
        private int _mandate_single_reward;
        //挂机表现刷新的怪物列表,每次随机 hide
        private int _moster_ids;
        #endregion

        #region //公共属性
        public int Num { get{ return _num; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string RewardShow { get{ return HanderDefine.SetStingCallBack(_reward_show); }}
        public int UnlockPart { get{ return _unlock_part; }}
        public string UnlockType { get{ return HanderDefine.SetStingCallBack(_unlock_type); }}
        public int NeedFightPower { get{ return _need_fight_power; }}
        public int PassPower { get{ return _pass_power; }}
        public string MandateSingleReward { get{ return HanderDefine.SetStingCallBack(_mandate_single_reward); }}
        public string MosterIds { get{ return HanderDefine.SetStingCallBack(_moster_ids); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSwordSoulCopy cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSwordSoulCopy> _dataCaches = null;
        public static Dictionary<int, DeclareSwordSoulCopy> CacheData
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
                        if (HanderDefine.DataCallBack("SwordSoulCopy", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSwordSoulCopy cfg = null;
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
        private unsafe static DeclareSwordSoulCopy LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSwordSoulCopy();
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._reward_show = (int)GetValue(keyIndex, _reward_show_Index, ptr);
            tmp._unlock_part = (int)GetValue(keyIndex, _unlock_part_Index, ptr);
            tmp._unlock_type = (int)GetValue(keyIndex, _unlock_type_Index, ptr);
            tmp._need_fight_power = (int)GetValue(keyIndex, _need_fight_power_Index, ptr);
            tmp._pass_power = (int)GetValue(keyIndex, _pass_power_Index, ptr);
            tmp._mandate_single_reward = (int)GetValue(keyIndex, _mandate_single_reward_Index, ptr);
            tmp._moster_ids = (int)GetValue(keyIndex, _moster_ids_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SwordSoulCopy", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardShow", out _reward_show_Index)) _reward_show_Index = -1;
                    if (!nameIndexs.TryGetValue("UnlockPart", out _unlock_part_Index)) _unlock_part_Index = -1;
                    if (!nameIndexs.TryGetValue("UnlockType", out _unlock_type_Index)) _unlock_type_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedFightPower", out _need_fight_power_Index)) _need_fight_power_Index = -1;
                    if (!nameIndexs.TryGetValue("PassPower", out _pass_power_Index)) _pass_power_Index = -1;
                    if (!nameIndexs.TryGetValue("MandateSingleReward", out _mandate_single_reward_Index)) _mandate_single_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("MosterIds", out _moster_ids_Index)) _moster_ids_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSwordSoulCopy>(keyCount);
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
            if(HanderDefine.DataCallBack("SwordSoulCopy", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSwordSoulCopy cfg = null;
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
        public static DeclareSwordSoulCopy Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSwordSoulCopy result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SwordSoulCopy", out _compressData))
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
