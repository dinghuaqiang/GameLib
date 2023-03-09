//文件是自动生成,请勿手动修改.来自数据文件:pet
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclarePet
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _order_Index = -1;
        private static int _isIgnore_Index = -1;
        private static int _if_fashion_Index = -1;
        private static int _icon_Index = -1;
        private static int _quality_Index = -1;
        private static int _model_Index = -1;
        private static int _scene_scale_Index = -1;
        private static int _ui_scale_Index = -1;
        private static int _ui_model_height_Index = -1;
        private static int _get_ui_height_Index = -1;
        private static int _scene_camera_y_add_Index = -1;
        private static int _strike_distance_Index = -1;
        private static int _unlock_Index = -1;
        private static int _equip_Index = -1;
        private static int _baseskill_Index = -1;
        private static int _pet_skill_Index = -1;
        private static int _attribute_Index = -1;
        private static int _full_degress_Index = -1;
        private static int _max_degree_Index = -1;
        private static int _isShow_Index = -1;
        private static int _mainTransfom_Index = -1;
        private static int _fllow_rank_Index = -1;
        #endregion
        #region //私有变量定义
        //流水号
        private int _id;
        //宠物名字
        private int _name;
        //排序hide
        private int _order;
        //是否显示在列表中，方便地区版本需要屏蔽某些化形
        //0不显示
        //1显示
        //（hide）
        private int _isIgnore;
        //是否是时装（0，是；1不是：如果是时装，则不显示在化形界面中，只利用化形的出战等基础逻辑，不在化形中增加属性和技能）
        private int _if_fashion;
        //头像
        private int _icon;
        //宠物品质(：1.白 2.绿 3.蓝 4.紫 5.橙 6.金 7.红,8粉,9暗金.10幻彩)
        private int _quality;
        //外观ID
        private int _model;
        //在场景上的缩放值(百分比)
        private int _scene_scale;
        //在ui上的缩放值
        private int _ui_scale;
        //在界面上的高度(hide)
        private int _ui_model_height;
        //在宠物获得展示界面的高度(hide)
        private int _get_ui_height;
        //摄像机Y轴旋转角度（-180正面）hide
        private int _scene_camera_y_add;
        //受击半径（厘米）
        private int _strike_distance;
        //解锁条件(类型ID_类型参数；0.任务；1.前置满阶；2.道具；3.宠物功能开启获得；(@;@_@))
        private int _unlock;
        //是否拥有装备栏（0.无；1.有）
        private int _equip;
        //普攻技能ID
        private int _baseskill;
        //宠物附带战斗技能
        private int _pet_skill;
        //初始属性：属性类型_数值，属性类型1_数值，(@;@_@)
        private int _attribute;
        //满阶阶数，超过之后显示为晋升
        private int _full_degress;
        //最大阶数
        private int _max_degree;
        //0表示不显示装备，1显示人物装备2显示宠物装备，3显示坐骑装备
        private int _isShow;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        private int _mainTransfom;
        //宠物助阵 跟随排序（hide）越小越靠前
        private int _fllow_rank;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Order { get{ return _order; }}
        public int IsIgnore { get{ return _isIgnore; }}
        public int IfFashion { get{ return _if_fashion; }}
        public int Icon { get{ return _icon; }}
        public int Quality { get{ return _quality; }}
        public int Model { get{ return _model; }}
        public int SceneScale { get{ return _scene_scale; }}
        public int UiScale { get{ return _ui_scale; }}
        public int UiModelHeight { get{ return _ui_model_height; }}
        public int GetUiHeight { get{ return _get_ui_height; }}
        public int SceneCameraYAdd { get{ return _scene_camera_y_add; }}
        public int StrikeDistance { get{ return _strike_distance; }}
        public string Unlock { get{ return HanderDefine.SetStingCallBack(_unlock); }}
        public int Equip { get{ return _equip; }}
        public int Baseskill { get{ return _baseskill; }}
        public int PetSkill { get{ return _pet_skill; }}
        public string Attribute { get{ return HanderDefine.SetStingCallBack(_attribute); }}
        public int FullDegress { get{ return _full_degress; }}
        public int MaxDegree { get{ return _max_degree; }}
        public int IsShow { get{ return _isShow; }}
        public string MainTransfom { get{ return HanderDefine.SetStingCallBack(_mainTransfom); }}
        public int FllowRank { get{ return _fllow_rank; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclarePet cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclarePet> _dataCaches = null;
        public static Dictionary<int, DeclarePet> CacheData
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
                        if (HanderDefine.DataCallBack("Pet", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclarePet cfg = null;
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
        private unsafe static DeclarePet LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclarePet();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._order = (int)GetValue(keyIndex, _order_Index, ptr);
            tmp._isIgnore = (int)GetValue(keyIndex, _isIgnore_Index, ptr);
            tmp._if_fashion = (int)GetValue(keyIndex, _if_fashion_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._scene_scale = (int)GetValue(keyIndex, _scene_scale_Index, ptr);
            tmp._ui_scale = (int)GetValue(keyIndex, _ui_scale_Index, ptr);
            tmp._ui_model_height = (int)GetValue(keyIndex, _ui_model_height_Index, ptr);
            tmp._get_ui_height = (int)GetValue(keyIndex, _get_ui_height_Index, ptr);
            tmp._scene_camera_y_add = (int)GetValue(keyIndex, _scene_camera_y_add_Index, ptr);
            tmp._strike_distance = (int)GetValue(keyIndex, _strike_distance_Index, ptr);
            tmp._unlock = (int)GetValue(keyIndex, _unlock_Index, ptr);
            tmp._equip = (int)GetValue(keyIndex, _equip_Index, ptr);
            tmp._baseskill = (int)GetValue(keyIndex, _baseskill_Index, ptr);
            tmp._pet_skill = (int)GetValue(keyIndex, _pet_skill_Index, ptr);
            tmp._attribute = (int)GetValue(keyIndex, _attribute_Index, ptr);
            tmp._full_degress = (int)GetValue(keyIndex, _full_degress_Index, ptr);
            tmp._max_degree = (int)GetValue(keyIndex, _max_degree_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._mainTransfom = (int)GetValue(keyIndex, _mainTransfom_Index, ptr);
            tmp._fllow_rank = (int)GetValue(keyIndex, _fllow_rank_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Pet", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Order", out _order_Index)) _order_Index = -1;
                    if (!nameIndexs.TryGetValue("IsIgnore", out _isIgnore_Index)) _isIgnore_Index = -1;
                    if (!nameIndexs.TryGetValue("IfFashion", out _if_fashion_Index)) _if_fashion_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneScale", out _scene_scale_Index)) _scene_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("UiScale", out _ui_scale_Index)) _ui_scale_Index = -1;
                    if (!nameIndexs.TryGetValue("UiModelHeight", out _ui_model_height_Index)) _ui_model_height_Index = -1;
                    if (!nameIndexs.TryGetValue("GetUiHeight", out _get_ui_height_Index)) _get_ui_height_Index = -1;
                    if (!nameIndexs.TryGetValue("SceneCameraYAdd", out _scene_camera_y_add_Index)) _scene_camera_y_add_Index = -1;
                    if (!nameIndexs.TryGetValue("StrikeDistance", out _strike_distance_Index)) _strike_distance_Index = -1;
                    if (!nameIndexs.TryGetValue("Unlock", out _unlock_Index)) _unlock_Index = -1;
                    if (!nameIndexs.TryGetValue("Equip", out _equip_Index)) _equip_Index = -1;
                    if (!nameIndexs.TryGetValue("Baseskill", out _baseskill_Index)) _baseskill_Index = -1;
                    if (!nameIndexs.TryGetValue("PetSkill", out _pet_skill_Index)) _pet_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("Attribute", out _attribute_Index)) _attribute_Index = -1;
                    if (!nameIndexs.TryGetValue("FullDegress", out _full_degress_Index)) _full_degress_Index = -1;
                    if (!nameIndexs.TryGetValue("MaxDegree", out _max_degree_Index)) _max_degree_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTransfom", out _mainTransfom_Index)) _mainTransfom_Index = -1;
                    if (!nameIndexs.TryGetValue("FllowRank", out _fllow_rank_Index)) _fllow_rank_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclarePet>(keyCount);
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
            if(HanderDefine.DataCallBack("Pet", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclarePet cfg = null;
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
        public static DeclarePet Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclarePet result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Pet", out _compressData))
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
