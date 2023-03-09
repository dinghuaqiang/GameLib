//文件是自动生成,请勿手动修改.来自数据文件:Equip_holy_type
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquipHolyType
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _openFunction_Index = -1;
        private static int _parts_list_Index = -1;
        private static int _max_level_Index = -1;
        private static int _hun_need_degree_Index = -1;
        private static int _hun_fashion_id_Index = -1;
        private static int _po_need_degree_Index = -1;
        private static int _po_fashion_id_Index = -1;
        private static int _awaken_degree_Index = -1;
        private static int _awaken_quality_Index = -1;
        private static int _awaken_hun_fashion_id_Index = -1;
        private static int _awaken_po_fashion_id_Index = -1;
        #endregion
        #region //私有变量定义
        //类型id
        private int _id;
        //类型名字
        private int _name;
        //开启天数，由开服时间决定
        private int _openFunction;
        //界面显示的部位
        private int _parts_list;
        //最大强化等级
        private int _max_level;
        //魂装外观要求阶数
        private int _hun_need_degree;
        //魂装激活给与的时装ID
        //填写fashion_total的主键
        //时装自带男女区分
        private int _hun_fashion_id;
        //魄装外观要求阶数
        private int _po_need_degree;
        //魄装激活给与的时装ID
        //填写fashion_total的主键
        //时装自带男女区分
        private int _po_fashion_id;
        //觉醒要求的最低阶数
        private int _awaken_degree;
        //觉醒要求最低品质
        private int _awaken_quality;
        //觉醒魂装给与的时装ID
        //填写fashion_total的主键
        //时装自带男女区分
        private int _awaken_hun_fashion_id;
        //觉醒魄装给与的时装ID
        //填写fashion_total的主键
        //时装自带男女区分
        private int _awaken_po_fashion_id;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int OpenFunction { get{ return _openFunction; }}
        public string PartsList { get{ return HanderDefine.SetStingCallBack(_parts_list); }}
        public int MaxLevel { get{ return _max_level; }}
        public int HunNeedDegree { get{ return _hun_need_degree; }}
        public int HunFashionId { get{ return _hun_fashion_id; }}
        public int PoNeedDegree { get{ return _po_need_degree; }}
        public int PoFashionId { get{ return _po_fashion_id; }}
        public int AwakenDegree { get{ return _awaken_degree; }}
        public int AwakenQuality { get{ return _awaken_quality; }}
        public int AwakenHunFashionId { get{ return _awaken_hun_fashion_id; }}
        public int AwakenPoFashionId { get{ return _awaken_po_fashion_id; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquipHolyType cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquipHolyType> _dataCaches = null;
        public static Dictionary<int, DeclareEquipHolyType> CacheData
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
                        if (HanderDefine.DataCallBack("EquipHolyType", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquipHolyType cfg = null;
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
        private unsafe static DeclareEquipHolyType LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquipHolyType();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._openFunction = (int)GetValue(keyIndex, _openFunction_Index, ptr);
            tmp._parts_list = (int)GetValue(keyIndex, _parts_list_Index, ptr);
            tmp._max_level = (int)GetValue(keyIndex, _max_level_Index, ptr);
            tmp._hun_need_degree = (int)GetValue(keyIndex, _hun_need_degree_Index, ptr);
            tmp._hun_fashion_id = (int)GetValue(keyIndex, _hun_fashion_id_Index, ptr);
            tmp._po_need_degree = (int)GetValue(keyIndex, _po_need_degree_Index, ptr);
            tmp._po_fashion_id = (int)GetValue(keyIndex, _po_fashion_id_Index, ptr);
            tmp._awaken_degree = (int)GetValue(keyIndex, _awaken_degree_Index, ptr);
            tmp._awaken_quality = (int)GetValue(keyIndex, _awaken_quality_Index, ptr);
            tmp._awaken_hun_fashion_id = (int)GetValue(keyIndex, _awaken_hun_fashion_id_Index, ptr);
            tmp._awaken_po_fashion_id = (int)GetValue(keyIndex, _awaken_po_fashion_id_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("EquipHolyType", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFunction", out _openFunction_Index)) _openFunction_Index = -1;
                    if (!nameIndexs.TryGetValue("PartsList", out _parts_list_Index)) _parts_list_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _max_level_Index)) _max_level_Index = -1;
                    if (!nameIndexs.TryGetValue("HunNeedDegree", out _hun_need_degree_Index)) _hun_need_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("HunFashionId", out _hun_fashion_id_Index)) _hun_fashion_id_Index = -1;
                    if (!nameIndexs.TryGetValue("PoNeedDegree", out _po_need_degree_Index)) _po_need_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("PoFashionId", out _po_fashion_id_Index)) _po_fashion_id_Index = -1;
                    if (!nameIndexs.TryGetValue("AwakenDegree", out _awaken_degree_Index)) _awaken_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("AwakenQuality", out _awaken_quality_Index)) _awaken_quality_Index = -1;
                    if (!nameIndexs.TryGetValue("AwakenHunFashionId", out _awaken_hun_fashion_id_Index)) _awaken_hun_fashion_id_Index = -1;
                    if (!nameIndexs.TryGetValue("AwakenPoFashionId", out _awaken_po_fashion_id_Index)) _awaken_po_fashion_id_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquipHolyType>(keyCount);
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
            if(HanderDefine.DataCallBack("EquipHolyType", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquipHolyType cfg = null;
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
        public static DeclareEquipHolyType Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquipHolyType result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EquipHolyType", out _compressData))
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
