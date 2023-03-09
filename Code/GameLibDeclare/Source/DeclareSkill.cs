//文件是自动生成,请勿手动修改.来自数据文件:skill
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSkill
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _cell_id_Index = -1;
        private static int _icon_Index = -1;
        private static int _can_use_select_Index = -1;
        private static int _visualDef_Index = -1;
        private static int _server_sync_type_Index = -1;
        private static int _type_Index = -1;
        private static int _params_Index = -1;
        private static int _params_pre_att_Index = -1;
        private static int _desc_Index = -1;
        private static int _user_type_Index = -1;
        private static int _cd_Index = -1;
        private static int _public_cd_Index = -1;
        private static int _use_public_cd_Index = -1;
        private static int _need_player_level_Index = -1;
        private static int _element_type_Index = -1;
        private static int _level_Index = -1;
        private static int _prompt_text_Index = -1;
        private static int _prompt_delay_Index = -1;
        private static int _prompt_life_time_Index = -1;
        private static int _damageBase_Index = -1;
        private static int _damageUp_Index = -1;
        private static int _xp_skill_damage_Index = -1;
        #endregion
        #region //私有变量定义
        //技能ID
        private int _id;
        //技能名称hide
        private int _name;
        //技能分支ID
        private int _cell_id;
        //技能图标编号,任务技能图标使用的是skillicon的图集
        private int _icon;
        //是否可以使用时选择范围或者方向（hide）
        private int _can_use_select;
        //技能可视化数据
        private int _visualDef;
        //和服务器的同步类型（0客户端先表现；1等服务器返回了再表现）
        private int _server_sync_type;
        //0主动、 1被动、2特杀
        private int _type;
        //技能额外参数(0_怪物特杀类型_增伤万分比,1_属性_值;2_技能id_属性) 0是特杀1属性加成，2是技能加成(@;@_@)
        private int _params;
        //增加百分比属性(属性ID_数值）(@;@_@)
        private int _params_pre_att;
        //技能介绍hide
        private int _desc;
        //使用者（0-4，职业1,2,3,4,5技能；10：无限制；11怪物技能；12：宠物技能；13：婚姻技能；14：法宝技能
        private int _user_type;
        //冷却时间（单位毫秒）
        private int _cd;
        //公共CD（单位毫秒）
        private int _public_cd;
        //是否使用公CD（0不使用，1使用）
        private int _use_public_cd;
        //需求人物等级
        private int _need_player_level;
        //技能大类型
        private int _element_type;
        //技能的等级（初中高）
        private int _level;
        //技能提示文字，在使用技能时进行提示，只针对怪物有效hide
        private int _prompt_text;
        //技能提示文字延迟多久展示，单位毫秒hide
        private int _prompt_delay;
        //技能提示文字生存时间，单位毫秒hide
        private int _prompt_life_time;
        //伤害基础值
        private int _damageBase;
        //伤害提升值
        private int _damageUp;
        //XP技能对于时长怪的伤害放大系数
        private int _xp_skill_damage;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int CellId { get{ return _cell_id; }}
        public int Icon { get{ return _icon; }}
        public int CanUseSelect { get{ return _can_use_select; }}
        public string VisualDef { get{ return HanderDefine.SetStingCallBack(_visualDef); }}
        public int ServerSyncType { get{ return _server_sync_type; }}
        public int Type { get{ return _type; }}
        public string Params { get{ return HanderDefine.SetStingCallBack(_params); }}
        public string ParamsPreAtt { get{ return HanderDefine.SetStingCallBack(_params_pre_att); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int UserType { get{ return _user_type; }}
        public int Cd { get{ return _cd; }}
        public int PublicCd { get{ return _public_cd; }}
        public int UsePublicCd { get{ return _use_public_cd; }}
        public int NeedPlayerLevel { get{ return _need_player_level; }}
        public int ElementType { get{ return _element_type; }}
        public int Level { get{ return _level; }}
        public string PromptText { get{ return HanderDefine.SetStingCallBack(_prompt_text); }}
        public int PromptDelay { get{ return _prompt_delay; }}
        public int PromptLifeTime { get{ return _prompt_life_time; }}
        public int DamageBase { get{ return _damageBase; }}
        public int DamageUp { get{ return _damageUp; }}
        public int XpSkillDamage { get{ return _xp_skill_damage; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSkill cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSkill> _dataCaches = null;
        public static Dictionary<int, DeclareSkill> CacheData
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
                        if (HanderDefine.DataCallBack("Skill", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSkill cfg = null;
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
        private unsafe static DeclareSkill LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSkill();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._cell_id = (int)GetValue(keyIndex, _cell_id_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._can_use_select = (int)GetValue(keyIndex, _can_use_select_Index, ptr);
            tmp._visualDef = (int)GetValue(keyIndex, _visualDef_Index, ptr);
            tmp._server_sync_type = (int)GetValue(keyIndex, _server_sync_type_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._params = (int)GetValue(keyIndex, _params_Index, ptr);
            tmp._params_pre_att = (int)GetValue(keyIndex, _params_pre_att_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._user_type = (int)GetValue(keyIndex, _user_type_Index, ptr);
            tmp._cd = (int)GetValue(keyIndex, _cd_Index, ptr);
            tmp._public_cd = (int)GetValue(keyIndex, _public_cd_Index, ptr);
            tmp._use_public_cd = (int)GetValue(keyIndex, _use_public_cd_Index, ptr);
            tmp._need_player_level = (int)GetValue(keyIndex, _need_player_level_Index, ptr);
            tmp._element_type = (int)GetValue(keyIndex, _element_type_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._prompt_text = (int)GetValue(keyIndex, _prompt_text_Index, ptr);
            tmp._prompt_delay = (int)GetValue(keyIndex, _prompt_delay_Index, ptr);
            tmp._prompt_life_time = (int)GetValue(keyIndex, _prompt_life_time_Index, ptr);
            tmp._damageBase = (int)GetValue(keyIndex, _damageBase_Index, ptr);
            tmp._damageUp = (int)GetValue(keyIndex, _damageUp_Index, ptr);
            tmp._xp_skill_damage = (int)GetValue(keyIndex, _xp_skill_damage_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Skill", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("CellId", out _cell_id_Index)) _cell_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("CanUseSelect", out _can_use_select_Index)) _can_use_select_Index = -1;
                    if (!nameIndexs.TryGetValue("VisualDef", out _visualDef_Index)) _visualDef_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerSyncType", out _server_sync_type_Index)) _server_sync_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Params", out _params_Index)) _params_Index = -1;
                    if (!nameIndexs.TryGetValue("ParamsPreAtt", out _params_pre_att_Index)) _params_pre_att_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("UserType", out _user_type_Index)) _user_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Cd", out _cd_Index)) _cd_Index = -1;
                    if (!nameIndexs.TryGetValue("PublicCd", out _public_cd_Index)) _public_cd_Index = -1;
                    if (!nameIndexs.TryGetValue("UsePublicCd", out _use_public_cd_Index)) _use_public_cd_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedPlayerLevel", out _need_player_level_Index)) _need_player_level_Index = -1;
                    if (!nameIndexs.TryGetValue("ElementType", out _element_type_Index)) _element_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptText", out _prompt_text_Index)) _prompt_text_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptDelay", out _prompt_delay_Index)) _prompt_delay_Index = -1;
                    if (!nameIndexs.TryGetValue("PromptLifeTime", out _prompt_life_time_Index)) _prompt_life_time_Index = -1;
                    if (!nameIndexs.TryGetValue("DamageBase", out _damageBase_Index)) _damageBase_Index = -1;
                    if (!nameIndexs.TryGetValue("DamageUp", out _damageUp_Index)) _damageUp_Index = -1;
                    if (!nameIndexs.TryGetValue("XpSkillDamage", out _xp_skill_damage_Index)) _xp_skill_damage_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSkill>(keyCount);
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
            if(HanderDefine.DataCallBack("Skill", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSkill cfg = null;
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
        public static DeclareSkill Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSkill result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Skill", out _compressData))
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
