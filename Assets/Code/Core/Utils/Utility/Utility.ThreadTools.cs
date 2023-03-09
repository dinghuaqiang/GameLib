using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 线程工具类，可参考http://t.csdn.cn/ZXGoF
        /// </summary>
        public static class ThreadTools
        {
            /// <summary>
            /// 启动一个线程池执行
            /// </summary>
            /// <param name="callback"></param>
            /// <param name="maxThreadCount"></param>
            public static void StartThreadsByPool(WaitCallback callback, int maxThreadCount = 5)
            {
                //ThreadPool.SetMaxThreads(maxThreadCount, maxThreadCount);
                for (int i = 0; i < maxThreadCount; i++)
                {
                    ThreadPool.QueueUserWorkItem(callback);
                }
            }

            public static void StartThread(Action excuteFun, int threadCount = 3)
            {
                for (int i = 0; i < threadCount; i++)
                {
                    Thread thread = new Thread(new ThreadStart(excuteFun));
                    thread.Start();
                }
            }

            public static void StartThread(Action<object> excuteFunc, int threadCount = 3)
            {
                for (int i = 0; i < threadCount; i++)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(excuteFunc));
                    thread.Start();
                }
            }

            public static void StartTask(Action excuteFunc)
            {
                Task task = new Task(excuteFunc);
                //异步线程
                task.Start();
                //等待task内部执行完毕，才会往后直行，卡主线程，Task实例方法
                //task.Wait(1000);//等待1000毫秒后就往后直行不管有没有执行结束

                //异步线程
                //Task.Run(excuteFunc);
                //同步线程
                //task.RunSynchronously();

                //开个线程，在里面继续开子线程
                Task mainTask = new Task(()=> {
                    Task childTask = new Task(()=> 
                    {
                        //执行子线程做的事情
                    },
                    //子线程附加到父线程，父线程必须等待所有子线程执行结束才能结束，相当于Task.WaitAll(childTask)。
                    TaskCreationOptions.AttachedToParent);
                    childTask.Start();
                },
                //不允许子任务附加到父任务上，反AttachedToParent，和默认效果一样。
                TaskCreationOptions.DenyChildAttach);
                mainTask.Start();
                mainTask.Wait();
            }
        }
    }
}
