using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Xml.Serialization;
using Task.SerializationContexts;
using Task.Surrogates;

namespace Task
{
	[TestClass]
	public class SerializationSolutions
	{
		Northwind dbContext;

		[TestInitialize]
		public void Initialize()
		{
			dbContext = new Northwind();
		}

		[TestMethod]
		public void SerializationCallbacks()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

		    var serializationContext = new SerializationContext
		    {
		        ObjectContext = (dbContext as IObjectContextAdapter).ObjectContext,
		        TypeToSerialize = typeof(Product)
		    };

            var tester = new XmlDataContractSerializerTester<IEnumerable<Category>>(new NetDataContractSerializer(
                new StreamingContext(StreamingContextStates.All, serializationContext)), true);
            var categories = dbContext.Categories.ToList();

			var c = categories.First();

			tester.SerializeAndDeserialize(categories);
		}

		[TestMethod]
		public void ISerializable()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

		    var serializationContext = new SerializationContext
		    {
		        ObjectContext = (dbContext as IObjectContextAdapter).ObjectContext,
		        TypeToSerialize = typeof(Product)
		    };

            var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(
                    new StreamingContext(StreamingContextStates.All, serializationContext)), true);
			var products = dbContext.Products.ToList();

			tester.SerializeAndDeserialize(products);
		}


		[TestMethod]
		public void ISerializationSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

		    var serializationContext = new SerializationContext
		    {
		        ObjectContext = (dbContext as IObjectContextAdapter).ObjectContext,
		        TypeToSerialize = typeof(Order_Detail)
		    };

		    var xmlSerializer = new NetDataContractSerializer
		    {
		        SurrogateSelector = new OrderDetailSurrogateSelector(),
		        Context = new StreamingContext(StreamingContextStates.All, serializationContext)
		    };


            var tester = new XmlDataContractSerializerTester<IEnumerable<Order_Detail>>(xmlSerializer, true);
			var orderDetails = dbContext.Order_Details.ToList();

			tester.SerializeAndDeserialize(orderDetails);
		}

		[TestMethod]
		public void IDataContractSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = true;
			dbContext.Configuration.LazyLoadingEnabled = true;

            var xmlSerializer = new DataContractSerializer(typeof(IEnumerable<Order>),
                new DataContractSerializerSettings
                {
                    DataContractSurrogate = new OrderDataContractSurrogate()
                });

			var tester = new XmlDataContractSerializerTester<IEnumerable<Order>>(xmlSerializer, true);
			var orders = dbContext.Orders.ToList();

			tester.SerializeAndDeserialize(orders);
		}
	}
}
