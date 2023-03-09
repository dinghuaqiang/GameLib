//文件是自动生成,请勿手动修改.来自数据文件:VIPTrueRecharge
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareVIPTrueRecharge
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _rechargeLimit_Index = -1;
        private static int _rechargeReward_Index = -1;
        private static int _trueRewardPowerId_Index = -1;
        private static int _trueRewardPowerPra_Index = -1;
        private static int _modelId_Index = -1;
        private static int _modelRotate_Index = -1;
        private static int _modelPos_Index = -1;
        private static int _modelScale_Index = -1;
        private static int _title_Index = -1;
        private static int _desc_Index = -1;
        #endregion
        #region //私有变量定义
        //充值档位编号
        private int _id;
        //充值类型
        //1低级充值
        //2高级充值
        private int _type;
        //充值条件（单位：灵玉）
        private int _rechargeLimit;
        //物品奖励，
        //ItemId_num_bind_occ
        //物品ID_数量_绑定状态_职业
        //绑定状态：0未绑定1绑定
        //职业：0男1女9通用
        private int _rechargeReward;
        //累计充值特权ID；对应vipPower表的主键
        private int _trueRewardPowerId;
        //特权对应参数
        private int _trueRewardPowerPra;
        //需要显示出来的模型ID（hide）
        private int _modelId;
        //模型展示，旋转
        //X_Y_Z
        //按照对应坐标轴旋转（hide）
        private int _modelRotate;
        //模型展示，位置
        //X_Y_Z
        //按照对应坐标轴位置
        //配置在对应ModelRoot子节点的[FSKIN_00008]节点，程序会除以100填入（hide）
        private int _modelPos;
        //模型倍数（hide）
        //计算方式：320/（ModelRoot里的值）*100
        private int _modelScale;
        //描述标题（hide）
        private int _title;
        //描述内容（hide）
        private int _desc;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int RechargeLimit { get{ return _rechargeLimit; }}
        public string RechargeReward { get{ return HanderDefine.SetStingCallBack(_rechargeReward); }}
        public string TrueRewardPowerId { get{ return HanderDefine.SetStingCallBack(_trueRewardPowerId); }}
        public string TrueRewardPowerPra { get{ return HanderDefine.SetStingCallBack(_trueRewardPowerPra); }}
        public int ModelId { get{ return _modelId; }}
        public string ModelRotate { get{ return HanderDefine.SetStingCallBack(_modelRotate); }}
        public string ModelPos { get{ return HanderDefine.SetStingCallBack(_modelPos); }}
        public int ModelScale { get{ return _modelScale; }}
        public string Title { get{ return HanderDefine.SetStingCallBack(_title); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareVIPTrueRecharge cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareVIPTrueRecharge> _dataCaches = null;
        public static Dictionary<int, DeclareVIPTrueRecharge> CacheData
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
                        if (HanderDefine.DataCallBack("VIPTrueRecharge", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareVIPTrueRecharge cfg = null;
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
        private unsafe static DeclareVIPTrueRecharge LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareVIPTrueRecharge();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._rechargeLimit = (int)GetValue(keyIndex, _rechargeLimit_Index, ptr);
            tmp._rechargeReward = (int)GetValue(keyIndex, _rechargeReward_Index, ptr);
            tmp._trueRewardPowerId = (int)GetValue(keyIndex, _trueRewardPowerId_Index, ptr);
            tmp._trueRewardPowerPra = (int)GetValue(keyIndex, _trueRewardPowerPra_Index, ptr);
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._modelRotate = (int)GetValue(keyIndex, _modelRotate_Index, ptr);
            tmp._modelPos = (int)GetValue(keyIndex, _modelPos_Index, ptr);
            tmp._modelScale = (int)GetValue(keyIndex, _modelScale_Index, ptr);
            tmp._title = (int)GetValue(keyIndex, _title_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("VIPTrueRecharge", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("RechargeLimit", out _rechargeLimit_Index)) _rechargeLimit_Index = -1;
                    if (!nameIndexs.TryGetValue("RechargeReward", out _rechargeReward_Index)) _rechargeReward_Index = -1;
                    if (!nameIndexs.TryGetValue("TrueRewardPowerId", out _trueRewardPowerId_Index)) _trueRewardPowerId_Index = -1;
                    if (!nameIndexs.TryGetValue("TrueRewardPowerPra", out _trueRewardPowerPra_Index)) _trueRewardPowerPra_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRotate", out _modelRotate_Index)) _modelRotate_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPos", out _modelPos_Index)) _modelPos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelScale", out _modelScale_Index)) _modelScale_Index = -1;
                    if (!nameIndexs.TryGetValue("Title", out _title_Index)) _title_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareVIPTrueRecharge>(keyCount);
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
            if(HanderDefine.DataCallBack("VIPTrueRecharge", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareVIPTrueRecharge cfg = null;
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
        public static DeclareVIPTrueRecharge Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareVIPTrueRecharge result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("VIPTrueRecharge", out _compressData))
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
