//文件是自动生成,请勿手动修改.来自数据文件:GodWeaponSuit
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGodWeaponSuit
    {
        #region //静态变量定义
        private static int _suitId_Index = -1;
        private static int _suitname_Index = -1;
        private static int _attribute_Index = -1;
        private static int _icon_Index = -1;
        private static int _texture_Index = -1;
        private static int _num_Index = -1;
        private static int _modelId_Index = -1;
        private static int _showTittle_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _suitId;
        //套装名字
        private int _suitname;
        //套装属性属性(@;@_@)
        private int _attribute;
        //用于预览套装时候显示的的图片
        private int _icon;
        //用于电机预览套装时的展示图片
        private int _texture;
        //套装的数量
        private int _num;
        //用于套装显示ID：头部，身体，特效
        private int _modelId;
        //展示面板显示的文字
        private int _showTittle;
        #endregion

        #region //公共属性
        public int SuitId { get{ return _suitId; }}
        public string Suitname { get{ return HanderDefine.SetStingCallBack(_suitname); }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string Texture { get{ return HanderDefine.SetStingCallBack(_texture); }}
        public int Num { get{ return _num; }}
        public string ModelId { get{ return HanderDefine.SetStingCallBack(_modelId); }}
        public string ShowTittle { get{ return HanderDefine.SetStingCallBack(_showTittle); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGodWeaponSuit cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGodWeaponSuit> _dataCaches = null;
        public static Dictionary<int, DeclareGodWeaponSuit> CacheData
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
                        if (HanderDefine.DataCallBack("GodWeaponSuit", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGodWeaponSuit cfg = null;
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
        private unsafe static DeclareGodWeaponSuit LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGodWeaponSuit();
            tmp._suitId = (int)GetValue(keyIndex, _suitId_Index, ptr);
            tmp._suitname = (int)GetValue(keyIndex, _suitname_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._texture = (int)GetValue(keyIndex, _texture_Index, ptr);
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._showTittle = (int)GetValue(keyIndex, _showTittle_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GodWeaponSuit", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("SuitId", out _suitId_Index)) _suitId_Index = -1;
                    if (!nameIndexs.TryGetValue("Suitname", out _suitname_Index)) _suitname_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Texture", out _texture_Index)) _texture_Index = -1;
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowTittle", out _showTittle_Index)) _showTittle_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGodWeaponSuit>(keyCount);
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
            if(HanderDefine.DataCallBack("GodWeaponSuit", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGodWeaponSuit cfg = null;
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
        public static DeclareGodWeaponSuit Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGodWeaponSuit result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GodWeaponSuit", out _compressData))
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
