//文件是自动生成,请勿手动修改.来自数据文件:task_littletalk
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTaskLittletalk
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _conditions_value_Index = -1;
        private static int _conditions_value_param_Index = -1;
        private static int _repeat_Index = -1;
        private static int _model_Index = -1;
        private static int _size_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _nextid_Index = -1;
        private static int _content_Index = -1;
        private static int _speech_Index = -1;
        private static int _delayTime_Index = -1;
        private static int _showTime_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //条件类型2.等级到达3.任务完成4.进入地图13.杀死某个怪14.获得物品15.境界达到多少级16.法宝达到多少级
        private int _conditions_value;
        //条件参数
        private int _conditions_value_param;
        //可重复触发次数（-1只能触发一次，0无限次，其他就是配置多少次就是多少次）
        private int _repeat;
        //NPC ID
        private int _model;
        //模型缩放
        private int _size;
        //模型上下偏移
        private int _model_y_pos;
        //下一个id(0结束)
        private int _nextid;
        //对白
        private int _content;
        //语音资源名 hide
        private int _speech;
        //延迟出现时间
        private int _delayTime;
        //显示时间
        private int _showTime;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ConditionsValue { get{ return _conditions_value; }}
        public int ConditionsValueParam { get{ return _conditions_value_param; }}
        public int Repeat { get{ return _repeat; }}
        public int Model { get{ return _model; }}
        public int Size { get{ return _size; }}
        public int ModelYPos { get{ return _model_y_pos; }}
        public int Nextid { get{ return _nextid; }}
        public string Content { get{ return HanderDefine.SetStingCallBack(_content); }}
        public string Speech { get{ return HanderDefine.SetStingCallBack(_speech); }}
        public int DelayTime { get{ return _delayTime; }}
        public int ShowTime { get{ return _showTime; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTaskLittletalk cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTaskLittletalk> _dataCaches = null;
        public static Dictionary<int, DeclareTaskLittletalk> CacheData
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
                        if (HanderDefine.DataCallBack("TaskLittletalk", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTaskLittletalk cfg = null;
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
        private unsafe static DeclareTaskLittletalk LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTaskLittletalk();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._conditions_value = (int)GetValue(keyIndex, _conditions_value_Index, ptr);
            tmp._conditions_value_param = (int)GetValue(keyIndex, _conditions_value_param_Index, ptr);
            tmp._repeat = (int)GetValue(keyIndex, _repeat_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._nextid = (int)GetValue(keyIndex, _nextid_Index, ptr);
            tmp._content = (int)GetValue(keyIndex, _content_Index, ptr);
            tmp._speech = (int)GetValue(keyIndex, _speech_Index, ptr);
            tmp._delayTime = (int)GetValue(keyIndex, _delayTime_Index, ptr);
            tmp._showTime = (int)GetValue(keyIndex, _showTime_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TaskLittletalk", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsValue", out _conditions_value_Index)) _conditions_value_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsValueParam", out _conditions_value_param_Index)) _conditions_value_param_Index = -1;
                    if (!nameIndexs.TryGetValue("Repeat", out _repeat_Index)) _repeat_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Nextid", out _nextid_Index)) _nextid_Index = -1;
                    if (!nameIndexs.TryGetValue("Content", out _content_Index)) _content_Index = -1;
                    if (!nameIndexs.TryGetValue("Speech", out _speech_Index)) _speech_Index = -1;
                    if (!nameIndexs.TryGetValue("DelayTime", out _delayTime_Index)) _delayTime_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowTime", out _showTime_Index)) _showTime_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTaskLittletalk>(keyCount);
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
            if(HanderDefine.DataCallBack("TaskLittletalk", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTaskLittletalk cfg = null;
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
        public static DeclareTaskLittletalk Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTaskLittletalk result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TaskLittletalk", out _compressData))
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
