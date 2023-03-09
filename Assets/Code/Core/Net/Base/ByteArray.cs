using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GameLib.Core.Net
{
    public class ByteArray
    {
        private List<byte> _bytes = new List<byte>();

        public ByteArray()
        {
        }


        public ByteArray(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                _bytes.Add(buffer[i]);
            }
        }


        public int Length
        {
            get { return _bytes.Count; }
        }

        public int Postion
        {
            get;
            set;
        }

        public byte[] Buffer
        {
            get { return _bytes.ToArray(); }
        }


        public bool ReadBoolean()
        {
            byte b = _bytes[Postion];
            Postion += 1;
            return b == (byte)0 ? false : true;
        }

        public byte ReadByte()
        {
            byte result = _bytes[Postion];
            Postion += 1;
            return result;
        }

        public void WriteInt(int value)
        {
            byte[] bs = new byte[4];
            bs[0] = (byte)(value >> 24);
            bs[1] = (byte)(value >> 16);
            bs[2] = (byte)(value >> 8);
            bs[3] = (byte)(value);
            _bytes.AddRange(bs);
        }

        public int ReadInt()
        {
            byte[] bs = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bs[i] = _bytes[i + Postion];
            }
            Postion += 4;
            int result = (int)bs[3] | ((int)bs[2] << 8) | ((int)bs[1] << 16) | ((int)bs[0] << 24);
            return result;
        }

        public static int ReadInt(byte[] bs, int offset)
        {
            int result = (int)bs[3 + offset] | ((int)bs[2 + offset] << 8) | ((int)bs[1 + offset] << 16) | ((int)bs[0 + offset] << 24);
            return result;
        }

        public string ReadUTFBytes(uint length)
        {
            if (length == 0)
                return string.Empty;
            byte[] b = new byte[length];
            for (int i = 0; i < length; i++)
            {
                b[i] = _bytes[i + Postion];
            }
            Postion += (int)length;
            string decodedstring = Encoding.UTF8.GetString(b);
            return decodedstring;
        }
        public void WriteUTFBytes(string value)
        {
            byte[] bs = Encoding.UTF8.GetBytes(value);
            _bytes.AddRange(bs);
        }

        public void WriteUTFBytes(byte[] value)
        {
            //byte[] bs = Encoding.UTF8.GetBytes(value);
            _bytes.AddRange(value);
        }

        public void WriteBoolean(bool value)
        {
            _bytes.Add(value ? ((byte)1) : ((byte)0));
        }
        public void WriteByte(byte value)
        {
            _bytes.Add(value);
        }
        public void WriteBytes(byte[] value, int offset, int length)
        {
            for (int i = 0; i < length; i++)
            {
                _bytes.Add(value[i + offset]);
            }
        }
        public void WriteBytes(byte[] value)
        {
            _bytes.AddRange(value);
        }

        public void clean()
        {
            _bytes.Clear();
            Postion = 0;
        }

    }
}