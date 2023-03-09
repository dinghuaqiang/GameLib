//文件是自动生成,请勿手动修改.来自数据文件:peakBattleStage
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclarePeakBattleStage
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _stage_Index = -1;
        private static int _star_Index = -1;
        private static int _icon_Index = -1;
        private static int _name_Index = -1;
        private static int _integral_Index = -1;
        private static int _stageReward_Index = -1;
        private static int _limitTimes_Index = -1;
        private static int _winIntegral_Index = -1;
        private static int _loseIntegral_Index = -1;
        private static int _winExtraReward_Index = -1;
        private static int _loseExtraReward_Index = -1;
        private static int _winExp_Index = -1;
        private static int _loseExp_Index = -1;
        #endregion
        #region //私有变量定义
        //唯一id
        private int _id;
        //段位
        private int _stage;
        //星级
        private int _star;
        //段位Icon
        private int _icon;
        //段位名称
        private int _name;
        //积分
        private int _integral;
        //奖励道具
        private int _stageReward;
        //可领取次数
        private int _limitTimes;
        //胜利积分
        private int _winIntegral;
        //失败积分
        private int _loseIntegral;
        //前十场胜利额外奖励
        private int _winExtraReward;
        //前十场失败额外奖励
        private int _loseExtraReward;
        //胜利经验奖励值
        private int _winExp;
        //失败经验奖励值
        private int _loseExp;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Stage { get{ return _stage; }}
        public int Star { get{ return _star; }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Integral { get{ return _integral; }}
        public string StageReward { get{ return HanderDefine.SetStingCallBack(_stageReward); }}
        public int LimitTimes { get{ return _limitTimes; }}
        public int WinIntegral { get{ return _winIntegral; }}
        public int LoseIntegral { get{ return _loseIntegral; }}
        public string WinExtraReward { get{ return HanderDefine.SetStingCallBack(_winExtraReward); }}
        public string LoseExtraReward { get{ return HanderDefine.SetStingCallBack(_loseExtraReward); }}
        public int WinExp { get{ return _winExp; }}
        public int LoseExp { get{ return _loseExp; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclarePeakBattleStage cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclarePeakBattleStage> _dataCaches = null;
        public static Dictionary<int, DeclarePeakBattleStage> CacheData
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
                        if (HanderDefine.DataCallBack("PeakBattleStage", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclarePeakBattleStage cfg = null;
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
        private unsafe static DeclarePeakBattleStage LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclarePeakBattleStage();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._stage = (int)GetValue(keyIndex, _stage_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._integral = (int)GetValue(keyIndex, _integral_Index, ptr);
            tmp._stageReward = (int)GetValue(keyIndex, _stageReward_Index, ptr);
            tmp._limitTimes = (int)GetValue(keyIndex, _limitTimes_Index, ptr);
            tmp._winIntegral = (int)GetValue(keyIndex, _winIntegral_Index, ptr);
            tmp._loseIntegral = (int)GetValue(keyIndex, _loseIntegral_Index, ptr);
            tmp._winExtraReward = (int)GetValue(keyIndex, _winExtraReward_Index, ptr);
            tmp._loseExtraReward = (int)GetValue(keyIndex, _loseExtraReward_Index, ptr);
            tmp._winExp = (int)GetValue(keyIndex, _winExp_Index, ptr);
            tmp._loseExp = (int)GetValue(keyIndex, _loseExp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("PeakBattleStage", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Stage", out _stage_Index)) _stage_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Integral", out _integral_Index)) _integral_Index = -1;
                    if (!nameIndexs.TryGetValue("StageReward", out _stageReward_Index)) _stageReward_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitTimes", out _limitTimes_Index)) _limitTimes_Index = -1;
                    if (!nameIndexs.TryGetValue("WinIntegral", out _winIntegral_Index)) _winIntegral_Index = -1;
                    if (!nameIndexs.TryGetValue("LoseIntegral", out _loseIntegral_Index)) _loseIntegral_Index = -1;
                    if (!nameIndexs.TryGetValue("WinExtraReward", out _winExtraReward_Index)) _winExtraReward_Index = -1;
                    if (!nameIndexs.TryGetValue("LoseExtraReward", out _loseExtraReward_Index)) _loseExtraReward_Index = -1;
                    if (!nameIndexs.TryGetValue("WinExp", out _winExp_Index)) _winExp_Index = -1;
                    if (!nameIndexs.TryGetValue("LoseExp", out _loseExp_Index)) _loseExp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclarePeakBattleStage>(keyCount);
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
            if(HanderDefine.DataCallBack("PeakBattleStage", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclarePeakBattleStage cfg = null;
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
        public static DeclarePeakBattleStage Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclarePeakBattleStage result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("PeakBattleStage", out _compressData))
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
