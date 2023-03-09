//文件是自动生成,请勿手动修改.来自数据文件:EightCity
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEightCity
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _level_Index = -1;
        private static int _reward_Index = -1;
        private static int _bossID_Index = -1;
        private static int _bossPos_Index = -1;
        private static int _canAttackCity_Index = -1;
        private static int _canAttackCityLine_Index = -1;
        private static int _modleID_Index = -1;
        #endregion
        #region //私有变量定义
        //城市ID
        private int _id;
        //城市名字
        private int _name;
        //城市等级
        private int _level;
        //占领之后的奖励配置
        private int _reward;
        //守城boss的ID
        private int _bossID;
        //守城BOSS的刷新位置
        private int _bossPos;
        //相邻的城市ID
        private int _canAttackCity;
        //线ID
        private int _canAttackCityLine;
        //副本ID
        private int _modleID;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Level { get{ return _level; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int BossID { get{ return _bossID; }}
        public string BossPos { get{ return HanderDefine.SetStingCallBack(_bossPos); }}
        public string CanAttackCity { get{ return HanderDefine.SetStingCallBack(_canAttackCity); }}
        public string CanAttackCityLine { get{ return HanderDefine.SetStingCallBack(_canAttackCityLine); }}
        public int ModleID { get{ return _modleID; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEightCity cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEightCity> _dataCaches = null;
        public static Dictionary<int, DeclareEightCity> CacheData
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
                        if (HanderDefine.DataCallBack("EightCity", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEightCity cfg = null;
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
        private unsafe static DeclareEightCity LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEightCity();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._bossID = (int)GetValue(keyIndex, _bossID_Index, ptr);
            tmp._bossPos = (int)GetValue(keyIndex, _bossPos_Index, ptr);
            tmp._canAttackCity = (int)GetValue(keyIndex, _canAttackCity_Index, ptr);
            tmp._canAttackCityLine = (int)GetValue(keyIndex, _canAttackCityLine_Index, ptr);
            tmp._modleID = (int)GetValue(keyIndex, _modleID_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("EightCity", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("BossID", out _bossID_Index)) _bossID_Index = -1;
                    if (!nameIndexs.TryGetValue("BossPos", out _bossPos_Index)) _bossPos_Index = -1;
                    if (!nameIndexs.TryGetValue("CanAttackCity", out _canAttackCity_Index)) _canAttackCity_Index = -1;
                    if (!nameIndexs.TryGetValue("CanAttackCityLine", out _canAttackCityLine_Index)) _canAttackCityLine_Index = -1;
                    if (!nameIndexs.TryGetValue("ModleID", out _modleID_Index)) _modleID_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEightCity>(keyCount);
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
            if(HanderDefine.DataCallBack("EightCity", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEightCity cfg = null;
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
        public static DeclareEightCity Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEightCity result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EightCity", out _compressData))
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
