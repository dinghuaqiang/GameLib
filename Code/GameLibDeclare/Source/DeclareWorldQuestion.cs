//文件是自动生成,请勿手动修改.来自数据文件:world_question
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareWorldQuestion
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _describe_Index = -1;
        private static int _answer_1_Index = -1;
        private static int _answer_2_Index = -1;
        private static int _answer_3_Index = -1;
        private static int _answer_4_Index = -1;
        #endregion
        #region //私有变量定义
        //ID编号
        private int _id;
        //答题题面hide
        private int _describe;
        //正确答案hide
        private int _answer_1;
        //错误答案hide
        private int _answer_2;
        //错误答案hide
        private int _answer_3;
        //错误答案hide
        private int _answer_4;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Describe { get{ return HanderDefine.SetStingCallBack(_describe); }}
        public string Answer1 { get{ return HanderDefine.SetStingCallBack(_answer_1); }}
        public string Answer2 { get{ return HanderDefine.SetStingCallBack(_answer_2); }}
        public string Answer3 { get{ return HanderDefine.SetStingCallBack(_answer_3); }}
        public string Answer4 { get{ return HanderDefine.SetStingCallBack(_answer_4); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareWorldQuestion cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareWorldQuestion> _dataCaches = null;
        public static Dictionary<int, DeclareWorldQuestion> CacheData
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
                        if (HanderDefine.DataCallBack("WorldQuestion", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareWorldQuestion cfg = null;
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
        private unsafe static DeclareWorldQuestion LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareWorldQuestion();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            tmp._answer_1 = (int)GetValue(keyIndex, _answer_1_Index, ptr);
            tmp._answer_2 = (int)GetValue(keyIndex, _answer_2_Index, ptr);
            tmp._answer_3 = (int)GetValue(keyIndex, _answer_3_Index, ptr);
            tmp._answer_4 = (int)GetValue(keyIndex, _answer_4_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("WorldQuestion", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
                    if (!nameIndexs.TryGetValue("Answer1", out _answer_1_Index)) _answer_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Answer2", out _answer_2_Index)) _answer_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Answer3", out _answer_3_Index)) _answer_3_Index = -1;
                    if (!nameIndexs.TryGetValue("Answer4", out _answer_4_Index)) _answer_4_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareWorldQuestion>(keyCount);
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
            if(HanderDefine.DataCallBack("WorldQuestion", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareWorldQuestion cfg = null;
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
        public static DeclareWorldQuestion Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareWorldQuestion result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("WorldQuestion", out _compressData))
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
