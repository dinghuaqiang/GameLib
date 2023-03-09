//文件是自动生成,请勿手动修改.来自数据文件:new_sever_rank
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverRank
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _parm_Index = -1;
        private static int _serverEndTime_Index = -1;
        private static int _time_Index = -1;
        private static int _rew_rank_Index = -1;
        private static int _show_fake_ranke_Index = -1;
        private static int _showname_Index = -1;
        private static int _des_texture_Index = -1;
        private static int _show_texture_Index = -1;
        private static int _iconname1_Index = -1;
        private static int _icon1_Index = -1;
        private static int _path1_Index = -1;
        private static int _iconname2_Index = -1;
        private static int _icon2_Index = -1;
        private static int _path2_Index = -1;
        private static int _iconname3_Index = -1;
        private static int _icon3_Index = -1;
        private static int _path3_Index = -1;
        private static int _des_Index = -1;
        private static int _openLimitShop_Index = -1;
        private static int _openLimitShop2_Index = -1;
        private static int _limitShopCondition_Index = -1;
        private static int _limitShopCondition2_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //id
        //（ID=1时为等级比拼持续2天，
        //ID=3时代表当日充值比拼，当前暂时没有使用）
        private int _id;
        //0表示读取排行榜
        //1表示今日充值
        private int _type;
        //type为0时读取的排行榜的ID
        private int _parm;
        //服务器结束时间，1表示开服当天23:59分，具体时间点通过global配置
        //始终只开启1个，功能开放时开启
        private int _serverEndTime;
        //活动持续时间（天）
        //(hide)
        private int _time;
        //真实具体给与奖励的排名
        private int _rew_rank;
        //做假排名的方式[A,B]
        //假排名=取整(（真实排名-配置A）配置B+配置A)
        private int _show_fake_ranke;
        //显示名字
        private int _showname;
        //显示的图片艺术字的内容(hide)
        private int _des_texture;
        //具体的图片的主要是背景妹子内容(hide)
        private int _show_texture;
        //具体的路径(hide)
        private int _iconname1;
        //显示的途径ICON，item图集下面(hide)
        private int _icon1;
        //链接的途径
        //functionstartID(hide)
        private int _path1;
        //具体的路径(hide)
        private int _iconname2;
        //显示的途径ICON(hide)
        private int _icon2;
        //链接的途径
        //functionstartID(hide)
        private int _path2;
        //具体的路径(hide)
        private int _iconname3;
        //显示的途径ICON(hide)
        private int _icon3;
        //链接的途径
        //functionstartID(hide)
        private int _path3;
        //简单的描述(hide)
        private int _des;
        //打开对应超值折扣的商品界面
        //对应limit_direct_shop主键
        //（hide）
        private int _openLimitShop;
        //打开对应超值折扣的商品界面
        //对应limit_gold_shop主键
        //（hide）
        private int _openLimitShop2;
        //读取limit_direct_shop表
        //达到条件后才可开始跳转
        //可配置多个ID，或关系，任意一个满足都可以支持跳转
        //（hide）
        private int _limitShopCondition;
        //读取limit_gold_shop表
        //达到对应商品显示条件后才可开始跳转
        //可配置多个ID，或关系，任意一个满足都可以支持跳转
        //（hide）
        private int _limitShopCondition2;
        //激活时的公告频道(10跑马灯)
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Parm { get{ return _parm; }}
        public int ServerEndTime { get{ return _serverEndTime; }}
        public int Time { get{ return _time; }}
        public int RewRank { get{ return _rew_rank; }}
        public string ShowFakeRanke { get{ return HanderDefine.SetStingCallBack(_show_fake_ranke); }}
        public string Showname { get{ return HanderDefine.SetStingCallBack(_showname); }}
        public string DesTexture { get{ return HanderDefine.SetStingCallBack(_des_texture); }}
        public string ShowTexture { get{ return HanderDefine.SetStingCallBack(_show_texture); }}
        public string Iconname1 { get{ return HanderDefine.SetStingCallBack(_iconname1); }}
        public int Icon1 { get{ return _icon1; }}
        public int Path1 { get{ return _path1; }}
        public string Iconname2 { get{ return HanderDefine.SetStingCallBack(_iconname2); }}
        public int Icon2 { get{ return _icon2; }}
        public int Path2 { get{ return _path2; }}
        public string Iconname3 { get{ return HanderDefine.SetStingCallBack(_iconname3); }}
        public int Icon3 { get{ return _icon3; }}
        public int Path3 { get{ return _path3; }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public string OpenLimitShop { get{ return HanderDefine.SetStingCallBack(_openLimitShop); }}
        public string OpenLimitShop2 { get{ return HanderDefine.SetStingCallBack(_openLimitShop2); }}
        public string LimitShopCondition { get{ return HanderDefine.SetStingCallBack(_limitShopCondition); }}
        public string LimitShopCondition2 { get{ return HanderDefine.SetStingCallBack(_limitShopCondition2); }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverRank cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverRank> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverRank> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverRank", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverRank cfg = null;
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
        private unsafe static DeclareNewSeverRank LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverRank();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._parm = (int)GetValue(keyIndex, _parm_Index, ptr);
            tmp._serverEndTime = (int)GetValue(keyIndex, _serverEndTime_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._rew_rank = (int)GetValue(keyIndex, _rew_rank_Index, ptr);
            tmp._show_fake_ranke = (int)GetValue(keyIndex, _show_fake_ranke_Index, ptr);
            tmp._showname = (int)GetValue(keyIndex, _showname_Index, ptr);
            tmp._des_texture = (int)GetValue(keyIndex, _des_texture_Index, ptr);
            tmp._show_texture = (int)GetValue(keyIndex, _show_texture_Index, ptr);
            tmp._iconname1 = (int)GetValue(keyIndex, _iconname1_Index, ptr);
            tmp._icon1 = (int)GetValue(keyIndex, _icon1_Index, ptr);
            tmp._path1 = (int)GetValue(keyIndex, _path1_Index, ptr);
            tmp._iconname2 = (int)GetValue(keyIndex, _iconname2_Index, ptr);
            tmp._icon2 = (int)GetValue(keyIndex, _icon2_Index, ptr);
            tmp._path2 = (int)GetValue(keyIndex, _path2_Index, ptr);
            tmp._iconname3 = (int)GetValue(keyIndex, _iconname3_Index, ptr);
            tmp._icon3 = (int)GetValue(keyIndex, _icon3_Index, ptr);
            tmp._path3 = (int)GetValue(keyIndex, _path3_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._openLimitShop = (int)GetValue(keyIndex, _openLimitShop_Index, ptr);
            tmp._openLimitShop2 = (int)GetValue(keyIndex, _openLimitShop2_Index, ptr);
            tmp._limitShopCondition = (int)GetValue(keyIndex, _limitShopCondition_Index, ptr);
            tmp._limitShopCondition2 = (int)GetValue(keyIndex, _limitShopCondition2_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverRank", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Parm", out _parm_Index)) _parm_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerEndTime", out _serverEndTime_Index)) _serverEndTime_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("RewRank", out _rew_rank_Index)) _rew_rank_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowFakeRanke", out _show_fake_ranke_Index)) _show_fake_ranke_Index = -1;
                    if (!nameIndexs.TryGetValue("Showname", out _showname_Index)) _showname_Index = -1;
                    if (!nameIndexs.TryGetValue("DesTexture", out _des_texture_Index)) _des_texture_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowTexture", out _show_texture_Index)) _show_texture_Index = -1;
                    if (!nameIndexs.TryGetValue("Iconname1", out _iconname1_Index)) _iconname1_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon1", out _icon1_Index)) _icon1_Index = -1;
                    if (!nameIndexs.TryGetValue("Path1", out _path1_Index)) _path1_Index = -1;
                    if (!nameIndexs.TryGetValue("Iconname2", out _iconname2_Index)) _iconname2_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon2", out _icon2_Index)) _icon2_Index = -1;
                    if (!nameIndexs.TryGetValue("Path2", out _path2_Index)) _path2_Index = -1;
                    if (!nameIndexs.TryGetValue("Iconname3", out _iconname3_Index)) _iconname3_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon3", out _icon3_Index)) _icon3_Index = -1;
                    if (!nameIndexs.TryGetValue("Path3", out _path3_Index)) _path3_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenLimitShop", out _openLimitShop_Index)) _openLimitShop_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenLimitShop2", out _openLimitShop2_Index)) _openLimitShop2_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitShopCondition", out _limitShopCondition_Index)) _limitShopCondition_Index = -1;
                    if (!nameIndexs.TryGetValue("LimitShopCondition2", out _limitShopCondition2_Index)) _limitShopCondition2_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverRank>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverRank", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverRank cfg = null;
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
        public static DeclareNewSeverRank Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverRank result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverRank", out _compressData))
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
