//文件是自动生成,请勿手动修改.来自数据文件:RobotChat
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRobotChat
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _need_open_start_Index = -1;
        private static int _need_open_end_Index = -1;
        private static int _need_level_Index = -1;
        private static int _robot_cfg_Index = -1;
        private static int _chats_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        private int _id;
        //最小开服天数，0表示不限制
        private int _need_open_start;
        //最大开服天数，0表示不限制
        private int _need_open_end;
        //需求玩家等级
        private int _need_level;
        //机器人配置，几个就表示几个机器人，性别_等级最低_等级最高
        private int _robot_cfg;
        //机器人索引_延迟时间随机值开始_延迟时间随机值结束_说话内容
        private int _chats;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int NeedOpenStart { get{ return _need_open_start; }}
        public int NeedOpenEnd { get{ return _need_open_end; }}
        public int NeedLevel { get{ return _need_level; }}
        public string RobotCfg { get{ return HanderDefine.SetStingCallBack(_robot_cfg); }}
        public string Chats { get{ return HanderDefine.SetStingCallBack(_chats); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRobotChat cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRobotChat> _dataCaches = null;
        public static Dictionary<int, DeclareRobotChat> CacheData
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
                        if (HanderDefine.DataCallBack("RobotChat", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRobotChat cfg = null;
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
        private unsafe static DeclareRobotChat LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRobotChat();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._need_open_start = (int)GetValue(keyIndex, _need_open_start_Index, ptr);
            tmp._need_open_end = (int)GetValue(keyIndex, _need_open_end_Index, ptr);
            tmp._need_level = (int)GetValue(keyIndex, _need_level_Index, ptr);
            tmp._robot_cfg = (int)GetValue(keyIndex, _robot_cfg_Index, ptr);
            tmp._chats = (int)GetValue(keyIndex, _chats_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RobotChat", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedOpenStart", out _need_open_start_Index)) _need_open_start_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedOpenEnd", out _need_open_end_Index)) _need_open_end_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedLevel", out _need_level_Index)) _need_level_Index = -1;
                    if (!nameIndexs.TryGetValue("RobotCfg", out _robot_cfg_Index)) _robot_cfg_Index = -1;
                    if (!nameIndexs.TryGetValue("Chats", out _chats_Index)) _chats_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRobotChat>(keyCount);
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
            if(HanderDefine.DataCallBack("RobotChat", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRobotChat cfg = null;
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
        public static DeclareRobotChat Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRobotChat result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RobotChat", out _compressData))
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
