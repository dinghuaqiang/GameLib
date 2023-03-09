//文件是自动生成,请勿手动修改.来自数据文件:sign_reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSignReward
    {
        #region //静态变量定义
        private static int _day_Index = -1;
        private static int _itemId_Index = -1;
        private static int _itemNum_Index = -1;
        private static int _isBind_Index = -1;
        private static int _realmType_Index = -1;
        private static int _realmpara_Index = -1;
        private static int _realRatio_Index = -1;
        #endregion
        #region //私有变量定义
        //签到天数
        private int _day;
        //道具id
        private int _itemId;
        //道具数量
        private int _itemNum;
        //是否绑定（0不绑，1绑定）
        private int _isBind;
        //奖励加倍类型
        //1：境界
        //2：周卡
        //3：月卡
        //4：尊享卡
        //5：VIP
        //0：没有加倍
        private int _realmType;
        //类型参数
        //境界-境界等级
        //周卡-0
        //月卡-0
        //尊享卡-0
        //VIP-VIP等级
        private int _realmpara;
        //奖励倍率
        private int _realRatio;
        #endregion

        #region //公共属性
        public int Day { get{ return _day; }}
        public int ItemId { get{ return _itemId; }}
        public int ItemNum { get{ return _itemNum; }}
        public int IsBind { get{ return _isBind; }}
        public int RealmType { get{ return _realmType; }}
        public int Realmpara { get{ return _realmpara; }}
        public int RealRatio { get{ return _realRatio; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSignReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSignReward> _dataCaches = null;
        public static Dictionary<int, DeclareSignReward> CacheData
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
                        if (HanderDefine.DataCallBack("SignReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSignReward cfg = null;
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
        private unsafe static DeclareSignReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSignReward();
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._itemId = (int)GetValue(keyIndex, _itemId_Index, ptr);
            tmp._itemNum = (int)GetValue(keyIndex, _itemNum_Index, ptr);
            tmp._isBind = (int)GetValue(keyIndex, _isBind_Index, ptr);
            tmp._realmType = (int)GetValue(keyIndex, _realmType_Index, ptr);
            tmp._realmpara = (int)GetValue(keyIndex, _realmpara_Index, ptr);
            tmp._realRatio = (int)GetValue(keyIndex, _realRatio_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SignReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemId", out _itemId_Index)) _itemId_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemNum", out _itemNum_Index)) _itemNum_Index = -1;
                    if (!nameIndexs.TryGetValue("IsBind", out _isBind_Index)) _isBind_Index = -1;
                    if (!nameIndexs.TryGetValue("RealmType", out _realmType_Index)) _realmType_Index = -1;
                    if (!nameIndexs.TryGetValue("Realmpara", out _realmpara_Index)) _realmpara_Index = -1;
                    if (!nameIndexs.TryGetValue("RealRatio", out _realRatio_Index)) _realRatio_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSignReward>(keyCount);
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
            if(HanderDefine.DataCallBack("SignReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSignReward cfg = null;
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
        public static DeclareSignReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSignReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SignReward", out _compressData))
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
