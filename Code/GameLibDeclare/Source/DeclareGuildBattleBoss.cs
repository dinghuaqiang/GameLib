//文件是自动生成,请勿手动修改.来自数据文件:guild_battle_boss
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildBattleBoss
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _group_Index = -1;
        private static int _sort_Index = -1;
        private static int _type_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _refreshType_Index = -1;
        private static int _monsterID_Index = -1;
        private static int _mapID_Index = -1;
        private static int _pos_Index = -1;
        private static int _rage_Index = -1;
        private static int _resp_time_Index = -1;
        private static int _reward_Index = -1;
        private static int _drop_Index = -1;
        private static int _first_reward_Index = -1;
        private static int _participation_reward_Index = -1;
        private static int _guildTeam_reward_Index = -1;
        private static int _score_Index = -1;
        private static int _personal_score_Index = -1;
        private static int _defaultFollowOpen_Index = -1;
        #endregion
        #region //私有变量定义
        //key=group*100+level
        private int _id;
        //表示拥有领地的宗派排名。1表示1名，2表示2名，3表示3名。每日11点决定
        private int _group;
        //用于副本内排名的编号
        private int _sort;
        //1.领主；2.精英；3.侍卫
        private int _type;
        //怪物名
        private int _name;
        //头像
        private int _icon;
        //1：世界等级刷新
        //2：开服天数刷新
        //关联monsterID和reward字段，两个字段需要保持格式一致
        private int _refreshType;
        //怪物ID根据世界等级取；<=180取180 ；>=220取220
        //开服天数配置方式同理
        private int _monsterID;
        //怪物刷新的地图.clone_map的ID
        private int _mapID;
        //出生位置，（x_y 表示地图坐标)(@;@_@)
        private int _pos;
        //击杀怪物后获得怒气值
        private int _rage;
        //死亡后复活时间，单位分钟
        private int _resp_time;
        //展示奖励,大于等级显示最后等级
        private int _reward;
        //掉落拍卖物品奖励（根据怪物当前等级计算；等级_几率_道具ID；多个的时候，相同的等级）
        private int _drop;
        //伤害排名第一奖励
        private int _first_reward;
        //参与奖励
        private int _participation_reward;
        //共享掉落，怪物归属方的同仙盟成员都可以拾取,后面跟的是掉落包ID
        //天数_掉落包ID（天数还是世界等级由refreshType决定）
        private int _guildTeam_reward;
        //与type关联，当为1表示百分比；其他表示固定值
        private int _score;
        //个人积分获取值
        private int _personal_score;
        //是否在功能开启时默认关注
        //（0不关注，1关注）
        private int _defaultFollowOpen;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Group { get{ return _group; }}
        public int Sort { get{ return _sort; }}
        public int Type { get{ return _type; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int RefreshType { get{ return _refreshType; }}
        public string MonsterID { get{ return HanderDefine.SetStingCallBack(_monsterID); }}
        public int MapID { get{ return _mapID; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Rage { get{ return _rage; }}
        public int RespTime { get{ return _resp_time; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public string FirstReward { get{ return HanderDefine.SetStingCallBack(_first_reward); }}
        public string ParticipationReward { get{ return HanderDefine.SetStingCallBack(_participation_reward); }}
        public string GuildTeamReward { get{ return HanderDefine.SetStingCallBack(_guildTeam_reward); }}
        public int Score { get{ return _score; }}
        public int PersonalScore { get{ return _personal_score; }}
        public int DefaultFollowOpen { get{ return _defaultFollowOpen; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildBattleBoss cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildBattleBoss> _dataCaches = null;
        public static Dictionary<int, DeclareGuildBattleBoss> CacheData
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
                        if (HanderDefine.DataCallBack("GuildBattleBoss", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildBattleBoss cfg = null;
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
        private unsafe static DeclareGuildBattleBoss LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildBattleBoss();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._refreshType = (int)GetValue(keyIndex, _refreshType_Index, ptr);
            tmp._monsterID = (int)GetValue(keyIndex, _monsterID_Index, ptr);
            tmp._mapID = (int)GetValue(keyIndex, _mapID_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._rage = (int)GetValue(keyIndex, _rage_Index, ptr);
            tmp._resp_time = (int)GetValue(keyIndex, _resp_time_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._first_reward = (int)GetValue(keyIndex, _first_reward_Index, ptr);
            tmp._participation_reward = (int)GetValue(keyIndex, _participation_reward_Index, ptr);
            tmp._guildTeam_reward = (int)GetValue(keyIndex, _guildTeam_reward_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._personal_score = (int)GetValue(keyIndex, _personal_score_Index, ptr);
            tmp._defaultFollowOpen = (int)GetValue(keyIndex, _defaultFollowOpen_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildBattleBoss", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("RefreshType", out _refreshType_Index)) _refreshType_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterID", out _monsterID_Index)) _monsterID_Index = -1;
                    if (!nameIndexs.TryGetValue("MapID", out _mapID_Index)) _mapID_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Rage", out _rage_Index)) _rage_Index = -1;
                    if (!nameIndexs.TryGetValue("RespTime", out _resp_time_Index)) _resp_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("FirstReward", out _first_reward_Index)) _first_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ParticipationReward", out _participation_reward_Index)) _participation_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildTeamReward", out _guildTeam_reward_Index)) _guildTeam_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalScore", out _personal_score_Index)) _personal_score_Index = -1;
                    if (!nameIndexs.TryGetValue("DefaultFollowOpen", out _defaultFollowOpen_Index)) _defaultFollowOpen_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildBattleBoss>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildBattleBoss", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildBattleBoss cfg = null;
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
        public static DeclareGuildBattleBoss Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildBattleBoss result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildBattleBoss", out _compressData))
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
