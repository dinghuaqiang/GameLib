//文件是自动生成,请勿手动修改.来自数据文件:SoulArmor_breach
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareSoulArmorBreach
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _quality_Index = -1;
        private static int _name_Index = -1;
        private static int _effect_Index = -1;
        private static int _model_Index = -1;
        private static int _icon_Index = -1;
        private static int _consume_Index = -1;
        private static int _qualityValue_Index = -1;
        private static int _extraValue_Index = -1;
        private static int _mainTransfom_Index = -1;
        private static int _notice_Index = -1;
        private static int _chatchannel_Index = -1;
        #endregion
        #region //私有变量定义
        //流水id
        private int _id;
        //魂甲品质
        private int _quality;
        //魂甲名称
        private int _name;
        //装备光效编号hide
        private int _effect;
        //外观id
        private int _model;
        //物品icon编号hide
        private int _icon;
        //升品消耗  道具id_数量;道具id_数量;道具id_数量;（需要集齐一起使用）
        private int _consume;
        //属性
        private int _qualityValue;
        //专属属性
        private int _extraValue;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        private int _mainTransfom;
        //激活时的公告频道(10跑马灯)
        private int _notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Quality { get{ return _quality; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Effect { get{ return _effect; }}
        public int Model { get{ return _model; }}
        public int Icon { get{ return _icon; }}
        public string Consume { get{ return HanderDefine.SetStingCallBack(_consume); }}
        public string QualityValue { get{ return HanderDefine.SetStingCallBack(_qualityValue); }}
        public string ExtraValue { get{ return HanderDefine.SetStingCallBack(_extraValue); }}
        public string MainTransfom { get{ return HanderDefine.SetStingCallBack(_mainTransfom); }}
        public int Notice { get{ return _notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareSoulArmorBreach cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareSoulArmorBreach> _dataCaches = null;
        public static Dictionary<int, DeclareSoulArmorBreach> CacheData
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
                        if (HanderDefine.DataCallBack("SoulArmorBreach", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareSoulArmorBreach cfg = null;
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
        private unsafe static DeclareSoulArmorBreach LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareSoulArmorBreach();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._effect = (int)GetValue(keyIndex, _effect_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._consume = (int)GetValue(keyIndex, _consume_Index, ptr);
            tmp._qualityValue = (int)GetValue(keyIndex, _qualityValue_Index, ptr);
            tmp._extraValue = (int)GetValue(keyIndex, _extraValue_Index, ptr);
            tmp._mainTransfom = (int)GetValue(keyIndex, _mainTransfom_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("SoulArmorBreach", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Effect", out _effect_Index)) _effect_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Consume", out _consume_Index)) _consume_Index = -1;
                    if (!nameIndexs.TryGetValue("QualityValue", out _qualityValue_Index)) _qualityValue_Index = -1;
                    if (!nameIndexs.TryGetValue("ExtraValue", out _extraValue_Index)) _extraValue_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTransfom", out _mainTransfom_Index)) _mainTransfom_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareSoulArmorBreach>(keyCount);
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
            if(HanderDefine.DataCallBack("SoulArmorBreach", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareSoulArmorBreach cfg = null;
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
        public static DeclareSoulArmorBreach Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareSoulArmorBreach result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("SoulArmorBreach", out _compressData))
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
