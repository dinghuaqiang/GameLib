//文件是自动生成,请勿手动修改.来自数据文件:today_function_task
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTodayFunctionTask
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _des_Index = -1;
        private static int _variable_Index = -1;
        private static int _reward_Index = -1;
        private static int _today_functionID_Index = -1;
        private static int _functionID_Index = -1;
        private static int _parm_Index = -1;
        private static int _if_after_open_Index = -1;
        private static int _show_count_Index = -1;
        #endregion
        #region //私有变量定义
        //key值
        private int _id;
        //任务类型（1，每日任务（每天刷新，每天都可以领奖)2.唯一任务（期间内不会刷新，只能领取一次奖励)
        private int _type;
        //任务描述
        private int _des;
        //任务条件
        private int _variable;
        //任务奖励
        private int _reward;
        //对应的核心玩法功能ID
        private int _today_functionID;
        //跳转的functionID
        private int _functionID;
        //跳转参数
        private int _parm;
        //在开启时是否检查角色的状态（0，不检查；1，检查）
        private int _if_after_open;
        //任务展示次数，根据核心玩法功能开启次数判断
        private int _show_count;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public string Variable { get{ return HanderDefine.SetStingCallBack(_variable); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string TodayFunctionID { get{ return HanderDefine.SetStingCallBack(_today_functionID); }}
        public int FunctionID { get{ return _functionID; }}
        public int Parm { get{ return _parm; }}
        public int IfAfterOpen { get{ return _if_after_open; }}
        public int ShowCount { get{ return _show_count; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTodayFunctionTask cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTodayFunctionTask> _dataCaches = null;
        public static Dictionary<int, DeclareTodayFunctionTask> CacheData
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
                        if (HanderDefine.DataCallBack("TodayFunctionTask", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTodayFunctionTask cfg = null;
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
        private unsafe static DeclareTodayFunctionTask LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTodayFunctionTask();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._variable = (int)GetValue(keyIndex, _variable_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._today_functionID = (int)GetValue(keyIndex, _today_functionID_Index, ptr);
            tmp._functionID = (int)GetValue(keyIndex, _functionID_Index, ptr);
            tmp._parm = (int)GetValue(keyIndex, _parm_Index, ptr);
            tmp._if_after_open = (int)GetValue(keyIndex, _if_after_open_Index, ptr);
            tmp._show_count = (int)GetValue(keyIndex, _show_count_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TodayFunctionTask", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("Variable", out _variable_Index)) _variable_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("TodayFunctionID", out _today_functionID_Index)) _today_functionID_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionID", out _functionID_Index)) _functionID_Index = -1;
                    if (!nameIndexs.TryGetValue("Parm", out _parm_Index)) _parm_Index = -1;
                    if (!nameIndexs.TryGetValue("IfAfterOpen", out _if_after_open_Index)) _if_after_open_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowCount", out _show_count_Index)) _show_count_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTodayFunctionTask>(keyCount);
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
            if(HanderDefine.DataCallBack("TodayFunctionTask", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTodayFunctionTask cfg = null;
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
        public static DeclareTodayFunctionTask Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTodayFunctionTask result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TodayFunctionTask", out _compressData))
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
