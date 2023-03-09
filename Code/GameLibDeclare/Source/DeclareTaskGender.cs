//文件是自动生成,请勿手动修改.来自数据文件:task_gender
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTaskGender
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _gender_Index = -1;
        private static int _tape_name_Index = -1;
        private static int _genderClass_Index = -1;
        private static int _level_Index = -1;
        private static int _sequence_Index = -1;
        private static int _chapterprogr_Index = -1;
        private static int _chapter_name_Index = -1;
        private static int _chapter_desc_Index = -1;
        private static int _task_name_Index = -1;
        private static int _taksdesc_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _task_talk_start_Index = -1;
        private static int _task_talk_end_Index = -1;
        private static int _conditions_npc_Index = -1;
        private static int _score_limit_Index = -1;
        private static int _task_type_Index = -1;
        private static int _trueDrop_Index = -1;
        private static int _task_x_z_Index = -1;
        private static int _goal_npc_Index = -1;
        private static int _show_npc_Index = -1;
        private static int _show_monster_Index = -1;
        private static int _show_gather_Index = -1;
        private static int _openUI_Index = -1;
        private static int _back_group_id_Index = -1;
        private static int _pathMap_Index = -1;
        private static int _endpath_Index = -1;
        private static int _post_task_id_Index = -1;
        private static int _auto_task_Index = -1;
        private static int _auto_commit_Index = -1;
        private static int _rewards_Index = -1;
        private static int _target_type_Index = -1;
        private static int _skipCost_Index = -1;
        private static int _canSkip_Index = -1;
        private static int _skipPrompt_Index = -1;
        private static int _planes_show_enter_Index = -1;
        private static int _isSyncPos_Index = -1;
        #endregion
        #region //私有变量定义
        //任务ID
        private int _id;
        //职业限制（0-玄剑1-天英9-通用）
        private int _gender;
        //任务标题名称hide
        private int _tape_name;
        //领取任务所需洗髓阶数
        private int _genderClass;
        //任务开放等级
        private int _level;
        //任务顺序
        private int _sequence;
        //章节进度hide
        private int _chapterprogr;
        //章节名称hide
        private int _chapter_name;
        //章节描述hide
        private int _chapter_desc;
        //任务名称
        private int _task_name;
        //主面板任务描述hide
        private int _taksdesc;
        //任务目标描述
        private int _conditions_describe;
        //NPC接任务对白接
        private int _task_talk_start;
        //NPC交任务对白接
        private int _task_talk_end;
        //领取任务的NPC
        private int _conditions_npc;
        //进行的战力限制
        private int _score_limit;
        //任务类型（0NPC对话 1地图杀怪 2采集(不进背包） 3使用道具 4提交道具 5护送 6功能操作 7卡等级 8副本通关 9到达指定坐标 10收集道具（不进背包） 11收集道具（进背包） 12位面杀怪 13完成X个境界任务 14境界到达XX）
        private int _task_type;
        //是否为真掉落（0否1是）
        private int _trueDrop;
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
        //打开界面ID(hide)
        private int _openUI;
        //面板参数(hide)
        private int _back_group_id;
        //任务寻径地图ID
        private int _pathMap;
        //提交路径(地图id;ncpID)(@_@)
        private int _endpath;
        //完成后接取任务ID
        private int _post_task_id;
        //是否自动任务，NPC对话后下一个任务需要自动
        private int _auto_task;
        //自动提交的任务
        //0.服务器自动完成
        //1.左边任务面板点击提交
        private int _auto_commit;
        //任务奖励(奖励_数量;奖励_数量）[@;@_@]
        private int _rewards;
        //目标系统的分类：（0，境界剑灵；1，装备养成；2，角色成长；3，骑宠造化；4，其他；-999.不进）hide
        private int _target_type;
        //跳过消耗
        private int _skipCost;
        //是否可以跳过（0否1是）
        private int _canSkip;
        //是否提示跳过（0否1是）
        private int _skipPrompt;
        //当为位面时，进位面的表现效果
        //0表示：无效果直接切
        //具体参数表示进入退出效果
        private int _planes_show_enter;
        //任务位面是否同步位置
        //（0表示不同步，默认为0，1表示同步）
        private int _isSyncPos;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Gender { get{ return _gender; }}
        public string TapeName { get{ return HanderDefine.SetStingCallBack(_tape_name); }}
        public int GenderClass { get{ return _genderClass; }}
        public int Level { get{ return _level; }}
        public int Sequence { get{ return _sequence; }}
        public string Chapterprogr { get{ return HanderDefine.SetStingCallBack(_chapterprogr); }}
        public string ChapterName { get{ return HanderDefine.SetStingCallBack(_chapter_name); }}
        public string ChapterDesc { get{ return HanderDefine.SetStingCallBack(_chapter_desc); }}
        public string TaskName { get{ return HanderDefine.SetStingCallBack(_task_name); }}
        public string Taksdesc { get{ return HanderDefine.SetStingCallBack(_taksdesc); }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public int TaskTalkStart { get{ return _task_talk_start; }}
        public int TaskTalkEnd { get{ return _task_talk_end; }}
        public int ConditionsNpc { get{ return _conditions_npc; }}
        public int ScoreLimit { get{ return _score_limit; }}
        public int TaskType { get{ return _task_type; }}
        public int TrueDrop { get{ return _trueDrop; }}
        public string TaskXZ { get{ return HanderDefine.SetStingCallBack(_task_x_z); }}
        public string GoalNpc { get{ return HanderDefine.SetStingCallBack(_goal_npc); }}
        public string ShowNpc { get{ return HanderDefine.SetStingCallBack(_show_npc); }}
        public string ShowMonster { get{ return HanderDefine.SetStingCallBack(_show_monster); }}
        public string ShowGather { get{ return HanderDefine.SetStingCallBack(_show_gather); }}
        public int OpenUI { get{ return _openUI; }}
        public int BackGroupId { get{ return _back_group_id; }}
        public int PathMap { get{ return _pathMap; }}
        public string Endpath { get{ return HanderDefine.SetStingCallBack(_endpath); }}
        public int PostTaskId { get{ return _post_task_id; }}
        public int AutoTask { get{ return _auto_task; }}
        public int AutoCommit { get{ return _auto_commit; }}
        public string Rewards { get{ return HanderDefine.SetStingCallBack(_rewards); }}
        public int TargetType { get{ return _target_type; }}
        public int SkipCost { get{ return _skipCost; }}
        public int CanSkip { get{ return _canSkip; }}
        public int SkipPrompt { get{ return _skipPrompt; }}
        public string PlanesShowEnter { get{ return HanderDefine.SetStingCallBack(_planes_show_enter); }}
        public int IsSyncPos { get{ return _isSyncPos; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTaskGender cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTaskGender> _dataCaches = null;
        public static Dictionary<int, DeclareTaskGender> CacheData
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
                        if (HanderDefine.DataCallBack("TaskGender", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTaskGender cfg = null;
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
        private unsafe static DeclareTaskGender LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTaskGender();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._gender = (int)GetValue(keyIndex, _gender_Index, ptr);
            tmp._tape_name = (int)GetValue(keyIndex, _tape_name_Index, ptr);
            tmp._genderClass = (int)GetValue(keyIndex, _genderClass_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._sequence = (int)GetValue(keyIndex, _sequence_Index, ptr);
            tmp._chapterprogr = (int)GetValue(keyIndex, _chapterprogr_Index, ptr);
            tmp._chapter_name = (int)GetValue(keyIndex, _chapter_name_Index, ptr);
            tmp._chapter_desc = (int)GetValue(keyIndex, _chapter_desc_Index, ptr);
            tmp._task_name = (int)GetValue(keyIndex, _task_name_Index, ptr);
            tmp._taksdesc = (int)GetValue(keyIndex, _taksdesc_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._task_talk_start = (int)GetValue(keyIndex, _task_talk_start_Index, ptr);
            tmp._task_talk_end = (int)GetValue(keyIndex, _task_talk_end_Index, ptr);
            tmp._conditions_npc = (int)GetValue(keyIndex, _conditions_npc_Index, ptr);
            tmp._score_limit = (int)GetValue(keyIndex, _score_limit_Index, ptr);
            tmp._task_type = (int)GetValue(keyIndex, _task_type_Index, ptr);
            tmp._trueDrop = (int)GetValue(keyIndex, _trueDrop_Index, ptr);
            tmp._task_x_z = (int)GetValue(keyIndex, _task_x_z_Index, ptr);
            tmp._goal_npc = (int)GetValue(keyIndex, _goal_npc_Index, ptr);
            tmp._show_npc = (int)GetValue(keyIndex, _show_npc_Index, ptr);
            tmp._show_monster = (int)GetValue(keyIndex, _show_monster_Index, ptr);
            tmp._show_gather = (int)GetValue(keyIndex, _show_gather_Index, ptr);
            tmp._openUI = (int)GetValue(keyIndex, _openUI_Index, ptr);
            tmp._back_group_id = (int)GetValue(keyIndex, _back_group_id_Index, ptr);
            tmp._pathMap = (int)GetValue(keyIndex, _pathMap_Index, ptr);
            tmp._endpath = (int)GetValue(keyIndex, _endpath_Index, ptr);
            tmp._post_task_id = (int)GetValue(keyIndex, _post_task_id_Index, ptr);
            tmp._auto_task = (int)GetValue(keyIndex, _auto_task_Index, ptr);
            tmp._auto_commit = (int)GetValue(keyIndex, _auto_commit_Index, ptr);
            tmp._rewards = (int)GetValue(keyIndex, _rewards_Index, ptr);
            tmp._target_type = (int)GetValue(keyIndex, _target_type_Index, ptr);
            tmp._skipCost = (int)GetValue(keyIndex, _skipCost_Index, ptr);
            tmp._canSkip = (int)GetValue(keyIndex, _canSkip_Index, ptr);
            tmp._skipPrompt = (int)GetValue(keyIndex, _skipPrompt_Index, ptr);
            tmp._planes_show_enter = (int)GetValue(keyIndex, _planes_show_enter_Index, ptr);
            tmp._isSyncPos = (int)GetValue(keyIndex, _isSyncPos_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TaskGender", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Gender", out _gender_Index)) _gender_Index = -1;
                    if (!nameIndexs.TryGetValue("TapeName", out _tape_name_Index)) _tape_name_Index = -1;
                    if (!nameIndexs.TryGetValue("GenderClass", out _genderClass_Index)) _genderClass_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Sequence", out _sequence_Index)) _sequence_Index = -1;
                    if (!nameIndexs.TryGetValue("Chapterprogr", out _chapterprogr_Index)) _chapterprogr_Index = -1;
                    if (!nameIndexs.TryGetValue("ChapterName", out _chapter_name_Index)) _chapter_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ChapterDesc", out _chapter_desc_Index)) _chapter_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskName", out _task_name_Index)) _task_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Taksdesc", out _taksdesc_Index)) _taksdesc_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkStart", out _task_talk_start_Index)) _task_talk_start_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskTalkEnd", out _task_talk_end_Index)) _task_talk_end_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsNpc", out _conditions_npc_Index)) _conditions_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ScoreLimit", out _score_limit_Index)) _score_limit_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskType", out _task_type_Index)) _task_type_Index = -1;
                    if (!nameIndexs.TryGetValue("TrueDrop", out _trueDrop_Index)) _trueDrop_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskXZ", out _task_x_z_Index)) _task_x_z_Index = -1;
                    if (!nameIndexs.TryGetValue("GoalNpc", out _goal_npc_Index)) _goal_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNpc", out _show_npc_Index)) _show_npc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMonster", out _show_monster_Index)) _show_monster_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGather", out _show_gather_Index)) _show_gather_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenUI", out _openUI_Index)) _openUI_Index = -1;
                    if (!nameIndexs.TryGetValue("BackGroupId", out _back_group_id_Index)) _back_group_id_Index = -1;
                    if (!nameIndexs.TryGetValue("PathMap", out _pathMap_Index)) _pathMap_Index = -1;
                    if (!nameIndexs.TryGetValue("Endpath", out _endpath_Index)) _endpath_Index = -1;
                    if (!nameIndexs.TryGetValue("PostTaskId", out _post_task_id_Index)) _post_task_id_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoTask", out _auto_task_Index)) _auto_task_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoCommit", out _auto_commit_Index)) _auto_commit_Index = -1;
                    if (!nameIndexs.TryGetValue("Rewards", out _rewards_Index)) _rewards_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetType", out _target_type_Index)) _target_type_Index = -1;
                    if (!nameIndexs.TryGetValue("SkipCost", out _skipCost_Index)) _skipCost_Index = -1;
                    if (!nameIndexs.TryGetValue("CanSkip", out _canSkip_Index)) _canSkip_Index = -1;
                    if (!nameIndexs.TryGetValue("SkipPrompt", out _skipPrompt_Index)) _skipPrompt_Index = -1;
                    if (!nameIndexs.TryGetValue("PlanesShowEnter", out _planes_show_enter_Index)) _planes_show_enter_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSyncPos", out _isSyncPos_Index)) _isSyncPos_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTaskGender>(keyCount);
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
            if(HanderDefine.DataCallBack("TaskGender", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTaskGender cfg = null;
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
        public static DeclareTaskGender Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTaskGender result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TaskGender", out _compressData))
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
