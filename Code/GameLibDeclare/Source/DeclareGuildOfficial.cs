//文件是自动生成,请勿手动修改.来自数据文件:guild_official
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildOfficial
    {
        #region //静态变量定义
        private static int _level_Index = -1;
        private static int _modify_office_according_Index = -1;
        private static int _list_application_Index = -1;
        private static int _name_Index = -1;
        private static int _canNotice_Index = -1;
        private static int _num_Index = -1;
        private static int _canAgree_Index = -1;
        private static int _canKick_Index = -1;
        private static int _canUp_Index = -1;
        private static int _canAlter_Index = -1;
        private static int _canSetOfficial_Index = -1;
        private static int _canHan_Index = -1;
        private static int _guild_fighting_Index = -1;
        private static int _kuafu_match_Index = -1;
        private static int _voice_Index = -1;
        private static int _warRewardLimit_Index = -1;
        #endregion
        #region //私有变量定义
        //官职（1普通成员，2长老，3副会长，4会长）
        private int _level;
        //是否显示更改官职(0为不显示)hide
        private int _modify_office_according;
        //是否显示申请列表(0为不显示)hide
        private int _list_application;
        //名字显示(hide)
        private int _name;
        //修改公告（0不能1能）
        private int _canNotice;
        //官职人数限制(0无限制）
        private int _num;
        //同意其他玩家进入公会（0不能1能）
        private int _canAgree;
        //踢人（0不能1能）
        private int _canKick;
        //升级建筑（0不能1能）
        private int _canUp;
        //修改申请设置（0不能1能）
        private int _canAlter;
        //官职任免(0不能1能)
        private int _canSetOfficial;
        //喊话招人
        private int _canHan;
        //是否能参加帮会战
        private int _guild_fighting;
        //跨服公会联赛报名权限
        private int _kuafu_match;
        //语音权限（任命指挥）
        private int _voice;
        //仙盟战领奖权限
        //（0不能1能）
        private int _warRewardLimit;
        #endregion

        #region //公共属性
        public int Level { get{ return _level; }}
        public int ModifyOfficeAccording { get{ return _modify_office_according; }}
        public int ListApplication { get{ return _list_application; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int CanNotice { get{ return _canNotice; }}
        public int Num { get{ return _num; }}
        public int CanAgree { get{ return _canAgree; }}
        public int CanKick { get{ return _canKick; }}
        public int CanUp { get{ return _canUp; }}
        public int CanAlter { get{ return _canAlter; }}
        public int CanSetOfficial { get{ return _canSetOfficial; }}
        public int CanHan { get{ return _canHan; }}
        public int GuildFighting { get{ return _guild_fighting; }}
        public int KuafuMatch { get{ return _kuafu_match; }}
        public int Voice { get{ return _voice; }}
        public int WarRewardLimit { get{ return _warRewardLimit; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildOfficial cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildOfficial> _dataCaches = null;
        public static Dictionary<int, DeclareGuildOfficial> CacheData
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
                        if (HanderDefine.DataCallBack("GuildOfficial", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildOfficial cfg = null;
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
        private unsafe static DeclareGuildOfficial LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildOfficial();
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._modify_office_according = (int)GetValue(keyIndex, _modify_office_according_Index, ptr);
            tmp._list_application = (int)GetValue(keyIndex, _list_application_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._canNotice = (int)GetValue(keyIndex, _canNotice_Index, ptr);
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._canAgree = (int)GetValue(keyIndex, _canAgree_Index, ptr);
            tmp._canKick = (int)GetValue(keyIndex, _canKick_Index, ptr);
            tmp._canUp = (int)GetValue(keyIndex, _canUp_Index, ptr);
            tmp._canAlter = (int)GetValue(keyIndex, _canAlter_Index, ptr);
            tmp._canSetOfficial = (int)GetValue(keyIndex, _canSetOfficial_Index, ptr);
            tmp._canHan = (int)GetValue(keyIndex, _canHan_Index, ptr);
            tmp._guild_fighting = (int)GetValue(keyIndex, _guild_fighting_Index, ptr);
            tmp._kuafu_match = (int)GetValue(keyIndex, _kuafu_match_Index, ptr);
            tmp._voice = (int)GetValue(keyIndex, _voice_Index, ptr);
            tmp._warRewardLimit = (int)GetValue(keyIndex, _warRewardLimit_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildOfficial", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("ModifyOfficeAccording", out _modify_office_according_Index)) _modify_office_according_Index = -1;
                    if (!nameIndexs.TryGetValue("ListApplication", out _list_application_Index)) _list_application_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("CanNotice", out _canNotice_Index)) _canNotice_Index = -1;
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("CanAgree", out _canAgree_Index)) _canAgree_Index = -1;
                    if (!nameIndexs.TryGetValue("CanKick", out _canKick_Index)) _canKick_Index = -1;
                    if (!nameIndexs.TryGetValue("CanUp", out _canUp_Index)) _canUp_Index = -1;
                    if (!nameIndexs.TryGetValue("CanAlter", out _canAlter_Index)) _canAlter_Index = -1;
                    if (!nameIndexs.TryGetValue("CanSetOfficial", out _canSetOfficial_Index)) _canSetOfficial_Index = -1;
                    if (!nameIndexs.TryGetValue("CanHan", out _canHan_Index)) _canHan_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildFighting", out _guild_fighting_Index)) _guild_fighting_Index = -1;
                    if (!nameIndexs.TryGetValue("KuafuMatch", out _kuafu_match_Index)) _kuafu_match_Index = -1;
                    if (!nameIndexs.TryGetValue("Voice", out _voice_Index)) _voice_Index = -1;
                    if (!nameIndexs.TryGetValue("WarRewardLimit", out _warRewardLimit_Index)) _warRewardLimit_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildOfficial>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildOfficial", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildOfficial cfg = null;
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
        public static DeclareGuildOfficial Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildOfficial result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildOfficial", out _compressData))
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
