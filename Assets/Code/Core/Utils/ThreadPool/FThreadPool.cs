using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 线程池
    /// </summary>
    public class FThreadPool
    {       
        //线程任务列表
        private static LinkedList<FRunnable> tasks = new LinkedList<FRunnable>();
        //线程数量
        private static int count = 0;
        //任务数量
        private static int task_count = 0;
        //任务数量的锁
        private static object task_count_locker = new object();
        //线程数量的锁
        private static object thread_count_locker = new object();
        //最后一个线程添加的时间
        private static float time_lastadd = 0f;
        //任务总量
        private static long task_total = 0L;
        //移除的线程数量锁
        private static object remove_count_locker = new object();
        //移除数量
        private static int remove_count = 0;      

        //添加任务
        public static void AddTask(FRunnable r)
        {
            LinkedList<FRunnable> obj = FThreadPool.tasks;
            lock (obj)
            {
                FThreadPool.tasks.AddFirst(r);
                object obj2 = FThreadPool.task_count_locker;
                lock (obj2)
                {
                    FThreadPool.task_count++;
                    FThreadPool.task_total += 1L;
                }
                FThreadPool.time_lastadd = UnityEngine.Time.realtimeSinceStartup;
                Monitor.Pulse(FThreadPool.tasks);
            }

        }

        //任务总数
        public static long TaskTotal()
        {
            object obj = FThreadPool.task_count_locker;
            long result;
            lock (obj)
            {
                result = FThreadPool.task_total;
            }
            return result;
        }

        //最后添加任务的时间
        public static float TimeLastAdd()
        {
            return FThreadPool.time_lastadd;
        }

        //添加线程
        public static void AddThread()
        {   
            var th = new Thread(new ThreadStart(delegate
             {
                 new FThreadPool().Run();
             }));
            th.IsBackground = true;
            th.Start();
            
        }

        //线程数量
        public static int ThreadCount()
        {
            object obj = FThreadPool.thread_count_locker;
            int result;
            lock (obj)
            {
                result = FThreadPool.count;
            }
            return result;
        }

        //移除线程
        public static void RemoveThread()
        {
            object obj = FThreadPool.thread_count_locker;
            lock (obj)
            {
                if (FThreadPool.count - FThreadPool.remove_count > 0)
                {
                    FThreadPool.remove_count++;
                    try
                    {
                        //这里添加一个空任务,用于线程退出
                        AddTask(null);
                    }
                    catch { }
                }
            }
        }

        //启动线程
        public static void StartUp()
        {
            if (ThreadCount() == 0)
            {
                //根据处理器的数量来启动线程,最大4个线程
                var pc = SystemInfo.processorCount > 4 ? 4 : SystemInfo.processorCount;
                for (int i = 0; i < pc; i++)
                {
                    AddThread();
                }
            }
        }

        //关闭所有线程
        public static void ShutDown()
        {
            object obj = FThreadPool.thread_count_locker;
            lock (obj)
            {
                FThreadPool.remove_count = FThreadPool.count;   
                try
                {
                    Monitor.Exit(FThreadPool.tasks);
                    var cnt = FThreadPool.count;
                    for (int i = 0; i < cnt; i++)
                    {
                        //这里添加一个空任务,用于线程退出
                        AddTask(null);    
                        //等待100毫秒
                        Thread.Sleep(100);
                    }
                }
                catch{ }
            }
        }
       
        #region//ThreadPool的成员方法
        //构造函数
        private FThreadPool()
        {
            object obj = FThreadPool.thread_count_locker;
            lock (obj)
            {
                FThreadPool.count++;
            }
        }

        //运行函数
        private void Run()
        {
            System.Diagnostics.Trace.WriteLine("Start a thread! ThreadPool has threads count:" + FThreadPool.count);
            while (true)
            {
                try
                {
                    FRunnable runnable = null;
                    LinkedList<FRunnable> obj = FThreadPool.tasks;
                    lock (obj)
                    {
                        while (FThreadPool.tasks.Count == 0)
                        {
                            Monitor.Wait(FThreadPool.tasks);
                        }
                        if (FThreadPool.tasks.Count > 0)
                        {
                            runnable = FThreadPool.tasks.Last.Value;
                            FThreadPool.tasks.RemoveLast();
                            object obj2 = FThreadPool.task_count_locker;
                            lock (obj2)
                            {
                                FThreadPool.task_count--;
                            }
                        }
                    }

                    if (runnable != null) runnable.Run();

                    object obj3 = FThreadPool.thread_count_locker;
                    lock (obj3)
                    {
                        if (FThreadPool.remove_count > 0)
                        {
                            FThreadPool.remove_count--;
                            FThreadPool.count--;                            
                            break;
                        }
                    }
                    //每执行一个任务,休息10毫秒
                    Thread.Sleep(10);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.Fail(ex.Message, ex.StackTrace);
                }                
            }
            System.Diagnostics.Trace.WriteLine("Quit a thread,ThreadPool has threads count:"+ FThreadPool.count);
        }
        #endregion

    }
}
