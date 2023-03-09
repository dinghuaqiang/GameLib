//文件是自动生成,请勿手动修改.来自数据文件:social_house_task
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSocialHouseTask
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _branch_sort_Index = -1;
        private static int _type_Index = -1;
        private static int _daily_Index = -1;
        private static int _name_Index = -1;
        private static int _demand_value_Index = -1;
        private static int _conditions_describe_Index = -1;
        private static int _task_reward_Index = -1;
        private static int _conditions_value_Index = -1;
        private static int _open_panel_Index = -1;
        private static int _overTaskFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //任务编号
        private int _id;
        //支线排序hide
        private int _branch_sort;
        //任务的分类：
        //1=拜访 count
        //2=送礼 count
        //3=购买商城家具 count
        //4=人气 value
        //5=装饰度 value
        //6=收集家具套装 suit
        //7=收集家具类型 type_count
        //8=聚宝盆 level
        private int _type;
        //任务刷新：
        //0=每日
        //1=永久
        private int _daily;
        //任务名称
        private int _name;
        //任务领取条件
        private int _demand_value;
        //任务目标描述hide
        private int _conditions_describe;
        //任务奖励(物品_数量；物品_数量；)[@;@_@]
        private int _task_reward;
        //根据任务分类
        private int _conditions_value;
        //开启界面hide
        private int _open_panel;
        //任务在完成状态下跳转的界面（对应FunctionStar的ID）
        //（hide）
        private int _overTaskFunction;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int BranchSort { get{ return _branch_sort; }}
        public int Type { get{ return _type; }}
        public int Daily { get{ return _daily; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string DemandValue { get{ return HanderDefine.SetStingCallBack(_demand_value); }}
        public string ConditionsDescribe { get{ return HanderDefine.SetStingCallBack(_conditions_describe); }}
        public string TaskReward { get{ return HanderDefine.SetStingCallBack(_task_reward); }}
        public string ConditionsValue { get{ return HanderDefine.SetStingCallBack(_conditions_value); }}
        public int OpenPanel { get{ return _open_panel; }}
        public int OverTaskFunction { get{ return _overTaskFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSocialHouseTask cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSocialHouseTask> _dataCaches = null;
        public static Dictionary<int, DeclareSocialHouseTask> CacheData
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
                        if (HanderDefine.DataCallBack("SocialHouseTask", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSocialHouseTask cfg = null;
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
        private unsafe static DeclareSocialHouseTask LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSocialHouseTask();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._branch_sort = (int)GetValue(keyIndex, _branch_sort_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._daily = (int)GetValue(keyIndex, _daily_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._demand_value = (int)GetValue(keyIndex, _demand_value_Index, ptr);
            tmp._conditions_describe = (int)GetValue(keyIndex, _conditions_describe_Index, ptr);
            tmp._task_reward = (int)GetValue(keyIndex, _task_reward_Index, ptr);
            tmp._conditions_value = (int)GetValue(keyIndex, _conditions_value_Index, ptr);
            tmp._open_panel = (int)GetValue(keyIndex, _open_panel_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("SocialHouseTask", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("BranchSort", out _branch_sort_Index)) _branch_sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Daily", out _daily_Index)) _daily_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("DemandValue", out _demand_value_Index)) _demand_value_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsDescribe", out _conditions_describe_Index)) _conditions_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskReward", out _task_reward_Index)) _task_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("ConditionsValue", out _conditions_value_Index)) _conditions_value_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPanel", out _open_panel_Index)) _open_panel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSocialHouseTask>(keyCount);
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
            if(HanderDefine.DataCallBack("SocialHouseTask", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSocialHouseTask cfg = null;
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
        public static DeclareSocialHouseTask Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSocialHouseTask result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SocialHouseTask", out _compressData))
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
