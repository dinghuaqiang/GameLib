//文件是自动生成,请勿手动修改.来自数据文件:FunctionVariable
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFunctionVariable
    {
        #region //静态变量定义
        private static int _variable_Index = -1;
        private static int _server_sync_Index = -1;
        private static int _achievement_Index = -1;
        private static int _spell_Index = -1;
        private static int _gemstone_Index = -1;
        private static int _state_Index = -1;
        private static int _function_Index = -1;
        private static int _changejob_Index = -1;
        private static int _growup_Index = -1;
        private static int _fashion_Index = -1;
        private static int _task_Index = -1;
        private static int _stifle_Index = -1;
        private static int _vIPWeek_Index = -1;
        private static int _isVIPtask_Index = -1;
        private static int _new_active_Index = -1;
        private static int _flySword_Index = -1;
        private static int _direct_shop_Index = -1;
        private static int _fallingSky_Index = -1;
        private static int _luckyDraw_Index = -1;
        private static int _petEquipUnlock_Index = -1;
        private static int _soulEquipUnlock_Index = -1;
        private static int _horseEquipUnlock_Index = -1;
        private static int _cross_devil_Index = -1;
        private static int _marry_activity_task_Index = -1;
        private static int _nPC_friend_Index = -1;
        private static int _guild_gift_Index = -1;
        private static int _today_function_task_Index = -1;
        private static int _vipRebate_Index = -1;
        private static int _guild_battle_Index = -1;
        #endregion
        #region //私有变量定义
        //变量ID，此ID只能增加不能修改和删除
        private int _variable;
        //是否需要服务器同步数据
        private int _server_sync;
        //成就用的条件(0不用.1使用)
        private int _achievement;
        //符咒用的条件(0不用.1使用)
        private int _spell;
        //宝石镶嵌用的条件(0不用.1使用)
        private int _gemstone;
        //境界用的条件(0不用.1使用)
        private int _state;
        //开放系统
        private int _function;
        //转职用的条件(0不用.1使用)
        private int _changejob;
        //新服活动成长之路中检测
        private int _growup;
        //时装中检测
        private int _fashion;
        //任务中检测（0不检测.1检测）变量2，44不能用
        private int _task;
        //灵压中检测（0不检测.1检测）
        private int _stifle;
        //是否属于VIP周常（0不属于，1属于），废弃，旧版VIP使用的字段
        private int _vIPWeek;
        //是否属于VIP任务
        private int _isVIPtask;
        //新服活动中检测
        //（新服优势，完美情缘）
        //【功能改名为“神器灵章”】
        private int _new_active;
        //剑灵中是否使用
        //（剑灵，灵魄，剑冢，剑灵阁）
        private int _flySword;
        //超值折扣礼包是否使用
        private int _direct_shop;
        //天禁令任务中是否检测
        //（0否1是）
        private int _fallingSky;
        //周福利幸运抽奖检测0不检测.1检测）
        private int _luckyDraw;
        //解锁宠物装备槽位条件
        private int _petEquipUnlock;
        //解锁魂甲魂印槽位条件
        private int _soulEquipUnlock;
        //解锁坐骑脉轮条件
        private int _horseEquipUnlock;
        //魔魂系统栏位解锁
        private int _cross_devil;
        //完美情缘（情缘任务）
        private int _marry_activity_task;
        //NPC好友
        private int _nPC_friend;
        //仙盟宝箱
        private int _guild_gift;
        //核心任务
        private int _today_function_task;
        //V4返利
        private int _vipRebate;
        //仙盟争霸
        private int _guild_battle;
        #endregion

        #region //公共属性
        public int Variable { get{ return _variable; }}
        public int ServerSync { get{ return _server_sync; }}
        public int Achievement { get{ return _achievement; }}
        public int Spell { get{ return _spell; }}
        public int Gemstone { get{ return _gemstone; }}
        public int State { get{ return _state; }}
        public int Function { get{ return _function; }}
        public int Changejob { get{ return _changejob; }}
        public int Growup { get{ return _growup; }}
        public int Fashion { get{ return _fashion; }}
        public int Task { get{ return _task; }}
        public int Stifle { get{ return _stifle; }}
        public int VIPWeek { get{ return _vIPWeek; }}
        public int IsVIPtask { get{ return _isVIPtask; }}
        public int NewActive { get{ return _new_active; }}
        public int FlySword { get{ return _flySword; }}
        public int DirectShop { get{ return _direct_shop; }}
        public int FallingSky { get{ return _fallingSky; }}
        public int LuckyDraw { get{ return _luckyDraw; }}
        public int PetEquipUnlock { get{ return _petEquipUnlock; }}
        public int SoulEquipUnlock { get{ return _soulEquipUnlock; }}
        public int HorseEquipUnlock { get{ return _horseEquipUnlock; }}
        public int CrossDevil { get{ return _cross_devil; }}
        public int MarryActivityTask { get{ return _marry_activity_task; }}
        public int NPCFriend { get{ return _nPC_friend; }}
        public int GuildGift { get{ return _guild_gift; }}
        public int TodayFunctionTask { get{ return _today_function_task; }}
        public int VipRebate { get{ return _vipRebate; }}
        public int GuildBattle { get{ return _guild_battle; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFunctionVariable cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFunctionVariable> _dataCaches = null;
        public static Dictionary<int, DeclareFunctionVariable> CacheData
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
                        if (HanderDefine.DataCallBack("FunctionVariable", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFunctionVariable cfg = null;
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
        private unsafe static DeclareFunctionVariable LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFunctionVariable();
            tmp._variable = (int)GetValue(keyIndex, _variable_Index, ptr);
            tmp._server_sync = (int)GetValue(keyIndex, _server_sync_Index, ptr);
            tmp._achievement = (int)GetValue(keyIndex, _achievement_Index, ptr);
            tmp._spell = (int)GetValue(keyIndex, _spell_Index, ptr);
            tmp._gemstone = (int)GetValue(keyIndex, _gemstone_Index, ptr);
            tmp._state = (int)GetValue(keyIndex, _state_Index, ptr);
            tmp._function = (int)GetValue(keyIndex, _function_Index, ptr);
            tmp._changejob = (int)GetValue(keyIndex, _changejob_Index, ptr);
            tmp._growup = (int)GetValue(keyIndex, _growup_Index, ptr);
            tmp._fashion = (int)GetValue(keyIndex, _fashion_Index, ptr);
            tmp._task = (int)GetValue(keyIndex, _task_Index, ptr);
            tmp._stifle = (int)GetValue(keyIndex, _stifle_Index, ptr);
            tmp._vIPWeek = (int)GetValue(keyIndex, _vIPWeek_Index, ptr);
            tmp._isVIPtask = (int)GetValue(keyIndex, _isVIPtask_Index, ptr);
            tmp._new_active = (int)GetValue(keyIndex, _new_active_Index, ptr);
            tmp._flySword = (int)GetValue(keyIndex, _flySword_Index, ptr);
            tmp._direct_shop = (int)GetValue(keyIndex, _direct_shop_Index, ptr);
            tmp._fallingSky = (int)GetValue(keyIndex, _fallingSky_Index, ptr);
            tmp._luckyDraw = (int)GetValue(keyIndex, _luckyDraw_Index, ptr);
            tmp._petEquipUnlock = (int)GetValue(keyIndex, _petEquipUnlock_Index, ptr);
            tmp._soulEquipUnlock = (int)GetValue(keyIndex, _soulEquipUnlock_Index, ptr);
            tmp._horseEquipUnlock = (int)GetValue(keyIndex, _horseEquipUnlock_Index, ptr);
            tmp._cross_devil = (int)GetValue(keyIndex, _cross_devil_Index, ptr);
            tmp._marry_activity_task = (int)GetValue(keyIndex, _marry_activity_task_Index, ptr);
            tmp._nPC_friend = (int)GetValue(keyIndex, _nPC_friend_Index, ptr);
            tmp._guild_gift = (int)GetValue(keyIndex, _guild_gift_Index, ptr);
            tmp._today_function_task = (int)GetValue(keyIndex, _today_function_task_Index, ptr);
            tmp._vipRebate = (int)GetValue(keyIndex, _vipRebate_Index, ptr);
            tmp._guild_battle = (int)GetValue(keyIndex, _guild_battle_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FunctionVariable", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Variable", out _variable_Index)) _variable_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerSync", out _server_sync_Index)) _server_sync_Index = -1;
                    if (!nameIndexs.TryGetValue("Achievement", out _achievement_Index)) _achievement_Index = -1;
                    if (!nameIndexs.TryGetValue("Spell", out _spell_Index)) _spell_Index = -1;
                    if (!nameIndexs.TryGetValue("Gemstone", out _gemstone_Index)) _gemstone_Index = -1;
                    if (!nameIndexs.TryGetValue("State", out _state_Index)) _state_Index = -1;
                    if (!nameIndexs.TryGetValue("Function", out _function_Index)) _function_Index = -1;
                    if (!nameIndexs.TryGetValue("Changejob", out _changejob_Index)) _changejob_Index = -1;
                    if (!nameIndexs.TryGetValue("Growup", out _growup_Index)) _growup_Index = -1;
                    if (!nameIndexs.TryGetValue("Fashion", out _fashion_Index)) _fashion_Index = -1;
                    if (!nameIndexs.TryGetValue("Task", out _task_Index)) _task_Index = -1;
                    if (!nameIndexs.TryGetValue("Stifle", out _stifle_Index)) _stifle_Index = -1;
                    if (!nameIndexs.TryGetValue("VIPWeek", out _vIPWeek_Index)) _vIPWeek_Index = -1;
                    if (!nameIndexs.TryGetValue("IsVIPtask", out _isVIPtask_Index)) _isVIPtask_Index = -1;
                    if (!nameIndexs.TryGetValue("NewActive", out _new_active_Index)) _new_active_Index = -1;
                    if (!nameIndexs.TryGetValue("FlySword", out _flySword_Index)) _flySword_Index = -1;
                    if (!nameIndexs.TryGetValue("DirectShop", out _direct_shop_Index)) _direct_shop_Index = -1;
                    if (!nameIndexs.TryGetValue("FallingSky", out _fallingSky_Index)) _fallingSky_Index = -1;
                    if (!nameIndexs.TryGetValue("LuckyDraw", out _luckyDraw_Index)) _luckyDraw_Index = -1;
                    if (!nameIndexs.TryGetValue("PetEquipUnlock", out _petEquipUnlock_Index)) _petEquipUnlock_Index = -1;
                    if (!nameIndexs.TryGetValue("SoulEquipUnlock", out _soulEquipUnlock_Index)) _soulEquipUnlock_Index = -1;
                    if (!nameIndexs.TryGetValue("HorseEquipUnlock", out _horseEquipUnlock_Index)) _horseEquipUnlock_Index = -1;
                    if (!nameIndexs.TryGetValue("CrossDevil", out _cross_devil_Index)) _cross_devil_Index = -1;
                    if (!nameIndexs.TryGetValue("MarryActivityTask", out _marry_activity_task_Index)) _marry_activity_task_Index = -1;
                    if (!nameIndexs.TryGetValue("NPCFriend", out _nPC_friend_Index)) _nPC_friend_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildGift", out _guild_gift_Index)) _guild_gift_Index = -1;
                    if (!nameIndexs.TryGetValue("TodayFunctionTask", out _today_function_task_Index)) _today_function_task_Index = -1;
                    if (!nameIndexs.TryGetValue("VipRebate", out _vipRebate_Index)) _vipRebate_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildBattle", out _guild_battle_Index)) _guild_battle_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFunctionVariable>(keyCount);
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
            if(HanderDefine.DataCallBack("FunctionVariable", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFunctionVariable cfg = null;
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
        public static DeclareFunctionVariable Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFunctionVariable result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FunctionVariable", out _compressData))
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
