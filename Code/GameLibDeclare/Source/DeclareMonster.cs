//文件是自动生成,请勿手动修改.来自数据文件:monster
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMonster
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _title_Index = -1;
        private static int _dialog_Index = -1;
        private static int _camp_Index = -1;
        private static int _monster_type_Index = -1;
        private static int _attack_type_Index = -1;
        private static int _playerModel_Index = -1;
        private static int _playerModelRes_Index = -1;
        private static int _res_Index = -1;
        private static int _size_scale_Index = -1;
        private static int _strike_distance_Index = -1;
        private static int _icon_Index = -1;
        private static int _die_soundid_Index = -1;
        private static int _level_Index = -1;
        private static int _state_level_Index = -1;
        private static int _score_Index = -1;
        private static int _maxHp_Index = -1;
        private static int _beHurtType_Index = -1;
        private static int _beHurtValue_Index = -1;
        private static int _use_smooth_damage_Index = -1;
        private static int _armor_Index = -1;
        private static int _armor_if_Index = -1;
        private static int _exp_Index = -1;
        private static int _blood_Index = -1;
        private static int _hP_num_Index = -1;
        private static int _taskShow_Index = -1;
        private static int _task_cinematic_Index = -1;
        private static int _dead_hit_fly_Index = -1;
        private static int _brithProtect_Index = -1;
        private static int _brithFowardPlayer_Index = -1;
        private static int _brithVfx_Index = -1;
        private static int _birth_speech_Index = -1;
        private static int _dead_speech_Index = -1;
        private static int _dead_feature_Index = -1;
        private static int _hit_fly_percent_Index = -1;
        private static int _hit_shake_power_Index = -1;
        private static int _can_be_select_Index = -1;
        private static int _monster_hp_change_Index = -1;
        private static int _is_lock_dir_Index = -1;
        private static int _lock_dir_Index = -1;
        private static int _show_drop_type_Index = -1;
        private static int _magic_bowl_reward_Index = -1;
        #endregion
        #region //私有变量定义
        //怪物id
        private int _id;
        //怪物名
        private int _name;
        //怪物称号hide
        private int _title;
        //怪物气泡对白
        private int _dialog;
        //阵营(0玩家 3怪物)
        private int _camp;
        //怪物类型(1普通小怪,2精英,3BOSS
        private int _monster_type;
        //怪物攻击模式（0不反击，1主动，2被动）
        private int _attack_type;
        //是否使用玩家模型(0不使用，1使用)
        private int _playerModel;
        //身体ID_武器head_武器Body_武器特效_翅膀ID
        private int _playerModelRes;
        //资源
        private int _res;
        //模型缩放（百分比）
        private int _size_scale;
        //受击半径（厘米）
        private int _strike_distance;
        //头像
        private int _icon;
        //死亡时音效编号
        private int _die_soundid;
        //等级_x000D_
        //-1表示显示玩家等级_x000D_
        //0表示为世界等级_x000D_
        //>0表示具体的等级
        private int _level;
        //怪物境界等级，用于威压
        private int _state_level;
        //怪物战斗力（用于判断是否进行战斗力的压制，空或零都不进行战斗力压制）
        private int _score;
        //血量
        private Int64 _maxHp;
        //0：走常规流程；
        //1：固定伤害，用hurtValue字段，显示固定值；
        //2：固定伤害，用hurtValue字段，显示属性计算造成的值
        //3：受伤固定掉血：被攻击则每秒掉血，不受攻击则不每秒掉血，用hurtValue字段，显示属性计算造成的值
        //4：时间固定掉血：出生后无论被攻击否都每秒掉血，用hurtValue字段，显示属性计算造成的值
        //5：单位时间内的掉血上限(时间填写在global) 实列:当beHurtType 字段填写5时,beHurtValue填写的数值为单位时间内的掉血上限
        private int _beHurtType;
        //固定伤害的具体值
        private int _beHurtValue;
        //使用假掉血（hide）
        private int _use_smooth_damage;
        //护甲量
        private int _armor;
        //护甲是否会掉（0，会掉；1,不会掉）
        private int _armor_if;
        //掉落经验
        private int _exp;
        //掉落的血之精魄
        private int _blood;
        //boss血条数量hide
        private int _hP_num;
        //怪物隐藏（用于任务,任务类型_任务ID;任务类型_任务ID）(@;@_@)
        private int _taskShow;
        //任务剧情，在主角有指定的任务并且靠近怪物时播放动画，任务ID_剧情ID(hide)
        private int _task_cinematic;
        //是否能够被死亡击飞（0不能，1能）（hide）
        private int _dead_hit_fly;
        //出生时间(毫秒)
        private int _brithProtect;
        //出生是否朝向玩家
        private int _brithFowardPlayer;
        //出生特效 other目录下（hide）
        private int _brithVfx;
        //出生语音(不带路径和后缀)hide
        private int _birth_speech;
        //死亡语音(不带路径和后缀)hide
        private int _dead_speech;
        //是否进行死亡特写，0不特写，1特写（hide）
        private int _dead_feature;
        //被击飞效果的百分比（0-100）（hide）
        private int _hit_fly_percent;
        //震动力度百分比（hide）
        private int _hit_shake_power;
        //是否能够被选中
        private int _can_be_select;
        //固定伤害中，自动掉血调用的系数
        private int _monster_hp_change;
        //锁定方向，为0表示怪物可以转向，为1表示怪物不能转向（hide）
        private int _is_lock_dir;
        //锁定的旋转值(hide)
        private int _lock_dir;
        ////0不显示头顶，boss血条不显示掉落归属
        ////1不显示头顶，boss血条显示参与攻击
        ////2第一名显示 额外掉落，boss血条显示玩家名字
        ////3前三显示 掉落归属，伤害前三
        ////4第一名显示 掉落归属，boss血条显示玩家名字(hide)
        private int _show_drop_type;
        //聚宝盆奖励（击杀后给与所有参加攻击的玩家给与的奖励数量）废弃
        //itemID_num
        private int _magic_bowl_reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Title { get{ return HanderDefine.SetStingCallBack(_title); }}
        public string Dialog { get{ return HanderDefine.SetStingCallBack(_dialog); }}
        public int Camp { get{ return _camp; }}
        public int MonsterType { get{ return _monster_type; }}
        public int AttackType { get{ return _attack_type; }}
        public int PlayerModel { get{ return _playerModel; }}
        public string PlayerModelRes { get{ return HanderDefine.SetStingCallBack(_playerModelRes); }}
        public int Res { get{ return _res; }}
        public int SizeScale { get{ return _size_scale; }}
        public int StrikeDistance { get{ return _strike_distance; }}
        public int Icon { get{ return _icon; }}
        public int DieSoundid { get{ return _die_soundid; }}
        public int Level { get{ return _level; }}
        public int StateLevel { get{ return _state_level; }}
        public int Score { get{ return _score; }}
        public Int64 MaxHp { get{ return _maxHp; }}
        public int BeHurtType { get{ return _beHurtType; }}
        public int BeHurtValue { get{ return _beHurtValue; }}
        public int UseSmoothDamage { get{ return _use_smooth_damage; }}
        public int Armor { get{ return _armor; }}
        public int ArmorIf { get{ return _armor_if; }}
        public int Exp { get{ return _exp; }}
        public int Blood { get{ return _blood; }}
        public int HPNum { get{ return _hP_num; }}
        public string TaskShow { get{ return HanderDefine.SetStingCallBack(_taskShow); }}
        public string TaskCinematic { get{ return HanderDefine.SetStingCallBack(_task_cinematic); }}
        public int DeadHitFly { get{ return _dead_hit_fly; }}
        public int BrithProtect { get{ return _brithProtect; }}
        public int BrithFowardPlayer { get{ return _brithFowardPlayer; }}
        public int BrithVfx { get{ return _brithVfx; }}
        public string BirthSpeech { get{ return HanderDefine.SetStingCallBack(_birth_speech); }}
        public string DeadSpeech { get{ return HanderDefine.SetStingCallBack(_dead_speech); }}
        public int DeadFeature { get{ return _dead_feature; }}
        public int HitFlyPercent { get{ return _hit_fly_percent; }}
        public int HitShakePower { get{ return _hit_shake_power; }}
        public int CanBeSelect { get{ return _can_be_select; }}
        public int MonsterHpChange { get{ return _monster_hp_change; }}
        public int IsLockDir { get{ return _is_lock_dir; }}
        public int LockDir { get{ return _lock_dir; }}
        public int ShowDropType { get{ return _show_drop_type; }}
        public int MagicBowlReward { get{ return _magic_bowl_reward; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMonster cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMonster> _dataCaches = null;
        public static Dictionary<int, DeclareMonster> CacheData
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
                        if (HanderDefine.DataCallBack("Monster", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMonster cfg = null;
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
        private unsafe static DeclareMonster LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMonster();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._title = (int)GetValue(keyIndex, _title_Index, ptr);
            tmp._dialog = (int)GetValue(keyIndex, _dialog_Index, ptr);
            tmp._camp = (int)GetValue(keyIndex, _camp_Index, ptr);
            tmp._monster_type = (int)GetValue(keyIndex, _monster_type_Index, ptr);
            tmp._attack_type = (int)GetValue(keyIndex, _attack_type_Index, ptr);
            tmp._playerModel = (int)GetValue(keyIndex, _playerModel_Index, ptr);
            tmp._playerModelRes = (int)GetValue(keyIndex, _playerModelRes_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._size_scale = (int)GetValue(keyIndex, _size_scale_Index, ptr);
            tmp._strike_distance = (int)GetValue(keyIndex, _strike_distance_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._die_soundid = (int)GetValue(keyIndex, _die_soundid_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._state_level = (int)GetValue(keyIndex, _state_level_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._maxHp = GetValue(keyIndex, _maxHp_Index, ptr);
            tmp._beHurtType = (int)GetValue(keyIndex, _beHurtType_Index, ptr);
            tmp._beHurtValue = (int)GetValue(keyIndex, _beHurtValue_Index, ptr);
            tmp._use_smooth_damage = (int)GetValue(keyIndex, _use_smooth_damage_Index, ptr);
            tmp._armor = (int)GetValue(keyIndex, _armor_Index, ptr);
            tmp._armor_if = (int)GetValue(keyIndex, _armor_if_Index, ptr);
            tmp._exp = (int)GetValue(keyIndex, _exp_Index, ptr);
            tmp._blood = (int)GetValue(keyIndex, _blood_Index, ptr);
            tmp._hP_num = (int)GetValue(keyIndex, _hP_num_Index, ptr);
            tmp._taskShow = (int)GetValue(keyIndex, _taskShow_Index, ptr);
            tmp._task_cinematic = (int)GetValue(keyIndex, _task_cinematic_Index, ptr);
            tmp._dead_hit_fly = (int)GetValue(keyIndex, _dead_hit_fly_Index, ptr);
            tmp._brithProtect = (int)GetValue(keyIndex, _brithProtect_Index, ptr);
            tmp._brithFowardPlayer = (int)GetValue(keyIndex, _brithFowardPlayer_Index, ptr);
            tmp._brithVfx = (int)GetValue(keyIndex, _brithVfx_Index, ptr);
            tmp._birth_speech = (int)GetValue(keyIndex, _birth_speech_Index, ptr);
            tmp._dead_speech = (int)GetValue(keyIndex, _dead_speech_Index, ptr);
            tmp._dead_feature = (int)GetValue(keyIndex, _dead_feature_Index, ptr);
            tmp._hit_fly_percent = (int)GetValue(keyIndex, _hit_fly_percent_Index, ptr);
            tmp._hit_shake_power = (int)GetValue(keyIndex, _hit_shake_power_Index, ptr);
            tmp._can_be_select = (int)GetValue(keyIndex, _can_be_select_Index, ptr);
            tmp._monster_hp_change = (int)GetValue(keyIndex, _monster_hp_change_Index, ptr);
            tmp._is_lock_dir = (int)GetValue(keyIndex, _is_lock_dir_Index, ptr);
            tmp._lock_dir = (int)GetValue(keyIndex, _lock_dir_Index, ptr);
            tmp._show_drop_type = (int)GetValue(keyIndex, _show_drop_type_Index, ptr);
            tmp._magic_bowl_reward = (int)GetValue(keyIndex, _magic_bowl_reward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Monster", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Title", out _title_Index)) _title_Index = -1;
                    if (!nameIndexs.TryGetValue("Dialog", out _dialog_Index)) _dialog_Index = -1;
                    if (!nameIndexs.TryGetValue("Camp", out _camp_Index)) _camp_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterType", out _monster_type_Index)) _monster_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AttackType", out _attack_type_Index)) _attack_type_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayerModel", out _playerModel_Index)) _playerModel_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayerModelRes", out _playerModelRes_Index)) _playerModelRes_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("SizeScale", out _size_scale_Index)) _size_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("StrikeDistance", out _strike_distance_Index)) _strike_distance_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("DieSoundid", out _die_soundid_Index)) _die_soundid_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("StateLevel", out _state_level_Index)) _state_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxHp", out _maxHp_Index)) _maxHp_Index = -1;
                    if (!nameIndexs.TryGetValue("BeHurtType", out _beHurtType_Index)) _beHurtType_Index = -1;
                    if (!nameIndexs.TryGetValue("BeHurtValue", out _beHurtValue_Index)) _beHurtValue_Index = -1;
                    if (!nameIndexs.TryGetValue("UseSmoothDamage", out _use_smooth_damage_Index)) _use_smooth_damage_Index = -1;
                    if (!nameIndexs.TryGetValue("Armor", out _armor_Index)) _armor_Index = -1;
                    if (!nameIndexs.TryGetValue("ArmorIf", out _armor_if_Index)) _armor_if_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("Blood", out _blood_Index)) _blood_Index = -1;
                    if (!nameIndexs.TryGetValue("HPNum", out _hP_num_Index)) _hP_num_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskShow", out _taskShow_Index)) _taskShow_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskCinematic", out _task_cinematic_Index)) _task_cinematic_Index = -1;
                    if (!nameIndexs.TryGetValue("DeadHitFly", out _dead_hit_fly_Index)) _dead_hit_fly_Index = -1;
                    if (!nameIndexs.TryGetValue("BrithProtect", out _brithProtect_Index)) _brithProtect_Index = -1;
                    if (!nameIndexs.TryGetValue("BrithFowardPlayer", out _brithFowardPlayer_Index)) _brithFowardPlayer_Index = -1;
                    if (!nameIndexs.TryGetValue("BrithVfx", out _brithVfx_Index)) _brithVfx_Index = -1;
                    if (!nameIndexs.TryGetValue("BirthSpeech", out _birth_speech_Index)) _birth_speech_Index = -1;
                    if (!nameIndexs.TryGetValue("DeadSpeech", out _dead_speech_Index)) _dead_speech_Index = -1;
                    if (!nameIndexs.TryGetValue("DeadFeature", out _dead_feature_Index)) _dead_feature_Index = -1;
                    if (!nameIndexs.TryGetValue("HitFlyPercent", out _hit_fly_percent_Index)) _hit_fly_percent_Index = -1;
                    if (!nameIndexs.TryGetValue("HitShakePower", out _hit_shake_power_Index)) _hit_shake_power_Index = -1;
                    if (!nameIndexs.TryGetValue("CanBeSelect", out _can_be_select_Index)) _can_be_select_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterHpChange", out _monster_hp_change_Index)) _monster_hp_change_Index = -1;
                    if (!nameIndexs.TryGetValue("IsLockDir", out _is_lock_dir_Index)) _is_lock_dir_Index = -1;
                    if (!nameIndexs.TryGetValue("LockDir", out _lock_dir_Index)) _lock_dir_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowDropType", out _show_drop_type_Index)) _show_drop_type_Index = -1;
                    if (!nameIndexs.TryGetValue("MagicBowlReward", out _magic_bowl_reward_Index)) _magic_bowl_reward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMonster>(keyCount);
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
            if(HanderDefine.DataCallBack("Monster", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMonster cfg = null;
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
        public static DeclareMonster Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMonster result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Monster", out _compressData))
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
