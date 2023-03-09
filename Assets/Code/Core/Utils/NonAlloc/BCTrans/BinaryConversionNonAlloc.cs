namespace GameLib.Core.Utils
{
    /// <summary>
    /// 无GC的进制转换
    /// </summary>
    public static class BinaryConversionNonAlloc
    {
        // 每次不用新分配4个字节来进行转换,达到无GC的操作，提升性能，特别是网络操作
        // EG. 
        // write header(size) into buffer at position
        // IntToBytesBigEndianNonAlloc(message.Count, payload, position);
        public static void IntToBytesBigEndianNonAlloc(int value, byte[] bytes, int offset = 0)
        {
            bytes[offset + 0] = (byte)(value >> 24);
            bytes[offset + 1] = (byte)(value >> 16);
            bytes[offset + 2] = (byte)(value >> 8);
            bytes[offset + 3] = (byte)value;
        }

        //bytes[] ==> int
        public static int BytesToIntBigEndian(byte[] bytes)
        {
            return (bytes[0] << 24) |
                   (bytes[1] << 16) |
                   (bytes[2] << 8) |
                    bytes[3];
        }
    }
}
