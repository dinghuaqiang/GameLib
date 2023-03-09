//文件是自动生成,请勿手动修改.来自数据文件:skill_meridian_new
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSkillMeridianNew
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _occ_Index = -1;
        private static int _type_Index = -1;
        private static int _meridian_id_Index = -1;
        private static int _level_Index = -1;
        private static int _max_level_Index = -1;
        private static int _add_att_Index = -1;
        private static int _add_passive_skill_Index = -1;
        private static int _add_skill_Index = -1;
        private static int _need_parent_id_Index = -1;
        private static int _need_value_Index = -1;
        private static int _desc_Index = -1;
        private static int _tag_back_Index = -1;
        private static int _tag_text_Index = -1;
        #endregion
        #region //私有变量定义
        //key值（职业*1000000+所属经脉*10000+格子*100+等级）
        private int _id;
        //经脉名称 (hide)
        private int _name;
        private int _icon;
        //所属职业
        private int _occ;
        //所属经脉大类
        private int _type;
        //经脉ID
        private int _meridian_id;
        //等级
        private int _level;
        //最大等级，方便读取
        private int _max_level;
        //经脉增加的属性
        private int _add_att;
        //经脉增加的被动技能
        private int _add_passive_skill;
        //经脉增加的主动技能
        private int _add_skill;
        //需要父经脉id，使用本表的id字段
        private int _need_parent_id;
        //学习需要货币_点数
        private int _need_value;
        //天赋描述（hide）
        private int _desc;
        //标签底索引 hide 1紫色；2橙色；3蓝色
        private int _tag_back;
        //标签内容 hide
        private int _tag_text;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int Occ { get{ return _occ; }}
        public int Type { get{ return _type; }}
        public int MeridianId { get{ return _meridian_id; }}
        public int Level { get{ return _level; }}
        public int MaxLevel { get{ return _max_level; }}
        public string AddAtt { get{ return HanderDefine.SetStingCallBack(_add_att); }}
        public int AddPassiveSkill { get{ return _add_passive_skill; }}
        public int AddSkill { get{ return _add_skill; }}
        public int NeedParentId { get{ return _need_parent_id; }}
        public string NeedValue { get{ return HanderDefine.SetStingCallBack(_need_value); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int TagBack { get{ return _tag_back; }}
        public string TagText { get{ return HanderDefine.SetStingCallBack(_tag_text); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSkillMeridianNew cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSkillMeridianNew> _dataCaches = null;
        public static Dictionary<int, DeclareSkillMeridianNew> CacheData
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
                        if (HanderDefine.DataCallBack("SkillMeridianNew", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSkillMeridianNew cfg = null;
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
        private unsafe static DeclareSkillMeridianNew LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSkillMeridianNew();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._occ = (int)GetValue(keyIndex, _occ_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._meridian_id = (int)GetValue(keyIndex, _meridian_id_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._max_level = (int)GetValue(keyIndex, _max_level_Index, ptr);
            tmp._add_att = (int)GetValue(keyIndex, _add_att_Index, ptr);
            tmp._add_passive_skill = (int)GetValue(keyIndex, _add_passive_skill_Index, ptr);
            tmp._add_skill = (int)GetValue(keyIndex, _add_skill_Index, ptr);
            tmp._need_parent_id = (int)GetValue(keyIndex, _need_parent_id_Index, ptr);
            tmp._need_value = (int)GetValue(keyIndex, _need_value_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._tag_back = (int)GetValue(keyIndex, _tag_back_Index, ptr);
            tmp._tag_text = (int)GetValue(keyIndex, _tag_text_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SkillMeridianNew", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ", out _occ_Index)) _occ_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("MeridianId", out _meridian_id_Index)) _meridian_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _max_level_Index)) _max_level_Index = -1;
                    if (!nameIndexs.TryGetValue("AddAtt", out _add_att_Index)) _add_att_Index = -1;
                    if (!nameIndexs.TryGetValue("AddPassiveSkill", out _add_passive_skill_Index)) _add_passive_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("AddSkill", out _add_skill_Index)) _add_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedParentId", out _need_parent_id_Index)) _need_parent_id_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedValue", out _need_value_Index)) _need_value_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("TagBack", out _tag_back_Index)) _tag_back_Index = -1;
                    if (!nameIndexs.TryGetValue("TagText", out _tag_text_Index)) _tag_text_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSkillMeridianNew>(keyCount);
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
            if(HanderDefine.DataCallBack("SkillMeridianNew", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSkillMeridianNew cfg = null;
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
        public static DeclareSkillMeridianNew Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSkillMeridianNew result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SkillMeridianNew", out _compressData))
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
