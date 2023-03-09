//文件是自动生成,请勿手动修改.来自数据文件:Equip_holy_suit
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquipHolySuit
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _level_Index = -1;
        private static int _need_degree_Index = -1;
        private static int _quality_Index = -1;
        private static int _score_Index = -1;
        private static int _type_Index = -1;
        private static int _attribute_2_Index = -1;
        private static int _elementAttribute_2_Index = -1;
        private static int _attribute_4_Index = -1;
        private static int _elementAttribute_4_Index = -1;
        private static int _attribute_5_Index = -1;
        private static int _elementAttribute_5_Index = -1;
        private static int _attribute_6_Index = -1;
        private static int _elementAttribute_6_Index = -1;
        #endregion
        #region //私有变量定义
        //套装唯一ID
        //阶数*10000+品质*100+type字段
        //程度也是算的（不能修改ID规则）
        private int _id;
        //套装等级
        private int _level;
        //对应圣装阶数
        private int _need_degree;
        //装备品质(：1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩)
        private int _quality;
        //套装参考评分
        private int _score;
        //1.衣服套装
        //2.首饰套装
        //1，2对应第一套圣装
        //3，4对应第二套圣装
        //5，6对应第三套圣装
        private int _type;
        //2件套基础属性提升(@;@_@)
        private int _attribute_2;
        //2件套百分比属性提升(@;@_@)
        private int _elementAttribute_2;
        //4件套基础属性提升(@;@_@)
        private int _attribute_4;
        //4件套百分比属性提升(@;@_@)
        private int _elementAttribute_4;
        //5件套基础属性提升(@;@_@)
        private int _attribute_5;
        //5件套百分比属性提升(@;@_@)
        private int _elementAttribute_5;
        //6件套基础属性提升(@;@_@)
        private int _attribute_6;
        //6件套百分比属性提升(@;@_@)
        private int _elementAttribute_6;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Level { get{ return _level; }}
        public int NeedDegree { get{ return _need_degree; }}
        public int Quality { get{ return _quality; }}
        public int Score { get{ return _score; }}
        public int Type { get{ return _type; }}
        public string Attribute2 { get{ return HanderDefine.SetStingCallBack(_attribute_2); }}
        public string ElementAttribute2 { get{ return HanderDefine.SetStingCallBack(_elementAttribute_2); }}
        public string Attribute4 { get{ return HanderDefine.SetStingCallBack(_attribute_4); }}
        public string ElementAttribute4 { get{ return HanderDefine.SetStingCallBack(_elementAttribute_4); }}
        public string Attribute5 { get{ return HanderDefine.SetStingCallBack(_attribute_5); }}
        public string ElementAttribute5 { get{ return HanderDefine.SetStingCallBack(_elementAttribute_5); }}
        public string Attribute6 { get{ return HanderDefine.SetStingCallBack(_attribute_6); }}
        public string ElementAttribute6 { get{ return HanderDefine.SetStingCallBack(_elementAttribute_6); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquipHolySuit cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquipHolySuit> _dataCaches = null;
        public static Dictionary<int, DeclareEquipHolySuit> CacheData
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
                        if (HanderDefine.DataCallBack("EquipHolySuit", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquipHolySuit cfg = null;
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
        private unsafe static DeclareEquipHolySuit LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquipHolySuit();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._need_degree = (int)GetValue(keyIndex, _need_degree_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._attribute_2 = (int)GetValue(keyIndex, _attribute_2_Index, ptr);
            tmp._elementAttribute_2 = (int)GetValue(keyIndex, _elementAttribute_2_Index, ptr);
            tmp._attribute_4 = (int)GetValue(keyIndex, _attribute_4_Index, ptr);
            tmp._elementAttribute_4 = (int)GetValue(keyIndex, _elementAttribute_4_Index, ptr);
            tmp._attribute_5 = (int)GetValue(keyIndex, _attribute_5_Index, ptr);
            tmp._elementAttribute_5 = (int)GetValue(keyIndex, _elementAttribute_5_Index, ptr);
            tmp._attribute_6 = (int)GetValue(keyIndex, _attribute_6_Index, ptr);
            tmp._elementAttribute_6 = (int)GetValue(keyIndex, _elementAttribute_6_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("EquipHolySuit", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedDegree", out _need_degree_Index)) _need_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute2", out _attribute_2_Index)) _attribute_2_Index = -1;
                    if (!nameIndexs.TryGetValue("ElementAttribute2", out _elementAttribute_2_Index)) _elementAttribute_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute4", out _attribute_4_Index)) _attribute_4_Index = -1;
                    if (!nameIndexs.TryGetValue("ElementAttribute4", out _elementAttribute_4_Index)) _elementAttribute_4_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute5", out _attribute_5_Index)) _attribute_5_Index = -1;
                    if (!nameIndexs.TryGetValue("ElementAttribute5", out _elementAttribute_5_Index)) _elementAttribute_5_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute6", out _attribute_6_Index)) _attribute_6_Index = -1;
                    if (!nameIndexs.TryGetValue("ElementAttribute6", out _elementAttribute_6_Index)) _elementAttribute_6_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquipHolySuit>(keyCount);
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
            if(HanderDefine.DataCallBack("EquipHolySuit", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquipHolySuit cfg = null;
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
        public static DeclareEquipHolySuit Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquipHolySuit result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EquipHolySuit", out _compressData))
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
