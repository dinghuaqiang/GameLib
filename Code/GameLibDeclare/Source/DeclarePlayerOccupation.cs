//文件是自动生成,请勿手动修改.来自数据文件:PlayerOccupation
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclarePlayerOccupation
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _sex_Index = -1;
        private static int _jobName_Index = -1;
        private static int _atk_type_Index = -1;
        private static int _introduction_Index = -1;
        private static int _special_Index = -1;
        private static int _desc_Index = -1;
        private static int _headIcon_Index = -1;
        private static int _modelHeight_Index = -1;
        private static int _modelID_Index = -1;
        private static int _weaponID_Index = -1;
        private static int _skillVfxID_Index = -1;
        private static int _playAnimName_Index = -1;
        private static int _idleAnimName_Index = -1;
        private static int _blurArgs_Index = -1;
        #endregion
        #region //私有变量定义
        //ID职业类别    QiWangFu = 0,
        //    LiuShanMen = 1,
        //    WanHuaLou = 2,
        //    JiLiaoDaYing = 3,
        private int _id;
        //性别(0:女,1:男)
        private int _sex;
        //职业名字
        private int _jobName;
        //攻击类型（0物攻，1法攻）
        private int _atk_type;
        //职业简介10字左右(hide)
        private int _introduction;
        //职业特色10字左右(hide)
        private int _special;
        //职业而描述，显示到属性界面(hide)
        private int _desc;
        //头像Icon,其中默认Atlas为MenuIcon(hide)
        private int _headIcon;
        //3D模型的实际高度*100(hide)
        private int _modelHeight;
        //模型id,在ModelConfig中配置的id(hide)
        private int _modelID;
        //武器id，依然是在ModelConfig中配置，(hide)
        private int _weaponID;
        //技能特效id(hide)
        private int _skillVfxID;
        //表演动作，暂时不支持配置(hide)
        private int _playAnimName;
        //待机动作(hide)
        private int _idleAnimName;
        //相机模糊特效参数(hide)
        private int _blurArgs;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Sex { get{ return _sex; }}
        public string JobName { get{ return HanderDefine.SetStingCallBack(_jobName); }}
        public int AtkType { get{ return _atk_type; }}
        public string Introduction { get{ return HanderDefine.SetStingCallBack(_introduction); }}
        public string Special { get{ return HanderDefine.SetStingCallBack(_special); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public string HeadIcon { get{ return HanderDefine.SetStingCallBack(_headIcon); }}
        public int ModelHeight { get{ return _modelHeight; }}
        public int ModelID { get{ return _modelID; }}
        public int WeaponID { get{ return _weaponID; }}
        public int SkillVfxID { get{ return _skillVfxID; }}
        public string PlayAnimName { get{ return HanderDefine.SetStingCallBack(_playAnimName); }}
        public string IdleAnimName { get{ return HanderDefine.SetStingCallBack(_idleAnimName); }}
        public string BlurArgs { get{ return HanderDefine.SetStingCallBack(_blurArgs); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclarePlayerOccupation cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclarePlayerOccupation> _dataCaches = null;
        public static Dictionary<int, DeclarePlayerOccupation> CacheData
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
                        if (HanderDefine.DataCallBack("PlayerOccupation", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclarePlayerOccupation cfg = null;
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
        private unsafe static DeclarePlayerOccupation LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclarePlayerOccupation();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._sex = (int)GetValue(keyIndex, _sex_Index, ptr);
            tmp._jobName = (int)GetValue(keyIndex, _jobName_Index, ptr);
            tmp._atk_type = (int)GetValue(keyIndex, _atk_type_Index, ptr);
            tmp._introduction = (int)GetValue(keyIndex, _introduction_Index, ptr);
            tmp._special = (int)GetValue(keyIndex, _special_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._headIcon = (int)GetValue(keyIndex, _headIcon_Index, ptr);
            tmp._modelHeight = (int)GetValue(keyIndex, _modelHeight_Index, ptr);
            tmp._modelID = (int)GetValue(keyIndex, _modelID_Index, ptr);
            tmp._weaponID = (int)GetValue(keyIndex, _weaponID_Index, ptr);
            tmp._skillVfxID = (int)GetValue(keyIndex, _skillVfxID_Index, ptr);
            tmp._playAnimName = (int)GetValue(keyIndex, _playAnimName_Index, ptr);
            tmp._idleAnimName = (int)GetValue(keyIndex, _idleAnimName_Index, ptr);
            tmp._blurArgs = (int)GetValue(keyIndex, _blurArgs_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("PlayerOccupation", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Sex", out _sex_Index)) _sex_Index = -1;
                    if (!nameIndexs.TryGetValue("JobName", out _jobName_Index)) _jobName_Index = -1;
                    if (!nameIndexs.TryGetValue("AtkType", out _atk_type_Index)) _atk_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Introduction", out _introduction_Index)) _introduction_Index = -1;
                    if (!nameIndexs.TryGetValue("Special", out _special_Index)) _special_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("HeadIcon", out _headIcon_Index)) _headIcon_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelHeight", out _modelHeight_Index)) _modelHeight_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelID", out _modelID_Index)) _modelID_Index = -1;
                    if (!nameIndexs.TryGetValue("WeaponID", out _weaponID_Index)) _weaponID_Index = -1;
                    if (!nameIndexs.TryGetValue("SkillVfxID", out _skillVfxID_Index)) _skillVfxID_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayAnimName", out _playAnimName_Index)) _playAnimName_Index = -1;
                    if (!nameIndexs.TryGetValue("IdleAnimName", out _idleAnimName_Index)) _idleAnimName_Index = -1;
                    if (!nameIndexs.TryGetValue("BlurArgs", out _blurArgs_Index)) _blurArgs_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclarePlayerOccupation>(keyCount);
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
            if(HanderDefine.DataCallBack("PlayerOccupation", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclarePlayerOccupation cfg = null;
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
        public static DeclarePlayerOccupation Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclarePlayerOccupation result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("PlayerOccupation", out _compressData))
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
