//文件是自动生成,请勿手动修改.来自数据文件:task
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTask
    {
        #region //静态变量定义
        private static int _task_id_Index = -1;
        private static int _camp_Index = -1;
        private static int _tape_name_Index = -1;
        private static int _chapterprogr_Index = -1;
        private static int _medalJD_Index = -1;
        private static int _chapter_name_Index = -1;
        private static int _chapter_desc_Index = -1;
        private static int _task_talk_end_Index = -1;
        private static int _task_name_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _recommend_tips_Index = -1;
        private static int _conditions_value_Index = -1;
        private static int _post_task_id_Index = -1;
        private static int _pre_task_id_Index = -1;
        private static int _taksdesc_Index = -1;
        private static int _task_talk_start_Index = -1;
        private static int _task_x_z_Index = -1;
        private static int _type_Index = -1;
        private static int _open_npc_panel_Index = -1;
        private static int _close_npc_panel_Index = -1;
        private static int _leave_map_Index = -1;
        private static int _prompt_icon_Index = -1;
        private static int _target_Index = -1;
        private static int _move_Index = -1;
        private static int _turn_Index = -1;
        private static int _animation_Index = -1;
        private static int _show_npc_Index = -1;
        private static int _show_monster_Index = -1;
        private static int _show_gather_Index = -1;
        private static int _pathMap_Index = -1;
        private static int _endpath_Index = -1;
        private static int _auto_commit_Index = -1;
        private static int _rewards_Index = -1;
        private static int _equip_Index = -1;
        private static int _show_Index = -1;
        private static int _equip_strengthening_Index = -1;
        private static int _share_Index = -1;
        private static int _monsterhide_Index = -1;
        private static int _flyteleport_Index = -1;
        private static int _open_panel_Index = -1;
        private static int _open_panel_param_Index = -1;
        private static int _servercloneId_Index = -1;
        private static int _isTransport_Index = -1;
        private static int _isAuto_Index = -1;
        private static int _set_act_skill_Index = -1;
        private static int _set_act_branch_Index = -1;
        private static int _isFly_Index = -1;
        private static int _planes_show_enter_Index = -1;
        private static int _isSyncPos_Index = -1;
        private static int _buff_Index = -1;
        private static int _isShowPrompt_Index = -1;
        private static int _promptText_Index = -1;
        private static int _target_type_Index = -1;
        private static int _overTaskFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //任务id(第1位为章节编号后面4位为任务编号)
        private int _task_id;
        //领取阵营（0为所有阵营）
        private int _camp;
        //任务标题名称hide
        private int _tape_name;
        //章节进度hide
        private int _chapterprogr;
        //徽章进度(徽章ID_当前进度)(@_@)
        private int _medalJD;
        //章节名称hide
        private int _chapter_name;
        //章节描述hide
        private int _chapter_desc;
        //NPC交任务对白接：
        private int _task_talk_end;
        //任务名称
        private int _task_name;
        //任务目标描述
        private int _conditions_describe;
        //任务目标推荐hide
        private int _recommend_tips;
        //领取条件：类型_值(@;@_@)
        //（类型读FunctionVariable表：1为等级，2为任务,3为开服时间,等级；不需要则留空)
        private int _conditions_value;
        //完成后接取任务ID（-1为新手村任务做完，0为主线做完）
        private int _post_task_id;
        //任务的前置任务的ID用于处理位面同步位置问题
        private int _pre_task_id;
        //主面板任务描述hide
        private int _taksdesc;
        //NPC接任务对白接
        private int _task_talk_start;
        //坐标
        //用于位面，走到具体的坐标
        //(@_@)
        private int _task_x_z;
        //任务类型（0NPC对话 1地图杀怪 2采集(不进背包） 3使用道具 4提交道具 5护送 6功能操作 7卡等级 8副本通关 9到达指定坐标 10收集道具（不进背包） 11收集道具（进背包） 12位面杀怪 13完成X个境界任务 14境界到达XX）15播放动作（0角色1法宝）
        private int _type;
        //是否寻路功能NPC（0 不需要 1需要）type类型为6时生效（hide）
        private int _open_npc_panel;
        //是否关闭功能NPC面板（0 不需要 1需要）type类型为6时生效（hide）
        private int _close_npc_panel;
        //进度达成是否强制退位面
        //(0不退 1退）配位面杀怪类型任务需要（hide）
        private int _leave_map;
        //到达目标点位置的ICON配置(只在达到目标位置生效)hide
        private int _prompt_icon;
        //任务目标(怪物ID_数量/NPCid_数量/等级/采集物品ID_数量_采集物ID/收集物品ID_数量_怪物ID/怪物ID_数量_NPCID_副本Id/飞行ID_飞行次数)(@_@)
        private int _target;
        //(法宝，宠物)位移坐标，用于15类型任务
        private int _move;
        //玩家进位面面向，用于15类型任务
        private int _turn;
        //表演动作
        private int _animation;
        //仅在任务显示NPC（@_@)
        private int _show_npc;
        //仅在任务显示怪物（@_@)
        private int _show_monster;
        //仅在任务显示采集物（@_@)
        private int _show_gather;
        //任务寻径地图ID
        private int _pathMap;
        //提交路径(地图id;ncpID)(@_@)
        //不配置的时候表示自动提交
        private int _endpath;
        //自动提交的任务
        //0.服务器自动完成
        //1.左边任务面板点击提交
        private int _auto_commit;
        //任务奖励(奖励1;奖励2;奖励N) 奖励模型_数量_是否绑定[@;@_@]
        private int _rewards;
        //奖励装备（格式：职业_装备ID_是否绑定）多个用；间隔(@;@_@)
        private int _equip;
        //神兵展示(@_@)
        private int _show;
        //装备强化属性（强化等级）
        private int _equip_strengthening;
        //任务共享类型（0为不共享，1为共享）
        private int _share;
        //怪物是否是隐藏的
        private int _monsterhide;
        //接受到任务时进行飞行传送的ID
        private int _flyteleport;
        //开启界面hide
        private int _open_panel;
        //参数
        private int _open_panel_param;
        //服务器副本ID值，服务器机器人用于完成副本任务处理
        private int _servercloneId;
        //是否传送（0传送，1不传送）
        private int _isTransport;
        //是否自动交接任务（0自动，1不自动）
        private int _isAuto;
        //激活技能（职业ID_技能ID；职业ID_技能ID）(@;@_@)
        private int _set_act_skill;
        //激活分支（职业ID_分支ID_分支索引；职业ID_分支ID_分支索引）(@;@_@)
        private int _set_act_branch;
        //是否加载小飞鞋特效（0否1是）
        private int _isFly;
        //当为位面时，进位面的表现效果
        //0表示：无效果直接切
        //具体参数表示进入退出效果
        private int _planes_show_enter;
        //任务位面是否同步位置
        //（0表示不同步，默认为0，1表示同步）
        private int _isSyncPos;
        //完成任务后获得的buff
        private int _buff;
        //是否显示引导提示
        private int _isShowPrompt;
        //引导提示的文本
        private int _promptText;
        //目标系统的分类：（0，境界剑灵；1，装备养成；2，角色成长；3，骑宠造化；4，其他）hide
        private int _target_type;
        //任务在完成状态下跳转的界面（对应FunctionStar的ID）
        //（hide）
        private int _overTaskFunction;
        #endregion

        #region //公共属性
        public int TaskId { get{ return _task_id; }}
        public int Camp { get{ return _camp; }}
        public string TapeName { get{ return HanderDefine.SetStingCallBack(_tape_name); }}
        public string Chapterprogr { get{ return HanderDefine.SetStingCallBack(_chapterprogr); }}
        public string MedalJD { get{ return HanderDefine.SetStingCallBack(_medalJD); }}
        public string ChapterName { get{ return HanderDefine.SetStingCallBack(_chapter_name); }}
        public string ChapterDesc { get{ return HanderDefine.SetStingCallBack(_chapter_desc); }}
        public int TaskTalkEnd { get{ return _task_talk_end; }}
        public string TaskName { get{ return HanderDefine.SetStingCallBack(_task_name); }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public string RecommendTips { get{ return HanderDefine.SetStingCallBack(_recommend_tips); }}
        public string ConditionsValue { get{ return HanderDefine.SetStingCallBack(_conditions_value); }}
        public int PostTaskId { get{ return _post_task_id; }}
        public int PreTaskId { get{ return _pre_task_id; }}
        public string Taksdesc { get{ return HanderDefine.SetStingCallBack(_taksdesc); }}
        public int TaskTalkStart { get{ return _task_talk_start; }}
        public string TaskXZ { get{ return HanderDefine.SetStingCallBack(_task_x_z); }}
        public int Type { get{ return _type; }}
        public int OpenNpcPanel { get{ return _open_npc_panel; }}
        public int CloseNpcPanel { get{ return _close_npc_panel; }}
        public int LeaveMap { get{ return _leave_map; }}
        public int PromptIcon { get{ return _prompt_icon; }}
        public string Target { get{ return HanderDefine.SetStingCallBack(_target); }}
        public string Move { get{ return HanderDefine.SetStingCallBack(_move); }}
        public int Turn { get{ return _turn; }}
        public string Animation { get{ return HanderDefine.SetStingCallBack(_animation); }}
        public string ShowNpc { get{ return HanderDefine.SetStingCallBack(_show_npc); }}
        public string ShowMonster { get{ return HanderDefine.SetStingCallBack(_show_monster); }}
        public string ShowGather { get{ return HanderDefine.SetStingCallBack(_show_gather); }}
        public int PathMap { get{ return _pathMap; }}
        public string Endpath { get{ return HanderDefine.SetStingCallBack(_endpath); }}
        public int AutoCommit { get{ return _auto_commit; }}
        public string Rewards { get{ return HanderDefine.SetStingCallBack(_rewards); }}
        public string Equip { get{ return HanderDefine.SetStingCallBack(_equip); }}
        public string Show { get{ return HanderDefine.SetStingCallBack(_show); }}
        public string EquipStrengthening { get{ return HanderDefine.SetStingCallBack(_equip_strengthening); }}
        public int Share { get{ return _share; }}
        public int Monsterhide { get{ return _monsterhide; }}
        public int Flyteleport { get{ return _flyteleport; }}
        public int OpenPanel { get{ return _open_panel; }}
        public int OpenPanelParam { get{ return _open_panel_param; }}
        public int ServercloneId { get{ return _servercloneId; }}
        public int IsTransport { get{ return _isTransport; }}
        public int IsAuto { get{ return _isAuto; }}
        public string SetActSkill { get{ return HanderDefine.SetStingCallBack(_set_act_skill); }}
        public string SetActBranch { get{ return HanderDefine.SetStingCallBack(_set_act_branch); }}
        public int IsFly { get{ return _isFly; }}
        public string PlanesShowEnter { get{ return HanderDefine.SetStingCallBack(_planes_show_enter); }}
        public int IsSyncPos { get{ return _isSyncPos; }}
        public int Buff { get{ return _buff; }}
        public int IsShowPrompt { get{ return _isShowPrompt; }}
        public string PromptText { get{ return HanderDefine.SetStingCallBack(_promptText); }}
        public int TargetType { get{ return _target_type; }}
        public int OverTaskFunction { get{ return _overTaskFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTask cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTask> _dataCaches = null;
        public static Dictionary<int, DeclareTask> CacheData
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
                        if (HanderDefine.DataCallBack("Task", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTask cfg = null;
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
        private unsafe static DeclareTask LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTask();
            tmp._task_id = (int)GetValue(keyIndex, _task_id_Index, ptr);
            tmp._camp = (int)GetValue(keyIndex, _camp_Index, ptr);
            tmp._tape_name = (int)GetValue(keyIndex, _tape_name_Index, ptr);
            tmp._chapterprogr = (int)GetValue(keyIndex, _chapterprogr_Index, ptr);
            tmp._medalJD = (int)GetValue(keyIndex, _medalJD_Index, ptr);
            tmp._chapter_name = (int)GetValue(keyIndex, _chapter_name_Index, ptr);
            tmp._chapter_desc = (int)GetValue(keyIndex, _chapter_desc_Index, ptr);
            tmp._task_talk_end = (int)GetValue(keyIndex, _task_talk_end_Index, ptr);
            tmp._task_name = (int)GetValue(keyIndex, _task_name_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._recommend_tips = (int)GetValue(keyIndex, _recommend_tips_Index, ptr);
            tmp._conditions_value = (int)GetValue(keyIndex, _conditions_value_Index, ptr);
            tmp._post_task_id = (int)GetValue(keyIndex, _post_task_id_Index, ptr);
            tmp._pre_task_id = (int)GetValue(keyIndex, _pre_task_id_Index, ptr);
            tmp._taksdesc = (int)GetValue(keyIndex, _taksdesc_Index, ptr);
            tmp._task_talk_start = (int)GetValue(keyIndex, _task_talk_start_Index, ptr);
            tmp._task_x_z = (int)GetValue(keyIndex, _task_x_z_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._open_npc_panel = (int)GetValue(keyIndex, _open_npc_panel_Index, ptr);
            tmp._close_npc_panel = (int)GetValue(keyIndex, _close_npc_panel_Index, ptr);
            tmp._leave_map = (int)GetValue(keyIndex, _leave_map_Index, ptr);
            tmp._prompt_icon = (int)GetValue(keyIndex, _prompt_icon_Index, ptr);
            tmp._target = (int)GetValue(keyIndex, _target_Index, ptr);
            tmp._move = (int)GetValue(keyIndex, _move_Index, ptr);
            tmp._turn = (int)GetValue(keyIndex, _turn_Index, ptr);
            tmp._animation = (int)GetValue(keyIndex, _animation_Index, ptr);
            tmp._show_npc = (int)GetValue(keyIndex, _show_npc_Index, ptr);
            tmp._show_monster = (int)GetValue(keyIndex, _show_monster_Index, ptr);
            tmp._show_gather = (int)GetValue(keyIndex, _show_gather_Index, ptr);
            tmp._pathMap = (int)GetValue(keyIndex, _pathMap_Index, ptr);
            tmp._endpath = (int)GetValue(keyIndex, _endpath_Index, ptr);
            tmp._auto_commit = (int)GetValue(keyIndex, _auto_commit_Index, ptr);
            tmp._rewards = (int)GetValue(keyIndex, _rewards_Index, ptr);
            tmp._equip = (int)GetValue(keyIndex, _equip_Index, ptr);
            tmp._show = (int)GetValue(keyIndex, _show_Index, ptr);
            tmp._equip_strengthening = (int)GetValue(keyIndex, _equip_strengthening_Index, ptr);
            tmp._share = (int)GetValue(keyIndex, _share_Index, ptr);
            tmp._monsterhide = (int)GetValue(keyIndex, _monsterhide_Index, ptr);
            tmp._flyteleport = (int)GetValue(keyIndex, _flyteleport_Index, ptr);
            tmp._open_panel = (int)GetValue(keyIndex, _open_panel_Index, ptr);
            tmp._open_panel_param = (int)GetValue(keyIndex, _open_panel_param_Index, ptr);
            tmp._servercloneId = (int)GetValue(keyIndex, _servercloneId_Index, ptr);
            tmp._isTransport = (int)GetValue(keyIndex, _isTransport_Index, ptr);
            tmp._isAuto = (int)GetValue(keyIndex, _isAuto_Index, ptr);
            tmp._set_act_skill = (int)GetValue(keyIndex, _set_act_skill_Index, ptr);
            tmp._set_act_branch = (int)GetValue(keyIndex, _set_act_branch_Index, ptr);
            tmp._isFly = (int)GetValue(keyIndex, _isFly_Index, ptr);
            tmp._planes_show_enter = (int)GetValue(keyIndex, _planes_show_enter_Index, ptr);
            tmp._isSyncPos = (int)GetValue(keyIndex, _isSyncPos_Index, ptr);
            tmp._buff = (int)GetValue(keyIndex, _buff_Index, ptr);
            tmp._isShowPrompt = (int)GetValue(keyIndex, _isShowPrompt_Index, ptr);
            tmp._promptText = (int)GetValue(keyIndex, _promptText_Index, ptr);
            tmp._target_type = (int)GetValue(keyIndex, _target_type_Index, ptr);
            tmp._overTaskFunction = (int)GetValue(keyIndex, _overTaskFunction_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Task", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("TaskId", out _task_id_Index)) _task_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Camp", out _camp_Index)) _camp_Index = -1;
                    if (!nameIndexs.TryGetValue("TapeName", out _tape_name_Index)) _tape_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Chapterprogr", out _chapterprogr_Index)) _chapterprogr_Index = -1;
                    if (!nameIndexs.TryGetValue("MedalJD", out _medalJD_Index)) _medalJD_Index = -1;
                    if (!nameIndexs.TryGetValue("ChapterName", out _chapter_name_Index)) _chapter_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ChapterDesc", out _chapter_desc_Index)) _chapter_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkEnd", out _task_talk_end_Index)) _task_talk_end_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskName", out _task_name_Index)) _task_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("RecommendTips", out _recommend_tips_Index)) _recommend_tips_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsValue", out _conditions_value_Index)) _conditions_value_Index = -1;
                    if (!nameIndexs.TryGetValue("PostTaskId", out _post_task_id_Index)) _post_task_id_Index = -1;
                    if (!nameIndexs.TryGetValue("PreTaskId", out _pre_task_id_Index)) _pre_task_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Taksdesc", out _taksdesc_Index)) _taksdesc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkStart", out _task_talk_start_Index)) _task_talk_start_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskXZ", out _task_x_z_Index)) _task_x_z_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenNpcPanel", out _open_npc_panel_Index)) _open_npc_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("CloseNpcPanel", out _close_npc_panel_Index)) _close_npc_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("LeaveMap", out _leave_map_Index)) _leave_map_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptIcon", out _prompt_icon_Index)) _prompt_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Target", out _target_Index)) _target_Index = -1;
                    if (!nameIndexs.TryGetValue("Move", out _move_Index)) _move_Index = -1;
                    if (!nameIndexs.TryGetValue("Turn", out _turn_Index)) _turn_Index = -1;
                    if (!nameIndexs.TryGetValue("Animation", out _animation_Index)) _animation_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNpc", out _show_npc_Index)) _show_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMonster", out _show_monster_Index)) _show_monster_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGather", out _show_gather_Index)) _show_gather_Index = -1;
                    if (!nameIndexs.TryGetValue("PathMap", out _pathMap_Index)) _pathMap_Index = -1;
                    if (!nameIndexs.TryGetValue("Endpath", out _endpath_Index)) _endpath_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoCommit", out _auto_commit_Index)) _auto_commit_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards", out _rewards_Index)) _rewards_Index = -1;
                    if (!nameIndexs.TryGetValue("Equip", out _equip_Index)) _equip_Index = -1;
                    if (!nameIndexs.TryGetValue("Show", out _show_Index)) _show_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipStrengthening", out _equip_strengthening_Index)) _equip_strengthening_Index = -1;
                    if (!nameIndexs.TryGetValue("Share", out _share_Index)) _share_Index = -1;
                    if (!nameIndexs.TryGetValue("Monsterhide", out _monsterhide_Index)) _monsterhide_Index = -1;
                    if (!nameIndexs.TryGetValue("Flyteleport", out _flyteleport_Index)) _flyteleport_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanel", out _open_panel_Index)) _open_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanelParam", out _open_panel_param_Index)) _open_panel_param_Index = -1;
                    if (!nameIndexs.TryGetValue("ServercloneId", out _servercloneId_Index)) _servercloneId_Index = -1;
                    if (!nameIndexs.TryGetValue("IsTransport", out _isTransport_Index)) _isTransport_Index = -1;
                    if (!nameIndexs.TryGetValue("IsAuto", out _isAuto_Index)) _isAuto_Index = -1;
                    if (!nameIndexs.TryGetValue("SetActSkill", out _set_act_skill_Index)) _set_act_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("SetActBranch", out _set_act_branch_Index)) _set_act_branch_Index = -1;
                    if (!nameIndexs.TryGetValue("IsFly", out _isFly_Index)) _isFly_Index = -1;
                    if (!nameIndexs.TryGetValue("PlanesShowEnter", out _planes_show_enter_Index)) _planes_show_enter_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSyncPos", out _isSyncPos_Index)) _isSyncPos_Index = -1;
                    if (!nameIndexs.TryGetValue("Buff", out _buff_Index)) _buff_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShowPrompt", out _isShowPrompt_Index)) _isShowPrompt_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptText", out _promptText_Index)) _promptText_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetType", out _target_type_Index)) _target_type_Index = -1;
                    if (!nameIndexs.TryGetValue("OverTaskFunction", out _overTaskFunction_Index)) _overTaskFunction_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTask>(keyCount);
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
            if(HanderDefine.DataCallBack("Task", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTask cfg = null;
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
        public static DeclareTask Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTask result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Task", out _compressData))
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
