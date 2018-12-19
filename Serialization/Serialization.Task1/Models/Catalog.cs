using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serialization.Task1.Models
{
    /// <summary>
    /// Represents a <see cref="Catalog"/> class.
    /// </summary>
    [XmlRoot(ElementName = "catalog", Namespace = Xmlns)]
    public class Catalog
    {
        public const string Xmlns = "http://library.by/catalog";

        /// <summary>Gets or sets date.</summary>
        [XmlAttribute(AttributeName = "date", DataType = "date")]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets books.</summary>
        [XmlElement(ElementName = "book")]
        public List<Book> Books { get; set; }
    }
}
