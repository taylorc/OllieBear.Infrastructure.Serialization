using System;

namespace Infrastructure.Serialization.Interfaces
{
    public interface ISerializer
    {
        TResult DeserializeTo<TResult>(byte[] args) where TResult : class;

        object DeserializeToType(byte[] args, Type type);

        byte[] ToPayload(object o);
    }
}