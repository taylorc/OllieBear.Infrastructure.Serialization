using System;

namespace Infrastructure.Serialization.Interfaces
{
    public interface ISerializer
    {
        TResult DeserializeTo<TResult>(byte[] args) where TResult : class;

        TResult DeserializeTo<TResult>(string args) where TResult : class;

        object DeserializeToType(byte[] args, Type type);

        object DeserializeToType(string args, Type type);

        byte[] ToByteArrayPayload(object o);

        string ToStringPayload(object o);

    }
}