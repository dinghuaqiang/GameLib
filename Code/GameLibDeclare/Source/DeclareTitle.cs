//文件是自动生成,请勿手动修改.来自数据文件:title
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTitle
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _typeName_Index = -1;
        private static int _sort_Index = -1;
        private static int _time_Index = -1;
        private static int _activation_Index = -1;
        private static int _textrue_Index = -1;
        private static int _vfx_title_Index = -1;
        private static int _property_Index = -1;
        private static int _activeDesc_Index = -1;
        private static int _openFunc_Index = -1;
        private static int _funcParam_Index = -1;
        private static int _canShow_Index = -1;
        private static int _quality_Index = -1;
        private static int _isAutoWear_Index = -1;
        #endregion
        #region //私有变量定义
        //称号ID，对应item中ID
        private int _id;
        //称号名称
        private int _name;
        //分类排序
        private int _type;
        //分类名字(hide)
        private int _typeName;
        //组内排序(hide)
        private int _sort;
        //0是永久称号，>0为称号倒计时单位秒，从激活开始算（限时称号必定自动激活）
        private int _time;
        //得到该道具后是否自动激活，0为不处理，1为自动激活（限时称号必定自动激活）
        private int _activation;
        //称号图片资源
        private int _textrue;
        //特效称号id，没有填0
        private int _vfx_title;
        //称号属性(@;@_@)
        private int _property;
        //激活描述(hide)
        private int _activeDesc;
        //获取途径对应的functionstart的面板ID
        private int _openFunc;
        //点击前往打开的功能参数
        private int _funcParam;
        //是否在列表中显示(0否1是)
        private int _canShow;
        //称号的品质排序，默认穿戴最大品质的称号，数字越大品质越好，相同品质不替换
        private int _quality;
        //是否弹出获取界面
        //0不弹出
        //1弹出
        //(hide)
        private int _isAutoWear;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_typeName); }}
        public int Sort { get{ return _sort; }}
        public int Time { get{ return _time; }}
        public int Activation { get{ return _activation; }}
        public int Textrue { get{ return _textrue; }}
        public int VfxTitle { get{ return _vfx_title; }}
        public string Property { get{ return HanderDefine.SetStingCallBack(_property); }}
        public string ActiveDesc { get{ return HanderDefine.SetStingCallBack(_activeDesc); }}
        public int OpenFunc { get{ return _openFunc; }}
        public int FuncParam { get{ return _funcParam; }}
        public int CanShow { get{ return _canShow; }}
        public int Quality { get{ return _quality; }}
        public int IsAutoWear { get{ return _isAutoWear; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTitle cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTitle> _dataCaches = null;
        public static Dictionary<int, DeclareTitle> CacheData
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
                        if (HanderDefine.DataCallBack("Title", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTitle cfg = null;
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
        private unsafe static DeclareTitle LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTitle();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._typeName = (int)GetValue(keyIndex, _typeName_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._activation = (int)GetValue(keyIndex, _activation_Index, ptr);
            tmp._textrue = (int)GetValue(keyIndex, _textrue_Index, ptr);
            tmp._vfx_title = (int)GetValue(keyIndex, _vfx_title_Index, ptr);
            tmp._property = (int)GetValue(keyIndex, _property_Index, ptr);
            tmp._activeDesc = (int)GetValue(keyIndex, _activeDesc_Index, ptr);
            tmp._openFunc = (int)GetValue(keyIndex, _openFunc_Index, ptr);
            tmp._funcParam = (int)GetValue(keyIndex, _funcParam_Index, ptr);
            tmp._canShow = (int)GetValue(keyIndex, _canShow_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._isAutoWear = (int)GetValue(keyIndex, _isAutoWear_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Title", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _typeName_Index)) _typeName_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("Activation", out _activation_Index)) _activation_Index = -1;
                    if (!nameIndexs.TryGetValue("Textrue", out _textrue_Index)) _textrue_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxTitle", out _vfx_title_Index)) _vfx_title_Index = -1;
                    if (!nameIndexs.TryGetValue("Property", out _property_Index)) _property_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveDesc", out _activeDesc_Index)) _activeDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFunc", out _openFunc_Index)) _openFunc_Index = -1;
                    if (!nameIndexs.TryGetValue("FuncParam", out _funcParam_Index)) _funcParam_Index = -1;
                    if (!nameIndexs.TryGetValue("CanShow", out _canShow_Index)) _canShow_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("IsAutoWear", out _isAutoWear_Index)) _isAutoWear_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTitle>(keyCount);
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
            if(HanderDefine.DataCallBack("Title", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTitle cfg = null;
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
        public static DeclareTitle Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTitle result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Title", out _compressData))
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
