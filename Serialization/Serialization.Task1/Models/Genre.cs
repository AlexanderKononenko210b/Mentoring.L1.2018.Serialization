using System.Xml.Serialization;

namespace Serialization.Task1.Models
{
    /// <summary>
    /// Represents a <see cref="Genre"/> class.
    /// </summary>
    public enum Genre
    {
        /// <summary>Computer genre.</summary>
        [XmlEnum("Computer")]
        Computer = 1,

        /// <summary>Fantasy genre.</summary>
        [XmlEnum("Fantasy")]
        Fantasy = 2,

        /// <summary>Romance genre.</summary>
        [XmlEnum("Romance")]
        Romance = 3,

        /// <summary>Horror genre.</summary>
        [XmlEnum("Horror")]
        Horror = 4,

        /// <summary>Science Fiction genre.</summary>
        [XmlEnum("Science Fiction")]
        ScienceFiction = 5
    }
}
