//文件是自动生成,请勿手动修改.来自数据文件:guide_war_newbie
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuideWarNewbie
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _sort_Index = -1;
        private static int _type_name_Index = -1;
        private static int _picType_Index = -1;
        private static int _pointType_Index = -1;
        private static int _pic_Index = -1;
        private static int _title_Index = -1;
        private static int _context_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //排行榜名称
        private int _name;
        //大类型分类
        private int _type;
        //排序优先级
        private int _sort;
        //大类型的名字
        private int _type_name;
        //0无图片显示界面
        //1有图片显示界面
        private int _picType;
        //对应需要显示在图上面的点，点的位置由程序写死
        private int _pointType;
        //名字读取的图片
        private int _pic;
        //标题
        private int _title;
        //显示内容
        private int _context;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Sort { get{ return _sort; }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_type_name); }}
        public int PicType { get{ return _picType; }}
        public int PointType { get{ return _pointType; }}
        public string Pic { get{ return HanderDefine.SetStingCallBack(_pic); }}
        public string Title { get{ return HanderDefine.SetStingCallBack(_title); }}
        public string Context { get{ return HanderDefine.SetStingCallBack(_context); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuideWarNewbie cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuideWarNewbie> _dataCaches = null;
        public static Dictionary<int, DeclareGuideWarNewbie> CacheData
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
                        if (HanderDefine.DataCallBack("GuideWarNewbie", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuideWarNewbie cfg = null;
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
        private unsafe static DeclareGuideWarNewbie LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuideWarNewbie();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._type_name = (int)GetValue(keyIndex, _type_name_Index, ptr);
            tmp._picType = (int)GetValue(keyIndex, _picType_Index, ptr);
            tmp._pointType = (int)GetValue(keyIndex, _pointType_Index, ptr);
            tmp._pic = (int)GetValue(keyIndex, _pic_Index, ptr);
            tmp._title = (int)GetValue(keyIndex, _title_Index, ptr);
            tmp._context = (int)GetValue(keyIndex, _context_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuideWarNewbie", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _type_name_Index)) _type_name_Index = -1;
                    if (!nameIndexs.TryGetValue("PicType", out _picType_Index)) _picType_Index = -1;
                    if (!nameIndexs.TryGetValue("PointType", out _pointType_Index)) _pointType_Index = -1;
                    if (!nameIndexs.TryGetValue("Pic", out _pic_Index)) _pic_Index = -1;
                    if (!nameIndexs.TryGetValue("Title", out _title_Index)) _title_Index = -1;
                    if (!nameIndexs.TryGetValue("Context", out _context_Index)) _context_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuideWarNewbie>(keyCount);
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
            if(HanderDefine.DataCallBack("GuideWarNewbie", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuideWarNewbie cfg = null;
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
        public static DeclareGuideWarNewbie Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuideWarNewbie result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuideWarNewbie", out _compressData))
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
