//文件是自动生成,请勿手动修改.来自数据文件:FunctionOpenTips
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFunctionOpenTips
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _function_id_Index = -1;
        private static int _main_model_res_Index = -1;
        private static int _model_res_Index = -1;
        private static int _name_Index = -1;
        private static int _desc_Index = -1;
        private static int _open_desc_Index = -1;
        private static int _icon_Index = -1;
        private static int _award_item_Index = -1;
        private static int _active_day_Index = -1;
        private static int _is_show_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //对应功能的id
        private int _function_id;
        //主界面模型配置(职业_模型配置id_缩放_旋转_y轴偏移;职业_模型配置id_缩放_旋转_y轴偏移）hide
        private int _main_model_res;
        //功能界面模型配置(职业_模型配置id_缩放_位置x_位置y_旋转x_旋转y_旋转z）hide
        private int _model_res;
        //功能名字hide
        private int _name;
        //功能描述，只有功能类型才使用hide
        private int _desc;
        //开启描述hide
        private int _open_desc;
        //提示用ICON hide
        private int _icon;
        //物品奖励
        private int _award_item;
        //存在的天数，从开服时间开始算，时间到之后隐藏
        private int _active_day;
        //是否显示，用于版本控制(0隐藏1显示)(hide)
        private int _is_show;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int FunctionId { get{ return _function_id; }}
        public string MainModelRes { get{ return HanderDefine.SetStingCallBack(_main_model_res); }}
        public string ModelRes { get{ return HanderDefine.SetStingCallBack(_model_res); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string OpenDesc { get{ return HanderDefine.SetStingCallBack(_open_desc); }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string AwardItem { get{ return HanderDefine.SetStingCallBack(_award_item); }}
        public int ActiveDay { get{ return _active_day; }}
        public int IsShow { get{ return _is_show; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFunctionOpenTips cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFunctionOpenTips> _dataCaches = null;
        public static Dictionary<int, DeclareFunctionOpenTips> CacheData
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
                        if (HanderDefine.DataCallBack("FunctionOpenTips", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFunctionOpenTips cfg = null;
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
        private unsafe static DeclareFunctionOpenTips LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFunctionOpenTips();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._function_id = (int)GetValue(keyIndex, _function_id_Index, ptr);
            tmp._main_model_res = (int)GetValue(keyIndex, _main_model_res_Index, ptr);
            tmp._model_res = (int)GetValue(keyIndex, _model_res_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._open_desc = (int)GetValue(keyIndex, _open_desc_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._award_item = (int)GetValue(keyIndex, _award_item_Index, ptr);
            tmp._active_day = (int)GetValue(keyIndex, _active_day_Index, ptr);
            tmp._is_show = (int)GetValue(keyIndex, _is_show_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FunctionOpenTips", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionId", out _function_id_Index)) _function_id_Index = -1;
                    if (!nameIndexs.TryGetValue("MainModelRes", out _main_model_res_Index)) _main_model_res_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRes", out _model_res_Index)) _model_res_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenDesc", out _open_desc_Index)) _open_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("AwardItem", out _award_item_Index)) _award_item_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveDay", out _active_day_Index)) _active_day_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _is_show_Index)) _is_show_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFunctionOpenTips>(keyCount);
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
            if(HanderDefine.DataCallBack("FunctionOpenTips", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFunctionOpenTips cfg = null;
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
        public static DeclareFunctionOpenTips Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFunctionOpenTips result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FunctionOpenTips", out _compressData))
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
