
namespace ProtoBuf
{
    /// <summary>
    /// Indicates that the implementing type has support for protocol-buffer
    /// <see cref="IExtension">extensions</see>.
    /// </summary>
    /// <remarks>Can be implemented by deriving from Extensible.</remarks>
    public interface IExtensible
    {
        void Excute();
        void Send();
        //int GetMsgID();
        void Clear();
    }
    public interface IReqMessage
    {

    }

    public interface IResMessage
    {
        void ReadMessage(byte[] bytes);
    }

    public interface IMessageInfo
    {
        void ReadMessage(ref int readPos, int totalCount);
        int WriteMessage(int fieldNumber);
    }

}
