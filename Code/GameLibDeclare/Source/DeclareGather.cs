//文件是自动生成,请勿手动修改.来自数据文件:Gather
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGather
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _res_Index = -1;
        private static int _friends_flag_Index = -1;
        private static int _enemy_flag_Index = -1;
        private static int _size_scale_Index = -1;
        private static int _logic_body_size_Index = -1;
        private static int _icon_Index = -1;
        private static int _collect_time_Index = -1;
        private static int _collect_info_Index = -1;
        private static int _collect_tips_Index = -1;
        private static int _drop_num_Index = -1;
        private static int _share_Index = -1;
        private static int _show_name_Index = -1;
        private static int _afterType_Index = -1;
        private static int _effectId_Index = -1;
        private static int _animName_Index = -1;
        private static int _dialog_Index = -1;
        private static int _multType_Index = -1;
        private static int _showButton_Index = -1;
        private static int _takHinde_Index = -1;
        private static int _getbuff_Index = -1;
        private static int _animid_Index = -1;
        #endregion
        #region //私有变量定义
        //采集物ID
        private int _id;
        //名称
        private int _name;
        //类型 0普通采集物（都可以采集） 1任务采集物（只有接受了某些任务才能采集）2婚宴食物（普通婚宴采集）3婚宴喜糖（喜从天降采集）
        private int _type;
        //资源
        private int _res;
        //友方占领
        private int _friends_flag;
        //敌方占领
        private int _enemy_flag;
        //模型缩放（百分比）
        private int _size_scale;
        //逻辑半径（单位厘米）(hide)
        private int _logic_body_size;
        //头像icon
        private int _icon;
        //采集时间(毫秒)
        private int _collect_time;
        //采集进度条文字 hide
        private int _collect_info;
        //可采集文字提示
        //hide
        private int _collect_tips;
        //掉落数量（目前只用于公会战）
        private int _drop_num;
        //采集共享(1共享，0不共享）
        private int _share;
        //是否显示名字(1是，0否）hide
        private int _show_name;
        //采集后Action Type(1:特效，2:动画,3:对话泡泡,10:混合)
        private int _afterType;
        //特效id
        private int _effectId;
        //动作片段名字
        private int _animName;
        //动作片段名字
        private int _dialog;
        //混合Type_执行顺序（0：顺序，1同时执行）
        private int _multType;
        //靠近是否显示按钮（(1是，0否））
        private int _showButton;
        //任务隐藏(@;@_@)
        private int _takHinde;
        //采集时增加的BUFF（采集取消后消失）
        private int _getbuff;
        //采集时触发的动作（传功疗伤是0，蹲下采集是1，站立采集是2，祭拜是3，）
        private int _animid;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Res { get{ return _res; }}
        public int FriendsFlag { get{ return _friends_flag; }}
        public int EnemyFlag { get{ return _enemy_flag; }}
        public int SizeScale { get{ return _size_scale; }}
        public int LogicBodySize { get{ return _logic_body_size; }}
        public int Icon { get{ return _icon; }}
        public int CollectTime { get{ return _collect_time; }}
        public string CollectInfo { get{ return HanderDefine.SetStingCallBack(_collect_info); }}
        public string CollectTips { get{ return HanderDefine.SetStingCallBack(_collect_tips); }}
        public int DropNum { get{ return _drop_num; }}
        public int Share { get{ return _share; }}
        public int ShowName { get{ return _show_name; }}
        public int AfterType { get{ return _afterType; }}
        public int EffectId { get{ return _effectId; }}
        public string AnimName { get{ return HanderDefine.SetStingCallBack(_animName); }}
        public string Dialog { get{ return HanderDefine.SetStingCallBack(_dialog); }}
        public string MultType { get{ return HanderDefine.SetStingCallBack(_multType); }}
        public int ShowButton { get{ return _showButton; }}
        public string TakHinde { get{ return HanderDefine.SetStingCallBack(_takHinde); }}
        public int Getbuff { get{ return _getbuff; }}
        public int Animid { get{ return _animid; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGather cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGather> _dataCaches = null;
        public static Dictionary<int, DeclareGather> CacheData
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
                        if (HanderDefine.DataCallBack("Gather", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGather cfg = null;
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
        private unsafe static DeclareGather LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGather();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._friends_flag = (int)GetValue(keyIndex, _friends_flag_Index, ptr);
            tmp._enemy_flag = (int)GetValue(keyIndex, _enemy_flag_Index, ptr);
            tmp._size_scale = (int)GetValue(keyIndex, _size_scale_Index, ptr);
            tmp._logic_body_size = (int)GetValue(keyIndex, _logic_body_size_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._collect_time = (int)GetValue(keyIndex, _collect_time_Index, ptr);
            tmp._collect_info = (int)GetValue(keyIndex, _collect_info_Index, ptr);
            tmp._collect_tips = (int)GetValue(keyIndex, _collect_tips_Index, ptr);
            tmp._drop_num = (int)GetValue(keyIndex, _drop_num_Index, ptr);
            tmp._share = (int)GetValue(keyIndex, _share_Index, ptr);
            tmp._show_name = (int)GetValue(keyIndex, _show_name_Index, ptr);
            tmp._afterType = (int)GetValue(keyIndex, _afterType_Index, ptr);
            tmp._effectId = (int)GetValue(keyIndex, _effectId_Index, ptr);
            tmp._animName = (int)GetValue(keyIndex, _animName_Index, ptr);
            tmp._dialog = (int)GetValue(keyIndex, _dialog_Index, ptr);
            tmp._multType = (int)GetValue(keyIndex, _multType_Index, ptr);
            tmp._showButton = (int)GetValue(keyIndex, _showButton_Index, ptr);
            tmp._takHinde = (int)GetValue(keyIndex, _takHinde_Index, ptr);
            tmp._getbuff = (int)GetValue(keyIndex, _getbuff_Index, ptr);
            tmp._animid = (int)GetValue(keyIndex, _animid_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Gather", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("FriendsFlag", out _friends_flag_Index)) _friends_flag_Index = -1;
                    if (!nameIndexs.TryGetValue("EnemyFlag", out _enemy_flag_Index)) _enemy_flag_Index = -1;
                    if (!nameIndexs.TryGetValue("SizeScale", out _size_scale_Index)) _size_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("LogicBodySize", out _logic_body_size_Index)) _logic_body_size_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("CollectTime", out _collect_time_Index)) _collect_time_Index = -1;
                    if (!nameIndexs.TryGetValue("CollectInfo", out _collect_info_Index)) _collect_info_Index = -1;
                    if (!nameIndexs.TryGetValue("CollectTips", out _collect_tips_Index)) _collect_tips_Index = -1;
                    if (!nameIndexs.TryGetValue("DropNum", out _drop_num_Index)) _drop_num_Index = -1;
                    if (!nameIndexs.TryGetValue("Share", out _share_Index)) _share_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowName", out _show_name_Index)) _show_name_Index = -1;
                    if (!nameIndexs.TryGetValue("AfterType", out _afterType_Index)) _afterType_Index = -1;
                    if (!nameIndexs.TryGetValue("EffectId", out _effectId_Index)) _effectId_Index = -1;
                    if (!nameIndexs.TryGetValue("AnimName", out _animName_Index)) _animName_Index = -1;
                    if (!nameIndexs.TryGetValue("Dialog", out _dialog_Index)) _dialog_Index = -1;
                    if (!nameIndexs.TryGetValue("MultType", out _multType_Index)) _multType_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowButton", out _showButton_Index)) _showButton_Index = -1;
                    if (!nameIndexs.TryGetValue("TakHinde", out _takHinde_Index)) _takHinde_Index = -1;
                    if (!nameIndexs.TryGetValue("Getbuff", out _getbuff_Index)) _getbuff_Index = -1;
                    if (!nameIndexs.TryGetValue("Animid", out _animid_Index)) _animid_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGather>(keyCount);
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
            if(HanderDefine.DataCallBack("Gather", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGather cfg = null;
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
        public static DeclareGather Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGather result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Gather", out _compressData))
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
