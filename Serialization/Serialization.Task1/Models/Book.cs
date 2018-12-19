using System;
using System.Xml.Serialization;

namespace Serialization.Task1.Models
{
    /// <summary>
    /// Represents a <see cref="Book"/> class.
    /// </summary>
    public class Book
    {
        /// <summary>Gets or sets Id.</summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>Gets or sets isbn.</summary>
        [XmlElement(ElementName = "isbn")]
        public string Isbn { get; set; }

        /// <summary>Gets or sets author.</summary>
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        /// <summary>Gets or sets title.</summary>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>Gets or sets genre.</summary>
        [XmlElement(ElementName = "genre")]
        public Genre Genre { get; set; }

        /// <summary>Gets or sets publisher.</summary>
        [XmlElement(ElementName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>Gets or sets publish date.</summary>
        [XmlElement(ElementName = "publish_date")]
        public DateTime PublishDate { get; set; }

        /// <summary>Gets or sets description.</summary>
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        /// <summary>Gets or sets registration date.</summary>
        [XmlElement(ElementName = "registration_date")]
        public DateTime RegistrationDate { get; set; }
    }
}
