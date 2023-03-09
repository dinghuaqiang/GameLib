//文件是自动生成,请勿手动修改.来自数据文件:fashion_total
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFashionTotal
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _type_2_Index = -1;
        private static int _order_Index = -1;
        private static int _quality_Index = -1;
        private static int _icon_Index = -1;
        private static int _res_Index = -1;
        private static int _model_x_pos_Index = -1;
        private static int _model_y_pos_Index = -1;
        private static int _model_y_rot_Index = -1;
        private static int _model_z_pos_Index = -1;
        private static int _model_z_rot_Index = -1;
        private static int _camera_size_Index = -1;
        private static int _variable_ID_Index = -1;
        private static int _isShow_Index = -1;
        private static int _isTask_Index = -1;
        private static int _show_model_y_pos_Index = -1;
        private static int _show_camera_size_Index = -1;
        private static int _if_New_Index = -1;
        private static int _if_headup_Index = -1;
        #endregion
        #region //私有变量定义
        //时装ID(type*100000000+（0，时装；1，化形养成）*10000000+化形ID(衣服武器用优先级排序））
        private int _id;
        //时装名称(hide)
        private int _name;
        //类型（1，衣服；2武器；3，背饰；4坐骑；5，宠物；6法宝；7魂甲；11头像；12头像框；13气泡）
        private int _type;
        //细分类型（0，时装；1，化形养成）
        private int _type_2;
        //优先级排序（数字越小优先级越高）
        private int _order;
        //时装的品质hide
        private int _quality;
        //时装icon(hide)
        private int _icon;
        //资源
        private int _res;
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
        //相机镜头万分比hide
        private int _camera_size;
        //条件（填写FunctionVariable表配置）
        private int _variable_ID;
        //是否有新获得时装的展示
        private int _isShow;
        //关闭获得时装展示后是否继续主线任务hide
        private int _isTask;
        //在获取界面中，模型位置的Y轴坐标hide
        private int _show_model_y_pos;
        //获得相机镜头万分比hide
        private int _show_camera_size;
        //是否需要【新】标记（0，需要 ；1，不需要）
        private int _if_New;
        //是否需要在上传头像界面里隐藏，1是隐藏
        private int _if_headup;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Type2 { get{ return _type_2; }}
        public int Order { get{ return _order; }}
        public int Quality { get{ return _quality; }}
        public string Icon { get{ return HanderDefine.SetStingCallBack(_icon); }}
        public string Res { get{ return HanderDefine.SetStingCallBack(_res); }}
        public int ModelXPos { get{ return _model_x_pos; }}
        public int ModelYPos { get{ return _model_y_pos; }}
        public int ModelYRot { get{ return _model_y_rot; }}
        public int ModelZPos { get{ return _model_z_pos; }}
        public int ModelZRot { get{ return _model_z_rot; }}
        public int CameraSize { get{ return _camera_size; }}
        public string VariableID { get{ return HanderDefine.SetStingCallBack(_variable_ID); }}
        public int IsShow { get{ return _isShow; }}
        public int IsTask { get{ return _isTask; }}
        public int ShowModelYPos { get{ return _show_model_y_pos; }}
        public int ShowCameraSize { get{ return _show_camera_size; }}
        public int IfNew { get{ return _if_New; }}
        public int IfHeadup { get{ return _if_headup; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFashionTotal cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFashionTotal> _dataCaches = null;
        public static Dictionary<int, DeclareFashionTotal> CacheData
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
                        if (HanderDefine.DataCallBack("FashionTotal", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFashionTotal cfg = null;
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
        private unsafe static DeclareFashionTotal LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFashionTotal();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._type_2 = (int)GetValue(keyIndex, _type_2_Index, ptr);
            tmp._order = (int)GetValue(keyIndex, _order_Index, ptr);
            tmp._quality = (int)GetValue(keyIndex, _quality_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._res = (int)GetValue(keyIndex, _res_Index, ptr);
            tmp._model_x_pos = (int)GetValue(keyIndex, _model_x_pos_Index, ptr);
            tmp._model_y_pos = (int)GetValue(keyIndex, _model_y_pos_Index, ptr);
            tmp._model_y_rot = (int)GetValue(keyIndex, _model_y_rot_Index, ptr);
            tmp._model_z_pos = (int)GetValue(keyIndex, _model_z_pos_Index, ptr);
            tmp._model_z_rot = (int)GetValue(keyIndex, _model_z_rot_Index, ptr);
            tmp._camera_size = (int)GetValue(keyIndex, _camera_size_Index, ptr);
            tmp._variable_ID = (int)GetValue(keyIndex, _variable_ID_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._isTask = (int)GetValue(keyIndex, _isTask_Index, ptr);
            tmp._show_model_y_pos = (int)GetValue(keyIndex, _show_model_y_pos_Index, ptr);
            tmp._show_camera_size = (int)GetValue(keyIndex, _show_camera_size_Index, ptr);
            tmp._if_New = (int)GetValue(keyIndex, _if_New_Index, ptr);
            tmp._if_headup = (int)GetValue(keyIndex, _if_headup_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FashionTotal", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Type2", out _type_2_Index)) _type_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Order", out _order_Index)) _order_Index = -1;
                    if (!nameIndexs.TryGetValue("Quality", out _quality_Index)) _quality_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Res", out _res_Index)) _res_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelXPos", out _model_x_pos_Index)) _model_x_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYPos", out _model_y_pos_Index)) _model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelYRot", out _model_y_rot_Index)) _model_y_rot_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelZPos", out _model_z_pos_Index)) _model_z_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelZRot", out _model_z_rot_Index)) _model_z_rot_Index = -1;
                    if (!nameIndexs.TryGetValue("CameraSize", out _camera_size_Index)) _camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("VariableID", out _variable_ID_Index)) _variable_ID_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("IsTask", out _isTask_Index)) _isTask_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowModelYPos", out _show_model_y_pos_Index)) _show_model_y_pos_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowCameraSize", out _show_camera_size_Index)) _show_camera_size_Index = -1;
                    if (!nameIndexs.TryGetValue("IfNew", out _if_New_Index)) _if_New_Index = -1;
                    if (!nameIndexs.TryGetValue("IfHeadup", out _if_headup_Index)) _if_headup_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFashionTotal>(keyCount);
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
            if(HanderDefine.DataCallBack("FashionTotal", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFashionTotal cfg = null;
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
        public static DeclareFashionTotal Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFashionTotal result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FashionTotal", out _compressData))
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
