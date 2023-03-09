//文件是自动生成,请勿手动修改.来自数据文件:VIPWeek
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVIPWeek
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _taskNum_Index = -1;
        private static int _condition_Index = -1;
        private static int _reward_Index = -1;
        private static int _desc_Index = -1;
        private static int _functionId_Index = -1;
        private static int _icon_Index = -1;
        #endregion
        #region //私有变量定义
        //奖励编号
        private int _id;
        //任务编号
        //任务组_子任务
        private int _taskNum;
        //ID对应FunctionVariable表里的ID
        private int _condition;
        //奖励尘晶数量（程序写死的奖励类型），用于领取周常奖励
        private int _reward;
        //特权文字描述（hide）
        private int _desc;
        //对应跳转的功能界面（hide），对应functionstart表主键
        private int _functionId;
        //每个任务类型对应显示的Icon(hide)
        private int _icon;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string TaskNum { get{ return HanderDefine.SetStingCallBack(_taskNum); }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public int Reward { get{ return _reward; }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int FunctionId { get{ return _functionId; }}
        public int Icon { get{ return _icon; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVIPWeek cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVIPWeek> _dataCaches = null;
        public static Dictionary<int, DeclareVIPWeek> CacheData
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
                        if (HanderDefine.DataCallBack("VIPWeek", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVIPWeek cfg = null;
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
        private unsafe static DeclareVIPWeek LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVIPWeek();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._taskNum = (int)GetValue(keyIndex, _taskNum_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._functionId = (int)GetValue(keyIndex, _functionId_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("VIPWeek", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskNum", out _taskNum_Index)) _taskNum_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionId", out _functionId_Index)) _functionId_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareVIPWeek>();
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
            if(HanderDefine.DataCallBack("VIPWeek", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVIPWeek cfg = null;
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
        public static DeclareVIPWeek Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVIPWeek result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("VIPWeek", out _compressData))
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
