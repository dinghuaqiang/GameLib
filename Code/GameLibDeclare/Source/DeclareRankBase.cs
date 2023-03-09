//文件是自动生成,请勿手动修改.来自数据文件:Rank_base
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRankBase
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _sort_Index = -1;
        private static int _pic_Index = -1;
        private static int _type_name_Index = -1;
        private static int _serverEnum_Index = -1;
        private static int _uiValueDes_Index = -1;
        private static int _modelType_Index = -1;
        private static int _descPrefix_Index = -1;
        private static int _cleanWeek_Index = -1;
        private static int _rank_num_Index = -1;
        private static int _rank_truthNum_Index = -1;
        private static int _isShow_Index = -1;
        private static int _functionOpen_Index = -1;
        private static int _isShoweModel_Index = -1;
        private static int _isShoweEqup_Index = -1;
        private static int _mainTransfom_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //排行榜名称
        private int _name;
        //大类型分类
        private int _type;
        //排序优先级
        private int _sort;
        //名字读取的图片(hide)
        private int _pic;
        //大类型的名字
        private int _type_name;
        //服务器枚举值
        private int _serverEnum;
        //UI上数值的名称
        private int _uiValueDes;
        //显示模型类型(1.玩家,2.坐骑,3.翅膀,4.宠物,5.器灵,6精灵球,7魂甲)
        private int _modelType;
        //排行榜界面显示前缀
        //(hide)
        private int _descPrefix;
        //排行榜数据清理时间（0表示不清理，1表示周1，2表示周2，4表示周3，8表示周4，16表示周5，32表示周6，64表示周日）
        private int _cleanWeek;
        //进入排行榜的最大人数，用于决定最大的人数(排行榜功能显示用）
        private int _rank_num;
        //服务器实际统计人数（用于服务器统计的数据），主要是其他功能在使用
        private int _rank_truthNum;
        //是否在排行榜内显示
        //1显示。0不显示
        private int _isShow;
        //功能ID，对应functionstart表ID，检测功能是否开启
        //（hide）
        private int _functionOpen;
        //0不显示模型
        //1显示人物模型
        //2宠物模型
        //3坐骑模型
        //4法宝模型
        //5魂甲模型
        private int _isShoweModel;
        //0不显示装备
        //1人物装备
        //2圣装
        //3仙甲
        //4宠物装备
        //5灵体装备
        private int _isShoweEqup;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        //废弃
        private int _mainTransfom;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Sort { get{ return _sort; }}
        public int Pic { get{ return _pic; }}
        public string TypeName { get{ return HanderDefine.SetStingCallBack(_type_name); }}
        public int ServerEnum { get{ return _serverEnum; }}
        public string UiValueDes { get{ return HanderDefine.SetStingCallBack(_uiValueDes); }}
        public int ModelType { get{ return _modelType; }}
        public string DescPrefix { get{ return HanderDefine.SetStingCallBack(_descPrefix); }}
        public int CleanWeek { get{ return _cleanWeek; }}
        public int RankNum { get{ return _rank_num; }}
        public int RankTruthNum { get{ return _rank_truthNum; }}
        public int IsShow { get{ return _isShow; }}
        public int FunctionOpen { get{ return _functionOpen; }}
        public int IsShoweModel { get{ return _isShoweModel; }}
        public int IsShoweEqup { get{ return _isShoweEqup; }}
        public string MainTransfom { get{ return HanderDefine.SetStingCallBack(_mainTransfom); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRankBase cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRankBase> _dataCaches = null;
        public static Dictionary<int, DeclareRankBase> CacheData
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
                        if (HanderDefine.DataCallBack("RankBase", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRankBase cfg = null;
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
        private unsafe static DeclareRankBase LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRankBase();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._pic = (int)GetValue(keyIndex, _pic_Index, ptr);
            tmp._type_name = (int)GetValue(keyIndex, _type_name_Index, ptr);
            tmp._serverEnum = (int)GetValue(keyIndex, _serverEnum_Index, ptr);
            tmp._uiValueDes = (int)GetValue(keyIndex, _uiValueDes_Index, ptr);
            tmp._modelType = (int)GetValue(keyIndex, _modelType_Index, ptr);
            tmp._descPrefix = (int)GetValue(keyIndex, _descPrefix_Index, ptr);
            tmp._cleanWeek = (int)GetValue(keyIndex, _cleanWeek_Index, ptr);
            tmp._rank_num = (int)GetValue(keyIndex, _rank_num_Index, ptr);
            tmp._rank_truthNum = (int)GetValue(keyIndex, _rank_truthNum_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._functionOpen = (int)GetValue(keyIndex, _functionOpen_Index, ptr);
            tmp._isShoweModel = (int)GetValue(keyIndex, _isShoweModel_Index, ptr);
            tmp._isShoweEqup = (int)GetValue(keyIndex, _isShoweEqup_Index, ptr);
            tmp._mainTransfom = (int)GetValue(keyIndex, _mainTransfom_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RankBase", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Pic", out _pic_Index)) _pic_Index = -1;
                    if (!nameIndexs.TryGetValue("TypeName", out _type_name_Index)) _type_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ServerEnum", out _serverEnum_Index)) _serverEnum_Index = -1;
                    if (!nameIndexs.TryGetValue("UiValueDes", out _uiValueDes_Index)) _uiValueDes_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelType", out _modelType_Index)) _modelType_Index = -1;
                    if (!nameIndexs.TryGetValue("DescPrefix", out _descPrefix_Index)) _descPrefix_Index = -1;
                    if (!nameIndexs.TryGetValue("CleanWeek", out _cleanWeek_Index)) _cleanWeek_Index = -1;
                    if (!nameIndexs.TryGetValue("RankNum", out _rank_num_Index)) _rank_num_Index = -1;
                    if (!nameIndexs.TryGetValue("RankTruthNum", out _rank_truthNum_Index)) _rank_truthNum_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionOpen", out _functionOpen_Index)) _functionOpen_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShoweModel", out _isShoweModel_Index)) _isShoweModel_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShoweEqup", out _isShoweEqup_Index)) _isShoweEqup_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTransfom", out _mainTransfom_Index)) _mainTransfom_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRankBase>(keyCount);
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
            if(HanderDefine.DataCallBack("RankBase", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRankBase cfg = null;
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
        public static DeclareRankBase Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRankBase result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RankBase", out _compressData))
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
