using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Infrastructure.Serialization.Interfaces;
using Shouldly;
using Xunit;

namespace Infrastructure.Serialization.Tests
{
    public class XmlSerilizerTests
    {
        private readonly ISerializer _serializer;

        public XmlSerilizerTests()
        {
            _serializer = new SerializerXml();
        }
        [Fact]
        public void Should_Serialize_From_Bytes()
        {
            var xml = new StringReader(File.ReadAllText("books-xml.xml"));

            var bookXml = _serializer.DeserializeTo<BookXml>(Encoding.Default.GetBytes(xml.ReadToEnd().ToCharArray()));

            bookXml.ShouldNotBeNull();

            xml.Dispose();
        }
    }
}