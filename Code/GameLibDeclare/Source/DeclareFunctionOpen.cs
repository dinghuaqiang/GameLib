//文件是自动生成,请勿手动修改.来自数据文件:FunctionOpen
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFunctionOpen
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _data_id_Index = -1;
        private static int _play_fly_Index = -1;
        private static int _show_goto_Index = -1;
        private static int _icon_path_Index = -1;
        private static int _show_time_Index = -1;
        private static int _show_name_Index = -1;
        private static int _desc_Index = -1;
        private static int _sound_Index = -1;
        #endregion
        #region //私有变量定义
        //索引
        private int _id;
        //开启类型 0:技能开放，1：功能开放，2古籍获得
        private int _type;
        //配置ID根据类型代表不同的配置，0技能id，1功能id
        private int _data_id;
        //是否播放飞行效果
        private int _play_fly;
        //是否展示前往按钮，0不展示，1展示（只针对功能开放）
        private int _show_goto;
        //资源路径
        private int _icon_path;
        //展示时间
        private int _show_time;
        //展示的名字
        private int _show_name;
        //描述
        private int _desc;
        //播放的音效
        private int _sound;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int DataId { get{ return _data_id; }}
        public int PlayFly { get{ return _play_fly; }}
        public int ShowGoto { get{ return _show_goto; }}
        public string IconPath { get{ return HanderDefine.SetStingCallBack(_icon_path); }}
        public int ShowTime { get{ return _show_time; }}
        public string ShowName { get{ return HanderDefine.SetStingCallBack(_show_name); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string Sound { get{ return HanderDefine.SetStingCallBack(_sound); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFunctionOpen cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFunctionOpen> _dataCaches = null;
        public static Dictionary<int, DeclareFunctionOpen> CacheData
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
                        if (HanderDefine.DataCallBack("FunctionOpen", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFunctionOpen cfg = null;
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
        private unsafe static DeclareFunctionOpen LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFunctionOpen();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._data_id = (int)GetValue(keyIndex, _data_id_Index, ptr);
            tmp._play_fly = (int)GetValue(keyIndex, _play_fly_Index, ptr);
            tmp._show_goto = (int)GetValue(keyIndex, _show_goto_Index, ptr);
            tmp._icon_path = (int)GetValue(keyIndex, _icon_path_Index, ptr);
            tmp._show_time = (int)GetValue(keyIndex, _show_time_Index, ptr);
            tmp._show_name = (int)GetValue(keyIndex, _show_name_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("FunctionOpen", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("DataId", out _data_id_Index)) _data_id_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayFly", out _play_fly_Index)) _play_fly_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGoto", out _show_goto_Index)) _show_goto_Index = -1;
                    if (!nameIndexs.TryGetValue("IconPath", out _icon_path_Index)) _icon_path_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowTime", out _show_time_Index)) _show_time_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowName", out _show_name_Index)) _show_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFunctionOpen>(keyCount);
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
            if(HanderDefine.DataCallBack("FunctionOpen", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFunctionOpen cfg = null;
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
        public static DeclareFunctionOpen Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFunctionOpen result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FunctionOpen", out _compressData))
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
