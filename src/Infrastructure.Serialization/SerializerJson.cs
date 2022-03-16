using System;
using System.Text;
using System.Text.Json;
using Infrastructure.Serialization.Interfaces;

namespace Infrastructure.Serialization
{
    public class SerializerJson : ISerializer
    {
        public TResult DeserializeTo<TResult>(byte[] args) where TResult : class
        {
            return JsonSerializer.Deserialize<TResult>(Encoding.UTF8.GetString(args));
        }
        
        public TResult DeserializeTo<TResult>(string args) where TResult : class
        {
            return JsonSerializer.Deserialize<TResult>(args);
        }

        public object DeserializeToType(byte[] args, Type type)
        {
            return JsonSerializer.Deserialize(Encoding.UTF8.GetString(args), type);
        }
        
        public object DeserializeToType(string args, Type type)
        {
            return JsonSerializer.Deserialize(args, type);
        }

        public byte[] ToByteArrayPayload(object o)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(o));
        }

        public string ToStringPayload(object o)
        {
            return JsonSerializer.Serialize(o);
        }
    }
}
