//文件是自动生成,请勿手动修改.来自数据文件:xianmengzhengba
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareXianmengzhengba
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _designDesc_Index = -1;
        private static int _activeType_Index = -1;
        private static int _value_Index = -1;
        private static int _reward_Index = -1;
        private static int _sort_Index = -1;
        private static int _desc_Index = -1;
        private static int _functionId_Index = -1;
        #endregion
        #region //私有变量定义
        //排序id
        private int _id;
        //描述（策划用，无实际意义）
        private int _designDesc;
        //1.仙盟发展2.仙盟征战3.仙盟争夺
        private int _activeType;
        //对应FunctionVariable表的值
        private int _value;
        //奖励
        //ItemID_num_bind_occ
        //bind:0不绑定1绑定
        //occ：0男1女9通用
        private int _reward;
        //客户端用任务列表排序
        private int _sort;
        //客户端显示用
        private int _desc;
        //对应跳转的功能ID
        //对应FunctionStart表主键
        private int _functionId;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string DesignDesc { get{ return HanderDefine.SetStingCallBack(_designDesc); }}
        public int ActiveType { get{ return _activeType; }}
        public string Value { get{ return HanderDefine.SetStingCallBack(_value); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int Sort { get{ return _sort; }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int FunctionId { get{ return _functionId; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareXianmengzhengba cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareXianmengzhengba> _dataCaches = null;
        public static Dictionary<int, DeclareXianmengzhengba> CacheData
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
                        if (HanderDefine.DataCallBack("Xianmengzhengba", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareXianmengzhengba cfg = null;
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
        private unsafe static DeclareXianmengzhengba LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareXianmengzhengba();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._designDesc = (int)GetValue(keyIndex, _designDesc_Index, ptr);
            tmp._activeType = (int)GetValue(keyIndex, _activeType_Index, ptr);
            tmp._value = (int)GetValue(keyIndex, _value_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._functionId = (int)GetValue(keyIndex, _functionId_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Xianmengzhengba", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("DesignDesc", out _designDesc_Index)) _designDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveType", out _activeType_Index)) _activeType_Index = -1;
                    if (!nameIndexs.TryGetValue("Value", out _value_Index)) _value_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionId", out _functionId_Index)) _functionId_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareXianmengzhengba>(keyCount);
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
            if(HanderDefine.DataCallBack("Xianmengzhengba", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareXianmengzhengba cfg = null;
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
        public static DeclareXianmengzhengba Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareXianmengzhengba result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Xianmengzhengba", out _compressData))
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
