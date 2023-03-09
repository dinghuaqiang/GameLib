//文件是自动生成,请勿手动修改.来自数据文件:state_xisui_acupoint
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareStateXisuiAcupoint
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _group_Index = -1;
        private static int _prop_all_Index = -1;
        private static int _prop_star_all_Index = -1;
        private static int _prop_add_Index = -1;
        private static int _item_cost_Index = -1;
        private static int _coin_cost_Index = -1;
        private static int _vFX_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //星窍名
        private int _name;
        //洗髓玩法（1.玄体 2.灵体 3.金身 4.玉体 5.仙体）
        private int _group;
        //属性（覆盖）：属性类型_数值(@;@_@)
        private int _prop_all;
        //属性（累加）：属性类型_数值(@;@_@)
        private int _prop_star_all;
        //属性（累加）：属性类型_数值(@;@_@)
        private int _prop_add;
        //消耗道具ID_数量
        private int _item_cost;
        //消耗货币ID_数量
        private int _coin_cost;
        //点亮后的特效ID(hide)
        private int _vFX;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Group { get{ return _group; }}
        public string PropAll { get{ return HanderDefine.SetStingCallBack(_prop_all); }}
        public string PropStarAll { get{ return HanderDefine.SetStingCallBack(_prop_star_all); }}
        public string PropAdd { get{ return HanderDefine.SetStingCallBack(_prop_add); }}
        public string ItemCost { get{ return HanderDefine.SetStingCallBack(_item_cost); }}
        public string CoinCost { get{ return HanderDefine.SetStingCallBack(_coin_cost); }}
        public int VFX { get{ return _vFX; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareStateXisuiAcupoint cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareStateXisuiAcupoint> _dataCaches = null;
        public static Dictionary<int, DeclareStateXisuiAcupoint> CacheData
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
                        if (HanderDefine.DataCallBack("StateXisuiAcupoint", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareStateXisuiAcupoint cfg = null;
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
        private unsafe static DeclareStateXisuiAcupoint LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareStateXisuiAcupoint();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._prop_all = (int)GetValue(keyIndex, _prop_all_Index, ptr);
            tmp._prop_star_all = (int)GetValue(keyIndex, _prop_star_all_Index, ptr);
            tmp._prop_add = (int)GetValue(keyIndex, _prop_add_Index, ptr);
            tmp._item_cost = (int)GetValue(keyIndex, _item_cost_Index, ptr);
            tmp._coin_cost = (int)GetValue(keyIndex, _coin_cost_Index, ptr);
            tmp._vFX = (int)GetValue(keyIndex, _vFX_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("StateXisuiAcupoint", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("PropAll", out _prop_all_Index)) _prop_all_Index = -1;
                    if (!nameIndexs.TryGetValue("PropStarAll", out _prop_star_all_Index)) _prop_star_all_Index = -1;
                    if (!nameIndexs.TryGetValue("PropAdd", out _prop_add_Index)) _prop_add_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemCost", out _item_cost_Index)) _item_cost_Index = -1;
                    if (!nameIndexs.TryGetValue("CoinCost", out _coin_cost_Index)) _coin_cost_Index = -1;
                    if (!nameIndexs.TryGetValue("VFX", out _vFX_Index)) _vFX_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareStateXisuiAcupoint>(keyCount);
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
            if(HanderDefine.DataCallBack("StateXisuiAcupoint", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareStateXisuiAcupoint cfg = null;
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
        public static DeclareStateXisuiAcupoint Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareStateXisuiAcupoint result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("StateXisuiAcupoint", out _compressData))
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
