//文件是自动生成,请勿手动修改.来自数据文件:Nature_att
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNatureAtt
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _position_Index = -1;
        private static int _level_Index = -1;
        private static int _item_id_Index = -1;
        private static int _attribute_Index = -1;
        private static int _peiyang_att_Index = -1;
        private static int _leve_limit_Index = -1;
        #endregion
        #region //私有变量定义
        //ID（类型*1000+位置*100+阶级）
        private int _id;
        //神物类型(1.坐骑，2.翅膀，3.法器，4.阵道，5.神兵 6.法宝 8.宠物）
        private int _type;
        //位置（第几个物品）
        private int _position;
        //等阶
        private int _level;
        //物品ID
        private int _item_id;
        //增加属性(@;@_@)
        private int _attribute;
        //增加对应系统培养属性万分比(@_@)
        private int _peiyang_att;
        //等级数量上限
        private int _leve_limit;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Position { get{ return _position; }}
        public int Level { get{ return _level; }}
        public int ItemId { get{ return _item_id; }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string PeiyangAtt { get{ return HanderDefine.SetStingCallBack(_peiyang_att); }}
        public int LeveLimit { get{ return _leve_limit; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNatureAtt cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNatureAtt> _dataCaches = null;
        public static Dictionary<int, DeclareNatureAtt> CacheData
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
                        if (HanderDefine.DataCallBack("NatureAtt", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNatureAtt cfg = null;
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
        private unsafe static DeclareNatureAtt LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNatureAtt();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._position = (int)GetValue(keyIndex, _position_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._item_id = (int)GetValue(keyIndex, _item_id_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._peiyang_att = (int)GetValue(keyIndex, _peiyang_att_Index, ptr);
            tmp._leve_limit = (int)GetValue(keyIndex, _leve_limit_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NatureAtt", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Position", out _position_Index)) _position_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemId", out _item_id_Index)) _item_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("PeiyangAtt", out _peiyang_att_Index)) _peiyang_att_Index = -1;
                    if (!nameIndexs.TryGetValue("LeveLimit", out _leve_limit_Index)) _leve_limit_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNatureAtt>(keyCount);
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
            if(HanderDefine.DataCallBack("NatureAtt", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNatureAtt cfg = null;
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
        public static DeclareNatureAtt Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNatureAtt result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NatureAtt", out _compressData))
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
