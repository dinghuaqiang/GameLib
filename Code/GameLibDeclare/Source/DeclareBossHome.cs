//文件是自动生成,请勿手动修改.来自数据文件:bossHome
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossHome
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _canShow_Index = -1;
        private static int _head_icon_Index = -1;
        private static int _bossLevel_Index = -1;
        private static int _power_Index = -1;
        private static int _drop_Index = -1;
        private static int _gold_drop_Index = -1;
        private static int _dropEquipShow_Index = -1;
        private static int _clone_map_Index = -1;
        #endregion
        #region //私有变量定义
        //编号ID，和monster表id一致
        private int _iD;
        //是否在列表中显示(0否1是)
        private int _canShow;
        //怪物头像
        private int _head_icon;
        //boss等级
        private int _bossLevel;
        //推荐战力
        private int _power;
        //显示掉落(@;@)hide
        private int _drop;
        //珍稀显示掉落(职业ID_道具ID)(@;@_@)hide
        private int _gold_drop;
        //掉落装备阶数
        private int _dropEquipShow;
        //刷新副本地图
        private int _clone_map;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int CanShow { get{ return _canShow; }}
        public int HeadIcon { get{ return _head_icon; }}
        public int BossLevel { get{ return _bossLevel; }}
        public int Power { get{ return _power; }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public string GoldDrop { get{ return HanderDefine.SetStingCallBack(_gold_drop); }}
        public int DropEquipShow { get{ return _dropEquipShow; }}
        public int CloneMap { get{ return _clone_map; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossHome cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossHome> _dataCaches = null;
        public static Dictionary<int, DeclareBossHome> CacheData
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
                        if (HanderDefine.DataCallBack("BossHome", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossHome cfg = null;
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
        private unsafe static DeclareBossHome LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossHome();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._canShow = (int)GetValue(keyIndex, _canShow_Index, ptr);
            tmp._head_icon = (int)GetValue(keyIndex, _head_icon_Index, ptr);
            tmp._bossLevel = (int)GetValue(keyIndex, _bossLevel_Index, ptr);
            tmp._power = (int)GetValue(keyIndex, _power_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._gold_drop = (int)GetValue(keyIndex, _gold_drop_Index, ptr);
            tmp._dropEquipShow = (int)GetValue(keyIndex, _dropEquipShow_Index, ptr);
            tmp._clone_map = (int)GetValue(keyIndex, _clone_map_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("BossHome", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("CanShow", out _canShow_Index)) _canShow_Index = -1;
                    if (!nameIndexs.TryGetValue("HeadIcon", out _head_icon_Index)) _head_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("BossLevel", out _bossLevel_Index)) _bossLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Power", out _power_Index)) _power_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("GoldDrop", out _gold_drop_Index)) _gold_drop_Index = -1;
                    if (!nameIndexs.TryGetValue("DropEquipShow", out _dropEquipShow_Index)) _dropEquipShow_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneMap", out _clone_map_Index)) _clone_map_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossHome>();
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
            if(HanderDefine.DataCallBack("BossHome", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossHome cfg = null;
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
        public static DeclareBossHome Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossHome result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("BossHome", out _compressData))
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
