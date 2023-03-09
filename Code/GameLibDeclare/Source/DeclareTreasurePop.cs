//文件是自动生成,请勿手动修改.来自数据文件:Treasure_Pop
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTreasurePop
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _rewardType_Index = -1;
        private static int _rewardName_Index = -1;
        private static int _moneyCost_Index = -1;
        private static int _item_Index = -1;
        private static int _freeTimes_Index = -1;
        private static int _times_Index = -1;
        private static int _gold_Index = -1;
        private static int _integral_Index = -1;
        private static int _section_Index = -1;
        private static int _frequency_Index = -1;
        private static int _guarantees_reward_Index = -1;
        private static int _show_model_Index = -1;
        private static int _model_pos_Index = -1;
        private static int _luck_limit_Index = -1;
        private static int _luck_limit_mult_Index = -1;
        private static int _luck_limit_times_Index = -1;
        #endregion
        #region //私有变量定义
        //寻宝类别
        private int _id;
        //奖池类型
        //1、寻宝奖池
        //2、仙魄奖池
        //3、造化奖池
        //4、鸿蒙奖池
        //5，上古寻宝
        //6，仙甲寻宝
        private int _rewardType;
        //名称hide
        private int _rewardName;
        //单次花费
        //货币类型_num
        private int _moneyCost;
        //购买后获得的抽取道具id_num
        private int _item;
        //每天免费抽取次数
        private int _freeTimes;
        //寻宝次数_道具id_道具数量
        private int _times;
        //购买后获得的赠送道具类型_num
        private int _gold;
        //获得的积分
        //货币类型_num
        private int _integral;
        //对应的奖池区间
        private int _section;
        //具体次数必中type中的一个道具
        private int _frequency;
        //仙甲寻宝的保底奖励
        private int _guarantees_reward;
        //展示的内容（时装，坐骑，宠物用模型ID，称号用名字）modelID_缩放大小_Y轴偏移_Y轴旋转_X轴旋转_Z轴旋转_x轴偏移_z轴偏移_职业（0玄剑1天英2地藏9通用）
        //(hide)
        private int _show_model;
        //模型位置hide（废弃）
        private int _model_pos;
        //幸运值上限（rewardType=1，3，4，5才可使用）
        private int _luck_limit;
        //幸运值达到上限时，增加的大奖抽中概率
        //（Treasure_Hunt表中type=2的为大奖）
        //概率需要扩大10000倍填入，方便程序计算
        private int _luck_limit_mult;
        //增加幸运值保底次数，在幸运值满的情况下，达到次数则必中大奖
        private int _luck_limit_times;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int RewardType { get{ return _rewardType; }}
        public string RewardName { get{ return HanderDefine.SetStingCallBack(_rewardName); }}
        public string MoneyCost { get{ return HanderDefine.SetStingCallBack(_moneyCost); }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        public int FreeTimes { get{ return _freeTimes; }}
        public string Times { get{ return HanderDefine.SetStingCallBack(_times); }}
        public string Gold { get{ return HanderDefine.SetStingCallBack(_gold); }}
        public string Integral { get{ return HanderDefine.SetStingCallBack(_integral); }}
        public string Section { get{ return HanderDefine.SetStingCallBack(_section); }}
        public string Frequency { get{ return HanderDefine.SetStingCallBack(_frequency); }}
        public string GuaranteesReward { get{ return HanderDefine.SetStingCallBack(_guarantees_reward); }}
        public string ShowModel { get{ return HanderDefine.SetStingCallBack(_show_model); }}
        public string ModelPos { get{ return HanderDefine.SetStingCallBack(_model_pos); }}
        public int LuckLimit { get{ return _luck_limit; }}
        public int LuckLimitMult { get{ return _luck_limit_mult; }}
        public int LuckLimitTimes { get{ return _luck_limit_times; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTreasurePop cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTreasurePop> _dataCaches = null;
        public static Dictionary<int, DeclareTreasurePop> CacheData
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
                        if (HanderDefine.DataCallBack("TreasurePop", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTreasurePop cfg = null;
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
        private unsafe static DeclareTreasurePop LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTreasurePop();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._rewardType = (int)GetValue(keyIndex, _rewardType_Index, ptr);
            tmp._rewardName = (int)GetValue(keyIndex, _rewardName_Index, ptr);
            tmp._moneyCost = (int)GetValue(keyIndex, _moneyCost_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            tmp._freeTimes = (int)GetValue(keyIndex, _freeTimes_Index, ptr);
            tmp._times = (int)GetValue(keyIndex, _times_Index, ptr);
            tmp._gold = (int)GetValue(keyIndex, _gold_Index, ptr);
            tmp._integral = (int)GetValue(keyIndex, _integral_Index, ptr);
            tmp._section = (int)GetValue(keyIndex, _section_Index, ptr);
            tmp._frequency = (int)GetValue(keyIndex, _frequency_Index, ptr);
            tmp._guarantees_reward = (int)GetValue(keyIndex, _guarantees_reward_Index, ptr);
            tmp._show_model = (int)GetValue(keyIndex, _show_model_Index, ptr);
            tmp._model_pos = (int)GetValue(keyIndex, _model_pos_Index, ptr);
            tmp._luck_limit = (int)GetValue(keyIndex, _luck_limit_Index, ptr);
            tmp._luck_limit_mult = (int)GetValue(keyIndex, _luck_limit_mult_Index, ptr);
            tmp._luck_limit_times = (int)GetValue(keyIndex, _luck_limit_times_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TreasurePop", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardType", out _rewardType_Index)) _rewardType_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardName", out _rewardName_Index)) _rewardName_Index = -1;
                    if (!nameIndexs.TryGetValue("MoneyCost", out _moneyCost_Index)) _moneyCost_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
                    if (!nameIndexs.TryGetValue("FreeTimes", out _freeTimes_Index)) _freeTimes_Index = -1;
                    if (!nameIndexs.TryGetValue("Times", out _times_Index)) _times_Index = -1;
                    if (!nameIndexs.TryGetValue("Gold", out _gold_Index)) _gold_Index = -1;
                    if (!nameIndexs.TryGetValue("Integral", out _integral_Index)) _integral_Index = -1;
                    if (!nameIndexs.TryGetValue("Section", out _section_Index)) _section_Index = -1;
                    if (!nameIndexs.TryGetValue("Frequency", out _frequency_Index)) _frequency_Index = -1;
                    if (!nameIndexs.TryGetValue("GuaranteesReward", out _guarantees_reward_Index)) _guarantees_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModel", out _show_model_Index)) _show_model_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPos", out _model_pos_Index)) _model_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("LuckLimit", out _luck_limit_Index)) _luck_limit_Index = -1;
                    if (!nameIndexs.TryGetValue("LuckLimitMult", out _luck_limit_mult_Index)) _luck_limit_mult_Index = -1;
                    if (!nameIndexs.TryGetValue("LuckLimitTimes", out _luck_limit_times_Index)) _luck_limit_times_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTreasurePop>(keyCount);
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
            if(HanderDefine.DataCallBack("TreasurePop", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTreasurePop cfg = null;
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
        public static DeclareTreasurePop Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTreasurePop result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TreasurePop", out _compressData))
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
