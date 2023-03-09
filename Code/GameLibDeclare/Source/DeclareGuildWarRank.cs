//文件是自动生成,请勿手动修改.来自数据文件:guild_war_rank
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildWarRank
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _count_Index = -1;
        private static int _firstRankMethod_Index = -1;
        private static int _showGodIcon_Index = -1;
        private static int _showGodName_Index = -1;
        private static int _guildReward1_Index = -1;
        private static int _guildReward2_Index = -1;
        private static int _guildReward3_Index = -1;
        private static int _personalReward1_Index = -1;
        private static int _personalReward2_Index = -1;
        private static int _personalReward3_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //评级名称
        private int _name;
        //评级对应的图标hide
        private int _icon;
        //每个评级对应的仙盟数量
        private int _count;
        //评级方式
        //-1代表每次评级都按照战斗力排序
        //具体值代表选取的战斗力排名范围
        private int _firstRankMethod;
        //战神仙盟对应的绶带icon显示
        //-1代表没有特殊显示
        //hide
        private int _showGodIcon;
        //各个评级的第一名对应的特殊名称显示
        //-1代表没有特殊显示
        //hide
        private int _showGodName;
        //第一名仙盟结算奖励
        //物品_数量_绑定
        //物品：对应item表主键
        //数量：对应奖励的数量
        //绑定：0未绑定1绑定(需要上仙盟拍卖行的必须是未绑定状态）
        private int _guildReward1;
        //第二名仙盟结算奖励
        private int _guildReward2;
        //第三名仙盟结算奖励
        private int _guildReward3;
        //第一名个人结算奖励
        //物品_数量_绑定_职业
        //物品：对应item表主键
        //数量：对应奖励的数量
        //绑定：0未绑定1绑定
        //职业：0男剑1女枪9通用
        private int _personalReward1;
        //第二名个人结算奖励
        private int _personalReward2;
        //第三名个人结算奖励
        private int _personalReward3;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int Count { get{ return _count; }}
        public string FirstRankMethod { get{ return HanderDefine.SetStingCallBack(_firstRankMethod); }}
        public int ShowGodIcon { get{ return _showGodIcon; }}
        public string ShowGodName { get{ return HanderDefine.SetStingCallBack(_showGodName); }}
        public string GuildReward1 { get{ return HanderDefine.SetStingCallBack(_guildReward1); }}
        public string GuildReward2 { get{ return HanderDefine.SetStingCallBack(_guildReward2); }}
        public string GuildReward3 { get{ return HanderDefine.SetStingCallBack(_guildReward3); }}
        public string PersonalReward1 { get{ return HanderDefine.SetStingCallBack(_personalReward1); }}
        public string PersonalReward2 { get{ return HanderDefine.SetStingCallBack(_personalReward2); }}
        public string PersonalReward3 { get{ return HanderDefine.SetStingCallBack(_personalReward3); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildWarRank cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildWarRank> _dataCaches = null;
        public static Dictionary<int, DeclareGuildWarRank> CacheData
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
                        if (HanderDefine.DataCallBack("GuildWarRank", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildWarRank cfg = null;
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
        private unsafe static DeclareGuildWarRank LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildWarRank();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._count = (int)GetValue(keyIndex, _count_Index, ptr);
            tmp._firstRankMethod = (int)GetValue(keyIndex, _firstRankMethod_Index, ptr);
            tmp._showGodIcon = (int)GetValue(keyIndex, _showGodIcon_Index, ptr);
            tmp._showGodName = (int)GetValue(keyIndex, _showGodName_Index, ptr);
            tmp._guildReward1 = (int)GetValue(keyIndex, _guildReward1_Index, ptr);
            tmp._guildReward2 = (int)GetValue(keyIndex, _guildReward2_Index, ptr);
            tmp._guildReward3 = (int)GetValue(keyIndex, _guildReward3_Index, ptr);
            tmp._personalReward1 = (int)GetValue(keyIndex, _personalReward1_Index, ptr);
            tmp._personalReward2 = (int)GetValue(keyIndex, _personalReward2_Index, ptr);
            tmp._personalReward3 = (int)GetValue(keyIndex, _personalReward3_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildWarRank", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Count", out _count_Index)) _count_Index = -1;
                    if (!nameIndexs.TryGetValue("FirstRankMethod", out _firstRankMethod_Index)) _firstRankMethod_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGodIcon", out _showGodIcon_Index)) _showGodIcon_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowGodName", out _showGodName_Index)) _showGodName_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildReward1", out _guildReward1_Index)) _guildReward1_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildReward2", out _guildReward2_Index)) _guildReward2_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildReward3", out _guildReward3_Index)) _guildReward3_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalReward1", out _personalReward1_Index)) _personalReward1_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalReward2", out _personalReward2_Index)) _personalReward2_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalReward3", out _personalReward3_Index)) _personalReward3_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildWarRank>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildWarRank", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildWarRank cfg = null;
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
        public static DeclareGuildWarRank Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildWarRank result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildWarRank", out _compressData))
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
