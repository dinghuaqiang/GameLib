//文件是自动生成,请勿手动修改.来自数据文件:Equip_shenpin_synthesis
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquipShenpinSynthesis
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _synthesis_type_Index = -1;
        private static int _synthesis_level_Index = -1;
        private static int _if_no_synthesis_Index = -1;
        private static int _equip_ID_Index = -1;
        private static int _join_item_Index = -1;
        private static int _target_Equip_ID_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（类型*10000000+身上的装备）
        private int _iD;
        //合成类型（1.升星；2.升阶）
        private int _synthesis_type;
        //参与合成等级
        private int _synthesis_level;
        //是否为当前版本最高星/阶装备
        private int _if_no_synthesis;
        //身上穿的装备ID
        private int _equip_ID;
        //合成需要的材料_数量
        private int _join_item;
        //合成目标装备ID
        private int _target_Equip_ID;
        //公告类型（10跑马灯）
        private int _notice;
        //聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int SynthesisType { get{ return _synthesis_type; }}
        public int SynthesisLevel { get{ return _synthesis_level; }}
        public int IfNoSynthesis { get{ return _if_no_synthesis; }}
        public int EquipID { get{ return _equip_ID; }}
        public string JoinItem { get{ return HanderDefine.SetStingCallBack(_join_item); }}
        public int TargetEquipID { get{ return _target_Equip_ID; }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquipShenpinSynthesis cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquipShenpinSynthesis> _dataCaches = null;
        public static Dictionary<int, DeclareEquipShenpinSynthesis> CacheData
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
                        if (HanderDefine.DataCallBack("EquipShenpinSynthesis", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquipShenpinSynthesis cfg = null;
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
        private unsafe static DeclareEquipShenpinSynthesis LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquipShenpinSynthesis();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._synthesis_type = (int)GetValue(keyIndex, _synthesis_type_Index, ptr);
            tmp._synthesis_level = (int)GetValue(keyIndex, _synthesis_level_Index, ptr);
            tmp._if_no_synthesis = (int)GetValue(keyIndex, _if_no_synthesis_Index, ptr);
            tmp._equip_ID = (int)GetValue(keyIndex, _equip_ID_Index, ptr);
            tmp._join_item = (int)GetValue(keyIndex, _join_item_Index, ptr);
            tmp._target_Equip_ID = (int)GetValue(keyIndex, _target_Equip_ID_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("EquipShenpinSynthesis", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("SynthesisType", out _synthesis_type_Index)) _synthesis_type_Index = -1;
                    if (!nameIndexs.TryGetValue("SynthesisLevel", out _synthesis_level_Index)) _synthesis_level_Index = -1;
                    if (!nameIndexs.TryGetValue("IfNoSynthesis", out _if_no_synthesis_Index)) _if_no_synthesis_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipID", out _equip_ID_Index)) _equip_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinItem", out _join_item_Index)) _join_item_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetEquipID", out _target_Equip_ID_Index)) _target_Equip_ID_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquipShenpinSynthesis>(keyCount);
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
            if(HanderDefine.DataCallBack("EquipShenpinSynthesis", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquipShenpinSynthesis cfg = null;
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
        public static DeclareEquipShenpinSynthesis Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquipShenpinSynthesis result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("EquipShenpinSynthesis", out _compressData))
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
