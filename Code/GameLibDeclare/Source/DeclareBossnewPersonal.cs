//文件是自动生成,请勿手动修改.来自数据文件:bossnew_Personal
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossnewPersonal
    {
        #region //静态变量定义
        private static int _monsterid_Index = -1;
        private static int _enterLevel_Index = -1;
        private static int _layer_Index = -1;
        private static int _power_Index = -1;
        private static int _if_Special_Index = -1;
        private static int _size_Index = -1;
        private static int _drop_Index = -1;
        private static int _revive_time_Index = -1;
        private static int _cloneID_Index = -1;
        private static int _mapsid_Index = -1;
        private static int _pos_Index = -1;
        #endregion
        #region //私有变量定义
        //怪物ID
        private int _monsterid;
        //进入所需等级
        private int _enterLevel;
        //阶数
        private int _layer;
        //推荐战力
        private int _power;
        //是否是特殊怪物，特殊怪物只会被召唤卡刷新出来（0，不是；1，是）
        private int _if_Special;
        //模型缩放hide
        private int _size;
        //显示掉落(@;@)hide
        private int _drop;
        //BOSS重生时间
        private int _revive_time;
        //副本地图
        private int _cloneID;
        //刷新地图
        private int _mapsid;
        //刷新坐标(@;@_@)
        private int _pos;
        #endregion

        #region //公共属性
        public int Monsterid { get{ return _monsterid; }}
        public int EnterLevel { get{ return _enterLevel; }}
        public int Layer { get{ return _layer; }}
        public int Power { get{ return _power; }}
        public int IfSpecial { get{ return _if_Special; }}
        public int Size { get{ return _size; }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public int ReviveTime { get{ return _revive_time; }}
        public int CloneID { get{ return _cloneID; }}
        public int Mapsid { get{ return _mapsid; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossnewPersonal cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossnewPersonal> _dataCaches = null;
        public static Dictionary<int, DeclareBossnewPersonal> CacheData
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
                        if (HanderDefine.DataCallBack("BossnewPersonal", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossnewPersonal cfg = null;
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
        private unsafe static DeclareBossnewPersonal LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossnewPersonal();
            tmp._monsterid = (int)GetValue(keyIndex, _monsterid_Index, ptr);
            tmp._enterLevel = (int)GetValue(keyIndex, _enterLevel_Index, ptr);
            tmp._layer = (int)GetValue(keyIndex, _layer_Index, ptr);
            tmp._power = (int)GetValue(keyIndex, _power_Index, ptr);
            tmp._if_Special = (int)GetValue(keyIndex, _if_Special_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._revive_time = (int)GetValue(keyIndex, _revive_time_Index, ptr);
            tmp._cloneID = (int)GetValue(keyIndex, _cloneID_Index, ptr);
            tmp._mapsid = (int)GetValue(keyIndex, _mapsid_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("BossnewPersonal", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Monsterid", out _monsterid_Index)) _monsterid_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterLevel", out _enterLevel_Index)) _enterLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Layer", out _layer_Index)) _layer_Index = -1;
                    if (!nameIndexs.TryGetValue("Power", out _power_Index)) _power_Index = -1;
                    if (!nameIndexs.TryGetValue("IfSpecial", out _if_Special_Index)) _if_Special_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("ReviveTime", out _revive_time_Index)) _revive_time_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneID", out _cloneID_Index)) _cloneID_Index = -1;
                    if (!nameIndexs.TryGetValue("Mapsid", out _mapsid_Index)) _mapsid_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossnewPersonal>();
                        _dataIndexCaches = new Dictionary<int, int>();
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
            if(HanderDefine.DataCallBack("BossnewPersonal", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossnewPersonal cfg = null;
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
        public static DeclareBossnewPersonal Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossnewPersonal result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("BossnewPersonal", out _compressData))
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
