//文件是自动生成,请勿手动修改.来自数据文件:state_stifle
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareStateStifle
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _level_Index = -1;
        private static int _star_Index = -1;
        private static int _back_vfx_Index = -1;
        private static int _condition_Index = -1;
        private static int _condition_desc_Index = -1;
        private static int _need_item_Index = -1;
        private static int _ex_damage_Index = -1;
        private static int _ex_damage_cd_Index = -1;
        private static int _att_Index = -1;
        private static int _exempt_state_Index = -1;
        private static int _modelID_Index = -1;
        #endregion
        #region //私有变量定义
        //等级*100+星级
        private int _id;
        //境界名字
        private int _name;
        //等级
        private int _level;
        //星级
        private int _star;
        //背景特效id
        private int _back_vfx;
        //升级需要条件(@_@)
        private int _condition;
        //升级条件描述(hide)
        private int _condition_desc;
        //升级需求物品(@_@)
        private int _need_item;
        //额外伤害
        private int _ex_damage;
        //额外伤害CD(单位毫秒)
        private int _ex_damage_cd;
        //额外属性
        private int _att;
        //免疫境界（0不免疫，非0表示小于等于的境界都免疫）
        private int _exempt_state;
        //是否激活新外观的外观ID
        private int _modelID;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Level { get{ return _level; }}
        public int Star { get{ return _star; }}
        public int BackVfx { get{ return _back_vfx; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public string ConditionDesc { get{ return HanderDefine.SetStingCallBack(_condition_desc); }}
        public string NeedItem { get{ return HanderDefine.SetStingCallBack(_need_item); }}
        public int ExDamage { get{ return _ex_damage; }}
        public int ExDamageCd { get{ return _ex_damage_cd; }}
        public string Att { get{ return HanderDefine.SetStingCallBack(_att); }}
        public int ExemptState { get{ return _exempt_state; }}
        public int ModelID { get{ return _modelID; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareStateStifle cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareStateStifle> _dataCaches = null;
        public static Dictionary<int, DeclareStateStifle> CacheData
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
                        if (HanderDefine.DataCallBack("StateStifle", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareStateStifle cfg = null;
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
        private unsafe static DeclareStateStifle LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareStateStifle();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._star = (int)GetValue(keyIndex, _star_Index, ptr);
            tmp._back_vfx = (int)GetValue(keyIndex, _back_vfx_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._condition_desc = (int)GetValue(keyIndex, _condition_desc_Index, ptr);
            tmp._need_item = (int)GetValue(keyIndex, _need_item_Index, ptr);
            tmp._ex_damage = (int)GetValue(keyIndex, _ex_damage_Index, ptr);
            tmp._ex_damage_cd = (int)GetValue(keyIndex, _ex_damage_cd_Index, ptr);
            tmp._att = (int)GetValue(keyIndex, _att_Index, ptr);
            tmp._exempt_state = (int)GetValue(keyIndex, _exempt_state_Index, ptr);
            tmp._modelID = (int)GetValue(keyIndex, _modelID_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("StateStifle", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Star", out _star_Index)) _star_Index = -1;
                    if (!nameIndexs.TryGetValue("BackVfx", out _back_vfx_Index)) _back_vfx_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionDesc", out _condition_desc_Index)) _condition_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedItem", out _need_item_Index)) _need_item_Index = -1;
                    if (!nameIndexs.TryGetValue("ExDamage", out _ex_damage_Index)) _ex_damage_Index = -1;
                    if (!nameIndexs.TryGetValue("ExDamageCd", out _ex_damage_cd_Index)) _ex_damage_cd_Index = -1;
                    if (!nameIndexs.TryGetValue("Att", out _att_Index)) _att_Index = -1;
                    if (!nameIndexs.TryGetValue("ExemptState", out _exempt_state_Index)) _exempt_state_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelID", out _modelID_Index)) _modelID_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareStateStifle>(keyCount);
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
            if(HanderDefine.DataCallBack("StateStifle", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareStateStifle cfg = null;
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
        public static DeclareStateStifle Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareStateStifle result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("StateStifle", out _compressData))
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
