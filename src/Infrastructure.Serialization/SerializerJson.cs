using System;
using System.Text;
using Infrastructure.Serialization.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Serialization
{
    public class SerializerJson : ISerializer
    {
        public TResult DeserializeTo<TResult>(byte[] args) where TResult : class
        {
            return JsonConvert.DeserializeObject<TResult>(Encoding.UTF8.GetString(args));
        }

        public object DeserializeToType(byte[] args, Type type)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(args), type);
        }

        public byte[] ToPayload(object o)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
        }
    }
}
