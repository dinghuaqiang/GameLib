using System;
using System.Collections.Generic;
using System.IO;

using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 日志组,对日志进行分组处理
    /// </summary>
    public class LogGroup : IComparable<LogGroup>
    {
        public string GroupName = string.Empty;

        private LogTextList _content = new LogTextList();
        private StreamWriter _output = null;
        private string _filePath = "";
        private object _lockerObj = new object();

        public LogGroup(string name, string fullPath)
        {
            GroupName = name;
            _filePath = fullPath;
            try
            {
                _output = new StreamWriter(_filePath, true, Encoding.UTF8);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
        }

        public int CompareTo(LogGroup other)
        {
            return GroupName.CompareTo(other.GroupName);
        }

        //释放文件句柄
        public void FreeHandler()
        {
            lock (_lockerObj)
            {
                try
                {
                    if (_output != null)
                    {
                        UnityEngine.Debug.Log("FreeHandler:"+GroupName);
                        _output.Close();
                        _output = null;
                    }
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    _output = null;
                }
            }
        }

        //分配文件句柄
        public void AllocHandler()
        {
            lock (_lockerObj)
            {
                try
                {
                    if (_output == null)
                    {
                        UnityEngine.Debug.Log("AllocHandler:" + GroupName);
                        _output = new StreamWriter(_filePath, true, Encoding.UTF8);
                        
                    }
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
            }
        }


        public void Add(string text)
        {
            lock (_lockerObj)
            {
                _content.Add(text);
            }
        }

        public void ToFile()
        {
            lock (_lockerObj)
            {
                if (_output != null && _content.Count > 0)
                {
               
                    if (_content != null)
                    {
                        for (int i = 0; i < _content.Count; ++i)
                        {
                            _output.WriteLine(_content[i]);
                        }
                        _content.Clear();
                    }                
                    _output.Flush();
                }
            }
        }
    }
}
