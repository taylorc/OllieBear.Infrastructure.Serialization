using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Infrastructure.Serialization.Interfaces;
using Shouldly;
using Xunit;

namespace Infrastructure.Serialization.Tests
{
    public class XmlSerializerTests
    {
        private readonly ISerializer _serializer;

        public XmlSerializerTests()
        {
            _serializer = new SerializerXml();
        }
        [Fact]
        public void Should_Serialize_From_Bytes()
        {
            var xml = new StringReader(File.ReadAllText("books-xml.xml"));

            var bookXml = _serializer.DeserializeTo<Catalog>(Encoding.Default.GetBytes(xml.ReadToEnd().ToCharArray()));

            bookXml.ShouldNotBeNull();

            xml.Dispose();
        }
    }
}