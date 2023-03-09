//文件是自动生成,请勿手动修改.来自数据文件:social_house_furniture
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSocialHouseFurniture
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _order_Index = -1;
        private static int _suit_Index = -1;
        private static int _ui_res_Index = -1;
        private static int _res_Index = -1;
        private static int _show_parm_Index = -1;
        private static int _icon_Index = -1;
        private static int _description_Index = -1;
        private static int _decorate_num_Index = -1;
        private static int _cell_data_0_Index = -1;
        private static int _cell_data_90_Index = -1;
        private static int _cell_data_180_Index = -1;
        private static int _cell_data_270_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //名称
        private int _name;
        //类型（1，主题；2，窗户；3， 家具；4，装饰）
        private int _type;
        //排序
        private int _order;
        //套装
        private int _suit;
        //ui资源
        private int _ui_res;
        //资源ID
        private int _res;
        //缩放大小_X轴偏移_Y轴偏移_Z轴偏移_X轴旋转_Y轴旋转_Z轴旋转
        private int _show_parm;
        //缩略图hide
        private int _icon;
        //常规描述hide
        private int _description;
        //增加的装饰度
        private int _decorate_num;
        //格子数据0度
        private int _cell_data_0;
        //格子数据90度
        private int _cell_data_90;
        //格子数据180度
        private int _cell_data_180;
        //格子数据270度
        private int _cell_data_270;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Order { get{ return _order; }}
        public int Suit { get{ return _suit; }}
        public string UiRes { get{ return HanderDefine.SetStingCallBack(_ui_res); }}
        public string Res { get{ return HanderDefine.SetStingCallBack(_res); }}
        public string ShowParm { get{ return HanderDefine.SetStingCallBack(_show_parm); }}
        public int Icon { get{ return _icon; }}
        public string Description { get{ return HanderDefine.SetStingCallBack(_description); }}
        public int DecorateNum { get{ return _decorate_num; }}
        public string CellData0 { get{ return HanderDefine.SetStingCallBack(_cell_data_0); }}
        public string CellData90 { get{ return HanderDefine.SetStingCallBack(_cell_data_90); }}
        public string CellData180 { get{ return HanderDefine.SetStingCallBack(_cell_data_180); }}
        public string CellData270 { get{ return HanderDefine.SetStingCallBack(_cell_data_270); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSocialHouseFurniture cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSocialHouseFurniture> _dataCaches = null;
        public static Dictionary<int, DeclareSocialHouseFurniture> CacheData
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
                        if (HanderDefine.DataCallBack("SocialHouseFurniture", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSocialHouseFurniture cfg = null;
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
        private unsafe static DeclareSocialHouseFurniture LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSocialHouseFurniture();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._order = (int)GetValue(keyIndex, _order_Index, ptr);
            tmp._suit = (int)GetValue(keyIndex, _suit_Index, ptr);
            tmp._ui_res = (int)GetValue(keyIndex, _ui_res_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._show_parm = (int)GetValue(keyIndex, _show_parm_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._description = (int)GetValue(keyIndex, _description_Index, ptr);
            tmp._decorate_num = (int)GetValue(keyIndex, _decorate_num_Index, ptr);
            tmp._cell_data_0 = (int)GetValue(keyIndex, _cell_data_0_Index, ptr);
            tmp._cell_data_90 = (int)GetValue(keyIndex, _cell_data_90_Index, ptr);
            tmp._cell_data_180 = (int)GetValue(keyIndex, _cell_data_180_Index, ptr);
            tmp._cell_data_270 = (int)GetValue(keyIndex, _cell_data_270_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SocialHouseFurniture", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Order", out _order_Index)) _order_Index = -1;
                    if (!nameIndexs.TryGetValue("Suit", out _suit_Index)) _suit_Index = -1;
                    if (!nameIndexs.TryGetValue("UiRes", out _ui_res_Index)) _ui_res_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowParm", out _show_parm_Index)) _show_parm_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Description", out _description_Index)) _description_Index = -1;
                    if (!nameIndexs.TryGetValue("DecorateNum", out _decorate_num_Index)) _decorate_num_Index = -1;
                    if (!nameIndexs.TryGetValue("CellData0", out _cell_data_0_Index)) _cell_data_0_Index = -1;
                    if (!nameIndexs.TryGetValue("CellData90", out _cell_data_90_Index)) _cell_data_90_Index = -1;
                    if (!nameIndexs.TryGetValue("CellData180", out _cell_data_180_Index)) _cell_data_180_Index = -1;
                    if (!nameIndexs.TryGetValue("CellData270", out _cell_data_270_Index)) _cell_data_270_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSocialHouseFurniture>(keyCount);
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
            if(HanderDefine.DataCallBack("SocialHouseFurniture", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSocialHouseFurniture cfg = null;
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
        public static DeclareSocialHouseFurniture Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSocialHouseFurniture result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SocialHouseFurniture", out _compressData))
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
