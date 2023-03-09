//文件是自动生成,请勿手动修改.来自数据文件:item
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareItem
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _icon_Index = -1;
        private static int _fly_to_bag_type_Index = -1;
        private static int _effect_Index = -1;
        private static int _type_Index = -1;
        private static int _trade_type_Index = -1;
        private static int _trade_recom_Index = -1;
        private static int _button_type_Index = -1;
        private static int _color_Index = -1;
        private static int _level_Index = -1;
        private static int _max_level_Index = -1;
        private static int _sex_Index = -1;
        private static int _occupation_Index = -1;
        private static int _bind_Index = -1;
        private static int _max_Index = -1;
        private static int _description_Index = -1;
        private static int _if_confirm_Index = -1;
        private static int _effect_num_Index = -1;
        private static int _ues_UI_id_Index = -1;
        private static int _ues_gift_Index = -1;
        private static int _gift_Index = -1;
        private static int _get_text_Index = -1;
        private static int _if_use_info_Index = -1;
        private static int _drop_item_num_Index = -1;
        private static int _show_type_Index = -1;
        private static int _show_id_Index = -1;
        private static int _size_scale_Index = -1;
        private static int _item_Price_Index = -1;
        private static int _needTaskCheck_Index = -1;
        private static int _needwingCheck_Index = -1;
        private static int _hechen_target_Index = -1;
        private static int _hechen_money_Index = -1;
        private static int _drop_notice_Index = -1;
        private static int _chatchannel_Index = -1;
        private static int _auction_price_type_Index = -1;
        private static int _auction_use_coin_Index = -1;
        private static int _auction_min_price_Index = -1;
        private static int _auction_max_price_Index = -1;
        private static int _auction_single_type_Index = -1;
        private static int _auction_single_price_Index = -1;
        private static int _auction_countdown_Index = -1;
        private static int _auction_all_time_Index = -1;
        private static int _auction_guild_all_time_Index = -1;
        private static int _dead_time_Index = -1;
        private static int _auction_text_Index = -1;
        #endregion
        #region //私有变量定义
        //物品ID
        private int _id;
        //物品显示名字
        private int _name;
        //物品icon编号hide
        private int _icon;
        //进背包的表现类型（0，没有表现，1普通物品，2重要物品）（hide)
        private int _fly_to_bag_type;
        //装备光效编号
        //4。流光红
        //5.流光粉
        //6.流光暗金
        //7流光幻彩
        //hide
        private int _effect;
        //物品类型(1：货币；2：装备；3：效果道具； 4：材料；5：宝石；6：礼包；7：碎片；8：礼物；9：普通物品；10：特殊物品；11.称号；12，神兽装备；13神兽水晶；14，圣装；15，多选一宝箱 16 转职道具;17 转职洗髓普通道具18VIP经验19仙甲20婚姻礼炮21灵魄 22=仙甲 23=宠物装备 24=魂印 25=坐骑脉纹 26=魔魂装备 27=魔魂碎片 28=幻装 29=幻装碎片 30=家具物品)
        private int _type;
        //用于交易行小类型的分类，对应AuctionMenu表中
        private int _trade_type;
        //交易中默认的推荐价格，不填表示不能交易
        private int _trade_recom;
        //按钮类型（1，穿戴；2，使用；3，批量使用；4，获取途径；5，出售；6，摆摊；7，合成；8，赠送）(@_@)
        private int _button_type;
        //物品天生颜色（1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩）
        private int _color;
        //物品使用等级
        private int _level;
        //物品最高使用等级
        private int _max_level;
        //玩家使用性别限制（0：女；1：男；2：通用）
        private int _sex;
        //玩家使用职业限制（0：齐王府；1：六扇门；2：待定职业1；3：待定职业2；9：通用）
        private int _occupation;
        //绑定类型（0：默认；1：获得时绑定）
        private int _bind;
        //最大叠加数（1：不可叠加，其他自然数：该物品最大叠加数量；除货币之外的最大值为9999）
        private Int64 _max;
        //物品常规描述hide
        private int _description;
        //出售二次确定提示(0：不弹出；1：弹出)
        private int _if_confirm;
        //效果配置[@;@_@]（1：增加属性【1_属性枚举_数值】；2：增加挂机时间【秒】；3：增加经验倍率【万分比_时间】；4_增加数值；5_增加称号和称号的时间；6_增加个人BOSS的刷新时间（秒）；8_挚友古道热肠类型；9_增加活跃度上限_数量；10_等级上限_万分比经验；11_dailyID_增加的次数；12vip经验增加点数；13货币增加"13_货币type_num"；14：激活对应的时装，对应时装表的ID）15:复活道具（1，世界BOSS，5年兽BOSS，7晶甲BOSS）16：召唤道具（1，世界BOSS，5年兽BOSS，7晶甲BOSS）17激活充值（对应rechargeitem的主键ID） 18 播放特效  19VIP宝珠特权(0限时宝珠_时间秒，1永久宝珠_货币类型_货币数量）20诸界远征积分宝箱,21获得家具_家具ID
        private int _effect_num;
        //物品使用时打开的UI_idhide
        private int _ues_UI_id;
        //使用礼包调用的掉落
        private int _ues_gift;
        //宝箱的ID
        private int _gift;
        //获取途径 功能ID_功能参数_功能名字;功能ID_功能参数_功能名字（hide）【0_1_文字，代表只显示配置的途径，不需要打开】
        private int _get_text;
        //获得时是否有获得提示（0，没有；1以上，堆叠达到的使用条件）
        private int _if_use_info;
        //掉落出来的堆叠的物品数量（hide）
        private int _drop_item_num;
        //物品预览类型（0，没有预览；1，有show动作的模型，填modelID；2.没有show动作的模型，填modelID；3.加人物模型；4.称号特效；5.称号图片）
        private int _show_type;
        //展示的内容（时装，坐骑，宠物用模型ID，称号用名字）modelID_缩放大小_Y轴偏移_Y轴旋转_X轴旋转_Z轴旋转_x轴偏移_z轴偏移
        private int _show_id;
        //模型缩放（百分比）
        private int _size_scale;
        //物品的蓝钻价值
        private int _item_Price;
        //是否任务检查（0否1是）
        private int _needTaskCheck;
        //是否翅膀检查（0否1是）
        private int _needwingCheck;
        //合成目标（目标物品ID_消耗自身数量）(@_@)
        private int _hechen_target;
        //合成额外消耗（物品ID_数量）(@_@)
        private int _hechen_money;
        //掉落物品后是否公告
        private int _drop_notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        //拍卖价格类型，0配置价格，1自定义价格（最低价格2，最大价格使用auction_max_price字段）
        private int _auction_price_type;
        //拍卖使用的货币类型
        private int _auction_use_coin;
        //拍卖最小价格
        private int _auction_min_price;
        //拍卖最大价格
        //此数值大于0才能上架,否则不能上架,填写0或空都为0,-1为只能竞拍不能一口价
        private int _auction_max_price;
        //单次加价的类类型，0为数值价格，1为万分比数值
        private int _auction_single_type;
        //拍卖单次增加，增加类型为0时表示具体价格，为1的时候表示当前价格万分比,没有增加价格表示只能一口价
        private int _auction_single_price;
        //是否开拍倒计时(0不倒计时,1上架后倒计时)
        private int _auction_countdown;
        //世界拍卖总时间，单位秒
        private int _auction_all_time;
        //仙盟拍卖总时间，单位秒
        private int _auction_guild_all_time;
        //失效时间（从创造开始计时，到时就失效，单位：秒）
        private int _dead_time;
        //拍卖行关注中材料的产出途径描述配置（hide）
        private int _auction_text;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Icon { get{ return _icon; }}
        public int FlyToBagType { get{ return _fly_to_bag_type; }}
        public int Effect { get{ return _effect; }}
        public int Type { get{ return _type; }}
        public int TradeType { get{ return _trade_type; }}
        public int TradeRecom { get{ return _trade_recom; }}
        public string ButtonType { get{ return HanderDefine.SetStingCallBack(_button_type); }}
        public int Color { get{ return _color; }}
        public int Level { get{ return _level; }}
        public int MaxLevel { get{ return _max_level; }}
        public int Sex { get{ return _sex; }}
        public string Occupation { get{ return HanderDefine.SetStingCallBack(_occupation); }}
        public int Bind { get{ return _bind; }}
        public Int64 Max { get{ return _max; }}
        public string Description { get{ return HanderDefine.SetStingCallBack(_description); }}
        public int IfConfirm { get{ return _if_confirm; }}
        public string EffectNum { get{ return HanderDefine.SetStingCallBack(_effect_num); }}
        public string UesUIId { get{ return HanderDefine.SetStingCallBack(_ues_UI_id); }}
        public int UesGift { get{ return _ues_gift; }}
        public int Gift { get{ return _gift; }}
        public string GetText { get{ return HanderDefine.SetStingCallBack(_get_text); }}
        public int IfUseInfo { get{ return _if_use_info; }}
        public int DropItemNum { get{ return _drop_item_num; }}
        public int ShowType { get{ return _show_type; }}
        public string ShowId { get{ return HanderDefine.SetStingCallBack(_show_id); }}
        public int SizeScale { get{ return _size_scale; }}
        public int ItemPrice { get{ return _item_Price; }}
        public int NeedTaskCheck { get{ return _needTaskCheck; }}
        public int NeedwingCheck { get{ return _needwingCheck; }}
        public string HechenTarget { get{ return HanderDefine.SetStingCallBack(_hechen_target); }}
        public string HechenMoney { get{ return HanderDefine.SetStingCallBack(_hechen_money); }}
        public int DropNotice { get{ return _drop_notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        public int AuctionPriceType { get{ return _auction_price_type; }}
        public int AuctionUseCoin { get{ return _auction_use_coin; }}
        public int AuctionMinPrice { get{ return _auction_min_price; }}
        public int AuctionMaxPrice { get{ return _auction_max_price; }}
        public int AuctionSingleType { get{ return _auction_single_type; }}
        public int AuctionSinglePrice { get{ return _auction_single_price; }}
        public int AuctionCountdown { get{ return _auction_countdown; }}
        public int AuctionAllTime { get{ return _auction_all_time; }}
        public int AuctionGuildAllTime { get{ return _auction_guild_all_time; }}
        public int DeadTime { get{ return _dead_time; }}
        public string AuctionText { get{ return HanderDefine.SetStingCallBack(_auction_text); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareItem cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareItem> _dataCaches = null;
        public static Dictionary<int, DeclareItem> CacheData
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
                        if (HanderDefine.DataCallBack("Item", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareItem cfg = null;
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
        private unsafe static DeclareItem LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareItem();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._fly_to_bag_type = (int)GetValue(keyIndex, _fly_to_bag_type_Index, ptr);
            tmp._effect = (int)GetValue(keyIndex, _effect_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._trade_type = (int)GetValue(keyIndex, _trade_type_Index, ptr);
            tmp._trade_recom = (int)GetValue(keyIndex, _trade_recom_Index, ptr);
            tmp._button_type = (int)GetValue(keyIndex, _button_type_Index, ptr);
            tmp._color = (int)GetValue(keyIndex, _color_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._max_level = (int)GetValue(keyIndex, _max_level_Index, ptr);
            tmp._sex = (int)GetValue(keyIndex, _sex_Index, ptr);
            tmp._occupation = (int)GetValue(keyIndex, _occupation_Index, ptr);
            tmp._bind = (int)GetValue(keyIndex, _bind_Index, ptr);
            tmp._max = GetValue(keyIndex, _max_Index, ptr);
            tmp._description = (int)GetValue(keyIndex, _description_Index, ptr);
            tmp._if_confirm = (int)GetValue(keyIndex, _if_confirm_Index, ptr);
            tmp._effect_num = (int)GetValue(keyIndex, _effect_num_Index, ptr);
            tmp._ues_UI_id = (int)GetValue(keyIndex, _ues_UI_id_Index, ptr);
            tmp._ues_gift = (int)GetValue(keyIndex, _ues_gift_Index, ptr);
            tmp._gift = (int)GetValue(keyIndex, _gift_Index, ptr);
            tmp._get_text = (int)GetValue(keyIndex, _get_text_Index, ptr);
            tmp._if_use_info = (int)GetValue(keyIndex, _if_use_info_Index, ptr);
            tmp._drop_item_num = (int)GetValue(keyIndex, _drop_item_num_Index, ptr);
            tmp._show_type = (int)GetValue(keyIndex, _show_type_Index, ptr);
            tmp._show_id = (int)GetValue(keyIndex, _show_id_Index, ptr);
            tmp._size_scale = (int)GetValue(keyIndex, _size_scale_Index, ptr);
            tmp._item_Price = (int)GetValue(keyIndex, _item_Price_Index, ptr);
            tmp._needTaskCheck = (int)GetValue(keyIndex, _needTaskCheck_Index, ptr);
            tmp._needwingCheck = (int)GetValue(keyIndex, _needwingCheck_Index, ptr);
            tmp._hechen_target = (int)GetValue(keyIndex, _hechen_target_Index, ptr);
            tmp._hechen_money = (int)GetValue(keyIndex, _hechen_money_Index, ptr);
            tmp._drop_notice = (int)GetValue(keyIndex, _drop_notice_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            tmp._auction_price_type = (int)GetValue(keyIndex, _auction_price_type_Index, ptr);
            tmp._auction_use_coin = (int)GetValue(keyIndex, _auction_use_coin_Index, ptr);
            tmp._auction_min_price = (int)GetValue(keyIndex, _auction_min_price_Index, ptr);
            tmp._auction_max_price = (int)GetValue(keyIndex, _auction_max_price_Index, ptr);
            tmp._auction_single_type = (int)GetValue(keyIndex, _auction_single_type_Index, ptr);
            tmp._auction_single_price = (int)GetValue(keyIndex, _auction_single_price_Index, ptr);
            tmp._auction_countdown = (int)GetValue(keyIndex, _auction_countdown_Index, ptr);
            tmp._auction_all_time = (int)GetValue(keyIndex, _auction_all_time_Index, ptr);
            tmp._auction_guild_all_time = (int)GetValue(keyIndex, _auction_guild_all_time_Index, ptr);
            tmp._dead_time = (int)GetValue(keyIndex, _dead_time_Index, ptr);
            tmp._auction_text = (int)GetValue(keyIndex, _auction_text_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Item", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("FlyToBagType", out _fly_to_bag_type_Index)) _fly_to_bag_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Effect", out _effect_Index)) _effect_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("TradeType", out _trade_type_Index)) _trade_type_Index = -1;
                    if (!nameIndexs.TryGetValue("TradeRecom", out _trade_recom_Index)) _trade_recom_Index = -1;
                    if (!nameIndexs.TryGetValue("ButtonType", out _button_type_Index)) _button_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Color", out _color_Index)) _color_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxLevel", out _max_level_Index)) _max_level_Index = -1;
                    if (!nameIndexs.TryGetValue("Sex", out _sex_Index)) _sex_Index = -1;
                    if (!nameIndexs.TryGetValue("Occupation", out _occupation_Index)) _occupation_Index = -1;
                    if (!nameIndexs.TryGetValue("Bind", out _bind_Index)) _bind_Index = -1;
                    if (!nameIndexs.TryGetValue("Max", out _max_Index)) _max_Index = -1;
                    if (!nameIndexs.TryGetValue("Description", out _description_Index)) _description_Index = -1;
                    if (!nameIndexs.TryGetValue("IfConfirm", out _if_confirm_Index)) _if_confirm_Index = -1;
                    if (!nameIndexs.TryGetValue("EffectNum", out _effect_num_Index)) _effect_num_Index = -1;
                    if (!nameIndexs.TryGetValue("UesUIId", out _ues_UI_id_Index)) _ues_UI_id_Index = -1;
                    if (!nameIndexs.TryGetValue("UesGift", out _ues_gift_Index)) _ues_gift_Index = -1;
                    if (!nameIndexs.TryGetValue("Gift", out _gift_Index)) _gift_Index = -1;
                    if (!nameIndexs.TryGetValue("GetText", out _get_text_Index)) _get_text_Index = -1;
                    if (!nameIndexs.TryGetValue("IfUseInfo", out _if_use_info_Index)) _if_use_info_Index = -1;
                    if (!nameIndexs.TryGetValue("DropItemNum", out _drop_item_num_Index)) _drop_item_num_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowType", out _show_type_Index)) _show_type_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowId", out _show_id_Index)) _show_id_Index = -1;
                    if (!nameIndexs.TryGetValue("SizeScale", out _size_scale_Index)) _size_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemPrice", out _item_Price_Index)) _item_Price_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedTaskCheck", out _needTaskCheck_Index)) _needTaskCheck_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedwingCheck", out _needwingCheck_Index)) _needwingCheck_Index = -1;
                    if (!nameIndexs.TryGetValue("HechenTarget", out _hechen_target_Index)) _hechen_target_Index = -1;
                    if (!nameIndexs.TryGetValue("HechenMoney", out _hechen_money_Index)) _hechen_money_Index = -1;
                    if (!nameIndexs.TryGetValue("DropNotice", out _drop_notice_Index)) _drop_notice_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionPriceType", out _auction_price_type_Index)) _auction_price_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionUseCoin", out _auction_use_coin_Index)) _auction_use_coin_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionMinPrice", out _auction_min_price_Index)) _auction_min_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionMaxPrice", out _auction_max_price_Index)) _auction_max_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionSingleType", out _auction_single_type_Index)) _auction_single_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionSinglePrice", out _auction_single_price_Index)) _auction_single_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionCountdown", out _auction_countdown_Index)) _auction_countdown_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionAllTime", out _auction_all_time_Index)) _auction_all_time_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionGuildAllTime", out _auction_guild_all_time_Index)) _auction_guild_all_time_Index = -1;
                    if (!nameIndexs.TryGetValue("DeadTime", out _dead_time_Index)) _dead_time_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionText", out _auction_text_Index)) _auction_text_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareItem>(keyCount);
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
            if(HanderDefine.DataCallBack("Item", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareItem cfg = null;
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
        public static DeclareItem Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareItem result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Item", out _compressData))
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
