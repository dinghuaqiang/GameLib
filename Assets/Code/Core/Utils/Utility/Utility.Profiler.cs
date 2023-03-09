using System;
using System.Diagnostics;
using System.Threading;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 封装Unity的Profiler.
        /// 通过设置宏 ENABLE_PROFILER 来确定是否开启性能采样的收集
        /// </summary>
        public static class Profiler
        {
            /// <summary>
            /// 开始采样
            /// </summary>
            /// <param name="name"></param>
            [Conditional("ENABLE_PROFILER")]
            public static void Begin(string name)
            {
                if (!Thread.CurrentThread.IsBackground)
                {
                    UnityEngine.Profiling.Profiler.BeginSample(name);
                }
            }

            [Conditional("ENABLE_PROFILER")]
            public static void BeginObj(object obj, string name)
            {
                if (obj != null)
                {
                    BeginType(obj.GetType(), name);
                }
                else
                {
                    Begin(name);
                }
            }

            [Conditional("ENABLE_PROFILER")]
            public static void BeginType(Type type, string name)
            {
                if (type != null)
                {
                    Begin(type.Name + name);
                }
                else
                {
                    Begin(name);
                }
            }

            /// <summary>
            /// 结束采样
            /// </summary>
            [Conditional("ENABLE_PROFILER")]
            public static void End()
            {
                if (!Thread.CurrentThread.IsBackground)
                {
                    UnityEngine.Profiling.Profiler.EndSample();
                }

            }

            /// <summary>
            /// 当前信息
            /// </summary>
            /// <returns></returns>
            public static string Infomation()
            {
                var sb = StringUtils.NewStringBuilder;
                sb.AppendLine("Profiler:");
#if ENABLE_PROFILER
                sb.AppendFormat("MonoHeapSize:{0}", UnityEngine.Profiling.Profiler.GetMonoHeapSizeLong() / 1048576);
                sb.AppendLine();
                sb.AppendFormat("GetMonoUsedSize:{0}", UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() / 1048576);
                sb.AppendLine();
                sb.AppendFormat("GetTotalAllocatedMemory:{0}", UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() / 1048576);
                sb.AppendLine();
                //sb.AppendFormat("GetRuntimeMemorySize:{0}", Profiler.GetRuntimeMemorySizeLong(null) / 1048576);
                //sb.AppendLine();
                sb.AppendFormat("GetTotalUnusedReservedMemory:{0}", UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong() / 1048576);
                sb.AppendLine();
#endif
                return sb.ToString();

            }

            /// <summary>
            /// 获取某个对象的内存
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static long GetObjectRuntimeMemory(UnityEngine.Object obj)
            {
#if ENABLE_PROFILER
                return UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(obj);
#else
            return 0;
#endif
            }

            /// <summary>
            /// 获取游戏物体运行时的内存大小
            /// 这个可以做成工具，比如选中一个物体，看在游戏中占有的内存大小
            /// </summary>
            /// <param name="obj"></param>
            /// <returns>占用的内存大小</returns>
            public static long GetRuntimeSize(UnityEngine.Object obj)
            {
                long memSize = 0;
                if (obj != null)
                {
                    memSize = UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(obj);
                }
                return memSize;
            }
        }
    }
}
