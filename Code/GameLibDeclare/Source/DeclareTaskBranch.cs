//文件是自动生成,请勿手动修改.来自数据文件:task_branch
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareTaskBranch
    {
        #region //静态变量定义
        private static int _branchId_Index = -1;
        private static int _branch_sort_Index = -1;
        private static int _name_Index = -1;
        private static int _type_name_Index = -1;
        private static int _subtype_Index = -1;
        private static int _conditions_value_Index = -1;
        private static int _conditions_type_Index = -1;
        private static int _demand_value_Index = -1;
        private static int _itemID_Index = -1;
        private static int _tsak_describe_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _task_reward_Index = -1;
        private static int _open_panel_Index = -1;
        private static int _back_group_id_Index = -1;
        private static int _copymap_show_Index = -1;
        private static int _ifGono_Index = -1;
        private static int _get_item_Index = -1;
        private static int _target_type_Index = -1;
        private static int _overTaskFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //任务编号
        private int _branchId;
        //支线排序hide
        private int _branch_sort;
        //任务名称
        private int _name;
        //任务类型名称
        private int _type_name;
        //开服天数控制类型(ClientIgnore)(0普通1限时）
        private int _subtype;
        //领取条件：类型_值(@;@_@)
        //（类型读FunctionVariable表：1为等级，2为任务,160为开服时间,等级)
        private int _conditions_value;
        //任务类型（6功能操作）
        private int _conditions_type;
        //任务需求具体值X_X具体参看支线任务文档(@;@_@)
        private int _demand_value;
        //使用道具的道具ID
        private int _itemID;
        //任务描述hide
        private int _tsak_describe;
        //任务目标描述hide
        private int _conditions_describe;
        //任务奖励(物品_数量；物品_数量；)[@;@_@]
        private int _task_reward;
        //开启界面hide
        private int _open_panel;
        //面板参数ID
        private int _back_group_id;
        //副本展示进度(hide)
        private int _copymap_show;
        //开服天数控制(ClientIgnore)
        private int _ifGono;
        //获取途径(hide)
        private int _get_item;
        //目标系统的分类：（0，境界剑灵；1，装备养成；2，角色成长；3，骑宠造化；4，其他）hide
        private int _target_type;
        //任务在完成状态下跳转的界面（对应FunctionStar的ID）
        //（hide）
        private int _overTaskFunction;
        #endregion

        #region //公共属性
        public int BranchId { get{ return _branchId; }}
        public int BranchSort { get{ return _branch_sort; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_type_name); }}
        public int Subtype { get{ return _subtype; }}
        public string ConditionsValue { get{ return HanderDefine.SetStingCallBack(_conditions_value); }}
        public int ConditionsType { get{ return _conditions_type; }}
        public string DemandValue { get{ return HanderDefine.SetStingCallBack(_demand_value); }}
        public int ItemID { get{ return _itemID; }}
        public string TsakDescribe { get{ return HanderDefine.SetStingCallBack(_tsak_describe); }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public string TaskReward { get{ return HanderDefine.SetStingCallBack(_task_reward); }}
        public int OpenPanel { get{ return _open_panel; }}
        public int BackGroupId { get{ return _back_group_id; }}
        public int CopymapShow { get{ return _copymap_show; }}
        public int IfGono { get{ return _ifGono; }}
        public int GetItem { get{ return _get_item; }}
        public int TargetType { get{ return _target_type; }}
        public int OverTaskFunction { get{ return _overTaskFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareTaskBranch cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareTaskBranch> _dataCaches = null;
        public static Dictionary<int, DeclareTaskBranch> CacheData
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
                        if (HanderDefine.DataCallBack("TaskBranch", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareTaskBranch cfg = null;
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
        private unsafe static DeclareTaskBranch LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareTaskBranch();
            tmp._branchId = (int)GetValue(keyIndex, _branchId_Index, ptr);
            tmp._branch_sort = (int)GetValue(keyIndex, _branch_sort_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type_name = (int)GetValue(keyIndex, _type_name_Index, ptr);
            tmp._subtype = (int)GetValue(keyIndex, _subtype_Index, ptr);
            tmp._conditions_value = (int)GetValue(keyIndex, _conditions_value_Index, ptr);
            tmp._conditions_type = (int)GetValue(keyIndex, _conditions_type_Index, ptr);
            tmp._demand_value = (int)GetValue(keyIndex, _demand_value_Index, ptr);
            tmp._itemID = (int)GetValue(keyIndex, _itemID_Index, ptr);
            tmp._tsak_describe = (int)GetValue(keyIndex, _tsak_describe_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._task_reward = (int)GetValue(keyIndex, _task_reward_Index, ptr);
            tmp._open_panel = (int)GetValue(keyIndex, _open_panel_Index, ptr);
            tmp._back_group_id = (int)GetValue(keyIndex, _back_group_id_Index, ptr);
            tmp._copymap_show = (int)GetValue(keyIndex, _copymap_show_Index, ptr);
            tmp._ifGono = (int)GetValue(keyIndex, _ifGono_Index, ptr);
            tmp._get_item = (int)GetValue(keyIndex, _get_item_Index, ptr);
            tmp._target_type = (int)GetValue(keyIndex, _target_type_Index, ptr);
            tmp._overTaskFunction = (int)GetValue(keyIndex, _overTaskFunction_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("TaskBranch", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("BranchId", out _branchId_Index)) _branchId_Index = -1;
                    if (!nameIndexs.TryGetValue("BranchSort", out _branch_sort_Index)) _branch_sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _type_name_Index)) _type_name_Index = -1;
                    if (!nameIndexs.TryGetValue("Subtype", out _subtype_Index)) _subtype_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsValue", out _conditions_value_Index)) _conditions_value_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsType", out _conditions_type_Index)) _conditions_type_Index = -1;
                    if (!nameIndexs.TryGetValue("DemandValue", out _demand_value_Index)) _demand_value_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemID", out _itemID_Index)) _itemID_Index = -1;
                    if (!nameIndexs.TryGetValue("TsakDescribe", out _tsak_describe_Index)) _tsak_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskReward", out _task_reward_Index)) _task_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanel", out _open_panel_Index)) _open_panel_Index = -1;
                    if (!nameIndexs.TryGetValue("BackGroupId", out _back_group_id_Index)) _back_group_id_Index = -1;
                    if (!nameIndexs.TryGetValue("CopymapShow", out _copymap_show_Index)) _copymap_show_Index = -1;
                    if (!nameIndexs.TryGetValue("IfGono", out _ifGono_Index)) _ifGono_Index = -1;
                    if (!nameIndexs.TryGetValue("GetItem", out _get_item_Index)) _get_item_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetType", out _target_type_Index)) _target_type_Index = -1;
                    if (!nameIndexs.TryGetValue("OverTaskFunction", out _overTaskFunction_Index)) _overTaskFunction_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareTaskBranch>(keyCount);
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
            if(HanderDefine.DataCallBack("TaskBranch", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareTaskBranch cfg = null;
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
        public static DeclareTaskBranch Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareTaskBranch result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("TaskBranch", out _compressData))
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
