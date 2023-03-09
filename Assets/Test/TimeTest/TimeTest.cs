using System;
using UnityEngine;

namespace Assets.Test
{
    public class TimeTest : MonoBehaviour
    {
        //一天总共的秒数
        private const int CN_ONE_DAY_SECONDS = 24 * 60 * 60;
        //一小时总共的秒数
        private const int CN_ONE_HOUR_SECONDS = 60 * 60;
        //一分钟总共的秒数
        private const int CN_ONE_MIN_SECONDS = 60;
        //明天0点的时间戳
        private long _nextDayMidNight = 0;
        private bool _hasRefeshed = false;
        //当前界面停留的总时间(秒)
        private float _passTime = 0;
        //用于减少打印次数，间隔1秒进行打印显示
        private float _lastPassTime = 1;
        /// <summary>
        /// 当前的时间戳
        /// </summary>
        private long TimeStampNow
        {
            get
            {
                return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            }
        }

        private delegate void OnNewDayComming();
        private event OnNewDayComming OnNewDayEvent;

        private void Awake()
        {
            //用明天0点的时间戳作为结束时间
            _nextDayMidNight = GetNextDayZeroTimeStamp();
            //int reaminSec = (int)(_nextDayMidNight - TimeStampNow);
            ////晚上12点的倒计时
            //Debug.LogFormat("到今晚0点剩余时间:{0}", ConvertSecToDHMS(reaminSec));
            //设置一个到时的触发事件
            OnNewDayEvent += OnNewDayRefeshData;
        }

        private void OnNewDayRefeshData()
        {
            Debug.Log("新的一天了!");
        }

        private void Update()
        {
            //TODO  这里其实是有问题的，没有进行轮询的操作。 只算了第二天的0点，如果是第三天0点这里就不行了的
            if (TimeStampNow >= _nextDayMidNight && !_hasRefeshed)
            {
                //到点之后执行回调
                _hasRefeshed = true;
                if (OnNewDayEvent != null)
                {
                    OnNewDayEvent();
                }
            }
            else
            {
                //计算当前经过的总时间（每帧执行的时间相加）
                _passTime += Time.deltaTime;
                //每隔1秒进入一次打印
                if (_passTime - _lastPassTime > 1)
                {
                    _lastPassTime = _passTime;
                    Debug.LogFormat("到今晚0点剩余时间:{0}", ConvertSecToDHMS((int)(_nextDayMidNight - TimeStampNow)));
                }
            }
        }

        /// <summary>
        /// 把秒数转换成天时分秒
        /// </summary>
        /// <param name="totalSeconds">总的秒数</param>
        /// <returns></returns>
        private string ConvertSecToDHMS(int totalSeconds)
        {
            int days = totalSeconds / CN_ONE_DAY_SECONDS;
            int hours = totalSeconds % CN_ONE_DAY_SECONDS / CN_ONE_HOUR_SECONDS;
            int minutes = totalSeconds % CN_ONE_HOUR_SECONDS / CN_ONE_MIN_SECONDS;
            int seconds = totalSeconds % CN_ONE_HOUR_SECONDS % CN_ONE_MIN_SECONDS;
            return string.Format("{0}天：{1}时：{2}分：{3}秒：", days, hours, minutes, seconds);
        }

        //获取第二天的0点的时间戳（游戏中常用作活动的刷新，可以做个计时器，获取到这个时间戳然后我当前时间戳相减做回调处理）
        private long GetNextDayZeroTimeStamp()
        {
            //当天0时0分0秒
            DateTime todayMidnight = DateTime.Now.Date;
            //第二天的0时0分0秒
            DateTime nextDayMidnight = todayMidnight.AddDays(1);
            return ConvertToTimeStamp(nextDayMidnight);
        }

        /// <summary>
        /// DateTime转时间戳
        /// </summary>
        /// <param name="targetDateTime">DateTime</param>
        /// <returns>时间戳（秒）</returns>
        public long ConvertToTimeStamp(DateTime targetDateTime)
        {
            return (targetDateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="timeStamp">时间戳（秒）</param>
        /// <returns>DateTime</returns>
        public DateTime GetDateTimeFromTimeStamp(long timeStamp)
        {
            //获取到当前时区的开始时间戳
            DateTime startDateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1, 0, 0, 0), TimeZoneInfo.Local);
            long targetTimeStamp = ((long)timeStamp * 10000000);
            TimeSpan targetTS = new TimeSpan(targetTimeStamp);
            DateTime targetDateTime = startDateTime.Add(targetTS);
            return targetDateTime;
        }
    }
}
