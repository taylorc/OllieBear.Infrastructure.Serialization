using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.Serialization.Tests
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Catalog)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "book")]
    public class Book
    {

        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "genre")]
        public string Genre { get; set; }

        [XmlElement(ElementName = "price")]
        public double Price { get; set; }

        [XmlElement(ElementName = "publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "catalog")]
    public class Catalog
    {

        [XmlElement(ElementName = "book")]
        public List<Book> Book { get; set; }
    }


}