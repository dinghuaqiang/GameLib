//文件是自动生成,请勿手动修改.来自数据文件:FBOpenShow
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareFBOpenShow
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _model_Type_Index = -1;
        private static int _model_path_Index = -1;
        private static int _item_model_path_Index = -1;
        private static int _show_icon_Index = -1;
        private static int _model_show_Index = -1;
        private static int _item_model_show_Index = -1;
        private static int _changeReason_Index = -1;
        #endregion
        #region //私有变量定义
        //物品ID
        private int _id;
        //物品名字
        private int _name;
        //物品类型
        //0.此物品有模型
        //1.此物品没有模型
        private int _type;
        //物品类型
        //0.坐骑
        //1.翅膀
        //2, 法宝
        //3, 角色
        //4, 暂时时装
        //5, 宠物
        //6, 主角武器
        //7, 魂甲
        //8, 宝箱
        //11, 头像
        //12, 头像框 
        //13,   聊天泡泡
        private int _model_Type;
        //宝箱模型路径
        private int _model_path;
        //物品模型路径
        private int _item_model_path;
        //没有物品模型时展示的Icon
        private int _show_icon;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        //4.旋转在此功能不支持
        private int _model_show;
        //sca_rotx_roty_roz_posx_posy
        //1.sac_:缩放比例
        //2.rotx_:对应旋转参数
        //3.posx_:对应位置参数(hide)
        //4.旋转在此功能不支持
        private int _item_model_show;
        //物品掉落原因码
        private int _changeReason;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int ModelType { get{ return _model_Type; }}
        public int ModelPath { get{ return _model_path; }}
        public int ItemModelPath { get{ return _item_model_path; }}
        public int ShowIcon { get{ return _show_icon; }}
        public string ModelShow { get{ return HanderDefine.SetStingCallBack(_model_show); }}
        public string ItemModelShow { get{ return HanderDefine.SetStingCallBack(_item_model_show); }}
        public string ChangeReason { get{ return HanderDefine.SetStingCallBack(_changeReason); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareFBOpenShow cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareFBOpenShow> _dataCaches = null;
        public static Dictionary<int, DeclareFBOpenShow> CacheData
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
                        if (HanderDefine.DataCallBack("FBOpenShow", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareFBOpenShow cfg = null;
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
        private unsafe static DeclareFBOpenShow LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareFBOpenShow();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._model_Type = (int)GetValue(keyIndex, _model_Type_Index, ptr);
            tmp._model_path = (int)GetValue(keyIndex, _model_path_Index, ptr);
            tmp._item_model_path = (int)GetValue(keyIndex, _item_model_path_Index, ptr);
            tmp._show_icon = (int)GetValue(keyIndex, _show_icon_Index, ptr);
            tmp._model_show = (int)GetValue(keyIndex, _model_show_Index, ptr);
            tmp._item_model_show = (int)GetValue(keyIndex, _item_model_show_Index, ptr);
            tmp._changeReason = (int)GetValue(keyIndex, _changeReason_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("FBOpenShow", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelType", out _model_Type_Index)) _model_Type_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelPath", out _model_path_Index)) _model_path_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemModelPath", out _item_model_path_Index)) _item_model_path_Index = -1;
                    if (!nameIndexs.TryGetValue("ShowIcon", out _show_icon_Index)) _show_icon_Index = -1;
                    if (!nameIndexs.TryGetValue("ModelShow", out _model_show_Index)) _model_show_Index = -1;
                    if (!nameIndexs.TryGetValue("ItemModelShow", out _item_model_show_Index)) _item_model_show_Index = -1;
                    if (!nameIndexs.TryGetValue("ChangeReason", out _changeReason_Index)) _changeReason_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareFBOpenShow>(keyCount);
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
            if(HanderDefine.DataCallBack("FBOpenShow", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareFBOpenShow cfg = null;
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
        public static DeclareFBOpenShow Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareFBOpenShow result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("FBOpenShow", out _compressData))
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
