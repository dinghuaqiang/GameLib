//文件是自动生成,请勿手动修改.来自数据文件:new_sever_growuprew
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNewSeverGrowuprew
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _scroe_Index = -1;
        private static int _item_Index = -1;
        private static int _lock_pic_Index = -1;
        private static int _open_pic_Index = -1;
        private static int _showWord_Index = -1;
        private static int _showTexture_Index = -1;
        private static int _isModel_Index = -1;
        #endregion
        #region //私有变量定义
        //key用于标识
        private int _id;
        //表示积分数量
        private int _scroe;
        //奖励
        //item_num_bind_occ
        //bind:0未绑定，1绑定
        //occ：0男1女9通用
        private int _item;
        //展示的宝箱图片item图集下面(hide)
        private int _lock_pic;
        //展示的宝箱图片(hide)
        private int _open_pic;
        //显示特殊标识（在wordAtlas）
        //（hide）
        private int _showWord;
        //在界面左上角显示的美术字
        //（hide）
        private int _showTexture;
        //是否是模型（0否，1是）
        //只用于最后一个奖励的模型显示，其余奖励不能使用，游戏中第二个奖励使用的模型为程序代码特殊处理
        //（hide）
        private int _isModel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Scroe { get{ return _scroe; }}
        public string Item { get{ return HanderDefine.SetStingCallBack(_item); }}
        public int LockPic { get{ return _lock_pic; }}
        public int OpenPic { get{ return _open_pic; }}
        public string ShowWord { get{ return HanderDefine.SetStingCallBack(_showWord); }}
        public string ShowTexture { get{ return HanderDefine.SetStingCallBack(_showTexture); }}
        public int IsModel { get{ return _isModel; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNewSeverGrowuprew cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNewSeverGrowuprew> _dataCaches = null;
        public static Dictionary<int, DeclareNewSeverGrowuprew> CacheData
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
                        if (HanderDefine.DataCallBack("NewSeverGrowuprew", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNewSeverGrowuprew cfg = null;
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
        private unsafe static DeclareNewSeverGrowuprew LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNewSeverGrowuprew();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._scroe = (int)GetValue(keyIndex, _scroe_Index, ptr);
            tmp._item = (int)GetValue(keyIndex, _item_Index, ptr);
            tmp._lock_pic = (int)GetValue(keyIndex, _lock_pic_Index, ptr);
            tmp._open_pic = (int)GetValue(keyIndex, _open_pic_Index, ptr);
            tmp._showWord = (int)GetValue(keyIndex, _showWord_Index, ptr);
            tmp._showTexture = (int)GetValue(keyIndex, _showTexture_Index, ptr);
            tmp._isModel = (int)GetValue(keyIndex, _isModel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("NewSeverGrowuprew", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Scroe", out _scroe_Index)) _scroe_Index = -1;
                    if (!nameIndexs.TryGetValue("Item", out _item_Index)) _item_Index = -1;
                    if (!nameIndexs.TryGetValue("LockPic", out _lock_pic_Index)) _lock_pic_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenPic", out _open_pic_Index)) _open_pic_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowWord", out _showWord_Index)) _showWord_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowTexture", out _showTexture_Index)) _showTexture_Index = -1;
                    if (!nameIndexs.TryGetValue("IsModel", out _isModel_Index)) _isModel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNewSeverGrowuprew>(keyCount);
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
            if(HanderDefine.DataCallBack("NewSeverGrowuprew", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNewSeverGrowuprew cfg = null;
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
        public static DeclareNewSeverGrowuprew Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNewSeverGrowuprew result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("NewSeverGrowuprew", out _compressData))
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
