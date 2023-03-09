//文件是自动生成,请勿手动修改.来自数据文件:RankAwardItem
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRankAwardItem
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _owner_id_Index = -1;
        private static int _award_type_Index = -1;
        private static int _top_rank_Index = -1;
        private static int _bottom_rank_Index = -1;
        private static int _need_value_Index = -1;
        private static int _max_get_count_Index = -1;
        private static int _award_items_Index = -1;
        #endregion
        #region //私有变量定义
        //key值
        //应服务器要求必须从1开始
        private int _id;
        //所属排名id
        //对应RankAwardType表主键
        private int _owner_id;
        //奖励类型
        //（0排名奖励,活动结束发奖励
        //1达成奖励，玩家自主领取）
        private int _award_type;
        //最高排名
        //（适用于排名奖励类型）
        private int _top_rank;
        //最低排名
        //（适用于排名奖励类型）
        private int _bottom_rank;
        //领取奖励需要达到的值（不同排行榜对应各自的值）
        //比如等级榜对应等级 （坐骑数值为阶*100+星）
        private int _need_value;
        //最大领取数量，为0表示不限制（适用于达成奖励类型）
        private int _max_get_count;
        //物品奖励，需要配置职业区分
        //itemid_num_bind_occ
        //bind:0不绑定，1绑定
        //occ：0男1女9通用
        private int _award_items;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int OwnerId { get{ return _owner_id; }}
        public int AwardType { get{ return _award_type; }}
        public int TopRank { get{ return _top_rank; }}
        public int BottomRank { get{ return _bottom_rank; }}
        public int NeedValue { get{ return _need_value; }}
        public int MaxGetCount { get{ return _max_get_count; }}
        public string AwardItems { get{ return HanderDefine.SetStingCallBack(_award_items); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRankAwardItem cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRankAwardItem> _dataCaches = null;
        public static Dictionary<int, DeclareRankAwardItem> CacheData
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
                        if (HanderDefine.DataCallBack("RankAwardItem", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRankAwardItem cfg = null;
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
        private unsafe static DeclareRankAwardItem LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRankAwardItem();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._owner_id = (int)GetValue(keyIndex, _owner_id_Index, ptr);
            tmp._award_type = (int)GetValue(keyIndex, _award_type_Index, ptr);
            tmp._top_rank = (int)GetValue(keyIndex, _top_rank_Index, ptr);
            tmp._bottom_rank = (int)GetValue(keyIndex, _bottom_rank_Index, ptr);
            tmp._need_value = (int)GetValue(keyIndex, _need_value_Index, ptr);
            tmp._max_get_count = (int)GetValue(keyIndex, _max_get_count_Index, ptr);
            tmp._award_items = (int)GetValue(keyIndex, _award_items_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RankAwardItem", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("OwnerId", out _owner_id_Index)) _owner_id_Index = -1;
                    if (!nameIndexs.TryGetValue("AwardType", out _award_type_Index)) _award_type_Index = -1;
                    if (!nameIndexs.TryGetValue("TopRank", out _top_rank_Index)) _top_rank_Index = -1;
                    if (!nameIndexs.TryGetValue("BottomRank", out _bottom_rank_Index)) _bottom_rank_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedValue", out _need_value_Index)) _need_value_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxGetCount", out _max_get_count_Index)) _max_get_count_Index = -1;
                    if (!nameIndexs.TryGetValue("AwardItems", out _award_items_Index)) _award_items_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRankAwardItem>(keyCount);
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
            if(HanderDefine.DataCallBack("RankAwardItem", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRankAwardItem cfg = null;
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
        public static DeclareRankAwardItem Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRankAwardItem result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RankAwardItem", out _compressData))
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
