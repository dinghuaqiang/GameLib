//文件是自动生成,请勿手动修改.来自数据文件:state_stifle_add
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareStateStifleAdd
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _jinhua_level_Index = -1;
        private static int _model_Index = -1;
        private static int _icon_Index = -1;
        private static int _vfx_Index = -1;
        private static int _jinhua_need_item_Index = -1;
        private static int _jinhua_need_money_Index = -1;
        private static int _jinghua_succes_Index = -1;
        private static int _attribute_Index = -1;
        private static int _per_attribute_Index = -1;
        private static int _skill_Index = -1;
        private static int _max_times_Index = -1;
        private static int _if_max_Index = -1;
        private static int _need_level_Index = -1;
        private static int _need_item_Index = -1;
        private static int _add_tips_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（类型*100+进化等级）
        private int _id;
        //类型（1：经验器灵；2：战斗器灵；3：追击器灵）
        private int _type;
        //进化等级
        private int _jinhua_level;
        //模型hide
        private int _model;
        //图标hide
        private int _icon;
        //特效hide
        private int _vfx;
        //进化需要的物品_数量；
        private int _jinhua_need_item;
        //进化需要的货币_数量；
        private int _jinhua_need_money;
        //进化的成功率（万分比）
        private int _jinghua_succes;
        //核心核心属性
        private int _attribute;
        //核心百分比属性
        private int _per_attribute;
        //核心技能
        private int _skill;
        //界面上核心属性描述
        private int _max_times;
        //是否为当前版本满级
        private int _if_max;
        //开启需要的法宝等级ID
        private int _need_level;
        //需要的物品
        private int _need_item;
        //进化界面上显示的文字
        private int _add_tips;
        //激活时的公告频道(10跑马灯)
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int JinhuaLevel { get{ return _jinhua_level; }}
        public int Model { get{ return _model; }}
        public int Icon { get{ return _icon; }}
        public int Vfx { get{ return _vfx; }}
        public string JinhuaNeedItem { get{ return HanderDefine.SetStingCallBack(_jinhua_need_item); }}
        public string JinhuaNeedMoney { get{ return HanderDefine.SetStingCallBack(_jinhua_need_money); }}
        public int JinghuaSucces { get{ return _jinghua_succes; }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string PerAttribute { get{ return HanderDefine.SetStingCallBack(_per_attribute); }}
        public string Skill { get{ return HanderDefine.SetStingCallBack(_skill); }}
        public string MaxTimes { get{ return HanderDefine.SetStingCallBack(_max_times); }}
        public int IfMax { get{ return _if_max; }}
        public int NeedLevel { get{ return _need_level; }}
        public string NeedItem { get{ return HanderDefine.SetStingCallBack(_need_item); }}
        public string AddTips { get{ return HanderDefine.SetStingCallBack(_add_tips); }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareStateStifleAdd cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareStateStifleAdd> _dataCaches = null;
        public static Dictionary<int, DeclareStateStifleAdd> CacheData
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
                        if (HanderDefine.DataCallBack("StateStifleAdd", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareStateStifleAdd cfg = null;
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
        private unsafe static DeclareStateStifleAdd LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareStateStifleAdd();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._jinhua_level = (int)GetValue(keyIndex, _jinhua_level_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._vfx = (int)GetValue(keyIndex, _vfx_Index, ptr);
            tmp._jinhua_need_item = (int)GetValue(keyIndex, _jinhua_need_item_Index, ptr);
            tmp._jinhua_need_money = (int)GetValue(keyIndex, _jinhua_need_money_Index, ptr);
            tmp._jinghua_succes = (int)GetValue(keyIndex, _jinghua_succes_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._per_attribute = (int)GetValue(keyIndex, _per_attribute_Index, ptr);
            tmp._skill = (int)GetValue(keyIndex, _skill_Index, ptr);
            tmp._max_times = (int)GetValue(keyIndex, _max_times_Index, ptr);
            tmp._if_max = (int)GetValue(keyIndex, _if_max_Index, ptr);
            tmp._need_level = (int)GetValue(keyIndex, _need_level_Index, ptr);
            tmp._need_item = (int)GetValue(keyIndex, _need_item_Index, ptr);
            tmp._add_tips = (int)GetValue(keyIndex, _add_tips_Index, ptr);
            tmp._notice = (int)GetValue(keyIndex, _notice_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("StateStifleAdd", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("JinhuaLevel", out _jinhua_level_Index)) _jinhua_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx", out _vfx_Index)) _vfx_Index = -1;
                    if (!nameIndexs.TryGetValue("JinhuaNeedItem", out _jinhua_need_item_Index)) _jinhua_need_item_Index = -1;
                    if (!nameIndexs.TryGetValue("JinhuaNeedMoney", out _jinhua_need_money_Index)) _jinhua_need_money_Index = -1;
                    if (!nameIndexs.TryGetValue("JinghuaSucces", out _jinghua_succes_Index)) _jinghua_succes_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("PerAttribute", out _per_attribute_Index)) _per_attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("Skill", out _skill_Index)) _skill_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxTimes", out _max_times_Index)) _max_times_Index = -1;
                    if (!nameIndexs.TryGetValue("IfMax", out _if_max_Index)) _if_max_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedLevel", out _need_level_Index)) _need_level_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedItem", out _need_item_Index)) _need_item_Index = -1;
                    if (!nameIndexs.TryGetValue("AddTips", out _add_tips_Index)) _add_tips_Index = -1;
                    if (!nameIndexs.TryGetValue("Notice", out _notice_Index)) _notice_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareStateStifleAdd>(keyCount);
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
            if(HanderDefine.DataCallBack("StateStifleAdd", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareStateStifleAdd cfg = null;
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
        public static DeclareStateStifleAdd Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareStateStifleAdd result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("StateStifleAdd", out _compressData))
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
