//文件是自动生成,请勿手动修改.来自数据文件:relive
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRelive
    {
        #region //静态变量定义
        private static int _relive_id_Index = -1;
        private static int _show_killer_name_Index = -1;
        private static int _auto_relive_type_Index = -1;
        private static int _auto_relive_time_Index = -1;
        private static int _button_type_Index = -1;
        private static int _safe_relive_time_Index = -1;
        private static int _situ_relive_time_Index = -1;
        private static int _situ_relive_add_time_Index = -1;
        private static int _situ_relive_recovery_time_Index = -1;
        private static int _isSeekHelp_Index = -1;
        #endregion
        #region //私有变量定义
        //复活KEYid
        private int _relive_id;
        //是否显示击杀者名字
        private int _show_killer_name;
        //自动复活类型（0不自动复活，1自动原地复活，2自动安全复活）
        private int _auto_relive_type;
        //自动复活的时间
        private int _auto_relive_time;
        //复活按钮显示（填空都不显示，0原地复活，1安全复活）
        private int _button_type;
        //安全复活的等待时间
        //按钮上的
        private int _safe_relive_time;
        //原地复活的初始等待时间
        //按钮上的
        private int _situ_relive_time;
        //原地复活的额外时间增量和最大时间
        private int _situ_relive_add_time;
        //原地复活额外时间的清除时间间隔
        private int _situ_relive_recovery_time;
        //死亡界面是否显示“求援”按钮，点击后可向在线的同盟成员求援
        //0不显示，1显示
        private int _isSeekHelp;
        #endregion

        #region //公共属性
        public int ReliveId { get{ return _relive_id; }}
        public int ShowKillerName { get{ return _show_killer_name; }}
        public int AutoReliveType { get{ return _auto_relive_type; }}
        public int AutoReliveTime { get{ return _auto_relive_time; }}
        public string ButtonType { get{ return HanderDefine.SetStingCallBack(_button_type); }}
        public int SafeReliveTime { get{ return _safe_relive_time; }}
        public int SituReliveTime { get{ return _situ_relive_time; }}
        public string SituReliveAddTime { get{ return HanderDefine.SetStingCallBack(_situ_relive_add_time); }}
        public int SituReliveRecoveryTime { get{ return _situ_relive_recovery_time; }}
        public int IsSeekHelp { get{ return _isSeekHelp; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRelive cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRelive> _dataCaches = null;
        public static Dictionary<int, DeclareRelive> CacheData
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
                        if (HanderDefine.DataCallBack("Relive", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRelive cfg = null;
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
        private unsafe static DeclareRelive LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRelive();
            tmp._relive_id = (int)GetValue(keyIndex, _relive_id_Index, ptr);
            tmp._show_killer_name = (int)GetValue(keyIndex, _show_killer_name_Index, ptr);
            tmp._auto_relive_type = (int)GetValue(keyIndex, _auto_relive_type_Index, ptr);
            tmp._auto_relive_time = (int)GetValue(keyIndex, _auto_relive_time_Index, ptr);
            tmp._button_type = (int)GetValue(keyIndex, _button_type_Index, ptr);
            tmp._safe_relive_time = (int)GetValue(keyIndex, _safe_relive_time_Index, ptr);
            tmp._situ_relive_time = (int)GetValue(keyIndex, _situ_relive_time_Index, ptr);
            tmp._situ_relive_add_time = (int)GetValue(keyIndex, _situ_relive_add_time_Index, ptr);
            tmp._situ_relive_recovery_time = (int)GetValue(keyIndex, _situ_relive_recovery_time_Index, ptr);
            tmp._isSeekHelp = (int)GetValue(keyIndex, _isSeekHelp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Relive", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ReliveId", out _relive_id_Index)) _relive_id_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowKillerName", out _show_killer_name_Index)) _show_killer_name_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoReliveType", out _auto_relive_type_Index)) _auto_relive_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoReliveTime", out _auto_relive_time_Index)) _auto_relive_time_Index = -1;
                    if (!nameIndexs.TryGetValue("ButtonType", out _button_type_Index)) _button_type_Index = -1;
                    if (!nameIndexs.TryGetValue("SafeReliveTime", out _safe_relive_time_Index)) _safe_relive_time_Index = -1;
                    if (!nameIndexs.TryGetValue("SituReliveTime", out _situ_relive_time_Index)) _situ_relive_time_Index = -1;
                    if (!nameIndexs.TryGetValue("SituReliveAddTime", out _situ_relive_add_time_Index)) _situ_relive_add_time_Index = -1;
                    if (!nameIndexs.TryGetValue("SituReliveRecoveryTime", out _situ_relive_recovery_time_Index)) _situ_relive_recovery_time_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSeekHelp", out _isSeekHelp_Index)) _isSeekHelp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRelive>(keyCount);
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
            if(HanderDefine.DataCallBack("Relive", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRelive cfg = null;
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
        public static DeclareRelive Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRelive result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Relive", out _compressData))
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
