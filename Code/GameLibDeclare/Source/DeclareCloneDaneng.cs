//文件是自动生成,请勿手动修改.来自数据文件:clone_daneng
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCloneDaneng
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _monster_fight_num_Index = -1;
        private static int _min_lv_Index = -1;
        private static int _max_lv_Index = -1;
        private static int _monster_max_hp1_Index = -1;
        private static int _monster_max_hp2_Index = -1;
        private static int _monster_max_hp3_Index = -1;
        private static int _participation_Award_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        private int _id;
        //大BOSS的战斗力
        private int _monster_fight_num;
        //进入所需最小等级
        private int _min_lv;
        //最高等级进入限制
        private int _max_lv;
        //普通怪血量
        private int _monster_max_hp1;
        //精英怪血量
        private int _monster_max_hp2;
        //boss血量
        private int _monster_max_hp3;
        //活动参与奖励，只用于界面展示hide
        private int _participation_Award;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int MonsterFightNum { get{ return _monster_fight_num; }}
        public int MinLv { get{ return _min_lv; }}
        public int MaxLv { get{ return _max_lv; }}
        public int MonsterMaxHp1 { get{ return _monster_max_hp1; }}
        public int MonsterMaxHp2 { get{ return _monster_max_hp2; }}
        public int MonsterMaxHp3 { get{ return _monster_max_hp3; }}
        public string ParticipationAward { get{ return HanderDefine.SetStingCallBack(_participation_Award); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCloneDaneng cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCloneDaneng> _dataCaches = null;
        public static Dictionary<int, DeclareCloneDaneng> CacheData
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
                        if (HanderDefine.DataCallBack("CloneDaneng", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCloneDaneng cfg = null;
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
        private unsafe static DeclareCloneDaneng LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCloneDaneng();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._monster_fight_num = (int)GetValue(keyIndex, _monster_fight_num_Index, ptr);
            tmp._min_lv = (int)GetValue(keyIndex, _min_lv_Index, ptr);
            tmp._max_lv = (int)GetValue(keyIndex, _max_lv_Index, ptr);
            tmp._monster_max_hp1 = (int)GetValue(keyIndex, _monster_max_hp1_Index, ptr);
            tmp._monster_max_hp2 = (int)GetValue(keyIndex, _monster_max_hp2_Index, ptr);
            tmp._monster_max_hp3 = (int)GetValue(keyIndex, _monster_max_hp3_Index, ptr);
            tmp._participation_Award = (int)GetValue(keyIndex, _participation_Award_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CloneDaneng", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterFightNum", out _monster_fight_num_Index)) _monster_fight_num_Index = -1;
                    if (!nameIndexs.TryGetValue("MinLv", out _min_lv_Index)) _min_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLv", out _max_lv_Index)) _max_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterMaxHp1", out _monster_max_hp1_Index)) _monster_max_hp1_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterMaxHp2", out _monster_max_hp2_Index)) _monster_max_hp2_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterMaxHp3", out _monster_max_hp3_Index)) _monster_max_hp3_Index = -1;
                    if (!nameIndexs.TryGetValue("ParticipationAward", out _participation_Award_Index)) _participation_Award_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCloneDaneng>(keyCount);
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
            if(HanderDefine.DataCallBack("CloneDaneng", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCloneDaneng cfg = null;
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
        public static DeclareCloneDaneng Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCloneDaneng result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CloneDaneng", out _compressData))
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
