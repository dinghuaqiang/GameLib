//文件是自动生成,请勿手动修改.来自数据文件:AnimClipName
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareAnimClipName
    {
        #region //静态变量定义
        private static int _name_Index = -1;
        private static int _idle_move_anim_Index = -1;
        private static int _move_idle_anim_Index = -1;
        private static int _use_half_body_Index = -1;
        private static int _logic_type_Index = -1;
        private static int _is_login_anim_Index = -1;
        private static int _is_ui_simple_anim_Index = -1;
        private static int _is_ui_mountle_anim_Index = -1;
        private static int _is_skill_anim_Index = -1;
        private static int _is_scene_anim_Index = -1;
        #endregion
        #region //私有变量定义
        //动作名字
        private int _name;
        //站立对应的移动动作
        private int _idle_move_anim;
        //移动到站立的动作
        private int _move_idle_anim;
        //是否使用上下半身分离
        private int _use_half_body;
        //动作逻辑类型（0，站立动作；1，移动动作；2，技能动作；3，其他动作
        private int _logic_type;
        //是否是登录动作
        private int _is_login_anim;
        //是否是ui简单动作
        private int _is_ui_simple_anim;
        //是否是ui坐骑动作
        private int _is_ui_mountle_anim;
        //是否是技能动作
        private int _is_skill_anim;
        //是否是场景动作
        private int _is_scene_anim;
        #endregion

        #region //公共属性
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public string IdleMoveAnim { get{ return HanderDefine.SetStingCallBack(_idle_move_anim); }}
        public string MoveIdleAnim { get{ return HanderDefine.SetStingCallBack(_move_idle_anim); }}
        public int UseHalfBody { get{ return _use_half_body; }}
        public int LogicType { get{ return _logic_type; }}
        public int IsLoginAnim { get{ return _is_login_anim; }}
        public int IsUiSimpleAnim { get{ return _is_ui_simple_anim; }}
        public int IsUiMountleAnim { get{ return _is_ui_mountle_anim; }}
        public int IsSkillAnim { get{ return _is_skill_anim; }}
        public int IsSceneAnim { get{ return _is_scene_anim; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareAnimClipName cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<string, DeclareAnimClipName> _dataCaches = null;
        public static Dictionary<string, DeclareAnimClipName> CacheData
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
                        if (HanderDefine.DataCallBack("AnimClipName", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareAnimClipName cfg = null;
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
        private static Dictionary<string, int> _dataIndexCaches = null;
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
        private unsafe static DeclareAnimClipName LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareAnimClipName();
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._idle_move_anim = (int)GetValue(keyIndex, _idle_move_anim_Index, ptr);
            tmp._move_idle_anim = (int)GetValue(keyIndex, _move_idle_anim_Index, ptr);
            tmp._use_half_body = (int)GetValue(keyIndex, _use_half_body_Index, ptr);
            tmp._logic_type = (int)GetValue(keyIndex, _logic_type_Index, ptr);
            tmp._is_login_anim = (int)GetValue(keyIndex, _is_login_anim_Index, ptr);
            tmp._is_ui_simple_anim = (int)GetValue(keyIndex, _is_ui_simple_anim_Index, ptr);
            tmp._is_ui_mountle_anim = (int)GetValue(keyIndex, _is_ui_mountle_anim_Index, ptr);
            tmp._is_skill_anim = (int)GetValue(keyIndex, _is_skill_anim_Index, ptr);
            tmp._is_scene_anim = (int)GetValue(keyIndex, _is_scene_anim_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("AnimClipName", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("IdleMoveAnim", out _idle_move_anim_Index)) _idle_move_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("MoveIdleAnim", out _move_idle_anim_Index)) _move_idle_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("UseHalfBody", out _use_half_body_Index)) _use_half_body_Index = -1;
                    if (!nameIndexs.TryGetValue("LogicType", out _logic_type_Index)) _logic_type_Index = -1;
                    if (!nameIndexs.TryGetValue("IsLoginAnim", out _is_login_anim_Index)) _is_login_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("IsUiSimpleAnim", out _is_ui_simple_anim_Index)) _is_ui_simple_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("IsUiMountleAnim", out _is_ui_mountle_anim_Index)) _is_ui_mountle_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSkillAnim", out _is_skill_anim_Index)) _is_skill_anim_Index = -1;
                    if (!nameIndexs.TryGetValue("IsSceneAnim", out _is_scene_anim_Index)) _is_scene_anim_Index = -1;
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
                        _dataCaches = new Dictionary<string, DeclareAnimClipName>(keyCount);
                        _dataIndexCaches = new Dictionary<string, int>(keyCount);
                        ptr = (int*)_compressData.ToPointer();
                        for (int i = 0; i < keyCount; i++)
                        {
                            var key = (int)GetValue(i, 0, ptr);
                            _dataIndexCaches.Add(HanderDefine.SetStingCallBack(key), i);
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
            if(HanderDefine.DataCallBack("AnimClipName", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareAnimClipName cfg = null;
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
        public static DeclareAnimClipName Get(string id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareAnimClipName result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("AnimClipName", out _compressData))
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
