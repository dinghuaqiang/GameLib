//文件是自动生成,请勿手动修改.来自数据文件:marry_shop
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryShop
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _price_Index = -1;
        private static int _hot_Index = -1;
        private static int _use_max_Index = -1;
        private static int _exp_index_Index = -1;
        private static int _drop_item_Index = -1;
        private static int _vfx_id_Index = -1;
        private static int _is_play_other_Index = -1;
        #endregion
        #region //私有变量定义
        //列表ID
        private int _id;
        //对应价格
        private int _price;
        //单个增加的热度
        private int _hot;
        //每场使用上限
        private int _use_max;
        //获取经验的索引
        private int _exp_index;
        //使用时对应调用的掉落包ID（对应server_drop_item表主键）
        private int _drop_item;
        //使用播放的特效id obj目录下 （hide）
        private int _vfx_id;
        //是否播放其他玩家的特效（hide）
        private int _is_play_other;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Price { get{ return HanderDefine.SetStingCallBack(_price); }}
        public int Hot { get{ return _hot; }}
        public int UseMax { get{ return _use_max; }}
        public int ExpIndex { get{ return _exp_index; }}
        public int DropItem { get{ return _drop_item; }}
        public int VfxId { get{ return _vfx_id; }}
        public int IsPlayOther { get{ return _is_play_other; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryShop cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryShop> _dataCaches = null;
        public static Dictionary<int, DeclareMarryShop> CacheData
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
                        if (HanderDefine.DataCallBack("MarryShop", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryShop cfg = null;
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
        private unsafe static DeclareMarryShop LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryShop();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._hot = (int)GetValue(keyIndex, _hot_Index, ptr);
            tmp._use_max = (int)GetValue(keyIndex, _use_max_Index, ptr);
            tmp._exp_index = (int)GetValue(keyIndex, _exp_index_Index, ptr);
            tmp._drop_item = (int)GetValue(keyIndex, _drop_item_Index, ptr);
            tmp._vfx_id = (int)GetValue(keyIndex, _vfx_id_Index, ptr);
            tmp._is_play_other = (int)GetValue(keyIndex, _is_play_other_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryShop", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("Hot", out _hot_Index)) _hot_Index = -1;
                    if (!nameIndexs.TryGetValue("UseMax", out _use_max_Index)) _use_max_Index = -1;
                    if (!nameIndexs.TryGetValue("ExpIndex", out _exp_index_Index)) _exp_index_Index = -1;
                    if (!nameIndexs.TryGetValue("DropItem", out _drop_item_Index)) _drop_item_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxId", out _vfx_id_Index)) _vfx_id_Index = -1;
                    if (!nameIndexs.TryGetValue("IsPlayOther", out _is_play_other_Index)) _is_play_other_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryShop>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryShop", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryShop cfg = null;
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
        public static DeclareMarryShop Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryShop result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryShop", out _compressData))
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
