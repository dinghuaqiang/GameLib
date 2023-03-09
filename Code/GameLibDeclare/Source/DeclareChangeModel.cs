//文件是自动生成,请勿手动修改.来自数据文件:change_model
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareChangeModel
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _modelId_Index = -1;
        private static int _skill_Index = -1;
        private static int _attribute_Index = -1;
        private static int _isAttRole_Index = -1;
        private static int _isRoleAtt_Index = -1;
        private static int _isAttChange_Index = -1;
        private static int _isChangeAtt_Index = -1;
        private static int _mapLimit_Index = -1;
        #endregion
        #region //私有变量定义
        //对应BUFF表的主键ID
        private int _id;
        //对应modelconfig主键ID
        private int _modelId;
        //技能，对应skill表主键（占用原有主角技能栏，可能有多个技能，，第一个技能为普通攻击其中一个必须是变身回角色的技能，无需配置，程序写死
        private int _skill;
        //原有属性的倍数（填写BUFFID）
        private int _attribute;
        //是否可攻击玩家
        //（0否1是）
        private int _isAttRole;
        //是否可被玩家攻击
        //（0否1是）
        private int _isRoleAtt;
        //是否可攻击其他载具
        //（0否1是）
        private int _isAttChange;
        //是否可被其他载具攻击
        //（0否1是）
        private int _isChangeAtt;
        //只能在指定地图使用得变身（null代表没有限制），可以配置多个
        private int _mapLimit;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int ModelId { get{ return _modelId; }}
        public string Skill { get{ return HanderDefine.SetStingCallBack(_skill); }}
        public int Attribute { get{ return _attribute; }}
        public int IsAttRole { get{ return _isAttRole; }}
        public int IsRoleAtt { get{ return _isRoleAtt; }}
        public int IsAttChange { get{ return _isAttChange; }}
        public int IsChangeAtt { get{ return _isChangeAtt; }}
        public string MapLimit { get{ return HanderDefine.SetStingCallBack(_mapLimit); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareChangeModel cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareChangeModel> _dataCaches = null;
        public static Dictionary<int, DeclareChangeModel> CacheData
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
                        if (HanderDefine.DataCallBack("ChangeModel", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareChangeModel cfg = null;
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
        private unsafe static DeclareChangeModel LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareChangeModel();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._skill = (int)GetValue(keyIndex, _skill_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._isAttRole = (int)GetValue(keyIndex, _isAttRole_Index, ptr);
            tmp._isRoleAtt = (int)GetValue(keyIndex, _isRoleAtt_Index, ptr);
            tmp._isAttChange = (int)GetValue(keyIndex, _isAttChange_Index, ptr);
            tmp._isChangeAtt = (int)GetValue(keyIndex, _isChangeAtt_Index, ptr);
            tmp._mapLimit = (int)GetValue(keyIndex, _mapLimit_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ChangeModel", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("Skill", out _skill_Index)) _skill_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("IsAttRole", out _isAttRole_Index)) _isAttRole_Index = -1;
                    if (!nameIndexs.TryGetValue("IsRoleAtt", out _isRoleAtt_Index)) _isRoleAtt_Index = -1;
                    if (!nameIndexs.TryGetValue("IsAttChange", out _isAttChange_Index)) _isAttChange_Index = -1;
                    if (!nameIndexs.TryGetValue("IsChangeAtt", out _isChangeAtt_Index)) _isChangeAtt_Index = -1;
                    if (!nameIndexs.TryGetValue("MapLimit", out _mapLimit_Index)) _mapLimit_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareChangeModel>(keyCount);
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
            if(HanderDefine.DataCallBack("ChangeModel", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareChangeModel cfg = null;
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
        public static DeclareChangeModel Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareChangeModel result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ChangeModel", out _compressData))
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
