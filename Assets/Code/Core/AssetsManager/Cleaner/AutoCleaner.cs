using GameLib.Core.Base;
using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Asset
{
    internal class AutoCleaner<T> : ITicker where T : IAutoCleanInfo
    {
        #region//静态变量
        //当有10个资源被删除了就清掉
        private const int CN_UNLOAD_COUNT = 15;
        private static int _deleteItemCount = 0;

        #endregion

        #region//私有成员变量
        //监控的数据列表
        private List<T> _dataList;
        //刷新间隔
        private float _intervalRefresh = 1f;
        //最后一次刷新时间
        private float _lastRefreshTime = 0;
        //数据隐藏后的生存期
        private float _hideLifeTime = 5f;
        //数据被移除后的回调
        private GFunc<T, bool> _removeCallBack = null;
        //清理器名字
        private string _name = null;
        #endregion

        #region//私有属性
        private string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    _name = typeof(T).Name;
                }
                return _name;
            }
        }
        #endregion

        #region//构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="removeCallBack"></param>
        /// <param name="lifeTime"></param>
        /// <param name="tickInterval"></param>
        public AutoCleaner(List<T> dataList, GFunc<T, bool> removeCallBack = null, float lifeTime = 10f, float tickInterval = 1f)
        {
            _name = null;
            _dataList = dataList;
            _removeCallBack = removeCallBack;
            _hideLifeTime = lifeTime;
            _intervalRefresh = tickInterval;
        }
        #endregion

        #region //公共接口     
        public void Start()
        {

        }

        //心跳处理
        public void Update(float deltaTime)
        {
            if (!IsValid()) return;

            var currTime = Time.realtimeSinceStartup; //TimeUtils.GetSystemTicksS();
            if (currTime > _lastRefreshTime + _intervalRefresh)
            {
                _lastRefreshTime = currTime;
                try
                {
                    for (int i = _dataList.Count - 1; i >= 0; i--)
                    {
                        if (_dataList[i].WillBeCleared && _dataList[i].UsedTimeInfo.CheckLifeTime(currTime, _hideLifeTime))
                        {
                            if (_removeCallBack == null)
                            {
                                _deleteItemCount++;
                                _dataList.RemoveAt(i);
                                break;   //每帧处理一个
                            }
                            else
                            {
                                if (_removeCallBack(_dataList[i]))
                                {
                                    _deleteItemCount++;
                                    _dataList.RemoveAt(i);
                                    break;   //每帧处理一个                                
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevLog.LogErrorFormat("AutoCleaner<{0}>.Update() Error! {1}", Name, ex.Message);
                }
            }
        }
        //删除
        public void Destory()
        {
            _dataList = null;
        }

        //是否有效
        public bool IsValid()
        {
            return _dataList != null;
        }
        #endregion
    }
}
