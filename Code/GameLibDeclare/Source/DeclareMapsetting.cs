//文件是自动生成,请勿手动修改.来自数据文件:Mapsetting
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareMapsetting
    {
        #region //静态变量定义
        private static int _name_Index = -1;
        private static int _map_id_Index = -1;
        private static int _map_logic_type_Index = -1;
        private static int _type_Index = -1;
        private static int _mapType_Index = -1;
        private static int _scene_came_match_type_Index = -1;
        private static int _hide_mode_Index = -1;
        private static int _can_team_Index = -1;
        private static int _team_sent_Index = -1;
        private static int _isscript_Index = -1;
        private static int _bornPosition_Index = -1;
        private static int _relivePosition_Index = -1;
        private static int _leavePosition_Index = -1;
        private static int _filter_Index = -1;
        private static int _filter_num_Index = -1;
        private static int _area_high_Index = -1;
        private static int _area_width_Index = -1;
        private static int _needVip_Index = -1;
        private static int _needState_Index = -1;
        private static int _level_min_Index = -1;
        private static int _level_max_Index = -1;
        private static int _pkState_Index = -1;
        private static int _use_drug_Index = -1;
        private static int _relive_type_Index = -1;
        private static int _relive_time_Index = -1;
        private static int _lines_Index = -1;
        private static int _online_Index = -1;
        private static int _level_name_Index = -1;
        private static int _level_name_2_Index = -1;
        private static int _icon_model_Index = -1;
        private static int _map_grid_Index = -1;
        private static int _map_info_Index = -1;
        private static int _music_Index = -1;
        private static int _camera_fov_Index = -1;
        private static int _camera_fov_3d_Index = -1;
        private static int _camera_fov_pc_Index = -1;
        private static int _camera_fov_pc_3d_Index = -1;
        private static int _cam_default_yaw_Index = -1;
        private static int _cam_min_yaw_Index = -1;
        private static int _cam_max_yaw_Index = -1;
        private static int _cam_default_dis_Index = -1;
        private static int _cam_far_dis_Index = -1;
        private static int _cam_default_pitch_Index = -1;
        private static int _cam_far_pitch_Index = -1;
        private static int _cam_default_offsety_Index = -1;
        private static int _cam_far_offsety_Index = -1;
        private static int _cam_layer_cull_distance_Index = -1;
        private static int _cam_switch_time_Index = -1;
        private static int _dropMap_Index = -1;
        private static int _shadow_param_Index = -1;
        private static int _scene_shadow_param_Index = -1;
        private static int _fog_day_param_Index = -1;
        private static int _fog_night_param_Index = -1;
        private static int _camera_name_Index = -1;
        private static int _camera_name_night_Index = -1;
        private static int _change_by_setting_Index = -1;
        private static int _camera_vfx_Index = -1;
        private static int _special_body_Index = -1;
        private static int _special_weapon_head_Index = -1;
        private static int _special_weapon_body_Index = -1;
        private static int _special_weapon_vfx_Index = -1;
        private static int _special_wing_Index = -1;
        private static int _special_name_Index = -1;
        private static int _canJump_Index = -1;
        private static int _canFly_Index = -1;
        private static int _canRiding_Index = -1;
        private static int _fly_min_height_Index = -1;
        private static int _fly_max_height_Index = -1;
        private static int _cinematic_Index = -1;
        private static int _can_mandate_Index = -1;
        private static int _show_pk_color_Index = -1;
        private static int _bonfire_num_Index = -1;
        private static int _show_player_hp_Index = -1;
        private static int _show_player_hud_Index = -1;
        private static int _show_monster_hud_Index = -1;
        private static int _show_pet_hud_Index = -1;
        private static int _show_npc_hud_Index = -1;
        private static int _teamAuto_Index = -1;
        private static int _xunlu_Index = -1;
        private static int _guild_kill_Index = -1;
        private static int _exp_efficiency_Index = -1;
        private static int _auto_fight_set_Index = -1;
        private static int _enterPrompt_Index = -1;
        private static int _map_exp_Index = -1;
        private static int _map_exp_condition_Index = -1;
        private static int _mini_map_scale_Index = -1;
        private static int _vfx_show_Index = -1;
        private static int _if_Newguild_Call_Index = -1;
        private static int _fight_type_Index = -1;
        private static int _fight_change_Index = -1;
        private static int _show_pk_modes_Index = -1;
        private static int _meditation_whether_Index = -1;
        private static int _if_World_Support_Index = -1;
        private static int _leave_mapid_Index = -1;
        private static int _isLeave_Index = -1;
        private static int _isDaily_Index = -1;
        private static int _isLink_Index = -1;
        private static int _multiLevel_Index = -1;
        private static int _receive_type_Index = -1;
        private static int _guildeHelp_type_Index = -1;
        private static int _idle_anim_Index = -1;
        private static int _run_anim_Index = -1;
        private static int _dodge_anim_Index = -1;
        #endregion
        #region //私有变量定义
        //地图名
        private int _name;
        //地图id
        //细则见备注
        private int _map_id;
        //地图逻辑类型（客户端专用）（hide）
        //用于判断是不是位面
        private int _map_logic_type;
        //地图类型-1登录场景，0世界地图，1副本地图，2竞技场，3跨服副本，5位面
        private int _type;
        //0非跨服
        //1跨服
        //客户端专用区分是否为跨服玩法的字段
        //（hide）
        private int _mapType;
        //阵营模式匹配方式：0阵营id不一样就可以攻击；1根据敌方的阵营id进行位运算匹配
        private int _scene_came_match_type;
        //宠物在地图是否出战
        //0表示不限制，1表示宠物
        private int _hide_mode;
        //地图内是否允许组队（0为不允许，1为允许）
        private int _can_team;
        //是否允许组队传送（0为不允许，1为允许）
        private int _team_sent;
        //脚本ID
        private int _isscript;
        //出生位置，（x_y 表示地图坐标)(@;@_@)
        private int _bornPosition;
        //复活位置，（地图ID_坐标；地图填0为在当前地图复活)(@;@_@)
        private int _relivePosition;
        //用于位面离开时的位置，（x_y 表示地图坐标)(@_@)
        //不填表示从位面原地出
        //坐标表示指定位置出来
        private int _leavePosition;
        //消息分级类型0=普通，1=？
        private int _filter;
        //消息分级的可见人数
        private int _filter_num;
        //区域的高
        private int _area_high;
        //区域的宽
        private int _area_width;
        //进入所需VIP等级（0-9）
        private int _needVip;
        //进入所需境界等级（0为无限制，不填则为0）
        private int _needState;
        //进入最小等级 -1表示无限制
        private int _level_min;
        //进入最大等级 -1表示无限制
        private int _level_max;
        //是否安全(0不能pk, 1常规pk， 2无惩罚pk)
        private int _pkState;
        //是否可以使用药品。0为可以使用，1为不可使用
        private int _use_drug;
        //复活模式 读取relive表的类型
        private int _relive_type;
        //复活倒计时（毫秒
        private int _relive_time;
        //最大分线数量（此地图的最大分线数量，当线路中人数满了之后，不会新开线路，只会增加线路可容纳人数上限）
        private int _lines;
        //每条线路每批次最大增加人数（例：分线20条，最大人数50。当20条线路都50人后，会再往20条线路中分别投入50人，如果又满了，再加50，依此循环……）
        private int _online;
        //场景资源名字
        private int _level_name;
        //场景资源名字2
        private int _level_name_2;
        //世界地图标志资源（hide）
        private int _icon_model;
        //地图阻挡数据
        private int _map_grid;
        //地图怪物NPC采集物寻路点等等
        private int _map_info;
        //音乐(hide)
        private int _music;
        //摄像机fov值（hide)
        private int _camera_fov;
        //摄像机fov值（hide)
        private int _camera_fov_3d;
        //pc摄像机fov值（hide)
        private int _camera_fov_pc;
        //pc摄像机fov值（hide)
        private int _camera_fov_pc_3d;
        //摄像机进入地图默认yaw值(hide)
        private int _cam_default_yaw;
        //摄像机最小yaw值(hide)
        private int _cam_min_yaw;
        //摄像机最大yaw值(hide)
        private int _cam_max_yaw;
        //摄像机默认跟随距离,单位厘米(hide)
        private int _cam_default_dis;
        //摄像机远景时的距离,单位厘米(hide)
        private int _cam_far_dis;
        //摄像机默认时的倾斜角(hide)
        private int _cam_default_pitch;
        //摄像机远景时的倾斜角(hide)
        private int _cam_far_pitch;
        //摄像机默认Y轴偏移距离,单位厘米(hide)
        private int _cam_default_offsety;
        //摄像机远景时的Y轴偏移距离,单位厘米(hide)
        private int _cam_far_offsety;
        //摄像机默认视线的距离
        private int _cam_layer_cull_distance;
        //镜头切换时间，只针对位面地图有效，在进出位面时使用，单位毫秒（hide）
        private int _cam_switch_time;
        //地图掉落[几率_掉落ID；几率_掉落ID]
        private int _dropMap;
        //阴影参数(hide) 是否开启;灯光方向;白天阴影强度;晚上阴影强度，例如0;55_0_0;0.5
        private int _shadow_param;
        //场景阴影参数(hide) 是否开启;灯光方向;白天阴影强度;晚上阴影强度，例如0;55_0_0;0.5
        private int _scene_shadow_param;
        //雾效白天效果配置(hide);R_G_B;近距离;远距离
        private int _fog_day_param;
        //雾效晚上效果配置(hide)R_G_B;近距离;远距离
        private int _fog_night_param;
        //使用的摄像机名字
        private int _camera_name;
        //使用的摄像机名字
        private int _camera_name_night;
        //是否受到设置影响，0表示不会，即设置中的画质改变时不会改变摄像机，1表示会，即设置中画质改变时会改变摄像机
        private int _change_by_setting;
        //镜头上播放的特效（hide）othervfx中的id
        private int _camera_vfx;
        //特殊的外形，在此地图使用特殊的身体外形，例如0_100;1_100，职业_衣服ID；（hide）
        private int _special_body;
        //特殊的外形，在此地图使用特殊的武器外形，例如0_100;1_100，职业_武器ID；（hide）
        private int _special_weapon_head;
        //特殊的外形，在此地图使用特殊的武器外形，例如0_100;1_100，职业_武器ID；（hide）
        private int _special_weapon_body;
        //特殊的外形，在此地图使用特殊的武器外形，例如0_100;1_100，职业_武器ID；（hide）
        private int _special_weapon_vfx;
        //特殊的外形，在此地图使用特殊的翅膀外形，例如0_100;1_100，职业_翅膀ID；（hide）
        private int _special_wing;
        //特殊的名字，在此地图其他玩家都显示为特殊的名字0_齐王府;1_六扇门（hide）
        private int _special_name;
        //是否能跳（0否 1是）
        private int _canJump;
        //是否能飞（0否 1是）
        private int _canFly;
        //能否上坐骑（0否 1是）
        private int _canRiding;
        //飞行最低高度
        private int _fly_min_height;
        //飞行最高高度
        private int _fly_max_height;
        //首次进入地图后播放的动画Id（hide）
        private int _cinematic;
        //地图里边是否可以挂机
        private int _can_mandate;
        //是否显示PK值影响的名字颜色(hide)
        private int _show_pk_color;
        //地图篝火上限
        private int _bonfire_num;
        //是否默认展示玩家血条（hide)
        private int _show_player_hp;
        //是否显示其他玩家头顶(hide)
        private int _show_player_hud;
        //是否显示怪物头顶(hide)
        private int _show_monster_hud;
        //是否显示宠物头顶(hide)
        private int _show_pet_hud;
        //是否显示NPC头顶(hide)
        private int _show_npc_hud;
        //加队自动召唤（0不召唤，1召唤）
        private int _teamAuto;
        //自动寻路的坐标（世界BOSS用，别的不用；阵营ID_x_z）
        private int _xunlu;
        //公会死亡是否发送消息
        private int _guild_kill;
        //是否显示挂机经验收益（0否，1是）
        private int _exp_efficiency;
        //地图默认挂机方式（0.全地图；1.当前屏）
        private int _auto_fight_set;
        //聊天框点击坐标的超链接是否弹出提示（0否，1是）
        private int _enterPrompt;
        //该地图是否开启地图经验(0，不开启；大于1为on_hook的map_exp字段中数组序列,1表示第1个
        private int _map_exp;
        //开启地图经验的条件（不填限制）(FunctionVariable的条件）
        private int _map_exp_condition;
        //控制小地图整体缩放大小得比例，原始尺寸为1
        private int _mini_map_scale;
        //是否屏蔽升级和任务完成特效
        //默认为0表示不屏蔽；1表示屏蔽
        private int _vfx_show;
        //是否可以挚友召唤（0，不行；1.可以）
        private int _if_Newguild_Call;
        //默认战斗模式（0，和平；1，全体；2，本服；3，强制）
        private int _fight_type;
        //能否切换战斗模式（0，不行；1，可以）
        private int _fight_change;
        //展示的pk模式 hide
        private int _show_pk_modes;
        //当前是否可以现在打坐（0或空，不行；1.可以）
        private int _meditation_whether;
        //是否可以世界支援（0，不行；1.可以）
        private int _if_World_Support;
        //退出副本进入的地图ID
        private int _leave_mapid;
        //离开地图是否弹出二级确认界面
        //0不弹，直接传（默认为0）
        //1弹出文字描述不准传送
        //（hide）
        private int _isLeave;
        //是否属于活动地图
        //（直接配置daily表的ID）
        //（hide）
        private int _isDaily;
        //当前地图是否能发送坐标链接
        //0不能（默认为不能）
        //1能
        //（hide）
        private int _isLink;
        private int _multiLevel;
        //收取活动提示的类型(0不接收，1接收退出副本进入活动提示，2接收直接进入活动提示）（hide）
        private int _receive_type;
        //死亡求援同仙盟成员弹出类型
        //0：不接收
        //1：接收退出副本进入活动提示
        //2：可直接前往
        //（hide）
        private int _guildeHelp_type;
        //地图特殊idle动作（hide）
        private int _idle_anim;
        //地图特殊移动动作（hide）
        private int _run_anim;
        //地图特殊冲刺动作（hide）
        private int _dodge_anim;
        #endregion

        #region //公共属性
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int MapId { get{ return _map_id; }}
        public int MapLogicType { get{ return _map_logic_type; }}
        public int Type { get{ return _type; }}
        public int MapType { get{ return _mapType; }}
        public int SceneCameMatchType { get{ return _scene_came_match_type; }}
        public int HideMode { get{ return _hide_mode; }}
        public int CanTeam { get{ return _can_team; }}
        public int TeamSent { get{ return _team_sent; }}
        public int Isscript { get{ return _isscript; }}
        public string BornPosition { get{ return HanderDefine.SetStingCallBack(_bornPosition); }}
        public string RelivePosition { get{ return HanderDefine.SetStingCallBack(_relivePosition); }}
        public string LeavePosition { get{ return HanderDefine.SetStingCallBack(_leavePosition); }}
        public int Filter { get{ return _filter; }}
        public int FilterNum { get{ return _filter_num; }}
        public int AreaHigh { get{ return _area_high; }}
        public int AreaWidth { get{ return _area_width; }}
        public int NeedVip { get{ return _needVip; }}
        public int NeedState { get{ return _needState; }}
        public int LevelMin { get{ return _level_min; }}
        public int LevelMax { get{ return _level_max; }}
        public int PkState { get{ return _pkState; }}
        public int UseDrug { get{ return _use_drug; }}
        public int ReliveType { get{ return _relive_type; }}
        public int ReliveTime { get{ return _relive_time; }}
        public int Lines { get{ return _lines; }}
        public int Online { get{ return _online; }}
        public string LevelName { get{ return HanderDefine.SetStingCallBack(_level_name); }}
        public string LevelName2 { get{ return HanderDefine.SetStingCallBack(_level_name_2); }}
        public int IconModel { get{ return _icon_model; }}
        public string MapGrid { get{ return HanderDefine.SetStingCallBack(_map_grid); }}
        public string MapInfo { get{ return HanderDefine.SetStingCallBack(_map_info); }}
        public string Music { get{ return HanderDefine.SetStingCallBack(_music); }}
        public int CameraFov { get{ return _camera_fov; }}
        public int CameraFov3d { get{ return _camera_fov_3d; }}
        public int CameraFovPc { get{ return _camera_fov_pc; }}
        public int CameraFovPc3d { get{ return _camera_fov_pc_3d; }}
        public int CamDefaultYaw { get{ return _cam_default_yaw; }}
        public int CamMinYaw { get{ return _cam_min_yaw; }}
        public int CamMaxYaw { get{ return _cam_max_yaw; }}
        public int CamDefaultDis { get{ return _cam_default_dis; }}
        public int CamFarDis { get{ return _cam_far_dis; }}
        public int CamDefaultPitch { get{ return _cam_default_pitch; }}
        public int CamFarPitch { get{ return _cam_far_pitch; }}
        public int CamDefaultOffsety { get{ return _cam_default_offsety; }}
        public int CamFarOffsety { get{ return _cam_far_offsety; }}
        public int CamLayerCullDistance { get{ return _cam_layer_cull_distance; }}
        public int CamSwitchTime { get{ return _cam_switch_time; }}
        public string DropMap { get{ return HanderDefine.SetStingCallBack(_dropMap); }}
        public string ShadowParam { get{ return HanderDefine.SetStingCallBack(_shadow_param); }}
        public string SceneShadowParam { get{ return HanderDefine.SetStingCallBack(_scene_shadow_param); }}
        public string FogDayParam { get{ return HanderDefine.SetStingCallBack(_fog_day_param); }}
        public string FogNightParam { get{ return HanderDefine.SetStingCallBack(_fog_night_param); }}
        public string CameraName { get{ return HanderDefine.SetStingCallBack(_camera_name); }}
        public string CameraNameNight { get{ return HanderDefine.SetStingCallBack(_camera_name_night); }}
        public int ChangeBySetting { get{ return _change_by_setting; }}
        public int CameraVfx { get{ return _camera_vfx; }}
        public string SpecialBody { get{ return HanderDefine.SetStingCallBack(_special_body); }}
        public string SpecialWeaponHead { get{ return HanderDefine.SetStingCallBack(_special_weapon_head); }}
        public string SpecialWeaponBody { get{ return HanderDefine.SetStingCallBack(_special_weapon_body); }}
        public string SpecialWeaponVfx { get{ return HanderDefine.SetStingCallBack(_special_weapon_vfx); }}
        public string SpecialWing { get{ return HanderDefine.SetStingCallBack(_special_wing); }}
        public string SpecialName { get{ return HanderDefine.SetStingCallBack(_special_name); }}
        public int CanJump { get{ return _canJump; }}
        public int CanFly { get{ return _canFly; }}
        public int CanRiding { get{ return _canRiding; }}
        public int FlyMinHeight { get{ return _fly_min_height; }}
        public int FlyMaxHeight { get{ return _fly_max_height; }}
        public int Cinematic { get{ return _cinematic; }}
        public int CanMandate { get{ return _can_mandate; }}
        public int ShowPkColor { get{ return _show_pk_color; }}
        public int BonfireNum { get{ return _bonfire_num; }}
        public int ShowPlayerHp { get{ return _show_player_hp; }}
        public int ShowPlayerHud { get{ return _show_player_hud; }}
        public int ShowMonsterHud { get{ return _show_monster_hud; }}
        public int ShowPetHud { get{ return _show_pet_hud; }}
        public int ShowNpcHud { get{ return _show_npc_hud; }}
        public int TeamAuto { get{ return _teamAuto; }}
        public string Xunlu { get{ return HanderDefine.SetStingCallBack(_xunlu); }}
        public int GuildKill { get{ return _guild_kill; }}
        public int ExpEfficiency { get{ return _exp_efficiency; }}
        public int AutoFightSet { get{ return _auto_fight_set; }}
        public int EnterPrompt { get{ return _enterPrompt; }}
        public int MapExp { get{ return _map_exp; }}
        public string MapExpCondition { get{ return HanderDefine.SetStingCallBack(_map_exp_condition); }}
        public int MiniMapScale { get{ return _mini_map_scale; }}
        public int VfxShow { get{ return _vfx_show; }}
        public int IfNewguildCall { get{ return _if_Newguild_Call; }}
        public int FightType { get{ return _fight_type; }}
        public int FightChange { get{ return _fight_change; }}
        public string ShowPkModes { get{ return HanderDefine.SetStingCallBack(_show_pk_modes); }}
        public int MeditationWhether { get{ return _meditation_whether; }}
        public int IfWorldSupport { get{ return _if_World_Support; }}
        public int LeaveMapid { get{ return _leave_mapid; }}
        public int IsLeave { get{ return _isLeave; }}
        public int IsDaily { get{ return _isDaily; }}
        public int IsLink { get{ return _isLink; }}
        public int MultiLevel { get{ return _multiLevel; }}
        public int ReceiveType { get{ return _receive_type; }}
        public int GuildeHelpType { get{ return _guildeHelp_type; }}
        public string IdleAnim { get{ return HanderDefine.SetStingCallBack(_idle_anim); }}
        public string RunAnim { get{ return HanderDefine.SetStingCallBack(_run_anim); }}
        public string DodgeAnim { get{ return HanderDefine.SetStingCallBack(_dodge_anim); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareMapsetting cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareMapsetting> _dataCaches = null;
        public static Dictionary<int, DeclareMapsetting> CacheData
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
                        if (HanderDefine.DataCallBack("Mapsetting", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareMapsetting cfg = null;
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
        private unsafe static DeclareMapsetting LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareMapsetting();
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._map_id = (int)GetValue(keyIndex, _map_id_Index, ptr);
            tmp._map_logic_type = (int)GetValue(keyIndex, _map_logic_type_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._mapType = (int)GetValue(keyIndex, _mapType_Index, ptr);
            tmp._scene_came_match_type = (int)GetValue(keyIndex, _scene_came_match_type_Index, ptr);
            tmp._hide_mode = (int)GetValue(keyIndex, _hide_mode_Index, ptr);
            tmp._can_team = (int)GetValue(keyIndex, _can_team_Index, ptr);
            tmp._team_sent = (int)GetValue(keyIndex, _team_sent_Index, ptr);
            tmp._isscript = (int)GetValue(keyIndex, _isscript_Index, ptr);
            tmp._bornPosition = (int)GetValue(keyIndex, _bornPosition_Index, ptr);
            tmp._relivePosition = (int)GetValue(keyIndex, _relivePosition_Index, ptr);
            tmp._leavePosition = (int)GetValue(keyIndex, _leavePosition_Index, ptr);
            tmp._filter = (int)GetValue(keyIndex, _filter_Index, ptr);
            tmp._filter_num = (int)GetValue(keyIndex, _filter_num_Index, ptr);
            tmp._area_high = (int)GetValue(keyIndex, _area_high_Index, ptr);
            tmp._area_width = (int)GetValue(keyIndex, _area_width_Index, ptr);
            tmp._needVip = (int)GetValue(keyIndex, _needVip_Index, ptr);
            tmp._needState = (int)GetValue(keyIndex, _needState_Index, ptr);
            tmp._level_min = (int)GetValue(keyIndex, _level_min_Index, ptr);
            tmp._level_max = (int)GetValue(keyIndex, _level_max_Index, ptr);
            tmp._pkState = (int)GetValue(keyIndex, _pkState_Index, ptr);
            tmp._use_drug = (int)GetValue(keyIndex, _use_drug_Index, ptr);
            tmp._relive_type = (int)GetValue(keyIndex, _relive_type_Index, ptr);
            tmp._relive_time = (int)GetValue(keyIndex, _relive_time_Index, ptr);
            tmp._lines = (int)GetValue(keyIndex, _lines_Index, ptr);
            tmp._online = (int)GetValue(keyIndex, _online_Index, ptr);
            tmp._level_name = (int)GetValue(keyIndex, _level_name_Index, ptr);
            tmp._level_name_2 = (int)GetValue(keyIndex, _level_name_2_Index, ptr);
            tmp._icon_model = (int)GetValue(keyIndex, _icon_model_Index, ptr);
            tmp._map_grid = (int)GetValue(keyIndex, _map_grid_Index, ptr);
            tmp._map_info = (int)GetValue(keyIndex, _map_info_Index, ptr);
            tmp._music = (int)GetValue(keyIndex, _music_Index, ptr);
            tmp._camera_fov = (int)GetValue(keyIndex, _camera_fov_Index, ptr);
            tmp._camera_fov_3d = (int)GetValue(keyIndex, _camera_fov_3d_Index, ptr);
            tmp._camera_fov_pc = (int)GetValue(keyIndex, _camera_fov_pc_Index, ptr);
            tmp._camera_fov_pc_3d = (int)GetValue(keyIndex, _camera_fov_pc_3d_Index, ptr);
            tmp._cam_default_yaw = (int)GetValue(keyIndex, _cam_default_yaw_Index, ptr);
            tmp._cam_min_yaw = (int)GetValue(keyIndex, _cam_min_yaw_Index, ptr);
            tmp._cam_max_yaw = (int)GetValue(keyIndex, _cam_max_yaw_Index, ptr);
            tmp._cam_default_dis = (int)GetValue(keyIndex, _cam_default_dis_Index, ptr);
            tmp._cam_far_dis = (int)GetValue(keyIndex, _cam_far_dis_Index, ptr);
            tmp._cam_default_pitch = (int)GetValue(keyIndex, _cam_default_pitch_Index, ptr);
            tmp._cam_far_pitch = (int)GetValue(keyIndex, _cam_far_pitch_Index, ptr);
            tmp._cam_default_offsety = (int)GetValue(keyIndex, _cam_default_offsety_Index, ptr);
            tmp._cam_far_offsety = (int)GetValue(keyIndex, _cam_far_offsety_Index, ptr);
            tmp._cam_layer_cull_distance = (int)GetValue(keyIndex, _cam_layer_cull_distance_Index, ptr);
            tmp._cam_switch_time = (int)GetValue(keyIndex, _cam_switch_time_Index, ptr);
            tmp._dropMap = (int)GetValue(keyIndex, _dropMap_Index, ptr);
            tmp._shadow_param = (int)GetValue(keyIndex, _shadow_param_Index, ptr);
            tmp._scene_shadow_param = (int)GetValue(keyIndex, _scene_shadow_param_Index, ptr);
            tmp._fog_day_param = (int)GetValue(keyIndex, _fog_day_param_Index, ptr);
            tmp._fog_night_param = (int)GetValue(keyIndex, _fog_night_param_Index, ptr);
            tmp._camera_name = (int)GetValue(keyIndex, _camera_name_Index, ptr);
            tmp._camera_name_night = (int)GetValue(keyIndex, _camera_name_night_Index, ptr);
            tmp._change_by_setting = (int)GetValue(keyIndex, _change_by_setting_Index, ptr);
            tmp._camera_vfx = (int)GetValue(keyIndex, _camera_vfx_Index, ptr);
            tmp._special_body = (int)GetValue(keyIndex, _special_body_Index, ptr);
            tmp._special_weapon_head = (int)GetValue(keyIndex, _special_weapon_head_Index, ptr);
            tmp._special_weapon_body = (int)GetValue(keyIndex, _special_weapon_body_Index, ptr);
            tmp._special_weapon_vfx = (int)GetValue(keyIndex, _special_weapon_vfx_Index, ptr);
            tmp._special_wing = (int)GetValue(keyIndex, _special_wing_Index, ptr);
            tmp._special_name = (int)GetValue(keyIndex, _special_name_Index, ptr);
            tmp._canJump = (int)GetValue(keyIndex, _canJump_Index, ptr);
            tmp._canFly = (int)GetValue(keyIndex, _canFly_Index, ptr);
            tmp._canRiding = (int)GetValue(keyIndex, _canRiding_Index, ptr);
            tmp._fly_min_height = (int)GetValue(keyIndex, _fly_min_height_Index, ptr);
            tmp._fly_max_height = (int)GetValue(keyIndex, _fly_max_height_Index, ptr);
            tmp._cinematic = (int)GetValue(keyIndex, _cinematic_Index, ptr);
            tmp._can_mandate = (int)GetValue(keyIndex, _can_mandate_Index, ptr);
            tmp._show_pk_color = (int)GetValue(keyIndex, _show_pk_color_Index, ptr);
            tmp._bonfire_num = (int)GetValue(keyIndex, _bonfire_num_Index, ptr);
            tmp._show_player_hp = (int)GetValue(keyIndex, _show_player_hp_Index, ptr);
            tmp._show_player_hud = (int)GetValue(keyIndex, _show_player_hud_Index, ptr);
            tmp._show_monster_hud = (int)GetValue(keyIndex, _show_monster_hud_Index, ptr);
            tmp._show_pet_hud = (int)GetValue(keyIndex, _show_pet_hud_Index, ptr);
            tmp._show_npc_hud = (int)GetValue(keyIndex, _show_npc_hud_Index, ptr);
            tmp._teamAuto = (int)GetValue(keyIndex, _teamAuto_Index, ptr);
            tmp._xunlu = (int)GetValue(keyIndex, _xunlu_Index, ptr);
            tmp._guild_kill = (int)GetValue(keyIndex, _guild_kill_Index, ptr);
            tmp._exp_efficiency = (int)GetValue(keyIndex, _exp_efficiency_Index, ptr);
            tmp._auto_fight_set = (int)GetValue(keyIndex, _auto_fight_set_Index, ptr);
            tmp._enterPrompt = (int)GetValue(keyIndex, _enterPrompt_Index, ptr);
            tmp._map_exp = (int)GetValue(keyIndex, _map_exp_Index, ptr);
            tmp._map_exp_condition = (int)GetValue(keyIndex, _map_exp_condition_Index, ptr);
            tmp._mini_map_scale = (int)GetValue(keyIndex, _mini_map_scale_Index, ptr);
            tmp._vfx_show = (int)GetValue(keyIndex, _vfx_show_Index, ptr);
            tmp._if_Newguild_Call = (int)GetValue(keyIndex, _if_Newguild_Call_Index, ptr);
            tmp._fight_type = (int)GetValue(keyIndex, _fight_type_Index, ptr);
            tmp._fight_change = (int)GetValue(keyIndex, _fight_change_Index, ptr);
            tmp._show_pk_modes = (int)GetValue(keyIndex, _show_pk_modes_Index, ptr);
            tmp._meditation_whether = (int)GetValue(keyIndex, _meditation_whether_Index, ptr);
            tmp._if_World_Support = (int)GetValue(keyIndex, _if_World_Support_Index, ptr);
            tmp._leave_mapid = (int)GetValue(keyIndex, _leave_mapid_Index, ptr);
            tmp._isLeave = (int)GetValue(keyIndex, _isLeave_Index, ptr);
            tmp._isDaily = (int)GetValue(keyIndex, _isDaily_Index, ptr);
            tmp._isLink = (int)GetValue(keyIndex, _isLink_Index, ptr);
            tmp._multiLevel = (int)GetValue(keyIndex, _multiLevel_Index, ptr);
            tmp._receive_type = (int)GetValue(keyIndex, _receive_type_Index, ptr);
            tmp._guildeHelp_type = (int)GetValue(keyIndex, _guildeHelp_type_Index, ptr);
            tmp._idle_anim = (int)GetValue(keyIndex, _idle_anim_Index, ptr);
            tmp._run_anim = (int)GetValue(keyIndex, _run_anim_Index, ptr);
            tmp._dodge_anim = (int)GetValue(keyIndex, _dodge_anim_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Mapsetting", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("MapId", out _map_id_Index)) _map_id_Index = -1;
                    if (!nameIndexs.TryGetValue("MapLogicType", out _map_logic_type_Index)) _map_logic_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("MapType", out _mapType_Index)) _mapType_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneCameMatchType", out _scene_came_match_type_Index)) _scene_came_match_type_Index = -1;
                    if (!nameIndexs.TryGetValue("HideMode", out _hide_mode_Index)) _hide_mode_Index = -1;
                    if (!nameIndexs.TryGetValue("CanTeam", out _can_team_Index)) _can_team_Index = -1;
                    if (!nameIndexs.TryGetValue("TeamSent", out _team_sent_Index)) _team_sent_Index = -1;
                    if (!nameIndexs.TryGetValue("Isscript", out _isscript_Index)) _isscript_Index = -1;
                    if (!nameIndexs.TryGetValue("BornPosition", out _bornPosition_Index)) _bornPosition_Index = -1;
                    if (!nameIndexs.TryGetValue("RelivePosition", out _relivePosition_Index)) _relivePosition_Index = -1;
                    if (!nameIndexs.TryGetValue("LeavePosition", out _leavePosition_Index)) _leavePosition_Index = -1;
                    if (!nameIndexs.TryGetValue("Filter", out _filter_Index)) _filter_Index = -1;
                    if (!nameIndexs.TryGetValue("FilterNum", out _filter_num_Index)) _filter_num_Index = -1;
                    if (!nameIndexs.TryGetValue("AreaHigh", out _area_high_Index)) _area_high_Index = -1;
                    if (!nameIndexs.TryGetValue("AreaWidth", out _area_width_Index)) _area_width_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedVip", out _needVip_Index)) _needVip_Index = -1;
                    if (!nameIndexs.TryGetValue("NeedState", out _needState_Index)) _needState_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelMin", out _level_min_Index)) _level_min_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelMax", out _level_max_Index)) _level_max_Index = -1;
                    if (!nameIndexs.TryGetValue("PkState", out _pkState_Index)) _pkState_Index = -1;
                    if (!nameIndexs.TryGetValue("UseDrug", out _use_drug_Index)) _use_drug_Index = -1;
                    if (!nameIndexs.TryGetValue("ReliveType", out _relive_type_Index)) _relive_type_Index = -1;
                    if (!nameIndexs.TryGetValue("ReliveTime", out _relive_time_Index)) _relive_time_Index = -1;
                    if (!nameIndexs.TryGetValue("Lines", out _lines_Index)) _lines_Index = -1;
                    if (!nameIndexs.TryGetValue("Online", out _online_Index)) _online_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelName", out _level_name_Index)) _level_name_Index = -1;
                    if (!nameIndexs.TryGetValue("LevelName2", out _level_name_2_Index)) _level_name_2_Index = -1;
                    if (!nameIndexs.TryGetValue("IconModel", out _icon_model_Index)) _icon_model_Index = -1;
                    if (!nameIndexs.TryGetValue("MapGrid", out _map_grid_Index)) _map_grid_Index = -1;
                    if (!nameIndexs.TryGetValue("MapInfo", out _map_info_Index)) _map_info_Index = -1;
                    if (!nameIndexs.TryGetValue("Music", out _music_Index)) _music_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraFov", out _camera_fov_Index)) _camera_fov_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraFov3d", out _camera_fov_3d_Index)) _camera_fov_3d_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraFovPc", out _camera_fov_pc_Index)) _camera_fov_pc_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraFovPc3d", out _camera_fov_pc_3d_Index)) _camera_fov_pc_3d_Index = -1;
                    if (!nameIndexs.TryGetValue("CamDefaultYaw", out _cam_default_yaw_Index)) _cam_default_yaw_Index = -1;
                    if (!nameIndexs.TryGetValue("CamMinYaw", out _cam_min_yaw_Index)) _cam_min_yaw_Index = -1;
                    if (!nameIndexs.TryGetValue("CamMaxYaw", out _cam_max_yaw_Index)) _cam_max_yaw_Index = -1;
                    if (!nameIndexs.TryGetValue("CamDefaultDis", out _cam_default_dis_Index)) _cam_default_dis_Index = -1;
                    if (!nameIndexs.TryGetValue("CamFarDis", out _cam_far_dis_Index)) _cam_far_dis_Index = -1;
                    if (!nameIndexs.TryGetValue("CamDefaultPitch", out _cam_default_pitch_Index)) _cam_default_pitch_Index = -1;
                    if (!nameIndexs.TryGetValue("CamFarPitch", out _cam_far_pitch_Index)) _cam_far_pitch_Index = -1;
                    if (!nameIndexs.TryGetValue("CamDefaultOffsety", out _cam_default_offsety_Index)) _cam_default_offsety_Index = -1;
                    if (!nameIndexs.TryGetValue("CamFarOffsety", out _cam_far_offsety_Index)) _cam_far_offsety_Index = -1;
                    if (!nameIndexs.TryGetValue("CamLayerCullDistance", out _cam_layer_cull_distance_Index)) _cam_layer_cull_distance_Index = -1;
                    if (!nameIndexs.TryGetValue("CamSwitchTime", out _cam_switch_time_Index)) _cam_switch_time_Index = -1;
                    if (!nameIndexs.TryGetValue("DropMap", out _dropMap_Index)) _dropMap_Index = -1;
                    if (!nameIndexs.TryGetValue("ShadowParam", out _shadow_param_Index)) _shadow_param_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneShadowParam", out _scene_shadow_param_Index)) _scene_shadow_param_Index = -1;
                    if (!nameIndexs.TryGetValue("FogDayParam", out _fog_day_param_Index)) _fog_day_param_Index = -1;
                    if (!nameIndexs.TryGetValue("FogNightParam", out _fog_night_param_Index)) _fog_night_param_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraName", out _camera_name_Index)) _camera_name_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraNameNight", out _camera_name_night_Index)) _camera_name_night_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangeBySetting", out _change_by_setting_Index)) _change_by_setting_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraVfx", out _camera_vfx_Index)) _camera_vfx_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialBody", out _special_body_Index)) _special_body_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialWeaponHead", out _special_weapon_head_Index)) _special_weapon_head_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialWeaponBody", out _special_weapon_body_Index)) _special_weapon_body_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialWeaponVfx", out _special_weapon_vfx_Index)) _special_weapon_vfx_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialWing", out _special_wing_Index)) _special_wing_Index = -1;
                    if (!nameIndexs.TryGetValue("SpecialName", out _special_name_Index)) _special_name_Index = -1;
                    if (!nameIndexs.TryGetValue("CanJump", out _canJump_Index)) _canJump_Index = -1;
                    if (!nameIndexs.TryGetValue("CanFly", out _canFly_Index)) _canFly_Index = -1;
                    if (!nameIndexs.TryGetValue("CanRiding", out _canRiding_Index)) _canRiding_Index = -1;
                    if (!nameIndexs.TryGetValue("FlyMinHeight", out _fly_min_height_Index)) _fly_min_height_Index = -1;
                    if (!nameIndexs.TryGetValue("FlyMaxHeight", out _fly_max_height_Index)) _fly_max_height_Index = -1;
                    if (!nameIndexs.TryGetValue("Cinematic", out _cinematic_Index)) _cinematic_Index = -1;
                    if (!nameIndexs.TryGetValue("CanMandate", out _can_mandate_Index)) _can_mandate_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPkColor", out _show_pk_color_Index)) _show_pk_color_Index = -1;
                    if (!nameIndexs.TryGetValue("BonfireNum", out _bonfire_num_Index)) _bonfire_num_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPlayerHp", out _show_player_hp_Index)) _show_player_hp_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPlayerHud", out _show_player_hud_Index)) _show_player_hud_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowMonsterHud", out _show_monster_hud_Index)) _show_monster_hud_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPetHud", out _show_pet_hud_Index)) _show_pet_hud_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowNpcHud", out _show_npc_hud_Index)) _show_npc_hud_Index = -1;
                    if (!nameIndexs.TryGetValue("TeamAuto", out _teamAuto_Index)) _teamAuto_Index = -1;
                    if (!nameIndexs.TryGetValue("Xunlu", out _xunlu_Index)) _xunlu_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildKill", out _guild_kill_Index)) _guild_kill_Index = -1;
                    if (!nameIndexs.TryGetValue("ExpEfficiency", out _exp_efficiency_Index)) _exp_efficiency_Index = -1;
                    if (!nameIndexs.TryGetValue("AutoFightSet", out _auto_fight_set_Index)) _auto_fight_set_Index = -1;
                    if (!nameIndexs.TryGetValue("EnterPrompt", out _enterPrompt_Index)) _enterPrompt_Index = -1;
                    if (!nameIndexs.TryGetValue("MapExp", out _map_exp_Index)) _map_exp_Index = -1;
                    if (!nameIndexs.TryGetValue("MapExpCondition", out _map_exp_condition_Index)) _map_exp_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("MiniMapScale", out _mini_map_scale_Index)) _mini_map_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxShow", out _vfx_show_Index)) _vfx_show_Index = -1;
                    if (!nameIndexs.TryGetValue("IfNewguildCall", out _if_Newguild_Call_Index)) _if_Newguild_Call_Index = -1;
                    if (!nameIndexs.TryGetValue("FightType", out _fight_type_Index)) _fight_type_Index = -1;
                    if (!nameIndexs.TryGetValue("FightChange", out _fight_change_Index)) _fight_change_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowPkModes", out _show_pk_modes_Index)) _show_pk_modes_Index = -1;
                    if (!nameIndexs.TryGetValue("MeditationWhether", out _meditation_whether_Index)) _meditation_whether_Index = -1;
                    if (!nameIndexs.TryGetValue("IfWorldSupport", out _if_World_Support_Index)) _if_World_Support_Index = -1;
                    if (!nameIndexs.TryGetValue("LeaveMapid", out _leave_mapid_Index)) _leave_mapid_Index = -1;
                    if (!nameIndexs.TryGetValue("IsLeave", out _isLeave_Index)) _isLeave_Index = -1;
                    if (!nameIndexs.TryGetValue("IsDaily", out _isDaily_Index)) _isDaily_Index = -1;
                    if (!nameIndexs.TryGetValue("IsLink", out _isLink_Index)) _isLink_Index = -1;
                    if (!nameIndexs.TryGetValue("MultiLevel", out _multiLevel_Index)) _multiLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("ReceiveType", out _receive_type_Index)) _receive_type_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildeHelpType", out _guildeHelp_type_Index)) _guildeHelp_type_Index = -1;
                    if (!nameIndexs.TryGetValue("IdleAnim", out _idle_anim_Index)) _idle_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("RunAnim", out _run_anim_Index)) _run_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("DodgeAnim", out _dodge_anim_Index)) _dodge_anim_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareMapsetting>(keyCount);
                        _dataIndexCaches = new Dictionary<int, int>(keyCount);
                        ptr = (int*)_compressData.ToPointer();
                        for (int i = 0; i < keyCount; i++)
                        {
                            var key = (int)GetValue(i, 1, ptr);
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
            if(HanderDefine.DataCallBack("Mapsetting", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareMapsetting cfg = null;
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
        public static DeclareMapsetting Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareMapsetting result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Mapsetting", out _compressData))
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
