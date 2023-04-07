using GameLib.Core.Event;
using GameLib.Core.Utils;

namespace GameLib.Core.Base.Support
{
    /// <summary>
    /// 帧率监控---如果
    /// 平均在一段时间内,帧率太低,那么就发出警告
    /// 某个点帧率低于多少水平,那么就发出警告
    /// 然后调节 -- 
    ///  1.当前场景的特效水平
    ///  2.场景中模型对象的数量
    ///  3.场景模型的上挂在的特效水平
    /// </summary>
    public static class FrameMonitor
    {
        //实时的fps
        private static FrameCounter _fpsCounter = new FrameCounter(0.5f);
        //每分钟的平均的fps
        private static FrameCounter _fpmCounter = new FrameCounter(60f);

        //计数
        private static TimeTicker _tic = null;

        //正常等级
        private static FrameLevel _level = FrameLevel.Normal;

        //实时FPS
        public static float RealFPS
        {
            get
            {
                return _fpsCounter.FPS;
            }
        }

        //每分钟平均FPS
        public static float AVGFPS
        {
            get
            {
                return _fpmCounter.FPS;
            }
        }


        //初始化,默认为1分钟tick一次
        public static void Initialize(float tickInterval = 60)
        {
            if (tickInterval <= 60f) tickInterval = 60f;

            if (_tic == null)
            {
                _tic = new TimeTicker(tickInterval, OnTick, true);
            }
            else
            {
                _tic.Reset(tickInterval);
            }
        }
        //反初始化
        public static void Uninitialize()
        {
            if (_tic != null)
            {
                _tic.SetEnable(false);
            }
        }

        //更新
        public static void Update(float deltaTime)
        {
            _fpsCounter.Update(deltaTime);
            _fpmCounter.Update(deltaTime);
            if (_tic != null)
            {
                _tic.Update(deltaTime);
            }
        }

        //信息
        public static string Infomation()
        {
            var sb = StringUtils.NewStringBuilder;
            sb.AppendLine("FrameMonitor:");
            sb.AppendFormat("Real FPS:{0}", _fpsCounter.FPS);
            sb.AppendLine();
            sb.AppendFormat("Minute Average FPS:{0}", _fpmCounter.FPS);
            return sb.ToString();
        }

        //监控名字
        private static string _profileName = string.Empty;
        //监控是否运行
        private static bool _profileIsRunning = false;
        //开始的Tick数量
        private static int _beginTickCount = 0;

        //开始监控
        public static void BeginProfile(string profileName)
        {
            if (_profileIsRunning)
            {
                EndProfile();
            }
            _beginTickCount = System.Environment.TickCount;
            _profileIsRunning = true;
            _profileName = profileName;
            _fpsCounter.SetEnable(true, true);
        }

        //暂停
        public static void PauseProfile()
        {
            if (_profileIsRunning)
            {
                _fpsCounter.SetEnable(false, false);
            }
        }

        //恢复
        public static void ResumeProfile()
        {
            if (_profileIsRunning)
            {
                _fpsCounter.SetEnable(true, false);
            }
        }

        //结束
        public static void EndProfile()
        {
            if (_profileIsRunning)
            {
                _profileIsRunning = false;
                _fpsCounter.SetEnable(false, false);
                if (!string.IsNullOrEmpty(_profileName))
                {
                    UnityEngine.Debug.Log(_profileName + " Duration(s):" + (System.Environment.TickCount - _beginTickCount) / 1000 + " Average FPS:" + _fpsCounter.AVGFPS + " ValidFrameCount:" + _fpsCounter.AVGValidFrameCount);
                }

            }
        }
        #region//私有方法
        //心跳处理
        private static void OnTick()
        {
            FrameLevel tmp = FrameLevel.Fastest;
            for (int i = (int)FrameLevel.Slowest; i <= (int)FrameLevel.Fast; i++)
            {
                if (_fpmCounter.FPS < i * 10)
                {
                    tmp = (FrameLevel)i;
                    break;
                }
            }
            if (tmp != _level)
            {
                _level = tmp;
                EventManager.SharedInstance.PushFixEvent(CoreEventDefine.EID_CORE_FPS_LEVEL_CHANGED, _level);
            }
        }
        #endregion
    }
}
