//文件是自动生成,请勿手动修改.来自数据文件:bossnew_HorseBoss
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossnewHorseBoss
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _monster_name_Index = -1;
        private static int _canShow_Index = -1;
        private static int _crossSever_Index = -1;
        private static int _head_icon_Index = -1;
        private static int _size_Index = -1;
        private static int _monsterid_Index = -1;
        private static int _enterLevel_Index = -1;
        private static int _dropEquipShow_Index = -1;
        private static int _score_Index = -1;
        private static int _layer_Index = -1;
        private static int _power_Index = -1;
        private static int _drop_Index = -1;
        private static int _cloneid_Index = -1;
        private static int _num_Index = -1;
        private static int _pos_Index = -1;
        private static int _if_raward_Index = -1;
        private static int _gift_num_Index = -1;
        #endregion
        #region //私有变量定义
        //编号ID
        private int _iD;
        //怪物名称
        private int _monster_name;
        //是否在列表中显示(0否1是)
        private int _canShow;
        //是否为跨服（0否1是）
        private int _crossSever;
        //怪物头像 hide
        private int _head_icon;
        //模型缩放hide
        private int _size;
        //怪物ID或采集物ID
        private int _monsterid;
        //进入所需等级
        private int _enterLevel;
        //掉落装备阶数 hide
        private int _dropEquipShow;
        //击杀获得的荒古令
        private int _score;
        //所在层数
        private int _layer;
        //需要脉轮评级
        private int _power;
        //显示掉落(@;@)hide
        private int _drop;
        //副本ID
        private int _cloneid;
        //刷新数量
        private int _num;
        //刷新坐标(@;@_@)1.随机坐标点；2固定坐标点；3固定坐标点；4固定坐标点
        private int _pos;
        //是否扣除收益次数（0，不扣除；1，扣除）
        private int _if_raward;
        //显示的宝箱数量hide（填0显示阶数）
        private int _gift_num;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public string MonsterName { get{ return HanderDefine.SetStingCallBack(_monster_name); }}
        public int CanShow { get{ return _canShow; }}
        public int CrossSever { get{ return _crossSever; }}
        public int HeadIcon { get{ return _head_icon; }}
        public int Size { get{ return _size; }}
        public int Monsterid { get{ return _monsterid; }}
        public int EnterLevel { get{ return _enterLevel; }}
        public int DropEquipShow { get{ return _dropEquipShow; }}
        public int Score { get{ return _score; }}
        public int Layer { get{ return _layer; }}
        public int Power { get{ return _power; }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public int Cloneid { get{ return _cloneid; }}
        public int Num { get{ return _num; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int IfRaward { get{ return _if_raward; }}
        public int GiftNum { get{ return _gift_num; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossnewHorseBoss cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossnewHorseBoss> _dataCaches = null;
        public static Dictionary<int, DeclareBossnewHorseBoss> CacheData
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
                        if (HanderDefine.DataCallBack("BossnewHorseBoss", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossnewHorseBoss cfg = null;
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
        private unsafe static DeclareBossnewHorseBoss LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossnewHorseBoss();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._monster_name = (int)GetValue(keyIndex, _monster_name_Index, ptr);
            tmp._canShow = (int)GetValue(keyIndex, _canShow_Index, ptr);
            tmp._crossSever = (int)GetValue(keyIndex, _crossSever_Index, ptr);
            tmp._head_icon = (int)GetValue(keyIndex, _head_icon_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._monsterid = (int)GetValue(keyIndex, _monsterid_Index, ptr);
            tmp._enterLevel = (int)GetValue(keyIndex, _enterLevel_Index, ptr);
            tmp._dropEquipShow = (int)GetValue(keyIndex, _dropEquipShow_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._layer = (int)GetValue(keyIndex, _layer_Index, ptr);
            tmp._power = (int)GetValue(keyIndex, _power_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._cloneid = (int)GetValue(keyIndex, _cloneid_Index, ptr);
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._if_raward = (int)GetValue(keyIndex, _if_raward_Index, ptr);
            tmp._gift_num = (int)GetValue(keyIndex, _gift_num_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("BossnewHorseBoss", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterName", out _monster_name_Index)) _monster_name_Index = -1;
                    if (!nameIndexs.TryGetValue("CanShow", out _canShow_Index)) _canShow_Index = -1;
                    if (!nameIndexs.TryGetValue("CrossSever", out _crossSever_Index)) _crossSever_Index = -1;
                    if (!nameIndexs.TryGetValue("HeadIcon", out _head_icon_Index)) _head_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("Monsterid", out _monsterid_Index)) _monsterid_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterLevel", out _enterLevel_Index)) _enterLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("DropEquipShow", out _dropEquipShow_Index)) _dropEquipShow_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("Layer", out _layer_Index)) _layer_Index = -1;
                    if (!nameIndexs.TryGetValue("Power", out _power_Index)) _power_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("Cloneid", out _cloneid_Index)) _cloneid_Index = -1;
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("IfRaward", out _if_raward_Index)) _if_raward_Index = -1;
                    if (!nameIndexs.TryGetValue("GiftNum", out _gift_num_Index)) _gift_num_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossnewHorseBoss>(keyCount);
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
            if(HanderDefine.DataCallBack("BossnewHorseBoss", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossnewHorseBoss cfg = null;
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
        public static DeclareBossnewHorseBoss Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossnewHorseBoss result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("BossnewHorseBoss", out _compressData))
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
