//文件是自动生成,请勿手动修改.来自数据文件:retrieveRes
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRetrieveRes
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _minLevel_Index = -1;
        private static int _maxLevel_Index = -1;
        private static int _openVariables_Index = -1;
        private static int _dailyId_Index = -1;
        private static int _vipPower_Index = -1;
        private static int _name_Index = -1;
        private static int _reward_part_Index = -1;
        private static int _cost_part_Index = -1;
        private static int _reward_perfect_Index = -1;
        private static int _rewardexp_part_Index = -1;
        private static int _rewardexp_perfect_Index = -1;
        private static int _cost_perfect_Index = -1;
        private static int _max_Index = -1;
        private static int _group_Index = -1;
        #endregion
        #region //私有变量定义
        //唯一ID
        private int _id;
        //类型
        private int _type;
        //等级min
        private int _minLevel;
        //等级max
        private int _maxLevel;
        //对应FunctionStart表里的主键ID
        //用于程序判断功能是否开启
        private int _openVariables;
        //对应daily表主键，
        //用于程序定位功能
        //填0代表无日常项
        private int _dailyId;
        //对应vipPower主键
        //用于定位额外购买次数
        //填0代表无VIP购买次数
        private int _vipPower;
        //找回类型名字，客户端调用界面显示
        private int _name;
        //部分找回奖励
        //ID_Num_Bind_Occ
        //ID_数量_绑定_职业
        //绑定：0未绑定 1绑定
        //职业：0男 1女 9通用
        //部分50%比例（活跃25%）
        private int _reward_part;
        //部分找回消耗
        //物品ID_数量
        private int _cost_part;
        //完美找回奖励
        //ID_Num_Bind_Occ
        //ID_数量_绑定_职业
        //绑定：0未绑定 1绑定
        //职业：0男 1女 9通用
        //完美100%比例(活跃50%）
        private int _reward_perfect;
        //部分找回经验值奖励
        //（为了减少客户端字符串数量独立）
        private Int64 _rewardexp_part;
        //完美找回经验值奖励
        //（为了减少客户端字符串数量独立）
        private Int64 _rewardexp_perfect;
        //完美找回消耗
        //物品ID_数量
        private int _cost_perfect;
        //次数(每天系统提供的参与次数)
        //活跃值代表可找回上限
        private int _max;
        //找回组（每次点击找回能够找回多少资源）
        //比如：max=20；group=10
        //表示每次找回10次奖励，找回2次就找回满了
        //（废弃，保持和max相等即可）
        private int _group;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int MinLevel { get{ return _minLevel; }}
        public int MaxLevel { get{ return _maxLevel; }}
        public int OpenVariables { get{ return _openVariables; }}
        public int DailyId { get{ return _dailyId; }}
        public int VipPower { get{ return _vipPower; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string RewardPart { get{ return HanderDefine.SetStingCallBack(_reward_part); }}
        public string CostPart { get{ return HanderDefine.SetStingCallBack(_cost_part); }}
        public string RewardPerfect { get{ return HanderDefine.SetStingCallBack(_reward_perfect); }}
        public Int64 RewardexpPart { get{ return _rewardexp_part; }}
        public Int64 RewardexpPerfect { get{ return _rewardexp_perfect; }}
        public string CostPerfect { get{ return HanderDefine.SetStingCallBack(_cost_perfect); }}
        public int Max { get{ return _max; }}
        public int Group { get{ return _group; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRetrieveRes cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRetrieveRes> _dataCaches = null;
        public static Dictionary<int, DeclareRetrieveRes> CacheData
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
                        if (HanderDefine.DataCallBack("RetrieveRes", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRetrieveRes cfg = null;
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
        private unsafe static DeclareRetrieveRes LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRetrieveRes();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._minLevel = (int)GetValue(keyIndex, _minLevel_Index, ptr);
            tmp._maxLevel = (int)GetValue(keyIndex, _maxLevel_Index, ptr);
            tmp._openVariables = (int)GetValue(keyIndex, _openVariables_Index, ptr);
            tmp._dailyId = (int)GetValue(keyIndex, _dailyId_Index, ptr);
            tmp._vipPower = (int)GetValue(keyIndex, _vipPower_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._reward_part = (int)GetValue(keyIndex, _reward_part_Index, ptr);
            tmp._cost_part = (int)GetValue(keyIndex, _cost_part_Index, ptr);
            tmp._reward_perfect = (int)GetValue(keyIndex, _reward_perfect_Index, ptr);
            tmp._rewardexp_part = GetValue(keyIndex, _rewardexp_part_Index, ptr);
            tmp._rewardexp_perfect = GetValue(keyIndex, _rewardexp_perfect_Index, ptr);
            tmp._cost_perfect = (int)GetValue(keyIndex, _cost_perfect_Index, ptr);
            tmp._max = (int)GetValue(keyIndex, _max_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RetrieveRes", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("MinLevel", out _minLevel_Index)) _minLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _maxLevel_Index)) _maxLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenVariables", out _openVariables_Index)) _openVariables_Index = -1;
                    if (!nameIndexs.TryGetValue("DailyId", out _dailyId_Index)) _dailyId_Index = -1;
                    if (!nameIndexs.TryGetValue("VipPower", out _vipPower_Index)) _vipPower_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardPart", out _reward_part_Index)) _reward_part_Index = -1;
                    if (!nameIndexs.TryGetValue("CostPart", out _cost_part_Index)) _cost_part_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardPerfect", out _reward_perfect_Index)) _reward_perfect_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardexpPart", out _rewardexp_part_Index)) _rewardexp_part_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardexpPerfect", out _rewardexp_perfect_Index)) _rewardexp_perfect_Index = -1;
                    if (!nameIndexs.TryGetValue("CostPerfect", out _cost_perfect_Index)) _cost_perfect_Index = -1;
                    if (!nameIndexs.TryGetValue("Max", out _max_Index)) _max_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRetrieveRes>(keyCount);
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
            if(HanderDefine.DataCallBack("RetrieveRes", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRetrieveRes cfg = null;
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
        public static DeclareRetrieveRes Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRetrieveRes result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RetrieveRes", out _compressData))
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
