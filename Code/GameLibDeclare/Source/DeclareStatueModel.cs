//文件是自动生成,请勿手动修改.来自数据文件:statue_model
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareStatueModel
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _npcid_Index = -1;
        private static int _size_scale_Index = -1;
        private static int _x_Index = -1;
        private static int _y_Index = -1;
        private static int _mapid_Index = -1;
        private static int _dirX_Index = -1;
        private static int _dirY_Index = -1;
        private static int _model_1_Index = -1;
        private static int _model_2_Index = -1;
        private static int _model_3_Index = -1;
        private static int _model_4_Index = -1;
        private static int _model_5_Index = -1;
        private static int _model_6_Index = -1;
        #endregion
        #region //私有变量定义
        //Statue编号
        private int _id;
        //类型（1为首席雕像、2为公会雕像、3为圣天城雕像）
        private int _type;
        //默认显示NPC
        private int _npcid;
        //模型缩放（百分比）
        private int _size_scale;
        //坐标x
        private int _x;
        //坐标y
        private int _y;
        //地图ID
        private int _mapid;
        //方向
        private int _dirX;
        //方向
        private int _dirY;
        //执笔之灵
        private int _model_1;
        //龙魂圣拳
        private int _model_2;
        //圣临战锤
        private int _model_3;
        //疾风剑客
        private int _model_4;
        //卡牌大师
        private int _model_5;
        //皇家枪手
        private int _model_6;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Npcid { get{ return _npcid; }}
        public int SizeScale { get{ return _size_scale; }}
        public int X { get{ return _x; }}
        public int Y { get{ return _y; }}
        public int Mapid { get{ return _mapid; }}
        public int DirX { get{ return _dirX; }}
        public int DirY { get{ return _dirY; }}
        public int Model1 { get{ return _model_1; }}
        public int Model2 { get{ return _model_2; }}
        public int Model3 { get{ return _model_3; }}
        public int Model4 { get{ return _model_4; }}
        public int Model5 { get{ return _model_5; }}
        public int Model6 { get{ return _model_6; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareStatueModel cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareStatueModel> _dataCaches = null;
        public static Dictionary<int, DeclareStatueModel> CacheData
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
                        if (HanderDefine.DataCallBack("StatueModel", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareStatueModel cfg = null;
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
        private unsafe static DeclareStatueModel LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareStatueModel();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._npcid = (int)GetValue(keyIndex, _npcid_Index, ptr);
            tmp._size_scale = (int)GetValue(keyIndex, _size_scale_Index, ptr);
            tmp._x = (int)GetValue(keyIndex, _x_Index, ptr);
            tmp._y = (int)GetValue(keyIndex, _y_Index, ptr);
            tmp._mapid = (int)GetValue(keyIndex, _mapid_Index, ptr);
            tmp._dirX = (int)GetValue(keyIndex, _dirX_Index, ptr);
            tmp._dirY = (int)GetValue(keyIndex, _dirY_Index, ptr);
            tmp._model_1 = (int)GetValue(keyIndex, _model_1_Index, ptr);
            tmp._model_2 = (int)GetValue(keyIndex, _model_2_Index, ptr);
            tmp._model_3 = (int)GetValue(keyIndex, _model_3_Index, ptr);
            tmp._model_4 = (int)GetValue(keyIndex, _model_4_Index, ptr);
            tmp._model_5 = (int)GetValue(keyIndex, _model_5_Index, ptr);
            tmp._model_6 = (int)GetValue(keyIndex, _model_6_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("StatueModel", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Npcid", out _npcid_Index)) _npcid_Index = -1;
                    if (!nameIndexs.TryGetValue("SizeScale", out _size_scale_Index)) _size_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("X", out _x_Index)) _x_Index = -1;
                    if (!nameIndexs.TryGetValue("Y", out _y_Index)) _y_Index = -1;
                    if (!nameIndexs.TryGetValue("Mapid", out _mapid_Index)) _mapid_Index = -1;
                    if (!nameIndexs.TryGetValue("DirX", out _dirX_Index)) _dirX_Index = -1;
                    if (!nameIndexs.TryGetValue("DirY", out _dirY_Index)) _dirY_Index = -1;
                    if (!nameIndexs.TryGetValue("Model1", out _model_1_Index)) _model_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Model2", out _model_2_Index)) _model_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Model3", out _model_3_Index)) _model_3_Index = -1;
                    if (!nameIndexs.TryGetValue("Model4", out _model_4_Index)) _model_4_Index = -1;
                    if (!nameIndexs.TryGetValue("Model5", out _model_5_Index)) _model_5_Index = -1;
                    if (!nameIndexs.TryGetValue("Model6", out _model_6_Index)) _model_6_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareStatueModel>(keyCount);
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
            if(HanderDefine.DataCallBack("StatueModel", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareStatueModel cfg = null;
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
        public static DeclareStatueModel Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareStatueModel result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("StatueModel", out _compressData))
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
