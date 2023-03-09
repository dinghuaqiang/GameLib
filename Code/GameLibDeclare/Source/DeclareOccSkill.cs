//文件是自动生成,请勿手动修改.来自数据文件:Occ_Skill
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareOccSkill
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _mental_ID_Index = -1;
        private static int _occ_Index = -1;
        private static int _position_Index = -1;
        private static int _if_tuibian_Index = -1;
        private static int _passive_level_Index = -1;
        private static int _skill_id_Index = -1;
        private static int _passive_skill_id_Index = -1;
        private static int _tuibian_item_Index = -1;
        private static int _level_item_Index = -1;
        #endregion
        #region //私有变量定义
        //技能ID(心法ID*100000+职业*10000+技能位置*1000+蜕变*100+被动等级）
        private int _iD;
        //心法ID（组ID）
        private int _mental_ID;
        //职业（0，男剑；1，女枪）
        private int _occ;
        //技能位置（0，普攻；1-4从左至右的4个技能。）
        private int _position;
        //是否是蜕变（0，不蜕变；1，蜕变）
        private int _if_tuibian;
        //被动等级
        private int _passive_level;
        //关联伤害技能
        private int _skill_id;
        //关联被动技能
        private int _passive_skill_id;
        //蜕变消耗（物品ID_数量）
        private int _tuibian_item;
        //升级消耗（物品ID_数量）
        private int _level_item;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int MentalID { get{ return _mental_ID; }}
        public int Occ { get{ return _occ; }}
        public int Position { get{ return _position; }}
        public int IfTuibian { get{ return _if_tuibian; }}
        public int PassiveLevel { get{ return _passive_level; }}
        public string SkillId { get{ return HanderDefine.SetStingCallBack(_skill_id); }}
        public string PassiveSkillId { get{ return HanderDefine.SetStingCallBack(_passive_skill_id); }}
        public string TuibianItem { get{ return HanderDefine.SetStingCallBack(_tuibian_item); }}
        public string LevelItem { get{ return HanderDefine.SetStingCallBack(_level_item); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareOccSkill cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareOccSkill> _dataCaches = null;
        public static Dictionary<int, DeclareOccSkill> CacheData
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
                        if (HanderDefine.DataCallBack("OccSkill", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareOccSkill cfg = null;
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
        private unsafe static DeclareOccSkill LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareOccSkill();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._mental_ID = (int)GetValue(keyIndex, _mental_ID_Index, ptr);
            tmp._occ = (int)GetValue(keyIndex, _occ_Index, ptr);
            tmp._position = (int)GetValue(keyIndex, _position_Index, ptr);
            tmp._if_tuibian = (int)GetValue(keyIndex, _if_tuibian_Index, ptr);
            tmp._passive_level = (int)GetValue(keyIndex, _passive_level_Index, ptr);
            tmp._skill_id = (int)GetValue(keyIndex, _skill_id_Index, ptr);
            tmp._passive_skill_id = (int)GetValue(keyIndex, _passive_skill_id_Index, ptr);
            tmp._tuibian_item = (int)GetValue(keyIndex, _tuibian_item_Index, ptr);
            tmp._level_item = (int)GetValue(keyIndex, _level_item_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("OccSkill", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("MentalID", out _mental_ID_Index)) _mental_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ", out _occ_Index)) _occ_Index = -1;
                    if (!nameIndexs.TryGetValue("Position", out _position_Index)) _position_Index = -1;
                    if (!nameIndexs.TryGetValue("IfTuibian", out _if_tuibian_Index)) _if_tuibian_Index = -1;
                    if (!nameIndexs.TryGetValue("PassiveLevel", out _passive_level_Index)) _passive_level_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillId", out _skill_id_Index)) _skill_id_Index = -1;
                    if (!nameIndexs.TryGetValue("PassiveSkillId", out _passive_skill_id_Index)) _passive_skill_id_Index = -1;
                    if (!nameIndexs.TryGetValue("TuibianItem", out _tuibian_item_Index)) _tuibian_item_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelItem", out _level_item_Index)) _level_item_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareOccSkill>(keyCount);
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
            if(HanderDefine.DataCallBack("OccSkill", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareOccSkill cfg = null;
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
        public static DeclareOccSkill Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareOccSkill result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("OccSkill", out _compressData))
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
