//文件是自动生成,请勿手动修改.来自数据文件:shop_Maket
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareShopMaket
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _type_Index = -1;
        private static int _itemID_Index = -1;
        private static int _shopID_Index = -1;
        private static int _shopType_Index = -1;
        private static int _labelID_Index = -1;
        private static int _level_Index = -1;
        private static int _militaryLevel_Index = -1;
        private static int _guildLevel_Index = -1;
        private static int _guildShopLvlStart_Index = -1;
        private static int _guildShopLvlEND_Index = -1;
        private static int _vipLevel_Index = -1;
        private static int _occupation_Index = -1;
        private static int _limitType_Index = -1;
        private static int _buyNum_Index = -1;
        private static int _currencyID_Index = -1;
        private static int _price_Index = -1;
        private static int _discountPrice_Index = -1;
        private static int _discount_Index = -1;
        private static int _promotion_Index = -1;
        private static int _sort_Index = -1;
        private static int _upTime_Index = -1;
        private static int _downTime_Index = -1;
        private static int _overdue_Index = -1;
        private static int _duration_Index = -1;
        private static int _bind_Index = -1;
        private static int _refreshCurrency_Index = -1;
        private static int _refreshNum_Index = -1;
        private static int _worldLvlStart_Index = -1;
        private static int _worldLvlEND_Index = -1;
        private static int _openDay_Index = -1;
        private static int _closeDay_Index = -1;
        private static int _isDiscount_Index = -1;
        private static int _countDiscount_Index = -1;
        #endregion
        #region //私有变量定义
        //商品ID
        //唯一ID，不可重复.不可删除更改,只能添加
        //101开头表示游戏每日特惠商品
        //102开头表示游戏常用道具商品
        //20001开头表示游戏积分兑换商品
        //20002开头表示游戏寻宝积分商品
        //20003开头表示游戏阵道兑换商品
        //20004开头表示游戏帮贡兑换商品
        //20005开头表示游戏绑元商城商品
        //20006开头表示巅峰晋级荣誉币商品

        //30001开头表示公会福地兑换商品
        //40001开头表示公会商店兑换商品
        //50001开头表示混沌之境商店
        private int _iD;
        //1：商城（GM后台配置，运营控制）
        //0：商店（配置表控制）
        private int _type;
        //道具ID
        private int _itemID;
        //所属商城ID
        //1.元宝商城
        //2.兑换商城
        //3.福地积分商店
        //4.仙盟贡献商店
        //5.混沌之境商店
        //9:婚姻商城（只用于埋点，不可增加配置）
        private int _shopID;
        //商城标签
        //1_2_3_4_5
        //对应ShopMenu里面的主键
        private int _shopType;
        //商品标签页ID
        //区别不同的商城标签页
        //对应functionstart中ID
        private int _labelID;
        //购买需求等级
        private int _level;
        //购买需求军衔
        private int _militaryLevel;
        //购买需求帮会等级
        private int _guildLevel;
        //购买需求仙盟商店起始等级
        private int _guildShopLvlStart;
        //购买需求仙盟商店结束等级
        private int _guildShopLvlEND;
        //购买需求境界等级
        private int _vipLevel;
        //角色职业限制
        //-1.通用无限制
        //0.玄剑
        //1.天英
        private int _occupation;
        //0.不限购；1.日限够；2.周限购；3.月限购；4.年限购；5.终身限购
        private int _limitType;
        //可购买次数
        //商品可购买次数:-1为无限
        private int _buyNum;
        //货币ID
        //1、元宝
        //2、绑元
        //3、金币
        //10、成就点
        //11、帮贡
        //29、巅峰竞技荣誉币
        private int _currencyID;
        //打折前价格
        private int _price;
        //打折后价格
        private int _discountPrice;
        //打折数
        //0为不打折
        //>0为具体打折数
        private int _discount;
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
        //上架时间
        //物品上架的时间：年_月_日_时_分_秒，0则为即刻上架
        private int _upTime;
        //下架时间
        //物品下架的时间：年_月_日_时_分_秒，0为永不下架
        private int _downTime;
        //过期日期
        //物品过期时刻：年_月_日_时_分_秒，0则为即刻上架
        private int _overdue;
        //持续时间
        //购买后的使用倒计时
        private int _duration;
        //是否绑定
        //（0否 1是）
        private int _bind;
        //刷新使用货币类型，-1为不能刷新
        private int _refreshCurrency;
        //刷新货币消耗数量
        private int _refreshNum;
        //购买需求最低世界等级
        private int _worldLvlStart;
        //购买需求结束世界等级
        private int _worldLvlEND;
        //上架时间
        //根据开服天数
        //以当天0点为准
        private int _openDay;
        //下架时间
        //根据开服天数
        //以当天24点为准
        private int _closeDay;
        //开通修神锻体后是否打折，具体折扣读取修神锻体特权表
        //0代表不打折
        //1代表打折
        private int _isDiscount;
        //商品价格（价格约卖越高），不配置则代表不会随着购买次数增加价格
        //例：1_50_5;51_100_5(第一次购买到第五十次购买都是在原有价格上增加5，51次到100次就是增加10），如果可购买数量超过了配置数量，则读取最后一个值
        private int _countDiscount;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int Type { get{ return _type; }}
        public int ItemID { get{ return _itemID; }}
        public int ShopID { get{ return _shopID; }}
        public string ShopType { get{ return HanderDefine.SetStingCallBack(_shopType); }}
        public int LabelID { get{ return _labelID; }}
        public int Level { get{ return _level; }}
        public int MilitaryLevel { get{ return _militaryLevel; }}
        public int GuildLevel { get{ return _guildLevel; }}
        public int GuildShopLvlStart { get{ return _guildShopLvlStart; }}
        public int GuildShopLvlEND { get{ return _guildShopLvlEND; }}
        public int VipLevel { get{ return _vipLevel; }}
        public int Occupation { get{ return _occupation; }}
        public int LimitType { get{ return _limitType; }}
        public int BuyNum { get{ return _buyNum; }}
        public int CurrencyID { get{ return _currencyID; }}
        public int Price { get{ return _price; }}
        public int DiscountPrice { get{ return _discountPrice; }}
        public int Discount { get{ return _discount; }}
        public int Promotion { get{ return _promotion; }}
        public int Sort { get{ return _sort; }}
        public string UpTime { get{ return HanderDefine.SetStingCallBack(_upTime); }}
        public string DownTime { get{ return HanderDefine.SetStingCallBack(_downTime); }}
        public string Overdue { get{ return HanderDefine.SetStingCallBack(_overdue); }}
        public int Duration { get{ return _duration; }}
        public int Bind { get{ return _bind; }}
        public int RefreshCurrency { get{ return _refreshCurrency; }}
        public int RefreshNum { get{ return _refreshNum; }}
        public int WorldLvlStart { get{ return _worldLvlStart; }}
        public int WorldLvlEND { get{ return _worldLvlEND; }}
        public int OpenDay { get{ return _openDay; }}
        public int CloseDay { get{ return _closeDay; }}
        public int IsDiscount { get{ return _isDiscount; }}
        public string CountDiscount { get{ return HanderDefine.SetStingCallBack(_countDiscount); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareShopMaket cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareShopMaket> _dataCaches = null;
        public static Dictionary<int, DeclareShopMaket> CacheData
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
                        if (HanderDefine.DataCallBack("ShopMaket", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareShopMaket cfg = null;
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
        private unsafe static DeclareShopMaket LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareShopMaket();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._itemID = (int)GetValue(keyIndex, _itemID_Index, ptr);
            tmp._shopID = (int)GetValue(keyIndex, _shopID_Index, ptr);
            tmp._shopType = (int)GetValue(keyIndex, _shopType_Index, ptr);
            tmp._labelID = (int)GetValue(keyIndex, _labelID_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._militaryLevel = (int)GetValue(keyIndex, _militaryLevel_Index, ptr);
            tmp._guildLevel = (int)GetValue(keyIndex, _guildLevel_Index, ptr);
            tmp._guildShopLvlStart = (int)GetValue(keyIndex, _guildShopLvlStart_Index, ptr);
            tmp._guildShopLvlEND = (int)GetValue(keyIndex, _guildShopLvlEND_Index, ptr);
            tmp._vipLevel = (int)GetValue(keyIndex, _vipLevel_Index, ptr);
            tmp._occupation = (int)GetValue(keyIndex, _occupation_Index, ptr);
            tmp._limitType = (int)GetValue(keyIndex, _limitType_Index, ptr);
            tmp._buyNum = (int)GetValue(keyIndex, _buyNum_Index, ptr);
            tmp._currencyID = (int)GetValue(keyIndex, _currencyID_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._discountPrice = (int)GetValue(keyIndex, _discountPrice_Index, ptr);
            tmp._discount = (int)GetValue(keyIndex, _discount_Index, ptr);
            tmp._promotion = (int)GetValue(keyIndex, _promotion_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._upTime = (int)GetValue(keyIndex, _upTime_Index, ptr);
            tmp._downTime = (int)GetValue(keyIndex, _downTime_Index, ptr);
            tmp._overdue = (int)GetValue(keyIndex, _overdue_Index, ptr);
            tmp._duration = (int)GetValue(keyIndex, _duration_Index, ptr);
            tmp._bind = (int)GetValue(keyIndex, _bind_Index, ptr);
            tmp._refreshCurrency = (int)GetValue(keyIndex, _refreshCurrency_Index, ptr);
            tmp._refreshNum = (int)GetValue(keyIndex, _refreshNum_Index, ptr);
            tmp._worldLvlStart = (int)GetValue(keyIndex, _worldLvlStart_Index, ptr);
            tmp._worldLvlEND = (int)GetValue(keyIndex, _worldLvlEND_Index, ptr);
            tmp._openDay = (int)GetValue(keyIndex, _openDay_Index, ptr);
            tmp._closeDay = (int)GetValue(keyIndex, _closeDay_Index, ptr);
            tmp._isDiscount = (int)GetValue(keyIndex, _isDiscount_Index, ptr);
            tmp._countDiscount = (int)GetValue(keyIndex, _countDiscount_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ShopMaket", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemID", out _itemID_Index)) _itemID_Index = -1;
                    if (!nameIndexs.TryGetValue("ShopID", out _shopID_Index)) _shopID_Index = -1;
                    if (!nameIndexs.TryGetValue("ShopType", out _shopType_Index)) _shopType_Index = -1;
                    if (!nameIndexs.TryGetValue("LabelID", out _labelID_Index)) _labelID_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("MilitaryLevel", out _militaryLevel_Index)) _militaryLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildLevel", out _guildLevel_Index)) _guildLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildShopLvlStart", out _guildShopLvlStart_Index)) _guildShopLvlStart_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildShopLvlEND", out _guildShopLvlEND_Index)) _guildShopLvlEND_Index = -1;
                    if (!nameIndexs.TryGetValue("VipLevel", out _vipLevel_Index)) _vipLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Occupation", out _occupation_Index)) _occupation_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitType", out _limitType_Index)) _limitType_Index = -1;
                    if (!nameIndexs.TryGetValue("BuyNum", out _buyNum_Index)) _buyNum_Index = -1;
                    if (!nameIndexs.TryGetValue("CurrencyID", out _currencyID_Index)) _currencyID_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("DiscountPrice", out _discountPrice_Index)) _discountPrice_Index = -1;
                    if (!nameIndexs.TryGetValue("Discount", out _discount_Index)) _discount_Index = -1;
                    if (!nameIndexs.TryGetValue("Promotion", out _promotion_Index)) _promotion_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("UpTime", out _upTime_Index)) _upTime_Index = -1;
                    if (!nameIndexs.TryGetValue("DownTime", out _downTime_Index)) _downTime_Index = -1;
                    if (!nameIndexs.TryGetValue("Overdue", out _overdue_Index)) _overdue_Index = -1;
                    if (!nameIndexs.TryGetValue("Duration", out _duration_Index)) _duration_Index = -1;
                    if (!nameIndexs.TryGetValue("Bind", out _bind_Index)) _bind_Index = -1;
                    if (!nameIndexs.TryGetValue("RefreshCurrency", out _refreshCurrency_Index)) _refreshCurrency_Index = -1;
                    if (!nameIndexs.TryGetValue("RefreshNum", out _refreshNum_Index)) _refreshNum_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLvlStart", out _worldLvlStart_Index)) _worldLvlStart_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLvlEND", out _worldLvlEND_Index)) _worldLvlEND_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenDay", out _openDay_Index)) _openDay_Index = -1;
                    if (!nameIndexs.TryGetValue("CloseDay", out _closeDay_Index)) _closeDay_Index = -1;
                    if (!nameIndexs.TryGetValue("IsDiscount", out _isDiscount_Index)) _isDiscount_Index = -1;
                    if (!nameIndexs.TryGetValue("CountDiscount", out _countDiscount_Index)) _countDiscount_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareShopMaket>(keyCount);
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
            if(HanderDefine.DataCallBack("ShopMaket", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareShopMaket cfg = null;
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
        public static DeclareShopMaket Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareShopMaket result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ShopMaket", out _compressData))
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
