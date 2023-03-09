//文件是自动生成,请勿手动修改.来自数据文件:RechargeAward
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareRechargeAward
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _awardType_Index = -1;
        private static int _needRecharge_Index = -1;
        private static int _occ_0_Index = -1;
        private static int _occ_1_Index = -1;
        private static int _occ_2_Index = -1;
        private static int _occ_3_Index = -1;
        private static int _rewardDes_Index = -1;
        private static int _mainModel_Index = -1;
        private static int _mainModelWeapon_Index = -1;
        private static int _model_Index = -1;
        private static int _equipAward_Index = -1;
        private static int _itemAward_Index = -1;
        private static int _showBigItem_Index = -1;
        private static int _showItem_Index = -1;
        private static int _showEffect_Index = -1;
        private static int _radio_Index = -1;
        private static int _chatchannel_Index = -1;
        private static int _fightPower_Index = -1;
        #endregion
        #region //私有变量定义
        //首充奖励表
        private int _id;
        //奖励类型
        //(0首充奖励；
        //1续充奖励;
        //2高档位首充)
        private int _awardType;
        //需要充值数量（单位，灵玉）
        private int _needRecharge;
        //玄剑职业首充Tips武器配置
        //类型_modelcfgId
        //类型详情见批注
        private int _occ_0;
        //天英职业首充Tips武器配置
        //类型_modelcfgId
        //类型详情见批注
        private int _occ_1;
        //地藏职业首充Tips武器配置
        //类型_modelcfgId
        //类型详情见批注
        private int _occ_2;
        //罗刹职业首充Tips武器配置
        //类型_modelcfgId
        //类型详情见批注
        private int _occ_3;
        //奖励物品名称_描述
        private int _rewardDes;
        //主模型展示（界面中心位置）
        //modelID_occ_power_sca_rotX_rotY_rotZ_posX_posY
        //modelID：对应ModelConfig的主键
        //occ：0男1女9通用
        //power：对应显示的战斗力
        //sca:模型大小倍数
        //rotX：对应的旋转参数
        //posX：对应的位置参数
        //（hide)
        private int _mainModel;
        //主模型佩戴在手里的武器模型ID
        //modelID_occ
        //（hide）
        private int _mainModelWeapon;
        //副模型展示
        //modelID_occ_power_sca_rotX_rotY_rotZ_posX_posY
        //modelID：对应ModelConfig的主键
        //occ：0男1女9通用
        //power：对应显示的战斗力
        //sca:模型大小倍数
        //rotX：对应的旋转参数
        //（hide)
        private int _model;
        //奖励区分职业，图标也是显示出来（ID_数量_是否绑定（0否1是）_职业），没有不填(@;@_@)
        private int _equipAward;
        //物品奖励ID_数量_是否绑定（0否1是）(@;@_@)
        private int _itemAward;
        //客户端纯显示用，服务器不会发放(为了解决个别物品只显示，实际不发放的问题）
        //物品奖励ID_数量_是否绑定（0否1是)_职业_页签标题显示（对应MessageString6010，6011，6012）
        //itemid_num_bind_occ
        //bind:0未绑定1绑定
        //occ：0男1女9通用
        //（hide）
        private int _showBigItem;
        //客户端纯显示用，服务器不会发放(为了解决个别物品只显示，实际不发放的问题）
        //物品奖励ID_数量_是否绑定（0否1是)_职业
        //itemid_num_bind_occ
        //bind:0未绑定1绑定
        //occ：0男1女9通用
        //（hide）
        private int _showItem;
        //选定特定的格子展示转圈特效（策划只配置格子编号，编号从1开始递增即可）
        //(hide)
        private int _showEffect;
        //公告类型（10跑马灯）
        private int _radio;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        //战斗力，没有就不填hide
        private int _fightPower;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int AwardType { get{ return _awardType; }}
        public int NeedRecharge { get{ return _needRecharge; }}
        public string Occ0 { get{ return HanderDefine.SetStingCallBack(_occ_0); }}
        public string Occ1 { get{ return HanderDefine.SetStingCallBack(_occ_1); }}
        public string Occ2 { get{ return HanderDefine.SetStingCallBack(_occ_2); }}
        public string Occ3 { get{ return HanderDefine.SetStingCallBack(_occ_3); }}
        public string RewardDes { get{ return HanderDefine.SetStingCallBack(_rewardDes); }}
        public string MainModel { get{ return HanderDefine.SetStingCallBack(_mainModel); }}
        public string MainModelWeapon { get{ return HanderDefine.SetStingCallBack(_mainModelWeapon); }}
        public string Model { get{ return HanderDefine.SetStingCallBack(_model); }}
        public string EquipAward { get{ return HanderDefine.SetStingCallBack(_equipAward); }}
        public string ItemAward { get{ return HanderDefine.SetStingCallBack(_itemAward); }}
        public string ShowBigItem { get{ return HanderDefine.SetStingCallBack(_showBigItem); }}
        public string ShowItem { get{ return HanderDefine.SetStingCallBack(_showItem); }}
        public string ShowEffect { get{ return HanderDefine.SetStingCallBack(_showEffect); }}
        public int Radio { get{ return _radio; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        public int FightPower { get{ return _fightPower; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareRechargeAward cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareRechargeAward> _dataCaches = null;
        public static Dictionary<int, DeclareRechargeAward> CacheData
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
                        if (HanderDefine.DataCallBack("RechargeAward", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareRechargeAward cfg = null;
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
        private unsafe static DeclareRechargeAward LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareRechargeAward();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._awardType = (int)GetValue(keyIndex, _awardType_Index, ptr);
            tmp._needRecharge = (int)GetValue(keyIndex, _needRecharge_Index, ptr);
            tmp._occ_0 = (int)GetValue(keyIndex, _occ_0_Index, ptr);
            tmp._occ_1 = (int)GetValue(keyIndex, _occ_1_Index, ptr);
            tmp._occ_2 = (int)GetValue(keyIndex, _occ_2_Index, ptr);
            tmp._occ_3 = (int)GetValue(keyIndex, _occ_3_Index, ptr);
            tmp._rewardDes = (int)GetValue(keyIndex, _rewardDes_Index, ptr);
            tmp._mainModel = (int)GetValue(keyIndex, _mainModel_Index, ptr);
            tmp._mainModelWeapon = (int)GetValue(keyIndex, _mainModelWeapon_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._equipAward = (int)GetValue(keyIndex, _equipAward_Index, ptr);
            tmp._itemAward = (int)GetValue(keyIndex, _itemAward_Index, ptr);
            tmp._showBigItem = (int)GetValue(keyIndex, _showBigItem_Index, ptr);
            tmp._showItem = (int)GetValue(keyIndex, _showItem_Index, ptr);
            tmp._showEffect = (int)GetValue(keyIndex, _showEffect_Index, ptr);
            tmp._radio = (int)GetValue(keyIndex, _radio_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            tmp._fightPower = (int)GetValue(keyIndex, _fightPower_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("RechargeAward", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("AwardType", out _awardType_Index)) _awardType_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedRecharge", out _needRecharge_Index)) _needRecharge_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ0", out _occ_0_Index)) _occ_0_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ1", out _occ_1_Index)) _occ_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ2", out _occ_2_Index)) _occ_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Occ3", out _occ_3_Index)) _occ_3_Index = -1;
                    if (!nameIndexs.TryGetValue("RewardDes", out _rewardDes_Index)) _rewardDes_Index = -1;
                    if (!nameIndexs.TryGetValue("MainModel", out _mainModel_Index)) _mainModel_Index = -1;
                    if (!nameIndexs.TryGetValue("MainModelWeapon", out _mainModelWeapon_Index)) _mainModelWeapon_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipAward", out _equipAward_Index)) _equipAward_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemAward", out _itemAward_Index)) _itemAward_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowBigItem", out _showBigItem_Index)) _showBigItem_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowItem", out _showItem_Index)) _showItem_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowEffect", out _showEffect_Index)) _showEffect_Index = -1;
                    if (!nameIndexs.TryGetValue("Radio", out _radio_Index)) _radio_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
                    if (!nameIndexs.TryGetValue("FightPower", out _fightPower_Index)) _fightPower_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareRechargeAward>(keyCount);
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
            if(HanderDefine.DataCallBack("RechargeAward", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareRechargeAward cfg = null;
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
        public static DeclareRechargeAward Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareRechargeAward result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("RechargeAward", out _compressData))
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
