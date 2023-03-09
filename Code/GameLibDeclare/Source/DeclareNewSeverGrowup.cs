//文件是自动生成,请勿手动修改.来自数据文件:new_sever_growup
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverGrowup
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _day_Index = -1;
        private static int _subId_Index = -1;
        private static int _sort_Index = -1;
        private static int _menuTex_Index = -1;
        private static int _name_Index = -1;
        private static int _rate_Index = -1;
        private static int _condition_Index = -1;
        private static int _des_Index = -1;
        private static int _relation_UI_Index = -1;
        private static int _relation_sub_UI_Index = -1;
        private static int _reward_Index = -1;
        #endregion
        #region //私有变量定义
        //id，id=day+subId-1+sort
        private int _id;
        //服务器开启的天数
        private int _day;
        //所属类型
        //1：磨砺之路
        //2：神装之路
        //3：荣光之路
        //4：为盟之道
        private int _subId;
        //用于默认排序，完成未领取在前面
        private int _sort;
        //菜单背景名字
        private int _menuTex;
        //每天的名字(hide)
        private int _name;
        //完成该任务后获得的进度点
        private int _rate;
        //达成的成就条件(@_@)
        //条件都需要定义在functionVariable中
        private int _condition;
        //任务描述(hide)
        private int _des;
        //跳转的UI面板，functionstart里面的ID
        //(hide)
        private int _relation_UI;
        //UI对应的子功能，
        //首领功能对应BOSS的ID，当前只支持首领
        //（hide）
        private int _relation_sub_UI;
        //奖励
        private int _reward;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Day { get{ return _day; }}
        public int SubId { get{ return _subId; }}
        public int Sort { get{ return _sort; }}
        public string MenuTex { get{ return HanderDefine.SetStingCallBack(_menuTex); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Rate { get{ return _rate; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public int RelationUI { get{ return _relation_UI; }}
        public int RelationSubUI { get{ return _relation_sub_UI; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverGrowup cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverGrowup> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverGrowup> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverGrowup", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverGrowup cfg = null;
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
        private unsafe static DeclareNewSeverGrowup LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverGrowup();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._day = (int)GetValue(keyIndex, _day_Index, ptr);
            tmp._subId = (int)GetValue(keyIndex, _subId_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._menuTex = (int)GetValue(keyIndex, _menuTex_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._rate = (int)GetValue(keyIndex, _rate_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._relation_UI = (int)GetValue(keyIndex, _relation_UI_Index, ptr);
            tmp._relation_sub_UI = (int)GetValue(keyIndex, _relation_sub_UI_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverGrowup", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Day", out _day_Index)) _day_Index = -1;
                    if (!nameIndexs.TryGetValue("SubId", out _subId_Index)) _subId_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("MenuTex", out _menuTex_Index)) _menuTex_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Rate", out _rate_Index)) _rate_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("RelationUI", out _relation_UI_Index)) _relation_UI_Index = -1;
                    if (!nameIndexs.TryGetValue("RelationSubUI", out _relation_sub_UI_Index)) _relation_sub_UI_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverGrowup>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverGrowup", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverGrowup cfg = null;
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
        public static DeclareNewSeverGrowup Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverGrowup result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverGrowup", out _compressData))
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
