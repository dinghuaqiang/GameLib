//文件是自动生成,请勿手动修改.来自数据文件:GroundBuff
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGroundBuff
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _buff_id_Index = -1;
        private static int _res_Index = -1;
        private static int _logic_body_size_Index = -1;
        private static int _disValue_Index = -1;
        private static int _activeTimes_Index = -1;
        private static int _activeStep_Index = -1;
        private static int _groupNo_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        private int _id;
        //增加的buff id
        private int _buff_id;
        //使用的特效，other目录下的特效id
        private int _res;
        //碰撞半径（单位厘米）
        private int _logic_body_size;
        //生效的坐标距离差
        private int _disValue;
        //激活的次数，如果是临时则写1次就好
        private int _activeTimes;
        //激活的时间间隔
        private int _activeStep;
        //设置阵营，0为所有阵营都加 其它值与玩家的阵营相同就可以加，-1为怪物阵营
        private int _groupNo;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int BuffId { get{ return _buff_id; }}
        public int Res { get{ return _res; }}
        public int LogicBodySize { get{ return _logic_body_size; }}
        public int DisValue { get{ return _disValue; }}
        public int ActiveTimes { get{ return _activeTimes; }}
        public int ActiveStep { get{ return _activeStep; }}
        public int GroupNo { get{ return _groupNo; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGroundBuff cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGroundBuff> _dataCaches = null;
        public static Dictionary<int, DeclareGroundBuff> CacheData
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
                        if (HanderDefine.DataCallBack("GroundBuff", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGroundBuff cfg = null;
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
        private unsafe static DeclareGroundBuff LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGroundBuff();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._buff_id = (int)GetValue(keyIndex, _buff_id_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._logic_body_size = (int)GetValue(keyIndex, _logic_body_size_Index, ptr);
            tmp._disValue = (int)GetValue(keyIndex, _disValue_Index, ptr);
            tmp._activeTimes = (int)GetValue(keyIndex, _activeTimes_Index, ptr);
            tmp._activeStep = (int)GetValue(keyIndex, _activeStep_Index, ptr);
            tmp._groupNo = (int)GetValue(keyIndex, _groupNo_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GroundBuff", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("BuffId", out _buff_id_Index)) _buff_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("LogicBodySize", out _logic_body_size_Index)) _logic_body_size_Index = -1;
                    if (!nameIndexs.TryGetValue("DisValue", out _disValue_Index)) _disValue_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveTimes", out _activeTimes_Index)) _activeTimes_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveStep", out _activeStep_Index)) _activeStep_Index = -1;
                    if (!nameIndexs.TryGetValue("GroupNo", out _groupNo_Index)) _groupNo_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGroundBuff>(keyCount);
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
            if(HanderDefine.DataCallBack("GroundBuff", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGroundBuff cfg = null;
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
        public static DeclareGroundBuff Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGroundBuff result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GroundBuff", out _compressData))
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
