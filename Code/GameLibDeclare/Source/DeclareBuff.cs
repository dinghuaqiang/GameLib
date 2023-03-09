//文件是自动生成,请勿手动修改.来自数据文件:buff
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBuff
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _desc_Index = -1;
        private static int _type_Index = -1;
        private static int _group_Index = -1;
        private static int _overlap_Index = -1;
        private static int _level_Index = -1;
        private static int _icon_Index = -1;
        private static int _buffVfx_Index = -1;
        private static int _vfxScal_Index = -1;
        private static int _vfxSlot_Index = -1;
        private static int _param1_Index = -1;
        private static int _param2_Index = -1;
        private static int _param3_Index = -1;
        private static int _param4_Index = -1;
        private static int _targetType_Index = -1;
        private static int _addsub_Index = -1;
        private static int _wenzi_Index = -1;
        private static int _d_time_Index = -1;
        private static int _condi_Index = -1;
        private static int _if_send_Index = -1;
        private static int _if_changemap_Index = -1;
        private static int _if_show_Index = -1;
        #endregion
        #region //私有变量定义
        //buffid
        private int _id;
        //buff名称
        private int _name;
        //buff描述 hide
        private int _desc;
        //Type_None = 0; //0：无效果
        //Type_Attribute = 1;// 1：属性
        //Type_HpPool = 2; //2：血池
        //Type_DecHp = 3;//3：掉血 
        //Type_DecAllHpRate = 4;// 4：掉血总值万分比 
        //Type_DecCurHpRate = 5;// 5：掉血当前值万分比 
        //Type_AddHp = 6;// 6：治疗
        //Type_addAllHpRate = 7; //7：治疗总值万分比 
        //Type_addCurHpRate = 8; //7：治疗当前值万分比
        //Type_SuperMan = 9; //7：霸体状态
        //Type_MoneyRate = 10; //7：金币倍率 param1：倍率万分比
        //Type_ExpRate = 11; //7：经验倍率 param1：倍率万分比
        //Type_Guiying = 12; //鬼影buff
        //SuperPveBuff = 13; //击杀周围怪物
        //Type_RoleInvisible = 14;//角色隐身
        //Type_DING = 15;//定身BUFF
        //Type_MiaoKang = 16;//免控BUFF
        //Type_ReDamageFromBoss = 17;// boss收到的伤害按比例施加到玩家身上
        //Type_BigBoom = 18;// 给player或者monster挂一个,结束时候炸周围的人固定伤害
        //Type_PosTriggerBuff = 19;// 位置触发事件的buff
        //Type_TriggerSummonBuff = 20;// 触发召唤物的buff
        //Type_Dizziness = 21;//眩晕的BUFF
        //Type_Bianshen = 22; //变身buff
        //Type_Chuandao = 23; //传道buff
        //Type_FeiJian = 24; //飞剑buff
        //Type_jinliao = 25; //禁疗buff
        private int _type;
        //分组(同组高等级顶替低等级)
        private int _group;
        //叠加次数 (额外规则-1同buff顶替)
        private int _overlap;
        //等级
        private int _level;
        //buff图标
        private int _icon;
        //特效路径
        private int _buffVfx;
        //特效缩放
        private int _vfxScal;
        //特效挂载点
        private int _vfxSlot;
        //参数1
        private int _param1;
        //参数2
        private int _param2;
        //参数3
        private int _param3;
        //参数4
        private int _param4;
        //作用对象（0所有 1怪物 2玩家）
        private int _targetType;
        //增0/减1益
        private int _addsub;
        //是否有文字显示（0，不显示；1，显示）
        private int _wenzi;
        //延迟时间（毫秒）
        private int _d_time;
        //特殊的条件 条件类型_条件参数;(@;@_@)
        private int _condi;
        //服务器是否发送给客户端显示（0，显示；1，不显示）
        private int _if_send;
        //改地图是否清除（0，不清；1，清除）
        private int _if_changemap;
        //客户端是否显示该BUFF在BUFF栏中（0，显示；1，不显示）
        private int _if_show;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int Type { get{ return _type; }}
        public int Group { get{ return _group; }}
        public int Overlap { get{ return _overlap; }}
        public int Level { get{ return _level; }}
        public int Icon { get{ return _icon; }}
        public int BuffVfx { get{ return _buffVfx; }}
        public int VfxScal { get{ return _vfxScal; }}
        public int VfxSlot { get{ return _vfxSlot; }}
        public int Param1 { get{ return _param1; }}
        public int Param2 { get{ return _param2; }}
        public int Param3 { get{ return _param3; }}
        public int Param4 { get{ return _param4; }}
        public int TargetType { get{ return _targetType; }}
        public int Addsub { get{ return _addsub; }}
        public int Wenzi { get{ return _wenzi; }}
        public int DTime { get{ return _d_time; }}
        public string Condi { get{ return HanderDefine.SetStingCallBack(_condi); }}
        public int IfSend { get{ return _if_send; }}
        public int IfChangemap { get{ return _if_changemap; }}
        public int IfShow { get{ return _if_show; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBuff cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBuff> _dataCaches = null;
        public static Dictionary<int, DeclareBuff> CacheData
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
                        if (HanderDefine.DataCallBack("Buff", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBuff cfg = null;
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
        private unsafe static DeclareBuff LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBuff();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._overlap = (int)GetValue(keyIndex, _overlap_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._buffVfx = (int)GetValue(keyIndex, _buffVfx_Index, ptr);
            tmp._vfxScal = (int)GetValue(keyIndex, _vfxScal_Index, ptr);
            tmp._vfxSlot = (int)GetValue(keyIndex, _vfxSlot_Index, ptr);
            tmp._param1 = (int)GetValue(keyIndex, _param1_Index, ptr);
            tmp._param2 = (int)GetValue(keyIndex, _param2_Index, ptr);
            tmp._param3 = (int)GetValue(keyIndex, _param3_Index, ptr);
            tmp._param4 = (int)GetValue(keyIndex, _param4_Index, ptr);
            tmp._targetType = (int)GetValue(keyIndex, _targetType_Index, ptr);
            tmp._addsub = (int)GetValue(keyIndex, _addsub_Index, ptr);
            tmp._wenzi = (int)GetValue(keyIndex, _wenzi_Index, ptr);
            tmp._d_time = (int)GetValue(keyIndex, _d_time_Index, ptr);
            tmp._condi = (int)GetValue(keyIndex, _condi_Index, ptr);
            tmp._if_send = (int)GetValue(keyIndex, _if_send_Index, ptr);
            tmp._if_changemap = (int)GetValue(keyIndex, _if_changemap_Index, ptr);
            tmp._if_show = (int)GetValue(keyIndex, _if_show_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Buff", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Overlap", out _overlap_Index)) _overlap_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("BuffVfx", out _buffVfx_Index)) _buffVfx_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxScal", out _vfxScal_Index)) _vfxScal_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxSlot", out _vfxSlot_Index)) _vfxSlot_Index = -1;
                    if (!nameIndexs.TryGetValue("Param1", out _param1_Index)) _param1_Index = -1;
                    if (!nameIndexs.TryGetValue("Param2", out _param2_Index)) _param2_Index = -1;
                    if (!nameIndexs.TryGetValue("Param3", out _param3_Index)) _param3_Index = -1;
                    if (!nameIndexs.TryGetValue("Param4", out _param4_Index)) _param4_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetType", out _targetType_Index)) _targetType_Index = -1;
                    if (!nameIndexs.TryGetValue("Addsub", out _addsub_Index)) _addsub_Index = -1;
                    if (!nameIndexs.TryGetValue("Wenzi", out _wenzi_Index)) _wenzi_Index = -1;
                    if (!nameIndexs.TryGetValue("DTime", out _d_time_Index)) _d_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Condi", out _condi_Index)) _condi_Index = -1;
                    if (!nameIndexs.TryGetValue("IfSend", out _if_send_Index)) _if_send_Index = -1;
                    if (!nameIndexs.TryGetValue("IfChangemap", out _if_changemap_Index)) _if_changemap_Index = -1;
                    if (!nameIndexs.TryGetValue("IfShow", out _if_show_Index)) _if_show_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBuff>(keyCount);
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
            if(HanderDefine.DataCallBack("Buff", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBuff cfg = null;
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
        public static DeclareBuff Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBuff result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Buff", out _compressData))
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
