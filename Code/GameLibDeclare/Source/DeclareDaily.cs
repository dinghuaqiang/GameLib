//文件是自动生成,请勿手动修改.来自数据文件:daily
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareDaily
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _tips_name_Index = -1;
        private static int _icon_Index = -1;
        private static int _canshow_Index = -1;
        private static int _fbtype_Index = -1;
        private static int _sort_Index = -1;
        private static int _main_production_Index = -1;
        private static int _production_Index = -1;
        private static int _reward_Index = -1;
        private static int _type_icon_Index = -1;
        private static int _activeValue_Index = -1;
        private static int _times_Index = -1;
        private static int _times_hide_Index = -1;
        private static int _if_add_count_Index = -1;
        private static int _openday_Index = -1;
        private static int _openLevel_Index = -1;
        private static int _conditiondes_Index = -1;
        private static int _openTime_Index = -1;
        private static int _allDayOpen_Index = -1;
        private static int _time_Index = -1;
        private static int _closeTime_Index = -1;
        private static int _openTimeDes_Index = -1;
        private static int _team_Index = -1;
        private static int _description_Index = -1;
        private static int _state_power_count_Index = -1;
        private static int _buy_need_gold_Index = -1;
        private static int _refresh_Index = -1;
        private static int _cloneID_Index = -1;
        private static int _sweep_Index = -1;
        private static int _sweepLevel_Index = -1;
        private static int _delayDays_Index = -1;
        private static int _ifGono_Index = -1;
        private static int _ready_Index = -1;
        private static int _foundTeam_Index = -1;
        private static int _openType_Index = -1;
        private static int _openUI_Index = -1;
        private static int _npcID_Index = -1;
        private static int _ifPush_Index = -1;
        private static int _pushType_Index = -1;
        private static int _pushAdvance_Index = -1;
        private static int _addOnMenu_Index = -1;
        private static int _crosstype_Index = -1;
        private static int _crossMatch_Index = -1;
        private static int _ifcross_Index = -1;
        private static int _maxValue_Index = -1;
        private static int _task_Index = -1;
        private static int _type_Index = -1;
        private static int _specialOpen_Index = -1;
        private static int _isSignOut_Index = -1;
        private static int _isremind_Index = -1;
        private static int _noremind_map_Index = -1;
        private static int _isCloseShow_Index = -1;
        #endregion
        #region //私有变量定义
        //活跃行为ID
        private int _id;
        //活跃行为名字
        private int _name;
        //获得提示名字hide
        private int _tips_name;
        //图标 hide
        private int _icon;
        //是否在列表中显示(0否1是)
        private int _canshow;
        //分类类型:-1不处理、1日常、2限时hide
        private int _fbtype;
        //显示排序hide
        private int _sort;
        //外部产出描述hide
        private int _main_production;
        //点击内标签产出说明 hide
        private int _production;
        //奖励展示hide
        private int _reward;
        //标签(0,无标签；1,经验；2,装备；3,灵石）hide
        private int _type_icon;
        //进度完成所加活跃值
        private int _activeValue;
        //参与次数
        private int _times;
        //是否隐藏参与次数(0,不隐藏；1，隐藏）
        private int _times_hide;
        //是否可以增加次数（0，不行；1可以）
        private int _if_add_count;
        //达到指定开服天数开启玩法，为空则表示和天数无关（达到等级要求并且达到开服天数要求才显示参加按钮）
        private int _openday;
        //功能可参与等级
        private int _openLevel;
        //开启条件说明 hide，用于未开启时显示得内容
        private int _conditiondes;
        //活动开放时间（0表示每天开放，1-7表示周一到周日的某一天）(@;@)
        private int _openTime;
        //是否是全天开放(0不处理、1不检查开放时间)
        private int _allDayOpen;
        //开放时间
        private int _time;
        //特殊关闭时间，本服福地专用，
        //其他功能慎用
        //开服天数_时间点（分钟）
        private int _closeTime;
        //开放时间描述 hide
        private int _openTimeDes;
        //组队方式描述 hide
        private int _team;
        //活动描述 hide
        private int _description;
        //境界等级增加的次数（境界下限_境界上限_增加次数）
        private int _state_power_count;
        //购买次数时消耗的元宝
        private int _buy_need_gold;
        //0.日刷新；1.周刷新
        private int _refresh;
        //clone_map的id
        private int _cloneID;
        //是否可以扫荡，0为不处理；1为可扫荡
        private int _sweep;
        //扫荡等级，0为不处理；大于0为扫荡等级
        private int _sweepLevel;
        //是否根据开服时间确定活动开启，0为不处理按照统一时间来；>0为第几天开，开服那天算第1天
        //(@;@)
        private int _delayDays;
        //开服天数控制后是否还会再次开启，0为不开启，1为开启
        private int _ifGono;
        //控制是否在活动准备阶段打开活动面板
        //0，不能打开
        //1，可以打开
        private int _ready;
        //寻队界面hide
        private int _foundTeam;
        //功能开启类型（0无;1打开功能界面;2前往与NPC对话;3直接参加活动不打开界面也不与Npc谈话. 注:打开界面,与Npc谈话 等等一切以此参数为准；4，直接进入副本；5，寻路日常任务）
        private int _openType;
        //开启界面
        private int _openUI;
        //寻路NPC的ID(阵营ID_职业ID_NPCID;阵营ID_职业ID_NPCID)
        private int _npcID;
        //是否线下推送，0不进行推送，1推送
        private int _ifPush;
        //推送类型，0就是不处理；1线上面板；2线上跑马灯，对应表notice
        private int _pushType;
        //推送提前时间，分钟 0为不推送，>0为分钟数
        private int _pushAdvance;
        //是否显示到顶部第三排菜单，0代表否，1代表是
        private int _addOnMenu;
        //跨服模式:0:所有的服务器都需要满足对应的开服天数，否则活动都不能进入。1:达到要求的开服天数的服务器可以进入。2:达到开服天数后，对应的跨服的所有服务器的玩家均可进入。
        private int _crosstype;
        //服务器跨服数量_显示开服时间
        private int _crossMatch;
        //是否为跨服
        //0非跨服，
        //1跨服
        //2本服+跨服
        private int _ifcross;
        //可获得活跃总值（hide）
        private int _maxValue;
        //任务开放ID(@_@)完成这个ID得任务就开启改活动
        private int _task;
        //活动开启条件类型。1代表等级、2代表任务、3代表尚未定义
        private int _type;
        //开服第N天特殊开启一次活动
        private int _specialOpen;
        //活动期间是否可中途退出公会
        //0不可以
        //1可以
        //默认为1
        private int _isSignOut;
        //活动开启时是否提示（hide）0，不提示；1，提示
        private int _isremind;
        //活动开启时不发放提醒的地图（hide）
        private int _noremind_map;
        //功能关闭后，是否还显示在日常界面
        //0不显示
        //1显示
        //(hide)
        private int _isCloseShow;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string TipsName { get{ return HanderDefine.SetStingCallBack(_tips_name); }}
        public int Icon { get{ return _icon; }}
        public int Canshow { get{ return _canshow; }}
        public int Fbtype { get{ return _fbtype; }}
        public int Sort { get{ return _sort; }}
        public string MainProduction { get{ return HanderDefine.SetStingCallBack(_main_production); }}
        public string Production { get{ return HanderDefine.SetStingCallBack(_production); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int TypeIcon { get{ return _type_icon; }}
        public int ActiveValue { get{ return _activeValue; }}
        public int Times { get{ return _times; }}
        public int TimesHide { get{ return _times_hide; }}
        public int IfAddCount { get{ return _if_add_count; }}
        public int Openday { get{ return _openday; }}
        public int OpenLevel { get{ return _openLevel; }}
        public string Conditiondes { get{ return HanderDefine.SetStingCallBack(_conditiondes); }}
        public string OpenTime { get{ return HanderDefine.SetStingCallBack(_openTime); }}
        public int AllDayOpen { get{ return _allDayOpen; }}
        public string Time { get{ return HanderDefine.SetStingCallBack(_time); }}
        public string CloseTime { get{ return HanderDefine.SetStingCallBack(_closeTime); }}
        public string OpenTimeDes { get{ return HanderDefine.SetStingCallBack(_openTimeDes); }}
        public string Team { get{ return HanderDefine.SetStingCallBack(_team); }}
        public string Description { get{ return HanderDefine.SetStingCallBack(_description); }}
        public string StatePowerCount { get{ return HanderDefine.SetStingCallBack(_state_power_count); }}
        public string BuyNeedGold { get{ return HanderDefine.SetStingCallBack(_buy_need_gold); }}
        public int Refresh { get{ return _refresh; }}
        public string CloneID { get{ return HanderDefine.SetStingCallBack(_cloneID); }}
        public int Sweep { get{ return _sweep; }}
        public int SweepLevel { get{ return _sweepLevel; }}
        public string DelayDays { get{ return HanderDefine.SetStingCallBack(_delayDays); }}
        public int IfGono { get{ return _ifGono; }}
        public int Ready { get{ return _ready; }}
        public string FoundTeam { get{ return HanderDefine.SetStingCallBack(_foundTeam); }}
        public int OpenType { get{ return _openType; }}
        public string OpenUI { get{ return HanderDefine.SetStingCallBack(_openUI); }}
        public string NpcID { get{ return HanderDefine.SetStingCallBack(_npcID); }}
        public int IfPush { get{ return _ifPush; }}
        public int PushType { get{ return _pushType; }}
        public int PushAdvance { get{ return _pushAdvance; }}
        public int AddOnMenu { get{ return _addOnMenu; }}
        public int Crosstype { get{ return _crosstype; }}
        public string CrossMatch { get{ return HanderDefine.SetStingCallBack(_crossMatch); }}
        public int Ifcross { get{ return _ifcross; }}
        public int MaxValue { get{ return _maxValue; }}
        public string Task { get{ return HanderDefine.SetStingCallBack(_task); }}
        public int Type { get{ return _type; }}
        public int SpecialOpen { get{ return _specialOpen; }}
        public int IsSignOut { get{ return _isSignOut; }}
        public int Isremind { get{ return _isremind; }}
        public string NoremindMap { get{ return HanderDefine.SetStingCallBack(_noremind_map); }}
        public int IsCloseShow { get{ return _isCloseShow; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareDaily cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareDaily> _dataCaches = null;
        public static Dictionary<int, DeclareDaily> CacheData
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
                        if (HanderDefine.DataCallBack("Daily", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareDaily cfg = null;
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
        private unsafe static DeclareDaily LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareDaily();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._tips_name = (int)GetValue(keyIndex, _tips_name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._canshow = (int)GetValue(keyIndex, _canshow_Index, ptr);
            tmp._fbtype = (int)GetValue(keyIndex, _fbtype_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._main_production = (int)GetValue(keyIndex, _main_production_Index, ptr);
            tmp._production = (int)GetValue(keyIndex, _production_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._type_icon = (int)GetValue(keyIndex, _type_icon_Index, ptr);
            tmp._activeValue = (int)GetValue(keyIndex, _activeValue_Index, ptr);
            tmp._times = (int)GetValue(keyIndex, _times_Index, ptr);
            tmp._times_hide = (int)GetValue(keyIndex, _times_hide_Index, ptr);
            tmp._if_add_count = (int)GetValue(keyIndex, _if_add_count_Index, ptr);
            tmp._openday = (int)GetValue(keyIndex, _openday_Index, ptr);
            tmp._openLevel = (int)GetValue(keyIndex, _openLevel_Index, ptr);
            tmp._conditiondes = (int)GetValue(keyIndex, _conditiondes_Index, ptr);
            tmp._openTime = (int)GetValue(keyIndex, _openTime_Index, ptr);
            tmp._allDayOpen = (int)GetValue(keyIndex, _allDayOpen_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._closeTime = (int)GetValue(keyIndex, _closeTime_Index, ptr);
            tmp._openTimeDes = (int)GetValue(keyIndex, _openTimeDes_Index, ptr);
            tmp._team = (int)GetValue(keyIndex, _team_Index, ptr);
            tmp._description = (int)GetValue(keyIndex, _description_Index, ptr);
            tmp._state_power_count = (int)GetValue(keyIndex, _state_power_count_Index, ptr);
            tmp._buy_need_gold = (int)GetValue(keyIndex, _buy_need_gold_Index, ptr);
            tmp._refresh = (int)GetValue(keyIndex, _refresh_Index, ptr);
            tmp._cloneID = (int)GetValue(keyIndex, _cloneID_Index, ptr);
            tmp._sweep = (int)GetValue(keyIndex, _sweep_Index, ptr);
            tmp._sweepLevel = (int)GetValue(keyIndex, _sweepLevel_Index, ptr);
            tmp._delayDays = (int)GetValue(keyIndex, _delayDays_Index, ptr);
            tmp._ifGono = (int)GetValue(keyIndex, _ifGono_Index, ptr);
            tmp._ready = (int)GetValue(keyIndex, _ready_Index, ptr);
            tmp._foundTeam = (int)GetValue(keyIndex, _foundTeam_Index, ptr);
            tmp._openType = (int)GetValue(keyIndex, _openType_Index, ptr);
            tmp._openUI = (int)GetValue(keyIndex, _openUI_Index, ptr);
            tmp._npcID = (int)GetValue(keyIndex, _npcID_Index, ptr);
            tmp._ifPush = (int)GetValue(keyIndex, _ifPush_Index, ptr);
            tmp._pushType = (int)GetValue(keyIndex, _pushType_Index, ptr);
            tmp._pushAdvance = (int)GetValue(keyIndex, _pushAdvance_Index, ptr);
            tmp._addOnMenu = (int)GetValue(keyIndex, _addOnMenu_Index, ptr);
            tmp._crosstype = (int)GetValue(keyIndex, _crosstype_Index, ptr);
            tmp._crossMatch = (int)GetValue(keyIndex, _crossMatch_Index, ptr);
            tmp._ifcross = (int)GetValue(keyIndex, _ifcross_Index, ptr);
            tmp._maxValue = (int)GetValue(keyIndex, _maxValue_Index, ptr);
            tmp._task = (int)GetValue(keyIndex, _task_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._specialOpen = (int)GetValue(keyIndex, _specialOpen_Index, ptr);
            tmp._isSignOut = (int)GetValue(keyIndex, _isSignOut_Index, ptr);
            tmp._isremind = (int)GetValue(keyIndex, _isremind_Index, ptr);
            tmp._noremind_map = (int)GetValue(keyIndex, _noremind_map_Index, ptr);
            tmp._isCloseShow = (int)GetValue(keyIndex, _isCloseShow_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Daily", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("TipsName", out _tips_name_Index)) _tips_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Canshow", out _canshow_Index)) _canshow_Index = -1;
                    if (!nameIndexs.TryGetValue("Fbtype", out _fbtype_Index)) _fbtype_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("MainProduction", out _main_production_Index)) _main_production_Index = -1;
                    if (!nameIndexs.TryGetValue("Production", out _production_Index)) _production_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeIcon", out _type_icon_Index)) _type_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveValue", out _activeValue_Index)) _activeValue_Index = -1;
                    if (!nameIndexs.TryGetValue("Times", out _times_Index)) _times_Index = -1;
                    if (!nameIndexs.TryGetValue("TimesHide", out _times_hide_Index)) _times_hide_Index = -1;
                    if (!nameIndexs.TryGetValue("IfAddCount", out _if_add_count_Index)) _if_add_count_Index = -1;
                    if (!nameIndexs.TryGetValue("Openday", out _openday_Index)) _openday_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenLevel", out _openLevel_Index)) _openLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Conditiondes", out _conditiondes_Index)) _conditiondes_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenTime", out _openTime_Index)) _openTime_Index = -1;
                    if (!nameIndexs.TryGetValue("AllDayOpen", out _allDayOpen_Index)) _allDayOpen_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("CloseTime", out _closeTime_Index)) _closeTime_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenTimeDes", out _openTimeDes_Index)) _openTimeDes_Index = -1;
                    if (!nameIndexs.TryGetValue("Team", out _team_Index)) _team_Index = -1;
                    if (!nameIndexs.TryGetValue("Description", out _description_Index)) _description_Index = -1;
                    if (!nameIndexs.TryGetValue("StatePowerCount", out _state_power_count_Index)) _state_power_count_Index = -1;
                    if (!nameIndexs.TryGetValue("BuyNeedGold", out _buy_need_gold_Index)) _buy_need_gold_Index = -1;
                    if (!nameIndexs.TryGetValue("Refresh", out _refresh_Index)) _refresh_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneID", out _cloneID_Index)) _cloneID_Index = -1;
                    if (!nameIndexs.TryGetValue("Sweep", out _sweep_Index)) _sweep_Index = -1;
                    if (!nameIndexs.TryGetValue("SweepLevel", out _sweepLevel_Index)) _sweepLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("DelayDays", out _delayDays_Index)) _delayDays_Index = -1;
                    if (!nameIndexs.TryGetValue("IfGono", out _ifGono_Index)) _ifGono_Index = -1;
                    if (!nameIndexs.TryGetValue("Ready", out _ready_Index)) _ready_Index = -1;
                    if (!nameIndexs.TryGetValue("FoundTeam", out _foundTeam_Index)) _foundTeam_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenType", out _openType_Index)) _openType_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenUI", out _openUI_Index)) _openUI_Index = -1;
                    if (!nameIndexs.TryGetValue("NpcID", out _npcID_Index)) _npcID_Index = -1;
                    if (!nameIndexs.TryGetValue("IfPush", out _ifPush_Index)) _ifPush_Index = -1;
                    if (!nameIndexs.TryGetValue("PushType", out _pushType_Index)) _pushType_Index = -1;
                    if (!nameIndexs.TryGetValue("PushAdvance", out _pushAdvance_Index)) _pushAdvance_Index = -1;
                    if (!nameIndexs.TryGetValue("AddOnMenu", out _addOnMenu_Index)) _addOnMenu_Index = -1;
                    if (!nameIndexs.TryGetValue("Crosstype", out _crosstype_Index)) _crosstype_Index = -1;
                    if (!nameIndexs.TryGetValue("CrossMatch", out _crossMatch_Index)) _crossMatch_Index = -1;
                    if (!nameIndexs.TryGetValue("Ifcross", out _ifcross_Index)) _ifcross_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxValue", out _maxValue_Index)) _maxValue_Index = -1;
                    if (!nameIndexs.TryGetValue("Task", out _task_Index)) _task_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialOpen", out _specialOpen_Index)) _specialOpen_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSignOut", out _isSignOut_Index)) _isSignOut_Index = -1;
                    if (!nameIndexs.TryGetValue("Isremind", out _isremind_Index)) _isremind_Index = -1;
                    if (!nameIndexs.TryGetValue("NoremindMap", out _noremind_map_Index)) _noremind_map_Index = -1;
                    if (!nameIndexs.TryGetValue("IsCloseShow", out _isCloseShow_Index)) _isCloseShow_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareDaily>(keyCount);
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
            if(HanderDefine.DataCallBack("Daily", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareDaily cfg = null;
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
        public static DeclareDaily Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareDaily result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Daily", out _compressData))
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
