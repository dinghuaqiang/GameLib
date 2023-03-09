//文件是自动生成,请勿手动修改.来自数据文件:FallingSky_Level
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFallingSkyLevel
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _goup_Index = -1;
        private static int _level_Index = -1;
        private static int _subGroup_Index = -1;
        private static int _exp_Index = -1;
        private static int _freeReward_Index = -1;
        private static int _payReward_Index = -1;
        private static int _showModel_Index = -1;
        private static int _showItem_Index = -1;
        #endregion
        #region //私有变量定义
        private int _id;
        //最大轮数由global进行处理，修改配置后必须对应修改global的最大轮数
        //1930 FallingSky_Round_Limit
        private int _goup;
        //等级
        private int _level;
        //分组信息（用于客户端进行当前组的最后一个展示）
        //hide
        private int _subGroup;
        //对应的材料和数量
        private int _exp;
        //免费版奖励
        private int _freeReward;
        //付费版奖励
        private int _payReward;
        //展示模型
        //ID_scr_posX_posY_rotX_rotY_rotZ_occ
        //（hide）
        private int _showModel;
        //点击模型展示的item预览
        //（hide）
        private int _showItem;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Goup { get{ return _goup; }}
        public int Level { get{ return _level; }}
        public int SubGroup { get{ return _subGroup; }}
        public string Exp { get{ return HanderDefine.SetStingCallBack(_exp); }}
        public string FreeReward { get{ return HanderDefine.SetStingCallBack(_freeReward); }}
        public string PayReward { get{ return HanderDefine.SetStingCallBack(_payReward); }}
        public string ShowModel { get{ return HanderDefine.SetStingCallBack(_showModel); }}
        public string ShowItem { get{ return HanderDefine.SetStingCallBack(_showItem); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFallingSkyLevel cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFallingSkyLevel> _dataCaches = null;
        public static Dictionary<int, DeclareFallingSkyLevel> CacheData
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
                        if (HanderDefine.DataCallBack("FallingSkyLevel", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFallingSkyLevel cfg = null;
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
        private unsafe static DeclareFallingSkyLevel LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFallingSkyLevel();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._goup = (int)GetValue(keyIndex, _goup_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._subGroup = (int)GetValue(keyIndex, _subGroup_Index, ptr);
            tmp._exp = (int)GetValue(keyIndex, _exp_Index, ptr);
            tmp._freeReward = (int)GetValue(keyIndex, _freeReward_Index, ptr);
            tmp._payReward = (int)GetValue(keyIndex, _payReward_Index, ptr);
            tmp._showModel = (int)GetValue(keyIndex, _showModel_Index, ptr);
            tmp._showItem = (int)GetValue(keyIndex, _showItem_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FallingSkyLevel", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Goup", out _goup_Index)) _goup_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("SubGroup", out _subGroup_Index)) _subGroup_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("FreeReward", out _freeReward_Index)) _freeReward_Index = -1;
                    if (!nameIndexs.TryGetValue("PayReward", out _payReward_Index)) _payReward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModel", out _showModel_Index)) _showModel_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItem", out _showItem_Index)) _showItem_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFallingSkyLevel>(keyCount);
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
            if(HanderDefine.DataCallBack("FallingSkyLevel", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFallingSkyLevel cfg = null;
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
        public static DeclareFallingSkyLevel Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFallingSkyLevel result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FallingSkyLevel", out _compressData))
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
