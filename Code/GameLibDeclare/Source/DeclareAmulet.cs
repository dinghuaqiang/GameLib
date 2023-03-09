//文件是自动生成,请勿手动修改.来自数据文件:amulet
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareAmulet
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _condition_Index = -1;
        private static int _open_condition_Index = -1;
        private static int _active_skill_Index = -1;
        private static int _vfx_Index = -1;
        private static int _icon_Index = -1;
        private static int _des_Index = -1;
        private static int _abilityDes_Index = -1;
        private static int _exp_type_Index = -1;
        #endregion
        #region //私有变量定义
        //符咒唯一ID
        private int _id;
        //符咒名字
        private int _name;
        //激活条件（1_等级；2_需要完成的任务ID；3_需要完成的成就ID；4_境界等级；5_转职后的等级；(任务只支持主线)）(@_@)
        private int _condition;
        //符咒开启条件(@_@)
        private int _open_condition;
        //激活技能（职业ID_技能ID；职业ID_技能ID）(@;@_@)
        private int _active_skill;
        //符咒图片特效
        private int _vfx;
        //符咒列表图片
        private int _icon;
        //符咒描述 hide
        private int _des;
        //能力描述 hide
        private int _abilityDes;
        //服务器统计符咒经验显示用
        private int _exp_type;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public string OpenCondition { get{ return HanderDefine.SetStingCallBack(_open_condition); }}
        public string ActiveSkill { get{ return HanderDefine.SetStingCallBack(_active_skill); }}
        public string Vfx { get{ return HanderDefine.SetStingCallBack(_vfx); }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public string AbilityDes { get{ return HanderDefine.SetStingCallBack(_abilityDes); }}
        public int ExpType { get{ return _exp_type; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareAmulet cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareAmulet> _dataCaches = null;
        public static Dictionary<int, DeclareAmulet> CacheData
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
                        if (HanderDefine.DataCallBack("Amulet", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareAmulet cfg = null;
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
        private unsafe static DeclareAmulet LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareAmulet();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._open_condition = (int)GetValue(keyIndex, _open_condition_Index, ptr);
            tmp._active_skill = (int)GetValue(keyIndex, _active_skill_Index, ptr);
            tmp._vfx = (int)GetValue(keyIndex, _vfx_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._abilityDes = (int)GetValue(keyIndex, _abilityDes_Index, ptr);
            tmp._exp_type = (int)GetValue(keyIndex, _exp_type_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Amulet", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenCondition", out _open_condition_Index)) _open_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveSkill", out _active_skill_Index)) _active_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx", out _vfx_Index)) _vfx_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("AbilityDes", out _abilityDes_Index)) _abilityDes_Index = -1;
                    if (!nameIndexs.TryGetValue("ExpType", out _exp_type_Index)) _exp_type_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareAmulet>();
                        _dataIndexCaches = new Dictionary<int, int>();
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
            if(HanderDefine.DataCallBack("Amulet", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareAmulet cfg = null;
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
        public static DeclareAmulet Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareAmulet result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Amulet", out _compressData))
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
