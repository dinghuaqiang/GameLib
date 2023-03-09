//文件是自动生成,请勿手动修改.来自数据文件:Cross_Alien_Connect
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareCrossAlienConnect
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _group_Index = -1;
        private static int _connectCity_Index = -1;
        private static int _connectLine_Index = -1;
        private static int _copyName_Index = -1;
        private static int _copyId_Index = -1;
        private static int _showIcon_Index = -1;
        private static int _showReward_Index = -1;
        private static int _gemCopy_Index = -1;
        private static int _showName_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //副本类型
        //（1：一级副本
        //2：二级副本
        //3：三级副本）
        private int _type;
        //1=A组
        //2=B组
        //用于服务器根据活动随机显示一组，只用于二级城市分组
        private int _group;
        //链接城市
        //（对应Cross_fudi_main主键）
        private int _connectCity;
        //连接线
        //城市和连接线的对应关系
        //（hide）
        private int _connectLine;
        //副本名字
        private int _copyName;
        //副本ID
        //对应clone_map表主键
        private int _copyId;
        //副本对应Icon显示
        //(hide)
        private int _showIcon;
        //对应Cross_Alien_Connect_Show主键
        //（hide）
        private int _showReward;
        //对应须弥宝库的副本
        //对应Cross_Alien_Gem_Copy主键
        private int _gemCopy;
        //界面链接城市的名字显示
        //（hide）
        private int _showName;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Group { get{ return _group; }}
        public string ConnectCity { get{ return HanderDefine.SetStingCallBack(_connectCity); }}
        public string ConnectLine { get{ return HanderDefine.SetStingCallBack(_connectLine); }}
        public string CopyName { get{ return HanderDefine.SetStingCallBack(_copyName); }}
        public int CopyId { get{ return _copyId; }}
        public int ShowIcon { get{ return _showIcon; }}
        public string ShowReward { get{ return HanderDefine.SetStingCallBack(_showReward); }}
        public int GemCopy { get{ return _gemCopy; }}
        public string ShowName { get{ return HanderDefine.SetStingCallBack(_showName); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareCrossAlienConnect cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareCrossAlienConnect> _dataCaches = null;
        public static Dictionary<int, DeclareCrossAlienConnect> CacheData
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
                        if (HanderDefine.DataCallBack("CrossAlienConnect", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareCrossAlienConnect cfg = null;
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
        private unsafe static DeclareCrossAlienConnect LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareCrossAlienConnect();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._group = (int)GetValue(keyIndex, _group_Index, ptr);
            tmp._connectCity = (int)GetValue(keyIndex, _connectCity_Index, ptr);
            tmp._connectLine = (int)GetValue(keyIndex, _connectLine_Index, ptr);
            tmp._copyName = (int)GetValue(keyIndex, _copyName_Index, ptr);
            tmp._copyId = (int)GetValue(keyIndex, _copyId_Index, ptr);
            tmp._showIcon = (int)GetValue(keyIndex, _showIcon_Index, ptr);
            tmp._showReward = (int)GetValue(keyIndex, _showReward_Index, ptr);
            tmp._gemCopy = (int)GetValue(keyIndex, _gemCopy_Index, ptr);
            tmp._showName = (int)GetValue(keyIndex, _showName_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("CrossAlienConnect", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Group", out _group_Index)) _group_Index = -1;
                    if (!nameIndexs.TryGetValue("ConnectCity", out _connectCity_Index)) _connectCity_Index = -1;
                    if (!nameIndexs.TryGetValue("ConnectLine", out _connectLine_Index)) _connectLine_Index = -1;
                    if (!nameIndexs.TryGetValue("CopyName", out _copyName_Index)) _copyName_Index = -1;
                    if (!nameIndexs.TryGetValue("CopyId", out _copyId_Index)) _copyId_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowIcon", out _showIcon_Index)) _showIcon_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowReward", out _showReward_Index)) _showReward_Index = -1;
                    if (!nameIndexs.TryGetValue("GemCopy", out _gemCopy_Index)) _gemCopy_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowName", out _showName_Index)) _showName_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareCrossAlienConnect>(keyCount);
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
            if(HanderDefine.DataCallBack("CrossAlienConnect", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareCrossAlienConnect cfg = null;
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
        public static DeclareCrossAlienConnect Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareCrossAlienConnect result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("CrossAlienConnect", out _compressData))
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
