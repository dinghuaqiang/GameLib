//文件是自动生成,请勿手动修改.来自数据文件:guildBoss_Reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildBossReward
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _world_level_Index = -1;
        private static int _rank_Index = -1;
        private static int _guild_auction_reward_Index = -1;
        private static int _personal_reward_Index = -1;
        private static int _monster_reward_Index = -1;
        private static int _reward_show_Index = -1;
        private static int _paipin_show_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _iD;
        //世界等级段
        private int _world_level;
        //排名区间
        private int _rank;
        //进入竞拍得奖励
        private int _guild_auction_reward;
        //个人奖励
        private int _personal_reward;
        //小怪奖励
        private int _monster_reward;
        //奖励展示hide
        private int _reward_show;
        //奖励展示hide
        private int _paipin_show;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public string WorldLevel { get{ return HanderDefine.SetStingCallBack(_world_level); }}
        public string Rank { get{ return HanderDefine.SetStingCallBack(_rank); }}
        public string GuildAuctionReward { get{ return HanderDefine.SetStingCallBack(_guild_auction_reward); }}
        public string PersonalReward { get{ return HanderDefine.SetStingCallBack(_personal_reward); }}
        public string MonsterReward { get{ return HanderDefine.SetStingCallBack(_monster_reward); }}
        public string RewardShow { get{ return HanderDefine.SetStingCallBack(_reward_show); }}
        public string PaipinShow { get{ return HanderDefine.SetStingCallBack(_paipin_show); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildBossReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildBossReward> _dataCaches = null;
        public static Dictionary<int, DeclareGuildBossReward> CacheData
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
                        if (HanderDefine.DataCallBack("GuildBossReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildBossReward cfg = null;
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
        private unsafe static DeclareGuildBossReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildBossReward();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._world_level = (int)GetValue(keyIndex, _world_level_Index, ptr);
            tmp._rank = (int)GetValue(keyIndex, _rank_Index, ptr);
            tmp._guild_auction_reward = (int)GetValue(keyIndex, _guild_auction_reward_Index, ptr);
            tmp._personal_reward = (int)GetValue(keyIndex, _personal_reward_Index, ptr);
            tmp._monster_reward = (int)GetValue(keyIndex, _monster_reward_Index, ptr);
            tmp._reward_show = (int)GetValue(keyIndex, _reward_show_Index, ptr);
            tmp._paipin_show = (int)GetValue(keyIndex, _paipin_show_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildBossReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLevel", out _world_level_Index)) _world_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Rank", out _rank_Index)) _rank_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildAuctionReward", out _guild_auction_reward_Index)) _guild_auction_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalReward", out _personal_reward_Index)) _personal_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterReward", out _monster_reward_Index)) _monster_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardShow", out _reward_show_Index)) _reward_show_Index = -1;
                    if (!nameIndexs.TryGetValue("PaipinShow", out _paipin_show_Index)) _paipin_show_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildBossReward>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildBossReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildBossReward cfg = null;
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
        public static DeclareGuildBossReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildBossReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildBossReward", out _compressData))
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
