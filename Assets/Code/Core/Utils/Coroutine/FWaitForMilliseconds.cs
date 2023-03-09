using UnityEngine;

namespace GameLib.Core.Utils
{
    public class FWaitForMilliseconds : CustomYieldInstruction
    {
        private float _waitUntilTime = -1f;

        /// <summary>
        ///   <para>The given amount of millisecond that the yield instruction will wait for.</para>
        /// </summary>
        public int waitTime
        {
            get;
            set;
        }

        public override bool keepWaiting
        {
            get
            {
                if (_waitUntilTime < 0)
                {
                    _waitUntilTime = Time.realtimeSinceStartup  + waitTime * 0.001f;
                }

                if (Time.realtimeSinceStartup < _waitUntilTime)
                {
                    _waitUntilTime = -1f;
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///   <para>Creates a yield instruction to wait for a given number of millisecond using unscaled time.</para>
        /// </summary>
        /// <param name="time"></param>
        public FWaitForMilliseconds(int time)
        {
            this.waitTime = time;
        }

    }
}
