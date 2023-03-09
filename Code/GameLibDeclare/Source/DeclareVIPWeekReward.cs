//文件是自动生成,请勿手动修改.来自数据文件:VIPWeekReward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVIPWeekReward
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _condition_Index = -1;
        private static int _item_Index = -1;
        private static int _vIPMoney_Index = -1;
        private static int _desc1_Index = -1;
        private static int _item_weekCard_Index = -1;
        private static int _vIPMoney_weekCard_Index = -1;
        private static int _desc2_Index = -1;
        private static int _totalVipExp_Index = -1;
        #endregion
        #region //私有变量定义
        //奖励编号
        private int _id;
        //组标识
        private int _type;
        //需要达到的领取条件(领取不扣除）
        private int _condition;
        //ID_num_bind_occ(物品ID_数量_绑定_职业）
        //bind  0不绑定  1绑定
        //occ   0男剑  1女枪  9通用
        private int _item;
        //可领取的VIP点（用于增加VIP经验）
        private int _vIPMoney;
        //物品描述（hide）
        private int _desc1;
        //激活周卡额外领取的奖励
        //ID_num_bind_occ(物品ID_数量_绑定_职业）
        //bind  0不绑定  1绑定
        //occ   0男剑  1女枪  9通用
        private int _item_weekCard;
        //激活周卡额外领取的奖励
        //可领取的VIP点（用于增加VIP经验）
        private int _vIPMoney_weekCard;
        //物品描述（hide）
        private int _desc2;
        //领取获得VIP经验总计（包含周卡获得），用于客户端计算玩家总值
        //（hide）
        private int _totalVipExp;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Condition { get{ return _condition; }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        public int VIPMoney { get{ return _vIPMoney; }}
        public string Desc1 { get{ return HanderDefine.SetStingCallBack(_desc1); }}
        public string ItemWeekCard { get{ return HanderDefine.SetStingCallBack(_item_weekCard); }}
        public int VIPMoneyWeekCard { get{ return _vIPMoney_weekCard; }}
        public string Desc2 { get{ return HanderDefine.SetStingCallBack(_desc2); }}
        public int TotalVipExp { get{ return _totalVipExp; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVIPWeekReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVIPWeekReward> _dataCaches = null;
        public static Dictionary<int, DeclareVIPWeekReward> CacheData
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
                        if (HanderDefine.DataCallBack("VIPWeekReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVIPWeekReward cfg = null;
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
        private unsafe static DeclareVIPWeekReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVIPWeekReward();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            tmp._vIPMoney = (int)GetValue(keyIndex, _vIPMoney_Index, ptr);
            tmp._desc1 = (int)GetValue(keyIndex, _desc1_Index, ptr);
            tmp._item_weekCard = (int)GetValue(keyIndex, _item_weekCard_Index, ptr);
            tmp._vIPMoney_weekCard = (int)GetValue(keyIndex, _vIPMoney_weekCard_Index, ptr);
            tmp._desc2 = (int)GetValue(keyIndex, _desc2_Index, ptr);
            tmp._totalVipExp = (int)GetValue(keyIndex, _totalVipExp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("VIPWeekReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
                    if (!nameIndexs.TryGetValue("VIPMoney", out _vIPMoney_Index)) _vIPMoney_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc1", out _desc1_Index)) _desc1_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemWeekCard", out _item_weekCard_Index)) _item_weekCard_Index = -1;
                    if (!nameIndexs.TryGetValue("VIPMoneyWeekCard", out _vIPMoney_weekCard_Index)) _vIPMoney_weekCard_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc2", out _desc2_Index)) _desc2_Index = -1;
                    if (!nameIndexs.TryGetValue("TotalVipExp", out _totalVipExp_Index)) _totalVipExp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareVIPWeekReward>();
                        _dataIndexCaches = new Dictionary<int, int>();
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
            if(HanderDefine.DataCallBack("VIPWeekReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVIPWeekReward cfg = null;
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
        public static DeclareVIPWeekReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVIPWeekReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("VIPWeekReward", out _compressData))
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
