//文件是自动生成,请勿手动修改.来自数据文件:GuideItem
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuideItem
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _dialog_Index = -1;
        private static int _show_text_Index = -1;
        private static int _show_back_Index = -1;
        private static int _can_ignore_Index = -1;
        private static int _auto_click_time_Index = -1;
        private static int _auto_jump_time_Index = -1;
        private static int _param1_Index = -1;
        private static int _param1_pc_Index = -1;
        private static int _param2_Index = -1;
        private static int _param3_Index = -1;
        private static int _param4_Index = -1;
        private static int _param5_Index = -1;
        private static int _sound_Index = -1;
        #endregion
        #region //私有变量定义
        //引导ID
        private int _id;
        //对话内容
        private int _dialog;
        //是否展示引导文字
        private int _show_text;
        //是否显示背景
        private int _show_back;
        //是否可以忽略本次引导0不可以，1可以
        private int _can_ignore;
        //自动点击时间，单位秒，为0表示不自动点击
        private int _auto_click_time;
        //自动跳过的时间，当卡在此引导下超过时间后会主动跳过整个引导，单位秒
        private int _auto_jump_time;
        //引导参数1；距离屏幕顶部的距离
        private int _param1;
        //PC引导参数1；距离屏幕顶部的距离
        private int _param1_pc;
        //引导参数2；距离屏幕低部的距离
        private int _param2;
        //引导参数3；距离屏幕左边的距离
        private int _param3;
        //引导参数4；距离屏幕右边的距离
        private int _param4;
        //引导参数5
        private int _param5;
        //播放的音效
        private int _sound;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Dialog { get{ return HanderDefine.SetStingCallBack(_dialog); }}
        public int ShowText { get{ return _show_text; }}
        public int ShowBack { get{ return _show_back; }}
        public int CanIgnore { get{ return _can_ignore; }}
        public int AutoClickTime { get{ return _auto_click_time; }}
        public int AutoJumpTime { get{ return _auto_jump_time; }}
        public string Param1 { get{ return HanderDefine.SetStingCallBack(_param1); }}
        public string Param1Pc { get{ return HanderDefine.SetStingCallBack(_param1_pc); }}
        public string Param2 { get{ return HanderDefine.SetStingCallBack(_param2); }}
        public string Param3 { get{ return HanderDefine.SetStingCallBack(_param3); }}
        public string Param4 { get{ return HanderDefine.SetStingCallBack(_param4); }}
        public string Param5 { get{ return HanderDefine.SetStingCallBack(_param5); }}
        public string Sound { get{ return HanderDefine.SetStingCallBack(_sound); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuideItem cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuideItem> _dataCaches = null;
        public static Dictionary<int, DeclareGuideItem> CacheData
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
                        if (HanderDefine.DataCallBack("GuideItem", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuideItem cfg = null;
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
        private unsafe static DeclareGuideItem LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuideItem();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._dialog = (int)GetValue(keyIndex, _dialog_Index, ptr);
            tmp._show_text = (int)GetValue(keyIndex, _show_text_Index, ptr);
            tmp._show_back = (int)GetValue(keyIndex, _show_back_Index, ptr);
            tmp._can_ignore = (int)GetValue(keyIndex, _can_ignore_Index, ptr);
            tmp._auto_click_time = (int)GetValue(keyIndex, _auto_click_time_Index, ptr);
            tmp._auto_jump_time = (int)GetValue(keyIndex, _auto_jump_time_Index, ptr);
            tmp._param1 = (int)GetValue(keyIndex, _param1_Index, ptr);
            tmp._param1_pc = (int)GetValue(keyIndex, _param1_pc_Index, ptr);
            tmp._param2 = (int)GetValue(keyIndex, _param2_Index, ptr);
            tmp._param3 = (int)GetValue(keyIndex, _param3_Index, ptr);
            tmp._param4 = (int)GetValue(keyIndex, _param4_Index, ptr);
            tmp._param5 = (int)GetValue(keyIndex, _param5_Index, ptr);
            tmp._sound = (int)GetValue(keyIndex, _sound_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuideItem", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Dialog", out _dialog_Index)) _dialog_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowText", out _show_text_Index)) _show_text_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowBack", out _show_back_Index)) _show_back_Index = -1;
                    if (!nameIndexs.TryGetValue("CanIgnore", out _can_ignore_Index)) _can_ignore_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoClickTime", out _auto_click_time_Index)) _auto_click_time_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoJumpTime", out _auto_jump_time_Index)) _auto_jump_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Param1", out _param1_Index)) _param1_Index = -1;
                    if (!nameIndexs.TryGetValue("Param1Pc", out _param1_pc_Index)) _param1_pc_Index = -1;
                    if (!nameIndexs.TryGetValue("Param2", out _param2_Index)) _param2_Index = -1;
                    if (!nameIndexs.TryGetValue("Param3", out _param3_Index)) _param3_Index = -1;
                    if (!nameIndexs.TryGetValue("Param4", out _param4_Index)) _param4_Index = -1;
                    if (!nameIndexs.TryGetValue("Param5", out _param5_Index)) _param5_Index = -1;
                    if (!nameIndexs.TryGetValue("Sound", out _sound_Index)) _sound_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuideItem>(keyCount);
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
            if(HanderDefine.DataCallBack("GuideItem", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuideItem cfg = null;
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
        public static DeclareGuideItem Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuideItem result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuideItem", out _compressData))
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
