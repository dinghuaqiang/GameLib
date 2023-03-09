//文件是自动生成,请勿手动修改.来自数据文件:Cross_fudi_boss
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossFudiBoss
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _position_Index = -1;
        private static int _day_Index = -1;
        private static int _level_Index = -1;
        private static int _sort_Index = -1;
        private static int _type_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _pos_Index = -1;
        private static int _rage_Index = -1;
        private static int _reward_Index = -1;
        private static int _score_Index = -1;
        private static int _personal_score_Index = -1;
        private static int _geren_score_Index = -1;
        private static int _drop_Index = -1;
        private static int _special_drop_Index = -1;
        private static int _defaultFollowOpen_Index = -1;
        #endregion
        #region //私有变量定义
        //怪物ID
        private int _id;
        //福地等级（1，一级福地；2，二级福地；3，三级福地）
        private int _position;
        //开服时间区间
        private int _day;
        //世界等级区间
        private int _level;
        //用于副本内排名的编号
        private int _sort;
        //1.领主；2.精英；3.侍卫
        private int _type;
        //怪物名
        private int _name;
        //头像
        private int _icon;
        //出生位置，（x_y 表示地图坐标)(@;@_@)
        private int _pos;
        //击杀怪物后获得怒气值
        private int _rage;
        //展示奖励,
        private int _reward;
        //占领分数
        private int _score;
        //福地商城对应积分
        private int _personal_score;
        //个人积分
        private int _geren_score;
        //怪物死亡后获得归属的服务器的所有玩家共同分的掉落
        private int _drop;
        //怪物死亡后的伤害排名掉落
        private int _special_drop;
        //是否在功能开启时默认关注
        //（0不关注，1关注）
        private int _defaultFollowOpen;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Position { get{ return _position; }}
        public string Day { get{ return HanderDefine.SetStingCallBack(_day); }}
        public string Level { get{ return HanderDefine.SetStingCallBack(_level); }}
        public int Sort { get{ return _sort; }}
        public int Type { get{ return _type; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Rage { get{ return _rage; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int Score { get{ return _score; }}
        public string PersonalScore { get{ return HanderDefine.SetStingCallBack(_personal_score); }}
        public int GerenScore { get{ return _geren_score; }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public string SpecialDrop { get{ return HanderDefine.SetStingCallBack(_special_drop); }}
        public int DefaultFollowOpen { get{ return _defaultFollowOpen; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossFudiBoss cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossFudiBoss> _dataCaches = null;
        public static Dictionary<int, DeclareCrossFudiBoss> CacheData
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
                        if (HanderDefine.DataCallBack("CrossFudiBoss", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossFudiBoss cfg = null;
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
        private unsafe static DeclareCrossFudiBoss LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossFudiBoss();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._position = (int)GetValue(keyIndex, _position_Index, ptr);
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._rage = (int)GetValue(keyIndex, _rage_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._personal_score = (int)GetValue(keyIndex, _personal_score_Index, ptr);
            tmp._geren_score = (int)GetValue(keyIndex, _geren_score_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._special_drop = (int)GetValue(keyIndex, _special_drop_Index, ptr);
            tmp._defaultFollowOpen = (int)GetValue(keyIndex, _defaultFollowOpen_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossFudiBoss", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Position", out _position_Index)) _position_Index = -1;
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Rage", out _rage_Index)) _rage_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalScore", out _personal_score_Index)) _personal_score_Index = -1;
                    if (!nameIndexs.TryGetValue("GerenScore", out _geren_score_Index)) _geren_score_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialDrop", out _special_drop_Index)) _special_drop_Index = -1;
                    if (!nameIndexs.TryGetValue("DefaultFollowOpen", out _defaultFollowOpen_Index)) _defaultFollowOpen_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossFudiBoss>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossFudiBoss", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossFudiBoss cfg = null;
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
        public static DeclareCrossFudiBoss Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossFudiBoss result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossFudiBoss", out _compressData))
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
