//文件是自动生成,请勿手动修改.来自数据文件:social_house_market
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSocialHouseMarket
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _furnitureID_Index = -1;
        private static int _shopID_Index = -1;
        private static int _shopType_Index = -1;
        private static int _level_Index = -1;
        private static int _limitType_Index = -1;
        private static int _buyNum_Index = -1;
        private static int _currencyID_Index = -1;
        private static int _price_Index = -1;
        private static int _promotion_Index = -1;
        private static int _sort_Index = -1;
        #endregion
        #region //私有变量定义
        //商品ID
        //唯一ID
        private int _iD;
        //家具ID
        private int _furnitureID;
        //所属商城ID
        //1.房屋商城
        //2.人气商城
        //3.珍宝商城
        private int _shopID;
        //商城标签
        //1_2_3_4_5
        //对应ShopMenu里面的主键
        private int _shopType;
        //购买需求聚灵盆等级
        private int _level;
        //0.不限购；1.日限够；2.周限购；3.月限购；4.年限购；5.终身限购
        private int _limitType;
        //可购买次数
        //商品可购买次数:-1为无限
        private int _buyNum;
        //货币ID
        private int _currencyID;
        //价格
        private int _price;
        //促销标签
        //0.无
        //1.打折
        //2.推荐
        //3.新品
        //4.热卖
        //打折商品这个字段不能为0
        private int _promotion;
        //排列优先级
        private int _sort;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int FurnitureID { get{ return _furnitureID; }}
        public int ShopID { get{ return _shopID; }}
        public int ShopType { get{ return _shopType; }}
        public int Level { get{ return _level; }}
        public int LimitType { get{ return _limitType; }}
        public int BuyNum { get{ return _buyNum; }}
        public int CurrencyID { get{ return _currencyID; }}
        public int Price { get{ return _price; }}
        public int Promotion { get{ return _promotion; }}
        public int Sort { get{ return _sort; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSocialHouseMarket cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSocialHouseMarket> _dataCaches = null;
        public static Dictionary<int, DeclareSocialHouseMarket> CacheData
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
                        if (HanderDefine.DataCallBack("SocialHouseMarket", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSocialHouseMarket cfg = null;
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
        private unsafe static DeclareSocialHouseMarket LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSocialHouseMarket();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._furnitureID = (int)GetValue(keyIndex, _furnitureID_Index, ptr);
            tmp._shopID = (int)GetValue(keyIndex, _shopID_Index, ptr);
            tmp._shopType = (int)GetValue(keyIndex, _shopType_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._limitType = (int)GetValue(keyIndex, _limitType_Index, ptr);
            tmp._buyNum = (int)GetValue(keyIndex, _buyNum_Index, ptr);
            tmp._currencyID = (int)GetValue(keyIndex, _currencyID_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._promotion = (int)GetValue(keyIndex, _promotion_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SocialHouseMarket", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("FurnitureID", out _furnitureID_Index)) _furnitureID_Index = -1;
                    if (!nameIndexs.TryGetValue("ShopID", out _shopID_Index)) _shopID_Index = -1;
                    if (!nameIndexs.TryGetValue("ShopType", out _shopType_Index)) _shopType_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitType", out _limitType_Index)) _limitType_Index = -1;
                    if (!nameIndexs.TryGetValue("BuyNum", out _buyNum_Index)) _buyNum_Index = -1;
                    if (!nameIndexs.TryGetValue("CurrencyID", out _currencyID_Index)) _currencyID_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("Promotion", out _promotion_Index)) _promotion_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSocialHouseMarket>(keyCount);
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
            if(HanderDefine.DataCallBack("SocialHouseMarket", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSocialHouseMarket cfg = null;
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
        public static DeclareSocialHouseMarket Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSocialHouseMarket result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SocialHouseMarket", out _compressData))
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
