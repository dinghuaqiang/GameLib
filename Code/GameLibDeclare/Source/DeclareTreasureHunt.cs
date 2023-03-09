//文件是自动生成,请勿手动修改.来自数据文件:Treasure_Hunt
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTreasureHunt
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _round_Index = -1;
        private static int _rewardType_Index = -1;
        private static int _isShow_Index = -1;
        private static int _type_Index = -1;
        private static int _reward_Index = -1;
        private static int _worldLevel_Index = -1;
        private static int _probability_Index = -1;
        private static int _worldLevelLimit_Index = -1;
        private static int _probabilityFreq_Index = -1;
        private static int _dailyControl_Index = -1;
        private static int _serverControl_Index = -1;
        private static int _ifRadio_Index = -1;
        private static int _chatchannel_Index = -1;
        private static int _modelShow_Index = -1;
        #endregion
        #region //私有变量定义
        //寻宝奖池id=rewardType*100+desc
        private int _id;
        //轮数
        //只有仙甲寻宝在用，其他类型寻宝无用（用于时间开启下一轮，轮数配置在global表1778
        private int _round;
        //奖池类型
        //1、机缘寻宝
        //2、仙魄奖池（灵魄抽奖）
        //3、造化寻宝
        //4、鸿蒙寻宝
        //5、上古寻宝
        //6，仙甲寻宝
        //对应Treasure_Pop表的主键
        private int _rewardType;
        //是否在界面中显示给玩家看
        //-1 不显示（玩家可以抽到，但是不会展示在界面）
        //0 显示（只能显示10个，不能配置超过10个，仙甲寻宝12个，超过指定个程序则不会读取）
        //2：主奖励（显示在界面最中心）
        //1：副奖励1（显示在左边副奖励）
        //3：副奖励2（显示在右边副奖励）
        private int _isShow;
        //道具类型
        //1：普通道具
        //2：极品道具
        private int _type;
        //item_num_bind_occ
        //bind 0未绑定1绑定
        //occ 0男1女9通用
        private int _reward;
        //LevelMin_LevelMax
        private int _worldLevel;
        //掉落概率，总和为1
        //1=100000
        private int _probability;
        //世界等级限制
        private int _worldLevelLimit;
        //type=2中达到设定次数从中随机得概率1=100000
        private int _probabilityFreq;
        //控制该玩家每天获取上限
        //0为无限制
        //>0为具体次数
        private int _dailyControl;
        //控制该服务器每天产出上限
        //0为无限制
        //>0为具体次数
        private int _serverControl;
        //公告类型（10跑马灯）
        private int _ifRadio;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        //模型id_男0女1地藏2_Scale_Rotatex_Rotatey_Rotatez_Positionx_Positiony
        //(hide)
        private int _modelShow;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Round { get{ return _round; }}
        public int RewardType { get{ return _rewardType; }}
        public int IsShow { get{ return _isShow; }}
        public int Type { get{ return _type; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string WorldLevel { get{ return HanderDefine.SetStingCallBack(_worldLevel); }}
        public int Probability { get{ return _probability; }}
        public string WorldLevelLimit { get{ return HanderDefine.SetStingCallBack(_worldLevelLimit); }}
        public int ProbabilityFreq { get{ return _probabilityFreq; }}
        public int DailyControl { get{ return _dailyControl; }}
        public int ServerControl { get{ return _serverControl; }}
        public int IfRadio { get{ return _ifRadio; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        public string ModelShow { get{ return HanderDefine.SetStingCallBack(_modelShow); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTreasureHunt cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTreasureHunt> _dataCaches = null;
        public static Dictionary<int, DeclareTreasureHunt> CacheData
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
                        if (HanderDefine.DataCallBack("TreasureHunt", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTreasureHunt cfg = null;
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
        private unsafe static DeclareTreasureHunt LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTreasureHunt();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._round = (int)GetValue(keyIndex, _round_Index, ptr);
            tmp._rewardType = (int)GetValue(keyIndex, _rewardType_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._worldLevel = (int)GetValue(keyIndex, _worldLevel_Index, ptr);
            tmp._probability = (int)GetValue(keyIndex, _probability_Index, ptr);
            tmp._worldLevelLimit = (int)GetValue(keyIndex, _worldLevelLimit_Index, ptr);
            tmp._probabilityFreq = (int)GetValue(keyIndex, _probabilityFreq_Index, ptr);
            tmp._dailyControl = (int)GetValue(keyIndex, _dailyControl_Index, ptr);
            tmp._serverControl = (int)GetValue(keyIndex, _serverControl_Index, ptr);
            tmp._ifRadio = (int)GetValue(keyIndex, _ifRadio_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            tmp._modelShow = (int)GetValue(keyIndex, _modelShow_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TreasureHunt", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Round", out _round_Index)) _round_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardType", out _rewardType_Index)) _rewardType_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLevel", out _worldLevel_Index)) _worldLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Probability", out _probability_Index)) _probability_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLevelLimit", out _worldLevelLimit_Index)) _worldLevelLimit_Index = -1;
                    if (!nameIndexs.TryGetValue("ProbabilityFreq", out _probabilityFreq_Index)) _probabilityFreq_Index = -1;
                    if (!nameIndexs.TryGetValue("DailyControl", out _dailyControl_Index)) _dailyControl_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerControl", out _serverControl_Index)) _serverControl_Index = -1;
                    if (!nameIndexs.TryGetValue("IfRadio", out _ifRadio_Index)) _ifRadio_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelShow", out _modelShow_Index)) _modelShow_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTreasureHunt>(keyCount);
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
            if(HanderDefine.DataCallBack("TreasureHunt", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTreasureHunt cfg = null;
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
        public static DeclareTreasureHunt Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTreasureHunt result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TreasureHunt", out _compressData))
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
