//文件是自动生成,请勿手动修改.来自数据文件:Guide
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuide
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _trigger_type_Index = -1;
        private static int _limit_level_min_Index = -1;
        private static int _limit_level_max_Index = -1;
        private static int _trigger_param_Index = -1;
        private static int _open_function_Index = -1;
        private static int _open_function_param_Index = -1;
        private static int _target_ui_Index = -1;
        private static int _steps_Index = -1;
        private static int _continueTask_Index = -1;
        private static int _continueGuide_Index = -1;
        private static int _finish_teleport_Index = -1;
        #endregion
        #region //私有变量定义
        //引导ID
        private int _id;
        //引导类型，0非强制引导，1强制引导，2播放场景动画，3.播放Timeline资源动画
        private int _type;
        //触发类型,1功能开启，2等级达到多少级，3任务完成，4进入地图，5打开主界面快速提示引导，6获得新物品,7发现宠物,8引导查看新获取的装备属性，9打开离线经验不足界面,10点击打开UI任务的引导，11接受任务引导，12获得新技能引导，13境界任务点击前往
        private int _trigger_type;
        //可以触发引导的最低等级，没有就配0
        private int _limit_level_min;
        //可以触发引导的最高等级，没有就配0
        private int _limit_level_max;
        //触发参数,根据类型决定取值，1功能ID，2等级，3任务ID，4进入地图ID，5打开主界面引导ID,6获得物品ID，7宠物ID，8装备ID，
        private int _trigger_param;
        //直接打开的功能ID，值参考FunctionStart表
        private int _open_function;
        //打开功能ID参数(副本group_id)  场景动画类型的引导表示动画播放的时间，单位毫秒
        private int _open_function_param;
        //目标界面，配置此字段主要是为了防止目标界面被关闭
        private int _target_ui;
        //引导步骤，场景动画类引导表示动画的路径,分号隔开职业
        private int _steps;
        //是否继续任务（0否，1是）
        private int _continueTask;
        //本引导结束后继续执行的引导id
        private int _continueGuide;
        //引导 结束后执行的传送数据: 地图ID_坐标X_坐标Y
        private int _finish_teleport;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int TriggerType { get{ return _trigger_type; }}
        public int LimitLevelMin { get{ return _limit_level_min; }}
        public int LimitLevelMax { get{ return _limit_level_max; }}
        public int TriggerParam { get{ return _trigger_param; }}
        public int OpenFunction { get{ return _open_function; }}
        public int OpenFunctionParam { get{ return _open_function_param; }}
        public string TargetUi { get{ return HanderDefine.SetStingCallBack(_target_ui); }}
        public string Steps { get{ return HanderDefine.SetStingCallBack(_steps); }}
        public int ContinueTask { get{ return _continueTask; }}
        public int ContinueGuide { get{ return _continueGuide; }}
        public string FinishTeleport { get{ return HanderDefine.SetStingCallBack(_finish_teleport); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuide cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuide> _dataCaches = null;
        public static Dictionary<int, DeclareGuide> CacheData
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
                        if (HanderDefine.DataCallBack("Guide", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuide cfg = null;
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
        private unsafe static DeclareGuide LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuide();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._trigger_type = (int)GetValue(keyIndex, _trigger_type_Index, ptr);
            tmp._limit_level_min = (int)GetValue(keyIndex, _limit_level_min_Index, ptr);
            tmp._limit_level_max = (int)GetValue(keyIndex, _limit_level_max_Index, ptr);
            tmp._trigger_param = (int)GetValue(keyIndex, _trigger_param_Index, ptr);
            tmp._open_function = (int)GetValue(keyIndex, _open_function_Index, ptr);
            tmp._open_function_param = (int)GetValue(keyIndex, _open_function_param_Index, ptr);
            tmp._target_ui = (int)GetValue(keyIndex, _target_ui_Index, ptr);
            tmp._steps = (int)GetValue(keyIndex, _steps_Index, ptr);
            tmp._continueTask = (int)GetValue(keyIndex, _continueTask_Index, ptr);
            tmp._continueGuide = (int)GetValue(keyIndex, _continueGuide_Index, ptr);
            tmp._finish_teleport = (int)GetValue(keyIndex, _finish_teleport_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Guide", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("TriggerType", out _trigger_type_Index)) _trigger_type_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitLevelMin", out _limit_level_min_Index)) _limit_level_min_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitLevelMax", out _limit_level_max_Index)) _limit_level_max_Index = -1;
                    if (!nameIndexs.TryGetValue("TriggerParam", out _trigger_param_Index)) _trigger_param_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFunction", out _open_function_Index)) _open_function_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFunctionParam", out _open_function_param_Index)) _open_function_param_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetUi", out _target_ui_Index)) _target_ui_Index = -1;
                    if (!nameIndexs.TryGetValue("Steps", out _steps_Index)) _steps_Index = -1;
                    if (!nameIndexs.TryGetValue("ContinueTask", out _continueTask_Index)) _continueTask_Index = -1;
                    if (!nameIndexs.TryGetValue("ContinueGuide", out _continueGuide_Index)) _continueGuide_Index = -1;
                    if (!nameIndexs.TryGetValue("FinishTeleport", out _finish_teleport_Index)) _finish_teleport_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuide>(keyCount);
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
            if(HanderDefine.DataCallBack("Guide", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuide cfg = null;
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
        public static DeclareGuide Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuide result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Guide", out _compressData))
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
