//文件是自动生成,请勿手动修改.来自数据文件:HuaxingHorse
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareHuaxingHorse
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _order_Index = -1;
        private static int _isIgnore_Index = -1;
        private static int _if_fashion_Index = -1;
        private static int _icon_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _beishi_model_y_pos_Index = -1;
        private static int _show_model_y_pos_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _camera_rotation_Index = -1;
        private static int _active_condition_Index = -1;
        private static int _rot_by_scene_height_Index = -1;
        private static int _scene_camera_y_add_Index = -1;
        private static int _scene_camera_disadd_Index = -1;
        private static int _active_item_Index = -1;
        private static int _rent_att_Index = -1;
        private static int _star_itemnum_Index = -1;
        private static int _passive_skill_Index = -1;
        private static int _isShow_Index = -1;
        private static int _mainTransfom_Index = -1;
        private static int _scene_camera_pitchadd_Index = -1;
        private static int _anim_speed_Index = -1;
        private static int _can_sit_down_Index = -1;
        #endregion
        #region //私有变量定义
        //模型ID
        private int _id;
        //名称
        private int _name;
        //排序
        private int _order;
        //是否显示在列表中，方便地区版本需要屏蔽某些化形
        //0不显示
        //1显示
        //（hide）
        private int _isIgnore;
        //是否是时装（0，是；1不是：如果是时装，则不显示在化形界面中，只利用化形的出战等基础逻辑，不在化形中增加属性和技能）
        private int _if_fashion;
        //图标hide
        private int _icon;
        //模型位置的Y轴坐标hide
        private int _model_y_pos;
        //上坐骑之后背饰得Y轴偏移hide
        private int _beishi_model_y_pos;
        //在获取界面中，模型位置的Y轴坐标hide
        private int _show_model_y_pos;
        //相机镜头万分比hide
        private int _camera_size;
        //相机旋转x_y_z  hide
        private int _camera_rotation;
        //激活需要的条件（0物品激活，1服务器激活）
        private int _active_condition;
        //是否跟随场景高度进行旋转，建议飞行坐骑不跟随旋转（hide)
        private int _rot_by_scene_height;
        //摄像机Y轴高度（单位厘米）
        private int _scene_camera_y_add;
        //场景中对于摄像机跟随距离的加成(单位厘米)
        private int _scene_camera_disadd;
        //激活需要的物品
        private int _active_item;
        //属性类型_激活属性_升星属性(@;@_@)
        private int _rent_att;
        //升星需要的数量  阶数_数量(@;@_@)
        private int _star_itemnum;
        //激活学习的技能
        private int _passive_skill;
        //0表示不显示装备，1显示人物装备2显示宠物装备，3显示坐骑装备
        private int _isShow;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        private int _mainTransfom;
        //场景中对于摄像机pitch加成(单位角度)
        private int _scene_camera_pitchadd;
        //动画播放速度（hide)
        private int _anim_speed;
        //是否可以在坐骑上打坐（0不可以，1可以）
        private int _can_sit_down;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Order { get{ return _order; }}
        public int IsIgnore { get{ return _isIgnore; }}
        public int IfFashion { get{ return _if_fashion; }}
        public int Icon { get{ return _icon; }}
        public int ModelYPos { get{ return _model_y_pos; }}
        public int BeishiModelYPos { get{ return _beishi_model_y_pos; }}
        public int ShowModelYPos { get{ return _show_model_y_pos; }}
        public int CameraSize { get{ return _camera_size; }}
        public string CameraRotation { get{ return HanderDefine.SetStingCallBack(_camera_rotation); }}
        public int ActiveCondition { get{ return _active_condition; }}
        public int RotBySceneHeight { get{ return _rot_by_scene_height; }}
        public int SceneCameraYAdd { get{ return _scene_camera_y_add; }}
        public int SceneCameraDisadd { get{ return _scene_camera_disadd; }}
        public int ActiveItem { get{ return _active_item; }}
        public string RentAtt { get{ return HanderDefine.SetStingCallBack(_rent_att); }}
        public string StarItemnum { get{ return HanderDefine.SetStingCallBack(_star_itemnum); }}
        public int PassiveSkill { get{ return _passive_skill; }}
        public int IsShow { get{ return _isShow; }}
        public string MainTransfom { get{ return HanderDefine.SetStingCallBack(_mainTransfom); }}
        public int SceneCameraPitchadd { get{ return _scene_camera_pitchadd; }}
        public int AnimSpeed { get{ return _anim_speed; }}
        public int CanSitDown { get{ return _can_sit_down; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareHuaxingHorse cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareHuaxingHorse> _dataCaches = null;
        public static Dictionary<int, DeclareHuaxingHorse> CacheData
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
                        if (HanderDefine.DataCallBack("HuaxingHorse", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareHuaxingHorse cfg = null;
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
        private unsafe static DeclareHuaxingHorse LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareHuaxingHorse();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._order = (int)GetValue(keyIndex, _order_Index, ptr);
            tmp._isIgnore = (int)GetValue(keyIndex, _isIgnore_Index, ptr);
            tmp._if_fashion = (int)GetValue(keyIndex, _if_fashion_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._beishi_model_y_pos = (int)GetValue(keyIndex, _beishi_model_y_pos_Index, ptr);
            tmp._show_model_y_pos = (int)GetValue(keyIndex, _show_model_y_pos_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._camera_rotation = (int)GetValue(keyIndex, _camera_rotation_Index, ptr);
            tmp._active_condition = (int)GetValue(keyIndex, _active_condition_Index, ptr);
            tmp._rot_by_scene_height = (int)GetValue(keyIndex, _rot_by_scene_height_Index, ptr);
            tmp._scene_camera_y_add = (int)GetValue(keyIndex, _scene_camera_y_add_Index, ptr);
            tmp._scene_camera_disadd = (int)GetValue(keyIndex, _scene_camera_disadd_Index, ptr);
            tmp._active_item = (int)GetValue(keyIndex, _active_item_Index, ptr);
            tmp._rent_att = (int)GetValue(keyIndex, _rent_att_Index, ptr);
            tmp._star_itemnum = (int)GetValue(keyIndex, _star_itemnum_Index, ptr);
            tmp._passive_skill = (int)GetValue(keyIndex, _passive_skill_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._mainTransfom = (int)GetValue(keyIndex, _mainTransfom_Index, ptr);
            tmp._scene_camera_pitchadd = (int)GetValue(keyIndex, _scene_camera_pitchadd_Index, ptr);
            tmp._anim_speed = (int)GetValue(keyIndex, _anim_speed_Index, ptr);
            tmp._can_sit_down = (int)GetValue(keyIndex, _can_sit_down_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("HuaxingHorse", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Order", out _order_Index)) _order_Index = -1;
                    if (!nameIndexs.TryGetValue("IsIgnore", out _isIgnore_Index)) _isIgnore_Index = -1;
                    if (!nameIndexs.TryGetValue("IfFashion", out _if_fashion_Index)) _if_fashion_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("BeishiModelYPos", out _beishi_model_y_pos_Index)) _beishi_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModelYPos", out _show_model_y_pos_Index)) _show_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraRotation", out _camera_rotation_Index)) _camera_rotation_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveCondition", out _active_condition_Index)) _active_condition_Index = -1;
                    if (!nameIndexs.TryGetValue("RotBySceneHeight", out _rot_by_scene_height_Index)) _rot_by_scene_height_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneCameraYAdd", out _scene_camera_y_add_Index)) _scene_camera_y_add_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneCameraDisadd", out _scene_camera_disadd_Index)) _scene_camera_disadd_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveItem", out _active_item_Index)) _active_item_Index = -1;
                    if (!nameIndexs.TryGetValue("RentAtt", out _rent_att_Index)) _rent_att_Index = -1;
                    if (!nameIndexs.TryGetValue("StarItemnum", out _star_itemnum_Index)) _star_itemnum_Index = -1;
                    if (!nameIndexs.TryGetValue("PassiveSkill", out _passive_skill_Index)) _passive_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTransfom", out _mainTransfom_Index)) _mainTransfom_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneCameraPitchadd", out _scene_camera_pitchadd_Index)) _scene_camera_pitchadd_Index = -1;
                    if (!nameIndexs.TryGetValue("AnimSpeed", out _anim_speed_Index)) _anim_speed_Index = -1;
                    if (!nameIndexs.TryGetValue("CanSitDown", out _can_sit_down_Index)) _can_sit_down_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareHuaxingHorse>(keyCount);
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
            if(HanderDefine.DataCallBack("HuaxingHorse", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareHuaxingHorse cfg = null;
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
        public static DeclareHuaxingHorse Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareHuaxingHorse result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("HuaxingHorse", out _compressData))
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
