//文件是自动生成,请勿手动修改.来自数据文件:SoulBeastsEquip
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSoulBeastsEquip
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _diamond_Number_Index = -1;
        private static int _quality_Index = -1;
        private static int _part_Index = -1;
        private static int _bind_Index = -1;
        private static int _attribute1_Index = -1;
        private static int _seal_num_Index = -1;
        private static int _confirm_Index = -1;
        private static int _recommended_tips_Index = -1;
        private static int _if_ban_Index = -1;
        private static int _target_equip_Index = -1;
        private static int _demand_item_Index = -1;
        private static int _bigsuccess_Index = -1;
        private static int _bigsuccess_target_equip_Index = -1;
        private static int _seal_exp_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //装备id,(id构成：部位，职业，品质，等级）（3000000+品质*1000+钻石*100+部位）
        private int _id;
        //1表示1个钻石，2表示2个钻石，0表示没有钻石，钻石显示为左上角
        private int _diamond_Number;
        //物品天生颜色（1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩）
        private int _quality;
        //装备部位(1头盔、2项圈、3铠甲、4利爪、5羽翼)
        private int _part;
        //绑定类型(0：不绑定;1：获得时绑定;2：使用后绑定)
        private int _bind;
        //初始属性：属性类型_数值，属性类型1_数值，(@;@_@)
        private int _attribute1;
        //出售给予的货币(@_@)
        private int _seal_num;
        //回收时是弹出确认提示（0：不弹出;1：弹出）
        private int _confirm;
        //推荐极品属性显示
        private int _recommended_tips;
        //能否进行合成（0，可以，1不行）
        private int _if_ban;
        //目标装备ID
        private int _target_equip;
        //需求道具（道具ID_数量）(@_@)
        private int _demand_item;
        //合成大成功的概率（万分比）
        private int _bigsuccess;
        //目标装备ID
        private int _bigsuccess_target_equip;
        //强化提供经验
        private int _seal_exp;
        //激活时的公告频道(10跑马灯)
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int DiamondNumber { get{ return _diamond_Number; }}
        public int Quality { get{ return _quality; }}
        public int Part { get{ return _part; }}
        public int Bind { get{ return _bind; }}
        public string Attribute1 { get{ return HanderDefine.SetStingCallBack(_attribute1); }}
        public string SealNum { get{ return HanderDefine.SetStingCallBack(_seal_num); }}
        public int Confirm { get{ return _confirm; }}
        public string RecommendedTips { get{ return HanderDefine.SetStingCallBack(_recommended_tips); }}
        public int IfBan { get{ return _if_ban; }}
        public string TargetEquip { get{ return HanderDefine.SetStingCallBack(_target_equip); }}
        public string DemandItem { get{ return HanderDefine.SetStingCallBack(_demand_item); }}
        public int Bigsuccess { get{ return _bigsuccess; }}
        public string BigsuccessTargetEquip { get{ return HanderDefine.SetStingCallBack(_bigsuccess_target_equip); }}
        public int SealExp { get{ return _seal_exp; }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSoulBeastsEquip cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSoulBeastsEquip> _dataCaches = null;
        public static Dictionary<int, DeclareSoulBeastsEquip> CacheData
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
                        if (HanderDefine.DataCallBack("SoulBeastsEquip", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSoulBeastsEquip cfg = null;
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
        private unsafe static DeclareSoulBeastsEquip LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSoulBeastsEquip();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._diamond_Number = (int)GetValue(keyIndex, _diamond_Number_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._part = (int)GetValue(keyIndex, _part_Index, ptr);
            tmp._bind = (int)GetValue(keyIndex, _bind_Index, ptr);
            tmp._attribute1 = (int)GetValue(keyIndex, _attribute1_Index, ptr);
            tmp._seal_num = (int)GetValue(keyIndex, _seal_num_Index, ptr);
            tmp._confirm = (int)GetValue(keyIndex, _confirm_Index, ptr);
            tmp._recommended_tips = (int)GetValue(keyIndex, _recommended_tips_Index, ptr);
            tmp._if_ban = (int)GetValue(keyIndex, _if_ban_Index, ptr);
            tmp._target_equip = (int)GetValue(keyIndex, _target_equip_Index, ptr);
            tmp._demand_item = (int)GetValue(keyIndex, _demand_item_Index, ptr);
            tmp._bigsuccess = (int)GetValue(keyIndex, _bigsuccess_Index, ptr);
            tmp._bigsuccess_target_equip = (int)GetValue(keyIndex, _bigsuccess_target_equip_Index, ptr);
            tmp._seal_exp = (int)GetValue(keyIndex, _seal_exp_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("SoulBeastsEquip", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("DiamondNumber", out _diamond_Number_Index)) _diamond_Number_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Part", out _part_Index)) _part_Index = -1;
                    if (!nameIndexs.TryGetValue("Bind", out _bind_Index)) _bind_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute1", out _attribute1_Index)) _attribute1_Index = -1;
                    if (!nameIndexs.TryGetValue("SealNum", out _seal_num_Index)) _seal_num_Index = -1;
                    if (!nameIndexs.TryGetValue("Confirm", out _confirm_Index)) _confirm_Index = -1;
                    if (!nameIndexs.TryGetValue("RecommendedTips", out _recommended_tips_Index)) _recommended_tips_Index = -1;
                    if (!nameIndexs.TryGetValue("IfBan", out _if_ban_Index)) _if_ban_Index = -1;
                    if (!nameIndexs.TryGetValue("TargetEquip", out _target_equip_Index)) _target_equip_Index = -1;
                    if (!nameIndexs.TryGetValue("DemandItem", out _demand_item_Index)) _demand_item_Index = -1;
                    if (!nameIndexs.TryGetValue("Bigsuccess", out _bigsuccess_Index)) _bigsuccess_Index = -1;
                    if (!nameIndexs.TryGetValue("BigsuccessTargetEquip", out _bigsuccess_target_equip_Index)) _bigsuccess_target_equip_Index = -1;
                    if (!nameIndexs.TryGetValue("SealExp", out _seal_exp_Index)) _seal_exp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSoulBeastsEquip>(keyCount);
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
            if(HanderDefine.DataCallBack("SoulBeastsEquip", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSoulBeastsEquip cfg = null;
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
        public static DeclareSoulBeastsEquip Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSoulBeastsEquip result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SoulBeastsEquip", out _compressData))
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
