//文件是自动生成,请勿手动修改.来自数据文件:ConvoyGirl
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareConvoyGirl
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _model_path_Index = -1;
        private static int _reward_ID_Index = -1;
        private static int _convoyTime_Index = -1;
        private static int _useItem_Index = -1;
        private static int _showValue_Index = -1;
        private static int _chooseBackground_Index = -1;
        private static int _model_Position_Index = -1;
        #endregion
        #region //私有变量定义
        //神女id
        private int _id;
        //神女名字
        private int _name;
        //神女使用头像
        private int _icon;
        //神女模型片的路径e_ui(hide)
        private int _model_path;
        //物品奖励
        //物品id1_数量_绑定_职业
        //职业：0玄剑、1天英、2地藏、3罗刹、9通用
        //绑定：0绑定、1不绑定
        private int _reward_ID;
        //护送时间(单位：s)
        private int _convoyTime;
        //物品ID_需要数量
        private int _useItem;
        //展示奖励百分比（hide）
        private int _showValue;
        //选择神女时使用的背景板
        private int _chooseBackground;
        //sca_roty_posx_posy_posz
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        //4.旋转在此功能不支持
        private int _model_Position;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int ModelPath { get{ return _model_path; }}
        public string RewardID { get{ return HanderDefine.SetStingCallBack(_reward_ID); }}
        public int ConvoyTime { get{ return _convoyTime; }}
        public string UseItem { get{ return HanderDefine.SetStingCallBack(_useItem); }}
        public int ShowValue { get{ return _showValue; }}
        public string ChooseBackground { get{ return HanderDefine.SetStingCallBack(_chooseBackground); }}
        public string ModelPosition { get{ return HanderDefine.SetStingCallBack(_model_Position); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareConvoyGirl cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareConvoyGirl> _dataCaches = null;
        public static Dictionary<int, DeclareConvoyGirl> CacheData
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
                        if (HanderDefine.DataCallBack("ConvoyGirl", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareConvoyGirl cfg = null;
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
        private unsafe static DeclareConvoyGirl LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareConvoyGirl();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._model_path = (int)GetValue(keyIndex, _model_path_Index, ptr);
            tmp._reward_ID = (int)GetValue(keyIndex, _reward_ID_Index, ptr);
            tmp._convoyTime = (int)GetValue(keyIndex, _convoyTime_Index, ptr);
            tmp._useItem = (int)GetValue(keyIndex, _useItem_Index, ptr);
            tmp._showValue = (int)GetValue(keyIndex, _showValue_Index, ptr);
            tmp._chooseBackground = (int)GetValue(keyIndex, _chooseBackground_Index, ptr);
            tmp._model_Position = (int)GetValue(keyIndex, _model_Position_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ConvoyGirl", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPath", out _model_path_Index)) _model_path_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardID", out _reward_ID_Index)) _reward_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("ConvoyTime", out _convoyTime_Index)) _convoyTime_Index = -1;
                    if (!nameIndexs.TryGetValue("UseItem", out _useItem_Index)) _useItem_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowValue", out _showValue_Index)) _showValue_Index = -1;
                    if (!nameIndexs.TryGetValue("ChooseBackground", out _chooseBackground_Index)) _chooseBackground_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPosition", out _model_Position_Index)) _model_Position_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareConvoyGirl>(keyCount);
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
            if(HanderDefine.DataCallBack("ConvoyGirl", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareConvoyGirl cfg = null;
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
        public static DeclareConvoyGirl Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareConvoyGirl result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ConvoyGirl", out _compressData))
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
