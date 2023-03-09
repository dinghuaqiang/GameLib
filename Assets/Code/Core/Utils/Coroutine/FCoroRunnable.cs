using System.Collections;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 协成的处理
    /// </summary>
    public abstract class FCoroRunnable
    {
        //当前执行的句柄
        public Coroutine Handle { get; set; }

        //当前需要执行的内容
        public abstract IEnumerator Run();

    }
}
