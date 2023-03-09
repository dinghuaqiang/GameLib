//文件是自动生成,请勿手动修改.来自数据文件:FlySword_Grave
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFlySwordGrave
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _flysorwd_num_Index = -1;
        private static int _type_Index = -1;
        private static int _icon_Index = -1;
        private static int _describe_Index = -1;
        private static int _skill_Index = -1;
        private static int _condition_Index = -1;
        private static int _clone_id_Index = -1;
        private static int _flySword_id_Index = -1;
        private static int _black_time_Index = -1;
        private static int _jiesuan_time_Index = -1;
        #endregion
        #region //私有变量定义
        //剑冢的ID
        private int _id;
        //对应剑灵名字
        private int _name;
        //剑的编号
        private int _flysorwd_num;
        //剑灵的类型
        private int _type;
        //名剑ICON
        private int _icon;
        //背景描述
        private int _describe;
        //技能展示的ID
        private int _skill;
        //剑主试炼的条件
        private int _condition;
        //副本ID
        private int _clone_id;
        //激活的剑灵的ID
        private int _flySword_id;
        //黑屏的开始显示时间
        private int _black_time;
        //结算开始显示的时间
        private int _jiesuan_time;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int FlysorwdNum { get{ return _flysorwd_num; }}
        public int Type { get{ return _type; }}
        public int Icon { get{ return _icon; }}
        public string Describe { get{ return HanderDefine.SetStingCallBack(_describe); }}
        public int Skill { get{ return _skill; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public int CloneId { get{ return _clone_id; }}
        public int FlySwordId { get{ return _flySword_id; }}
        public int BlackTime { get{ return _black_time; }}
        public int JiesuanTime { get{ return _jiesuan_time; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFlySwordGrave cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFlySwordGrave> _dataCaches = null;
        public static Dictionary<int, DeclareFlySwordGrave> CacheData
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
                        if (HanderDefine.DataCallBack("FlySwordGrave", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFlySwordGrave cfg = null;
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
        private unsafe static DeclareFlySwordGrave LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFlySwordGrave();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._flysorwd_num = (int)GetValue(keyIndex, _flysorwd_num_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            tmp._skill = (int)GetValue(keyIndex, _skill_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._clone_id = (int)GetValue(keyIndex, _clone_id_Index, ptr);
            tmp._flySword_id = (int)GetValue(keyIndex, _flySword_id_Index, ptr);
            tmp._black_time = (int)GetValue(keyIndex, _black_time_Index, ptr);
            tmp._jiesuan_time = (int)GetValue(keyIndex, _jiesuan_time_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FlySwordGrave", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("FlysorwdNum", out _flysorwd_num_Index)) _flysorwd_num_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
                    if (!nameIndexs.TryGetValue("Skill", out _skill_Index)) _skill_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneId", out _clone_id_Index)) _clone_id_Index = -1;
                    if (!nameIndexs.TryGetValue("FlySwordId", out _flySword_id_Index)) _flySword_id_Index = -1;
                    if (!nameIndexs.TryGetValue("BlackTime", out _black_time_Index)) _black_time_Index = -1;
                    if (!nameIndexs.TryGetValue("JiesuanTime", out _jiesuan_time_Index)) _jiesuan_time_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFlySwordGrave>(keyCount);
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
            if(HanderDefine.DataCallBack("FlySwordGrave", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFlySwordGrave cfg = null;
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
        public static DeclareFlySwordGrave Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFlySwordGrave result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FlySwordGrave", out _compressData))
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
