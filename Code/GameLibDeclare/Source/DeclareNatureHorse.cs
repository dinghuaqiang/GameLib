//文件是自动生成,请勿手动修改.来自数据文件:NatureHorse
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNatureHorse
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _steps_Index = -1;
        private static int _star_Index = -1;
        private static int _name_Index = -1;
        private static int _progress_Index = -1;
        private static int _attribute_Index = -1;
        private static int _skill_Index = -1;
        private static int _up_item_Index = -1;
        private static int _modelID_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _isShow_Index = -1;
        private static int _mainTransfom_Index = -1;
        private static int _gDateLevel_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //坐骑的阶数
        private int _steps;
        //坐骑的星数
        private int _star;
        //名字
        private int _name;
        //强化进度
        private int _progress;
        //本级属性(@;@_@)
        private int _attribute;
        //激活技能(@_@)
        private int _skill;
        //升阶物品id(@_@)
        private int _up_item;
        //是否激活新外观的外观ID
        private int _modelID;
        //相机镜头万分比
        private int _camera_size;
        //0表示不显示装备，1显示人物装备2显示宠物装备，3显示坐骑装备
        private int _isShow;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        private int _mainTransfom;
        //等级，
        //G数专用字段，其他功能不可调用，用于G数据的等级统计
        private int _gDateLevel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Steps { get{ return _steps; }}
        public int Star { get{ return _star; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Progress { get{ return _progress; }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string Skill { get{ return HanderDefine.SetStingCallBack(_skill); }}
        public string UpItem { get{ return HanderDefine.SetStingCallBack(_up_item); }}
        public int ModelID { get{ return _modelID; }}
        public int CameraSize { get{ return _camera_size; }}
        public int IsShow { get{ return _isShow; }}
        public string MainTransfom { get{ return HanderDefine.SetStingCallBack(_mainTransfom); }}
        public int GDateLevel { get{ return _gDateLevel; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNatureHorse cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNatureHorse> _dataCaches = null;
        public static Dictionary<int, DeclareNatureHorse> CacheData
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
                        if (HanderDefine.DataCallBack("NatureHorse", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNatureHorse cfg = null;
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
        private unsafe static DeclareNatureHorse LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNatureHorse();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._steps = (int)GetValue(keyIndex, _steps_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._progress = (int)GetValue(keyIndex, _progress_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._skill = (int)GetValue(keyIndex, _skill_Index, ptr);
            tmp._up_item = (int)GetValue(keyIndex, _up_item_Index, ptr);
            tmp._modelID = (int)GetValue(keyIndex, _modelID_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._mainTransfom = (int)GetValue(keyIndex, _mainTransfom_Index, ptr);
            tmp._gDateLevel = (int)GetValue(keyIndex, _gDateLevel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NatureHorse", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Steps", out _steps_Index)) _steps_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Progress", out _progress_Index)) _progress_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("Skill", out _skill_Index)) _skill_Index = -1;
                    if (!nameIndexs.TryGetValue("UpItem", out _up_item_Index)) _up_item_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelID", out _modelID_Index)) _modelID_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTransfom", out _mainTransfom_Index)) _mainTransfom_Index = -1;
                    if (!nameIndexs.TryGetValue("GDateLevel", out _gDateLevel_Index)) _gDateLevel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNatureHorse>(keyCount);
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
            if(HanderDefine.DataCallBack("NatureHorse", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNatureHorse cfg = null;
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
        public static DeclareNatureHorse Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNatureHorse result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NatureHorse", out _compressData))
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
