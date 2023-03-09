//文件是自动生成,请勿手动修改.来自数据文件:task_daily
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTaskDaily
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _task_name_Index = -1;
        private static int _guide_type_Index = -1;
        private static int _daily_subtype_Index = -1;
        private static int _subtype_describe_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _conditions_npc_Index = -1;
        private static int _task_talk_start_Index = -1;
        private static int _conditions_map_Index = -1;
        private static int _over_npc_Index = -1;
        private static int _task_talk_over_Index = -1;
        private static int _task_type_Index = -1;
        private static int _npc_id_Index = -1;
        private static int _task_x_z_Index = -1;
        private static int _goal_npc_Index = -1;
        private static int _show_npc_Index = -1;
        private static int _show_monster_Index = -1;
        private static int _show_gather_Index = -1;
        private static int _open_panel_Index = -1;
        private static int _open_panel_param_Index = -1;
        private static int _daily_task_x_z_Index = -1;
        private static int _auto_commit_Index = -1;
        private static int _star_Index = -1;
        private static int _fillStarcost_Index = -1;
        private static int _if_over_Index = -1;
        private static int _over_currency_Index = -1;
        private static int _double_currency_Index = -1;
        private static int _rewards_0_Index = -1;
        private static int _rewards_1_Index = -1;
        private static int _rewards_2_Index = -1;
        private static int _rewards_3_Index = -1;
        private static int _rewards_4_Index = -1;
        private static int _rewards_5_Index = -1;
        private static int _typeName_Index = -1;
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
        //是否固定首发任务（0不是 1是）
        private int _guide_type;
        //日常任务子类型（0 经验日常；1 银币日常）
        private int _daily_subtype;
        //任务类型描述(hide)
        private int _subtype_describe;
        //任务目标描述
        private int _conditions_describe;
        //领取任务的NPC
        private int _conditions_npc;
        //领取任务对话
        private int _task_talk_start;
        //领取任务的NPC地图
        private int _conditions_map;
        //提交任务NPC
        private int _over_npc;
        //完成任务对话
        private int _task_talk_over;
        //任务类型（0NPC对话 1地图杀怪 2采集(不进背包） 3使用道具 4提交道具 5护送 6功能操作 7卡等级 8副本通关 9到达指定坐标 10收集道具（不进背包） 11收集道具（进背包） 12位面杀怪 13完成X个境界任务 14境界到达XX）
        private int _task_type;
        //对话的npc_id
        private int _npc_id;
        //坐标
        //用于位面，走到具体的坐标
        //(@_@)
        private int _task_x_z;
        //任务目标(任务模型/NPC_数量)(@_@)
        private int _goal_npc;
        //仅在任务显示NPC（@_@)
        private int _show_npc;
        //仅在任务显示怪物（@_@)
        private int _show_monster;
        //仅在任务显示采集物（@_@)
        private int _show_gather;
        //开启界面hide
        private int _open_panel;
        //参数
        private int _open_panel_param;
        //传送位置，x_z(@_@) daily_task_x_z
        private int _daily_task_x_z;
        //自动提交的任务
        //0.服务器自动完成
        //1.左边任务面板点击提交
        private int _auto_commit;
        //星级概率（0星概率_1星概率_2星概率_3星概率…..）(@_@) daily_task_x_z
        private int _star;
        //刷星消耗(@_@)
        private int _fillStarcost;
        //是否显示扫荡按钮（0显示 1不显示(默认为0)(hide)
        private int _if_over;
        //完成单次货币(完成任务货币类型_值)(@_@)
        private int _over_currency;
        //双倍奖励(双倍奖励货币类型_值)(@_@)
        private int _double_currency;
        //0星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_0;
        //1星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_1;
        //2星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_2;
        //3星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_3;
        //4星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_4;
        //5星任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards_5;
        //任务类型
        private int _typeName;
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
        public int GuideType { get{ return _guide_type; }}
        public int DailySubtype { get{ return _daily_subtype; }}
        public string SubtypeDescribe { get{ return HanderDefine.SetStingCallBack(_subtype_describe); }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public int ConditionsNpc { get{ return _conditions_npc; }}
        public int TaskTalkStart { get{ return _task_talk_start; }}
        public int ConditionsMap { get{ return _conditions_map; }}
        public int OverNpc { get{ return _over_npc; }}
        public int TaskTalkOver { get{ return _task_talk_over; }}
        public int TaskType { get{ return _task_type; }}
        public int NpcId { get{ return _npc_id; }}
        public string TaskXZ { get{ return HanderDefine.SetStingCallBack(_task_x_z); }}
        public string GoalNpc { get{ return HanderDefine.SetStingCallBack(_goal_npc); }}
        public string ShowNpc { get{ return HanderDefine.SetStingCallBack(_show_npc); }}
        public string ShowMonster { get{ return HanderDefine.SetStingCallBack(_show_monster); }}
        public string ShowGather { get{ return HanderDefine.SetStingCallBack(_show_gather); }}
        public int OpenPanel { get{ return _open_panel; }}
        public int OpenPanelParam { get{ return _open_panel_param; }}
        public string DailyTaskXZ { get{ return HanderDefine.SetStingCallBack(_daily_task_x_z); }}
        public int AutoCommit { get{ return _auto_commit; }}
        public string Star { get{ return HanderDefine.SetStingCallBack(_star); }}
        public string FillStarcost { get{ return HanderDefine.SetStingCallBack(_fillStarcost); }}
        public int IfOver { get{ return _if_over; }}
        public string OverCurrency { get{ return HanderDefine.SetStingCallBack(_over_currency); }}
        public string DoubleCurrency { get{ return HanderDefine.SetStingCallBack(_double_currency); }}
        public string Rewards0 { get{ return HanderDefine.SetStingCallBack(_rewards_0); }}
        public string Rewards1 { get{ return HanderDefine.SetStingCallBack(_rewards_1); }}
        public string Rewards2 { get{ return HanderDefine.SetStingCallBack(_rewards_2); }}
        public string Rewards3 { get{ return HanderDefine.SetStingCallBack(_rewards_3); }}
        public string Rewards4 { get{ return HanderDefine.SetStingCallBack(_rewards_4); }}
        public string Rewards5 { get{ return HanderDefine.SetStingCallBack(_rewards_5); }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_typeName); }}
        public string PlanesShowEnter { get{ return HanderDefine.SetStingCallBack(_planes_show_enter); }}
        public int IsSyncPos { get{ return _isSyncPos; }}
        public int Recieve { get{ return _recieve; }}
        public int TargetType { get{ return _target_type; }}
        public int OverTaskFunction { get{ return _overTaskFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTaskDaily cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTaskDaily> _dataCaches = null;
        public static Dictionary<int, DeclareTaskDaily> CacheData
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
                        if (HanderDefine.DataCallBack("TaskDaily", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTaskDaily cfg = null;
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
        private unsafe static DeclareTaskDaily LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTaskDaily();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._task_name = (int)GetValue(keyIndex, _task_name_Index, ptr);
            tmp._guide_type = (int)GetValue(keyIndex, _guide_type_Index, ptr);
            tmp._daily_subtype = (int)GetValue(keyIndex, _daily_subtype_Index, ptr);
            tmp._subtype_describe = (int)GetValue(keyIndex, _subtype_describe_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._conditions_npc = (int)GetValue(keyIndex, _conditions_npc_Index, ptr);
            tmp._task_talk_start = (int)GetValue(keyIndex, _task_talk_start_Index, ptr);
            tmp._conditions_map = (int)GetValue(keyIndex, _conditions_map_Index, ptr);
            tmp._over_npc = (int)GetValue(keyIndex, _over_npc_Index, ptr);
            tmp._task_talk_over = (int)GetValue(keyIndex, _task_talk_over_Index, ptr);
            tmp._task_type = (int)GetValue(keyIndex, _task_type_Index, ptr);
            tmp._npc_id = (int)GetValue(keyIndex, _npc_id_Index, ptr);
            tmp._task_x_z = (int)GetValue(keyIndex, _task_x_z_Index, ptr);
            tmp._goal_npc = (int)GetValue(keyIndex, _goal_npc_Index, ptr);
            tmp._show_npc = (int)GetValue(keyIndex, _show_npc_Index, ptr);
            tmp._show_monster = (int)GetValue(keyIndex, _show_monster_Index, ptr);
            tmp._show_gather = (int)GetValue(keyIndex, _show_gather_Index, ptr);
            tmp._open_panel = (int)GetValue(keyIndex, _open_panel_Index, ptr);
            tmp._open_panel_param = (int)GetValue(keyIndex, _open_panel_param_Index, ptr);
            tmp._daily_task_x_z = (int)GetValue(keyIndex, _daily_task_x_z_Index, ptr);
            tmp._auto_commit = (int)GetValue(keyIndex, _auto_commit_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            tmp._fillStarcost = (int)GetValue(keyIndex, _fillStarcost_Index, ptr);
            tmp._if_over = (int)GetValue(keyIndex, _if_over_Index, ptr);
            tmp._over_currency = (int)GetValue(keyIndex, _over_currency_Index, ptr);
            tmp._double_currency = (int)GetValue(keyIndex, _double_currency_Index, ptr);
            tmp._rewards_0 = (int)GetValue(keyIndex, _rewards_0_Index, ptr);
            tmp._rewards_1 = (int)GetValue(keyIndex, _rewards_1_Index, ptr);
            tmp._rewards_2 = (int)GetValue(keyIndex, _rewards_2_Index, ptr);
            tmp._rewards_3 = (int)GetValue(keyIndex, _rewards_3_Index, ptr);
            tmp._rewards_4 = (int)GetValue(keyIndex, _rewards_4_Index, ptr);
            tmp._rewards_5 = (int)GetValue(keyIndex, _rewards_5_Index, ptr);
            tmp._typeName = (int)GetValue(keyIndex, _typeName_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("TaskDaily", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskName", out _task_name_Index)) _task_name_Index = -1;
                    if (!nameIndexs.TryGetValue("GuideType", out _guide_type_Index)) _guide_type_Index = -1;
                    if (!nameIndexs.TryGetValue("DailySubtype", out _daily_subtype_Index)) _daily_subtype_Index = -1;
                    if (!nameIndexs.TryGetValue("SubtypeDescribe", out _subtype_describe_Index)) _subtype_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsNpc", out _conditions_npc_Index)) _conditions_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkStart", out _task_talk_start_Index)) _task_talk_start_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsMap", out _conditions_map_Index)) _conditions_map_Index = -1;
                    if (!nameIndexs.TryGetValue("OverNpc", out _over_npc_Index)) _over_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkOver", out _task_talk_over_Index)) _task_talk_over_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskType", out _task_type_Index)) _task_type_Index = -1;
                    if (!nameIndexs.TryGetValue("NpcId", out _npc_id_Index)) _npc_id_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskXZ", out _task_x_z_Index)) _task_x_z_Index = -1;
                    if (!nameIndexs.TryGetValue("GoalNpc", out _goal_npc_Index)) _goal_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNpc", out _show_npc_Index)) _show_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMonster", out _show_monster_Index)) _show_monster_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGather", out _show_gather_Index)) _show_gather_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanel", out _open_panel_Index)) _open_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanelParam", out _open_panel_param_Index)) _open_panel_param_Index = -1;
                    if (!nameIndexs.TryGetValue("DailyTaskXZ", out _daily_task_x_z_Index)) _daily_task_x_z_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoCommit", out _auto_commit_Index)) _auto_commit_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
                    if (!nameIndexs.TryGetValue("FillStarcost", out _fillStarcost_Index)) _fillStarcost_Index = -1;
                    if (!nameIndexs.TryGetValue("IfOver", out _if_over_Index)) _if_over_Index = -1;
                    if (!nameIndexs.TryGetValue("OverCurrency", out _over_currency_Index)) _over_currency_Index = -1;
                    if (!nameIndexs.TryGetValue("DoubleCurrency", out _double_currency_Index)) _double_currency_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards0", out _rewards_0_Index)) _rewards_0_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards1", out _rewards_1_Index)) _rewards_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards2", out _rewards_2_Index)) _rewards_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards3", out _rewards_3_Index)) _rewards_3_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards4", out _rewards_4_Index)) _rewards_4_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards5", out _rewards_5_Index)) _rewards_5_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _typeName_Index)) _typeName_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTaskDaily>(keyCount);
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
            if(HanderDefine.DataCallBack("TaskDaily", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTaskDaily cfg = null;
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
        public static DeclareTaskDaily Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTaskDaily result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TaskDaily", out _compressData))
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
