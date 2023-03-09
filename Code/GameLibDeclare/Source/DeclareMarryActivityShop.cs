//文件是自动生成,请勿手动修改.来自数据文件:marry_activity_shop
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryActivityShop
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _originalPrice_Index = -1;
        private static int _price_Index = -1;
        private static int _discount_Index = -1;
        private static int _limitBuy_Index = -1;
        private static int _reward_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        private int _id;
        //商品名字
        private int _name;
        //原价
        //货币类型_价格
        private int _originalPrice;
        //当前价格
        private int _price;
        //折扣，界面显示折扣
        //（hide）
        private int _discount;
        //个人限购次数
        private int _limitBuy;
        //礼包内容
        private int _reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string OriginalPrice { get{ return HanderDefine.SetStingCallBack(_originalPrice); }}
        public string Price { get{ return HanderDefine.SetStingCallBack(_price); }}
        public int Discount { get{ return _discount; }}
        public int LimitBuy { get{ return _limitBuy; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryActivityShop cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryActivityShop> _dataCaches = null;
        public static Dictionary<int, DeclareMarryActivityShop> CacheData
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
                        if (HanderDefine.DataCallBack("MarryActivityShop", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryActivityShop cfg = null;
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
        private unsafe static DeclareMarryActivityShop LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryActivityShop();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._originalPrice = (int)GetValue(keyIndex, _originalPrice_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._discount = (int)GetValue(keyIndex, _discount_Index, ptr);
            tmp._limitBuy = (int)GetValue(keyIndex, _limitBuy_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryActivityShop", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("OriginalPrice", out _originalPrice_Index)) _originalPrice_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("Discount", out _discount_Index)) _discount_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitBuy", out _limitBuy_Index)) _limitBuy_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryActivityShop>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryActivityShop", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryActivityShop cfg = null;
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
        public static DeclareMarryActivityShop Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryActivityShop result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryActivityShop", out _compressData))
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
