//文件是自动生成,请勿手动修改.来自数据文件:bossstate
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossstate
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _canShow_Index = -1;
        private static int _stateLevel_Index = -1;
        private static int _monster_Index = -1;
        private static int _layer_Index = -1;
        private static int _cloneID_Index = -1;
        private static int _power_Index = -1;
        private static int _size_Index = -1;
        private static int _modelYPos_Index = -1;
        private static int _frist_reward_Index = -1;
        private static int _reward_Index = -1;
        private static int _drop_Index = -1;
        private static int _pos_Index = -1;
        private static int _time_Index = -1;
        private static int _min_grade_Index = -1;
        private static int _show_panel_Index = -1;
        private static int _show_boss_Index = -1;
        private static int _precious_drop_Index = -1;
        private static int _isGuide_Index = -1;
        private static int _hPper_Index = -1;
        #endregion
        #region //私有变量定义
        //编号ID，表示层级
        private int _iD;
        //是否在列表中显示(0否1是)
        private int _canShow;
        //对应FunctionVariable的ID
        private int _stateLevel;
        //该层级刷出的怪物ID
        private int _monster;
        //所在层数
        private int _layer;
        //副本地图
        private int _cloneID;
        //推荐战力
        private int _power;
        //模型缩放hide
        private int _size;
        //模型偏移
        //hide
        private int _modelYPos;
        //首次掉落
        //服务器掉落，但是客户端不显示
        //item_num_bind_occ
        private int _frist_reward;
        //扫荡奖励(@;@_@)
        private int _reward;
        //显示掉落(职业ID_道具ID)(@;@_@)hide
        private int _drop;
        //刷新坐标(@_@)
        private int _pos;
        //当前层挑战时间
        //单位秒
        private int _time;
        //结算最低显示的装备品质hide
        private int _min_grade;
        //击杀后是否显示继弹出境界BOSS界面
        //（0否1是）
        //(hide)
        private int _show_panel;
        //首次击杀后BOSS是否继续显示在界面上
        //（0否1是）
        private int _show_boss;
        //珍稀掉落，展示在界面上的珍稀掉落
        //（hide）
        private int _precious_drop;
        //是否播放XP技能新手引导
        //（hide）
        private int _isGuide;
        //播放新手引导的BOSS血量，万分比
        //（hide）
        private int _hPper;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int CanShow { get{ return _canShow; }}
        public string StateLevel { get{ return HanderDefine.SetStingCallBack(_stateLevel); }}
        public int Monster { get{ return _monster; }}
        public int Layer { get{ return _layer; }}
        public int CloneID { get{ return _cloneID; }}
        public int Power { get{ return _power; }}
        public int Size { get{ return _size; }}
        public int ModelYPos { get{ return _modelYPos; }}
        public string FristReward { get{ return HanderDefine.SetStingCallBack(_frist_reward); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string Drop { get{ return HanderDefine.SetStingCallBack(_drop); }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int Time { get{ return _time; }}
        public int MinGrade { get{ return _min_grade; }}
        public int ShowPanel { get{ return _show_panel; }}
        public int ShowBoss { get{ return _show_boss; }}
        public string PreciousDrop { get{ return HanderDefine.SetStingCallBack(_precious_drop); }}
        public int IsGuide { get{ return _isGuide; }}
        public int HPper { get{ return _hPper; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossstate cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossstate> _dataCaches = null;
        public static Dictionary<int, DeclareBossstate> CacheData
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
                        if (HanderDefine.DataCallBack("Bossstate", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossstate cfg = null;
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
        private unsafe static DeclareBossstate LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossstate();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._canShow = (int)GetValue(keyIndex, _canShow_Index, ptr);
            tmp._stateLevel = (int)GetValue(keyIndex, _stateLevel_Index, ptr);
            tmp._monster = (int)GetValue(keyIndex, _monster_Index, ptr);
            tmp._layer = (int)GetValue(keyIndex, _layer_Index, ptr);
            tmp._cloneID = (int)GetValue(keyIndex, _cloneID_Index, ptr);
            tmp._power = (int)GetValue(keyIndex, _power_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._modelYPos = (int)GetValue(keyIndex, _modelYPos_Index, ptr);
            tmp._frist_reward = (int)GetValue(keyIndex, _frist_reward_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._drop = (int)GetValue(keyIndex, _drop_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._min_grade = (int)GetValue(keyIndex, _min_grade_Index, ptr);
            tmp._show_panel = (int)GetValue(keyIndex, _show_panel_Index, ptr);
            tmp._show_boss = (int)GetValue(keyIndex, _show_boss_Index, ptr);
            tmp._precious_drop = (int)GetValue(keyIndex, _precious_drop_Index, ptr);
            tmp._isGuide = (int)GetValue(keyIndex, _isGuide_Index, ptr);
            tmp._hPper = (int)GetValue(keyIndex, _hPper_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Bossstate", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("CanShow", out _canShow_Index)) _canShow_Index = -1;
                    if (!nameIndexs.TryGetValue("StateLevel", out _stateLevel_Index)) _stateLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Monster", out _monster_Index)) _monster_Index = -1;
                    if (!nameIndexs.TryGetValue("Layer", out _layer_Index)) _layer_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneID", out _cloneID_Index)) _cloneID_Index = -1;
                    if (!nameIndexs.TryGetValue("Power", out _power_Index)) _power_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _modelYPos_Index)) _modelYPos_Index = -1;
                    if (!nameIndexs.TryGetValue("FristReward", out _frist_reward_Index)) _frist_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Drop", out _drop_Index)) _drop_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("MinGrade", out _min_grade_Index)) _min_grade_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPanel", out _show_panel_Index)) _show_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowBoss", out _show_boss_Index)) _show_boss_Index = -1;
                    if (!nameIndexs.TryGetValue("PreciousDrop", out _precious_drop_Index)) _precious_drop_Index = -1;
                    if (!nameIndexs.TryGetValue("IsGuide", out _isGuide_Index)) _isGuide_Index = -1;
                    if (!nameIndexs.TryGetValue("HPper", out _hPper_Index)) _hPper_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossstate>(keyCount);
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
            if(HanderDefine.DataCallBack("Bossstate", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossstate cfg = null;
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
        public static DeclareBossstate Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossstate result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Bossstate", out _compressData))
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
