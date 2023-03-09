//文件是自动生成,请勿手动修改.来自数据文件:GemstoneInlay
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGemstoneInlay
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _color_type_Index = -1;
        private static int _gemstone_id_Index = -1;
        private static int _limit_Number_Index = -1;
        private static int _location_condition_Index = -1;
        #endregion
        #region //私有变量定义
        //流水id(宝石=1000+部位；仙玉=2000+部位)
        private int _id;
        //宝石消耗颜色类型区分,同一类型的消耗材料要一致,用于智能精炼
        private int _color_type;
        //可镶嵌宝石id(按宝石等级 从小到大 配置)...宝石1id_宝石2id…(@_@)
        private int _gemstone_id;
        //开孔上限
        private int _limit_Number;
        //开孔条件.条件都需要定义在functionVariable中.1孔条件_数据;2孔的条件_数据;…….(@;@_@)
        private int _location_condition;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ColorType { get{ return _color_type; }}
        public string GemstoneId { get{ return HanderDefine.SetStingCallBack(_gemstone_id); }}
        public int LimitNumber { get{ return _limit_Number; }}
        public string LocationCondition { get{ return HanderDefine.SetStingCallBack(_location_condition); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGemstoneInlay cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGemstoneInlay> _dataCaches = null;
        public static Dictionary<int, DeclareGemstoneInlay> CacheData
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
                        if (HanderDefine.DataCallBack("GemstoneInlay", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGemstoneInlay cfg = null;
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
        private unsafe static DeclareGemstoneInlay LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGemstoneInlay();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._color_type = (int)GetValue(keyIndex, _color_type_Index, ptr);
            tmp._gemstone_id = (int)GetValue(keyIndex, _gemstone_id_Index, ptr);
            tmp._limit_Number = (int)GetValue(keyIndex, _limit_Number_Index, ptr);
            tmp._location_condition = (int)GetValue(keyIndex, _location_condition_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GemstoneInlay", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ColorType", out _color_type_Index)) _color_type_Index = -1;
                    if (!nameIndexs.TryGetValue("GemstoneId", out _gemstone_id_Index)) _gemstone_id_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitNumber", out _limit_Number_Index)) _limit_Number_Index = -1;
                    if (!nameIndexs.TryGetValue("LocationCondition", out _location_condition_Index)) _location_condition_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGemstoneInlay>(keyCount);
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
            if(HanderDefine.DataCallBack("GemstoneInlay", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGemstoneInlay cfg = null;
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
        public static DeclareGemstoneInlay Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGemstoneInlay result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GemstoneInlay", out _compressData))
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
