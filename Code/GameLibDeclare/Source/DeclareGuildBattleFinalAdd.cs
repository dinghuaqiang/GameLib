//文件是自动生成,请勿手动修改.来自数据文件:guild_battle_final_add
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildBattleFinalAdd
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _num_Index = -1;
        private static int _addons_Index = -1;
        private static int _des_Index = -1;
        private static int _score_Index = -1;
        private static int _buff_Index = -1;
        private static int _special_tex_Index = -1;
        private static int _special_add_num_Index = -1;
        #endregion
        #region //私有变量定义
        //ID
        private int _id;
        //加成类型（0，连胜；1，连败）
        private int _type;
        //连胜连败次数
        private int _num;
        //外部显示的加成百分比
        private int _addons;
        //点开显示的加成内容
        private int _des;
        //额外积分
        private int _score;
        //增加BUFFID
        private int _buff;
        //调用的特殊连胜资源编号
        private int _special_tex;
        //增加连胜次数调用
        private int _special_add_num;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Num { get{ return _num; }}
        public string Addons { get{ return HanderDefine.SetStingCallBack(_addons); }}
        public string Des { get{ return HanderDefine.SetStingCallBack(_des); }}
        public int Score { get{ return _score; }}
        public int Buff { get{ return _buff; }}
        public int SpecialTex { get{ return _special_tex; }}
        public int SpecialAddNum { get{ return _special_add_num; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildBattleFinalAdd cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildBattleFinalAdd> _dataCaches = null;
        public static Dictionary<int, DeclareGuildBattleFinalAdd> CacheData
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
                        if (HanderDefine.DataCallBack("GuildBattleFinalAdd", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildBattleFinalAdd cfg = null;
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
        private unsafe static DeclareGuildBattleFinalAdd LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildBattleFinalAdd();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._num = (int)GetValue(keyIndex, _num_Index, ptr);
            tmp._addons = (int)GetValue(keyIndex, _addons_Index, ptr);
            tmp._des = (int)GetValue(keyIndex, _des_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._buff = (int)GetValue(keyIndex, _buff_Index, ptr);
            tmp._special_tex = (int)GetValue(keyIndex, _special_tex_Index, ptr);
            tmp._special_add_num = (int)GetValue(keyIndex, _special_add_num_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildBattleFinalAdd", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Num", out _num_Index)) _num_Index = -1;
                    if (!nameIndexs.TryGetValue("Addons", out _addons_Index)) _addons_Index = -1;
                    if (!nameIndexs.TryGetValue("Des", out _des_Index)) _des_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("Buff", out _buff_Index)) _buff_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialTex", out _special_tex_Index)) _special_tex_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialAddNum", out _special_add_num_Index)) _special_add_num_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildBattleFinalAdd>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildBattleFinalAdd", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildBattleFinalAdd cfg = null;
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
        public static DeclareGuildBattleFinalAdd Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildBattleFinalAdd result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildBattleFinalAdd", out _compressData))
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
