//文件是自动生成,请勿手动修改.来自数据文件:marry_battle_exchange
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryBattleExchange
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _itemID_Index = -1;
        private static int _occ_Index = -1;
        private static int _pay_Index = -1;
        private static int _limitType_Index = -1;
        private static int _buyNum_Index = -1;
        #endregion
        #region //私有变量定义
        //排序id
        private int _id;
        //物品奖励ID
        private int _itemID;
        //职业区分（0，男剑；1，女枪；2，和尚；3，罗刹；9，通用）(hide)
        private int _occ;
        //兑换需要的货币ID_数量
        private int _pay;
        //0.不限购；1.周限购；2.终身限购
        private int _limitType;
        //可购买次数
        //商品可购买次数:-1为无限
        private int _buyNum;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ItemID { get{ return _itemID; }}
        public string Occ { get{ return HanderDefine.SetStingCallBack(_occ); }}
        public string Pay { get{ return HanderDefine.SetStingCallBack(_pay); }}
        public int LimitType { get{ return _limitType; }}
        public int BuyNum { get{ return _buyNum; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryBattleExchange cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryBattleExchange> _dataCaches = null;
        public static Dictionary<int, DeclareMarryBattleExchange> CacheData
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
                        if (HanderDefine.DataCallBack("MarryBattleExchange", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryBattleExchange cfg = null;
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
        private unsafe static DeclareMarryBattleExchange LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryBattleExchange();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._itemID = (int)GetValue(keyIndex, _itemID_Index, ptr);
            tmp._occ = (int)GetValue(keyIndex, _occ_Index, ptr);
            tmp._pay = (int)GetValue(keyIndex, _pay_Index, ptr);
            tmp._limitType = (int)GetValue(keyIndex, _limitType_Index, ptr);
            tmp._buyNum = (int)GetValue(keyIndex, _buyNum_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryBattleExchange", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemID", out _itemID_Index)) _itemID_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ", out _occ_Index)) _occ_Index = -1;
                    if (!nameIndexs.TryGetValue("Pay", out _pay_Index)) _pay_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitType", out _limitType_Index)) _limitType_Index = -1;
                    if (!nameIndexs.TryGetValue("BuyNum", out _buyNum_Index)) _buyNum_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryBattleExchange>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryBattleExchange", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryBattleExchange cfg = null;
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
        public static DeclareMarryBattleExchange Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryBattleExchange result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryBattleExchange", out _compressData))
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
