using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public class FLogManager
    {
        #region//静态构造函数

        //初始化标记
        private static bool _initialized = false;

        //LogManager实例
        private static FLogManager _instance;
        public static FLogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FLogManager();
                }

                //判断是否初始化,如果没有初始化,那么就重新初始化
                if (!_initialized && _instance != null)
                {
                    _instance.Initialize();
                }

                return _instance;
            }
        }
        #endregion

        #region //私有变量

        //自定日志监听器
        private LoggerListener _loggerListener = null;
        //Trace监听器
        private LogTraceListener _listener = null;
        //unity监听器
        private LogUnityListener _unityListener = null;
        //写日志
        private ILogWriter _writer = null;
        //保存日志的文件夹上限
        private int _logDirCount = 10;
        //要提交的日志文件夹个数
        private int _commitLogDirCount = 5;

        #endregion

        #region//属性
        //Trace监听器
        public LogTraceListener Listener
        {
            get { return _listener; }           
        }
        #endregion

        #region//公共接口

        //初始化
        public void Initialize()
        {

            //0.判断初始化标记
            if (_initialized)
            {
                UnityEngine.Debug.Log("LogManager has been initialized");
                return;
            }

            //定义一个dir
            string dir = null;

            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                //1.判断目录创建是否成功            
                try
                {
                    dir = GetLogOutDir();
                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.LogException(ex);
                    return;
                }
            }

            //2.目录创建成功后,标记初始化成功
            _initialized = true;
           
           
            //3.写日志的对象实例
            if (Application.isEditor || Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _writer = new LogDebugWriter();

            }
            else
            {             
                _writer = new LogWriter(dir);

                //5.Unity自带的日志监听器
                _unityListener = new LogUnityListener(_writer);
                _unityListener.Start();
            }
            
             //4.1自定义的日志监听器
            _loggerListener = new LoggerListener(_writer);
            _loggerListener.Start();

            //4.2Trace日志监听器
            _listener = new LogTraceListener(_writer);
#if !UNITY_WEBGL
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                System.Diagnostics.Trace.Listeners.Clear();
                System.Diagnostics.Trace.Listeners.Add(_listener);
            }
#endif
            //6.启动写日志到文件处理
            _writer.Start();

            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                //7.注册系统事件，当作用域卸载、进程退出、未捕获异常等
                registerSystemEvent();


                deleteOverLogDirCountDirs();
            }

        }

        public void UnInitialize()
        {
            if (_listener != null)
            {
#if !UNITY_WEBGL
                if (Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    System.Diagnostics.Trace.Listeners.Remove(_listener);
                }
#endif
                _listener = null;
            }
            if (_unityListener != null)
            {
                _unityListener.Stop();
                _unityListener = null;
            }
            if (_writer != null)
            {   
                _writer.Stop();
                _writer = null;
            }
 
        }

        /// <summary>
        ///返回自定义的用于注册unity日志的回调函数，方便外部框架调用，注册到新的日志系统中
        ///比如接入Bugly sdk，sdk中已经使用了Application.RegisterLogCallback方法，就需要把这个回调函数
        ///注册到Bugly提供的接口中
        /// </summary>
        /// <returns></returns>
        public void GetUnityListenerLogCallbackFunc(string condition, string stackTrace, LogType type)
        {
            if (_unityListener != null)
            {
                _unityListener.LogCallback(condition, stackTrace, type);
            }
        }

        //手动添加log，有些log在线程中报的，不会自动触发LogCallback函数，需要手动调用
        public void ManualLog(string condition, LogType type)
        {
            if (_unityListener != null)
                _unityListener.LogCallback(condition, "", type);
        }

        //获取最新的几条日志,用于上传日志
        public List<string> GetLatestLogs()
        {
            List<string> retList = new List<string>();
            List<string> dirList = getLogDirList();
            int logDirCount = _commitLogDirCount >= dirList.Count ? 0 : (dirList.Count - _commitLogDirCount);
            for (int i = logDirCount; i < dirList.Count; ++i)
            {
                string[] logFiles = Directory.GetFiles(dirList[i],"*.txt");
                if (logFiles != null)
                {
                    retList.AddRange(logFiles);
                }
            }
            //把一些其他日志文件也要获取
            retList.AddRange(getOtherLogFileList());
            return retList;
        }

        public void PauseWrite()
        {
            if (_writer != null)
            {
                _writer.Pause();
            }
        }

        public void ResumeWrite()
        {
            if (_writer != null)
            {
                _writer.Resume();
            }
        }

#endregion

#region 私有函数

        //注册系统事件，在注册事件里面添加日志flush功能，避免游戏退出时日志没写完
        private void registerSystemEvent()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            if (domain != null)
            {
                domain.UnhandledException += uncaughtException;
                domain.DomainUnload += onDomainUnload;
                domain.ProcessExit += onProcessExit;
            }
        }

        //未捕获异常
        private void uncaughtException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e != null)
            {
                var ex = e.ExceptionObject as Exception;
                if (ex != null)
                {
                    Debug.LogException(ex);
                }
            }
            _writer.Flush();
        }

        //卸载domain时
        private void onDomainUnload(object sender, EventArgs e)
        {
            _writer.Flush();
        }

        //进程退出
        private void onProcessExit(object sender, EventArgs e)
        {
            _writer.Flush();
        }


        //删除超出规定日志文件夹上限的文件夹
        private void deleteOverLogDirCountDirs()
        {
            try
            {
                List<string> dirList = getLogDirList();

                if (dirList.Count > _logDirCount)
                {
                    for (int i = 0; i < dirList.Count - _logDirCount; ++i)
                    {
                        FileUtils.DeleteDirectory(dirList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                FLogger.LogException(ex);
            }
        }

        //获取日志文件夹列表
        private List<string> getLogDirList()
        {
            string logRootDir = PathUtils.GetWritePath("Log"); 
            List<string> dirList = new List<string>();
            if (Directory.Exists(logRootDir))
            {
                dirList.AddRange(System.IO.Directory.GetDirectories(logRootDir));
                dirList.Sort(compare);
            }

            return dirList;
        }

        //获取其他Log日志文件列表
        private List<string> getOtherLogFileList()
        {
            string logRootDir = PathUtils.GetWritePath("Log");
            List<string> fileList = new List<string>();
            if (Directory.Exists(logRootDir))
            {
                fileList.AddRange(System.IO.Directory.GetFiles(logRootDir, "*.txt", SearchOption.TopDirectoryOnly));
            }
            return fileList;
        }

        //文件夹名字排序
        private int compare(string arg1, string arg2)
        {
            return arg1.CompareTo(arg2);
        }

        /// <summary>
        /// 获取日志的输出目录
        /// </summary>
        /// <returns></returns>
        private string GetLogOutDir()
        {
            string outRoot = PathUtils.GetWritePath("Log");
            UnityEngine.Debug.Log("LogFilePath:" + outRoot);
            if (!System.IO.Directory.Exists(outRoot))
            {
                System.IO.Directory.CreateDirectory(outRoot);
            }

            string outDir = outRoot + "/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss (ffff)");

            if (!System.IO.Directory.Exists(outDir))
            {
                System.IO.Directory.CreateDirectory(outDir);
            }

            return outDir;
        }
#endregion

    }
}
