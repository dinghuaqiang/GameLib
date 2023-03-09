//文件是自动生成,请勿手动修改.来自数据文件:limit_shop
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareLimitShop
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _reward_Index = -1;
        private static int _desc_Index = -1;
        private static int _sort_Index = -1;
        private static int _condition_Index = -1;
        private static int _originalPrice_Index = -1;
        private static int _presentPrice_Index = -1;
        private static int _discount_Index = -1;
        private static int _time_Index = -1;
        private static int _tipsDes_Index = -1;
        private static int _isShowTips_Index = -1;
        #endregion
        #region //私有变量定义
        //商城编号
        private int _id;
        //ItemId_num_bind_occ
        //bind：0未绑定，1绑定
        //occ：0男1女9通用
        private int _reward;
        //策划用于备注字段，无实际意义，程序不调用
        //（hide）
        private int _desc;
        //排序，用于界面显示排序
        //（hide）
        private int _sort;
        //1等级
        //2任务
        //3境界（废弃）
        //4VIP等级
        //5登陆天数
        //6购买了指定礼包出现(-1代表最后一个，购买完就消失） 
        // //强化x件到N   private final int COND_INTENSIFY = 7;
        // //开服天数   private final int COND_OPENSERVERDAY = 8;
        // //功能开启   private final int COND_FUNCOPEN = 9;
        // //寻宝X次  private final int COND_XUNBAO = 10;（对应普通寻宝表的类型）
        // //套装，激活x阶N套  private final int COND_SUIT = 11;
        // //神兽岛  private final int COND_SOULBEAST = 12;（废弃）
        ////仙甲寻宝每轮结束当天  private final int COND_XIANJIALASTDAY = 13;(参数为轮数）
        //14 仙甲寻宝每轮寻宝次数
        private int _condition;
        //原价hide
        private int _originalPrice;
        //现价
        private int _presentPrice;
        //折扣hide（万分比，程序取值的时候会除以一万显示）
        private int _discount;
        //有效购买时间（秒）
        //-1代表无限制时间
        private int _time;
        //新品上架弹出文字提示
        //（hide）
        private int _tipsDes;
        //是否弹出新品提示Tips
        //0否
        //1是（要弹出）
        //（hide）
        private int _isShowTips;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public string Desc { get{ return HanderDefine.SetStingCallBack(_desc); }}
        public int Sort { get{ return _sort; }}
        public string Condition { get{ return HanderDefine.SetStingCallBack(_condition); }}
        public int OriginalPrice { get{ return _originalPrice; }}
        public int PresentPrice { get{ return _presentPrice; }}
        public int Discount { get{ return _discount; }}
        public int Time { get{ return _time; }}
        public string TipsDes { get{ return HanderDefine.SetStingCallBack(_tipsDes); }}
        public int IsShowTips { get{ return _isShowTips; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareLimitShop cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareLimitShop> _dataCaches = null;
        public static Dictionary<int, DeclareLimitShop> CacheData
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
                        if (HanderDefine.DataCallBack("LimitShop", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareLimitShop cfg = null;
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
        private unsafe static DeclareLimitShop LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareLimitShop();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._desc = (int)GetValue(keyIndex, _desc_Index, ptr);
            tmp._sort = (int)GetValue(keyIndex, _sort_Index, ptr);
            tmp._condition = (int)GetValue(keyIndex, _condition_Index, ptr);
            tmp._originalPrice = (int)GetValue(keyIndex, _originalPrice_Index, ptr);
            tmp._presentPrice = (int)GetValue(keyIndex, _presentPrice_Index, ptr);
            tmp._discount = (int)GetValue(keyIndex, _discount_Index, ptr);
            tmp._time = (int)GetValue(keyIndex, _time_Index, ptr);
            tmp._tipsDes = (int)GetValue(keyIndex, _tipsDes_Index, ptr);
            tmp._isShowTips = (int)GetValue(keyIndex, _isShowTips_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("LimitShop", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("Desc", out _desc_Index)) _desc_Index = -1;
                    if (!nameIndexs.TryGetValue("Sort", out _sort_Index)) _sort_Index = -1;
                    if (!nameIndexs.TryGetValue("Condition", out _condition_Index)) _condition_Index = -1;
                    if (!nameIndexs.TryGetValue("OriginalPrice", out _originalPrice_Index)) _originalPrice_Index = -1;
                    if (!nameIndexs.TryGetValue("PresentPrice", out _presentPrice_Index)) _presentPrice_Index = -1;
                    if (!nameIndexs.TryGetValue("Discount", out _discount_Index)) _discount_Index = -1;
                    if (!nameIndexs.TryGetValue("Time", out _time_Index)) _time_Index = -1;
                    if (!nameIndexs.TryGetValue("TipsDes", out _tipsDes_Index)) _tipsDes_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShowTips", out _isShowTips_Index)) _isShowTips_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareLimitShop>(keyCount);
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
            if(HanderDefine.DataCallBack("LimitShop", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareLimitShop cfg = null;
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
        public static DeclareLimitShop Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareLimitShop result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("LimitShop", out _compressData))
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
