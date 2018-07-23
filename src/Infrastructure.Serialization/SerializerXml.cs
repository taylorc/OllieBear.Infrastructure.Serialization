using Infrastructure.Serialization.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.Serialization
{
    public class SerializerXml : ISerializer
    {
        public Dictionary<string, string> Namespaces { get; set; }

        public T DeserializeTo<T>(byte[] args) where T : class
        {
            var stream = new MemoryStream(args);

            var result = new XmlSerializer(typeof(T)).Deserialize(stream);

            if (!(result is T))
            {
                throw new Exception($"Unable to deserialize message into type {typeof(T).Name}: {args}");
            }

            return (T)result;
        }

        public object DeserializeToType(byte[] args, Type type)
        {
            var stream = new MemoryStream(args);

            return new XmlSerializer(type).Deserialize(stream);
        }

        public byte[] ToPayload(object o)
        {
            var serializer = new XmlSerializer(o.GetType());

            var namespaces = new XmlSerializerNamespaces();

            foreach (var ns in Namespaces ?? new Dictionary<string, string>())
                namespaces.Add(ns.Key, ns.Value);

            using (var sw = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sw))
                {
                    writer.WriteProcessingInstruction("xml", "version='1.0'");

                    serializer.Serialize(writer, o, namespaces);
                    return Encoding.UTF8.GetBytes(sw.ToString());
                }
            }
        }
    }
}