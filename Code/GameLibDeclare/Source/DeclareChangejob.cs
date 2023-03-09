//文件是自动生成,请勿手动修改.来自数据文件:changejob
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareChangejob
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _changejob_name_Index = -1;
        private static int _changejob_condition_Index = -1;
        private static int _task_group_Index = -1;
        private static int _un_lock_function_Index = -1;
        private static int _function_name_Index = -1;
        private static int _show_item_Index = -1;
        private static int _function_name2_Index = -1;
        private static int _show_item2_Index = -1;
        private static int _level_describe_Index = -1;
        private static int _equip_describe_Index = -1;
        private static int _contribute_describe_Index = -1;
        private static int _model_change_Index = -1;
        private static int _changejob_reward_Index = -1;
        private static int _main_little_name_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //洗髓阶段ID
        private int _id;
        //洗髓名称
        private int _changejob_name;
        //开放条件
        private int _changejob_condition;
        //洗髓任务组ID
        private int _task_group;
        //解锁功能(hide)显示等级;功能id;功能参数;功能名字;功能icon;功能描述
        private int _un_lock_function;
        //名字(hide)
        private int _function_name;
        //显示物品ID(hide)
        private int _show_item;
        //名字(hide)
        private int _function_name2;
        //显示物品ID(hide)
        private int _show_item2;
        //解锁等级上限(hide)
        private int _level_describe;
        //解锁装备阶数(阶数_icon)(hide)
        private int _equip_describe;
        //完成后增加属性
        private int _contribute_describe;
        //解锁时装
        private int _model_change;
        //转职完成奖励(道具_数量_绑定_职业)
        private int _changejob_reward;
        //主界面icon小标题（hide）
        private int _main_little_name;
        //激活时的公告频道(10跑马灯)
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string ChangejobName { get{ return HanderDefine.SetStingCallBack(_changejob_name); }}
        public int ChangejobCondition { get{ return _changejob_condition; }}
        public string TaskGroup { get{ return HanderDefine.SetStingCallBack(_task_group); }}
        public string UnLockFunction { get{ return HanderDefine.SetStingCallBack(_un_lock_function); }}
        public string FunctionName { get{ return HanderDefine.SetStingCallBack(_function_name); }}
        public string ShowItem { get{ return HanderDefine.SetStingCallBack(_show_item); }}
        public string FunctionName2 { get{ return HanderDefine.SetStingCallBack(_function_name2); }}
        public string ShowItem2 { get{ return HanderDefine.SetStingCallBack(_show_item2); }}
        public string LevelDescribe { get{ return HanderDefine.SetStingCallBack(_level_describe); }}
        public string EquipDescribe { get{ return HanderDefine.SetStingCallBack(_equip_describe); }}
        public string ContributeDescribe { get{ return HanderDefine.SetStingCallBack(_contribute_describe); }}
        public int ModelChange { get{ return _model_change; }}
        public string ChangejobReward { get{ return HanderDefine.SetStingCallBack(_changejob_reward); }}
        public string MainLittleName { get{ return HanderDefine.SetStingCallBack(_main_little_name); }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareChangejob cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareChangejob> _dataCaches = null;
        public static Dictionary<int, DeclareChangejob> CacheData
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
                        if (HanderDefine.DataCallBack("Changejob", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareChangejob cfg = null;
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
        private unsafe static DeclareChangejob LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareChangejob();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._changejob_name = (int)GetValue(keyIndex, _changejob_name_Index, ptr);
            tmp._changejob_condition = (int)GetValue(keyIndex, _changejob_condition_Index, ptr);
            tmp._task_group = (int)GetValue(keyIndex, _task_group_Index, ptr);
            tmp._un_lock_function = (int)GetValue(keyIndex, _un_lock_function_Index, ptr);
            tmp._function_name = (int)GetValue(keyIndex, _function_name_Index, ptr);
            tmp._show_item = (int)GetValue(keyIndex, _show_item_Index, ptr);
            tmp._function_name2 = (int)GetValue(keyIndex, _function_name2_Index, ptr);
            tmp._show_item2 = (int)GetValue(keyIndex, _show_item2_Index, ptr);
            tmp._level_describe = (int)GetValue(keyIndex, _level_describe_Index, ptr);
            tmp._equip_describe = (int)GetValue(keyIndex, _equip_describe_Index, ptr);
            tmp._contribute_describe = (int)GetValue(keyIndex, _contribute_describe_Index, ptr);
            tmp._model_change = (int)GetValue(keyIndex, _model_change_Index, ptr);
            tmp._changejob_reward = (int)GetValue(keyIndex, _changejob_reward_Index, ptr);
            tmp._main_little_name = (int)GetValue(keyIndex, _main_little_name_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("Changejob", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangejobName", out _changejob_name_Index)) _changejob_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangejobCondition", out _changejob_condition_Index)) _changejob_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskGroup", out _task_group_Index)) _task_group_Index = -1;
                    if (!nameIndexs.TryGetValue("UnLockFunction", out _un_lock_function_Index)) _un_lock_function_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionName", out _function_name_Index)) _function_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItem", out _show_item_Index)) _show_item_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionName2", out _function_name2_Index)) _function_name2_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItem2", out _show_item2_Index)) _show_item2_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelDescribe", out _level_describe_Index)) _level_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipDescribe", out _equip_describe_Index)) _equip_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ContributeDescribe", out _contribute_describe_Index)) _contribute_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelChange", out _model_change_Index)) _model_change_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangejobReward", out _changejob_reward_Index)) _changejob_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("MainLittleName", out _main_little_name_Index)) _main_little_name_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareChangejob>(keyCount);
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
            if(HanderDefine.DataCallBack("Changejob", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareChangejob cfg = null;
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
        public static DeclareChangejob Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareChangejob result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Changejob", out _compressData))
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
