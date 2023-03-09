//文件是自动生成,请勿手动修改.来自数据文件:immortal_soul_core
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareImmortalSoulCore
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _noactive_des_Index = -1;
        private static int _active_condition_Index = -1;
        private static int _quality_Index = -1;
        private static int _star_Index = -1;
        #endregion
        #region //私有变量定义
        //核心ID（所属剑灵）
        private int _iD;
        //名字(hide)
        private int _name;
        //ICON(hide)
        private int _icon;
        //未激活时显示的属性描述(hide)
        private int _noactive_des;
        //激活条件描述(hide)
        private int _active_condition;
        //品质
        private int _quality;
        //星级
        private int _star;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public string NoactiveDes { get{ return HanderDefine.SetStingCallBack(_noactive_des); }}
        public string ActiveCondition { get{ return HanderDefine.SetStingCallBack(_active_condition); }}
        public string Quality { get{ return HanderDefine.SetStingCallBack(_quality); }}
        public string Star { get{ return HanderDefine.SetStingCallBack(_star); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareImmortalSoulCore cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareImmortalSoulCore> _dataCaches = null;
        public static Dictionary<int, DeclareImmortalSoulCore> CacheData
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
                        if (HanderDefine.DataCallBack("ImmortalSoulCore", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareImmortalSoulCore cfg = null;
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
        private unsafe static DeclareImmortalSoulCore LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareImmortalSoulCore();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._noactive_des = (int)GetValue(keyIndex, _noactive_des_Index, ptr);
            tmp._active_condition = (int)GetValue(keyIndex, _active_condition_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ImmortalSoulCore", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("NoactiveDes", out _noactive_des_Index)) _noactive_des_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveCondition", out _active_condition_Index)) _active_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareImmortalSoulCore>(keyCount);
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
            if(HanderDefine.DataCallBack("ImmortalSoulCore", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareImmortalSoulCore cfg = null;
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
        public static DeclareImmortalSoulCore Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareImmortalSoulCore result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ImmortalSoulCore", out _compressData))
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
