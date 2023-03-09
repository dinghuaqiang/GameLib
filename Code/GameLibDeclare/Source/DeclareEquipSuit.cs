//文件是自动生成,请勿手动修改.来自数据文件:Equip_suit
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquipSuit
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _prefix_Index = -1;
        private static int _name_Index = -1;
        private static int _level_Index = -1;
        private static int _need_degree_Index = -1;
        private static int _need_quality_Index = -1;
        private static int _need_diamonds_Index = -1;
        private static int _need_gender_Index = -1;
        private static int _need_parts_Index = -1;
        private static int _need_items_Index = -1;
        private static int _attribute_1_Index = -1;
        private static int _attribute_2_Index = -1;
        private static int _attribute_4_Index = -1;
        private static int _attribute_6_Index = -1;
        private static int _parent_ID_Index = -1;
        #endregion
        #region //私有变量定义
        //套装唯一ID  套装等级*10000+阶数*100+顺序id(1~99)
        private int _id;
        //套装前缀
        private int _prefix;
        //套装名字
        private int _name;
        //套装等级
        private int _level;
        //需求装备阶数(@_@)
        private int _need_degree;
        //需求的品质
        private int _need_quality;
        //需求钻石数量
        private int _need_diamonds;
        //职业限制
        //0-执笔者；1-拳师；2-大锤；3-太刀；4-卡牌；5-枪手(@_@)
        private int _need_gender;
        //需求部位(@_@)
        private int _need_parts;
        //锻造所需材料（部位_ID_num）(@;@_@)
        private int _need_items;
        //套装属性1(@;@_@)
        private int _attribute_1;
        //套装属性2(@;@_@)
        private int _attribute_2;
        //套装属性4(@;@_@)
        private int _attribute_4;
        //套装属性6(@;@_@)
        private int _attribute_6;
        //父类ID，填写神怒套上层天怒套ID用于套装石返还
        private int _parent_ID;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Prefix { get{ return HanderDefine.SetStingCallBack(_prefix); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Level { get{ return _level; }}
        public string NeedDegree { get{ return HanderDefine.SetStingCallBack(_need_degree); }}
        public int NeedQuality { get{ return _need_quality; }}
        public int NeedDiamonds { get{ return _need_diamonds; }}
        public string NeedGender { get{ return HanderDefine.SetStingCallBack(_need_gender); }}
        public string NeedParts { get{ return HanderDefine.SetStingCallBack(_need_parts); }}
        public string NeedItems { get{ return HanderDefine.SetStingCallBack(_need_items); }}
        public string Attribute1 { get{ return HanderDefine.SetStingCallBack(_attribute_1); }}
        public string Attribute2 { get{ return HanderDefine.SetStingCallBack(_attribute_2); }}
        public string Attribute4 { get{ return HanderDefine.SetStingCallBack(_attribute_4); }}
        public string Attribute6 { get{ return HanderDefine.SetStingCallBack(_attribute_6); }}
        public int ParentID { get{ return _parent_ID; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquipSuit cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquipSuit> _dataCaches = null;
        public static Dictionary<int, DeclareEquipSuit> CacheData
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
                        if (HanderDefine.DataCallBack("EquipSuit", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquipSuit cfg = null;
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
        private unsafe static DeclareEquipSuit LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquipSuit();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._prefix = (int)GetValue(keyIndex, _prefix_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._need_degree = (int)GetValue(keyIndex, _need_degree_Index, ptr);
            tmp._need_quality = (int)GetValue(keyIndex, _need_quality_Index, ptr);
            tmp._need_diamonds = (int)GetValue(keyIndex, _need_diamonds_Index, ptr);
            tmp._need_gender = (int)GetValue(keyIndex, _need_gender_Index, ptr);
            tmp._need_parts = (int)GetValue(keyIndex, _need_parts_Index, ptr);
            tmp._need_items = (int)GetValue(keyIndex, _need_items_Index, ptr);
            tmp._attribute_1 = (int)GetValue(keyIndex, _attribute_1_Index, ptr);
            tmp._attribute_2 = (int)GetValue(keyIndex, _attribute_2_Index, ptr);
            tmp._attribute_4 = (int)GetValue(keyIndex, _attribute_4_Index, ptr);
            tmp._attribute_6 = (int)GetValue(keyIndex, _attribute_6_Index, ptr);
            tmp._parent_ID = (int)GetValue(keyIndex, _parent_ID_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("EquipSuit", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Prefix", out _prefix_Index)) _prefix_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedDegree", out _need_degree_Index)) _need_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedQuality", out _need_quality_Index)) _need_quality_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedDiamonds", out _need_diamonds_Index)) _need_diamonds_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedGender", out _need_gender_Index)) _need_gender_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedParts", out _need_parts_Index)) _need_parts_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedItems", out _need_items_Index)) _need_items_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute1", out _attribute_1_Index)) _attribute_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute2", out _attribute_2_Index)) _attribute_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute4", out _attribute_4_Index)) _attribute_4_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute6", out _attribute_6_Index)) _attribute_6_Index = -1;
                    if (!nameIndexs.TryGetValue("ParentID", out _parent_ID_Index)) _parent_ID_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquipSuit>(keyCount);
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
            if(HanderDefine.DataCallBack("EquipSuit", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquipSuit cfg = null;
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
        public static DeclareEquipSuit Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquipSuit result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EquipSuit", out _compressData))
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
