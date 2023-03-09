//文件是自动生成,请勿手动修改.来自数据文件:level_reward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareLevelReward
    {
        #region //静态变量定义
        private static int _q_level_Index = -1;
        private static int _q_reward_Index = -1;
        private static int _q_reward_vip_Index = -1;
        private static int _vipLimit_Index = -1;
        private static int _limitValue_Index = -1;
        private static int _paoPao_Index = -1;
        private static int _pushLimit_Index = -1;
        #endregion
        #region //私有变量定义
        //等级要求
        private int _q_level;
        //装备,ID_数量_是否绑定（0否 1是）_职业(@;@_@)
        //Occ:0男；1女；9通用；0，1只对应职业发，通用都会发
        private int _q_reward;
        //VIP额外奖励列表
        //装备,ID_数量_是否绑定（0否 1是）_职业(@;@_@)
        //Occ:0男；1女；9通用；0，1只对应职业发，通用都会发
        private int _q_reward_vip;
        //对应领取VIP额外奖励所需的VIP等级
        private int _vipLimit;
        //限制数据，-1为不限，0 为不可领，大于0为可领数量
        private int _limitValue;
        //是否显示气泡0否1是
        private int _paoPao;
        //距离目标等级差XX级时就显示主界面推送按钮（0代表这个礼包不进行推送提示）
        //（hide）
        private int _pushLimit;
        #endregion

        #region //公共属性
        public int QLevel { get{ return _q_level; }}
        public string QReward { get{ return HanderDefine.SetStingCallBack(_q_reward); }}
        public string QRewardVip { get{ return HanderDefine.SetStingCallBack(_q_reward_vip); }}
        public int VipLimit { get{ return _vipLimit; }}
        public int LimitValue { get{ return _limitValue; }}
        public int PaoPao { get{ return _paoPao; }}
        public int PushLimit { get{ return _pushLimit; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareLevelReward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareLevelReward> _dataCaches = null;
        public static Dictionary<int, DeclareLevelReward> CacheData
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
                        if (HanderDefine.DataCallBack("LevelReward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareLevelReward cfg = null;
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
        private unsafe static DeclareLevelReward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareLevelReward();
            tmp._q_level = (int)GetValue(keyIndex, _q_level_Index, ptr);
            tmp._q_reward = (int)GetValue(keyIndex, _q_reward_Index, ptr);
            tmp._q_reward_vip = (int)GetValue(keyIndex, _q_reward_vip_Index, ptr);
            tmp._vipLimit = (int)GetValue(keyIndex, _vipLimit_Index, ptr);
            tmp._limitValue = (int)GetValue(keyIndex, _limitValue_Index, ptr);
            tmp._paoPao = (int)GetValue(keyIndex, _paoPao_Index, ptr);
            tmp._pushLimit = (int)GetValue(keyIndex, _pushLimit_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("LevelReward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("QLevel", out _q_level_Index)) _q_level_Index = -1;
                    if (!nameIndexs.TryGetValue("QReward", out _q_reward_Index)) _q_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("QRewardVip", out _q_reward_vip_Index)) _q_reward_vip_Index = -1;
                    if (!nameIndexs.TryGetValue("VipLimit", out _vipLimit_Index)) _vipLimit_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitValue", out _limitValue_Index)) _limitValue_Index = -1;
                    if (!nameIndexs.TryGetValue("PaoPao", out _paoPao_Index)) _paoPao_Index = -1;
                    if (!nameIndexs.TryGetValue("PushLimit", out _pushLimit_Index)) _pushLimit_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareLevelReward>(keyCount);
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
            if(HanderDefine.DataCallBack("LevelReward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareLevelReward cfg = null;
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
        public static DeclareLevelReward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareLevelReward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("LevelReward", out _compressData))
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
