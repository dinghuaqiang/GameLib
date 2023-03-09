//文件是自动生成,请勿手动修改.来自数据文件:clone_map
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCloneMap
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _dailyid_Index = -1;
        private static int _main_type_Index = -1;
        private static int _type_Index = -1;
        private static int _teamshow_Index = -1;
        private static int _open_interface_Index = -1;
        private static int _type_name_Index = -1;
        private static int _mapid_Index = -1;
        private static int _duplicate_name_Index = -1;
        private static int _params_Index = -1;
        private static int _buy_need_gold_Index = -1;
        private static int _enter_type_Index = -1;
        private static int _enter_sub_type_Index = -1;
        private static int _if_match_Index = -1;
        private static int _clone_story_Index = -1;
        private static int _min_lv_Index = -1;
        private static int _max_lv_Index = -1;
        private static int _manual_num_Index = -1;
        private static int _sign_up_time_Index = -1;
        private static int _enter_time_Index = -1;
        private static int _exist_time_Index = -1;
        private static int _success_reward_Index = -1;
        private static int _fail_reward_Index = -1;
        private static int _extra_reward_Index = -1;
        private static int _explain_Index = -1;
        private static int _isSyPos_Index = -1;
        private static int _participation_Award_Index = -1;
        private static int _participation_Award1_Index = -1;
        private static int _random_Description_Index = -1;
        private static int _combat_power_Index = -1;
        private static int _canUpMorale_Index = -1;
        private static int _pictureRes_Index = -1;
        private static int _show_head_Index = -1;
        private static int _show_model_Index = -1;
        private static int _model_rotat_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _sweep_Index = -1;
        private static int _sweep_free_Index = -1;
        private static int _needTaskId_Index = -1;
        private static int _equipLevel_Index = -1;
        private static int _materialLevel_Index = -1;
        private static int _runningyedai_Index = -1;
        private static int _group_id_Index = -1;
        private static int _isRide_Index = -1;
        #endregion
        #region //私有变量定义
        //副本编号
        private int _id;
        //对应的日常ID(用于购买次数）
        private int _dailyid;
        //总类型（1，副本；2，活动；3，位面）
        private int _main_type;
        //副本类型：1：多人副本;2：个人挑战副本;3首席副本;4婚宴地图;5Boss之家;6个人BOSS;7幻境BOSS;8上古战场;9勇者之巅;10神兽岛;11位面副本；12宗派福地；13福地宝藏；14大能遗府；15天界之门；16境界boss；17特殊无限层；18本服领地战；19跨服领地战；20八极阵图；21世界篝火；22掌门传道；23天墟战场；24仙盟任务副本；25仙盟战；26仙盟驻地;27剑主试炼；28剑灵阁；29情缘副本；30巅峰竞技；31福地论剑；32荒古神坛；33魔王缝隙；34魔王缝隙除魔团；35仙侣对决；36家园地图；37混沌虚空；38混沌虚空宝库；39混沌boss
        private int _type;
        //是否在组队中显示（0为不显示，1为显示）hide
        private int _teamshow;
        //副本界面(如果没有，则为0)hide
        private int _open_interface;
        //副本组队中的名称
        private int _type_name;
        //副本关联地图编号
        private int _mapid;
        //副本名称（支持HTML）
        private int _duplicate_name;
        //额外参数
        private int _params;
        //购买次数时消耗的元宝，优先消耗绑定元宝(@_@)
        private int _buy_need_gold;
        //副本进入类型：1.本服;2.跨服
        private int _enter_type;
        //进入子类型(1.单人；2.组队；3.单人+组队）
        private int _enter_sub_type;
        //是否需要匹配（0，不需要；1，需要）
        private int _if_match;
        //副本难度(0：不需要填写;1：简单;2：困难;3：地狱）
        private int _clone_story;
        //进入所需最小等级
        private int _min_lv;
        //最高等级进入限制
        private int _max_lv;
        //每日手动挑战次数(-1表示未开放,0表示不限制)
        private int _manual_num;
        //副本报名时间（毫秒）
        private int _sign_up_time;
        //进入副本后准备阶段时间（毫秒）
        private int _enter_time;
        //副本时间（毫秒）
        private int _exist_time;
        //副本成功奖励：物品ID_数量;物品ID_数量[@;@_@]
        private int _success_reward;
        //副本失败奖励：物品ID_数量;物品ID_数量[@;@_@]
        private int _fail_reward;
        //副本特殊奖励【积分】：物品ID_数量_参数;物品ID_数量_参数[@;@_@]
        private int _extra_reward;
        //副本说明（支持HTML）hide
        private int _explain;
        //任务位面是否同步位置
        //（0表示不同步，默认为0，1表示同步）
        private int _isSyPos;
        //活动参与奖励hide，只用于界面展示
        private int _participation_Award;
        //活动参与文字奖励hide，只用于界面展示
        private int _participation_Award1;
        //BOSS击杀大奖描述（物品ID_数量;物品ID_数量）(@;@_@)
        private int _random_Description;
        //推荐战斗力
        private int _combat_power;
        //能否鼓舞
        private int _canUpMorale;
        //前端展示图片hide
        private int _pictureRes;
        //前端展示头像hide
        private int _show_head;
        //前端展示模型hide
        private int _show_model;
        //模型旋转hide
        private int _model_rotat;
        //模型的摄像机大小(hide)(放大100倍）
        private int _camera_size;
        //扫荡要求物品(@_@)
        private int _sweep;
        //免费扫荡条件(@_@)
        private int _sweep_free;
        //需要完成的主线任务id(@_@)
        private int _needTaskId;
        //排序（小的再前，大的灾后）
        private int _equipLevel;
        //给予经验的索引
        private int _materialLevel;
        //副本开场跑的ai
        private int _runningyedai;
        //副本组，每一组代表同一个副本
        private int _group_id;
        //是否可以上坐骑（同时需要再mapsetting配置可上坐骑才会生效）
        //0不允许
        //1允许
        private int _isRide;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Dailyid { get{ return _dailyid; }}
        public int MainType { get{ return _main_type; }}
        public int Type { get{ return _type; }}
        public int Teamshow { get{ return _teamshow; }}
        public int OpenInterface { get{ return _open_interface; }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_type_name); }}
        public int Mapid { get{ return _mapid; }}
        public string DuplicateName { get{ return HanderDefine.SetStingCallBack(_duplicate_name); }}
        public string Params { get{ return HanderDefine.SetStingCallBack(_params); }}
        public string BuyNeedGold { get{ return HanderDefine.SetStingCallBack(_buy_need_gold); }}
        public int EnterType { get{ return _enter_type; }}
        public int EnterSubType { get{ return _enter_sub_type; }}
        public int IfMatch { get{ return _if_match; }}
        public int CloneStory { get{ return _clone_story; }}
        public int MinLv { get{ return _min_lv; }}
        public int MaxLv { get{ return _max_lv; }}
        public int ManualNum { get{ return _manual_num; }}
        public int SignUpTime { get{ return _sign_up_time; }}
        public int EnterTime { get{ return _enter_time; }}
        public int ExistTime { get{ return _exist_time; }}
        public string SuccessReward { get{ return HanderDefine.SetStingCallBack(_success_reward); }}
        public string FailReward { get{ return HanderDefine.SetStingCallBack(_fail_reward); }}
        public string ExtraReward { get{ return HanderDefine.SetStingCallBack(_extra_reward); }}
        public string Explain { get{ return HanderDefine.SetStingCallBack(_explain); }}
        public int IsSyPos { get{ return _isSyPos; }}
        public string ParticipationAward { get{ return HanderDefine.SetStingCallBack(_participation_Award); }}
        public string ParticipationAward1 { get{ return HanderDefine.SetStingCallBack(_participation_Award1); }}
        public string RandomDescription { get{ return HanderDefine.SetStingCallBack(_random_Description); }}
        public int CombatPower { get{ return _combat_power; }}
        public int CanUpMorale { get{ return _canUpMorale; }}
        public string PictureRes { get{ return HanderDefine.SetStingCallBack(_pictureRes); }}
        public int ShowHead { get{ return _show_head; }}
        public int ShowModel { get{ return _show_model; }}
        public int ModelRotat { get{ return _model_rotat; }}
        public int CameraSize { get{ return _camera_size; }}
        public string Sweep { get{ return HanderDefine.SetStingCallBack(_sweep); }}
        public string SweepFree { get{ return HanderDefine.SetStingCallBack(_sweep_free); }}
        public string NeedTaskId { get{ return HanderDefine.SetStingCallBack(_needTaskId); }}
        public int EquipLevel { get{ return _equipLevel; }}
        public int MaterialLevel { get{ return _materialLevel; }}
        public string Runningyedai { get{ return HanderDefine.SetStingCallBack(_runningyedai); }}
        public int GroupId { get{ return _group_id; }}
        public int IsRide { get{ return _isRide; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCloneMap cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCloneMap> _dataCaches = null;
        public static Dictionary<int, DeclareCloneMap> CacheData
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
                        if (HanderDefine.DataCallBack("CloneMap", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCloneMap cfg = null;
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
        private unsafe static DeclareCloneMap LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCloneMap();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._dailyid = (int)GetValue(keyIndex, _dailyid_Index, ptr);
            tmp._main_type = (int)GetValue(keyIndex, _main_type_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._teamshow = (int)GetValue(keyIndex, _teamshow_Index, ptr);
            tmp._open_interface = (int)GetValue(keyIndex, _open_interface_Index, ptr);
            tmp._type_name = (int)GetValue(keyIndex, _type_name_Index, ptr);
            tmp._mapid = (int)GetValue(keyIndex, _mapid_Index, ptr);
            tmp._duplicate_name = (int)GetValue(keyIndex, _duplicate_name_Index, ptr);
            tmp._params = (int)GetValue(keyIndex, _params_Index, ptr);
            tmp._buy_need_gold = (int)GetValue(keyIndex, _buy_need_gold_Index, ptr);
            tmp._enter_type = (int)GetValue(keyIndex, _enter_type_Index, ptr);
            tmp._enter_sub_type = (int)GetValue(keyIndex, _enter_sub_type_Index, ptr);
            tmp._if_match = (int)GetValue(keyIndex, _if_match_Index, ptr);
            tmp._clone_story = (int)GetValue(keyIndex, _clone_story_Index, ptr);
            tmp._min_lv = (int)GetValue(keyIndex, _min_lv_Index, ptr);
            tmp._max_lv = (int)GetValue(keyIndex, _max_lv_Index, ptr);
            tmp._manual_num = (int)GetValue(keyIndex, _manual_num_Index, ptr);
            tmp._sign_up_time = (int)GetValue(keyIndex, _sign_up_time_Index, ptr);
            tmp._enter_time = (int)GetValue(keyIndex, _enter_time_Index, ptr);
            tmp._exist_time = (int)GetValue(keyIndex, _exist_time_Index, ptr);
            tmp._success_reward = (int)GetValue(keyIndex, _success_reward_Index, ptr);
            tmp._fail_reward = (int)GetValue(keyIndex, _fail_reward_Index, ptr);
            tmp._extra_reward = (int)GetValue(keyIndex, _extra_reward_Index, ptr);
            tmp._explain = (int)GetValue(keyIndex, _explain_Index, ptr);
            tmp._isSyPos = (int)GetValue(keyIndex, _isSyPos_Index, ptr);
            tmp._participation_Award = (int)GetValue(keyIndex, _participation_Award_Index, ptr);
            tmp._participation_Award1 = (int)GetValue(keyIndex, _participation_Award1_Index, ptr);
            tmp._random_Description = (int)GetValue(keyIndex, _random_Description_Index, ptr);
            tmp._combat_power = (int)GetValue(keyIndex, _combat_power_Index, ptr);
            tmp._canUpMorale = (int)GetValue(keyIndex, _canUpMorale_Index, ptr);
            tmp._pictureRes = (int)GetValue(keyIndex, _pictureRes_Index, ptr);
            tmp._show_head = (int)GetValue(keyIndex, _show_head_Index, ptr);
            tmp._show_model = (int)GetValue(keyIndex, _show_model_Index, ptr);
            tmp._model_rotat = (int)GetValue(keyIndex, _model_rotat_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._sweep = (int)GetValue(keyIndex, _sweep_Index, ptr);
            tmp._sweep_free = (int)GetValue(keyIndex, _sweep_free_Index, ptr);
            tmp._needTaskId = (int)GetValue(keyIndex, _needTaskId_Index, ptr);
            tmp._equipLevel = (int)GetValue(keyIndex, _equipLevel_Index, ptr);
            tmp._materialLevel = (int)GetValue(keyIndex, _materialLevel_Index, ptr);
            tmp._runningyedai = (int)GetValue(keyIndex, _runningyedai_Index, ptr);
            tmp._group_id = (int)GetValue(keyIndex, _group_id_Index, ptr);
            tmp._isRide = (int)GetValue(keyIndex, _isRide_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CloneMap", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Dailyid", out _dailyid_Index)) _dailyid_Index = -1;
                    if (!nameIndexs.TryGetValue("MainType", out _main_type_Index)) _main_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Teamshow", out _teamshow_Index)) _teamshow_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenInterface", out _open_interface_Index)) _open_interface_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _type_name_Index)) _type_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Mapid", out _mapid_Index)) _mapid_Index = -1;
                    if (!nameIndexs.TryGetValue("DuplicateName", out _duplicate_name_Index)) _duplicate_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Params", out _params_Index)) _params_Index = -1;
                    if (!nameIndexs.TryGetValue("BuyNeedGold", out _buy_need_gold_Index)) _buy_need_gold_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterType", out _enter_type_Index)) _enter_type_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterSubType", out _enter_sub_type_Index)) _enter_sub_type_Index = -1;
                    if (!nameIndexs.TryGetValue("IfMatch", out _if_match_Index)) _if_match_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneStory", out _clone_story_Index)) _clone_story_Index = -1;
                    if (!nameIndexs.TryGetValue("MinLv", out _min_lv_Index)) _min_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLv", out _max_lv_Index)) _max_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("ManualNum", out _manual_num_Index)) _manual_num_Index = -1;
                    if (!nameIndexs.TryGetValue("SignUpTime", out _sign_up_time_Index)) _sign_up_time_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterTime", out _enter_time_Index)) _enter_time_Index = -1;
                    if (!nameIndexs.TryGetValue("ExistTime", out _exist_time_Index)) _exist_time_Index = -1;
                    if (!nameIndexs.TryGetValue("SuccessReward", out _success_reward_Index)) _success_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("FailReward", out _fail_reward_Index)) _fail_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ExtraReward", out _extra_reward_Index)) _extra_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Explain", out _explain_Index)) _explain_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSyPos", out _isSyPos_Index)) _isSyPos_Index = -1;
                    if (!nameIndexs.TryGetValue("ParticipationAward", out _participation_Award_Index)) _participation_Award_Index = -1;
                    if (!nameIndexs.TryGetValue("ParticipationAward1", out _participation_Award1_Index)) _participation_Award1_Index = -1;
                    if (!nameIndexs.TryGetValue("RandomDescription", out _random_Description_Index)) _random_Description_Index = -1;
                    if (!nameIndexs.TryGetValue("CombatPower", out _combat_power_Index)) _combat_power_Index = -1;
                    if (!nameIndexs.TryGetValue("CanUpMorale", out _canUpMorale_Index)) _canUpMorale_Index = -1;
                    if (!nameIndexs.TryGetValue("PictureRes", out _pictureRes_Index)) _pictureRes_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowHead", out _show_head_Index)) _show_head_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModel", out _show_model_Index)) _show_model_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRotat", out _model_rotat_Index)) _model_rotat_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("Sweep", out _sweep_Index)) _sweep_Index = -1;
                    if (!nameIndexs.TryGetValue("SweepFree", out _sweep_free_Index)) _sweep_free_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedTaskId", out _needTaskId_Index)) _needTaskId_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipLevel", out _equipLevel_Index)) _equipLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("MaterialLevel", out _materialLevel_Index)) _materialLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Runningyedai", out _runningyedai_Index)) _runningyedai_Index = -1;
                    if (!nameIndexs.TryGetValue("GroupId", out _group_id_Index)) _group_id_Index = -1;
                    if (!nameIndexs.TryGetValue("IsRide", out _isRide_Index)) _isRide_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCloneMap>(keyCount);
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
            if(HanderDefine.DataCallBack("CloneMap", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCloneMap cfg = null;
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
        public static DeclareCloneMap Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCloneMap result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CloneMap", out _compressData))
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
