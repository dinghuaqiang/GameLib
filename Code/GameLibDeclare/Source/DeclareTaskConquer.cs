//文件是自动生成,请勿手动修改.来自数据文件:task_conquer
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTaskConquer
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _task_name_Index = -1;
        private static int _conquer_subtype_Index = -1;
        private static int _subtype_describe_Index = -1;
        private static int _tape_name_Index = -1;
        private static int _task_grade_Index = -1;
        private static int _task_weight_Index = -1;
        private static int _task_icon_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _content_describe_Index = -1;
        private static int _conditions_npc_Index = -1;
        private static int _task_talk_start_Index = -1;
        private static int _over_npc_Index = -1;
        private static int _task_talk_over_Index = -1;
        private static int _task_type_Index = -1;
        private static int _task_x_z_Index = -1;
        private static int _goal_npc_Index = -1;
        private static int _open_npc_panel_Index = -1;
        private static int _prompt_icon_Index = -1;
        private static int _show_npc_Index = -1;
        private static int _show_monster_Index = -1;
        private static int _show_gather_Index = -1;
        private static int _auto_commit_Index = -1;
        private static int _over_currency_Index = -1;
        private static int _double_currency_Index = -1;
        private static int _rewards_Index = -1;
        private static int _assistrewards_Index = -1;
        private static int _clonemap_Index = -1;
        private static int _guildSupport_Index = -1;
        private static int _planes_show_enter_Index = -1;
        private static int _isSyncPos_Index = -1;
        private static int _recieve_Index = -1;
        private static int _target_type_Index = -1;
        private static int _overTaskFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //任务ID
        private int _id;
        //任务名称
        private int _task_name;
        //仙盟任务子类型（0 仙盟周常；1 宗派日常；2 仙盟日常）
        private int _conquer_subtype;
        //char
        private int _subtype_describe;
        //任务标题名称hide
        private int _tape_name;
        //任务的品级（1_C，2_B,3_A,4_S）
        private int _task_grade;
        //任务的权重（万分比）
        private int _task_weight;
        //界面上的图标(hide)
        private int _task_icon;
        //任务目标描述
        private int _conditions_describe;
        //任务内容描述
        private int _content_describe;
        //领取任务的NPC
        private int _conditions_npc;
        //领取任务对话
        private int _task_talk_start;
        //提交任务NPC
        private int _over_npc;
        //完成任务对话
        private int _task_talk_over;
        //任务类型（0NPC对话 1地图杀怪 2采集(不进背包） 3使用道具 4提交道具 5护送 6功能操作 7卡等级 8副本通关 9到达指定坐标 10收集道具（不进背包） 11收集道具（进背包） 12位面杀怪 13完成X个境界任务 14境界到达XX  15仙盟宣扬  16仙盟副本）
        private int _task_type;
        //坐标
        //用于位面，走到具体的坐标
        //(@_@)
        private int _task_x_z;
        //任务目标(任务模型/NPC_数量)(@_@)
        private int _goal_npc;
        //是否寻路功能NPC（0 不需要 1需要）type类型为6时生效（hide）
        private int _open_npc_panel;
        //到达目标点位置的ICON配置(只在达到目标位置生效)hide
        private int _prompt_icon;
        //仅在任务显示NPC（@_@)
        private int _show_npc;
        //仅在任务显示怪物（@_@)
        private int _show_monster;
        //仅在任务显示采集物（@_@)
        private int _show_gather;
        //自动提交的任务
        //0.服务器自动完成
        //1.左边任务面板点击提交
        private int _auto_commit;
        //完成单次货币(完成任务货币类型_值)(@_@)
        private int _over_currency;
        //双倍奖励(双倍奖励货币类型_值)(@_@)
        private int _double_currency;
        //任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards;
        //协助奖励
        private int _assistrewards;
        //副本id
        private int _clonemap;
        //是否可以求援
        private int _guildSupport;
        //当为位面时，进位面的表现效果
        //0表示：无效果直接切
        //具体参数表示进入退出效果
        private int _planes_show_enter;
        //任务位面是否同步位置
        //（0表示不同步，默认为0，1表示同步）
        private int _isSyncPos;
        //服务器是否自动派发（0自动派到任务栏 1需要玩家主动接取）
        private int _recieve;
        //目标系统的分类：（0，境界剑灵；1，装备养成；2，角色成长；3，骑宠造化；4，其他）hide
        private int _target_type;
        //任务在完成状态下跳转的界面（对应FunctionStar的ID）
        //（hide）
        private int _overTaskFunction;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string TaskName { get{ return HanderDefine.SetStingCallBack(_task_name); }}
        public int ConquerSubtype { get{ return _conquer_subtype; }}
        public string SubtypeDescribe { get{ return HanderDefine.SetStingCallBack(_subtype_describe); }}
        public string TapeName { get{ return HanderDefine.SetStingCallBack(_tape_name); }}
        public int TaskGrade { get{ return _task_grade; }}
        public int TaskWeight { get{ return _task_weight; }}
        public int TaskIcon { get{ return _task_icon; }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public string ContentDescribe { get{ return HanderDefine.SetStingCallBack(_content_describe); }}
        public int ConditionsNpc { get{ return _conditions_npc; }}
        public int TaskTalkStart { get{ return _task_talk_start; }}
        public int OverNpc { get{ return _over_npc; }}
        public int TaskTalkOver { get{ return _task_talk_over; }}
        public int TaskType { get{ return _task_type; }}
        public string TaskXZ { get{ return HanderDefine.SetStingCallBack(_task_x_z); }}
        public string GoalNpc { get{ return HanderDefine.SetStingCallBack(_goal_npc); }}
        public int OpenNpcPanel { get{ return _open_npc_panel; }}
        public int PromptIcon { get{ return _prompt_icon; }}
        public string ShowNpc { get{ return HanderDefine.SetStingCallBack(_show_npc); }}
        public string ShowMonster { get{ return HanderDefine.SetStingCallBack(_show_monster); }}
        public string ShowGather { get{ return HanderDefine.SetStingCallBack(_show_gather); }}
        public int AutoCommit { get{ return _auto_commit; }}
        public string OverCurrency { get{ return HanderDefine.SetStingCallBack(_over_currency); }}
        public string DoubleCurrency { get{ return HanderDefine.SetStingCallBack(_double_currency); }}
        public string Rewards { get{ return HanderDefine.SetStingCallBack(_rewards); }}
        public string Assistrewards { get{ return HanderDefine.SetStingCallBack(_assistrewards); }}
        public int Clonemap { get{ return _clonemap; }}
        public int GuildSupport { get{ return _guildSupport; }}
        public string PlanesShowEnter { get{ return HanderDefine.SetStingCallBack(_planes_show_enter); }}
        public int IsSyncPos { get{ return _isSyncPos; }}
        public int Recieve { get{ return _recieve; }}
        public int TargetType { get{ return _target_type; }}
        public int OverTaskFunction { get{ return _overTaskFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTaskConquer cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTaskConquer> _dataCaches = null;
        public static Dictionary<int, DeclareTaskConquer> CacheData
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
                        if (HanderDefine.DataCallBack("TaskConquer", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTaskConquer cfg = null;
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
        private unsafe static DeclareTaskConquer LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTaskConquer();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._task_name = (int)GetValue(keyIndex, _task_name_Index, ptr);
            tmp._conquer_subtype = (int)GetValue(keyIndex, _conquer_subtype_Index, ptr);
            tmp._subtype_describe = (int)GetValue(keyIndex, _subtype_describe_Index, ptr);
            tmp._tape_name = (int)GetValue(keyIndex, _tape_name_Index, ptr);
            tmp._task_grade = (int)GetValue(keyIndex, _task_grade_Index, ptr);
            tmp._task_weight = (int)GetValue(keyIndex, _task_weight_Index, ptr);
            tmp._task_icon = (int)GetValue(keyIndex, _task_icon_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._content_describe = (int)GetValue(keyIndex, _content_describe_Index, ptr);
            tmp._conditions_npc = (int)GetValue(keyIndex, _conditions_npc_Index, ptr);
            tmp._task_talk_start = (int)GetValue(keyIndex, _task_talk_start_Index, ptr);
            tmp._over_npc = (int)GetValue(keyIndex, _over_npc_Index, ptr);
            tmp._task_talk_over = (int)GetValue(keyIndex, _task_talk_over_Index, ptr);
            tmp._task_type = (int)GetValue(keyIndex, _task_type_Index, ptr);
            tmp._task_x_z = (int)GetValue(keyIndex, _task_x_z_Index, ptr);
            tmp._goal_npc = (int)GetValue(keyIndex, _goal_npc_Index, ptr);
            tmp._open_npc_panel = (int)GetValue(keyIndex, _open_npc_panel_Index, ptr);
            tmp._prompt_icon = (int)GetValue(keyIndex, _prompt_icon_Index, ptr);
            tmp._show_npc = (int)GetValue(keyIndex, _show_npc_Index, ptr);
            tmp._show_monster = (int)GetValue(keyIndex, _show_monster_Index, ptr);
            tmp._show_gather = (int)GetValue(keyIndex, _show_gather_Index, ptr);
            tmp._auto_commit = (int)GetValue(keyIndex, _auto_commit_Index, ptr);
            tmp._over_currency = (int)GetValue(keyIndex, _over_currency_Index, ptr);
            tmp._double_currency = (int)GetValue(keyIndex, _double_currency_Index, ptr);
            tmp._rewards = (int)GetValue(keyIndex, _rewards_Index, ptr);
            tmp._assistrewards = (int)GetValue(keyIndex, _assistrewards_Index, ptr);
            tmp._clonemap = (int)GetValue(keyIndex, _clonemap_Index, ptr);
            tmp._guildSupport = (int)GetValue(keyIndex, _guildSupport_Index, ptr);
            tmp._planes_show_enter = (int)GetValue(keyIndex, _planes_show_enter_Index, ptr);
            tmp._isSyncPos = (int)GetValue(keyIndex, _isSyncPos_Index, ptr);
            tmp._recieve = (int)GetValue(keyIndex, _recieve_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("TaskConquer", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskName", out _task_name_Index)) _task_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ConquerSubtype", out _conquer_subtype_Index)) _conquer_subtype_Index = -1;
                    if (!nameIndexs.TryGetValue("SubtypeDescribe", out _subtype_describe_Index)) _subtype_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("TapeName", out _tape_name_Index)) _tape_name_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskGrade", out _task_grade_Index)) _task_grade_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskWeight", out _task_weight_Index)) _task_weight_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskIcon", out _task_icon_Index)) _task_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ContentDescribe", out _content_describe_Index)) _content_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsNpc", out _conditions_npc_Index)) _conditions_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkStart", out _task_talk_start_Index)) _task_talk_start_Index = -1;
                    if (!nameIndexs.TryGetValue("OverNpc", out _over_npc_Index)) _over_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkOver", out _task_talk_over_Index)) _task_talk_over_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskType", out _task_type_Index)) _task_type_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskXZ", out _task_x_z_Index)) _task_x_z_Index = -1;
                    if (!nameIndexs.TryGetValue("GoalNpc", out _goal_npc_Index)) _goal_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenNpcPanel", out _open_npc_panel_Index)) _open_npc_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptIcon", out _prompt_icon_Index)) _prompt_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNpc", out _show_npc_Index)) _show_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMonster", out _show_monster_Index)) _show_monster_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGather", out _show_gather_Index)) _show_gather_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoCommit", out _auto_commit_Index)) _auto_commit_Index = -1;
                    if (!nameIndexs.TryGetValue("OverCurrency", out _over_currency_Index)) _over_currency_Index = -1;
                    if (!nameIndexs.TryGetValue("DoubleCurrency", out _double_currency_Index)) _double_currency_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards", out _rewards_Index)) _rewards_Index = -1;
                    if (!nameIndexs.TryGetValue("Assistrewards", out _assistrewards_Index)) _assistrewards_Index = -1;
                    if (!nameIndexs.TryGetValue("Clonemap", out _clonemap_Index)) _clonemap_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildSupport", out _guildSupport_Index)) _guildSupport_Index = -1;
                    if (!nameIndexs.TryGetValue("PlanesShowEnter", out _planes_show_enter_Index)) _planes_show_enter_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSyncPos", out _isSyncPos_Index)) _isSyncPos_Index = -1;
                    if (!nameIndexs.TryGetValue("Recieve", out _recieve_Index)) _recieve_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTaskConquer>(keyCount);
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
            if(HanderDefine.DataCallBack("TaskConquer", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTaskConquer cfg = null;
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
        public static DeclareTaskConquer Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTaskConquer result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TaskConquer", out _compressData))
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
