using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 启动新进程 
        /// TODO:这个工具代码应该放在Editor里面去，不应该放在应用内使用，基本上只会在开发阶段用到
        /// </summary>
        public static class ProcessCMD
        {
            //工程编译完成的回调
            private static Action _onSlnCompileFinished = null;
            //编译工程的路径
            private static string _solution = null;
            //编译的进程
            private static Process _compileProcess;
            /// <summary>
            /// 打开一个解决方案
            /// </summary>
            private static void OpenVS(string path)
            {
                var dirInfo = new DirectoryInfo(path);
                string fullPath = dirInfo.FullName;
                DevLog.Log("Start Resolution:" + fullPath);
                var vsProcess = System.Diagnostics.Process.Start(fullPath);
                vsProcess.WaitForInputIdle(3000);
                DevLog.Log("Start Resolution Finished!");
            }

            /// <summary>
            /// 执行一个Bat文件
            /// </summary>
            /// <param name="batPath">Bat文件路径[c:/xx/aa.bat]</param>
            public static void StartProcess(string batPath) 
            {
                if (string.IsNullOrEmpty(batPath))
                {
                    DevLog.LogError(string.Format("传入的路径:{0}是空的！", batPath));
                    return;
                }
                FileInfo fileInfo = new FileInfo(batPath);
                if (fileInfo == null)
                {
                    DevLog.LogError(string.Format("传入的路径:{0}是空的！", batPath));
                    return;
                }
                string dirName = fileInfo.DirectoryName;
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                start.FileName = batPath;
                start.WorkingDirectory = dirName;
                start.CreateNoWindow = false;
                start.ErrorDialog = true;
                start.UseShellExecute = true;
                start.RedirectStandardInput = false;
                start.RedirectStandardOutput = false;
                start.RedirectStandardError = false;
                System.Diagnostics.Process.Start(start);
            }

            /// <summary>
            /// 打开资源管理器
            /// </summary>
            /// <param name="filePath">路劲</param>
            private static void OpenWinExplorer(string filePath)
            {
                //打开目录并定位文件
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                //Windows下把路径分割符修改一下
                psi.Arguments = "/e,/select," + filePath.Replace('/', '\\');
                System.Diagnostics.Process.Start(psi);
            }

            /// <summary>
            /// 打开资源管理器
            /// </summary>
            /// <param name="filePath">路劲</param>
            public static void BrowseFolder(String path)
            {
                Process prcShell = new Process();
                if (Application.platform == RuntimePlatform.WindowsEditor)
                {
                    prcShell.StartInfo.FileName = "explorer.exe";
                    path = path.Replace('/', '\\');
                }
                else if (Application.platform == RuntimePlatform.OSXEditor)
                {
                    prcShell.StartInfo.FileName = "open";
                    path = path.Replace('\\', '/');
                }
                prcShell.StartInfo.Arguments = path;
                prcShell.Start();
            }


            /// <summary>
            /// 编译sln工程
            /// </summary>
            /// <param name="buildTarget">目标平台</param>
            /// <param name="solution">解决方案的路径</param>
            /// <param name="callBack">编译完成之后的回调</param>
            private static void CompileSolution(BuildTarget buildTarget, string solution, Action callBack)
            {
                _onSlnCompileFinished = callBack;
                _solution = solution;
                switch (buildTarget)
                {
                    case BuildTarget.Android:
                        DoCompileSolution("/t:Rebuild /property:Configuration=Android " + solution);
                        break;
                    case BuildTarget.iOS:
                        DoCompileSolution("/t:Rebuild /property:Configuration=IOS " + solution);
                        break;
                    case BuildTarget.StandaloneWindows:
                    case BuildTarget.StandaloneWindows64:
                        DoCompileSolution("/t:Rebuild /property:Configuration=STANDALONE_WIN " + solution);
                        break;
                    default:
                        DoCompileSolution("/t:Rebuild /property:Configuration=DEBUG " + solution);
                        break;
                }
            }

            /// <summary>
            /// 对解决方案进行编译
            /// </summary>
            /// <param name="argument"></param>
            //TODO  这里还有处理下已编译好的dll和设置WorkingDirectory
            private static void DoCompileSolution(string argument)
            {
                ////删除Bin目录
                //if (Directory.Exists(Defines.CN_DLL_BIN_PATH))
                //{
                //    Directory.Delete(Defines.CN_DLL_BIN_PATH, true);
                //}
                DevLog.Log("编译解决方案:" + argument);
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe");
                start.Arguments = argument;
                //start.WorkingDirectory = Defines.WorkDir;
                start.CreateNoWindow = false;
                start.ErrorDialog = true;
                start.UseShellExecute = true;
                start.RedirectStandardInput = false;
                start.RedirectStandardOutput = false;
                start.RedirectStandardError = false;

                _compileProcess = new System.Diagnostics.Process();
                _compileProcess.EnableRaisingEvents = true;
                _compileProcess.Exited += CompileFinished;
                _compileProcess.StartInfo = start;
                _compileProcess.Start();
            }

            private static void CompileFinished(object sender, EventArgs e) 
            {
                if (_compileProcess == null) return;

                if (!_compileProcess.HasExited)
                {
                    _compileProcess.WaitForExit();
                }

                //如果编译程序正常退出
                if (_compileProcess.ExitCode == 0)
                {
                    UnityEngine.Debug.Log("动态库代码编译成功!");
                    if (_onSlnCompileFinished != null) 
                        _onSlnCompileFinished();
                }
                else
                {
                    DevLog.LogError("自动编译失败.请手动打开解决方案" + _solution + "编译;失败代码:" + _compileProcess.ExitCode);
                }
                _compileProcess = null;
            }
        }
    }
}
