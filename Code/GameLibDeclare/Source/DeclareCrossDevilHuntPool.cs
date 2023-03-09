//文件是自动生成,请勿手动修改.来自数据文件:Cross_devil_hunt_Pool
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossDevilHuntPool
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _hot_Limit_Index = -1;
        private static int _reward_Index = -1;
        private static int _probability_Index = -1;
        private static int _probabilityMiddle_Index = -1;
        private static int _probabilityLow_Index = -1;
        private static int _isShow_Index = -1;
        private static int _rankShow_Index = -1;
        #endregion
        #region //私有变量定义
        //奖池id
        private int _id;
        //封魔度限制
        //对应Cross_devil_hunt_Hot主键
        //-1代表公共部分，所有封魔度区间都可能抽到
        private int _hot_Limit;
        //奖励
        private int _reward;
        //高级抽奖权重
        //各个封魔度的权重独立计算
        private int _probability;
        //中级抽奖权重
        //各个封魔度的权重独立计算
        private int _probabilityMiddle;
        //低级抽奖权重
        //各个封魔度的权重独立计算
        private int _probabilityLow;
        //是否用于界面奖励展示
        //0不展示
        //1展示
        //填空默认为不展示
        //（hide）
        private int _isShow;
        //对应奖励档位的奖励预览
        //对应Cross_devil_hunt_Pop主键
        //配空代表不在档位预览显示
        //（hide）
        private int _rankShow;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int HotLimit { get{ return _hot_Limit; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int Probability { get{ return _probability; }}
        public int ProbabilityMiddle { get{ return _probabilityMiddle; }}
        public int ProbabilityLow { get{ return _probabilityLow; }}
        public int IsShow { get{ return _isShow; }}
        public int RankShow { get{ return _rankShow; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossDevilHuntPool cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossDevilHuntPool> _dataCaches = null;
        public static Dictionary<int, DeclareCrossDevilHuntPool> CacheData
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
                        if (HanderDefine.DataCallBack("CrossDevilHuntPool", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossDevilHuntPool cfg = null;
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
        private unsafe static DeclareCrossDevilHuntPool LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossDevilHuntPool();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._hot_Limit = (int)GetValue(keyIndex, _hot_Limit_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._probability = (int)GetValue(keyIndex, _probability_Index, ptr);
            tmp._probabilityMiddle = (int)GetValue(keyIndex, _probabilityMiddle_Index, ptr);
            tmp._probabilityLow = (int)GetValue(keyIndex, _probabilityLow_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._rankShow = (int)GetValue(keyIndex, _rankShow_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossDevilHuntPool", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("HotLimit", out _hot_Limit_Index)) _hot_Limit_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Probability", out _probability_Index)) _probability_Index = -1;
                    if (!nameIndexs.TryGetValue("ProbabilityMiddle", out _probabilityMiddle_Index)) _probabilityMiddle_Index = -1;
                    if (!nameIndexs.TryGetValue("ProbabilityLow", out _probabilityLow_Index)) _probabilityLow_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("RankShow", out _rankShow_Index)) _rankShow_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossDevilHuntPool>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossDevilHuntPool", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossDevilHuntPool cfg = null;
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
        public static DeclareCrossDevilHuntPool Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossDevilHuntPool result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossDevilHuntPool", out _compressData))
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
