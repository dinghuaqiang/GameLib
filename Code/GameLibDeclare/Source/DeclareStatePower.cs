//文件是自动生成,请勿手动修改.来自数据文件:state_power
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareStatePower
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _group_Index = -1;
        private static int _specail_Index = -1;
        private static int _specail_clone_Index = -1;
        private static int _show_des_Index = -1;
        private static int _show_modele_Index = -1;
        private static int _model_size_Index = -1;
        private static int _fly_sword_size_Index = -1;
        private static int _fly_sword_modele_Index = -1;
        private static int _reward_Index = -1;
        private static int _value_Index = -1;
        private static int _skill_icon_Index = -1;
        private static int _skill_hurt_Index = -1;
        private static int _skill_effect_Index = -1;
        private static int _xP_skill_Index = -1;
        #endregion
        #region //私有变量定义
        //表示境界等级
        private int _id;
        //境界名字
        private int _name;
        //分组，用于界面显示
        //（hide）
        private int _group;
        //默认为0表示小境界，突破
        //1表示大境界需要渡劫
        private int _specail;
        //需要渡劫的时候进入的特殊场景
        //副本ID，坐标点，
        //地图_出入坐标点_位面坐标点_位面地图
        private int _specail_clone;
        //大境界时候，显示在面板的描述(hide)
        private int _show_des;
        //渡劫时临时给与的modleID，(hide)
        //用于客户端做表现
        private int _show_modele;
        //渡劫界面展示的model缩放;旋转;X_Y(hide)
        private int _model_size;
        //境界界面飞剑展示模型缩放，旋转
        //缩放_旋转_位置（X_Y)
        //(hide)
        private int _fly_sword_size;
        //渡劫后给与玩家的飞剑化形
        private int _fly_sword_modele;
        //激活境界获得的奖励道具和数量(@;@_@)
        private int _reward;
        //属性(@;@_@)
        private int _value;
        //技能Icon
        private int _skill_icon;
        //界面显示的技能伤害文字描述参数
        //（hide）
        private int _skill_hurt;
        //type_参数
        //type1=固定值
        //type2=生命上限百分比(万分比）
        //type3=固定值+百分比
        //使用XP技能时回复生命值的技能效果字段
        //客户端描述配置在global 4830
        private int _skill_effect;
        //界面显示对应的技能Id(对应skill表的主键ID）
        //（hide）
        private int _xP_skill;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Group { get{ return _group; }}
        public int Specail { get{ return _specail; }}
        public string SpecailClone { get{ return HanderDefine.SetStingCallBack(_specail_clone); }}
        public string ShowDes { get{ return HanderDefine.SetStingCallBack(_show_des); }}
        public string ShowModele { get{ return HanderDefine.SetStingCallBack(_show_modele); }}
        public string ModelSize { get{ return HanderDefine.SetStingCallBack(_model_size); }}
        public string FlySwordSize { get{ return HanderDefine.SetStingCallBack(_fly_sword_size); }}
        public int FlySwordModele { get{ return _fly_sword_modele; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string Value { get{ return HanderDefine.SetStingCallBack(_value); }}
        public int SkillIcon { get{ return _skill_icon; }}
        public int SkillHurt { get{ return _skill_hurt; }}
        public string SkillEffect { get{ return HanderDefine.SetStingCallBack(_skill_effect); }}
        public int XPSkill { get{ return _xP_skill; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareStatePower cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareStatePower> _dataCaches = null;
        public static Dictionary<int, DeclareStatePower> CacheData
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
                        if (HanderDefine.DataCallBack("StatePower", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareStatePower cfg = null;
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
        private unsafe static DeclareStatePower LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareStatePower();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._specail = (int)GetValue(keyIndex, _specail_Index, ptr);
            tmp._specail_clone = (int)GetValue(keyIndex, _specail_clone_Index, ptr);
            tmp._show_des = (int)GetValue(keyIndex, _show_des_Index, ptr);
            tmp._show_modele = (int)GetValue(keyIndex, _show_modele_Index, ptr);
            tmp._model_size = (int)GetValue(keyIndex, _model_size_Index, ptr);
            tmp._fly_sword_size = (int)GetValue(keyIndex, _fly_sword_size_Index, ptr);
            tmp._fly_sword_modele = (int)GetValue(keyIndex, _fly_sword_modele_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._value = (int)GetValue(keyIndex, _value_Index, ptr);
            tmp._skill_icon = (int)GetValue(keyIndex, _skill_icon_Index, ptr);
            tmp._skill_hurt = (int)GetValue(keyIndex, _skill_hurt_Index, ptr);
            tmp._skill_effect = (int)GetValue(keyIndex, _skill_effect_Index, ptr);
            tmp._xP_skill = (int)GetValue(keyIndex, _xP_skill_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("StatePower", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Specail", out _specail_Index)) _specail_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecailClone", out _specail_clone_Index)) _specail_clone_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowDes", out _show_des_Index)) _show_des_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModele", out _show_modele_Index)) _show_modele_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelSize", out _model_size_Index)) _model_size_Index = -1;
                    if (!nameIndexs.TryGetValue("FlySwordSize", out _fly_sword_size_Index)) _fly_sword_size_Index = -1;
                    if (!nameIndexs.TryGetValue("FlySwordModele", out _fly_sword_modele_Index)) _fly_sword_modele_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Value", out _value_Index)) _value_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillIcon", out _skill_icon_Index)) _skill_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillHurt", out _skill_hurt_Index)) _skill_hurt_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillEffect", out _skill_effect_Index)) _skill_effect_Index = -1;
                    if (!nameIndexs.TryGetValue("XPSkill", out _xP_skill_Index)) _xP_skill_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareStatePower>(keyCount);
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
            if(HanderDefine.DataCallBack("StatePower", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareStatePower cfg = null;
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
        public static DeclareStatePower Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareStatePower result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("StatePower", out _compressData))
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
