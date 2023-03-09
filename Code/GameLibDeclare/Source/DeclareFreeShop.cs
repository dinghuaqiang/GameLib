//文件是自动生成,请勿手动修改.来自数据文件:free_shop
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFreeShop
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _item_Index = -1;
        private static int _name_Index = -1;
        private static int _itemTips_Index = -1;
        private static int _modelId_Index = -1;
        private static int _pos_Index = -1;
        private static int _power_Index = -1;
        private static int _price_Index = -1;
        private static int _returnPrice_Index = -1;
        private static int _time_Index = -1;
        private static int _rewardDaily_Index = -1;
        private static int _functionId_Index = -1;
        #endregion
        #region //私有变量定义
        //商城编号
        //编号ID必须和rechargeItem的ID保持一致
        private int _id;
        //ItemId_num_bind_occ
        //bind：0未绑定，1绑定
        //occ：0男1女9通用
        private int _item;
        //界面显示的名字
        //（hide）
        private int _name;
        //弹出对应item的物品tips
        //(废弃，客户端直接读取item）
        //（hide）
        private int _itemTips;
        //对应在界面上显示的模型ID，对应modeleconfig表
        //（hide）
        private int _modelId;
        //模型对应的显示
        //缩放_旋转（X_Y_Z)_位置（X_Y)_occ
        //occ:0男1女9通用
        //（hide）
        private int _pos;
        //界面显示战斗力
        //（hide）
        private int _power;
        //价格
        //type_value
        //type:-1=内购，type=其他值的时候对应item表的货币ID
        private int _price;
        //退回价格（原则上和原价相同，但是需要支持不同）,客户端显示用
        //type_value
        //type=对应item表的货币ID
        //(hide)
        private int _returnPrice;
        //返还价格的天数
        private int _time;
        //每天返还可领取货币
        private int _rewardDaily;
        //货币不足时，跳转对应的功能界面（废弃）
        //（hide）
        private int _functionId;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int ItemTips { get{ return _itemTips; }}
        public string ModelId { get{ return HanderDefine.SetStingCallBack(_modelId); }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Power { get{ return _power; }}
        public string Price { get{ return HanderDefine.SetStingCallBack(_price); }}
        public string ReturnPrice { get{ return HanderDefine.SetStingCallBack(_returnPrice); }}
        public int Time { get{ return _time; }}
        public string RewardDaily { get{ return HanderDefine.SetStingCallBack(_rewardDaily); }}
        public int FunctionId { get{ return _functionId; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFreeShop cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFreeShop> _dataCaches = null;
        public static Dictionary<int, DeclareFreeShop> CacheData
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
                        if (HanderDefine.DataCallBack("FreeShop", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFreeShop cfg = null;
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
        private unsafe static DeclareFreeShop LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFreeShop();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._itemTips = (int)GetValue(keyIndex, _itemTips_Index, ptr);
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._power = (int)GetValue(keyIndex, _power_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._returnPrice = (int)GetValue(keyIndex, _returnPrice_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._rewardDaily = (int)GetValue(keyIndex, _rewardDaily_Index, ptr);
            tmp._functionId = (int)GetValue(keyIndex, _functionId_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FreeShop", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemTips", out _itemTips_Index)) _itemTips_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Power", out _power_Index)) _power_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("ReturnPrice", out _returnPrice_Index)) _returnPrice_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardDaily", out _rewardDaily_Index)) _rewardDaily_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionId", out _functionId_Index)) _functionId_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFreeShop>(keyCount);
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
            if(HanderDefine.DataCallBack("FreeShop", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFreeShop cfg = null;
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
        public static DeclareFreeShop Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFreeShop result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FreeShop", out _compressData))
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
