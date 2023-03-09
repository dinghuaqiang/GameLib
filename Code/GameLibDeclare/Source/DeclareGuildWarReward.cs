//文件是自动生成,请勿手动修改.来自数据文件:guild_war_reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildWarReward
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _count_Index = -1;
        private static int _continueReward_Index = -1;
        private static int _endReward_Index = -1;
        private static int _showContinueReward_Index = -1;
        private static int _showEndReward_Index = -1;
        private static int _panguBuff_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //连胜场数
        private int _count;
        //连胜奖励
        //物品_数量_绑定
        //物品：对应item表主键
        //数量：对应奖励的数量
        //绑定：0未绑定1绑定
        private int _continueReward;
        //终结奖励
        private int _endReward;
        //连胜奖励（客户端显示用，解决无法将多个物品合在一起的问题）
        //（hide）
        private int _showContinueReward;
        //终结奖励（客户端显示用，解决无法将多个物品合在一起的问题）
        //（hide）
        private int _showEndReward;
        //盘古BUFF，当守城方处于连胜状态的时候，给攻城方增加的BUFF；对应BUFF表的ID
        private int _panguBuff;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Count { get{ return _count; }}
        public string ContinueReward { get{ return HanderDefine.SetStingCallBack(_continueReward); }}
        public string EndReward { get{ return HanderDefine.SetStingCallBack(_endReward); }}
        public string ShowContinueReward { get{ return HanderDefine.SetStingCallBack(_showContinueReward); }}
        public string ShowEndReward { get{ return HanderDefine.SetStingCallBack(_showEndReward); }}
        public int PanguBuff { get{ return _panguBuff; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildWarReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildWarReward> _dataCaches = null;
        public static Dictionary<int, DeclareGuildWarReward> CacheData
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
                        if (HanderDefine.DataCallBack("GuildWarReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildWarReward cfg = null;
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
        private unsafe static DeclareGuildWarReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildWarReward();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._count = (int)GetValue(keyIndex, _count_Index, ptr);
            tmp._continueReward = (int)GetValue(keyIndex, _continueReward_Index, ptr);
            tmp._endReward = (int)GetValue(keyIndex, _endReward_Index, ptr);
            tmp._showContinueReward = (int)GetValue(keyIndex, _showContinueReward_Index, ptr);
            tmp._showEndReward = (int)GetValue(keyIndex, _showEndReward_Index, ptr);
            tmp._panguBuff = (int)GetValue(keyIndex, _panguBuff_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildWarReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Count", out _count_Index)) _count_Index = -1;
                    if (!nameIndexs.TryGetValue("ContinueReward", out _continueReward_Index)) _continueReward_Index = -1;
                    if (!nameIndexs.TryGetValue("EndReward", out _endReward_Index)) _endReward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowContinueReward", out _showContinueReward_Index)) _showContinueReward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowEndReward", out _showEndReward_Index)) _showEndReward_Index = -1;
                    if (!nameIndexs.TryGetValue("PanguBuff", out _panguBuff_Index)) _panguBuff_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildWarReward>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildWarReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildWarReward cfg = null;
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
        public static DeclareGuildWarReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildWarReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildWarReward", out _compressData))
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
