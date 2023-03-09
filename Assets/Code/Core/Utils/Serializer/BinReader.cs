using System;
using System.IO;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 二进制读的操作的模板类,通过他可以形成一系列的二进制读取的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinReader<T>
    {
        internal static Func<BinaryReader, T> _invoke = null;
        public static Func<BinaryReader, T> Invoke
        {
            get
            {
                return _invoke;
            }
        }
        static BinReader()
        {
            BinReaderInit.DoInit();
        }
    }
}
