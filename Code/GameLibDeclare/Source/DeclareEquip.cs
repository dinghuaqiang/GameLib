//文件是自动生成,请勿手动修改.来自数据文件:Equip
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareEquip
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _describe_Index = -1;
        private static int _icon_Index = -1;
        private static int _effect_Index = -1;
        private static int _part_Index = -1;
        private static int _level_Index = -1;
        private static int _gender_Index = -1;
        private static int _diamond_Number_Index = -1;
        private static int _grade_Index = -1;
        private static int _classlevel_Index = -1;
        private static int _bind_Index = -1;
        private static int _quality_Index = -1;
        private static int _score_Index = -1;
        private static int _attribute1_Index = -1;
        private static int _attribute2_Index = -1;
        private static int _attribute3_Index = -1;
        private static int _price_Index = -1;
        private static int _price1_Index = -1;
        private static int _seal_exp_Index = -1;
        private static int _confirm_Index = -1;
        private static int _drop_model_Index = -1;
        private static int _model_id_Index = -1;
        private static int _isCheck_Index = -1;
        private static int _warehouse_integral_Index = -1;
        private static int _equip_Dismantling_Index = -1;
        private static int _if_common_Index = -1;
        private static int _level_max_Index = -1;
        private static int _recommended_tips_Index = -1;
        private static int _statelevel_Index = -1;
        private static int _trade_recom_Index = -1;
        private static int _drop_notice_Index = -1;
        private static int _chatchannel_Index = -1;
        private static int _seal_anima_Index = -1;
        private static int _fly_to_bag_type_Index = -1;
        private static int _auction_price_type_Index = -1;
        private static int _auction_use_coin_Index = -1;
        private static int _auction_min_price_Index = -1;
        private static int _auction_max_price_Index = -1;
        private static int _auction_single_type_Index = -1;
        private static int _auction_single_price_Index = -1;
        private static int _auction_countdown_Index = -1;
        private static int _auction_all_time_Index = -1;
        private static int _auction_guild_all_time_Index = -1;
        private static int _synthetic_materials_Index = -1;
        private static int _dead_time_Index = -1;
        private static int _get_text_Index = -1;
        private static int _holySuitType_Index = -1;
        private static int _magic_bowl_solve_Index = -1;
        private static int _auction_text_Index = -1;
        #endregion
        #region //私有变量定义
        //装备id,(id构成：部位，职业，品质，等级）
        private int _id;
        //装备名字
        private int _name;
        //装备描述hide
        private int _describe;
        //装备icon编号hide
        private int _icon;
        //装备光效编号hide
        private int _effect;
        //装备部位(0头盔.1武器.2胸甲.3项链.4腰带.5腿甲.6鞋子.7戒指.8手镯.9耳环.10灵章，11-21圣装，30仙甲武器，31仙甲战甲，32仙甲光环，33仙甲阵道，34仙甲左佩，35仙甲右佩，36仙甲头冠，37仙甲肩饰，38仙甲护腕，39仙甲手套，40仙甲内衬，41仙甲腰带，42仙甲裤子，43仙甲鞋履，44-57第二套仙甲，58-71第三套仙甲，72-85第四套仙甲。）；圣装【新】101-133；201 爪套，202 项圈，203 铃铛，204 福袋；211金之印,212木之印,213土之印,214水之印,215火之印,216雷之印,217太阴之印,218太阳之印,219太白之印,220混元之印；301 面纹，302 心纹，303 环纹，304 足纹，305-330魔魂装备（305-308阵营1，309-312阵营2，313-316阵营3，317-320阵营4，321-324阵营5，325-340为预留）401仙甲1阳，402仙甲1阴，403仙甲1八卦1，404仙甲1八卦2，405仙甲1八卦3，406仙甲1八卦4，407仙甲1八卦5，408仙甲1八卦6，409仙甲1八卦7，410仙甲1八卦8，411-440仙甲阴阳八卦,441幻装头盔，442幻装耳环，443幻装项链，444幻装衣服，445幻装裤子，446幻装武器，447幻装护腕，448幻装鞋子，449幻装戒指，450幻装手镯
        private int _part;
        //装备等级需求
        private int _level;
        //职业限制
        //0-男剑
        //1-女枪
        //2-待定
        //3-待定
        //4-待定
        //5-待定
        //9-通用
        private int _gender;
        //1表示1个钻石，2表示2个钻石，0表示没有钻石，钻石显示为左上角
        private int _diamond_Number;
        //品阶：1表示1阶，2表示2阶
        private int _grade;
        //填写转职id
        private int _classlevel;
        //绑定类型(0：不绑定;1：获得时绑定;2：使用后绑定)
        private int _bind;
        //装备品质(：1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩)
        private int _quality;
        //装备评分
        private int _score;
        //初始属性：属性类型_数值，属性类型1_数值，(@;@_@)
        private int _attribute1;
        //特殊附加属性：属性类型_数值，属性类型1_数值，(@;@_@)
        private int _attribute2;
        //特殊附加属性：属性类型_数值，属性类型1_数值，(@;@_@)
        private int _attribute3;
        //回收价格（回收获得的金币数量）货币id_数量(@;@_@)
        private int _price;
        //回收成物品（回收获得的物品及数量）物品id_数量(@;@_@)
        private int _price1;
        //封印吞噬经验
        private int _seal_exp;
        //出售时是否弹出确认提示（0：不弹出;1：弹出）
        private int _confirm;
        //掉落模型ID
        private int _drop_model;
        //显示模型id
        private int _model_id;
        //是否显示查看（1是;0否）(废弃)
        private int _isCheck;
        //仓库积分
        private int _warehouse_integral;
        //是否可以被拆解（0为不可被拆解，1为可以被拆解）
        private int _equip_Dismantling;
        //是否是普通装备
        private int _if_common;
        //装备强化上限
        private int _level_max;
        //洗练属性模板:属性类型_下限_上限;(@;@_@)
        private int _recommended_tips;
        //填写境界的等级
        private int _statelevel;
        //交易中默认的推荐价格，不填表示不能交易,4阶红3星以上可交易
        private int _trade_recom;
        //掉落出来是否公告,0不公告,1是公告
        private int _drop_notice;
        //掉落物品后聊天发送(0世界4系统14传闻）
        private int _chatchannel;
        //熔炉获得的灵晶数量
        private int _seal_anima;
        //进背包的表现类型（0，没有表现，1普通物品，2重要物品）（hide)
        private int _fly_to_bag_type;
        //拍卖价格类型，0配置价格，1自定义价格（最低价格2，最大价格使用auction_max_price字段）
        private int _auction_price_type;
        //拍卖使用的货币类型
        private int _auction_use_coin;
        //拍卖最小价格
        private int _auction_min_price;
        //此数值大于0才能上架,否则不能上架,填写0或空都为0,填写-1的时候不显示一口价,只可竞拍
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
        //融炼的时候剔除可合成的装备避免误操作,1:可合成的,客户端专用hide
        private int _synthetic_materials;
        //失效时间（从创造开始计时，到时就失效，单位：秒）
        private int _dead_time;
        //获取途径 功能ID_功能参数_功能名字;功能ID_功能参数_功能名字（hide）
        private int _get_text;
        //圣装专用（其他类型的装备不能使用）
        //1-2：对应圣装第一套的套装
        //3-4：对应圣装第二套的套装
        //5-6：对应圣装第三套的套装
        //（如需要扩展，需要程序代码支持）
        private int _holySuitType;
        //熔炼装备后对应加的聚宝盆银元宝奖励
        private int _magic_bowl_solve;
        //拍卖行关注中材料的产出途径描述配置（hide）
        private int _auction_text;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Describe { get{ return HanderDefine.SetStingCallBack(_describe); }}
        public int Icon { get{ return _icon; }}
        public int Effect { get{ return _effect; }}
        public int Part { get{ return _part; }}
        public int Level { get{ return _level; }}
        public string Gender { get{ return HanderDefine.SetStingCallBack(_gender); }}
        public int DiamondNumber { get{ return _diamond_Number; }}
        public int Grade { get{ return _grade; }}
        public int Classlevel { get{ return _classlevel; }}
        public int Bind { get{ return _bind; }}
        public int Quality { get{ return _quality; }}
        public int Score { get{ return _score; }}
        public string Attribute1 { get{ return HanderDefine.SetStingCallBack(_attribute1); }}
        public string Attribute2 { get{ return HanderDefine.SetStingCallBack(_attribute2); }}
        public string Attribute3 { get{ return HanderDefine.SetStingCallBack(_attribute3); }}
        public string Price { get{ return HanderDefine.SetStingCallBack(_price); }}
        public string Price1 { get{ return HanderDefine.SetStingCallBack(_price1); }}
        public int SealExp { get{ return _seal_exp; }}
        public int Confirm { get{ return _confirm; }}
        public int DropModel { get{ return _drop_model; }}
        public int ModelId { get{ return _model_id; }}
        public int IsCheck { get{ return _isCheck; }}
        public int WarehouseIntegral { get{ return _warehouse_integral; }}
        public int EquipDismantling { get{ return _equip_Dismantling; }}
        public int IfCommon { get{ return _if_common; }}
        public int LevelMax { get{ return _level_max; }}
        public string RecommendedTips { get{ return HanderDefine.SetStingCallBack(_recommended_tips); }}
        public int Statelevel { get{ return _statelevel; }}
        public int TradeRecom { get{ return _trade_recom; }}
        public int DropNotice { get{ return _drop_notice; }}
        public string Chatchannel { get{ return HanderDefine.SetStingCallBack(_chatchannel); }}
        public int SealAnima { get{ return _seal_anima; }}
        public int FlyToBagType { get{ return _fly_to_bag_type; }}
        public int AuctionPriceType { get{ return _auction_price_type; }}
        public int AuctionUseCoin { get{ return _auction_use_coin; }}
        public int AuctionMinPrice { get{ return _auction_min_price; }}
        public int AuctionMaxPrice { get{ return _auction_max_price; }}
        public int AuctionSingleType { get{ return _auction_single_type; }}
        public int AuctionSinglePrice { get{ return _auction_single_price; }}
        public int AuctionCountdown { get{ return _auction_countdown; }}
        public int AuctionAllTime { get{ return _auction_all_time; }}
        public int AuctionGuildAllTime { get{ return _auction_guild_all_time; }}
        public int SyntheticMaterials { get{ return _synthetic_materials; }}
        public int DeadTime { get{ return _dead_time; }}
        public string GetText { get{ return HanderDefine.SetStingCallBack(_get_text); }}
        public int HolySuitType { get{ return _holySuitType; }}
        public int MagicBowlSolve { get{ return _magic_bowl_solve; }}
        public string AuctionText { get{ return HanderDefine.SetStingCallBack(_auction_text); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareEquip cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareEquip> _dataCaches = null;
        public static Dictionary<int, DeclareEquip> CacheData
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
                        if (HanderDefine.DataCallBack("Equip", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareEquip cfg = null;
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
        private unsafe static DeclareEquip LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareEquip();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._effect = (int)GetValue(keyIndex, _effect_Index, ptr);
            tmp._part = (int)GetValue(keyIndex, _part_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._gender = (int)GetValue(keyIndex, _gender_Index, ptr);
            tmp._diamond_Number = (int)GetValue(keyIndex, _diamond_Number_Index, ptr);
            tmp._grade = (int)GetValue(keyIndex, _grade_Index, ptr);
            tmp._classlevel = (int)GetValue(keyIndex, _classlevel_Index, ptr);
            tmp._bind = (int)GetValue(keyIndex, _bind_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._score = (int)GetValue(keyIndex, _score_Index, ptr);
            tmp._attribute1 = (int)GetValue(keyIndex, _attribute1_Index, ptr);
            tmp._attribute2 = (int)GetValue(keyIndex, _attribute2_Index, ptr);
            tmp._attribute3 = (int)GetValue(keyIndex, _attribute3_Index, ptr);
            tmp._price = (int)GetValue(keyIndex, _price_Index, ptr);
            tmp._price1 = (int)GetValue(keyIndex, _price1_Index, ptr);
            tmp._seal_exp = (int)GetValue(keyIndex, _seal_exp_Index, ptr);
            tmp._confirm = (int)GetValue(keyIndex, _confirm_Index, ptr);
            tmp._drop_model = (int)GetValue(keyIndex, _drop_model_Index, ptr);
            tmp._model_id = (int)GetValue(keyIndex, _model_id_Index, ptr);
            tmp._isCheck = (int)GetValue(keyIndex, _isCheck_Index, ptr);
            tmp._warehouse_integral = (int)GetValue(keyIndex, _warehouse_integral_Index, ptr);
            tmp._equip_Dismantling = (int)GetValue(keyIndex, _equip_Dismantling_Index, ptr);
            tmp._if_common = (int)GetValue(keyIndex, _if_common_Index, ptr);
            tmp._level_max = (int)GetValue(keyIndex, _level_max_Index, ptr);
            tmp._recommended_tips = (int)GetValue(keyIndex, _recommended_tips_Index, ptr);
            tmp._statelevel = (int)GetValue(keyIndex, _statelevel_Index, ptr);
            tmp._trade_recom = (int)GetValue(keyIndex, _trade_recom_Index, ptr);
            tmp._drop_notice = (int)GetValue(keyIndex, _drop_notice_Index, ptr);
            tmp._chatchannel = (int)GetValue(keyIndex, _chatchannel_Index, ptr);
            tmp._seal_anima = (int)GetValue(keyIndex, _seal_anima_Index, ptr);
            tmp._fly_to_bag_type = (int)GetValue(keyIndex, _fly_to_bag_type_Index, ptr);
            tmp._auction_price_type = (int)GetValue(keyIndex, _auction_price_type_Index, ptr);
            tmp._auction_use_coin = (int)GetValue(keyIndex, _auction_use_coin_Index, ptr);
            tmp._auction_min_price = (int)GetValue(keyIndex, _auction_min_price_Index, ptr);
            tmp._auction_max_price = (int)GetValue(keyIndex, _auction_max_price_Index, ptr);
            tmp._auction_single_type = (int)GetValue(keyIndex, _auction_single_type_Index, ptr);
            tmp._auction_single_price = (int)GetValue(keyIndex, _auction_single_price_Index, ptr);
            tmp._auction_countdown = (int)GetValue(keyIndex, _auction_countdown_Index, ptr);
            tmp._auction_all_time = (int)GetValue(keyIndex, _auction_all_time_Index, ptr);
            tmp._auction_guild_all_time = (int)GetValue(keyIndex, _auction_guild_all_time_Index, ptr);
            tmp._synthetic_materials = (int)GetValue(keyIndex, _synthetic_materials_Index, ptr);
            tmp._dead_time = (int)GetValue(keyIndex, _dead_time_Index, ptr);
            tmp._get_text = (int)GetValue(keyIndex, _get_text_Index, ptr);
            tmp._holySuitType = (int)GetValue(keyIndex, _holySuitType_Index, ptr);
            tmp._magic_bowl_solve = (int)GetValue(keyIndex, _magic_bowl_solve_Index, ptr);
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
                var _isExist = HanderDefine.BaseDataCallBack("Equip", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Effect", out _effect_Index)) _effect_Index = -1;
                    if (!nameIndexs.TryGetValue("Part", out _part_Index)) _part_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Gender", out _gender_Index)) _gender_Index = -1;
                    if (!nameIndexs.TryGetValue("DiamondNumber", out _diamond_Number_Index)) _diamond_Number_Index = -1;
                    if (!nameIndexs.TryGetValue("Grade", out _grade_Index)) _grade_Index = -1;
                    if (!nameIndexs.TryGetValue("Classlevel", out _classlevel_Index)) _classlevel_Index = -1;
                    if (!nameIndexs.TryGetValue("Bind", out _bind_Index)) _bind_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Score", out _score_Index)) _score_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute1", out _attribute1_Index)) _attribute1_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute2", out _attribute2_Index)) _attribute2_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute3", out _attribute3_Index)) _attribute3_Index = -1;
                    if (!nameIndexs.TryGetValue("Price", out _price_Index)) _price_Index = -1;
                    if (!nameIndexs.TryGetValue("Price1", out _price1_Index)) _price1_Index = -1;
                    if (!nameIndexs.TryGetValue("SealExp", out _seal_exp_Index)) _seal_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("Confirm", out _confirm_Index)) _confirm_Index = -1;
                    if (!nameIndexs.TryGetValue("DropModel", out _drop_model_Index)) _drop_model_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelId", out _model_id_Index)) _model_id_Index = -1;
                    if (!nameIndexs.TryGetValue("IsCheck", out _isCheck_Index)) _isCheck_Index = -1;
                    if (!nameIndexs.TryGetValue("WarehouseIntegral", out _warehouse_integral_Index)) _warehouse_integral_Index = -1;
                    if (!nameIndexs.TryGetValue("EquipDismantling", out _equip_Dismantling_Index)) _equip_Dismantling_Index = -1;
                    if (!nameIndexs.TryGetValue("IfCommon", out _if_common_Index)) _if_common_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelMax", out _level_max_Index)) _level_max_Index = -1;
                    if (!nameIndexs.TryGetValue("RecommendedTips", out _recommended_tips_Index)) _recommended_tips_Index = -1;
                    if (!nameIndexs.TryGetValue("Statelevel", out _statelevel_Index)) _statelevel_Index = -1;
                    if (!nameIndexs.TryGetValue("TradeRecom", out _trade_recom_Index)) _trade_recom_Index = -1;
                    if (!nameIndexs.TryGetValue("DropNotice", out _drop_notice_Index)) _drop_notice_Index = -1;
                    if (!nameIndexs.TryGetValue("Chatchannel", out _chatchannel_Index)) _chatchannel_Index = -1;
                    if (!nameIndexs.TryGetValue("SealAnima", out _seal_anima_Index)) _seal_anima_Index = -1;
                    if (!nameIndexs.TryGetValue("FlyToBagType", out _fly_to_bag_type_Index)) _fly_to_bag_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionPriceType", out _auction_price_type_Index)) _auction_price_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionUseCoin", out _auction_use_coin_Index)) _auction_use_coin_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionMinPrice", out _auction_min_price_Index)) _auction_min_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionMaxPrice", out _auction_max_price_Index)) _auction_max_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionSingleType", out _auction_single_type_Index)) _auction_single_type_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionSinglePrice", out _auction_single_price_Index)) _auction_single_price_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionCountdown", out _auction_countdown_Index)) _auction_countdown_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionAllTime", out _auction_all_time_Index)) _auction_all_time_Index = -1;
                    if (!nameIndexs.TryGetValue("AuctionGuildAllTime", out _auction_guild_all_time_Index)) _auction_guild_all_time_Index = -1;
                    if (!nameIndexs.TryGetValue("SyntheticMaterials", out _synthetic_materials_Index)) _synthetic_materials_Index = -1;
                    if (!nameIndexs.TryGetValue("DeadTime", out _dead_time_Index)) _dead_time_Index = -1;
                    if (!nameIndexs.TryGetValue("GetText", out _get_text_Index)) _get_text_Index = -1;
                    if (!nameIndexs.TryGetValue("HolySuitType", out _holySuitType_Index)) _holySuitType_Index = -1;
                    if (!nameIndexs.TryGetValue("MagicBowlSolve", out _magic_bowl_solve_Index)) _magic_bowl_solve_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareEquip>(keyCount);
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
            if(HanderDefine.DataCallBack("Equip", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareEquip cfg = null;
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
        public static DeclareEquip Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareEquip result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Equip", out _compressData))
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
