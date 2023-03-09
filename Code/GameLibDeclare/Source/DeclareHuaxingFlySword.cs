//文件是自动生成,请勿手动修改.来自数据文件:HuaxingFlySword
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareHuaxingFlySword
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _icon_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _model_X_pos_Index = -1;
        private static int _model_R_Z_pos_Index = -1;
        private static int _show_model_y_pos_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _active_condition_Index = -1;
        private static int _variable_Index = -1;
        private static int _active_describe_Index = -1;
        private static int _active_item_Index = -1;
        private static int _rent_att_Index = -1;
        private static int _star_itemnum_Index = -1;
        private static int _passive_skill_Index = -1;
        private static int _use_Skill_Index = -1;
        private static int _player_Skill_Index = -1;
        private static int _if_show_Index = -1;
        private static int _normal_Skill_Index = -1;
        private static int _lingpo_model_y_pos_Index = -1;
        private static int _lingpo_model_X_pos_Index = -1;
        private static int _lingpo_camera_size_Index = -1;
        private static int _copy_pos_x_Index = -1;
        private static int _copy_pos_y_Index = -1;
        private static int _copy_rot_y_Index = -1;
        private static int _follow_height_Index = -1;
        private static int _follow_offset_height_Index = -1;
        private static int _show_offset_height_Index = -1;
        private static int _describe_Index = -1;
        #endregion
        #region //私有变量定义
        //模型ID对应modelconfig表主键
        private int _id;
        //翅膀名称
        private int _name;
        //分类
        private int _type;
        //图标hide
        private int _icon;
        //模型位置的Y轴坐标hide
        private int _model_y_pos;
        //模型位置的X轴坐标
        //hide
        private int _model_X_pos;
        //模型位置的Z轴旋转的坐标
        //hide
        private int _model_R_Z_pos;
        //在获取界面中，模型位置的Y轴坐标hide
        private int _show_model_y_pos;
        //相机镜头万分比hide
        private int _camera_size;
        //激活需要的条件（0物品激活，1服务器激活，2，条件激活）
        private int _active_condition;
        //条件激活需要的条件
        private int _variable;
        //服务器激活的条件描述(hide)
        private int _active_describe;
        //激活需要的物品
        private int _active_item;
        //属性类型_激活属性_升星属性(@;@_@)
        private int _rent_att;
        //升星需要的数量 阶数_数量(@;@_@)
        private int _star_itemnum;
        //激活学习的技能
        private int _passive_skill;
        //主动技能
        private int _use_Skill;
        //放技能的主角动作的技能
        private int _player_Skill;
        //在剑灵主界面的板子资源(正面_背面）
        private int _if_show;
        //剑灵普通技能
        private int _normal_Skill;
        //模型位置的Y轴坐标hide
        private int _lingpo_model_y_pos;
        //模型位置的X轴坐标
        //hide
        private int _lingpo_model_X_pos;
        //相机镜头万分比hide
        private int _lingpo_camera_size;
        //副本中界面的x轴坐标(hide)
        private int _copy_pos_x;
        //副本中界面的y轴坐标(hide)
        private int _copy_pos_y;
        //副本中界面的y轴旋转(hide)
        private int _copy_rot_y;
        //剑灵跟随高度，只针对剑灵有效，单位厘米（hide）
        private int _follow_height;
        //跟随高度相对于背部武器挂点的偏移值，只有飞剑有效(单位厘米)（hide）
        private int _follow_offset_height;
        //展示高度相对于背部武器挂点的偏移值，只有飞剑有效(单位厘米)（hide）
        private int _show_offset_height;
        //背景描述
        private int _describe;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Icon { get{ return _icon; }}
        public int ModelYPos { get{ return _model_y_pos; }}
        public int ModelXPos { get{ return _model_X_pos; }}
        public int ModelRZPos { get{ return _model_R_Z_pos; }}
        public int ShowModelYPos { get{ return _show_model_y_pos; }}
        public int CameraSize { get{ return _camera_size; }}
        public int ActiveCondition { get{ return _active_condition; }}
        public string Variable { get{ return HanderDefine.SetStingCallBack(_variable); }}
        public string ActiveDescribe { get{ return HanderDefine.SetStingCallBack(_active_describe); }}
        public int ActiveItem { get{ return _active_item; }}
        public string RentAtt { get{ return HanderDefine.SetStingCallBack(_rent_att); }}
        public string StarItemnum { get{ return HanderDefine.SetStingCallBack(_star_itemnum); }}
        public int PassiveSkill { get{ return _passive_skill; }}
        public int UseSkill { get{ return _use_Skill; }}
        public int PlayerSkill { get{ return _player_Skill; }}
        public string IfShow { get{ return HanderDefine.SetStingCallBack(_if_show); }}
        public int NormalSkill { get{ return _normal_Skill; }}
        public int LingpoModelYPos { get{ return _lingpo_model_y_pos; }}
        public int LingpoModelXPos { get{ return _lingpo_model_X_pos; }}
        public int LingpoCameraSize { get{ return _lingpo_camera_size; }}
        public int CopyPosX { get{ return _copy_pos_x; }}
        public int CopyPosY { get{ return _copy_pos_y; }}
        public int CopyRotY { get{ return _copy_rot_y; }}
        public string FollowHeight { get{ return HanderDefine.SetStingCallBack(_follow_height); }}
        public string FollowOffsetHeight { get{ return HanderDefine.SetStingCallBack(_follow_offset_height); }}
        public string ShowOffsetHeight { get{ return HanderDefine.SetStingCallBack(_show_offset_height); }}
        public string Describe { get{ return HanderDefine.SetStingCallBack(_describe); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareHuaxingFlySword cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareHuaxingFlySword> _dataCaches = null;
        public static Dictionary<int, DeclareHuaxingFlySword> CacheData
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
                        if (HanderDefine.DataCallBack("HuaxingFlySword", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareHuaxingFlySword cfg = null;
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
        private unsafe static DeclareHuaxingFlySword LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareHuaxingFlySword();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._model_X_pos = (int)GetValue(keyIndex, _model_X_pos_Index, ptr);
            tmp._model_R_Z_pos = (int)GetValue(keyIndex, _model_R_Z_pos_Index, ptr);
            tmp._show_model_y_pos = (int)GetValue(keyIndex, _show_model_y_pos_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._active_condition = (int)GetValue(keyIndex, _active_condition_Index, ptr);
            tmp._variable = (int)GetValue(keyIndex, _variable_Index, ptr);
            tmp._active_describe = (int)GetValue(keyIndex, _active_describe_Index, ptr);
            tmp._active_item = (int)GetValue(keyIndex, _active_item_Index, ptr);
            tmp._rent_att = (int)GetValue(keyIndex, _rent_att_Index, ptr);
            tmp._star_itemnum = (int)GetValue(keyIndex, _star_itemnum_Index, ptr);
            tmp._passive_skill = (int)GetValue(keyIndex, _passive_skill_Index, ptr);
            tmp._use_Skill = (int)GetValue(keyIndex, _use_Skill_Index, ptr);
            tmp._player_Skill = (int)GetValue(keyIndex, _player_Skill_Index, ptr);
            tmp._if_show = (int)GetValue(keyIndex, _if_show_Index, ptr);
            tmp._normal_Skill = (int)GetValue(keyIndex, _normal_Skill_Index, ptr);
            tmp._lingpo_model_y_pos = (int)GetValue(keyIndex, _lingpo_model_y_pos_Index, ptr);
            tmp._lingpo_model_X_pos = (int)GetValue(keyIndex, _lingpo_model_X_pos_Index, ptr);
            tmp._lingpo_camera_size = (int)GetValue(keyIndex, _lingpo_camera_size_Index, ptr);
            tmp._copy_pos_x = (int)GetValue(keyIndex, _copy_pos_x_Index, ptr);
            tmp._copy_pos_y = (int)GetValue(keyIndex, _copy_pos_y_Index, ptr);
            tmp._copy_rot_y = (int)GetValue(keyIndex, _copy_rot_y_Index, ptr);
            tmp._follow_height = (int)GetValue(keyIndex, _follow_height_Index, ptr);
            tmp._follow_offset_height = (int)GetValue(keyIndex, _follow_offset_height_Index, ptr);
            tmp._show_offset_height = (int)GetValue(keyIndex, _show_offset_height_Index, ptr);
            tmp._describe = (int)GetValue(keyIndex, _describe_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("HuaxingFlySword", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelXPos", out _model_X_pos_Index)) _model_X_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelRZPos", out _model_R_Z_pos_Index)) _model_R_Z_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModelYPos", out _show_model_y_pos_Index)) _show_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveCondition", out _active_condition_Index)) _active_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("Variable", out _variable_Index)) _variable_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveDescribe", out _active_describe_Index)) _active_describe_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveItem", out _active_item_Index)) _active_item_Index = -1;
                    if (!nameIndexs.TryGetValue("RentAtt", out _rent_att_Index)) _rent_att_Index = -1;
                    if (!nameIndexs.TryGetValue("StarItemnum", out _star_itemnum_Index)) _star_itemnum_Index = -1;
                    if (!nameIndexs.TryGetValue("PassiveSkill", out _passive_skill_Index)) _passive_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("UseSkill", out _use_Skill_Index)) _use_Skill_Index = -1;
                    if (!nameIndexs.TryGetValue("PlayerSkill", out _player_Skill_Index)) _player_Skill_Index = -1;
                    if (!nameIndexs.TryGetValue("IfShow", out _if_show_Index)) _if_show_Index = -1;
                    if (!nameIndexs.TryGetValue("NormalSkill", out _normal_Skill_Index)) _normal_Skill_Index = -1;
                    if (!nameIndexs.TryGetValue("LingpoModelYPos", out _lingpo_model_y_pos_Index)) _lingpo_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("LingpoModelXPos", out _lingpo_model_X_pos_Index)) _lingpo_model_X_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("LingpoCameraSize", out _lingpo_camera_size_Index)) _lingpo_camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("CopyPosX", out _copy_pos_x_Index)) _copy_pos_x_Index = -1;
                    if (!nameIndexs.TryGetValue("CopyPosY", out _copy_pos_y_Index)) _copy_pos_y_Index = -1;
                    if (!nameIndexs.TryGetValue("CopyRotY", out _copy_rot_y_Index)) _copy_rot_y_Index = -1;
                    if (!nameIndexs.TryGetValue("FollowHeight", out _follow_height_Index)) _follow_height_Index = -1;
                    if (!nameIndexs.TryGetValue("FollowOffsetHeight", out _follow_offset_height_Index)) _follow_offset_height_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowOffsetHeight", out _show_offset_height_Index)) _show_offset_height_Index = -1;
                    if (!nameIndexs.TryGetValue("Describe", out _describe_Index)) _describe_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareHuaxingFlySword>(keyCount);
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
            if(HanderDefine.DataCallBack("HuaxingFlySword", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareHuaxingFlySword cfg = null;
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
        public static DeclareHuaxingFlySword Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareHuaxingFlySword result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("HuaxingFlySword", out _compressData))
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
