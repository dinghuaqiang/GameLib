using GameLib.Core.Utils;
using GameLib.Core.Utils.IonicZlib;
using System;
using System.IO;

namespace GameLib.Core.Net
{
    /// <summary>
    /// 网络包加解密处理
    /// </summary>
    public class MessageSecurity
    {
        #region //成员变量
        //---------编码时处理---------
        private const int CN_ENCODING_BUFF_SIZE = 102400;
        private MemoryStream _encodeStream;
        private BinaryWriter _encodeWriter;
        //发送缓存最大为100k
        private byte[] _encodeBuffer = null;
        //------------------------

        //---------解码处理-----
        private const int CN_UNZIP_BUFF_SIZE = 8192;
        //压缩内存
        private MemoryStream _zipInputMS;
        private MemoryStream _zipOutMS;
        // zip解压时用于中间解压内存
        private byte[] _unzipBuffer = null;
        //------------------------
        #endregion

        #region //编码处理

        /// <summary>
        /// 编码处理
        /// </summary>
        /// <param name="mm"></param>
        /// <param name="msgID"></param>
        /// <param name="msgNo"></param>
        /// <returns></returns>
        public byte[] Encoding(byte[] mm, uint msgID,int msgNo)
        {
            if (_encodeBuffer == null)
            {
                //发送缓存最大为100k
                _encodeBuffer = new byte[CN_ENCODING_BUFF_SIZE];
                _encodeStream = new MemoryStream(_encodeBuffer);
                _encodeWriter = new FastBinaryWriter(_encodeStream);
            }

            MemoryStream m = _encodeStream;
            m.SetLength(0);
            m.Position = 0;
            BinaryWriter s = _encodeWriter;
            UInt32 size = 0;
            UInt32 tempId = 0;
            UInt32 timeNow = (UInt32)TimeUtils.GetNow();
            UInt32 id = (UInt32)msgID;

            size = (UInt32)mm.Length;

            tempId = (UInt32)msgNo ^ (0x6B << 10);
            tempId = tempId ^ (16 + size);

            s.Write(convertToBigInt(size + 16));
            s.Write(convertToBigInt(tempId));

            uint ext = tempId % 100;
            byte[] timeBytes = convertToBigInt(timeNow);
            byte[] idBytes = convertToBigInt(id);

            int total = sumTotal(timeBytes) + sumTotal(idBytes) + sumTotal(mm);
            s.Write(convertToBigInt((uint)total));

            s.Write(xor(timeBytes, ext));
            s.Write(xor(idBytes, ext));
            s.Write(xor(mm, ext));

            byte[] dataByte = new byte[size + 4 * 5];

            Buffer.BlockCopy(_encodeBuffer, 0, dataByte, 0, dataByte.Length);
            return dataByte;
        }

        //异或
        private static byte[] xor(byte[] value, uint arg)
        {
            for (int i = 0; i < value.Length; ++i)
            {
                value[i] = (byte)(value[i] ^ arg);
            }
            return value;
        }

        //求和
        private static int sumTotal(byte[] value)
        {
            int total = 0;

            for (int i = 0; i < value.Length; ++i)
            {
                total += value[i];
            }

            return total;
        }

        /// <summary>
        /// 将4字节byte转成32位整数，不用BitConvert方法，是因为服务器端是从0字节作为高位， C#自身是把0字节作为低位
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static byte[] convertToBigInt(uint value)
        {
            byte[] bs = new byte[4];
            bs[0] = (byte)(value >> 24);
            bs[1] = (byte)(value >> 16);
            bs[2] = (byte)(value >> 8);
            bs[3] = (byte)(value);
            return bs;
        }
        #endregion

        #region //解码处理
        /// <summary>
        ///  解码处理
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="buffer"></param>
        /// <param name="dataLen"></param>
        public void Decoding(MessageQueue queue,byte[] buffer, ref int dataLen)
        {
            // 未解析的字节数
            int nRemainDataSize = dataLen;

            int nParseIndex = 0;
            while (true)
            {
                var msgData = DecodingEx(buffer, ref nParseIndex, ref nRemainDataSize);
                if (msgData == null) break;
                queue.PushMsg(msgData);
            }

            //当有剩余data，并且位移大于0，则在最后需要把数据挪到buffer的头部位置
            if (nRemainDataSize > 0 && nParseIndex > 0)
            {
                Buffer.BlockCopy(buffer, (int)nParseIndex, buffer, 0, (int)nRemainDataSize);
            }

            // 最后记得把_revLength修正为剩余未解析的数据大小
            dataLen = nRemainDataSize;
        }
        /// <summary>
        /// 解码处理
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="nParseIndex"></param>
        /// <param name="nRemainDataSize"></param>
        /// <returns></returns>
        public MessageData DecodingEx(byte[] buffer, ref int nParseIndex, ref int nRemainDataSize)
        {
            MessageData result = null;

            //剩余数据必须大于等于消息头
            if (nRemainDataSize >= MessageData.HeaderBufferSize)
            {
                // 包头结构：4字节包大小（不包含这个大小自己的4字节哈），4字节消息ID
                int nMsgSize = ByteArray.ReadInt(buffer, (int)nParseIndex);
                int nMsgID = ByteArray.ReadInt(buffer, (int)(nParseIndex + 4));

                //是否zip, 处理一下isZip，占nMsgSize的头8位
                bool isZip = (nMsgSize >> 24) > 0;
                //消息内容长度
                nMsgSize = nMsgSize & 0x00FFFFFF;

                // 消息内容包体大小
                int nMsgBodySize = nMsgSize - 4;
                // 消息整包大小，包含了头4字节
                int nMsgAllSize = nMsgSize + 4; 

                if (nMsgBodySize == 0)
                {
                    // 空包，只有消息头
                    result =  MessageData.GetMsgData(nMsgBodySize, nMsgID);

                    //移动指针
                    nParseIndex += MessageData.HeaderBufferSize;
                    nRemainDataSize -= MessageData.HeaderBufferSize;
                }
                else
                {
                    // 检查是否是完整包
                    if (nMsgAllSize <= nRemainDataSize)
                    {
                        
                        // 至少是个完整包
                        result = MessageData.GetMsgData(nMsgBodySize, nMsgID);

                        // 内容复制
                        Buffer.BlockCopy(buffer, (int)nParseIndex + MessageData.HeaderBufferSize, result.Data, 0, (int)(nMsgBodySize));

                        // 是个压缩包，解压
                        if (isZip) zipDecompress(ref result);

                        //移动指针
                        nParseIndex += nMsgAllSize;
                        nRemainDataSize -= nMsgAllSize;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 对zip压缩过的数据解包
        /// </summary>
        /// <param name="tempData"></param>
        /// <returns></returns>
        private bool zipDecompress(ref MessageData msgData)
        {
            try
            {
                doUnzip(ref msgData);
            }
            catch (System.Exception ex)
            {
                FLogger.TraceFail(ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 开始做unzip操作
        /// </summary>
        /// <param name="data"></param>
        private void doUnzip(ref MessageData data)
        {
            //FLogger.TraceWrite(string.Format("doUnzip: id={0} len={1}", data.ID, data.Data.Length));
            if (_zipInputMS == null)
            {
                _zipInputMS = new MemoryStream();
            }

            if (_zipOutMS == null)
            {
                _zipOutMS = new MemoryStream();
            }
            if (_unzipBuffer == null)
            {
                _unzipBuffer = new byte[CN_UNZIP_BUFF_SIZE];
            }

            _zipInputMS.SetLength(data.DataSize);
            _zipInputMS.Position = 0;
            _zipInputMS.Write(data.Data, 0, (int)data.DataSize);
            _zipInputMS.Position = 0;

          
            _zipOutMS.Position = 0;
            _zipOutMS.SetLength(0);

            ZlibStream zlbs;

            zlbs = new ZlibStream(_zipInputMS, CompressionMode.Decompress);

            int count = 0;
            while ((count = zlbs.Read(_unzipBuffer, 0, _unzipBuffer.Length)) != 0)
            {
                _zipOutMS.Write(_unzipBuffer, 0, count);
                if (count == _unzipBuffer.Length)
                {
                    //FLogger.TraceWrite(string.Format("消息协议{0}长度太长了，超过8192字节，请检查", data.ID));
                    //return false;
                }
            }

            byte[] unzipedBytes = _zipOutMS.ToArray();
            if (data.Data != null && data.Data.Length >= unzipedBytes.Length)
            {
                Buffer.BlockCopy(unzipedBytes, 0, data.Data, 0, (int)unzipedBytes.Length);
                //消息可以继续使用，重新设置下数据长度
                data.DataSize = unzipedBytes.Length;
            }
            else
            {
                //消息放不下数据了，需要重新获取一个
                var msgID = data.MsgID;
                MessageData.FreeMsgData(data);
                data = MessageData.GetMsgData(unzipedBytes.Length, msgID);
                Buffer.BlockCopy(unzipedBytes, 0, data.Data, 0, (int)unzipedBytes.Length);
            }

            //清空内存
            _zipInputMS.SetLength(0);
            _zipOutMS.SetLength(0);
        }
        #endregion

    }
}
