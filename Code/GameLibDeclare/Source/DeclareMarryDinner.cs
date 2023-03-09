//文件是自动生成,请勿手动修改.来自数据文件:marry_dinner
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryDinner
    {
        #region //静态变量定义
        private static int _level_Index = -1;
        private static int _name_Index = -1;
        private static int _need_type_Index = -1;
        private static int _rewardItemList_Index = -1;
        private static int _jiebaiRewardItemList_Index = -1;
        private static int _dinner_Index = -1;
        private static int _title_Index = -1;
        private static int _friends_Index = -1;
        private static int _orderTime_Index = -1;
        #endregion
        #region //私有变量定义
        //宴席等级
        private int _level;
        //名称
        private int _name;
        //消耗的货币(@_@)
        private int _need_type;
        //给的物品列表(@;@_@)
        private int _rewardItemList;
        //给的物品列表(@;@_@)
        private int _jiebaiRewardItemList;
        //赠送婚宴ID
        private int _dinner;
        //称号图片，称号对应的图片显示
        //(hide)
        private int _title;
        //结婚所需所需好友度
        private int _friends;
        //可获得的婚宴次数
        private int _orderTime;
        #endregion

        #region //公共属性
        public int Level { get{ return _level; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string NeedType { get{ return HanderDefine.SetStingCallBack(_need_type); }}
        public string RewardItemList { get{ return HanderDefine.SetStingCallBack(_rewardItemList); }}
        public string JiebaiRewardItemList { get{ return HanderDefine.SetStingCallBack(_jiebaiRewardItemList); }}
        public int Dinner { get{ return _dinner; }}
        public string Title { get{ return HanderDefine.SetStingCallBack(_title); }}
        public int Friends { get{ return _friends; }}
        public int OrderTime { get{ return _orderTime; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryDinner cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryDinner> _dataCaches = null;
        public static Dictionary<int, DeclareMarryDinner> CacheData
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
                        if (HanderDefine.DataCallBack("MarryDinner", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryDinner cfg = null;
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
        private unsafe static DeclareMarryDinner LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryDinner();
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._need_type = (int)GetValue(keyIndex, _need_type_Index, ptr);
            tmp._rewardItemList = (int)GetValue(keyIndex, _rewardItemList_Index, ptr);
            tmp._jiebaiRewardItemList = (int)GetValue(keyIndex, _jiebaiRewardItemList_Index, ptr);
            tmp._dinner = (int)GetValue(keyIndex, _dinner_Index, ptr);
            tmp._title = (int)GetValue(keyIndex, _title_Index, ptr);
            tmp._friends = (int)GetValue(keyIndex, _friends_Index, ptr);
            tmp._orderTime = (int)GetValue(keyIndex, _orderTime_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryDinner", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedType", out _need_type_Index)) _need_type_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardItemList", out _rewardItemList_Index)) _rewardItemList_Index = -1;
                    if (!nameIndexs.TryGetValue("JiebaiRewardItemList", out _jiebaiRewardItemList_Index)) _jiebaiRewardItemList_Index = -1;
                    if (!nameIndexs.TryGetValue("Dinner", out _dinner_Index)) _dinner_Index = -1;
                    if (!nameIndexs.TryGetValue("Title", out _title_Index)) _title_Index = -1;
                    if (!nameIndexs.TryGetValue("Friends", out _friends_Index)) _friends_Index = -1;
                    if (!nameIndexs.TryGetValue("OrderTime", out _orderTime_Index)) _orderTime_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryDinner>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryDinner", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryDinner cfg = null;
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
        public static DeclareMarryDinner Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryDinner result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryDinner", out _compressData))
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
