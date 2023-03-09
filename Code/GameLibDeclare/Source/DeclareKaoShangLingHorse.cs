//文件是自动生成,请勿手动修改.来自数据文件:KaoShangLing_Horse
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareKaoShangLingHorse
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _rank_Index = -1;
        private static int _score_Index = -1;
        private static int _common_reward_Index = -1;
        private static int _specail_reward_Index = -1;
        private static int _if_end_Index = -1;
        private static int _if_Last_Index = -1;
        #endregion
        #region //私有变量定义
        //key值
        private int _id;
        //轮数
        private int _rank;
        //分数
        private int _score;
        //普通奖励
        private int _common_reward;
        //高级奖励
        private int _specail_reward;
        //是否为最后一轮
        private int _if_end;
        //是否是该轮的最后一组奖励（hide）
        private int _if_Last;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Rank { get{ return _rank; }}
        public int Score { get{ return _score; }}
        public string CommonReward { get{ return HanderDefine.SetStingCallBack(_common_reward); }}
        public string SpecailReward { get{ return HanderDefine.SetStingCallBack(_specail_reward); }}
        public int IfEnd { get{ return _if_end; }}
        public int IfLast { get{ return _if_Last; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareKaoShangLingHorse cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareKaoShangLingHorse> _dataCaches = null;
        public static Dictionary<int, DeclareKaoShangLingHorse> CacheData
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
                        if (HanderDefine.DataCallBack("KaoShangLingHorse", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareKaoShangLingHorse cfg = null;
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
        private unsafe static DeclareKaoShangLingHorse LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareKaoShangLingHorse();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._rank = (int)GetValue(keyIndex, _rank_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._common_reward = (int)GetValue(keyIndex, _common_reward_Index, ptr);
            tmp._specail_reward = (int)GetValue(keyIndex, _specail_reward_Index, ptr);
            tmp._if_end = (int)GetValue(keyIndex, _if_end_Index, ptr);
            tmp._if_Last = (int)GetValue(keyIndex, _if_Last_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("KaoShangLingHorse", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Rank", out _rank_Index)) _rank_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("CommonReward", out _common_reward_Index)) _common_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecailReward", out _specail_reward_Index)) _specail_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("IfEnd", out _if_end_Index)) _if_end_Index = -1;
                    if (!nameIndexs.TryGetValue("IfLast", out _if_Last_Index)) _if_Last_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareKaoShangLingHorse>(keyCount);
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
            if(HanderDefine.DataCallBack("KaoShangLingHorse", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareKaoShangLingHorse cfg = null;
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
        public static DeclareKaoShangLingHorse Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareKaoShangLingHorse result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("KaoShangLingHorse", out _compressData))
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
