//文件是自动生成,请勿手动修改.来自数据文件:new_sever_luckcard
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverLuckcard
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _desc_Index = -1;
        private static int _condition_Index = -1;
        private static int _reward_Index = -1;
        private static int _showIcon_Index = -1;
        private static int _showName_Index = -1;
        private static int _name_Index = -1;
        private static int _isDouble_Index = -1;
        private static int _isRecommend_Index = -1;
        private static int _jumpFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //key用于标识
        private int _id;
        //策划用描述字段
        //（hide）
        private int _desc;
        //对应FunctionVariable条件（可配置多条，多条则代表需要同时满足）
        private int _condition;
        //对应奖励的幸运值
        private int _reward;
        //对应显示的Icon
        //（hide）
        private int _showIcon;
        //对应显示在Icon下的名字
        //（hide）
        private int _showName;
        //任务条件描述
        //（hide）
        private int _name;
        //是否显示为双倍幸运值
        //0不是双倍
        //1是双倍
        //（hide）
        private int _isDouble;
        //是否显示为推荐
        //0不显示
        //1显示
        //（hide）
        private int _isRecommend;
        //对应跳转到功能界面，对应FunctionStart
        //（hide）
        private int _jumpFunction;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public int Reward { get{ return _reward; }}
        public int ShowIcon { get{ return _showIcon; }}
        public string ShowName { get{ return HanderDefine.SetStingCallBack(_showName); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int IsDouble { get{ return _isDouble; }}
        public int IsRecommend { get{ return _isRecommend; }}
        public int JumpFunction { get{ return _jumpFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverLuckcard cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverLuckcard> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverLuckcard> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverLuckcard", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverLuckcard cfg = null;
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
        private unsafe static DeclareNewSeverLuckcard LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverLuckcard();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._showIcon = (int)GetValue(keyIndex, _showIcon_Index, ptr);
            tmp._showName = (int)GetValue(keyIndex, _showName_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._isDouble = (int)GetValue(keyIndex, _isDouble_Index, ptr);
            tmp._isRecommend = (int)GetValue(keyIndex, _isRecommend_Index, ptr);
            tmp._jumpFunction = (int)GetValue(keyIndex, _jumpFunction_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverLuckcard", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowIcon", out _showIcon_Index)) _showIcon_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowName", out _showName_Index)) _showName_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("IsDouble", out _isDouble_Index)) _isDouble_Index = -1;
                    if (!nameIndexs.TryGetValue("IsRecommend", out _isRecommend_Index)) _isRecommend_Index = -1;
                    if (!nameIndexs.TryGetValue("JumpFunction", out _jumpFunction_Index)) _jumpFunction_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverLuckcard>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverLuckcard", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverLuckcard cfg = null;
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
        public static DeclareNewSeverLuckcard Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverLuckcard result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverLuckcard", out _compressData))
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
