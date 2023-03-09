//文件是自动生成,请勿手动修改.来自数据文件:RankAwardType
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRankAwardType
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _rank_type_Index = -1;
        private static int _link_rank_id_Index = -1;
        private static int _start_day_Index = -1;
        private static int _end_day_Index = -1;
        private static int _link_func_id_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _reach_desc_Index = -1;
        private static int _rank_desc_Index = -1;
        private static int _info_desc_Index = -1;
        private static int _top_desc_Index = -1;
        private static int _bottom_desc_Index = -1;
        private static int _tex_Index = -1;
        private static int _model_name_Index = -1;
        private static int _model_id_Index = -1;
        #endregion
        #region //私有变量定义
        //key值
        //ID=11是写死的消费灵玉榜，不可修改
        private int _id;
        //排名类型（
        //0：读取排行榜
        //1：金元宝消费排名，程序特殊处理）
        private int _rank_type;
        //链接的排行榜id
        //关联Rank_base主键
        private int _link_rank_id;
        //开始天数
        //包含配置当天
        private int _start_day;
        //结束天数
        //包含配置当天
        private int _end_day;
        //绑定的功能id，此功能开启之后才会显示（hide）
        private int _link_func_id;
        //比拼显示名字
        private int _name;
        //比拼显示icon
        //（hide）
        private int _icon;
        //达成描述（hide）
        private int _reach_desc;
        //排名描述（hide）
        private int _rank_desc;
        //显示在界面上用于区分页签比拼内容
        //（hide）
        private int _info_desc;
        //顶部描述，活动规则
        //（hide）
        private int _top_desc;
        //底部描述（hide）
        private int _bottom_desc;
        //显示对应的图片
        //（hide）
        private int _tex;
        //显示的模型名字
        // (hide)
        private int _model_name;
        //展示模型
        //ID_scr_posX_posY_rotX_rotY_rotZ_occ
        //scr:需要扩大100倍填写，100代表1倍大小
        //（hide）
        private int _model_id;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int RankType { get{ return _rank_type; }}
        public int LinkRankId { get{ return _link_rank_id; }}
        public int StartDay { get{ return _start_day; }}
        public int EndDay { get{ return _end_day; }}
        public int LinkFuncId { get{ return _link_func_id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public string ReachDesc { get{ return HanderDefine.SetStingCallBack(_reach_desc); }}
        public string RankDesc { get{ return HanderDefine.SetStingCallBack(_rank_desc); }}
        public string InfoDesc { get{ return HanderDefine.SetStingCallBack(_info_desc); }}
        public string TopDesc { get{ return HanderDefine.SetStingCallBack(_top_desc); }}
        public string BottomDesc { get{ return HanderDefine.SetStingCallBack(_bottom_desc); }}
        public string Tex { get{ return HanderDefine.SetStingCallBack(_tex); }}
        public string ModelName { get{ return HanderDefine.SetStingCallBack(_model_name); }}
        public string ModelId { get{ return HanderDefine.SetStingCallBack(_model_id); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRankAwardType cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRankAwardType> _dataCaches = null;
        public static Dictionary<int, DeclareRankAwardType> CacheData
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
                        if (HanderDefine.DataCallBack("RankAwardType", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRankAwardType cfg = null;
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
        private unsafe static DeclareRankAwardType LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRankAwardType();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._rank_type = (int)GetValue(keyIndex, _rank_type_Index, ptr);
            tmp._link_rank_id = (int)GetValue(keyIndex, _link_rank_id_Index, ptr);
            tmp._start_day = (int)GetValue(keyIndex, _start_day_Index, ptr);
            tmp._end_day = (int)GetValue(keyIndex, _end_day_Index, ptr);
            tmp._link_func_id = (int)GetValue(keyIndex, _link_func_id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._reach_desc = (int)GetValue(keyIndex, _reach_desc_Index, ptr);
            tmp._rank_desc = (int)GetValue(keyIndex, _rank_desc_Index, ptr);
            tmp._info_desc = (int)GetValue(keyIndex, _info_desc_Index, ptr);
            tmp._top_desc = (int)GetValue(keyIndex, _top_desc_Index, ptr);
            tmp._bottom_desc = (int)GetValue(keyIndex, _bottom_desc_Index, ptr);
            tmp._tex = (int)GetValue(keyIndex, _tex_Index, ptr);
            tmp._model_name = (int)GetValue(keyIndex, _model_name_Index, ptr);
            tmp._model_id = (int)GetValue(keyIndex, _model_id_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RankAwardType", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("RankType", out _rank_type_Index)) _rank_type_Index = -1;
                    if (!nameIndexs.TryGetValue("LinkRankId", out _link_rank_id_Index)) _link_rank_id_Index = -1;
                    if (!nameIndexs.TryGetValue("StartDay", out _start_day_Index)) _start_day_Index = -1;
                    if (!nameIndexs.TryGetValue("EndDay", out _end_day_Index)) _end_day_Index = -1;
                    if (!nameIndexs.TryGetValue("LinkFuncId", out _link_func_id_Index)) _link_func_id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ReachDesc", out _reach_desc_Index)) _reach_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("RankDesc", out _rank_desc_Index)) _rank_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("InfoDesc", out _info_desc_Index)) _info_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("TopDesc", out _top_desc_Index)) _top_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("BottomDesc", out _bottom_desc_Index)) _bottom_desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Tex", out _tex_Index)) _tex_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelName", out _model_name_Index)) _model_name_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _model_id_Index)) _model_id_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRankAwardType>(keyCount);
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
            if(HanderDefine.DataCallBack("RankAwardType", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRankAwardType cfg = null;
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
        public static DeclareRankAwardType Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRankAwardType result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RankAwardType", out _compressData))
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
