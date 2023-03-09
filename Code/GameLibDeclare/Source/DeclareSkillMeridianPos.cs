//文件是自动生成,请勿手动修改.来自数据文件:skill_meridian_pos
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSkillMeridianPos
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _change_job_Index = -1;
        private static int _xinfa_id_Index = -1;
        private static int _occ_Index = -1;
        private static int _name_Index = -1;
        private static int _use_gezi_Index = -1;
        private static int _tips_Index = -1;
        private static int _layout_type_Index = -1;
        private static int _xinfa_icon_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        private int _id;
        //需求转职等级
        private int _change_job;
        //心法ID
        private int _xinfa_id;
        //职业
        private int _occ;
        //经脉名字
        private int _name;
        //格子数据，每个格子上的经脉ID
        private int _use_gezi;
        //显示的tips hide
        private int _tips;
        //界面布局类型，用于显示底部进度条 hide
        private int _layout_type;
        private int _xinfa_icon;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ChangeJob { get{ return _change_job; }}
        public int XinfaId { get{ return _xinfa_id; }}
        public int Occ { get{ return _occ; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string UseGezi { get{ return HanderDefine.SetStingCallBack(_use_gezi); }}
        public string Tips { get{ return HanderDefine.SetStingCallBack(_tips); }}
        public int LayoutType { get{ return _layout_type; }}
        public string XinfaIcon { get{ return HanderDefine.SetStingCallBack(_xinfa_icon); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSkillMeridianPos cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSkillMeridianPos> _dataCaches = null;
        public static Dictionary<int, DeclareSkillMeridianPos> CacheData
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
                        if (HanderDefine.DataCallBack("SkillMeridianPos", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSkillMeridianPos cfg = null;
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
        private unsafe static DeclareSkillMeridianPos LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSkillMeridianPos();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._change_job = (int)GetValue(keyIndex, _change_job_Index, ptr);
            tmp._xinfa_id = (int)GetValue(keyIndex, _xinfa_id_Index, ptr);
            tmp._occ = (int)GetValue(keyIndex, _occ_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._use_gezi = (int)GetValue(keyIndex, _use_gezi_Index, ptr);
            tmp._tips = (int)GetValue(keyIndex, _tips_Index, ptr);
            tmp._layout_type = (int)GetValue(keyIndex, _layout_type_Index, ptr);
            tmp._xinfa_icon = (int)GetValue(keyIndex, _xinfa_icon_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("SkillMeridianPos", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangeJob", out _change_job_Index)) _change_job_Index = -1;
                    if (!nameIndexs.TryGetValue("XinfaId", out _xinfa_id_Index)) _xinfa_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ", out _occ_Index)) _occ_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("UseGezi", out _use_gezi_Index)) _use_gezi_Index = -1;
                    if (!nameIndexs.TryGetValue("Tips", out _tips_Index)) _tips_Index = -1;
                    if (!nameIndexs.TryGetValue("LayoutType", out _layout_type_Index)) _layout_type_Index = -1;
                    if (!nameIndexs.TryGetValue("XinfaIcon", out _xinfa_icon_Index)) _xinfa_icon_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSkillMeridianPos>(keyCount);
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
            if(HanderDefine.DataCallBack("SkillMeridianPos", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSkillMeridianPos cfg = null;
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
        public static DeclareSkillMeridianPos Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSkillMeridianPos result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SkillMeridianPos", out _compressData))
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
