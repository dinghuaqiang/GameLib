//文件是自动生成,请勿手动修改.来自数据文件:Leader_Preach_value
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareLeaderPreachValue
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _leader_Preach_fight_Index = -1;
        private static int _leader_Preach_award_Index = -1;
        private static int _min_level_Index = -1;
        private static int _max_level_Index = -1;
        private static int _lead_Index = -1;
        private static int _mapid_Index = -1;
        private static int _point_Index = -1;
        private static int _radius_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（最低等级）
        private int _id;
        //传道显示名字
        private int _name;
        //标准战斗力[@_@]
        private int _leader_Preach_fight;
        //每次经验奖励（4个难度依次填写）[@_@]
        private int _leader_Preach_award;
        //最小等级
        private int _min_level;
        //最大等级
        private int _max_level;
        //引导类型（hide）
        private int _lead;
        //传道的地图ID
        private int _mapid;
        //传道区域中心点
        private int _point;
        //传道区域半径
        private int _radius;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string LeaderPreachFight { get{ return HanderDefine.SetStingCallBack(_leader_Preach_fight); }}
        public string LeaderPreachAward { get{ return HanderDefine.SetStingCallBack(_leader_Preach_award); }}
        public int MinLevel { get{ return _min_level; }}
        public int MaxLevel { get{ return _max_level; }}
        public int Lead { get{ return _lead; }}
        public int Mapid { get{ return _mapid; }}
        public string Point { get{ return HanderDefine.SetStingCallBack(_point); }}
        public int Radius { get{ return _radius; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareLeaderPreachValue cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareLeaderPreachValue> _dataCaches = null;
        public static Dictionary<int, DeclareLeaderPreachValue> CacheData
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
                        if (HanderDefine.DataCallBack("LeaderPreachValue", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareLeaderPreachValue cfg = null;
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
        private unsafe static DeclareLeaderPreachValue LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareLeaderPreachValue();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._leader_Preach_fight = (int)GetValue(keyIndex, _leader_Preach_fight_Index, ptr);
            tmp._leader_Preach_award = (int)GetValue(keyIndex, _leader_Preach_award_Index, ptr);
            tmp._min_level = (int)GetValue(keyIndex, _min_level_Index, ptr);
            tmp._max_level = (int)GetValue(keyIndex, _max_level_Index, ptr);
            tmp._lead = (int)GetValue(keyIndex, _lead_Index, ptr);
            tmp._mapid = (int)GetValue(keyIndex, _mapid_Index, ptr);
            tmp._point = (int)GetValue(keyIndex, _point_Index, ptr);
            tmp._radius = (int)GetValue(keyIndex, _radius_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("LeaderPreachValue", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("LeaderPreachFight", out _leader_Preach_fight_Index)) _leader_Preach_fight_Index = -1;
                    if (!nameIndexs.TryGetValue("LeaderPreachAward", out _leader_Preach_award_Index)) _leader_Preach_award_Index = -1;
                    if (!nameIndexs.TryGetValue("MinLevel", out _min_level_Index)) _min_level_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _max_level_Index)) _max_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Lead", out _lead_Index)) _lead_Index = -1;
                    if (!nameIndexs.TryGetValue("Mapid", out _mapid_Index)) _mapid_Index = -1;
                    if (!nameIndexs.TryGetValue("Point", out _point_Index)) _point_Index = -1;
                    if (!nameIndexs.TryGetValue("Radius", out _radius_Index)) _radius_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareLeaderPreachValue>(keyCount);
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
            if(HanderDefine.DataCallBack("LeaderPreachValue", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareLeaderPreachValue cfg = null;
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
        public static DeclareLeaderPreachValue Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareLeaderPreachValue result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("LeaderPreachValue", out _compressData))
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
