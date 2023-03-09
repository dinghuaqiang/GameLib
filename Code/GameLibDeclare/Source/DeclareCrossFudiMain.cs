//文件是自动生成,请勿手动修改.来自数据文件:Cross_fudi_main
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossFudiMain
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _cross_stage_Index = -1;
        private static int _position_Index = -1;
        private static int _enter_position_Index = -1;
        private static int _line_Index = -1;
        private static int _clone_id_Index = -1;
        private static int _max_tianjin_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _refresh_time_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //跨服阶段
        private int _cross_stage;
        //福地等级（0，出生点；1，一级福地；2，二级福地；3，三级福地）
        private int _position;
        //占领该福地后能够进入的福地ID
        private int _enter_position;
        //连线
        private int _line;
        //对应的副本ID
        private int _clone_id;
        //每天的最大天禁值
        private int _max_tianjin;
        //福地名字显示hide
        private int _name;
        //城市图标hide
        private int _icon;
        //刷新时刻
        private int _refresh_time;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int CrossStage { get{ return _cross_stage; }}
        public int Position { get{ return _position; }}
        public string EnterPosition { get{ return HanderDefine.SetStingCallBack(_enter_position); }}
        public string Line { get{ return HanderDefine.SetStingCallBack(_line); }}
        public int CloneId { get{ return _clone_id; }}
        public int MaxTianjin { get{ return _max_tianjin; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public string RefreshTime { get{ return HanderDefine.SetStingCallBack(_refresh_time); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossFudiMain cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossFudiMain> _dataCaches = null;
        public static Dictionary<int, DeclareCrossFudiMain> CacheData
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
                        if (HanderDefine.DataCallBack("CrossFudiMain", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossFudiMain cfg = null;
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
        private unsafe static DeclareCrossFudiMain LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossFudiMain();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._cross_stage = (int)GetValue(keyIndex, _cross_stage_Index, ptr);
            tmp._position = (int)GetValue(keyIndex, _position_Index, ptr);
            tmp._enter_position = (int)GetValue(keyIndex, _enter_position_Index, ptr);
            tmp._line = (int)GetValue(keyIndex, _line_Index, ptr);
            tmp._clone_id = (int)GetValue(keyIndex, _clone_id_Index, ptr);
            tmp._max_tianjin = (int)GetValue(keyIndex, _max_tianjin_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._refresh_time = (int)GetValue(keyIndex, _refresh_time_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossFudiMain", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("CrossStage", out _cross_stage_Index)) _cross_stage_Index = -1;
                    if (!nameIndexs.TryGetValue("Position", out _position_Index)) _position_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterPosition", out _enter_position_Index)) _enter_position_Index = -1;
                    if (!nameIndexs.TryGetValue("Line", out _line_Index)) _line_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneId", out _clone_id_Index)) _clone_id_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxTianjin", out _max_tianjin_Index)) _max_tianjin_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("RefreshTime", out _refresh_time_Index)) _refresh_time_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossFudiMain>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossFudiMain", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossFudiMain cfg = null;
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
        public static DeclareCrossFudiMain Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossFudiMain result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossFudiMain", out _compressData))
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
