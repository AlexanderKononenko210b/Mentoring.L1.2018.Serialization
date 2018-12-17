using Serialization.Task1.Models;
using System.IO;
using System.Xml.Serialization;

namespace Serialization.Task1
{
    /// <summary>
    /// Represents a <see cref="XmlSerializeService"/> class.
    /// </summary>
    public class XmlSerializeService
    {
        /// <summary>
        /// Serialize instance type <see cref="Catalog"/>
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="catalog"></param>
        public void Serialize(string filePath, Catalog catalog)
        {
            var serializer = new XmlSerializer(typeof(Catalog));
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(stream, catalog);
            }
        }

        /// <summary>
        /// Deserialize xml data to <see cref="Catalog"/> type.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The <see cref="Catalog"/> instance.</returns>
        public Catalog Deserialize(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Catalog));

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return (Catalog)serializer.Deserialize(stream);
            }
        }
    }
}
