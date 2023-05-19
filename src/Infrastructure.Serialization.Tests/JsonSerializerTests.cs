using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Infrastructure.Serialization.Interfaces;
using Shouldly;
using Xunit;

namespace Infrastructure.Serialization.Tests
{
    public class JsonSerializerTests
    {
        private readonly ISerializer _serializer;

        public JsonSerializerTests()
        {
            _serializer = new SerializerJson();
        }
        [Fact]
        public void Should_Serialize_From_Bytes()
        {
            var json = new StringReader(File.ReadAllText("books.json"));

            var result = _serializer.DeserializeTo<Catalog>(Encoding.Default.GetBytes(json.ReadToEnd().ToCharArray()));

            result.ShouldNotBeNull();

            json.Dispose();
        }
    }
}