//文件是自动生成,请勿手动修改.来自数据文件:Cross_Alien_Boss
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossAlienBoss
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _monsterId_Index = -1;
        private static int _mosterName_Index = -1;
        private static int _type_Index = -1;
        private static int _connectType_Index = -1;
        private static int _group_Index = -1;
        private static int _day_Index = -1;
        private static int _level_Index = -1;
        private static int _waitTime_Index = -1;
        private static int _pos_Index = -1;
        private static int _point_Index = -1;
        private static int _showDrop_Index = -1;
        #endregion
        #region //私有变量定义
        //编号ID
        private int _id;
        //怪物ID
        //对应monster表的主键
        private int _monsterId;
        //怪物显示名字
        //（hide）
        private int _mosterName;
        //BOSS类型
        //1：虚空副本首领
        //2：虚空副本精英
        private int _type;
        //BOSS所属副本类型
        //对应Cross_Alien_Connect的type字段
        private int _connectType;
        //用于客户端区分day和level的区间组，同一ID的为同一组，需要和两个字段匹配上
        //（hide）
        private int _group;
        //开服时间区间
        private int _day;
        //世界等级区间
        private int _level;
        //副本开启后间隔多久后刷新出怪物
        //单位（秒）
        //填0为默认刷新
        private int _waitTime;
        //出生位置，（x_y 表示地图坐标)(@;@_@)
        private int _pos;
        //击杀获得的积分
        //(积分最高的服务器可进入宝库）
        private int _point;
        //单BOSS展示的掉落
        //(hide)
        private int _showDrop;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int MonsterId { get{ return _monsterId; }}
        public string MosterName { get{ return HanderDefine.SetStingCallBack(_mosterName); }}
        public int Type { get{ return _type; }}
        public int ConnectType { get{ return _connectType; }}
        public int Group { get{ return _group; }}
        public string Day { get{ return HanderDefine.SetStingCallBack(_day); }}
        public string Level { get{ return HanderDefine.SetStingCallBack(_level); }}
        public int WaitTime { get{ return _waitTime; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Point { get{ return _point; }}
        public string ShowDrop { get{ return HanderDefine.SetStingCallBack(_showDrop); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossAlienBoss cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossAlienBoss> _dataCaches = null;
        public static Dictionary<int, DeclareCrossAlienBoss> CacheData
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
                        if (HanderDefine.DataCallBack("CrossAlienBoss", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossAlienBoss cfg = null;
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
        private unsafe static DeclareCrossAlienBoss LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossAlienBoss();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._monsterId = (int)GetValue(keyIndex, _monsterId_Index, ptr);
            tmp._mosterName = (int)GetValue(keyIndex, _mosterName_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._connectType = (int)GetValue(keyIndex, _connectType_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._waitTime = (int)GetValue(keyIndex, _waitTime_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._point = (int)GetValue(keyIndex, _point_Index, ptr);
            tmp._showDrop = (int)GetValue(keyIndex, _showDrop_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossAlienBoss", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterId", out _monsterId_Index)) _monsterId_Index = -1;
                    if (!nameIndexs.TryGetValue("MosterName", out _mosterName_Index)) _mosterName_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("ConnectType", out _connectType_Index)) _connectType_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("WaitTime", out _waitTime_Index)) _waitTime_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Point", out _point_Index)) _point_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowDrop", out _showDrop_Index)) _showDrop_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossAlienBoss>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossAlienBoss", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossAlienBoss cfg = null;
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
        public static DeclareCrossAlienBoss Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossAlienBoss result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossAlienBoss", out _compressData))
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
