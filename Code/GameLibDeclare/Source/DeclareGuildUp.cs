//文件是自动生成,请勿手动修改.来自数据文件:guild_up
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildUp
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _resources_Index = -1;
        private static int _level_Index = -1;
        private static int _base_num_Index = -1;
        private static int _question_reward_Index = -1;
        private static int _maintenance_fund_Index = -1;
        private static int _needNum_Index = -1;
        private static int _level_buff_Index = -1;
        private static int _functional_describe_Index = -1;
        private static int _upgrade_effect_Index = -1;
        private static int _other_Index = -1;
        #endregion
        #region //私有变量定义
        //key=type*10000+level
        private int _id;
        //建筑类型（1大厅，2商店，3驻地，4日常， 5福利所）
        private int _type;
        //图片资源（hide）
        private int _resources;
        //建筑等级
        private int _level;
        //公会基地对应加入玩家数量上限
        private int _base_num;
        //答题基数（数量）
        private int _question_reward;
        //维修基金
        private int _maintenance_fund;
        //升级所需建设度
        private int _needNum;
        //升级带来buff的id
        private int _level_buff;
        //功能描述hide
        private int _functional_describe;
        //升级效果展示hide
        private int _upgrade_effect;
        //升级所需其他建筑相关(@;@_@)
        private int _other;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public string Resources { get{ return HanderDefine.SetStingCallBack(_resources); }}
        public int Level { get{ return _level; }}
        public int BaseNum { get{ return _base_num; }}
        public int QuestionReward { get{ return _question_reward; }}
        public int MaintenanceFund { get{ return _maintenance_fund; }}
        public int NeedNum { get{ return _needNum; }}
        public int LevelBuff { get{ return _level_buff; }}
        public string FunctionalDescribe { get{ return HanderDefine.SetStingCallBack(_functional_describe); }}
        public string UpgradeEffect { get{ return HanderDefine.SetStingCallBack(_upgrade_effect); }}
        public string Other { get{ return HanderDefine.SetStingCallBack(_other); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildUp cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildUp> _dataCaches = null;
        public static Dictionary<int, DeclareGuildUp> CacheData
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
                        if (HanderDefine.DataCallBack("GuildUp", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildUp cfg = null;
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
        private unsafe static DeclareGuildUp LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildUp();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._resources = (int)GetValue(keyIndex, _resources_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._base_num = (int)GetValue(keyIndex, _base_num_Index, ptr);
            tmp._question_reward = (int)GetValue(keyIndex, _question_reward_Index, ptr);
            tmp._maintenance_fund = (int)GetValue(keyIndex, _maintenance_fund_Index, ptr);
            tmp._needNum = (int)GetValue(keyIndex, _needNum_Index, ptr);
            tmp._level_buff = (int)GetValue(keyIndex, _level_buff_Index, ptr);
            tmp._functional_describe = (int)GetValue(keyIndex, _functional_describe_Index, ptr);
            tmp._upgrade_effect = (int)GetValue(keyIndex, _upgrade_effect_Index, ptr);
            tmp._other = (int)GetValue(keyIndex, _other_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildUp", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Resources", out _resources_Index)) _resources_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("BaseNum", out _base_num_Index)) _base_num_Index = -1;
                    if (!nameIndexs.TryGetValue("QuestionReward", out _question_reward_Index)) _question_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("MaintenanceFund", out _maintenance_fund_Index)) _maintenance_fund_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedNum", out _needNum_Index)) _needNum_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelBuff", out _level_buff_Index)) _level_buff_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionalDescribe", out _functional_describe_Index)) _functional_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("UpgradeEffect", out _upgrade_effect_Index)) _upgrade_effect_Index = -1;
                    if (!nameIndexs.TryGetValue("Other", out _other_Index)) _other_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildUp>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildUp", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildUp cfg = null;
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
        public static DeclareGuildUp Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildUp result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildUp", out _compressData))
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
