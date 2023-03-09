//文件是自动生成,请勿手动修改.来自数据文件:week_welfare
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareWeekWelfare
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _condition_Index = -1;
        private static int _functionId_Index = -1;
        private static int _desc_Index = -1;
        private static int _notice_Index = -1;
        private static int _reward_Index = -1;
        #endregion
        #region //私有变量定义
        //任务ID
        private int _id;
        //任务条件,对应FunctionVariable
        private int _condition;
        //功能Id
        private int _functionId;
        //任务描述，客户端界面显示用
        //（hide）
        private int _desc;
        //描述，策划用，无实际作用
        //（hide）
        private int _notice;
        //奖励
        //item_num_bind_occ
        //bind:0未绑定1绑定
        //occ：0男1女9通用
        private int _reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public int FunctionId { get{ return _functionId; }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string Notice { get{ return HanderDefine.SetStingCallBack(_notice); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareWeekWelfare cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareWeekWelfare> _dataCaches = null;
        public static Dictionary<int, DeclareWeekWelfare> CacheData
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
                        if (HanderDefine.DataCallBack("WeekWelfare", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareWeekWelfare cfg = null;
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
        private unsafe static DeclareWeekWelfare LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareWeekWelfare();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._functionId = (int)GetValue(keyIndex, _functionId_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._notice = (int)GetValue(keyIndex, _notice_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("WeekWelfare", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionId", out _functionId_Index)) _functionId_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Notice", out _notice_Index)) _notice_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareWeekWelfare>(keyCount);
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
            if(HanderDefine.DataCallBack("WeekWelfare", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareWeekWelfare cfg = null;
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
        public static DeclareWeekWelfare Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareWeekWelfare result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("WeekWelfare", out _compressData))
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
