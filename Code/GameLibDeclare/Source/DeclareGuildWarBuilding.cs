//文件是自动生成,请勿手动修改.来自数据文件:guild_war_building
using System;
using System.Collections.Generic;
namespace GameLib.Cfg.Data
{
    public class DeclareGuildWarBuilding
    {
        #region //静态变量定义
        private static int _id_Index = -1;
        private static int _name_Index = -1;
        private static int _type_Index = -1;
        private static int _icon_Index = -1;
        private static int _pos_Index = -1;
        private static int _worldLevel_Index = -1;
        private static int _reduceHurt_Index = -1;
        private static int _airWall_Index = -1;
        private static int _rankPoint_Index = -1;
        private static int _destroyPoint_Index = -1;
        private static int _carryDestroyPoint_Index = -1;
        private static int _repairPoint_Index = -1;
        private static int _carryRepiarPoint_Index = -1;
        private static int _gather_Index = -1;
        private static int _transfDoorId_Index = -1;
        private static int _transfDoorPos_Index = -1;
        private static int _transfDoorTarget_Index = -1;
        private static int _repairCD_Index = -1;
        #endregion
        #region //私有变量定义
        //对应怪物表ID
        private int _id;
        //建筑名字
        private int _name;
        //建筑类型
        //0上古意志
        //1内城建筑
        //2中城建筑
        //3外城建筑
        private int _type;
        //对应显示在任务界面上的Icon（hide）
        private int _icon;
        //建筑对应坐标（X,Z）
        //Y由系统自动判断
        private int _pos;
        //世界等级（小于等于配置的值）
        private int _worldLevel;
        //存活时为上古意志减伤，加法叠加，最大不可超过100%（万分比）
        private int _reduceHurt;
        //控制的空气墙ID（由地图配置的时候产生的ID）
        private int _airWall;
        //计入统计的得分（达到要求，则计分+1）
        private int _rankPoint;
        //被摧毁时增加的积分
        //当事人_盟友增加
        private int _destroyPoint;
        //被载具摧毁增加的积分
        //当事人_盟友增加
        private int _carryDestroyPoint;
        //被修复时增加的积分
        //当事人_盟友增加
        private int _repairPoint;
        //被载具修复增加的积分
        //当事人_盟友增加
        private int _carryRepiarPoint;
        //复活建筑时对应需要采集的物品
        private int _gather;
        //传送门ID
        //策划定的ID，由客户端直接调用
        //hide
        private int _transfDoorId;
        //传送门坐标
        //hide
        private int _transfDoorPos;
        //传送门传送目标地区域
        //-1代表最外层攻方所在区域
        //101代表外城
        //102代表中城
        //103代表内城
        //hide
        private int _transfDoorTarget;
        //被修复时的CD时间（秒）
        private int _repairCD;
        #endregion

        #region //公共属性
        public int Id { get{ return _id; }}
        public string Name { get{ return HanderDefine.SetStingCallBack(_name); }}
        public int Type { get{ return _type; }}
        public int Icon { get{ return _icon; }}
        public string Pos { get{ return HanderDefine.SetStingCallBack(_pos); }}
        public int WorldLevel { get{ return _worldLevel; }}
        public int ReduceHurt { get{ return _reduceHurt; }}
        public string AirWall { get{ return HanderDefine.SetStingCallBack(_airWall); }}
        public int RankPoint { get{ return _rankPoint; }}
        public string DestroyPoint { get{ return HanderDefine.SetStingCallBack(_destroyPoint); }}
        public string CarryDestroyPoint { get{ return HanderDefine.SetStingCallBack(_carryDestroyPoint); }}
        public string RepairPoint { get{ return HanderDefine.SetStingCallBack(_repairPoint); }}
        public string CarryRepiarPoint { get{ return HanderDefine.SetStingCallBack(_carryRepiarPoint); }}
        public int Gather { get{ return _gather; }}
        public int TransfDoorId { get{ return _transfDoorId; }}
        public string TransfDoorPos { get{ return HanderDefine.SetStingCallBack(_transfDoorPos); }}
        public string TransfDoorTarget { get{ return HanderDefine.SetStingCallBack(_transfDoorTarget); }}
        public int RepairCD { get{ return _repairCD; }}
        #endregion

        #region //静态变量以及方法定义
        //线程锁对象
        private static object _lockObj = new object();
        public delegate bool ForeachHandler(DeclareGuildWarBuilding cfg);
        //数据存储字典
        private static bool _dataCacheFull = false;
        private static Dictionary<int, DeclareGuildWarBuilding> _dataCaches = null;
        public static Dictionary<int, DeclareGuildWarBuilding> CacheData
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
                        if (HanderDefine.DataCallBack("GuildWarBuilding", out _compressData))
                        {
                            var iter = _dataIndexCaches.GetEnumerator();
                            while (iter.MoveNext())
                            {
                                DeclareGuildWarBuilding cfg = null;
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
        private unsafe static DeclareGuildWarBuilding LoadSingleData(int keyIndex)
        {
            int* ptr = (int*)_compressData.ToPointer();
            var tmp = new DeclareGuildWarBuilding();
            tmp._id = (int)GetValue(keyIndex, _id_Index, ptr);
            tmp._name = (int)GetValue(keyIndex, _name_Index, ptr);
            tmp._type = (int)GetValue(keyIndex, _type_Index, ptr);
            tmp._icon = (int)GetValue(keyIndex, _icon_Index, ptr);
            tmp._pos = (int)GetValue(keyIndex, _pos_Index, ptr);
            tmp._worldLevel = (int)GetValue(keyIndex, _worldLevel_Index, ptr);
            tmp._reduceHurt = (int)GetValue(keyIndex, _reduceHurt_Index, ptr);
            tmp._airWall = (int)GetValue(keyIndex, _airWall_Index, ptr);
            tmp._rankPoint = (int)GetValue(keyIndex, _rankPoint_Index, ptr);
            tmp._destroyPoint = (int)GetValue(keyIndex, _destroyPoint_Index, ptr);
            tmp._carryDestroyPoint = (int)GetValue(keyIndex, _carryDestroyPoint_Index, ptr);
            tmp._repairPoint = (int)GetValue(keyIndex, _repairPoint_Index, ptr);
            tmp._carryRepiarPoint = (int)GetValue(keyIndex, _carryRepiarPoint_Index, ptr);
            tmp._gather = (int)GetValue(keyIndex, _gather_Index, ptr);
            tmp._transfDoorId = (int)GetValue(keyIndex, _transfDoorId_Index, ptr);
            tmp._transfDoorPos = (int)GetValue(keyIndex, _transfDoorPos_Index, ptr);
            tmp._transfDoorTarget = (int)GetValue(keyIndex, _transfDoorTarget_Index, ptr);
            tmp._repairCD = (int)GetValue(keyIndex, _repairCD_Index, ptr);
            return tmp;
        }
        private static void SetBaseData()
        {
            if (_dataCaches == null)
            {
                int keyCount = 0;
                IntPtr columnShiftAndList = IntPtr.Zero;
                Dictionary<string, int> nameIndexs = null;
                var _isExist = HanderDefine.BaseDataCallBack("GuildWarBuilding", out keyCount, out _indexFactor, out _compressData, out columnShiftAndList, out _compressMaxColumn, out nameIndexs);
                if (_isExist)
                {
                    if (!nameIndexs.TryGetValue("Id", out _id_Index)) _id_Index = -1;
                    if (!nameIndexs.TryGetValue("Name", out _name_Index)) _name_Index = -1;
                    if (!nameIndexs.TryGetValue("Type", out _type_Index)) _type_Index = -1;
                    if (!nameIndexs.TryGetValue("Icon", out _icon_Index)) _icon_Index = -1;
                    if (!nameIndexs.TryGetValue("Pos", out _pos_Index)) _pos_Index = -1;
                    if (!nameIndexs.TryGetValue("WorldLevel", out _worldLevel_Index)) _worldLevel_Index = -1;
                    if (!nameIndexs.TryGetValue("ReduceHurt", out _reduceHurt_Index)) _reduceHurt_Index = -1;
                    if (!nameIndexs.TryGetValue("AirWall", out _airWall_Index)) _airWall_Index = -1;
                    if (!nameIndexs.TryGetValue("RankPoint", out _rankPoint_Index)) _rankPoint_Index = -1;
                    if (!nameIndexs.TryGetValue("DestroyPoint", out _destroyPoint_Index)) _destroyPoint_Index = -1;
                    if (!nameIndexs.TryGetValue("CarryDestroyPoint", out _carryDestroyPoint_Index)) _carryDestroyPoint_Index = -1;
                    if (!nameIndexs.TryGetValue("RepairPoint", out _repairPoint_Index)) _repairPoint_Index = -1;
                    if (!nameIndexs.TryGetValue("CarryRepiarPoint", out _carryRepiarPoint_Index)) _carryRepiarPoint_Index = -1;
                    if (!nameIndexs.TryGetValue("Gather", out _gather_Index)) _gather_Index = -1;
                    if (!nameIndexs.TryGetValue("TransfDoorId", out _transfDoorId_Index)) _transfDoorId_Index = -1;
                    if (!nameIndexs.TryGetValue("TransfDoorPos", out _transfDoorPos_Index)) _transfDoorPos_Index = -1;
                    if (!nameIndexs.TryGetValue("TransfDoorTarget", out _transfDoorTarget_Index)) _transfDoorTarget_Index = -1;
                    if (!nameIndexs.TryGetValue("RepairCD", out _repairCD_Index)) _repairCD_Index = -1;
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
                        _dataCaches = new Dictionary<int, DeclareGuildWarBuilding>(keyCount);
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
            if(HanderDefine.DataCallBack("GuildWarBuilding", out _compressData))
            {
                var iter = _dataIndexCaches.GetEnumerator();
                while (iter.MoveNext())
                {
                    DeclareGuildWarBuilding cfg = null;
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
        public static DeclareGuildWarBuilding Get(int id)
        {
            lock (_lockObj)
            {
                if (_dataCaches == null)
                    SetBaseData();
                DeclareGuildWarBuilding result = null;
                var keyIndex = 0;
                if (_dataCaches != null && !_dataCaches.TryGetValue(id, out result) && _dataIndexCaches != null && _dataIndexCaches.TryGetValue(id, out keyIndex))
                {
                    if (HanderDefine.DataCallBack("GuildWarBuilding", out _compressData))
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
