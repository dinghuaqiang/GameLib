//文件是自动生成,请勿手动修改.来自数据文件:GodWeaponQuality
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGodWeaponQuality
    {
        #region //静态变量定义
        private static int _groupId_Index = -1;
        private static int _item_Index = -1;
        private static int _quality_Index = -1;
        private static int _addAttribute_Index = -1;
        private static int _qualityIcon_Index = -1;
        private static int _maxLevel_Index = -1;
        #endregion
        #region //私有变量定义
        //ID,基础配置表中GROUP参数*100+Quality
        private int _groupId;
        //道具ID,道具数量(@;@_@)
        private int _item;
        //品质
        private int _quality;
        //每一级增加的当前模具的基础属性十万分比
        private int _addAttribute;
        //品质图片
        private int _qualityIcon;
        //开启对应升级表最大等级
        private int _maxLevel;
        #endregion

        #region //公共属性
        public int GroupId { get{ return _groupId; }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        public int Quality { get{ return _quality; }}
        public int AddAttribute { get{ return _addAttribute; }}
        public int QualityIcon { get{ return _qualityIcon; }}
        public int MaxLevel { get{ return _maxLevel; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGodWeaponQuality cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGodWeaponQuality> _dataCaches = null;
        public static Dictionary<int, DeclareGodWeaponQuality> CacheData
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
                        if (HanderDefine.DataCallBack("GodWeaponQuality", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGodWeaponQuality cfg = null;
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
        private unsafe static DeclareGodWeaponQuality LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGodWeaponQuality();
            tmp._groupId = (int)GetValue(keyIndex, _groupId_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._addAttribute = (int)GetValue(keyIndex, _addAttribute_Index, ptr);
            tmp._qualityIcon = (int)GetValue(keyIndex, _qualityIcon_Index, ptr);
            tmp._maxLevel = (int)GetValue(keyIndex, _maxLevel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GodWeaponQuality", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("GroupId", out _groupId_Index)) _groupId_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("AddAttribute", out _addAttribute_Index)) _addAttribute_Index = -1;
                    if (!nameIndexs.TryGetValue("QualityIcon", out _qualityIcon_Index)) _qualityIcon_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _maxLevel_Index)) _maxLevel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGodWeaponQuality>(keyCount);
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
            if(HanderDefine.DataCallBack("GodWeaponQuality", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGodWeaponQuality cfg = null;
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
        public static DeclareGodWeaponQuality Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGodWeaponQuality result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GodWeaponQuality", out _compressData))
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
