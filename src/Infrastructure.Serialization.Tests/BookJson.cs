using System;
using System.Collections.Generic;

namespace Infrastructure.Serialization.Tests
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BookJson
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
    }

    public class BookJsons
    {
        public List<BookJson> Books { get; set; }
    }
}
