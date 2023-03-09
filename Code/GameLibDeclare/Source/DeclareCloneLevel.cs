//文件是自动生成,请勿手动修改.来自数据文件:clone_level
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCloneLevel
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _clonemap_id_Index = -1;
        private static int _clone_level_Index = -1;
        private static int _describe_Index = -1;
        private static int _clone_level_des_Index = -1;
        private static int _level_icon_Index = -1;
        private static int _min_lv_Index = -1;
        private static int _max_lv_Index = -1;
        private static int _show_Award_Index = -1;
        private static int _extra_reward_Index = -1;
        #endregion
        #region //私有变量定义
        //编号（副本ID*100+难度）
        private int _id;
        //副本ID
        private int _clonemap_id;
        //副本的难度等级
        private int _clone_level;
        //副本的标题
        private int _describe;
        //副本的难度描述 hide
        private int _clone_level_des;
        //难度icon hide
        private int _level_icon;
        //进入所需最小等级
        private int _min_lv;
        //最高等级进入限制
        private int _max_lv;
        //活动参与奖励hide，只用于界面展示
        private int _show_Award;
        //副本特殊奖励【积分】：物品ID_数量_参数;物品ID_数量_参数[@;@_@]
        private int _extra_reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ClonemapId { get{ return _clonemap_id; }}
        public int CloneLevel { get{ return _clone_level; }}
        public string Describe { get{ return HanderDefine.SetStingCallBack(_describe); }}
        public string CloneLevelDes { get{ return HanderDefine.SetStingCallBack(_clone_level_des); }}
        public int LevelIcon { get{ return _level_icon; }}
        public int MinLv { get{ return _min_lv; }}
        public int MaxLv { get{ return _max_lv; }}
        public string ShowAward { get{ return HanderDefine.SetStingCallBack(_show_Award); }}
        public string ExtraReward { get{ return HanderDefine.SetStingCallBack(_extra_reward); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCloneLevel cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCloneLevel> _dataCaches = null;
        public static Dictionary<int, DeclareCloneLevel> CacheData
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
                        if (HanderDefine.DataCallBack("CloneLevel", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCloneLevel cfg = null;
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
        private unsafe static DeclareCloneLevel LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCloneLevel();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._clonemap_id = (int)GetValue(keyIndex, _clonemap_id_Index, ptr);
            tmp._clone_level = (int)GetValue(keyIndex, _clone_level_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            tmp._clone_level_des = (int)GetValue(keyIndex, _clone_level_des_Index, ptr);
            tmp._level_icon = (int)GetValue(keyIndex, _level_icon_Index, ptr);
            tmp._min_lv = (int)GetValue(keyIndex, _min_lv_Index, ptr);
            tmp._max_lv = (int)GetValue(keyIndex, _max_lv_Index, ptr);
            tmp._show_Award = (int)GetValue(keyIndex, _show_Award_Index, ptr);
            tmp._extra_reward = (int)GetValue(keyIndex, _extra_reward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CloneLevel", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ClonemapId", out _clonemap_id_Index)) _clonemap_id_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneLevel", out _clone_level_Index)) _clone_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneLevelDes", out _clone_level_des_Index)) _clone_level_des_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelIcon", out _level_icon_Index)) _level_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("MinLv", out _min_lv_Index)) _min_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLv", out _max_lv_Index)) _max_lv_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowAward", out _show_Award_Index)) _show_Award_Index = -1;
                    if (!nameIndexs.TryGetValue("ExtraReward", out _extra_reward_Index)) _extra_reward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCloneLevel>(keyCount);
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
            if(HanderDefine.DataCallBack("CloneLevel", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCloneLevel cfg = null;
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
        public static DeclareCloneLevel Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCloneLevel result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CloneLevel", out _compressData))
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
