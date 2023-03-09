//文件是自动生成,请勿手动修改.来自数据文件:immortal_soul_attribute
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareImmortalSoulAttribute
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _quality_Index = -1;
        private static int _star_Index = -1;
        private static int _exclusive_ID_Index = -1;
        private static int _icon_Index = -1;
        private static int _demand_value_Index = -1;
        private static int _basic_attributes_Index = -1;
        private static int _demand_value_percent_Index = -1;
        private static int _basic_attributes_percent_Index = -1;
        private static int _exchange_Consumption_Index = -1;
        private static int _exchange_ranking_Index = -1;
        private static int _exp_Index = -1;
        private static int _overview_conditions_Index = -1;
        private static int _exchange_conditions_Index = -1;
        private static int _type2_Index = -1;
        private static int _level_max_Index = -1;
        private static int _grid_Index = -1;
        #endregion
        #region //私有变量定义
        //仙魄id(6000000+type*100000+quality*1000+exclusive_ID)
        private int _id;
        //名称
        private int _name;
        //仙魄类型,1属性仙魄.2经验类仙魄3扩展仙魄
        private int _type;
        //品质(3蓝,4紫,6金,7红)
        private int _quality;
        //展示的星星数
        private int _star;
        //镶嵌互斥类型
        //比对互斥id,相同id互斥
        private int _exclusive_ID;
        //icon
        private int _icon;
        //基础属性
        private int _demand_value;
        //每级加成属性
        private int _basic_attributes;
        //基础百分比属性
        private int _demand_value_percent;
        //每级百分比加成属性
        private int _basic_attributes_percent;
        //兑换所需仙魄积分
        private int _exchange_Consumption;
        //兑换排序,从小到大排序,从左到右的排列((0或空则不再兑换界面显示)
        private int _exchange_ranking;
        //初始分解经验
        private int _exp;
        //总览显示条件,层数_行数_列数
        private int _overview_conditions;
        //所有获取所需爬塔层数(FunctionVariablea中条件)
        private int _exchange_conditions;
        //仙魄归类,用来判断镶嵌和替换时是否为同类
        private int _type2;
        //等级上限
        private int _level_max;
        //可镶嵌的格子ID
        private int _grid;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Quality { get{ return _quality; }}
        public int Star { get{ return _star; }}
        public int ExclusiveID { get{ return _exclusive_ID; }}
        public int Icon { get{ return _icon; }}
        public string DemandValue { get{ return HanderDefine.SetStingCallBack(_demand_value); }}
        public string BasicAttributes { get{ return HanderDefine.SetStingCallBack(_basic_attributes); }}
        public string DemandValuePercent { get{ return HanderDefine.SetStingCallBack(_demand_value_percent); }}
        public string BasicAttributesPercent { get{ return HanderDefine.SetStingCallBack(_basic_attributes_percent); }}
        public string ExchangeConsumption { get{ return HanderDefine.SetStingCallBack(_exchange_Consumption); }}
        public int ExchangeRanking { get{ return _exchange_ranking; }}
        public int Exp { get{ return _exp; }}
        public string OverviewConditions { get{ return HanderDefine.SetStingCallBack(_overview_conditions); }}
        public string ExchangeConditions { get{ return HanderDefine.SetStingCallBack(_exchange_conditions); }}
        public int Type2 { get{ return _type2; }}
        public int LevelMax { get{ return _level_max; }}
        public string Grid { get{ return HanderDefine.SetStingCallBack(_grid); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareImmortalSoulAttribute cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareImmortalSoulAttribute> _dataCaches = null;
        public static Dictionary<int, DeclareImmortalSoulAttribute> CacheData
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
                        if (HanderDefine.DataCallBack("ImmortalSoulAttribute", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareImmortalSoulAttribute cfg = null;
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
        private unsafe static DeclareImmortalSoulAttribute LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareImmortalSoulAttribute();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            tmp._exclusive_ID = (int)GetValue(keyIndex, _exclusive_ID_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._demand_value = (int)GetValue(keyIndex, _demand_value_Index, ptr);
            tmp._basic_attributes = (int)GetValue(keyIndex, _basic_attributes_Index, ptr);
            tmp._demand_value_percent = (int)GetValue(keyIndex, _demand_value_percent_Index, ptr);
            tmp._basic_attributes_percent = (int)GetValue(keyIndex, _basic_attributes_percent_Index, ptr);
            tmp._exchange_Consumption = (int)GetValue(keyIndex, _exchange_Consumption_Index, ptr);
            tmp._exchange_ranking = (int)GetValue(keyIndex, _exchange_ranking_Index, ptr);
            tmp._exp = (int)GetValue(keyIndex, _exp_Index, ptr);
            tmp._overview_conditions = (int)GetValue(keyIndex, _overview_conditions_Index, ptr);
            tmp._exchange_conditions = (int)GetValue(keyIndex, _exchange_conditions_Index, ptr);
            tmp._type2 = (int)GetValue(keyIndex, _type2_Index, ptr);
            tmp._level_max = (int)GetValue(keyIndex, _level_max_Index, ptr);
            tmp._grid = (int)GetValue(keyIndex, _grid_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ImmortalSoulAttribute", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
                    if (!nameIndexs.TryGetValue("ExclusiveID", out _exclusive_ID_Index)) _exclusive_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("DemandValue", out _demand_value_Index)) _demand_value_Index = -1;
                    if (!nameIndexs.TryGetValue("BasicAttributes", out _basic_attributes_Index)) _basic_attributes_Index = -1;
                    if (!nameIndexs.TryGetValue("DemandValuePercent", out _demand_value_percent_Index)) _demand_value_percent_Index = -1;
                    if (!nameIndexs.TryGetValue("BasicAttributesPercent", out _basic_attributes_percent_Index)) _basic_attributes_percent_Index = -1;
                    if (!nameIndexs.TryGetValue("ExchangeConsumption", out _exchange_Consumption_Index)) _exchange_Consumption_Index = -1;
                    if (!nameIndexs.TryGetValue("ExchangeRanking", out _exchange_ranking_Index)) _exchange_ranking_Index = -1;
                    if (!nameIndexs.TryGetValue("Exp", out _exp_Index)) _exp_Index = -1;
                    if (!nameIndexs.TryGetValue("OverviewConditions", out _overview_conditions_Index)) _overview_conditions_Index = -1;
                    if (!nameIndexs.TryGetValue("ExchangeConditions", out _exchange_conditions_Index)) _exchange_conditions_Index = -1;
                    if (!nameIndexs.TryGetValue("Type2", out _type2_Index)) _type2_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelMax", out _level_max_Index)) _level_max_Index = -1;
                    if (!nameIndexs.TryGetValue("Grid", out _grid_Index)) _grid_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareImmortalSoulAttribute>(keyCount);
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
            if(HanderDefine.DataCallBack("ImmortalSoulAttribute", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareImmortalSoulAttribute cfg = null;
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
        public static DeclareImmortalSoulAttribute Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareImmortalSoulAttribute result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ImmortalSoulAttribute", out _compressData))
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
