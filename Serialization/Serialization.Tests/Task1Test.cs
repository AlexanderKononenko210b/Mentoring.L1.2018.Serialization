using System;
using System.Configuration;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Serialization.Task1;
using Serialization.Task1.Models;

namespace Serialization.Tests
{
    [TestFixture]
    public class Task1Test
    {
        private Catalog _catalog;
        private string _filePath = Path.Combine(ConfigurationManager.AppSettings["fileDirectory"], ConfigurationManager.AppSettings["fileName"]);

        [Test]
        public void DeserializeTest()
        {
            var xmlSerializeService = new XmlSerializeService();

            var _catalog = xmlSerializeService.Deserialize(_filePath);

            foreach (var book in _catalog.Books)
            {
                Console.WriteLine(book.Id);
                Console.WriteLine(book.Isbn);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Genre);
                Console.WriteLine(book.Publisher);
                Console.WriteLine(book.PublishDate);
                Console.WriteLine(book.Description);
                Console.WriteLine(book.RegistrationDate);
                Console.WriteLine();
            }

            Assert.NotNull(_catalog);
            Assert.True(_catalog.Books.Any());
        }

        [Test]
        public void SerializeTest()
        {
            var xmlSerializeService = new XmlSerializeService();

            var _catalog = xmlSerializeService.Deserialize(_filePath);

            xmlSerializeService.Serialize(_filePath, _catalog);
        }
    }
}
