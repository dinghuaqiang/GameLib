//文件是自动生成,请勿手动修改.来自数据文件:Equip_Collection
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquipCollection
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _grade_Index = -1;
        private static int _gender_Index = -1;
        private static int _describe_Index = -1;
        private static int _equip_Index = -1;
        private static int _att_Index = -1;
        private static int _standard_power_Index = -1;
        private static int _att1_Index = -1;
        private static int _att2_Index = -1;
        private static int _activit_title_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（职业*100+阶数）
        private int _id;
        //灵体的名字
        private int _name;
        //灵体的阶数
        private int _grade;
        //职业限制
        //0-男剑
        //1-女枪
        //2-待定
        //3-待定
        //4-待定
        //5-待定
        //9-通用
        private int _gender;
        //灵体开启需要的人物等级
        private int _describe;
        //需要的最低战斗力装备（部位ID_装备ID）
        private int _equip;
        //激活基础灵力
        private int _att;
        //需要的红色5星装备件数
        private int _standard_power;
        //战力达到后基础灵力
        private int _att1;
        //特殊百分比称号
        private int _att2;
        //激活的称号ID
        private int _activit_title;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Grade { get{ return _grade; }}
        public int Gender { get{ return _gender; }}
        public int Describe { get{ return _describe; }}
        public string Equip { get{ return HanderDefine.SetStingCallBack(_equip); }}
        public string Att { get{ return HanderDefine.SetStingCallBack(_att); }}
        public int StandardPower { get{ return _standard_power; }}
        public string Att1 { get{ return HanderDefine.SetStingCallBack(_att1); }}
        public string Att2 { get{ return HanderDefine.SetStingCallBack(_att2); }}
        public int ActivitTitle { get{ return _activit_title; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquipCollection cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquipCollection> _dataCaches = null;
        public static Dictionary<int, DeclareEquipCollection> CacheData
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
                        if (HanderDefine.DataCallBack("EquipCollection", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquipCollection cfg = null;
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
        private unsafe static DeclareEquipCollection LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquipCollection();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._grade = (int)GetValue(keyIndex, _grade_Index, ptr);
            tmp._gender = (int)GetValue(keyIndex, _gender_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            tmp._equip = (int)GetValue(keyIndex, _equip_Index, ptr);
            tmp._att = (int)GetValue(keyIndex, _att_Index, ptr);
            tmp._standard_power = (int)GetValue(keyIndex, _standard_power_Index, ptr);
            tmp._att1 = (int)GetValue(keyIndex, _att1_Index, ptr);
            tmp._att2 = (int)GetValue(keyIndex, _att2_Index, ptr);
            tmp._activit_title = (int)GetValue(keyIndex, _activit_title_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("EquipCollection", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Grade", out _grade_Index)) _grade_Index = -1;
                    if (!nameIndexs.TryGetValue("Gender", out _gender_Index)) _gender_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
                    if (!nameIndexs.TryGetValue("Equip", out _equip_Index)) _equip_Index = -1;
                    if (!nameIndexs.TryGetValue("Att", out _att_Index)) _att_Index = -1;
                    if (!nameIndexs.TryGetValue("StandardPower", out _standard_power_Index)) _standard_power_Index = -1;
                    if (!nameIndexs.TryGetValue("Att1", out _att1_Index)) _att1_Index = -1;
                    if (!nameIndexs.TryGetValue("Att2", out _att2_Index)) _att2_Index = -1;
                    if (!nameIndexs.TryGetValue("ActivitTitle", out _activit_title_Index)) _activit_title_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquipCollection>(keyCount);
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
            if(HanderDefine.DataCallBack("EquipCollection", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquipCollection cfg = null;
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
        public static DeclareEquipCollection Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquipCollection result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EquipCollection", out _compressData))
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
