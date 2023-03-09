//文件是自动生成,请勿手动修改.来自数据文件:FunctionStart
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFunctionStart
    {
        #region //静态变量定义
        private static int _function_id_Index = -1;
        private static int _parent_id_Index = -1;
        private static int _function_pos_type_Index = -1;
        private static int _open_menu_Index = -1;
        private static int _function_sort_num_Index = -1;
        private static int _main_icon_Index = -1;
        private static int _function_in_cross_Index = -1;
        private static int _start_variables_Index = -1;
        private static int _function_name_Index = -1;
        private static int _guide_Index = -1;
        private static int _back_switch_Index = -1;
        #endregion
        #region //私有变量定义
        //功能id 主功能ID为10000到990000
        private int _function_id;
        //父功能Id
        private int _parent_id;
        //功能所在位置类型,0:主功能,1:右上角菜单按钮,2:内部功能,3:顶部活动按钮，4：左上角菜单按钮（hide）
        private int _function_pos_type;
        //打开菜单，只在主菜单和顶部菜单的功能有效
        private int _open_menu;
        //功能排序:在底部按钮就根据值从小到达从左到右排序，顶部就先根据值来决定是第几排（1-99第一排，100-199第二排以此类推）还要根据值来决定在收缩的时候是否隐藏（第一排1到49不隐藏，其他隐藏，以此类推）
        private int _function_sort_num;
        //图片名称hide
        private int _main_icon;
        //功能是否在跨服中显示（0不显示，1显示）
        private int _function_in_cross;
        //开启需要的变量列表(变量取值参考FunctionVariable配置表)(@_@)
        private int _start_variables;
        //功能名称
        private int _function_name;
        //是否纳入监测快捷提升（0，不监测；1，监测）
        private int _guide;
        //是否纳入后台开关
        //（0否，1是）
        private int _back_switch;
        #endregion

        #region //公共属性
        public int FunctionId { get{ return _function_id; }}
        public int ParentId { get{ return _parent_id; }}
        public int FunctionPosType { get{ return _function_pos_type; }}
        public int OpenMenu { get{ return _open_menu; }}
        public int FunctionSortNum { get{ return _function_sort_num; }}
        public string MainIcon { get{ return HanderDefine.SetStingCallBack(_main_icon); }}
        public int FunctionInCross { get{ return _function_in_cross; }}
        public string StartVariables { get{ return HanderDefine.SetStingCallBack(_start_variables); }}
        public string FunctionName { get{ return HanderDefine.SetStingCallBack(_function_name); }}
        public int Guide { get{ return _guide; }}
        public int BackSwitch { get{ return _back_switch; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFunctionStart cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFunctionStart> _dataCaches = null;
        public static Dictionary<int, DeclareFunctionStart> CacheData
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
                        if (HanderDefine.DataCallBack("FunctionStart", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFunctionStart cfg = null;
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
        private unsafe static DeclareFunctionStart LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFunctionStart();
            tmp._function_id = (int)GetValue(keyIndex, _function_id_Index, ptr);
            tmp._parent_id = (int)GetValue(keyIndex, _parent_id_Index, ptr);
            tmp._function_pos_type = (int)GetValue(keyIndex, _function_pos_type_Index, ptr);
            tmp._open_menu = (int)GetValue(keyIndex, _open_menu_Index, ptr);
            tmp._function_sort_num = (int)GetValue(keyIndex, _function_sort_num_Index, ptr);
            tmp._main_icon = (int)GetValue(keyIndex, _main_icon_Index, ptr);
            tmp._function_in_cross = (int)GetValue(keyIndex, _function_in_cross_Index, ptr);
            tmp._start_variables = (int)GetValue(keyIndex, _start_variables_Index, ptr);
            tmp._function_name = (int)GetValue(keyIndex, _function_name_Index, ptr);
            tmp._guide = (int)GetValue(keyIndex, _guide_Index, ptr);
            tmp._back_switch = (int)GetValue(keyIndex, _back_switch_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FunctionStart", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("FunctionId", out _function_id_Index)) _function_id_Index = -1;
                    if (!nameIndexs.TryGetValue("ParentId", out _parent_id_Index)) _parent_id_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionPosType", out _function_pos_type_Index)) _function_pos_type_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenMenu", out _open_menu_Index)) _open_menu_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionSortNum", out _function_sort_num_Index)) _function_sort_num_Index = -1;
                    if (!nameIndexs.TryGetValue("MainIcon", out _main_icon_Index)) _main_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionInCross", out _function_in_cross_Index)) _function_in_cross_Index = -1;
                    if (!nameIndexs.TryGetValue("StartVariables", out _start_variables_Index)) _start_variables_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionName", out _function_name_Index)) _function_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Guide", out _guide_Index)) _guide_Index = -1;
                    if (!nameIndexs.TryGetValue("BackSwitch", out _back_switch_Index)) _back_switch_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFunctionStart>(keyCount);
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
            if(HanderDefine.DataCallBack("FunctionStart", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFunctionStart cfg = null;
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
        public static DeclareFunctionStart Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFunctionStart result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FunctionStart", out _compressData))
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
