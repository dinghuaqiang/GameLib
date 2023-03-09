//文件是自动生成,请勿手动修改.来自数据文件:activity_yunying
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareActivityYunying
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _logic_id_Index = -1;
        private static int _festival_id_Index = -1;
        private static int _use_ui_id_Index = -1;
        #endregion
        #region //私有变量定义
        //key值
        private int _id;
        //所属逻辑ID    
        // 1, -- 活跃兑换
        // 2, -- 每日充值
        // 3, -- 登陆有礼
        // 4, -- 限购礼包
        // 5, -- 天帝宝库
        // 6, -- 累计充值
        // 7, -- 限时消耗
        // 8, -- 集物兑换
        // 9, -- 团购
        // 10, -- 招财猫
        // 11,  --首领狂欢
        // 12, --庆典任务
        // 13,  --节日集字
        // 14,  --节日特惠(直购礼包)
        // 15,  --连续累充
        // 16,--限时商城
        // 17,  --限时礼包
        // 18,  --积分排名
        // 19,  --节日许愿
        // 20,  --FB分享
        // 21,--连续累充2（直接购买）
        //22,--新年祝福
        //23,--掷骰子
        //24.--外观展示
        //25.--上线图片提示
        //26, --聚宝盆
        //27, --幸运砸蛋
        //28, --绑玉招财猫
        private int _logic_id;
        //0 普通活动
        //1 元旦
        //2 情人节
        //3 妇女节
        //4 愚人节
        //5 劳动节
        //6 儿童节
        //7 教师节
        //8 圣诞节
        //9 新年
        //10 元宵节
        //11 清明节
        //12 端午节
        //13 七夕
        //14 中秋节
        //15 重阳节
        //16 腊八节
        //17 除夕
        //18 泼水节
        //19 招财猫专用
        private int _festival_id;
        //使用的Uiid hide
        private int _use_ui_id;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int LogicId { get{ return _logic_id; }}
        public int FestivalId { get{ return _festival_id; }}
        public int UseUiId { get{ return _use_ui_id; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareActivityYunying cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareActivityYunying> _dataCaches = null;
        public static Dictionary<int, DeclareActivityYunying> CacheData
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
                        if (HanderDefine.DataCallBack("ActivityYunying", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareActivityYunying cfg = null;
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
        private unsafe static DeclareActivityYunying LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareActivityYunying();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._logic_id = (int)GetValue(keyIndex, _logic_id_Index, ptr);
            tmp._festival_id = (int)GetValue(keyIndex, _festival_id_Index, ptr);
            tmp._use_ui_id = (int)GetValue(keyIndex, _use_ui_id_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ActivityYunying", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("LogicId", out _logic_id_Index)) _logic_id_Index = -1;
                    if (!nameIndexs.TryGetValue("FestivalId", out _festival_id_Index)) _festival_id_Index = -1;
                    if (!nameIndexs.TryGetValue("UseUiId", out _use_ui_id_Index)) _use_ui_id_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareActivityYunying>(keyCount);
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
            if(HanderDefine.DataCallBack("ActivityYunying", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareActivityYunying cfg = null;
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
        public static DeclareActivityYunying Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareActivityYunying result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ActivityYunying", out _compressData))
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
