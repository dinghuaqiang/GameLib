//文件是自动生成,请勿手动修改.来自数据文件:VipRebate
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVipRebate
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _taskdes_Index = -1;
        private static int _variableId_Index = -1;
        private static int _stageType_Index = -1;
        private static int _taskInherit_Index = -1;
        private static int _functionID_Index = -1;
        private static int _iconID_Index = -1;
        #endregion
        #region //私有变量定义
        //任务ID
        private int _id;
        //任务描述（hide）
        private int _taskdes;
        //条件在FunctionVariable配置
        private int _variableId;
        //任务处于第几阶段:0.第一阶段1.第二阶段2.第三阶段3.第四阶段
        private int _stageType;
        //是否继承前一页已完成信息：0.不继承，继承则为继承任务Id
        private int _taskInherit;
        //点击任务打开的Function界面（hide）
        private int _functionID;
        //任务卡牌显示IconID（hide）
        private int _iconID;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Taskdes { get{ return HanderDefine.SetStingCallBack(_taskdes); }}
        public string VariableId { get{ return HanderDefine.SetStingCallBack(_variableId); }}
        public int StageType { get{ return _stageType; }}
        public int TaskInherit { get{ return _taskInherit; }}
        public int FunctionID { get{ return _functionID; }}
        public int IconID { get{ return _iconID; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVipRebate cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVipRebate> _dataCaches = null;
        public static Dictionary<int, DeclareVipRebate> CacheData
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
                        if (HanderDefine.DataCallBack("VipRebate", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVipRebate cfg = null;
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
        private unsafe static DeclareVipRebate LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVipRebate();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._taskdes = (int)GetValue(keyIndex, _taskdes_Index, ptr);
            tmp._variableId = (int)GetValue(keyIndex, _variableId_Index, ptr);
            tmp._stageType = (int)GetValue(keyIndex, _stageType_Index, ptr);
            tmp._taskInherit = (int)GetValue(keyIndex, _taskInherit_Index, ptr);
            tmp._functionID = (int)GetValue(keyIndex, _functionID_Index, ptr);
            tmp._iconID = (int)GetValue(keyIndex, _iconID_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("VipRebate", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Taskdes", out _taskdes_Index)) _taskdes_Index = -1;
                    if (!nameIndexs.TryGetValue("VariableId", out _variableId_Index)) _variableId_Index = -1;
                    if (!nameIndexs.TryGetValue("StageType", out _stageType_Index)) _stageType_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskInherit", out _taskInherit_Index)) _taskInherit_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionID", out _functionID_Index)) _functionID_Index = -1;
                    if (!nameIndexs.TryGetValue("IconID", out _iconID_Index)) _iconID_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareVipRebate>(keyCount);
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
            if(HanderDefine.DataCallBack("VipRebate", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVipRebate cfg = null;
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
        public static DeclareVipRebate Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVipRebate result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("VipRebate", out _compressData))
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
