//文件是自动生成,请勿手动修改.来自数据文件:ModelConfig
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareModelConfig
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _type_Index = -1;
        private static int _model_Index = -1;
        private static int _isShow_Index = -1;
        private static int _applyStatus_Index = -1;
        private static int _shader_Index = -1;
        private static int _sharder_param1_Index = -1;
        private static int _sharder_param2_Index = -1;
        private static int _sharder_param3_Index = -1;
        private static int _sharder_param4_Index = -1;
        private static int _sharder_param5_Index = -1;
        private static int _out_line_param_Index = -1;
        private static int _vfx_type_Index = -1;
        private static int _vfx_1_Index = -1;
        private static int _vfx_2_Index = -1;
        private static int _vfx_3_Index = -1;
        private static int _vfx_4_Index = -1;
        private static int _vfx_5_Index = -1;
        private static int _main_textrue_Index = -1;
        private static int _mask_textrue_Index = -1;
        #endregion
        #region //私有变量定义
        //外观ID
        private int _id;
        //模型类型：1玩家身体，2玩家武器，3玩家翅膀，4玩家坐骑，5怪物，6采集物，7强化特效，8.掉落模型,9.神兵，10，神兵特效部位，11.UI场景模型，99,其他模型
        private int _type;
        //使用的模型ID(位数不得大于5位数)
        private int _model;
        //设置当前模型使用展示模型
        private int _isShow;
        //当前模型适用的状态(1:出生,2:被击,4:死亡,8:霸体),多个状态同时有效可以叠加
        private int _applyStatus;
        //使用的shader，
        //-1使用自带默认shader
        //0默认shader（不需要参数），
        //1流光shader（参数1位纹理名，参数2为颜色，参数3为颜色,参数4为流动速度,参数5为贴图的平铺数量,参数6为流光强度,参数7为方向,参数8为闪烁速度,参数9为闪烁颜色）
        //2边缘高光效果（参数1为power[50-800]，参数2为RGB, 参数3为power[50-800]，参数4为RGB）
        //3.消融效果(参数1为灰色时间,参数2为溶解的时间,参数3为当前的状态),
        //4.半透效果(参数1:颜色255_255_255_255)
        //5.半透效果(参数1:Cutoff值)
        //6:默认PBR
        //7:环境光效果(参数1:Cube纹理名字,参数2:混合值) 
        //8:新流光效果（参数1位纹理名，参数2为颜色，参数3为颜色,参数4为流动速度,参数5为贴图的平铺数量,参数6为流光强度,参数7为闪烁速度,参数8为闪烁颜色）
        //9:流光BPR效果（参数1位纹理名，参数2为颜色，参数3为颜色,参数4为流动速度,参数5为贴图的平铺数量,参数6为流光强度,参数7为方向,参数8为闪烁速度,参数9为闪烁颜色）
        //10:新流光BPR效果（参数1位纹理名，参数2为颜色，参数3为颜色,参数4为流动速度,参数5为贴图的平铺数量,参数6为流光强度,参数7为闪烁速度,参数8为闪烁颜色）
        private int _shader;
        //sharder参数1
        private int _sharder_param1;
        //sharder参数2
        private int _sharder_param2;
        //sharder参数3
        private int _sharder_param3;
        //sharder参数4
        private int _sharder_param4;
        //sharder参数5
        private int _sharder_param5;
        //勾边参数, 颜色RGB;钩边大小
        private int _out_line_param;
        //特效type
        //301为转职特效其他的全部填-1
        private int _vfx_type;
        //使用的特效：绑定点(-1表示挂载不寻找挂载点)_特效ID_开始颜色_结束颜色
        private int _vfx_1;
        //使用的特效：绑定点_特效ID_开始颜色_结束颜色
        private int _vfx_2;
        //使用的特效：绑定点_特效ID_开始颜色_结束颜色
        private int _vfx_3;
        //使用的特效：绑定点_特效ID_开始颜色_结束颜色
        private int _vfx_4;
        //使用的特效：绑定点_特效ID_开始颜色_结束颜色
        private int _vfx_5;
        //用于替换主纹理
        private int _main_textrue;
        //用于替换mask纹理
        private int _mask_textrue;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public int Type { get{ return _type; }}
        public int Model { get{ return _model; }}
        public int IsShow { get{ return _isShow; }}
        public int ApplyStatus { get{ return _applyStatus; }}
        public int Shader { get{ return _shader; }}
        public string SharderParam1 { get{ return HanderDefine.SetStingCallBack(_sharder_param1); }}
        public string SharderParam2 { get{ return HanderDefine.SetStingCallBack(_sharder_param2); }}
        public string SharderParam3 { get{ return HanderDefine.SetStingCallBack(_sharder_param3); }}
        public string SharderParam4 { get{ return HanderDefine.SetStingCallBack(_sharder_param4); }}
        public string SharderParam5 { get{ return HanderDefine.SetStingCallBack(_sharder_param5); }}
        public string OutLineParam { get{ return HanderDefine.SetStingCallBack(_out_line_param); }}
        public int VfxType { get{ return _vfx_type; }}
        public string Vfx1 { get{ return HanderDefine.SetStingCallBack(_vfx_1); }}
        public string Vfx2 { get{ return HanderDefine.SetStingCallBack(_vfx_2); }}
        public string Vfx3 { get{ return HanderDefine.SetStingCallBack(_vfx_3); }}
        public string Vfx4 { get{ return HanderDefine.SetStingCallBack(_vfx_4); }}
        public string Vfx5 { get{ return HanderDefine.SetStingCallBack(_vfx_5); }}
        public string MainTextrue { get{ return HanderDefine.SetStingCallBack(_main_textrue); }}
        public string MaskTextrue { get{ return HanderDefine.SetStingCallBack(_mask_textrue); }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareModelConfig cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareModelConfig> _dataCaches = null;
        public static Dictionary<int, DeclareModelConfig> CacheData
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
                        if (HanderDefine.DataCallBack("ModelConfig", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareModelConfig cfg = null;
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
        private unsafe static DeclareModelConfig LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareModelConfig();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._model = (int)GetValue(keyIndex, _model_Index, ptr);
            tmp._isShow = (int)GetValue(keyIndex, _isShow_Index, ptr);
            tmp._applyStatus = (int)GetValue(keyIndex, _applyStatus_Index, ptr);
            tmp._shader = (int)GetValue(keyIndex, _shader_Index, ptr);
            tmp._sharder_param1 = (int)GetValue(keyIndex, _sharder_param1_Index, ptr);
            tmp._sharder_param2 = (int)GetValue(keyIndex, _sharder_param2_Index, ptr);
            tmp._sharder_param3 = (int)GetValue(keyIndex, _sharder_param3_Index, ptr);
            tmp._sharder_param4 = (int)GetValue(keyIndex, _sharder_param4_Index, ptr);
            tmp._sharder_param5 = (int)GetValue(keyIndex, _sharder_param5_Index, ptr);
            tmp._out_line_param = (int)GetValue(keyIndex, _out_line_param_Index, ptr);
            tmp._vfx_type = (int)GetValue(keyIndex, _vfx_type_Index, ptr);
            tmp._vfx_1 = (int)GetValue(keyIndex, _vfx_1_Index, ptr);
            tmp._vfx_2 = (int)GetValue(keyIndex, _vfx_2_Index, ptr);
            tmp._vfx_3 = (int)GetValue(keyIndex, _vfx_3_Index, ptr);
            tmp._vfx_4 = (int)GetValue(keyIndex, _vfx_4_Index, ptr);
            tmp._vfx_5 = (int)GetValue(keyIndex, _vfx_5_Index, ptr);
            tmp._main_textrue = (int)GetValue(keyIndex, _main_textrue_Index, ptr);
            tmp._mask_textrue = (int)GetValue(keyIndex, _mask_textrue_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("ModelConfig", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Model", out _model_Index)) _model_Index = -1;
                    if (!nameIndexs.TryGetValue("IsShow", out _isShow_Index)) _isShow_Index = -1;
                    if (!nameIndexs.TryGetValue("ApplyStatus", out _applyStatus_Index)) _applyStatus_Index = -1;
                    if (!nameIndexs.TryGetValue("Shader", out _shader_Index)) _shader_Index = -1;
                    if (!nameIndexs.TryGetValue("SharderParam1", out _sharder_param1_Index)) _sharder_param1_Index = -1;
                    if (!nameIndexs.TryGetValue("SharderParam2", out _sharder_param2_Index)) _sharder_param2_Index = -1;
                    if (!nameIndexs.TryGetValue("SharderParam3", out _sharder_param3_Index)) _sharder_param3_Index = -1;
                    if (!nameIndexs.TryGetValue("SharderParam4", out _sharder_param4_Index)) _sharder_param4_Index = -1;
                    if (!nameIndexs.TryGetValue("SharderParam5", out _sharder_param5_Index)) _sharder_param5_Index = -1;
                    if (!nameIndexs.TryGetValue("OutLineParam", out _out_line_param_Index)) _out_line_param_Index = -1;
                    if (!nameIndexs.TryGetValue("VfxType", out _vfx_type_Index)) _vfx_type_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx1", out _vfx_1_Index)) _vfx_1_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx2", out _vfx_2_Index)) _vfx_2_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx3", out _vfx_3_Index)) _vfx_3_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx4", out _vfx_4_Index)) _vfx_4_Index = -1;
                    if (!nameIndexs.TryGetValue("Vfx5", out _vfx_5_Index)) _vfx_5_Index = -1;
                    if (!nameIndexs.TryGetValue("MainTextrue", out _main_textrue_Index)) _main_textrue_Index = -1;
                    if (!nameIndexs.TryGetValue("MaskTextrue", out _mask_textrue_Index)) _mask_textrue_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareModelConfig>(keyCount);
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
            if(HanderDefine.DataCallBack("ModelConfig", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareModelConfig cfg = null;
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
        public static DeclareModelConfig Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareModelConfig result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("ModelConfig", out _compressData))
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
