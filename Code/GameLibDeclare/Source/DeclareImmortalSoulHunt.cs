//文件是自动生成,请勿手动修改.来自数据文件:immortal_soul_hunt
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareImmortalSoulHunt
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _times_Index = -1;
        private static int _special_times_Index = -1;
        private static int _type_probability_Index = -1;
        private static int _quality_probability_Index = -1;
        private static int _special_times1_Index = -1;
        private static int _special_type_probability_Index = -1;
        private static int _special_quality_probability_Index = -1;
        private static int _add_type_probability_Index = -1;
        private static int _reward_Index = -1;
        private static int _basic_attributes_Index = -1;
        private static int _exchange_ranking_Index = -1;
        private static int _exp_Index = -1;
        private static int _type_Index = -1;
        #endregion
        #region //私有变量定义
        //灵魂抽取id
        private int _id;
        //抽奖的次数（区分是单抽还是10连抽）
        private int _times;
        //特殊次数的特殊奖池（填写对应的次数，如果填-1，则为一般奖池）
        private int _special_times;
        //抽取类型判断（immortal_soul_attribute表的type_万分比概率）client igrone
        private int _type_probability;
        //抽取品质判断（immortal_soul_attribute表的quality_权重）client igrone
        private int _quality_probability;
        //第X次走特殊掉落组client igrone
        private int _special_times1;
        //抽取类型判断（immortal_soul_attribute表的type_万分比概率）client igrone
        private int _special_type_probability;
        //抽取品质判断（immortal_soul_attribute表的quality_权重）client igrone
        private int _special_quality_probability;
        //属性灵魄抽取属性类型判断（1，只能出单属性最大类型1-21；2，能够出双属性，最大类型1-28；3，能够出三属性，最大类型1-35）client igrone
        private int _add_type_probability;
        //每次抽奖固定获得的物品client igrone
        private int _reward;
        //抽奖消耗的货币_数量
        private int _basic_attributes;
        //货币不足时的单位购买花费元宝数量
        private int _exchange_ranking;
        //货币不足时的单位购买的货币
        private int _exp;
        //货币不足时的单位赠送的货币
        private int _type;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Times { get{ return _times; }}
        public int SpecialTimes { get{ return _special_times; }}
        public string TypeProbability { get{ return HanderDefine.SetStingCallBack(_type_probability); }}
        public string QualityProbability { get{ return HanderDefine.SetStingCallBack(_quality_probability); }}
        public int SpecialTimes1 { get{ return _special_times1; }}
        public string SpecialTypeProbability { get{ return HanderDefine.SetStingCallBack(_special_type_probability); }}
        public string SpecialQualityProbability { get{ return HanderDefine.SetStingCallBack(_special_quality_probability); }}
        public string AddTypeProbability { get{ return HanderDefine.SetStingCallBack(_add_type_probability); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string BasicAttributes { get{ return HanderDefine.SetStingCallBack(_basic_attributes); }}
        public int ExchangeRanking { get{ return _exchange_ranking; }}
        public string Exp { get{ return HanderDefine.SetStingCallBack(_exp); }}
        public string Type { get{ return HanderDefine.SetStingCallBack(_type); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareImmortalSoulHunt cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareImmortalSoulHunt> _dataCaches = null;
        public static Dictionary<int, DeclareImmortalSoulHunt> CacheData
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
                        if (HanderDefine.DataCallBack("ImmortalSoulHunt", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareImmortalSoulHunt cfg = null;
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
        private unsafe static DeclareImmortalSoulHunt LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareImmortalSoulHunt();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._times = (int)GetValue(keyIndex, _times_Index, ptr);
            tmp._special_times = (int)GetValue(keyIndex, _special_times_Index, ptr);
            tmp._type_probability = (int)GetValue(keyIndex, _type_probability_Index, ptr);
            tmp._quality_probability = (int)GetValue(keyIndex, _quality_probability_Index, ptr);
            tmp._special_times1 = (int)GetValue(keyIndex, _special_times1_Index, ptr);
            tmp._special_type_probability = (int)GetValue(keyIndex, _special_type_probability_Index, ptr);
            tmp._special_quality_probability = (int)GetValue(keyIndex, _special_quality_probability_Index, ptr);
            tmp._add_type_probability = (int)GetValue(keyIndex, _add_type_probability_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._basic_attributes = (int)GetValue(keyIndex, _basic_attributes_Index, ptr);
            tmp._exchange_ranking = (int)GetValue(keyIndex, _exchange_ranking_Index, ptr);
            tmp._exp = (int)GetValue(keyIndex, _exp_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ImmortalSoulHunt", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Times", out _times_Index)) _times_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialTimes", out _special_times_Index)) _special_times_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeProbability", out _type_probability_Index)) _type_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("QualityProbability", out _quality_probability_Index)) _quality_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialTimes1", out _special_times1_Index)) _special_times1_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialTypeProbability", out _special_type_probability_Index)) _special_type_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialQualityProbability", out _special_quality_probability_Index)) _special_quality_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("AddTypeProbability", out _add_type_probability_Index)) _add_type_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("BasicAttributes", out _basic_attributes_Index)) _basic_attributes_Index = -1;
                    if (!nameIndexs.TryGetValue("ExchangeRanking", out _exchange_ranking_Index)) _exchange_ranking_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareImmortalSoulHunt>(keyCount);
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
            if(HanderDefine.DataCallBack("ImmortalSoulHunt", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareImmortalSoulHunt cfg = null;
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
        public static DeclareImmortalSoulHunt Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareImmortalSoulHunt result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ImmortalSoulHunt", out _compressData))
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
