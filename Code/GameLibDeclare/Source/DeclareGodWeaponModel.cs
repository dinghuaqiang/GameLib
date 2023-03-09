//文件是自动生成,请勿手动修改.来自数据文件:GodWeaponModel
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGodWeaponModel
    {
        #region //静态变量定义
        private static int _modelId_Index = -1;
        private static int _type_Index = -1;
        private static int _occ_Index = -1;
        private static int _suitId_Index = -1;
        private static int _group_Index = -1;
        private static int _camera_Index = -1;
        private static int _activeItem_Index = -1;
        private static int _skill_Index = -1;
        private static int _attribute_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _initQuality_Index = -1;
        #endregion
        #region //私有变量定义
        //模型ID
        private int _modelId;
        //1.是剑身2.是剑柄，3是特效部位
        private int _type;
        //职业ID
        private int _occ;
        //所属套装对应套装配置表ID
        private int _suitId;
        //模型ID所属大类型type*1000+suitId
        private int _group;
        //移动；旋转；缩放（X_Z_Y配置）移动初始：0_0_0;旋转初始：0_0_0；缩放初始：320_320_320
        private int _camera;
        //激活道具ID,数量
        private int _activeItem;
        //技能的ID
        private int _skill;
        //基础属性(@;@_@)
        private int _attribute;
        //大类型名字
        private int _name;
        //大类型图片ICON,直接配置icon名字。到时候打成一个图集
        private int _icon;
        //模型初始品质
        private int _initQuality;
        #endregion

        #region //公共属性
        public int ModelId { get{ return _modelId; }}
        public int Type { get{ return _type; }}
        public int Occ { get{ return _occ; }}
        public int SuitId { get{ return _suitId; }}
        public int Group { get{ return _group; }}
        public string Camera { get{ return HanderDefine.SetStingCallBack(_camera); }}
        public string ActiveItem { get{ return HanderDefine.SetStingCallBack(_activeItem); }}
        public int Skill { get{ return _skill; }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int InitQuality { get{ return _initQuality; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGodWeaponModel cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGodWeaponModel> _dataCaches = null;
        public static Dictionary<int, DeclareGodWeaponModel> CacheData
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
                        if (HanderDefine.DataCallBack("GodWeaponModel", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGodWeaponModel cfg = null;
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
        private unsafe static DeclareGodWeaponModel LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGodWeaponModel();
            tmp._modelId = (int)GetValue(keyIndex, _modelId_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._occ = (int)GetValue(keyIndex, _occ_Index, ptr);
            tmp._suitId = (int)GetValue(keyIndex, _suitId_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._camera = (int)GetValue(keyIndex, _camera_Index, ptr);
            tmp._activeItem = (int)GetValue(keyIndex, _activeItem_Index, ptr);
            tmp._skill = (int)GetValue(keyIndex, _skill_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._initQuality = (int)GetValue(keyIndex, _initQuality_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GodWeaponModel", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ModelId", out _modelId_Index)) _modelId_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ", out _occ_Index)) _occ_Index = -1;
                    if (!nameIndexs.TryGetValue("SuitId", out _suitId_Index)) _suitId_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("Camera", out _camera_Index)) _camera_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveItem", out _activeItem_Index)) _activeItem_Index = -1;
                    if (!nameIndexs.TryGetValue("Skill", out _skill_Index)) _skill_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("InitQuality", out _initQuality_Index)) _initQuality_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGodWeaponModel>();
                        _dataIndexCaches = new Dictionary<int, int>();
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
            if(HanderDefine.DataCallBack("GodWeaponModel", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGodWeaponModel cfg = null;
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
        public static DeclareGodWeaponModel Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGodWeaponModel result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GodWeaponModel", out _compressData))
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
