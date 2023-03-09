//文件是自动生成,请勿手动修改.来自数据文件:bossnew_world
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossnewWorld
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _page_Index = -1;
        private static int _dropEquipShow_Index = -1;
        private static int _scourge_Index = -1;
        private static int _monster_picture_Index = -1;
        private static int _size_Index = -1;
        private static int _model_rotat_Index = -1;
        private static int _drop_Index = -1;
        private static int _gold_drop_Index = -1;
        private static int _mapnum_Index = -1;
        private static int _infinite_Index = -1;
        private static int _layer_Index = -1;
        private static int _clone_map_Index = -1;
        private static int _pos_Index = -1;
        private static int _if_raward_Index = -1;
        private static int _gift_num_Index = -1;
        private static int _min_grade_Index = -1;
        private static int _isNotice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //怪物ID
        private int _iD;
        //BOSS分页
        private int _page;
        //掉落装备阶数
        private int _dropEquipShow;
        //击杀累积天谴值（套装BOSS，宝石BOSS用）
        private int _scourge;
        //怪物贴图(hide)
        private int _monster_picture;
        //模型缩放hide
        private int _size;
        //模型旋转hide
        private int _model_rotat;
        //显示掉落(职业ID_道具ID)(@;@_@)hide
        private int _drop;
        //珍稀显示掉落(职业ID_道具ID)(@;@_@)hide
        private int _gold_drop;
        //地图层数
        private int _mapnum;
        //是否是无限层
        private int _infinite;
        //层数（只用来显示标题）hide
        private int _layer;
        //刷新副本地图
        private int _clone_map;
        //刷新坐标(@;@_@)
        private int _pos;
        //是否扣除收益次数（0，不扣除；1，扣除）
        private int _if_raward;
        //显示的宝箱数量hide（填0显示阶数）
        private int _gift_num;
        //是
        private int _min_grade;
        //复活时是否走跑马灯
        //（0否1是）
        private int _isNotice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int Page { get{ return _page; }}
        public int DropEquipShow { get{ return _dropEquipShow; }}
        public int Scourge { get{ return _scourge; }}
        public int MonsterPicture { get{ return _monster_picture; }}
        public int Size { get{ return _size; }}
        public int ModelRotat { get{ return _model_rotat; }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public string GoldDrop { get{ return HanderDefine.SetStingCallBack(_gold_drop); }}
        public int Mapnum { get{ return _mapnum; }}
        public int Infinite { get{ return _infinite; }}
        public int Layer { get{ return _layer; }}
        public int CloneMap { get{ return _clone_map; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int IfRaward { get{ return _if_raward; }}
        public int GiftNum { get{ return _gift_num; }}
        public int MinGrade { get{ return _min_grade; }}
        public int IsNotice { get{ return _isNotice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossnewWorld cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossnewWorld> _dataCaches = null;
        public static Dictionary<int, DeclareBossnewWorld> CacheData
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
                        if (HanderDefine.DataCallBack("BossnewWorld", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossnewWorld cfg = null;
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
        private unsafe static DeclareBossnewWorld LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossnewWorld();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._page = (int)GetValue(keyIndex, _page_Index, ptr);
            tmp._dropEquipShow = (int)GetValue(keyIndex, _dropEquipShow_Index, ptr);
            tmp._scourge = (int)GetValue(keyIndex, _scourge_Index, ptr);
            tmp._monster_picture = (int)GetValue(keyIndex, _monster_picture_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._model_rotat = (int)GetValue(keyIndex, _model_rotat_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._gold_drop = (int)GetValue(keyIndex, _gold_drop_Index, ptr);
            tmp._mapnum = (int)GetValue(keyIndex, _mapnum_Index, ptr);
            tmp._infinite = (int)GetValue(keyIndex, _infinite_Index, ptr);
            tmp._layer = (int)GetValue(keyIndex, _layer_Index, ptr);
            tmp._clone_map = (int)GetValue(keyIndex, _clone_map_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._if_raward = (int)GetValue(keyIndex, _if_raward_Index, ptr);
            tmp._gift_num = (int)GetValue(keyIndex, _gift_num_Index, ptr);
            tmp._min_grade = (int)GetValue(keyIndex, _min_grade_Index, ptr);
            tmp._isNotice = (int)GetValue(keyIndex, _isNotice_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("BossnewWorld", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("Page", out _page_Index)) _page_Index = -1;
                    if (!nameIndexs.TryGetValue("DropEquipShow", out _dropEquipShow_Index)) _dropEquipShow_Index = -1;
                    if (!nameIndexs.TryGetValue("Scourge", out _scourge_Index)) _scourge_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterPicture", out _monster_picture_Index)) _monster_picture_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRotat", out _model_rotat_Index)) _model_rotat_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("GoldDrop", out _gold_drop_Index)) _gold_drop_Index = -1;
                    if (!nameIndexs.TryGetValue("Mapnum", out _mapnum_Index)) _mapnum_Index = -1;
                    if (!nameIndexs.TryGetValue("Infinite", out _infinite_Index)) _infinite_Index = -1;
                    if (!nameIndexs.TryGetValue("Layer", out _layer_Index)) _layer_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneMap", out _clone_map_Index)) _clone_map_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("IfRaward", out _if_raward_Index)) _if_raward_Index = -1;
                    if (!nameIndexs.TryGetValue("GiftNum", out _gift_num_Index)) _gift_num_Index = -1;
                    if (!nameIndexs.TryGetValue("MinGrade", out _min_grade_Index)) _min_grade_Index = -1;
                    if (!nameIndexs.TryGetValue("IsNotice", out _isNotice_Index)) _isNotice_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossnewWorld>(keyCount);
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
            if(HanderDefine.DataCallBack("BossnewWorld", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossnewWorld cfg = null;
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
        public static DeclareBossnewWorld Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossnewWorld result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("BossnewWorld", out _compressData))
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
