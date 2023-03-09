using Code.Logic.System;
using GameLib.Core.Base;
using GameLib.Core.Utils;
using System.Collections.Generic;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 自动清理者管理器
    /// </summary>
    public class AutoCleanerManager : BaseSystem
    {
        #region//静态变量
        private static AutoCleanerManager _sharedInstance = null;
        public static AutoCleanerManager SharedInstance
        {
            get
            {
                if (_sharedInstance == null)
                {
                    _sharedInstance = new AutoCleanerManager();
                    //_sharedInstance.SetMemoryLevel((int)MemoryMonitor.Level);
                }
                return _sharedInstance;
            }
        }
        #endregion      

        #region//私有变量        
        //锁对象
        private readonly object _lockObj = new object();
        //清理者字典
        private Dictionary<object, ITicker> _autoCleanerList = new Dictionary<object, ITicker>();
        //生存期的全局参数
        private float _timeFactor = 1;
        #endregion

        #region //添加和移除清理者的接口方法

        //设置内存等级
        public void SetMemoryLevel(int level)
        {
            if (level < 1)
            {
                _timeFactor = 0.01f;
            }
            else
            {
                _timeFactor = 1f / (float)level;
            }
        }

        //添加清理者
        public void AddCleaner<T>(List<T> dataList, GFunc<T, bool> removeCallBack = null, float lifeTime = 10f, float tickInterval = 1f) where T : IAutoCleanInfo
        {
            lock (_lockObj)
            {
                if (dataList != null)
                {
                    if (!_autoCleanerList.ContainsKey(dataList))
                    {
                        var lift = lifeTime * _timeFactor;
                        var interval = (tickInterval * _timeFactor);
                        _autoCleanerList[dataList] = new AutoCleaner<T>(dataList, removeCallBack, lift < 1f ? 1f : lift, interval < 1f ? 1f : interval);
                    }
                }
            }

        }

        //移除清理者
        public void RemoveCleaner<T>(List<T> dataList)
        {
            lock (_lockObj)
            {
                if (dataList != null)
                {
                    _autoCleanerList.Remove(dataList);
                }
                else
                {
                    DevLog.LogErrorFormat("移除清理者时,参数为空!!");
                }
            }
        }

        public void Clear()
        {
            lock (_lockObj)
            {
                _autoCleanerList.Clear();
            }
        }
        #endregion

        #region 心跳更新
        protected override bool OnUpdate(float delta)
        {
            lock (_lockObj)
            {
                var enumerator = _autoCleanerList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Value.Update(delta);
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }
            }
            return true;
        }
        #endregion
    }
}
