//文件是自动生成,请勿手动修改.来自数据文件:marry_show
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMarryShow
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _marryDesc_Index = -1;
        private static int _swornDesc_Index = -1;
        private static int _marryTex_Index = -1;
        private static int _swornTex_Index = -1;
        private static int _reward_Index = -1;
        private static int _openFunction_Index = -1;
        #endregion
        #region //私有变量定义
        //编号
        private int _id;
        //0：总任务
        //1：拥有一个异性好友
        //2：和任意异性亲密度达到520以上
        //3：发送或接收到金玉良缘或以上的求婚
        //4：成功缔结一次仙缘
        //5：成功预约一场婚礼
        //6：成功举办一场婚礼
        private int _type;
        //界面文字显示描述
        //（hide）
        private int _marryDesc;
        //界面文字显示描述
        //（hide）
        private int _swornDesc;
        //图片资源
        //（hide）
        private int _marryTex;
        //图片资源
        //（hide）
        private int _swornTex;
        //奖励
        private int _reward;
        //对应跳转到的功能界面
        //（hide）
        private int _openFunction;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public string MarryDesc { get{ return HanderDefine.SetStingCallBack(_marryDesc); }}
        public string SwornDesc { get{ return HanderDefine.SetStingCallBack(_swornDesc); }}
        public string MarryTex { get{ return HanderDefine.SetStingCallBack(_marryTex); }}
        public string SwornTex { get{ return HanderDefine.SetStingCallBack(_swornTex); }}
        public string Reward { get{ return HanderDefine.SetStingCallBack(_reward); }}
        public int OpenFunction { get{ return _openFunction; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMarryShow cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMarryShow> _dataCaches = null;
        public static Dictionary<int, DeclareMarryShow> CacheData
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
                        if (HanderDefine.DataCallBack("MarryShow", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMarryShow cfg = null;
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
        private unsafe static DeclareMarryShow LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMarryShow();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._marryDesc = (int)GetValue(keyIndex, _marryDesc_Index, ptr);
            tmp._swornDesc = (int)GetValue(keyIndex, _swornDesc_Index, ptr);
            tmp._marryTex = (int)GetValue(keyIndex, _marryTex_Index, ptr);
            tmp._swornTex = (int)GetValue(keyIndex, _swornTex_Index, ptr);
            tmp._reward = (int)GetValue(keyIndex, _reward_Index, ptr);
            tmp._openFunction = (int)GetValue(keyIndex, _openFunction_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("MarryShow", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("MarryDesc", out _marryDesc_Index)) _marryDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("SwornDesc", out _swornDesc_Index)) _swornDesc_Index = -1;
                    if (!nameIndexs.TryGetValue("MarryTex", out _marryTex_Index)) _marryTex_Index = -1;
                    if (!nameIndexs.TryGetValue("SwornTex", out _swornTex_Index)) _swornTex_Index = -1;
                    if (!nameIndexs.TryGetValue("Reward", out _reward_Index)) _reward_Index = -1;
                    if (!nameIndexs.TryGetValue("OpenFunction", out _openFunction_Index)) _openFunction_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMarryShow>(keyCount);
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
            if(HanderDefine.DataCallBack("MarryShow", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMarryShow cfg = null;
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
        public static DeclareMarryShow Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMarryShow result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("MarryShow", out _compressData))
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
