//文件是自动生成,请勿手动修改.来自数据文件:marry_childAtt
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryChildAtt
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _nextLevel_Index = -1;
        private static int _childId_Index = -1;
        private static int _level_Index = -1;
        private static int _childName_Index = -1;
        private static int _consume_Index = -1;
        private static int _blessingValue_Index = -1;
        private static int _attributes_Index = -1;
        #endregion
        #region //私有变量定义
        //列表ID=itemCondition*100+stage
        private int _id;
        //下一级ID
        //(hide)
        private int _nextLevel;
        //仙娃ID激活
        //对应child表中ID
        private int _childId;
        //仙娃的对应等级
        private int _level;
        //仙娃名称（策划用）
        //程序不读取
        //（hide）
        private int _childName;
        //每升阶一次消耗的itemID和数量(@;@_@)
        private int _consume;
        //总祝福值
        private int _blessingValue;
        //增加的属性(@;@_@)
        private int _attributes;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int NextLevel { get{ return _nextLevel; }}
        public int ChildId { get{ return _childId; }}
        public int Level { get{ return _level; }}
        public string ChildName { get{ return HanderDefine.SetStingCallBack(_childName); }}
        public string Consume { get{ return HanderDefine.SetStingCallBack(_consume); }}
        public int BlessingValue { get{ return _blessingValue; }}
        public string Attributes { get{ return HanderDefine.SetStingCallBack(_attributes); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryChildAtt cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryChildAtt> _dataCaches = null;
        public static Dictionary<int, DeclareMarryChildAtt> CacheData
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
                        if (HanderDefine.DataCallBack("MarryChildAtt", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryChildAtt cfg = null;
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
        private unsafe static DeclareMarryChildAtt LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryChildAtt();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._nextLevel = (int)GetValue(keyIndex, _nextLevel_Index, ptr);
            tmp._childId = (int)GetValue(keyIndex, _childId_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._childName = (int)GetValue(keyIndex, _childName_Index, ptr);
            tmp._consume = (int)GetValue(keyIndex, _consume_Index, ptr);
            tmp._blessingValue = (int)GetValue(keyIndex, _blessingValue_Index, ptr);
            tmp._attributes = (int)GetValue(keyIndex, _attributes_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryChildAtt", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("NextLevel", out _nextLevel_Index)) _nextLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("ChildId", out _childId_Index)) _childId_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("ChildName", out _childName_Index)) _childName_Index = -1;
                    if (!nameIndexs.TryGetValue("Consume", out _consume_Index)) _consume_Index = -1;
                    if (!nameIndexs.TryGetValue("BlessingValue", out _blessingValue_Index)) _blessingValue_Index = -1;
                    if (!nameIndexs.TryGetValue("Attributes", out _attributes_Index)) _attributes_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryChildAtt>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryChildAtt", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryChildAtt cfg = null;
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
        public static DeclareMarryChildAtt Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryChildAtt result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryChildAtt", out _compressData))
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
