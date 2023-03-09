//文件是自动生成,请勿手动修改.来自数据文件:state
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareState
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _group_Index = -1;
        private static int _sort_Index = -1;
        private static int _condition_Index = -1;
        private static int _des_Index = -1;
        private static int _limit_type_Index = -1;
        private static int _limit_value_Index = -1;
        private static int _limit_describe_Index = -1;
        private static int _show_item_Index = -1;
        private static int _get_text_Index = -1;
        private static int _get_daily_active_Index = -1;
        #endregion
        #region //私有变量定义
        //境界的ID
        //=group*100+sort
        private int _id;
        //境界组，其他地方调用
        private int _group;
        //任务编号和排序
        private int _sort;
        //达成的成就条件(@_@)
        //条件都需要定义在functionVariable中
        private int _condition;
        //任务描述(hide)
        private int _des;
        //显示条件类型（1 等级 2 functionvariable表)(hide)
        private int _limit_type;
        //条件参数(hide)
        private int _limit_value;
        //条件描述（当条件为2时需要）(hide)
        private int _limit_describe;
        //用于跳转的道具(hide)用于读取跳转途径
        private int _show_item;
        //直接跳转到面板填面板ID（hide）
        private int _get_text;
        //跳转到日常面板的活动ID或者商店内物品ID（hide）
        private int _get_daily_active;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Group { get{ return _group; }}
        public int Sort { get{ return _sort; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public int LimitType { get{ return _limit_type; }}
        public int LimitValue { get{ return _limit_value; }}
        public string LimitDescribe { get{ return HanderDefine.SetStingCallBack(_limit_describe); }}
        public int ShowItem { get{ return _show_item; }}
        public int GetText { get{ return _get_text; }}
        public int GetDailyActive { get{ return _get_daily_active; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareState cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareState> _dataCaches = null;
        public static Dictionary<int, DeclareState> CacheData
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
                        if (HanderDefine.DataCallBack("State", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareState cfg = null;
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
        private unsafe static DeclareState LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareState();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._limit_type = (int)GetValue(keyIndex, _limit_type_Index, ptr);
            tmp._limit_value = (int)GetValue(keyIndex, _limit_value_Index, ptr);
            tmp._limit_describe = (int)GetValue(keyIndex, _limit_describe_Index, ptr);
            tmp._show_item = (int)GetValue(keyIndex, _show_item_Index, ptr);
            tmp._get_text = (int)GetValue(keyIndex, _get_text_Index, ptr);
            tmp._get_daily_active = (int)GetValue(keyIndex, _get_daily_active_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("State", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitType", out _limit_type_Index)) _limit_type_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitValue", out _limit_value_Index)) _limit_value_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitDescribe", out _limit_describe_Index)) _limit_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItem", out _show_item_Index)) _show_item_Index = -1;
                    if (!nameIndexs.TryGetValue("GetText", out _get_text_Index)) _get_text_Index = -1;
                    if (!nameIndexs.TryGetValue("GetDailyActive", out _get_daily_active_Index)) _get_daily_active_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareState>(keyCount);
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
            if(HanderDefine.DataCallBack("State", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareState cfg = null;
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
        public static DeclareState Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareState result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("State", out _compressData))
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
