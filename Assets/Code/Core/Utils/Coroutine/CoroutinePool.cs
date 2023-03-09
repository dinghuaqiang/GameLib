using System.Collections;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 协程池处理
    /// </summary>
    public class CoroutinePool
    {
        //脚本所在对象的名字
        private readonly static string _name = "[CoroutinePool]";
        //脚本所在对象
        private static GameObject _go = null;
        //脚本引用
        private static CoroutinePoolScript _coro = null;

        //构造函数
        static CoroutinePool()
        {
            Initialize();
        }

        //添加任务
        public static Coroutine AddTask(IEnumerator task)
        {

            if (_coro != null)
            {
                if (!_go.activeInHierarchy)
                {
                    Debug.LogError(_name + " is inactive!");
                    return null;
                }
                return _coro.StartCoroutine(task);
            }
            return null;
        }

        //添加任务
        public static Coroutine AddTask(FCoroRunnable task)
        {

            if (_coro != null && task != null)
            {
                if (!_go.activeInHierarchy)
                {
                    Debug.LogError(_name + " is inactive!");
                    return null;
                }
                task.Handle = _coro.StartCoroutine(task.Run());
                return task.Handle;
            }
            return null;
        }

        //停止任务
        public static void StopTask(Coroutine routine)
        {
            if(_coro != null)
                _coro.StopCoroutine(routine);
        }

        //停止任务
        public static void StopTask(IEnumerator routine)
        {
            if (_coro != null)
                _coro.StopCoroutine(routine);
        }

        //停止任务
        public static void StopTask(FCoroRunnable task)
        {
            if (_coro != null)
                _coro.StopCoroutine(task.Handle);
        }
        //初始化
        public static void Initialize()
        {
            if (_coro == null)
            {
                _go = new GameObject(_name);              
                _coro = _go.AddComponent<CoroutinePoolScript>();                
                GameObject.DontDestroyOnLoad(_go);              
            }
        }

        //卸载
        public static void UnInitialize()
        {
            if (_coro != null)
            {   
                if(_go != null) GameObject.Destroy(_go);
                _coro = null;
                _go = null;
            }
        }   
    }
}
