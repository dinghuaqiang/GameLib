//文件是自动生成,请勿手动修改.来自数据文件:ActivityNotice
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareActivityNotice
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _sort_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _value_Index = -1;
        private static int _wDay_Index = -1;
        private static int _time_Index = -1;
        private static int _timeDesc_Index = -1;
        private static int _texture_Index = -1;
        private static int _activityDesc_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //界面活动显示顺序
        //（从小到大对应从上至下）
        private int _sort;
        //显示在界面上的活动名字
        private int _name;
        //1：走daily表，填写对应的daily表的主键ID
        //2：首先需满足最低开服时间
        private int _type;
        //和type对应的值
        private int _value;
        //活动开放时间（0表示每天开放，1-7表示周一到周日的某一天）
        //type=1时该字段不需要配置
        private int _wDay;
        //活动时间
        //开启时间_关闭时间
        //单个参数代表只有开启时间，没有关闭时间
        //0代表全天开放
        //type=1时该字段不需要配置
        private int _time;
        //时间描述（需要和time字段对应显示，主要为了方便程序直接读取）
        private int _timeDesc;
        //底图资源名
        private int _texture;
        //活动描述
        private int _activityDesc;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Sort { get{ return _sort; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public string Value { get{ return HanderDefine.SetStingCallBack(_value); }}
        public string WDay { get{ return HanderDefine.SetStingCallBack(_wDay); }}
        public string Time { get{ return HanderDefine.SetStingCallBack(_time); }}
        public string TimeDesc { get{ return HanderDefine.SetStingCallBack(_timeDesc); }}
        public string Texture { get{ return HanderDefine.SetStingCallBack(_texture); }}
        public string ActivityDesc { get{ return HanderDefine.SetStingCallBack(_activityDesc); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareActivityNotice cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareActivityNotice> _dataCaches = null;
        public static Dictionary<int, DeclareActivityNotice> CacheData
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
                        if (HanderDefine.DataCallBack("ActivityNotice", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareActivityNotice cfg = null;
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
        private unsafe static DeclareActivityNotice LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareActivityNotice();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._value = (int)GetValue(keyIndex, _value_Index, ptr);
            tmp._wDay = (int)GetValue(keyIndex, _wDay_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._timeDesc = (int)GetValue(keyIndex, _timeDesc_Index, ptr);
            tmp._texture = (int)GetValue(keyIndex, _texture_Index, ptr);
            tmp._activityDesc = (int)GetValue(keyIndex, _activityDesc_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ActivityNotice", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Value", out _value_Index)) _value_Index = -1;
                    if (!nameIndexs.TryGetValue("WDay", out _wDay_Index)) _wDay_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("TimeDesc", out _timeDesc_Index)) _timeDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("Texture", out _texture_Index)) _texture_Index = -1;
                    if (!nameIndexs.TryGetValue("ActivityDesc", out _activityDesc_Index)) _activityDesc_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareActivityNotice>(keyCount);
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
            if(HanderDefine.DataCallBack("ActivityNotice", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareActivityNotice cfg = null;
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
        public static DeclareActivityNotice Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareActivityNotice result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ActivityNotice", out _compressData))
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
