using System;
using System.Text;
using System.IO;

namespace GameLib.Core.Utils
{

    /// <summary>
    /// 快速的写二进制流
    /// </summary>
    public unsafe class FastBinaryWriter : BinaryWriter 
    {

        byte[] _buffer = new byte[32];

        public FastBinaryWriter( Stream input ) : base( input ) { }
        public FastBinaryWriter( Stream input, Encoding encoding ) : base( input, encoding ) { }

        public override void Write( double value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(double*)p = value;
            }
            base.Write( _buffer, 0, sizeof( double ) );
        }

        public override void Write( float value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(float*)p = value;
            }
            base.Write( _buffer, 0, sizeof( float ) );
        }

        public override void Write( int value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(int*)p = value;
            }
            base.Write( _buffer, 0, sizeof( int ) );
        }

        public override void Write( long value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(long*)p = value;
            }
            base.Write( _buffer, 0, sizeof( long ) );
        }

        public override void Write( short value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(short*)p = value;
            }
            base.Write( _buffer, 0, sizeof( short ) );
        }

        public override void Write( uint value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(uint*)p = value;
            }
            base.Write( _buffer, 0, sizeof( uint ) );
        }

        public override void Write( ulong value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(ulong*)p = value;
            }
            base.Write( _buffer, 0, sizeof( ulong ) );
        }

        public override void Write( ushort value ) {
            fixed ( byte* p = &( _buffer[0] ) ) {
                *(ushort*)p = value;
            }
            base.Write( _buffer, 0, sizeof( ushort ) );
        }
    }
}
