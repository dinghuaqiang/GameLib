//文件是自动生成,请勿手动修改.来自数据文件:UIConfig
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareUIConfig
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _parents_Index = -1;
        private static int _componentScript_Index = -1;
        private static int _openSFX_Index = -1;
        private static int _closeSFX_Index = -1;
        private static int _notchInScreenModel_Index = -1;
        private static int _isPauseTask_Index = -1;
        #endregion
        #region //私有变量定义
        //0
        private int _id;
        //UIPrefab名
        private int _name;
        //父窗体的Prefab名字如果有多个的话可以通过分号;来分割
        private int _parents;
        //UIComponent
        private int _componentScript;
        //开启音效
        private int _openSFX;
        //关闭音效
        private int _closeSFX;
        //刘海屏适配模式（0不适配，1适配左边，2适配右边，3两边适配）
        private int _notchInScreenModel;
        //是否挂起任务，关闭界面后继续执行任务（0：否 1：是）
        private int _isPauseTask;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Parents { get{ return HanderDefine.SetStingCallBack(_parents); }}
        public string ComponentScript { get{ return HanderDefine.SetStingCallBack(_componentScript); }}
        public string OpenSFX { get{ return HanderDefine.SetStingCallBack(_openSFX); }}
        public string CloseSFX { get{ return HanderDefine.SetStingCallBack(_closeSFX); }}
        public int NotchInScreenModel { get{ return _notchInScreenModel; }}
        public int IsPauseTask { get{ return _isPauseTask; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareUIConfig cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<string, DeclareUIConfig> _dataCaches = null;
        public static Dictionary<string, DeclareUIConfig> CacheData
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
                        if (HanderDefine.DataCallBack("UIConfig", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareUIConfig cfg = null;
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
        private static Dictionary<string, int> _dataIndexCaches = null;
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
        private unsafe static DeclareUIConfig LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareUIConfig();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._parents = (int)GetValue(keyIndex, _parents_Index, ptr);
            tmp._componentScript = (int)GetValue(keyIndex, _componentScript_Index, ptr);
            tmp._openSFX = (int)GetValue(keyIndex, _openSFX_Index, ptr);
            tmp._closeSFX = (int)GetValue(keyIndex, _closeSFX_Index, ptr);
            tmp._notchInScreenModel = (int)GetValue(keyIndex, _notchInScreenModel_Index, ptr);
            tmp._isPauseTask = (int)GetValue(keyIndex, _isPauseTask_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("UIConfig", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Parents", out _parents_Index)) _parents_Index = -1;
                    if (!nameIndexs.TryGetValue("ComponentScript", out _componentScript_Index)) _componentScript_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenSFX", out _openSFX_Index)) _openSFX_Index = -1;
                    if (!nameIndexs.TryGetValue("CloseSFX", out _closeSFX_Index)) _closeSFX_Index = -1;
                    if (!nameIndexs.TryGetValue("NotchInScreenModel", out _notchInScreenModel_Index)) _notchInScreenModel_Index = -1;
                    if (!nameIndexs.TryGetValue("IsPauseTask", out _isPauseTask_Index)) _isPauseTask_Index = -1;
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
                        _dataCaches = new Dictionary<string, DeclareUIConfig>(keyCount);
                        _dataIndexCaches = new Dictionary<string, int>(keyCount);
                        ptr = (int*)_compressData.ToPointer();
                        for (int i = 0; i < keyCount; i++)
                        {
                            var key = (int)GetValue(i, 1, ptr);
                            _dataIndexCaches.Add(HanderDefine.SetStingCallBack(key), i);
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
            if(HanderDefine.DataCallBack("UIConfig", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareUIConfig cfg = null;
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
        public static DeclareUIConfig Get(string id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareUIConfig result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("UIConfig", out _compressData))
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
