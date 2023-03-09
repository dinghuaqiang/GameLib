//文件是自动生成,请勿手动修改.来自数据文件:marry_lock
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryLock
    {
        #region //静态变量定义
        private static int _level_Index = -1;
        private static int _stage_Index = -1;
        private static int _grade_Index = -1;
        private static int _nextLv_Index = -1;
        private static int _name_Index = -1;
        private static int _attribute_Index = -1;
        private static int _marryAttribute_Index = -1;
        private static int _exp_Index = -1;
        private static int _costItem_Index = -1;
        private static int _singlexp_Index = -1;
        #endregion
        #region //私有变量定义
        //心锁阶级
        private int _level;
        //心锁阶数
        private int _stage;
        //心锁等级
        private int _grade;
        //下一级心锁等级(hide)
        private int _nextLv;
        //名称
        private int _name;
        //基础属性
        //属性类型_属性(@;@_@)
        private int _attribute;
        //仙侣属性
        //属性类型_属性(@;@_@)
        private int _marryAttribute;
        //升级需要经验
        //（当前级升级到下一级的经验）
        private int _exp;
        //升级消耗材料ID
        private int _costItem;
        //单个材料经验
        private int _singlexp;
        #endregion

        #region //公共属性
        public int Level { get{ return _level; }}
        public int Stage { get{ return _stage; }}
        public int Grade { get{ return _grade; }}
        public int NextLv { get{ return _nextLv; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string MarryAttribute { get{ return HanderDefine.SetStingCallBack(_marryAttribute); }}
        public int Exp { get{ return _exp; }}
        public string CostItem { get{ return HanderDefine.SetStingCallBack(_costItem); }}
        public string Singlexp { get{ return HanderDefine.SetStingCallBack(_singlexp); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryLock cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryLock> _dataCaches = null;
        public static Dictionary<int, DeclareMarryLock> CacheData
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
                        if (HanderDefine.DataCallBack("MarryLock", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryLock cfg = null;
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
        private unsafe static DeclareMarryLock LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryLock();
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._stage = (int)GetValue(keyIndex, _stage_Index, ptr);
            tmp._grade = (int)GetValue(keyIndex, _grade_Index, ptr);
            tmp._nextLv = (int)GetValue(keyIndex, _nextLv_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._marryAttribute = (int)GetValue(keyIndex, _marryAttribute_Index, ptr);
            tmp._exp = (int)GetValue(keyIndex, _exp_Index, ptr);
            tmp._costItem = (int)GetValue(keyIndex, _costItem_Index, ptr);
            tmp._singlexp = (int)GetValue(keyIndex, _singlexp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryLock", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Stage", out _stage_Index)) _stage_Index = -1;
                    if (!nameIndexs.TryGetValue("Grade", out _grade_Index)) _grade_Index = -1;
                    if (!nameIndexs.TryGetValue("NextLv", out _nextLv_Index)) _nextLv_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("MarryAttribute", out _marryAttribute_Index)) _marryAttribute_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("CostItem", out _costItem_Index)) _costItem_Index = -1;
                    if (!nameIndexs.TryGetValue("Singlexp", out _singlexp_Index)) _singlexp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryLock>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryLock", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryLock cfg = null;
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
        public static DeclareMarryLock Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryLock result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryLock", out _compressData))
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
