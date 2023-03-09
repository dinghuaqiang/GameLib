//文件是自动生成,请勿手动修改.来自数据文件:FunctionNotice
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFunctionNotice
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _main_desc_Index = -1;
        private static int _icon_Index = -1;
        private static int _open_condition_Index = -1;
        private static int _open_param_Index = -1;
        private static int _open_param2_Index = -1;
        private static int _desc_Index = -1;
        private static int _award_Index = -1;
        private static int _back_tex_Index = -1;
        private static int _tips_start_time_Index = -1;
        private static int _tips_end_time_Index = -1;
        private static int _open_func_id_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //功能名字
        private int _name;
        //主界面描述
        private int _main_desc;
        //图标
        private int _icon;
        //开启条件类型； 0等级，1任务，2开服时间（开服时间按照0点开服配置，程序会根据实际开服时间计算）
        private int _open_condition;
        //开启参数，开服时间单位为分钟
        private int _open_param;
        //开启参数2，任务表示多少级的任务
        private int _open_param2;
        //功能描述
        private int _desc;
        //奖励预览
        //itemID_num_occ
        //occ 0男1女9通用
        private int _award;
        //背景图片
        private int _back_tex;
        //时间范围内显示提示（下限）【功能预告改版后已无用】
        private int _tips_start_time;
        //时间范围内显示提示（上限）【功能预告改版后已无用】
        private int _tips_end_time;
        //前往的功能id【功能预告改版后已无用】
        private int _open_func_id;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string MainDesc { get{ return HanderDefine.SetStingCallBack(_main_desc); }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public int OpenCondition { get{ return _open_condition; }}
        public int OpenParam { get{ return _open_param; }}
        public int OpenParam2 { get{ return _open_param2; }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string Award { get{ return HanderDefine.SetStingCallBack(_award); }}
        public string BackTex { get{ return HanderDefine.SetStingCallBack(_back_tex); }}
        public int TipsStartTime { get{ return _tips_start_time; }}
        public int TipsEndTime { get{ return _tips_end_time; }}
        public int OpenFuncId { get{ return _open_func_id; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFunctionNotice cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFunctionNotice> _dataCaches = null;
        public static Dictionary<int, DeclareFunctionNotice> CacheData
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
                        if (HanderDefine.DataCallBack("FunctionNotice", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFunctionNotice cfg = null;
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
        private unsafe static DeclareFunctionNotice LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFunctionNotice();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._main_desc = (int)GetValue(keyIndex, _main_desc_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._open_condition = (int)GetValue(keyIndex, _open_condition_Index, ptr);
            tmp._open_param = (int)GetValue(keyIndex, _open_param_Index, ptr);
            tmp._open_param2 = (int)GetValue(keyIndex, _open_param2_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._award = (int)GetValue(keyIndex, _award_Index, ptr);
            tmp._back_tex = (int)GetValue(keyIndex, _back_tex_Index, ptr);
            tmp._tips_start_time = (int)GetValue(keyIndex, _tips_start_time_Index, ptr);
            tmp._tips_end_time = (int)GetValue(keyIndex, _tips_end_time_Index, ptr);
            tmp._open_func_id = (int)GetValue(keyIndex, _open_func_id_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FunctionNotice", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("MainDesc", out _main_desc_Index)) _main_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenCondition", out _open_condition_Index)) _open_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenParam", out _open_param_Index)) _open_param_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenParam2", out _open_param2_Index)) _open_param2_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Award", out _award_Index)) _award_Index = -1;
                    if (!nameIndexs.TryGetValue("BackTex", out _back_tex_Index)) _back_tex_Index = -1;
                    if (!nameIndexs.TryGetValue("TipsStartTime", out _tips_start_time_Index)) _tips_start_time_Index = -1;
                    if (!nameIndexs.TryGetValue("TipsEndTime", out _tips_end_time_Index)) _tips_end_time_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFuncId", out _open_func_id_Index)) _open_func_id_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFunctionNotice>(keyCount);
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
            if(HanderDefine.DataCallBack("FunctionNotice", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFunctionNotice cfg = null;
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
        public static DeclareFunctionNotice Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFunctionNotice result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FunctionNotice", out _compressData))
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
