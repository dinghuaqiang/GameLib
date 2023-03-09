//文件是自动生成,请勿手动修改.来自数据文件:fashion
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFashion
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _sheet_Index = -1;
        private static int _type_Index = -1;
        private static int _order_Index = -1;
        private static int _quality_Index = -1;
        private static int _res_Index = -1;
        private static int _icon_Index = -1;
        private static int _active_item_Index = -1;
        private static int _model_x_pos_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _model_y_rot_Index = -1;
        private static int _model_z_pos_Index = -1;
        private static int _model_z_rot_Index = -1;
        private static int _show_model_y_pos_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _rent_att_Index = -1;
        private static int _star_itemnum_Index = -1;
        private static int _passive_skill_Index = -1;
        private static int _is_hide_Index = -1;
        #endregion
        #region //私有变量定义
        //时装ID(type*100000000+（0，时装；1，化形养成）*10000000+化形ID(衣服武器用优先级排序）
        private int _id;
        //名称
        private int _name;
        //页签（0，百装；1，装饰）hide
        private int _sheet;
        //类型（1，衣服；2武器；3，背饰；4坐骑；5，宠物；6法宝；11头像；12头像框；13气泡）
        private int _type;
        //排序
        private int _order;
        //时装的品质hide
        private int _quality;
        //资源ID
        private int _res;
        //图标hide
        private int _icon;
        //激活需要的物品(男_女）
        private int _active_item;
        //模型位置的X轴坐标hide
        private int _model_x_pos;
        //模型位置的Y轴坐标hide
        private int _model_y_pos;
        //模型位置的Y的旋转hide
        private int _model_y_rot;
        //模型位置的Z轴坐标hide
        private int _model_z_pos;
        //模型位置的Z的旋转hide
        private int _model_z_rot;
        //在获取界面中，模型位置的Y轴坐标hide
        private int _show_model_y_pos;
        //相机镜头万分比hide
        private int _camera_size;
        //属性类型_激活属性_升星属性(@;@_@)
        private int _rent_att;
        //升星需要的数量  阶数_数量(@;@_@)
        private int _star_itemnum;
        //激活学习的技能
        private int _passive_skill;
        //是否隐藏不显示hide
        private int _is_hide;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Sheet { get{ return _sheet; }}
        public int Type { get{ return _type; }}
        public int Order { get{ return _order; }}
        public int Quality { get{ return _quality; }}
        public string Res { get{ return HanderDefine.SetStingCallBack(_res); }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string ActiveItem { get{ return HanderDefine.SetStingCallBack(_active_item); }}
        public string ModelXPos { get{ return HanderDefine.SetStingCallBack(_model_x_pos); }}
        public string ModelYPos { get{ return HanderDefine.SetStingCallBack(_model_y_pos); }}
        public string ModelYRot { get{ return HanderDefine.SetStingCallBack(_model_y_rot); }}
        public string ModelZPos { get{ return HanderDefine.SetStingCallBack(_model_z_pos); }}
        public string ModelZRot { get{ return HanderDefine.SetStingCallBack(_model_z_rot); }}
        public int ShowModelYPos { get{ return _show_model_y_pos; }}
        public int CameraSize { get{ return _camera_size; }}
        public string RentAtt { get{ return HanderDefine.SetStingCallBack(_rent_att); }}
        public string StarItemnum { get{ return HanderDefine.SetStingCallBack(_star_itemnum); }}
        public int PassiveSkill { get{ return _passive_skill; }}
        public int IsHide { get{ return _is_hide; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFashion cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFashion> _dataCaches = null;
        public static Dictionary<int, DeclareFashion> CacheData
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
                        if (HanderDefine.DataCallBack("Fashion", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFashion cfg = null;
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
        private unsafe static DeclareFashion LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFashion();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._sheet = (int)GetValue(keyIndex, _sheet_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._order = (int)GetValue(keyIndex, _order_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._active_item = (int)GetValue(keyIndex, _active_item_Index, ptr);
            tmp._model_x_pos = (int)GetValue(keyIndex, _model_x_pos_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._model_y_rot = (int)GetValue(keyIndex, _model_y_rot_Index, ptr);
            tmp._model_z_pos = (int)GetValue(keyIndex, _model_z_pos_Index, ptr);
            tmp._model_z_rot = (int)GetValue(keyIndex, _model_z_rot_Index, ptr);
            tmp._show_model_y_pos = (int)GetValue(keyIndex, _show_model_y_pos_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._rent_att = (int)GetValue(keyIndex, _rent_att_Index, ptr);
            tmp._star_itemnum = (int)GetValue(keyIndex, _star_itemnum_Index, ptr);
            tmp._passive_skill = (int)GetValue(keyIndex, _passive_skill_Index, ptr);
            tmp._is_hide = (int)GetValue(keyIndex, _is_hide_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("Fashion", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Sheet", out _sheet_Index)) _sheet_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Order", out _order_Index)) _order_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ActiveItem", out _active_item_Index)) _active_item_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelXPos", out _model_x_pos_Index)) _model_x_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYRot", out _model_y_rot_Index)) _model_y_rot_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelZPos", out _model_z_pos_Index)) _model_z_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelZRot", out _model_z_rot_Index)) _model_z_rot_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModelYPos", out _show_model_y_pos_Index)) _show_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("RentAtt", out _rent_att_Index)) _rent_att_Index = -1;
                    if (!nameIndexs.TryGetValue("StarItemnum", out _star_itemnum_Index)) _star_itemnum_Index = -1;
                    if (!nameIndexs.TryGetValue("PassiveSkill", out _passive_skill_Index)) _passive_skill_Index = -1;
                    if (!nameIndexs.TryGetValue("IsHide", out _is_hide_Index)) _is_hide_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFashion>(keyCount);
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
            if(HanderDefine.DataCallBack("Fashion", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFashion cfg = null;
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
        public static DeclareFashion Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFashion result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("Fashion", out _compressData))
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
