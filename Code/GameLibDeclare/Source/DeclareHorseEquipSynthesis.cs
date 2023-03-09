//文件是自动生成,请勿手动修改.来自数据文件:Horse_equip_synthesis
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareHorseEquipSynthesis
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _equip_ID_Index = -1;
        private static int _synthesis_level_Index = -1;
        private static int _join_part_Index = -1;
        private static int _professional_Index = -1;
        private static int _quality_Index = -1;
        private static int _quality_Number_Index = -1;
        private static int _join_num_probability_Index = -1;
        private static int _diamond_Index = -1;
        private static int _diamond_Number_Index = -1;
        private static int _join_item_Index = -1;
        private static int _item_Price_Index = -1;
        private static int _join_EquipID1_Index = -1;
        private static int _join_num1_Index = -1;
        private static int _join_EquipID2_Index = -1;
        private static int _join_num2_Index = -1;
        private static int _failure_type_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //身上穿的装备ID
        private int _id;
        //合成目标装备ID
        private int _equip_ID;
        //参与合成等级
        private int _synthesis_level;
        //放入装备的部位限制，不填表示不限制
        private int _join_part;
        //材料装备需求的职业id
        private int _professional;
        //材料装备放入品质(1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩)
        private int _quality;
        //品质的概率翻倍系数
        private int _quality_Number;
        //材料装备的概率（同阶装备基础概率_比本阶装备高的装备基础概率_低一阶装备基础概率_低两阶装备以下基础概率）
        private int _join_num_probability;
        //可以放入的星级的多少
        private int _diamond;
        //星级对应的概率翻倍系数
        private int _diamond_Number;
        //材料装备是否能放入道具（数量:1以后为必放材料,道具ID_数量）(@_@)
        private int _join_item;
        //单个道具的货币id_数量(填写后道具不足时会自动扣除对应数量的货币,假如不填写就不会自动扣除)消耗元宝提升成功率，宠物装备不用
        private int _item_Price;
        //特殊装备材料1所有装备ID(1~99阶)(@_@)
        private int _join_EquipID1;
        //材料1放入数量(最小_最大)(@_@)
        private int _join_num1;
        //特殊装备材料2所有装备ID(1~99阶)(@_@)
        private int _join_EquipID2;
        //材料2放入数量(最小_最大)(@_@)
        private int _join_num2;
        //身上装备失败不扣除,其他失败后返还的道具id和数量
        private int _failure_type;
        //公告类型（10跑马灯）
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int EquipID { get{ return _equip_ID; }}
        public int SynthesisLevel { get{ return _synthesis_level; }}
        public string JoinPart { get{ return HanderDefine.SetStingCallBack(_join_part); }}
        public int Professional { get{ return _professional; }}
        public string Quality { get{ return HanderDefine.SetStingCallBack(_quality); }}
        public string QualityNumber { get{ return HanderDefine.SetStingCallBack(_quality_Number); }}
        public string JoinNumProbability { get{ return HanderDefine.SetStingCallBack(_join_num_probability); }}
        public string Diamond { get{ return HanderDefine.SetStingCallBack(_diamond); }}
        public string DiamondNumber { get{ return HanderDefine.SetStingCallBack(_diamond_Number); }}
        public string JoinItem { get{ return HanderDefine.SetStingCallBack(_join_item); }}
        public string ItemPrice { get{ return HanderDefine.SetStingCallBack(_item_Price); }}
        public string JoinEquipID1 { get{ return HanderDefine.SetStingCallBack(_join_EquipID1); }}
        public string JoinNum1 { get{ return HanderDefine.SetStingCallBack(_join_num1); }}
        public string JoinEquipID2 { get{ return HanderDefine.SetStingCallBack(_join_EquipID2); }}
        public string JoinNum2 { get{ return HanderDefine.SetStingCallBack(_join_num2); }}
        public string FailureType { get{ return HanderDefine.SetStingCallBack(_failure_type); }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareHorseEquipSynthesis cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareHorseEquipSynthesis> _dataCaches = null;
        public static Dictionary<int, DeclareHorseEquipSynthesis> CacheData
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
                        if (HanderDefine.DataCallBack("HorseEquipSynthesis", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareHorseEquipSynthesis cfg = null;
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
        private unsafe static DeclareHorseEquipSynthesis LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareHorseEquipSynthesis();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._equip_ID = (int)GetValue(keyIndex, _equip_ID_Index, ptr);
            tmp._synthesis_level = (int)GetValue(keyIndex, _synthesis_level_Index, ptr);
            tmp._join_part = (int)GetValue(keyIndex, _join_part_Index, ptr);
            tmp._professional = (int)GetValue(keyIndex, _professional_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._quality_Number = (int)GetValue(keyIndex, _quality_Number_Index, ptr);
            tmp._join_num_probability = (int)GetValue(keyIndex, _join_num_probability_Index, ptr);
            tmp._diamond = (int)GetValue(keyIndex, _diamond_Index, ptr);
            tmp._diamond_Number = (int)GetValue(keyIndex, _diamond_Number_Index, ptr);
            tmp._join_item = (int)GetValue(keyIndex, _join_item_Index, ptr);
            tmp._item_Price = (int)GetValue(keyIndex, _item_Price_Index, ptr);
            tmp._join_EquipID1 = (int)GetValue(keyIndex, _join_EquipID1_Index, ptr);
            tmp._join_num1 = (int)GetValue(keyIndex, _join_num1_Index, ptr);
            tmp._join_EquipID2 = (int)GetValue(keyIndex, _join_EquipID2_Index, ptr);
            tmp._join_num2 = (int)GetValue(keyIndex, _join_num2_Index, ptr);
            tmp._failure_type = (int)GetValue(keyIndex, _failure_type_Index, ptr);
            tmp._notice = (int)GetValue(keyIndex, _notice_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("HorseEquipSynthesis", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipID", out _equip_ID_Index)) _equip_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("SynthesisLevel", out _synthesis_level_Index)) _synthesis_level_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinPart", out _join_part_Index)) _join_part_Index = -1;
                    if (!nameIndexs.TryGetValue("Professional", out _professional_Index)) _professional_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("QualityNumber", out _quality_Number_Index)) _quality_Number_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinNumProbability", out _join_num_probability_Index)) _join_num_probability_Index = -1;
                    if (!nameIndexs.TryGetValue("Diamond", out _diamond_Index)) _diamond_Index = -1;
                    if (!nameIndexs.TryGetValue("DiamondNumber", out _diamond_Number_Index)) _diamond_Number_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinItem", out _join_item_Index)) _join_item_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemPrice", out _item_Price_Index)) _item_Price_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinEquipID1", out _join_EquipID1_Index)) _join_EquipID1_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinNum1", out _join_num1_Index)) _join_num1_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinEquipID2", out _join_EquipID2_Index)) _join_EquipID2_Index = -1;
                    if (!nameIndexs.TryGetValue("JoinNum2", out _join_num2_Index)) _join_num2_Index = -1;
                    if (!nameIndexs.TryGetValue("FailureType", out _failure_type_Index)) _failure_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Notice", out _notice_Index)) _notice_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareHorseEquipSynthesis>(keyCount);
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
            if(HanderDefine.DataCallBack("HorseEquipSynthesis", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareHorseEquipSynthesis cfg = null;
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
        public static DeclareHorseEquipSynthesis Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareHorseEquipSynthesis result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("HorseEquipSynthesis", out _compressData))
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
