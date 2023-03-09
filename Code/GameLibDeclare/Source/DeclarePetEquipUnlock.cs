//文件是自动生成,请勿手动修改.来自数据文件:pet_equip_unlock
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclarePetEquipUnlock
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _site_Index = -1;
        private static int _siteUnlock_Index = -1;
        private static int _siteUnlockItem_Index = -1;
        private static int _partId_Index = -1;
        private static int _partUnlock_Index = -1;
        #endregion
        #region //私有变量定义
        //唯一id
        private int _id;
        //槽位id
        private int _site;
        //槽位解锁条件
        private int _siteUnlock;
        //槽位解锁  道具_数量
        private int _siteUnlockItem;
        //部位
        private int _partId;
        //部位解锁条件
        private int _partUnlock;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Site { get{ return _site; }}
        public string SiteUnlock { get{ return HanderDefine.SetStingCallBack(_siteUnlock); }}
        public string SiteUnlockItem { get{ return HanderDefine.SetStingCallBack(_siteUnlockItem); }}
        public int PartId { get{ return _partId; }}
        public string PartUnlock { get{ return HanderDefine.SetStingCallBack(_partUnlock); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclarePetEquipUnlock cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclarePetEquipUnlock> _dataCaches = null;
        public static Dictionary<int, DeclarePetEquipUnlock> CacheData
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
                        if (HanderDefine.DataCallBack("PetEquipUnlock", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclarePetEquipUnlock cfg = null;
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
        private unsafe static DeclarePetEquipUnlock LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclarePetEquipUnlock();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._site = (int)GetValue(keyIndex, _site_Index, ptr);
            tmp._siteUnlock = (int)GetValue(keyIndex, _siteUnlock_Index, ptr);
            tmp._siteUnlockItem = (int)GetValue(keyIndex, _siteUnlockItem_Index, ptr);
            tmp._partId = (int)GetValue(keyIndex, _partId_Index, ptr);
            tmp._partUnlock = (int)GetValue(keyIndex, _partUnlock_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("PetEquipUnlock", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Site", out _site_Index)) _site_Index = -1;
                    if (!nameIndexs.TryGetValue("SiteUnlock", out _siteUnlock_Index)) _siteUnlock_Index = -1;
                    if (!nameIndexs.TryGetValue("SiteUnlockItem", out _siteUnlockItem_Index)) _siteUnlockItem_Index = -1;
                    if (!nameIndexs.TryGetValue("PartId", out _partId_Index)) _partId_Index = -1;
                    if (!nameIndexs.TryGetValue("PartUnlock", out _partUnlock_Index)) _partUnlock_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclarePetEquipUnlock>(keyCount);
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
            if(HanderDefine.DataCallBack("PetEquipUnlock", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclarePetEquipUnlock cfg = null;
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
        public static DeclarePetEquipUnlock Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclarePetEquipUnlock result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("PetEquipUnlock", out _compressData))
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
