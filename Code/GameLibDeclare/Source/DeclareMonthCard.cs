//文件是自动生成,请勿手动修改.来自数据文件:month_card
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMonthCard
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _day_Index = -1;
        private static int _cost_Index = -1;
        private static int _nowitem_Index = -1;
        private static int _dayAddItem_Index = -1;
        private static int _expAddPer_Index = -1;
        private static int _icon_Index = -1;
        private static int _texture_Index = -1;
        private static int _magicBowl_Index = -1;
        private static int _totalReward_Index = -1;
        #endregion
        #region //私有变量定义
        //月卡尊享卡表
        //（程序写死处理的ID，不能轻易改变，如果改变需要通知客户端
        private int _id;
        //名称hide
        private int _name;
        //可领天数，-1为永久
        private int _day;
        //激活花费货币类型_货币数量
        //0代表内购，走rechargeitem
        //非0代表货币，走item表
        private int _cost;
        //首次激活获得的id_num_是否绑定（0否 1是）(@;@_@)
        private int _nowitem;
        //每天可领的id_num_是否绑定（0否 1是）(@;@_@)
        private int _dayAddItem;
        //经验额外百分比加成（额外考虑是否保留）
        private int _expAddPer;
        //对应icon显示hide
        private int _icon;
        //对应图片显示hide
        private int _texture;
        //特权卡对应聚宝盆激活的加成（万分比）
        //废弃
        private int _magicBowl;
        //界面显示奖励总额
        //（hide）
        private int _totalReward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Day { get{ return _day; }}
        public string Cost { get{ return HanderDefine.SetStingCallBack(_cost); }}
        public string Nowitem { get{ return HanderDefine.SetStingCallBack(_nowitem); }}
        public string DayAddItem { get{ return HanderDefine.SetStingCallBack(_dayAddItem); }}
        public int ExpAddPer { get{ return _expAddPer; }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string Texture { get{ return HanderDefine.SetStingCallBack(_texture); }}
        public int MagicBowl { get{ return _magicBowl; }}
        public int TotalReward { get{ return _totalReward; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMonthCard cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMonthCard> _dataCaches = null;
        public static Dictionary<int, DeclareMonthCard> CacheData
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
                        if (HanderDefine.DataCallBack("MonthCard", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMonthCard cfg = null;
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
        private unsafe static DeclareMonthCard LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMonthCard();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._cost = (int)GetValue(keyIndex, _cost_Index, ptr);
            tmp._nowitem = (int)GetValue(keyIndex, _nowitem_Index, ptr);
            tmp._dayAddItem = (int)GetValue(keyIndex, _dayAddItem_Index, ptr);
            tmp._expAddPer = (int)GetValue(keyIndex, _expAddPer_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._texture = (int)GetValue(keyIndex, _texture_Index, ptr);
            tmp._magicBowl = (int)GetValue(keyIndex, _magicBowl_Index, ptr);
            tmp._totalReward = (int)GetValue(keyIndex, _totalReward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MonthCard", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("Cost", out _cost_Index)) _cost_Index = -1;
                    if (!nameIndexs.TryGetValue("Nowitem", out _nowitem_Index)) _nowitem_Index = -1;
                    if (!nameIndexs.TryGetValue("DayAddItem", out _dayAddItem_Index)) _dayAddItem_Index = -1;
                    if (!nameIndexs.TryGetValue("ExpAddPer", out _expAddPer_Index)) _expAddPer_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Texture", out _texture_Index)) _texture_Index = -1;
                    if (!nameIndexs.TryGetValue("MagicBowl", out _magicBowl_Index)) _magicBowl_Index = -1;
                    if (!nameIndexs.TryGetValue("TotalReward", out _totalReward_Index)) _totalReward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMonthCard>(keyCount);
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
            if(HanderDefine.DataCallBack("MonthCard", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMonthCard cfg = null;
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
        public static DeclareMonthCard Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMonthCard result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MonthCard", out _compressData))
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
