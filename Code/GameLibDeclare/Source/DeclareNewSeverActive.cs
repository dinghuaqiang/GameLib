//文件是自动生成,请勿手动修改.来自数据文件:new_sever_active
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverActive
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _sort_Index = -1;
        private static int _special_condition_Index = -1;
        private static int _condition_Index = -1;
        private static int _des_Index = -1;
        private static int _limit_time_Index = -1;
        private static int _item_Index = -1;
        #endregion
        #region //私有变量定义
        //key用于标识
        private int _id;
        //表示类型
        //1.表示宗派之星
        //2.境界等级
        //3.结婚
        //4.联盟争霸
        private int _type;
        //排序
        private int _sort;
        //1.创建宗派
        //2.表示宗派之星中任命X个副宗主
        //3.宗派成员到达X个
        //4.宗派等级到达X级
        //5.完成结婚XX档次，玩家可以结3次
        //6.联盟争霸中霸主的宗主
        //7.联盟争霸中霸主帮会的积分排名多少到多少
        //8.联盟争霸中非霸主的宗派成员领取
        //9.联盟争霸中霸主宗派成员领取
        private int _special_condition;
        //达成的成就条件
        //条件都需要定义在functionVariable中
        private int _condition;
        //达成条件的描述
        private int _des;
        //该奖项的限制领取次数，在全服只能被领取指定的次数，默认为0表示不限制
        private int _limit_time;
        //展示的道具，实际给与的奖励
        private int _item;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Sort { get{ return _sort; }}
        public string SpecialCondition { get{ return HanderDefine.SetStingCallBack(_special_condition); }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public int LimitTime { get{ return _limit_time; }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverActive cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverActive> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverActive> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverActive", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverActive cfg = null;
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
        private unsafe static DeclareNewSeverActive LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverActive();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._special_condition = (int)GetValue(keyIndex, _special_condition_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._limit_time = (int)GetValue(keyIndex, _limit_time_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverActive", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialCondition", out _special_condition_Index)) _special_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitTime", out _limit_time_Index)) _limit_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverActive>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverActive", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverActive cfg = null;
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
        public static DeclareNewSeverActive Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverActive result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverActive", out _compressData))
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
