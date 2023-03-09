//文件是自动生成,请勿手动修改.来自数据文件:sevenday_login
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSevendayLogin
    {
        #region //静态变量定义
        private static int _day_Index = -1;
        private static int _award_Index = -1;
        private static int _showItemDesc_Index = -1;
        private static int _showEffect_Index = -1;
        private static int _modelId_Index = -1;
        private static int _modelName_Index = -1;
        private static int _modelRotate_Index = -1;
        private static int _modelPos_Index = -1;
        private static int _modelScale_Index = -1;
        private static int _rewardDay_Index = -1;
        private static int _panelWord_Index = -1;
        #endregion
        #region //私有变量定义
        //累积登录天数
        private int _day;
        //签到奖励(@;@_@)ID_数量_是否绑定（0否1是）
        //ID_num_bind_occ
        //ID：对应Item表主键
        //num:数量
        //bind:0未绑定 1绑定
        //occ：0男 1女 9通用
        private int _award;
        //显示在对应格子上的文字
        //第一个参数代表第几个物品格子
        //第二个参数代表显示的具体文字内容（最好不超过2个字）
        //（hide）
        private int _showItemDesc;
        //较好的奖励显示特效，配置哪些格子需要显示转圈特效
        //(hide)
        private int _showEffect;
        //需要显示出来的模型ID（hide）
        //modelID_occ
        //occ=0男1女9通用
        private int _modelId;
        //模型对应显示的名字
        //由于名字会在各个配置表，不方便取，所有增加一个字段来进行配置
        private int _modelName;
        //模型展示，旋转
        //X_Y_Z_occ
        //按照对应坐标轴旋转
        //可针对不同职业进行配置
        //（hide）
        private int _modelRotate;
        //模型展示，位置
        //X_Y_Z
        //（hide）
        private int _modelPos;
        //模型倍数
        //计算方式：320/（ModelRoot里的值）*100
        //（hide）
        private int _modelScale;
        //距离大奖可领取的天数
        private int _rewardDay;
        //主界面显示的提示文字
        //（hide）
        private int _panelWord;
        #endregion

        #region //公共属性
        public int Day { get{ return _day; }}
        public string Award { get{ return HanderDefine.SetStingCallBack(_award); }}
        public string ShowItemDesc { get{ return HanderDefine.SetStingCallBack(_showItemDesc); }}
        public string ShowEffect { get{ return HanderDefine.SetStingCallBack(_showEffect); }}
        public string ModelId { get{ return HanderDefine.SetStingCallBack(_modelId); }}
        public string ModelName { get{ return HanderDefine.SetStingCallBack(_modelName); }}
        public string ModelRotate { get{ return HanderDefine.SetStingCallBack(_modelRotate); }}
        public string ModelPos { get{ return HanderDefine.SetStingCallBack(_modelPos); }}
        public int ModelScale { get{ return _modelScale; }}
        public int RewardDay { get{ return _rewardDay; }}
        public string PanelWord { get{ return HanderDefine.SetStingCallBack(_panelWord); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSevendayLogin cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSevendayLogin> _dataCaches = null;
        public static Dictionary<int, DeclareSevendayLogin> CacheData
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
                        if (HanderDefine.DataCallBack("SevendayLogin", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSevendayLogin cfg = null;
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
        private unsafe static DeclareSevendayLogin LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSevendayLogin();
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._award = (int)GetValue(keyIndex, _award_Index, ptr);
            tmp._showItemDesc = (int)GetValue(keyIndex, _showItemDesc_Index, ptr);
            tmp._showEffect = (int)GetValue(keyIndex, _showEffect_Index, ptr);
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._modelName = (int)GetValue(keyIndex, _modelName_Index, ptr);
            tmp._modelRotate = (int)GetValue(keyIndex, _modelRotate_Index, ptr);
            tmp._modelPos = (int)GetValue(keyIndex, _modelPos_Index, ptr);
            tmp._modelScale = (int)GetValue(keyIndex, _modelScale_Index, ptr);
            tmp._rewardDay = (int)GetValue(keyIndex, _rewardDay_Index, ptr);
            tmp._panelWord = (int)GetValue(keyIndex, _panelWord_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SevendayLogin", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("Award", out _award_Index)) _award_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItemDesc", out _showItemDesc_Index)) _showItemDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowEffect", out _showEffect_Index)) _showEffect_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelName", out _modelName_Index)) _modelName_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRotate", out _modelRotate_Index)) _modelRotate_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPos", out _modelPos_Index)) _modelPos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelScale", out _modelScale_Index)) _modelScale_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardDay", out _rewardDay_Index)) _rewardDay_Index = -1;
                    if (!nameIndexs.TryGetValue("PanelWord", out _panelWord_Index)) _panelWord_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSevendayLogin>(keyCount);
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
            if(HanderDefine.DataCallBack("SevendayLogin", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSevendayLogin cfg = null;
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
        public static DeclareSevendayLogin Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSevendayLogin result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SevendayLogin", out _compressData))
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
