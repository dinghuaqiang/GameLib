//文件是自动生成,请勿手动修改.来自数据文件:vip
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVip
    {
        #region //静态变量定义
        private static int _vipLevel_Index = -1;
        private static int _vipLevelUp_Index = -1;
        private static int _titleReward_Index = -1;
        private static int _titleRewardDesc_Index = -1;
        private static int _vipReward_Index = -1;
        private static int _vipRewardPriceOriginal_Index = -1;
        private static int _vipRewardPriceNow_Index = -1;
        private static int _vipRewardPer_Index = -1;
        private static int _vipPowerId_Index = -1;
        private static int _vipPowerPra_Index = -1;
        private static int _showNewPower_Index = -1;
        private static int _showMainPower_Index = -1;
        private static int _vipUpPower_Index = -1;
        private static int _vIPTitleDesc_Index = -1;
        #endregion
        #region //私有变量定义
        //vip等级
        private int _vipLevel;
        //vip升级经验
        private int _vipLevelUp;
        //称号奖励对应的item表ID
        private int _titleReward;
        //称号奖励描述
        //（废弃）
        //(hide)
        private int _titleRewardDesc;
        //VIP等级礼包
        private int _vipReward;
        //原价
        //ItemId_num（hide）
        private int _vipRewardPriceOriginal;
        //现价
        //ItemId_num
        private int _vipRewardPriceNow;
        //vip每日礼包
        private int _vipRewardPer;
        //VIP特权ID；对应vipPower表的主键
        private int _vipPowerId;
        //特权对应参数（X_Y_Z；X对应VIPPower主键，Y对应服务器用字段，Z客户端对应字段）
        private int _vipPowerPra;
        //特殊显示的特权（相对于上一级VIP针对新增加的特权）hide
        private int _showNewPower;
        //主要特权
        //需要在界面特殊显示的特权，其余都是次要特权)废弃

        //hide
        private int _showMainPower;
        //VIP等级提升时显示的特权(无参数的特权，参数配置0）
        //(hide)
        private int _vipUpPower;
        //VIP页签文字描述
        //（废弃）
        //(hide)
        private int _vIPTitleDesc;
        #endregion

        #region //公共属性
        public int VipLevel { get{ return _vipLevel; }}
        public int VipLevelUp { get{ return _vipLevelUp; }}
        public int TitleReward { get{ return _titleReward; }}
        public string TitleRewardDesc { get{ return HanderDefine.SetStingCallBack(_titleRewardDesc); }}
        public string VipReward { get{ return HanderDefine.SetStingCallBack(_vipReward); }}
        public string VipRewardPriceOriginal { get{ return HanderDefine.SetStingCallBack(_vipRewardPriceOriginal); }}
        public string VipRewardPriceNow { get{ return HanderDefine.SetStingCallBack(_vipRewardPriceNow); }}
        public string VipRewardPer { get{ return HanderDefine.SetStingCallBack(_vipRewardPer); }}
        public string VipPowerId { get{ return HanderDefine.SetStingCallBack(_vipPowerId); }}
        public string VipPowerPra { get{ return HanderDefine.SetStingCallBack(_vipPowerPra); }}
        public string ShowNewPower { get{ return HanderDefine.SetStingCallBack(_showNewPower); }}
        public string ShowMainPower { get{ return HanderDefine.SetStingCallBack(_showMainPower); }}
        public string VipUpPower { get{ return HanderDefine.SetStingCallBack(_vipUpPower); }}
        public string VIPTitleDesc { get{ return HanderDefine.SetStingCallBack(_vIPTitleDesc); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVip cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVip> _dataCaches = null;
        public static Dictionary<int, DeclareVip> CacheData
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
                        if (HanderDefine.DataCallBack("Vip", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVip cfg = null;
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
        private unsafe static DeclareVip LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVip();
            tmp._vipLevel = (int)GetValue(keyIndex, _vipLevel_Index, ptr);
            tmp._vipLevelUp = (int)GetValue(keyIndex, _vipLevelUp_Index, ptr);
            tmp._titleReward = (int)GetValue(keyIndex, _titleReward_Index, ptr);
            tmp._titleRewardDesc = (int)GetValue(keyIndex, _titleRewardDesc_Index, ptr);
            tmp._vipReward = (int)GetValue(keyIndex, _vipReward_Index, ptr);
            tmp._vipRewardPriceOriginal = (int)GetValue(keyIndex, _vipRewardPriceOriginal_Index, ptr);
            tmp._vipRewardPriceNow = (int)GetValue(keyIndex, _vipRewardPriceNow_Index, ptr);
            tmp._vipRewardPer = (int)GetValue(keyIndex, _vipRewardPer_Index, ptr);
            tmp._vipPowerId = (int)GetValue(keyIndex, _vipPowerId_Index, ptr);
            tmp._vipPowerPra = (int)GetValue(keyIndex, _vipPowerPra_Index, ptr);
            tmp._showNewPower = (int)GetValue(keyIndex, _showNewPower_Index, ptr);
            tmp._showMainPower = (int)GetValue(keyIndex, _showMainPower_Index, ptr);
            tmp._vipUpPower = (int)GetValue(keyIndex, _vipUpPower_Index, ptr);
            tmp._vIPTitleDesc = (int)GetValue(keyIndex, _vIPTitleDesc_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Vip", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("VipLevel", out _vipLevel_Index)) _vipLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("VipLevelUp", out _vipLevelUp_Index)) _vipLevelUp_Index = -1;
                    if (!nameIndexs.TryGetValue("TitleReward", out _titleReward_Index)) _titleReward_Index = -1;
                    if (!nameIndexs.TryGetValue("TitleRewardDesc", out _titleRewardDesc_Index)) _titleRewardDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("VipReward", out _vipReward_Index)) _vipReward_Index = -1;
                    if (!nameIndexs.TryGetValue("VipRewardPriceOriginal", out _vipRewardPriceOriginal_Index)) _vipRewardPriceOriginal_Index = -1;
                    if (!nameIndexs.TryGetValue("VipRewardPriceNow", out _vipRewardPriceNow_Index)) _vipRewardPriceNow_Index = -1;
                    if (!nameIndexs.TryGetValue("VipRewardPer", out _vipRewardPer_Index)) _vipRewardPer_Index = -1;
                    if (!nameIndexs.TryGetValue("VipPowerId", out _vipPowerId_Index)) _vipPowerId_Index = -1;
                    if (!nameIndexs.TryGetValue("VipPowerPra", out _vipPowerPra_Index)) _vipPowerPra_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNewPower", out _showNewPower_Index)) _showNewPower_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMainPower", out _showMainPower_Index)) _showMainPower_Index = -1;
                    if (!nameIndexs.TryGetValue("VipUpPower", out _vipUpPower_Index)) _vipUpPower_Index = -1;
                    if (!nameIndexs.TryGetValue("VIPTitleDesc", out _vIPTitleDesc_Index)) _vIPTitleDesc_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareVip>(keyCount);
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
            if(HanderDefine.DataCallBack("Vip", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVip cfg = null;
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
        public static DeclareVip Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVip result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Vip", out _compressData))
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
