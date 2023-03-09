//文件是自动生成,请勿手动修改.来自数据文件:JJCRank
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareJJCRank
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _rankname_Index = -1;
        private static int _pos_mix_Index = -1;
        private static int _pos_max_Index = -1;
        private static int _enemy1_Index = -1;
        private static int _enemy1r_Index = -1;
        private static int _enemy2_Index = -1;
        private static int _enemy2r_Index = -1;
        private static int _enemy3_Index = -1;
        private static int _enemy3r_Index = -1;
        private static int _first_reward_item_Index = -1;
        private static int _rank_Index = -1;
        private static int _reward_Index = -1;
        #endregion
        #region //私有变量定义
        //奖励的唯一ID
        private int _id;
        //名字显示(hide)
        private int _rankname;
        //段位的最小名次
        private int _pos_mix;
        //段位的最大名词，用于首次
        private int _pos_max;
        //敌人1比我低最大
        private int _enemy1;
        //敌人1比我高最大
        private int _enemy1r;
        //敌人2比我低最大
        private int _enemy2;
        //敌人2比我高最大
        private int _enemy2r;
        //敌人3比我高最小
        private int _enemy3;
        //敌人3比我高最大
        private int _enemy3r;
        //首次到底排名奖励(@;@_@)
        private int _first_reward_item;
        //排名区间(@_@)
        //废弃
        private int _rank;
        //奖励(@;@_@)
        //废弃
        private int _reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Rankname { get{ return HanderDefine.SetStingCallBack(_rankname); }}
        public int PosMix { get{ return _pos_mix; }}
        public int PosMax { get{ return _pos_max; }}
        public int Enemy1 { get{ return _enemy1; }}
        public int Enemy1r { get{ return _enemy1r; }}
        public int Enemy2 { get{ return _enemy2; }}
        public int Enemy2r { get{ return _enemy2r; }}
        public int Enemy3 { get{ return _enemy3; }}
        public int Enemy3r { get{ return _enemy3r; }}
        public string FirstRewardItem { get{ return HanderDefine.SetStingCallBack(_first_reward_item); }}
        public string Rank { get{ return HanderDefine.SetStingCallBack(_rank); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareJJCRank cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareJJCRank> _dataCaches = null;
        public static Dictionary<int, DeclareJJCRank> CacheData
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
                        if (HanderDefine.DataCallBack("JJCRank", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareJJCRank cfg = null;
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
        private unsafe static DeclareJJCRank LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareJJCRank();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._rankname = (int)GetValue(keyIndex, _rankname_Index, ptr);
            tmp._pos_mix = (int)GetValue(keyIndex, _pos_mix_Index, ptr);
            tmp._pos_max = (int)GetValue(keyIndex, _pos_max_Index, ptr);
            tmp._enemy1 = (int)GetValue(keyIndex, _enemy1_Index, ptr);
            tmp._enemy1r = (int)GetValue(keyIndex, _enemy1r_Index, ptr);
            tmp._enemy2 = (int)GetValue(keyIndex, _enemy2_Index, ptr);
            tmp._enemy2r = (int)GetValue(keyIndex, _enemy2r_Index, ptr);
            tmp._enemy3 = (int)GetValue(keyIndex, _enemy3_Index, ptr);
            tmp._enemy3r = (int)GetValue(keyIndex, _enemy3r_Index, ptr);
            tmp._first_reward_item = (int)GetValue(keyIndex, _first_reward_item_Index, ptr);
            tmp._rank = (int)GetValue(keyIndex, _rank_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("JJCRank", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Rankname", out _rankname_Index)) _rankname_Index = -1;
                    if (!nameIndexs.TryGetValue("PosMix", out _pos_mix_Index)) _pos_mix_Index = -1;
                    if (!nameIndexs.TryGetValue("PosMax", out _pos_max_Index)) _pos_max_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy1", out _enemy1_Index)) _enemy1_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy1r", out _enemy1r_Index)) _enemy1r_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy2", out _enemy2_Index)) _enemy2_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy2r", out _enemy2r_Index)) _enemy2r_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy3", out _enemy3_Index)) _enemy3_Index = -1;
                    if (!nameIndexs.TryGetValue("Enemy3r", out _enemy3r_Index)) _enemy3r_Index = -1;
                    if (!nameIndexs.TryGetValue("FirstRewardItem", out _first_reward_item_Index)) _first_reward_item_Index = -1;
                    if (!nameIndexs.TryGetValue("Rank", out _rank_Index)) _rank_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareJJCRank>(keyCount);
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
            if(HanderDefine.DataCallBack("JJCRank", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareJJCRank cfg = null;
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
        public static DeclareJJCRank Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareJJCRank result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("JJCRank", out _compressData))
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
