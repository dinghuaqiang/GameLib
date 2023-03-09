using System.Collections.Generic;
using System.Threading;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志写操作者
    /// </summary>
    public class LogWriter : ILogWriter
    {
        //所有其他有分类信息日志的存储
        private Dictionary<string, LogGroup> _groups = new Dictionary<string, LogGroup>();        
        //没有分类的日志存储
        private LogGroup _null_groups = null;
        //错误日志的存储
        private LogGroup _error_groups = null;

        //临时日志分组列表
        private List<LogGroup> _tmp_groups = new List<LogGroup>();

        //处理写日志的线程
        private Thread _thread = null;
        //当前线程状态
        private bool _isRunning = false;

        //触发写操作的事件
        private AutoResetEvent _event = new AutoResetEvent(false);
        //写group字典的锁
        private object _locker = new object();

        //日志目录
        private string _logDir = string.Empty;

        //构造函数
        public LogWriter(string logDir)
        {
            _logDir = logDir;
        }

        //开始
        public void Start()
        {
            _thread = new Thread(new ThreadStart(DoWriteFile));
            _thread.IsBackground = true;
            _thread.Start();             
        }

        //停止
        public void Stop()
        {
            _isRunning = false;
            _event.Set();
            if (_thread != null)
            {
                _thread.Join(1000);
                _thread = null;
            }
        }

        public void Pause()
        {
            var g = new List<LogGroup>();
            lock (_locker)
            {
                //把错误信息的group给添加进去
                if (_error_groups != null)
                {
                    g.Add(_error_groups);
                }

                //把没有分类信息的group给添加进去
                if (_null_groups != null)
                {
                    g.Add(_null_groups);
                }

                //把其他的group给添加进去
                var e = _groups.GetEnumerator();
                try
                {
                    while (e.MoveNext())
                    {
                        g.Add(e.Current.Value);
                    }
                }
                finally
                {
                    e.Dispose();
                }
            }

            for (int i = 0; i < _tmp_groups.Count; i++)
            {
                g[i].FreeHandler();
            }
        }
        public void Resume()
        {
            var g = new List<LogGroup>();
            lock (_locker)
            {
                //把错误信息的group给添加进去
                if (_error_groups != null)
                {
                    g.Add(_error_groups);
                }

                //把没有分类信息的group给添加进去
                if (_null_groups != null)
                {
                    g.Add(_null_groups);
                }

                //把其他的group给添加进去
                var e = _groups.GetEnumerator();
                try
                {
                    while (e.MoveNext())
                    {
                        g.Add(e.Current.Value);
                    }
                }
                finally
                {
                    e.Dispose();
                }
            }

            for (int i = 0; i < _tmp_groups.Count; i++)
            {
                g[i].AllocHandler();
            }
        }

        //添加信息日志
        public virtual void AddInfo(string message, string gName = null)
        {
            var group = GetGroup(gName);
            group.Add(message);
            _event.Set();                    
        }

        //添加错误日志
        public virtual void AddError(string message)
        {
            if (_error_groups == null)
            {
                _error_groups = new LogGroup(LogDefine.ErrorLog, GetFilePath(LogDefine.ErrorLog));
            }
            _error_groups.Add(message);
            _event.Set();  
        }

        //一次性把剩余日志写完
        public void Flush()
        {
            for (int i = 0; i < _tmp_groups.Count; i++)
            {
                _tmp_groups[i].ToFile();
            }
        }

        //获取分组
        private LogGroup GetGroup(string gName)
        {
            if (string.IsNullOrEmpty(gName))
            {
                if (_null_groups == null)
                {
                    _null_groups = new LogGroup(LogDefine.DefaultLogFileName, GetFilePath(LogDefine.DefaultLogFileName));
                }
                return _null_groups;
            }
            else
            {
                LogGroup result;
                _groups.TryGetValue(gName, out result);
                if (result == null)
                {
                    result = new LogGroup(gName, GetFilePath(gName));
                    lock (_locker)
                    {
                        _groups[gName] = result;
                    }
                }
                return result;
            }
        }

        //写文件的方法--线程执行的方法
        private void DoWriteFile()
        {
            _isRunning = true;
            while (_isRunning)
            {
                _event.WaitOne();
                _tmp_groups.Clear();

                lock (_locker)
                {
                    //把错误信息的group给添加进去
                    if (_error_groups != null)
                    {
                        _tmp_groups.Add(_error_groups);
                    }

                    //把没有分类信息的group给添加进去
                    if (_null_groups != null)
                    {
                        _tmp_groups.Add(_null_groups);
                    }

                    //把其他的group给添加进去
                    var e = _groups.GetEnumerator();
                    try
                    {
                        while (e.MoveNext())
                        {
                            _tmp_groups.Add(e.Current.Value);
                        }
                    }
                    finally
                    {
                        e.Dispose();
                    }
                }

                for (int i = 0; i < _tmp_groups.Count; i++)
                {
                    _tmp_groups[i].ToFile();
                }

                //使线程等待一个时间
                Thread.Sleep(1000);
            }
        }

        //获取文件路径
        private string GetFilePath(string gName)
        {
            return string.Format("{0}/{1}.txt", _logDir,string.IsNullOrEmpty(gName) ? LogDefine.DefaultLogFileName : gName);
        }
    }
}
