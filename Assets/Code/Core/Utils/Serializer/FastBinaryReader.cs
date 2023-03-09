using System;
using System.Text;
using System.IO;

namespace GameLib.Core.Utils
{

    /// <summary>
    /// 快速的读取二进制流
    /// </summary>
    public unsafe class FastBinaryReader : BinaryReader 
    {

        byte[] _buffer = new byte[32];

        public FastBinaryReader( Stream input ) : base( input ) { }
        public FastBinaryReader( Stream input, Encoding encoding ) : base( input, encoding ) { }

        public override double ReadDouble() {
            base.Read( _buffer, 0, 8 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (double*)p ) );
            }
        }
        public override short ReadInt16() {
            base.Read( _buffer, 0, 2 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (short*)p ) );
            }
        }
        public override int ReadInt32() {
            base.Read( _buffer, 0, 4 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (int*)p ) );
            }
        }
        public override long ReadInt64() {
            base.Read( _buffer, 0, 8 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (long*)p ) );
            }
        }
        public override float ReadSingle() {
            base.Read( _buffer, 0, 4 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (float*)p ) );
            }
        }
        public override ushort ReadUInt16() {
            base.Read( _buffer, 0, 2 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (ushort*)p ) );
            }
        }
        public override uint ReadUInt32() {
            base.Read( _buffer, 0, 4 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (uint*)p ) );
            }
        }
        public override ulong ReadUInt64() {
            base.Read( _buffer, 0, 8 );
            fixed ( byte* p = &( _buffer[0] ) ) {
                return *( ( (ulong*)p ) );
            }
        }
    }
}
