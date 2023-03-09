//文件是自动生成,请勿手动修改.来自数据文件:npc
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareNpc
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _title_Index = -1;
        private static int _level_Index = -1;
        private static int _res_Index = -1;
        private static int _zoom_Index = -1;
        private static int _pos_X_Index = -1;
        private static int _pos_Y_Index = -1;
        private static int _notation_Index = -1;
        private static int _icon_Index = -1;
        private static int _size_scale_Index = -1;
        private static int _taskShow_Index = -1;
        private static int _logic_body_size_Index = -1;
        private static int _cloneNpcDialog_Index = -1;
        private static int _dialog_Index = -1;
        private static int _speakIds_Index = -1;
        private static int _speech_Index = -1;
        private static int _playerModel_Index = -1;
        private static int _playerModelRes_Index = -1;
        private static int _height_add_Index = -1;
        private static int _professional_Index = -1;
        private static int _professional_dialog_Index = -1;
        private static int _showCfgName_Index = -1;
        private static int _isReq_NPC_Index = -1;
        private static int _funcType_Index = -1;
        private static int _turn_Index = -1;
        private static int _funcParam_Index = -1;
        private static int _npcTalkBtn_Index = -1;
        private static int _talkBtnName_Index = -1;
        private static int _talkBtnCount_Index = -1;
        private static int _btnFunction_Index = -1;
        private static int _npcFormType_Index = -1;
        private static int _bindFunctionID_Index = -1;
        private static int _bindFunctionParams_Index = -1;
        private static int _guildWarCamp_Index = -1;
        #endregion
        #region //私有变量定义
        //NPC编号
        private int _id;
        //NPC名字
        private int _name;
        //称号(hide)
        private int _title;
        //等级(hide)
        private int _level;
        //造型资源编号（资源使用：单方向6帧）
        private int _res;
        //任务模型缩放比(只针对任务对话)
        private int _zoom;
        //对话中模型X坐标
        //untiy参数+180
        private int _pos_X;
        //对话中模型Y坐标
        private int _pos_Y;
        //对话中模型旋转值
        private int _notation;
        //头像资源编号
        private int _icon;
        //模型缩放（百分比）
        private int _size_scale;
        //NPC隐藏（用于任务,任务类型_任务ID;任务类型_任务ID）(@;@_@)主线任务配0_任务ID
        private int _taskShow;
        //逻辑半径(单位厘米)(hide)
        private int _logic_body_size;
        //主线任务-进入副本NPC对话描述 hide
        private int _cloneNpcDialog;
        //NPC功能面板上的简单对白 hide
        private int _dialog;
        //发言ID列表分号隔开
        private int _speakIds;
        //语音资源名 hide
        private int _speech;
        //是否使用玩家模型（0不使用/1使用）
        private int _playerModel;
        //使用玩家的模型ID（身体ID_武器ID_阵道ID_光环ID_坐骑id_魂甲id）
        private int _playerModelRes;
        //增加的高度，相对于地面的高度，单位厘米（hide)
        private int _height_add;
        //NPC对话时需要职业（-1为所有职业）
        private int _professional;
        //职业对话 hide
        private int _professional_dialog;
        //是否显示配置表名字0否1是2面片模型
        private int _showCfgName;
        //是否像服务器请求消息（0不请求）
        private int _isReq_NPC;
        //NPC的功能类型,0:默认,1:进入一个功能,2:进入副本,3:切换场景
        private int _funcType;
        //NPC对话时是否转动（0转动1不转）hide
        private int _turn;
        //和前一列关联,funcType=0,不填
        //funcType=1,填写functionstartID
        //funcType=2,填写clonemapID
        //funcType=3,填写mapsettingID
        private int _funcParam;
        //NPC对话功能面板（1.显示按钮 2.仙盟副本按钮 3.显示倒计时按钮）
        private int _npcTalkBtn;
        //按钮显示文字
        private int _talkBtnName;
        //按钮显倒计时(hide)
        private int _talkBtnCount;
        private int _btnFunction;
        //填写预设好的npc窗体,1:通用主线副本描述
        private int _npcFormType;
        //当前NPC绑定的功能,碰触并触发. hide
        private int _bindFunctionID;
        //当前NPC绑定的功能参数(需要 对应功能来解析并处理此参数) hide
        private int _bindFunctionParams;
        //仙盟战专用，标识阵营（0攻方1守方）
        //（hide）
        private int _guildWarCamp;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string Title { get{ return HanderDefine.SetStingCallBack(_title); }}
        public int Level { get{ return _level; }}
        public int Res { get{ return _res; }}
        public int Zoom { get{ return _zoom; }}
        public int PosX { get{ return _pos_X; }}
        public int PosY { get{ return _pos_Y; }}
        public int Notation { get{ return _notation; }}
        public int Icon { get{ return _icon; }}
        public int SizeScale { get{ return _size_scale; }}
        public string TaskShow { get{ return HanderDefine.SetStingCallBack(_taskShow); }}
        public int LogicBodySize { get{ return _logic_body_size; }}
        public string CloneNpcDialog { get{ return HanderDefine.SetStingCallBack(_cloneNpcDialog); }}
        public string Dialog { get{ return HanderDefine.SetStingCallBack(_dialog); }}
        public string SpeakIds { get{ return HanderDefine.SetStingCallBack(_speakIds); }}
        public string Speech { get{ return HanderDefine.SetStingCallBack(_speech); }}
        public int PlayerModel { get{ return _playerModel; }}
        public string PlayerModelRes { get{ return HanderDefine.SetStingCallBack(_playerModelRes); }}
        public int HeightAdd { get{ return _height_add; }}
        public int Professional { get{ return _professional; }}
        public string ProfessionalDialog { get{ return HanderDefine.SetStingCallBack(_professional_dialog); }}
        public int ShowCfgName { get{ return _showCfgName; }}
        public int IsReqNPC { get{ return _isReq_NPC; }}
        public int FuncType { get{ return _funcType; }}
        public int Turn { get{ return _turn; }}
        public int FuncParam { get{ return _funcParam; }}
        public int NpcTalkBtn { get{ return _npcTalkBtn; }}
        public string TalkBtnName { get{ return HanderDefine.SetStingCallBack(_talkBtnName); }}
        public int TalkBtnCount { get{ return _talkBtnCount; }}
        public int BtnFunction { get{ return _btnFunction; }}
        public int NpcFormType { get{ return _npcFormType; }}
        public int BindFunctionID { get{ return _bindFunctionID; }}
        public string BindFunctionParams { get{ return HanderDefine.SetStingCallBack(_bindFunctionParams); }}
        public int GuildWarCamp { get{ return _guildWarCamp; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareNpc cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareNpc> _dataCaches = null;
        public static Dictionary<int, DeclareNpc> CacheData
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
                        if (HanderDefine.DataCallBack("Npc", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareNpc cfg = null;
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
        private unsafe static DeclareNpc LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareNpc();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._title = (int)GetValue(keyIndex, _title_Index, ptr);
            tmp._level = (int)GetValue(keyIndex, _level_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._zoom = (int)GetValue(keyIndex, _zoom_Index, ptr);
            tmp._pos_X = (int)GetValue(keyIndex, _pos_X_Index, ptr);
            tmp._pos_Y = (int)GetValue(keyIndex, _pos_Y_Index, ptr);
            tmp._notation = (int)GetValue(keyIndex, _notation_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._size_scale = (int)GetValue(keyIndex, _size_scale_Index, ptr);
            tmp._taskShow = (int)GetValue(keyIndex, _taskShow_Index, ptr);
            tmp._logic_body_size = (int)GetValue(keyIndex, _logic_body_size_Index, ptr);
            tmp._cloneNpcDialog = (int)GetValue(keyIndex, _cloneNpcDialog_Index, ptr);
            tmp._dialog = (int)GetValue(keyIndex, _dialog_Index, ptr);
            tmp._speakIds = (int)GetValue(keyIndex, _speakIds_Index, ptr);
            tmp._speech = (int)GetValue(keyIndex, _speech_Index, ptr);
            tmp._playerModel = (int)GetValue(keyIndex, _playerModel_Index, ptr);
            tmp._playerModelRes = (int)GetValue(keyIndex, _playerModelRes_Index, ptr);
            tmp._height_add = (int)GetValue(keyIndex, _height_add_Index, ptr);
            tmp._professional = (int)GetValue(keyIndex, _professional_Index, ptr);
            tmp._professional_dialog = (int)GetValue(keyIndex, _professional_dialog_Index, ptr);
            tmp._showCfgName = (int)GetValue(keyIndex, _showCfgName_Index, ptr);
            tmp._isReq_NPC = (int)GetValue(keyIndex, _isReq_NPC_Index, ptr);
            tmp._funcType = (int)GetValue(keyIndex, _funcType_Index, ptr);
            tmp._turn = (int)GetValue(keyIndex, _turn_Index, ptr);
            tmp._funcParam = (int)GetValue(keyIndex, _funcParam_Index, ptr);
            tmp._npcTalkBtn = (int)GetValue(keyIndex, _npcTalkBtn_Index, ptr);
            tmp._talkBtnName = (int)GetValue(keyIndex, _talkBtnName_Index, ptr);
            tmp._talkBtnCount = (int)GetValue(keyIndex, _talkBtnCount_Index, ptr);
            tmp._btnFunction = (int)GetValue(keyIndex, _btnFunction_Index, ptr);
            tmp._npcFormType = (int)GetValue(keyIndex, _npcFormType_Index, ptr);
            tmp._bindFunctionID = (int)GetValue(keyIndex, _bindFunctionID_Index, ptr);
            tmp._bindFunctionParams = (int)GetValue(keyIndex, _bindFunctionParams_Index, ptr);
            tmp._guildWarCamp = (int)GetValue(keyIndex, _guildWarCamp_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Npc", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Title", out _title_Index)) _title_Index = -1;
                    if (!nameIndexs.TryGetValue("Level", out _level_Index)) _level_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("Zoom", out _zoom_Index)) _zoom_Index = -1;
                    if (!nameIndexs.TryGetValue("PosX", out _pos_X_Index)) _pos_X_Index = -1;
                    if (!nameIndexs.TryGetValue("PosY", out _pos_Y_Index)) _pos_Y_Index = -1;
                    if (!nameIndexs.TryGetValue("Notation", out _notation_Index)) _notation_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("SizeScale", out _size_scale_Index)) _size_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("TaskShow", out _taskShow_Index)) _taskShow_Index = -1;
                    if (!nameIndexs.TryGetValue("LogicBodySize", out _logic_body_size_Index)) _logic_body_size_Index = -1;
                    if (!nameIndexs.TryGetValue("CloneNpcDialog", out _cloneNpcDialog_Index)) _cloneNpcDialog_Index = -1;
                    if (!nameIndexs.TryGetValue("Dialog", out _dialog_Index)) _dialog_Index = -1;
                    if (!nameIndexs.TryGetValue("SpeakIds", out _speakIds_Index)) _speakIds_Index = -1;
                    if (!nameIndexs.TryGetValue("Speech", out _speech_Index)) _speech_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayerModel", out _playerModel_Index)) _playerModel_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayerModelRes", out _playerModelRes_Index)) _playerModelRes_Index = -1;
                    if (!nameIndexs.TryGetValue("HeightAdd", out _height_add_Index)) _height_add_Index = -1;
                    if (!nameIndexs.TryGetValue("Professional", out _professional_Index)) _professional_Index = -1;
                    if (!nameIndexs.TryGetValue("ProfessionalDialog", out _professional_dialog_Index)) _professional_dialog_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowCfgName", out _showCfgName_Index)) _showCfgName_Index = -1;
                    if (!nameIndexs.TryGetValue("IsReqNPC", out _isReq_NPC_Index)) _isReq_NPC_Index = -1;
                    if (!nameIndexs.TryGetValue("FuncType", out _funcType_Index)) _funcType_Index = -1;
                    if (!nameIndexs.TryGetValue("Turn", out _turn_Index)) _turn_Index = -1;
                    if (!nameIndexs.TryGetValue("FuncParam", out _funcParam_Index)) _funcParam_Index = -1;
                    if (!nameIndexs.TryGetValue("NpcTalkBtn", out _npcTalkBtn_Index)) _npcTalkBtn_Index = -1;
                    if (!nameIndexs.TryGetValue("TalkBtnName", out _talkBtnName_Index)) _talkBtnName_Index = -1;
                    if (!nameIndexs.TryGetValue("TalkBtnCount", out _talkBtnCount_Index)) _talkBtnCount_Index = -1;
                    if (!nameIndexs.TryGetValue("BtnFunction", out _btnFunction_Index)) _btnFunction_Index = -1;
                    if (!nameIndexs.TryGetValue("NpcFormType", out _npcFormType_Index)) _npcFormType_Index = -1;
                    if (!nameIndexs.TryGetValue("BindFunctionID", out _bindFunctionID_Index)) _bindFunctionID_Index = -1;
                    if (!nameIndexs.TryGetValue("BindFunctionParams", out _bindFunctionParams_Index)) _bindFunctionParams_Index = -1;
                    if (!nameIndexs.TryGetValue("GuildWarCamp", out _guildWarCamp_Index)) _guildWarCamp_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareNpc>(keyCount);
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
            if(HanderDefine.DataCallBack("Npc", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareNpc cfg = null;
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
        public static DeclareNpc Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareNpc result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Npc", out _compressData))
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
