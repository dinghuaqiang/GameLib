//文件是自动生成,请勿手动修改.来自数据文件:marry_child
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryChild
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _sort_Index = -1;
        private static int _activation_Index = -1;
        private static int _itemCondition_Index = -1;
        private static int _condition_Index = -1;
        private static int _icon_Index = -1;
        private static int _childName_Index = -1;
        private static int _model_Index = -1;
        private static int _ui_scale_Index = -1;
        private static int _ui_model_height_Index = -1;
        private static int _skillId_Index = -1;
        #endregion
        #region //私有变量定义
        //列表ID，不能随意
        private int _id;
        //面板排序
        //（hide）
        private int _sort;
        //激活条件
        //1、或(两个达成一个即可）
        //2，且（两个条件都需要达成）
        private int _activation;
        //道具激活，对应item中ID，填0为条件激活(@;@_@)
        private int _itemCondition;
        //条件激活对应marry_lock 等级，填0为道具激活
        private int _condition;
        //图标，对应UIiconAtlas中的图片ID
        //（hide）
        private int _icon;
        //仙娃名称
        private int _childName;
        //对应模型ID，路径：trunk\Client\Main\Assets\GameAssets\Resources\Prefab\Monster
        //（hide）
        private int _model;
        //在ui上的缩放值(获得展示界面用)(hide)
        private int _ui_scale;
        //在界面上的高度(获得展示界面用)(hide)
        private int _ui_model_height;
        //技能ID_解锁等级
        //技能ID(对应skill技能主键）
        //解锁等级（对应仙娃等级）
        private int _skillId;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Sort { get{ return _sort; }}
        public int Activation { get{ return _activation; }}
        public string ItemCondition { get{ return HanderDefine.SetStingCallBack(_itemCondition); }}
        public int Condition { get{ return _condition; }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string ChildName { get{ return HanderDefine.SetStingCallBack(_childName); }}
        public int Model { get{ return _model; }}
        public int UiScale { get{ return _ui_scale; }}
        public int UiModelHeight { get{ return _ui_model_height; }}
        public string SkillId { get{ return HanderDefine.SetStingCallBack(_skillId); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryChild cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryChild> _dataCaches = null;
        public static Dictionary<int, DeclareMarryChild> CacheData
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
                        if (HanderDefine.DataCallBack("MarryChild", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryChild cfg = null;
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
        private unsafe static DeclareMarryChild LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryChild();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._activation = (int)GetValue(keyIndex, _activation_Index, ptr);
            tmp._itemCondition = (int)GetValue(keyIndex, _itemCondition_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._childName = (int)GetValue(keyIndex, _childName_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._ui_scale = (int)GetValue(keyIndex, _ui_scale_Index, ptr);
            tmp._ui_model_height = (int)GetValue(keyIndex, _ui_model_height_Index, ptr);
            tmp._skillId = (int)GetValue(keyIndex, _skillId_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryChild", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Activation", out _activation_Index)) _activation_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemCondition", out _itemCondition_Index)) _itemCondition_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ChildName", out _childName_Index)) _childName_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("UiScale", out _ui_scale_Index)) _ui_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("UiModelHeight", out _ui_model_height_Index)) _ui_model_height_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillId", out _skillId_Index)) _skillId_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryChild>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryChild", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryChild cfg = null;
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
        public static DeclareMarryChild Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryChild result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryChild", out _compressData))
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
