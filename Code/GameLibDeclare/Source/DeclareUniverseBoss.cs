//文件是自动生成,请勿手动修改.来自数据文件:universe_boss
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareUniverseBoss
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _camp_Index = -1;
        private static int _worldLevel_Index = -1;
        private static int _group_Index = -1;
        private static int _sort_Index = -1;
        private static int _type_Index = -1;
        private static int _createTips_Index = -1;
        private static int _monsterID_Index = -1;
        private static int _mapID_Index = -1;
        private static int _pos_Index = -1;
        private static int _rage_Index = -1;
        private static int _resp_time_Index = -1;
        private static int _reward_Index = -1;
        private static int _score_Index = -1;
        private static int _point_Index = -1;
        private static int _kill_buff_Index = -1;
        private static int _rankLimit_Index = -1;
        private static int _rankReward_Index = -1;
        private static int _serverRankReward_Index = -1;
        private static int _showbox_Index = -1;
        #endregion
        #region //私有变量定义
        //key=怪物ID
        private int _id;
        //阵营（程序用于区分各个服务器）
        private int _camp;
        //世界等级对应的怪
        private int _worldLevel;
        //表示拥有领地的宗派排名。
        //1表示大本营守关BOSS；
        //2表示战场中心BOSS
        private int _group;
        //用于副本内排名的编号
        private int _sort;
        //1.领主；2.精英；3.侍卫
        private int _type;
        //创建副本的时候需要推送给玩家的怪物
        //0不推送（不填默认为0）
        //1推送
        //原则上推送数量不超过2
        private int _createTips;
        //怪物ID,对应monster表
        private int _monsterID;
        //怪物刷新的地图.clone_map的ID
        private int _mapID;
        //出生位置，（x_y 表示地图坐标)(@;@_@)
        private int _pos;
        //击杀怪物后获得怒气值
        private int _rage;
        //死亡后复活时间，单位分钟
        //0表示走后面的特殊时间点刷新
        private int _resp_time;
        //展示奖励,大于等级显示最后等级
        //item_occ
        //（occ=0男1女9通用）
        //（hide）
        private int _reward;
        //怒气，击杀怪物后获得的怒气
        private int _score;
        //积分，击杀怪物后获得的积分，所有参与攻击的都会获得
        private int _point;
        //击杀后在对应场景中为其他服务器的玩家增加的buff
        private int _kill_buff;
        //对应名次
        //1_3（对应1-3名）
        private int _rankLimit;
        //奖励（初步预计为奖励礼包）
        //ID_数量
        private int _rankReward;
        //服务器排名倍数
        //对应1,2,3,4名
        private int _serverRankReward;
        //Icon_数量
        //用于显示到BOSS列表中
        //0或者空代表没有宝箱奖励显示
        //（hide）
        private int _showbox;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Camp { get{ return _camp; }}
        public string WorldLevel { get{ return HanderDefine.SetStingCallBack(_worldLevel); }}
        public int Group { get{ return _group; }}
        public int Sort { get{ return _sort; }}
        public int Type { get{ return _type; }}
        public int CreateTips { get{ return _createTips; }}
        public int MonsterID { get{ return _monsterID; }}
        public int MapID { get{ return _mapID; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Rage { get{ return _rage; }}
        public int RespTime { get{ return _resp_time; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int Score { get{ return _score; }}
        public int Point { get{ return _point; }}
        public int KillBuff { get{ return _kill_buff; }}
        public string RankLimit { get{ return HanderDefine.SetStingCallBack(_rankLimit); }}
        public string RankReward { get{ return HanderDefine.SetStingCallBack(_rankReward); }}
        public string ServerRankReward { get{ return HanderDefine.SetStingCallBack(_serverRankReward); }}
        public string Showbox { get{ return HanderDefine.SetStingCallBack(_showbox); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareUniverseBoss cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareUniverseBoss> _dataCaches = null;
        public static Dictionary<int, DeclareUniverseBoss> CacheData
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
                        if (HanderDefine.DataCallBack("UniverseBoss", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareUniverseBoss cfg = null;
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
        private unsafe static DeclareUniverseBoss LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareUniverseBoss();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._camp = (int)GetValue(keyIndex, _camp_Index, ptr);
            tmp._worldLevel = (int)GetValue(keyIndex, _worldLevel_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._createTips = (int)GetValue(keyIndex, _createTips_Index, ptr);
            tmp._monsterID = (int)GetValue(keyIndex, _monsterID_Index, ptr);
            tmp._mapID = (int)GetValue(keyIndex, _mapID_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._rage = (int)GetValue(keyIndex, _rage_Index, ptr);
            tmp._resp_time = (int)GetValue(keyIndex, _resp_time_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._point = (int)GetValue(keyIndex, _point_Index, ptr);
            tmp._kill_buff = (int)GetValue(keyIndex, _kill_buff_Index, ptr);
            tmp._rankLimit = (int)GetValue(keyIndex, _rankLimit_Index, ptr);
            tmp._rankReward = (int)GetValue(keyIndex, _rankReward_Index, ptr);
            tmp._serverRankReward = (int)GetValue(keyIndex, _serverRankReward_Index, ptr);
            tmp._showbox = (int)GetValue(keyIndex, _showbox_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("UniverseBoss", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Camp", out _camp_Index)) _camp_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLevel", out _worldLevel_Index)) _worldLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("CreateTips", out _createTips_Index)) _createTips_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterID", out _monsterID_Index)) _monsterID_Index = -1;
                    if (!nameIndexs.TryGetValue("MapID", out _mapID_Index)) _mapID_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Rage", out _rage_Index)) _rage_Index = -1;
                    if (!nameIndexs.TryGetValue("RespTime", out _resp_time_Index)) _resp_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("Point", out _point_Index)) _point_Index = -1;
                    if (!nameIndexs.TryGetValue("KillBuff", out _kill_buff_Index)) _kill_buff_Index = -1;
                    if (!nameIndexs.TryGetValue("RankLimit", out _rankLimit_Index)) _rankLimit_Index = -1;
                    if (!nameIndexs.TryGetValue("RankReward", out _rankReward_Index)) _rankReward_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerRankReward", out _serverRankReward_Index)) _serverRankReward_Index = -1;
                    if (!nameIndexs.TryGetValue("Showbox", out _showbox_Index)) _showbox_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareUniverseBoss>(keyCount);
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
            if(HanderDefine.DataCallBack("UniverseBoss", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareUniverseBoss cfg = null;
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
        public static DeclareUniverseBoss Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareUniverseBoss result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("UniverseBoss", out _compressData))
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
