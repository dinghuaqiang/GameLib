//文件是自动生成,请勿手动修改.来自数据文件:boss_FirstBlood
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareBossFirstBlood
    {
        #region //静态变量定义
        private static int _iD_Index = -1;
        private static int _monster_id_Index = -1;
        private static int _boss_type_Index = -1;
        private static int _first_blood_cash_Index = -1;
        private static int _first_blood_reward_Index = -1;
        private static int _personal_reward_Index = -1;
        private static int _function_ID_Index = -1;
        private static int _size_Index = -1;
        private static int _model_rotat_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _show_clone_name_Index = -1;
        #endregion
        #region //私有变量定义
        //编号ID
        private int _iD;
        //怪物ID
        private int _monster_id;
        //boss的类型（1，无极墟域；2晶甲和域；3神兽岛；4VIP首领）
        private int _boss_type;
        //首杀的红包奖励（货币ID_数量）
        private int _first_blood_cash;
        //首杀奖励（职业ID_奖励_数量_绑定)
        private int _first_blood_reward;
        //个人奖励（职业ID_奖励_数量_绑定)
        private int _personal_reward;
        //功能ID hide
        private int _function_ID;
        //模型缩放hide
        private int _size;
        //模型旋转hide
        private int _model_rotat;
        //模型位置的Y轴坐标hide
        private int _model_y_pos;
        //刷新位置的展示hide
        private int _show_clone_name;
        #endregion

        #region //公共属性
        public int ID { get{ return _iD; }}
        public int MonsterId { get{ return _monster_id; }}
        public int BossType { get{ return _boss_type; }}
        public string FirstBloodCash { get{ return HanderDefine.SetStingCallBack(_first_blood_cash); }}
        public string FirstBloodReward { get{ return HanderDefine.SetStingCallBack(_first_blood_reward); }}
        public string PersonalReward { get{ return HanderDefine.SetStingCallBack(_personal_reward); }}
        public int FunctionID { get{ return _function_ID; }}
        public int Size { get{ return _size; }}
        public int ModelRotat { get{ return _model_rotat; }}
        public int ModelYPos { get{ return _model_y_pos; }}
        public string ShowCloneName { get{ return HanderDefine.SetStingCallBack(_show_clone_name); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareBossFirstBlood cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareBossFirstBlood> _dataCaches = null;
        public static Dictionary<int, DeclareBossFirstBlood> CacheData
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
                        if (HanderDefine.DataCallBack("BossFirstBlood", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareBossFirstBlood cfg = null;
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
        private unsafe static DeclareBossFirstBlood LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareBossFirstBlood();
            tmp._iD = (int)GetValue(keyIndex, _iD_Index, ptr);
            tmp._monster_id = (int)GetValue(keyIndex, _monster_id_Index, ptr);
            tmp._boss_type = (int)GetValue(keyIndex, _boss_type_Index, ptr);
            tmp._first_blood_cash = (int)GetValue(keyIndex, _first_blood_cash_Index, ptr);
            tmp._first_blood_reward = (int)GetValue(keyIndex, _first_blood_reward_Index, ptr);
            tmp._personal_reward = (int)GetValue(keyIndex, _personal_reward_Index, ptr);
            tmp._function_ID = (int)GetValue(keyIndex, _function_ID_Index, ptr);
            tmp._size = (int)GetValue(keyIndex, _size_Index, ptr);
            tmp._model_rotat = (int)GetValue(keyIndex, _model_rotat_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._show_clone_name = (int)GetValue(keyIndex, _show_clone_name_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("BossFirstBlood", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("ID", out _iD_Index)) _iD_Index = -1;
                    if (!nameIndexs.TryGetValue("MonsterId", out _monster_id_Index)) _monster_id_Index = -1;
                    if (!nameIndexs.TryGetValue("BossType", out _boss_type_Index)) _boss_type_Index = -1;
                    if (!nameIndexs.TryGetValue("FirstBloodCash", out _first_blood_cash_Index)) _first_blood_cash_Index = -1;
                    if (!nameIndexs.TryGetValue("FirstBloodReward", out _first_blood_reward_Index)) _first_blood_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("PersonalReward", out _personal_reward_Index)) _personal_reward_Index = -1;
                    if (!nameIndexs.TryGetValue("FunctionID", out _function_ID_Index)) _function_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("Size", out _size_Index)) _size_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRotat", out _model_rotat_Index)) _model_rotat_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowCloneName", out _show_clone_name_Index)) _show_clone_name_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareBossFirstBlood>(keyCount);
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
            if(HanderDefine.DataCallBack("BossFirstBlood", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareBossFirstBlood cfg = null;
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
        public static DeclareBossFirstBlood Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareBossFirstBlood result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("BossFirstBlood", out _compressData))
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
