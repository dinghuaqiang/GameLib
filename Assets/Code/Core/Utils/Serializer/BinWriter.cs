using System;
using System.IO;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 二进制写的操作的模板类,通过他可以形成一系列的二进制写的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinWriter<T>
    {
        internal static Action<BinaryWriter, T> _invoke = null;
        public static Action<BinaryWriter, T> Invoke
        {
            get
            {
                return _invoke;
            }
        }
        static BinWriter()
        {
            BinWriterInit.DoInit();
        }
    }
}
