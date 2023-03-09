using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Test.AssemblyTest
{
    public class AssemblyTest
    {
        private readonly string CN_UPDATE_DLL_PATH = "/Update/Dll/Hotfix.bytes";

        public void Start()
        {
            Type updateMgrType = typeof(UpdateManager);
            if (updateMgrType != null)
            {
                string[] args = new string[] { "-static", "-Start", "0" };
                ////调用静态函数，不用传参
                //MethodInfo startMethod = updateMgrType.GetMethod("Start");
                //if (startMethod != null)
                //{
                //    startMethod.Invoke(null, new object[] { args });
                //}

                ////调用非静态函数
                //string[] argsNotStatic = new string[] { "-notstatic", "-QuickStart", "1" };
                //MethodInfo quickStartMethod = updateMgrType.GetMethod("QuickStart");
                //if (quickStartMethod != null)
                //{
                //    //创建对象
                //    object inst = Activator.CreateInstance(updateMgrType);
                //    quickStartMethod.Invoke(inst, new object[] { argsNotStatic });
                //}

                //updateMgrType.InvokeMember("Start", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[] { args });

                //调用私有函数
                MethodInfo privateStartMethod = updateMgrType.GetMethod("PrivateStart", BindingFlags.NonPublic | BindingFlags.Instance);
                if (privateStartMethod != null)
                {
                    //创建对象
                    object inst = Activator.CreateInstance(updateMgrType);
                    privateStartMethod.Invoke(inst, new object[] { args });
                }
            }
        }

        public void StartLoad()
        {
            Assembly updateAssembly = LoadAssembly(CN_UPDATE_DLL_PATH);
            if (updateAssembly == null)
            {
                updateAssembly = Assembly.GetCallingAssembly();
            }
            if (updateAssembly != null)
            {
                Type updateType = updateAssembly.GetType("GameLib.UpdateForm.Form.UIUpdateForm");

                MethodInfo methodInfo = updateType.GetMethod("Start");
                methodInfo.Invoke(null, new object[] { });

                string[] args = new string[] { "-usebundle", "-platform", "0" };
                updateType.InvokeMember("Start", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[] { args });
            }
        }

        /// <summary>
        /// 根据路径加载DLL动态库，返回Assembly程序集
        /// </summary>
        /// <param name="dllPath"></param>
        /// <returns></returns>
        public Assembly LoadAssembly(string dllPath)
        {
            Assembly assembly = null;
            byte[] dllBytes = LoadDLLBytes(dllPath);
            if (dllBytes != null && dllBytes.Length > 0)
            {
                assembly = Assembly.Load(dllBytes);
            }
            return assembly;
        }

        /// <summary>
        /// 根据Dll的存储路径通过流加载出二进制数据
        /// </summary>
        /// <param name="dllPath"></param>
        /// <returns></returns>
        private byte[] LoadDLLBytes(string dllPath)
        {
            byte[] dllBytes = null;
            if (!string.IsNullOrEmpty(dllPath) && File.Exists(dllPath))
            {
                try
                {
                    using (FileStream readStream = new FileStream(dllPath, FileMode.Open))
                    {
                        int len = (int)readStream.Length;
                        dllBytes = new byte[len];
                        readStream.Read(dllBytes, 0, len);
                        readStream.Close();
                        readStream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Load DLL Failed, the error msg:" + ex.Message);
                }
            }
            return dllBytes;
        }
    }
}
